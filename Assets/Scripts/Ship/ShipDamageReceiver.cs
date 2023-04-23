using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDamageReceiver : DamageReceiver
{

    [SerializeField] protected ShipController shipController;
    public ShipController ShipController => shipController;

    protected override void Start()
    {
        base.Start();
        PlayerHealthBar.Instance.SetMaxHealth(this.maxHealthPoint);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        PlayerHealthBar.Instance.SetHealth(this.healthPoint);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipController();
    }

    protected virtual void LoadShipController()
    {
        if (shipController != null) return;
        shipController = transform.parent.GetComponent<ShipController>();
        Debug.Log(transform.name + ": LoadShipController", gameObject);
    }

    protected override void SetupMaxHealth()
    {
        baseMaxHealthPoint = shipController.ShipProfile.maxHeath;
        base.SetupMaxHealth();
    }

    protected override void OnDead()
    {
        Debug.Log("Dead");
    }
}
