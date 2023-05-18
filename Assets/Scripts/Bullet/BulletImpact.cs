using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class BulletImpact : BulletAbstract
{
    [SerializeField] protected Collider2D sphereCollider;

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
        DamageReceiver bulletDamageSender = collision.GetComponent<DamageReceiver>();
        if (bulletDamageSender != null && this.BulletController.isSendDamage)
        {
            this.bulletController.BulletDamageSender.HitPos = transform.position;
            this.bulletController.BulletDamageSender.Send(collision.transform);

        }
    }
}
