using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveShield : ShieldAbstract
{
    protected virtual void FixedUpdate()
    {
        this.Shielding();
    }

    protected virtual void Shielding()
    {
        if (this.ShieldAbility.TimeRemains <= 0)
        {
            DisableShield();
            this.ShieldAbility.TimeRemains = 0;
            return;
        }
        this.ShieldAbility.TimeRemains -= Time.fixedDeltaTime;
    }

    public void Shield()
    {
        this.ShieldAbility.TimeRemains = this.ShieldAbility.TimeExists;
        if (!this.ShieldAbility.IsActived)
        {
            this.ShieldAbility.Model.gameObject.SetActive(true);
            this.ShieldAbility.IsActived = true;
        }
    }

    public void DisableShield()
    {
        this.ShieldAbility.Model.gameObject.SetActive(false);
        this.ShieldAbility.IsActived = false;
    }

    public void SetTimeExists(float time)
    {
        this.ShieldAbility.TimeExists = time;
    }
}
