using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    [Header("BulletSpawner")]
    private static BulletSpawner instance;

    public static BulletSpawner Instance => instance;
    public string BulletOne = "SurikenBullet";
    public string BulletTwo = "SnakeBullet";

    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null) Debug.LogError("Only allow 1 instance");
        BulletSpawner.instance = this;
    }
}
