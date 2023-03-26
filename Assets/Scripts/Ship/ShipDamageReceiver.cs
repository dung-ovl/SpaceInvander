using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDamageReceiver : DamageReceiver
{

    [SerializeField] protected ShipController shipController;
    public ShipController ShipController { get { return shipController; } }
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
