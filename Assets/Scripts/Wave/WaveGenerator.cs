using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveGenerator : GameMonoBehaviour
{
    [SerializeField] private WaveController wave;
    [SerializeField] private float startDelay = 2f;
    [SerializeField] private  List<Transform> enemys;
    [SerializeField] private bool isFollowPathDone = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWaveController();
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

    protected virtual void LoadWaveController()
    {
        if (this.wave != null) return;
        this.wave = transform.GetComponent<WaveController>();
        Debug.Log(transform.name + ": LoadWaveController", gameObject);
    }

    protected virtual void StartWave()
    {
        Invoke("EnemySpawn", startDelay);
    }

    private void EnemyPlacement()
    {
        if (!isFollowPathDone) return;
        for (int i = 0; i < enemys.Count; i++)
        {
            Vector3 placePoint = this.wave.PlacePoint.Points[i].transform.position;
            var change = 2 * Time.deltaTime;
            this.enemys[i].transform.position = Vector3.MoveTowards(this.enemys[i].transform.position, placePoint, change);
        }
    }

    protected virtual void EnemySpawn()
    {
        Vector3 spawnPos = this.wave.SpawnPoint.Points[0].transform.position;
        EnemyShipProfileSO enemyShipProfileSO = (EnemyShipProfileSO)this.wave.WaveProfile.enemyListType[0];
        string enemyName = enemyShipProfileSO.GetEnemyTypeName();
        Quaternion enemyRot = Quaternion.Euler(0, 0, -180);
        for (int i = 1; i <= this.wave.WaveProfile.amountOfEnemy; i++)
        {
            Transform newEnemy = EnemySpawner.Instance.Spawn(enemyName, spawnPos, enemyRot);
            if (newEnemy == null) return;
            newEnemy.gameObject.SetActive(true);
            this.enemys.Add(newEnemy);
            Debug.Log("Spawn");
        }
        this.isFollowPathDone = true;
    }
}
