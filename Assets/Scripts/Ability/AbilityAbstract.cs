using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityAbstract : GameMonoBehaviour
{
    [Header("Ability")]
    [SerializeField] protected bool isActived = false;
    public bool IsActived { get { return isActived; } set { isActived = value; } }

    [SerializeField] protected AbilityController abilityController;
    public AbilityController AbilityController { get { return abilityController; } }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilityController();
    }

    protected virtual void LoadAbilityController()
    {
        if (abilityController != null) return;
        abilityController = transform.parent.GetComponent<AbilityController>();
        Debug.Log(transform.name + ": LoadAbilityController", gameObject);
    }

    public abstract void Active();
}
