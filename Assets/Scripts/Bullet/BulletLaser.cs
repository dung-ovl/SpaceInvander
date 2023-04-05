using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class BulletLaser : GameMonoBehaviour
{
    [SerializeField] protected float distanceRay = 100f;
    [SerializeField] protected LineRenderer lineRenderer;
    [SerializeField] protected Transform laserFirePoint;
    [SerializeField] protected Transform endFirePoint;

    public DamageSender damageSender = new BulletDamageSender();
    protected void Update()
    {
        ShootLaser();
    }

    protected virtual void ShootLaser()
    {
        Draw2DRay(laserFirePoint.position, endFirePoint.position);
        Vector2 direction = endFirePoint.position - laserFirePoint.position;
        RaycastHit hit;
        if (Physics.Raycast(laserFirePoint.position, direction.normalized, out hit, direction.magnitude))
        {
            DamageReceiver damage = hit.collider.GetComponent<DamageReceiver>();
            if (damage != null && damage.transform.parent.name != "Ship")
            {
                Draw2DRay(laserFirePoint.position, hit.point);
                Debug.Log("Laser trung roi " + hit.collider.transform.parent.name);
                damageSender.transform.position = hit.point;
                damageSender.Send(damage.transform);
            }
        }
    }

    protected virtual void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}