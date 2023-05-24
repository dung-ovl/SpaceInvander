using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIHealthBar : UIHealthBar
{
    [SerializeField] private ShipDamageReceiver shipDamageReceiver;
    public ShipDamageReceiver ShipDamageReceiver => shipDamageReceiver;

    
    protected override void Start()
    {
        this.LoadShipDamageReceiver();
        this.SetMaxHealth(shipDamageReceiver.MaxHealthPoint);
    }

    private void LoadShipDamageReceiver()
    {
        if (shipDamageReceiver != null) return;
        this.shipDamageReceiver = GameCtrl.Instance.CurrentShip.GetComponent<ShipController>().ShipDamageReceiver;
    }

    private void Update()
    {
        this.SetHealth(shipDamageReceiver.HealthPoint);
    }
}
