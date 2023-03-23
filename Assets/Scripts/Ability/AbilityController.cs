using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : ShipAbstract
{
    [SerializeField] protected HealAbility healAbility;
    public HealAbility HealAbility => healAbility;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilityController();
    }

    protected virtual void LoadAbilityController()
    {
        if (healAbility != null) return;
        healAbility = transform.GetComponentInChildren<HealAbility>();
        Debug.Log(transform.name + ": LoadHealAbility", gameObject);
    }
}
