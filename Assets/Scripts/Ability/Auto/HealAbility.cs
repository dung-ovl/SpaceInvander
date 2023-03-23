using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAbility : AbilityAbstract
{
    [Header("Heal")]
    [SerializeField] protected DamageReceiver damageReceiver;
    [SerializeField] protected float healPoint = 5f;



    protected virtual void FixedUpdate()
    {
        Invoke("Test", 2f);
    }

    protected virtual void Test()
    {
        this.Active();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageReceiver();
    }

    protected virtual void LoadDamageReceiver()
    {
        if (damageReceiver != null) return;
        damageReceiver = abilityController.ShipController.ShipDamageReceiver;
        Debug.Log(transform.name + ": LoadDamageReceiver", gameObject);
    }

    public override void Active()
    {
     
        this.damageReceiver.AddHealthPoint(healPoint);
    }

}
