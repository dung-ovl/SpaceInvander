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

    [SerializeField] protected BulletMissile bulletMissile;
    public BulletMissile BulletMissile => bulletMissile;

    [SerializeField] protected BulletCircle bulletCircle;
    public BulletCircle BulletCircle => bulletCircle;

    [SerializeField] protected BulletSeparate bulletPower;
    public BulletSeparate BulletPower => bulletPower;

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
        this.bulletPower = transform.GetComponentInChildren<BulletSeparate>();
        //Debug.Log(transform.name + ": LoadBulletPower", gameObject);
    }

    protected virtual void LoadBulletCircle()
    {
        if (this.bulletCircle != null) return;
        this.bulletCircle = transform.GetComponentInChildren<BulletCircle>();
        //Debug.Log(transform.name + ": LoadBulletCircle", gameObject);
    }

    protected virtual void LoadBulletMissile()
    {
        if (this.bulletMissile != null) return;
        this.bulletMissile = transform.GetComponentInChildren<BulletMissile>();
        //Debug.Log(transform.name + ": LoadBulletMissile", gameObject);
    }

    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }
}
