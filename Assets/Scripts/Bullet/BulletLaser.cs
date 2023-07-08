using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BulletLaser : GameMonoBehaviour
{
    LaserBeam beam;
    [SerializeField] protected Transform position;
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender => damageSender;
    [SerializeField] protected bool isLaser;

    public string laserName;

    public Transform Position { get { return position; }  set { position = value; } }
    public bool IsLaser { get { return isLaser; } set{ isLaser = value; } }

    public float Rot;
    protected virtual void FixedUpdate()
    {
        if (isLaser)
        {
            Destroy(GameObject.Find(laserName));
            Vector3 end = new Vector3(position.position.x + 5 * Mathf.Sin(-Rot), position.position.y + 5 * Mathf.Cos(-Rot));

            Vector3 direction = end - position.position;
            beam = new LaserBeam(position.position, direction, damageSender, laserName);
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
    }

    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = transform.GetComponentInChildren<DamageSender>();
        Debug.Log(transform.name + " LoadDamageSender ", gameObject);
    }
}