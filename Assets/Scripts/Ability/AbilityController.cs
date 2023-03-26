using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbilityController : ShipAbstract
{
    [SerializeField] protected HealAbility healAbility;
    public HealAbility HealAbility => healAbility;

    [SerializeField] protected ShieldAbility shieldAbility;
    public ShieldAbility ShieldAbility => shieldAbility;

    [SerializeField] protected List<Ability> abilities;
    public List<Ability> Abilities => abilities;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilityController();
        this.LoadShieldAbility();
        this.LoadAbilities();
    }

    protected virtual void LoadAbilities()
    {
        if (abilities.Count > 0) return;
        abilities = transform.GetComponentsInChildren<Ability>().ToList();
        Debug.Log(transform.name + ": LoadAbilities", gameObject);
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
