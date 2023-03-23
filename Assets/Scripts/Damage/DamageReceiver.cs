using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : GameMonoBehaviour
{
    [Header("DamageReceiver")]
    [SerializeField] protected float healthPoint = 10f;
    [SerializeField] protected float maxHealthPoint = 10f;
    [SerializeField] protected bool isDead = false;


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

    protected abstract void OnDead();
}
