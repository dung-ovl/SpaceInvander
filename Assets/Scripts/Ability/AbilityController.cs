using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : ShipAbstract
{
    [SerializeField] protected HealAbility healAbility;
    public HealAbility HealAbility => healAbility;

    [SerializeField] protected ShieldAbility shieldAbility;
    public ShieldAbility ShieldAbility => shieldAbility;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilityController();
        this.LoadShieldAbility();
    }

    protected virtual void LoadAbilityController()
    {
        if (healAbility != null) return;
        healAbility = transform.GetComponentInChildren<HealAbility>();
        Debug.Log(transform.name + ": LoadHealAbility", gameObject);
    }

    protected virtual void LoadShieldAbility()
    {
        if (shieldAbility != null) return;
        shieldAbility = transform.GetComponentInChildren<ShieldAbility>();
        Debug.Log(transform.name + ": LoadShieldAbility", gameObject);
    }
}
