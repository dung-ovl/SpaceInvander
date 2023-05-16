using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class BulletImpact : BulletAbstract
{
    [SerializeField] protected Collider sphereCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == this.bulletController.Shooter) return;
        DamageReceiver bulletDamageSender = other.GetComponent<DamageReceiver>();
        if (bulletDamageSender != null && this.BulletController.isSendDamage)
        {
            this.bulletController.BulletDamageSender.HitPos = transform.position;
            this.bulletController.BulletDamageSender.Send(other.transform);
            
        }
    }
}
