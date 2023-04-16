using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePath : GameMonoBehaviour
{
    [SerializeField] List<Transform> path;
    [SerializeField] List<Transform> spawnpoints;
    public List<Transform> Spawnpoints => spawnpoints;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnerPoints();
    }

    private void LoadSpawnerPoints()
    {
        if (this.spawnpoints != null) return;

        foreach (Transform t in transform)
        {
            path.Add(t);
        }
        foreach (Transform t in this.path)
        {
            spawnpoints.Add(t.Find("SpawnPoint"));
        }
        Debug.Log(transform.name + ": LoadWaveProfile", gameObject);
    }
}
