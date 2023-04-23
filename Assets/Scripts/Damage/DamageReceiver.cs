using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public abstract class DamageReceiver : GameMonoBehaviour
{
    [Header("DamageReceiver")]
    [SerializeField] protected float healthPoint = 10f;
    [SerializeField] protected float baseMaxHealthPoint = 10f;
    [SerializeField] protected float maxHealthPointBonus = 0f;
    [SerializeField] protected float maxHealthPoint = 10f;
    [SerializeField] protected Collider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    public float MaxHealthPoint => maxHealthPoint;
    [SerializeField] protected bool isDead = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigidBody();
    }

    protected virtual void LoadRigidBody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        this._rigidbody.useGravity = false;
        Debug.Log(transform.name + "LoadCollider", gameObject);
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true; ;
        Debug.Log(transform.name + "LoadCollider", gameObject);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.Reborn();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }

    protected virtual void FixedUpdate()
    {
        CheckIsDead();
    }
    protected virtual void Reborn()
    {
        this.SetupMaxHealth();
        this.healthPoint = this.maxHealthPoint;
        this.isDead = false;
    }

    public virtual void AddHealthPoint(float hp)
    {
        this.healthPoint += hp;
        if (this.healthPoint > this.maxHealthPoint) healthPoint= this.maxHealthPoint;
    }

    public virtual void DeductHealthPoint(float hp)
    {
        this.healthPoint -= hp;
        if (this.healthPoint < 0) healthPoint = 0;

    }

    protected virtual bool IsDead()
    {
        return this.healthPoint <= 0;
    }

    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected virtual void SetupMaxHealth()
    {
        this.maxHealthPoint = this.baseMaxHealthPoint + this.maxHealthPointBonus;
    }

    protected abstract void OnDead();
}
