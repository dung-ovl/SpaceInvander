using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePowerUp : ActiveSustentiveAbility
{
    public override void Activating()
    {
        base.Activating();
        this.SustentiveAbility.AbilityController.ShipController.ShipShooting.SetupShootSpeed(100);
        Debug.Log("active Powerup");
    }

    public override void DisableActivating()
    {
        base.DisableActivating();
        this.SustentiveAbility.AbilityController.ShipController.ShipShooting.SetupShootSpeed();
    }
}
