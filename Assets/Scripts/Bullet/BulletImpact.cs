using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class BulletImpact : BulletAbstract
{
    [SerializeField] protected Collider2D sphereCollider;

    [SerializeField] protected bool isDestroyOnImpact = true;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponent<Collider2D>();
        this.sphereCollider.isTrigger = true;
        
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.transform.parent.name);
        if (collision.transform.parent == this.bulletController.Shooter) return;
        DamageReceiver damageReceiver = collision.GetComponent<DamageReceiver>();
        if (damageReceiver != null && this.BulletController.isSendDamage)
        {
            this.bulletController.BulletDamageSender.HitPos = collision.ClosestPoint(transform.position);
            this.bulletController.BulletDamageSender.Send(collision.transform, isDestroyOnImpact);

        }
    }
}
