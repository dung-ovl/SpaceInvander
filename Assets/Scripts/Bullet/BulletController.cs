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


    [SerializeField] protected BulletPower bulletPower;
    public BulletPower BulletPower => bulletPower;

    public bool isSendDamage;

    protected override void OnEnable()
    {
        base.OnEnable();
        isSendDamage = true;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletDespawn();
        this.LoadBulletDamageSender();
        this.LoadBulletBouncy();
        this.LoadBulletPower();
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

    protected virtual void LoadBulletPower()
    {
        if (this.bulletPower != null) return;
        this.bulletPower = transform.GetComponentInChildren<BulletPower>();
        //Debug.Log(transform.name + ": LoadBulletPower", gameObject);
    }

    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }
}
