using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [SerializeField] protected EnemyController enemyController;
    public EnemyController EnemyController => enemyController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyController();
    }

    private void LoadEnemyController()
    {
        if (this.enemyController != null) return;
        this.enemyController = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": LoadEnemyController", gameObject);
    }

    protected override void OnDead()
    {
        this.OnDeadFX();
        this.enemyController.EnemyDespawn.DespawnObject();
    }

    protected virtual void OnDeadFX()
    {
        string fxOnDeadName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxOnDeadName, transform.position, transform.rotation);
        if (fxOnDead == null) return;
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.Instance.E1_Detruction;
    }
}
