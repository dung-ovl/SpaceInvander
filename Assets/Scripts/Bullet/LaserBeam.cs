using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : GameMonoBehaviour
{
    RaycastHit oldhit;
    RaycastHit newHit;
    GameObject laserObj;
    LineRenderer lineRenderer;
    DamageSender damageSender;
    List<Vector3> laserInd = new List<Vector3>();

    public LaserBeam(Vector3 pos, Vector3 dir, DamageSender sender, string laserName)
    {
        this.damageSender = sender;
        this.lineRenderer = new LineRenderer();
        this.laserObj = new GameObject();
        this.laserObj.name = laserName;
        this.lineRenderer = this.laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        this.lineRenderer.startWidth = 0.05f;
        this.lineRenderer.endWidth = 0.05f;
        lineRenderer.material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));
        this.lineRenderer.startColor = Color.red;
        this.lineRenderer.endColor = Color.red;
        this.lineRenderer.sortingLayerName = "Bullet";
        CastRay(pos, dir, lineRenderer);
    }

    void CastRay(Vector3 pos, Vector3 dir, LineRenderer laser)
    {
        laserInd.Add(pos);
        Ray ray = new Ray(pos, dir);
        if (oldhit.collider != null)
        {
            oldhit.collider.enabled = false;
            //newHit = Physics2D.Raycast(pos, dir, 20f);
            Physics.Raycast(ray, out newHit, 30, 1);
            oldhit.collider.enabled = true;
        }
        else
        {
            Physics.Raycast(ray, out newHit, 30, 1);
        }
        if (newHit.collider != null)
        {
            CheckHit(newHit, dir, laser);
        }
        else
        {
            laserInd.Add(ray.GetPoint(20));
            UpdateLaser();
        }
    }

    void UpdateLaser()
    {
        int count = 0;
        lineRenderer.positionCount = laserInd.Count;

        foreach (Vector3 pos in laserInd)
        {
            lineRenderer.SetPosition(count, pos);
            count++;
        }
    }

    void CheckHit(RaycastHit raycast, Vector3 dir, LineRenderer lineRenderer)
    {
        if (raycast.collider.gameObject.tag == "Wall")
        {
            Vector3 pos = raycast.point;
            Vector3 direct = Vector3.Reflect(dir, raycast.normal);
            oldhit = raycast;
            CastRay(pos, direct, lineRenderer);
        }
        else if (raycast.collider.gameObject.tag == "EnemyTarget")
        {
            laserInd.Add(raycast.point);
            DamageReceiver damageReceiver = raycast.collider.GetComponent<DamageReceiver>();
            damageSender.HitPos = raycast.point;
            damageSender.Send(damageReceiver.transform.parent);
            Debug.Log("Sending damage " + damageReceiver.transform.parent.name);
            UpdateLaser();
        }
        else
        {
            UpdateLaser();
        }
    }
}
