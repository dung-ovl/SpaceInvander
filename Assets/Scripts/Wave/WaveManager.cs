using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : GameMonoBehaviour
{
    [SerializeField] private float startDelay = 2f;
    [SerializeField] private bool isFollowPathDone = false;
    [SerializeField] private FormationBase _formation;
    [SerializeField] private List<Vector3> _points;
    private readonly List<Transform> _spawnedEnemies;
    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    protected override void Start()
    {
        base.Start();
        this.StartWave();
    }

    private void FixedUpdate()
    {
        this.EnemyPlacement();
    }

    protected virtual void StartWave()
    {
        Invoke("EnemySpawn", startDelay);
    }

    private void EnemyPlacement()
    {
       
    }

    /*protected virtual void EnemySpawn()
    {
        Vector3 spawnPos = this.wave.MovePath.Spawnpoints[0].transform.position;
        EnemyShipProfileSO enemyShipProfileSO = (EnemyShipProfileSO)this.wave.WaveProfile.enemyListType[0];
        string enemyName = enemyShipProfileSO.GetEnemyTypeName();
        Quaternion enemyRot = Quaternion.Euler(0, 0, -180);
        for (int i = 1; i <= this.wave.WaveProfile.amountOfEnemy; i++)
        {
            Transform newEnemy = EnemySpawner.Instance.Spawn(enemyName, spawnPos, enemyRot);
            if (newEnemy == null) return;
            newEnemy.gameObject.SetActive(true);
            this._spawnedEnemies.Add(newEnemy);
            Debug.Log("Spawn");
        }
        this.isFollowPathDone = true;
    }*/
}
