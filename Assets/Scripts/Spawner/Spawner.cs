using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : GameMonoBehaviour
{
    private static Spawner instance;

    public static Spawner Instance { get => instance; }

    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] protected Transform holder;

    public string BulletOne = "SurikenBullet";
    public string BulletTwo = "SnakeBullet";

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected override void Awake()
    {
        base.Awake();
        if (Spawner.instance != null) Debug.LogError("Only 1 GameCtrl allow to exist");
        Spawner.instance = this;
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolder", gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        Transform prefabsObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabsObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();
        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        
        Transform prefab = this.GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.Log("Prefab not found: " + prefab.name);
            return null;
        }

        return Spawn(prefab, spawnPos, rotation);
    }


    public virtual Transform Spawn(Transform prefabs, Vector3 pos, Quaternion rot)
    {
        Transform newPrefab = this.GetObjectFromPool(prefabs);
        newPrefab.SetPositionAndRotation(pos, rot);
        newPrefab.parent = this.holder;
        return newPrefab;
    }


    protected virtual Transform GetPrefabByName(string prefabName)
    {
        return prefabs.Find(prefab => prefab.name == prefabName);
    }

    protected virtual Transform GetObjectFromPool(Transform prefabs)
    {
        foreach (Transform poolObj in poolObjs)
        {
            if (prefabs.name == poolObj.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefabs);
        newPrefab.name = prefabs.name;
        return newPrefab;
    }

    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }
}
