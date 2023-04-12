using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : GameMonoBehaviour
{
    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn => bulletDespawn;

    [SerializeField] protected BulletDamageSender bulletDamageSender;
    public BulletDamageSender BulletDamageSender => bulletDamageSender;

    [SerializeField] protected Transform shooter;
    public Transform Shooter => shooter;

    [SerializeField] protected BulletBouncy bulletBouncy;
    public BulletBouncy BulletBouncy => bulletBouncy;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletDespawn();
        this.LoadBulletDamageSender();
        this.LoadBulletBouncy();
    }

    protected virtual void LoadBulletDamageSender()
    {
        if (this.bulletDamageSender != null) return;
        this.bulletDamageSender = transform.GetComponentInChildren<BulletDamageSender>();
        Debug.Log(transform.name + ": LoadBulletDamageSender", gameObject);
    }

    protected virtual void LoadBulletBouncy()
    {
        if (this.bulletBouncy != null) return;
        this.bulletBouncy = transform.GetComponentInChildren<BulletBouncy>();
        Debug.Log(transform.name + ": LoadBulletBouncy", gameObject);
    }

    protected virtual void LoadBulletDespawn()
    {
        if (this.bulletDespawn != null) return;
        this.bulletDespawn = transform.GetComponentInChildren<BulletDespawn>();
        //Debug.Log(transform.name + ": LoadBulletDespawn", gameObject);
    }

    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }
}
