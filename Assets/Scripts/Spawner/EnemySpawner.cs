using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance { get => instance; }


    protected override void Awake()
    {
        base.Awake();
        EnemySpawner.instance = this;
    }
}
