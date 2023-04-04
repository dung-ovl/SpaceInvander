using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class WaveController : GameMonoBehaviour
{
    [SerializeField] WaveProfileSO waveProfile;
    public WaveProfileSO WaveProfile => waveProfile;
    [SerializeField] PlacePointManager placePoint;
    public PlacePointManager PlacePoint => placePoint;
    [SerializeField] SpawnPointManager spawnPoint;
    public SpawnPointManager SpawnPoint => spawnPoint;
    [SerializeField] MovePath movePath;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlacePoint();
        this.LoadSpawnPoint();
        this.LoadWaveSO();
    }

    private void LoadWaveSO()
    {
        if (this.waveProfile != null) return;
        string resPath = "Wave/" + transform.name;
        this.waveProfile = Resources.Load<WaveProfileSO>(resPath);
        Debug.Log(transform.name + ": LoadWaveProfile", gameObject);
    }

    private void LoadSpawnPoint()
    {
        if (this.spawnPoint != null) return;
        this.spawnPoint = transform.GetComponentInChildren<SpawnPointManager>();
        Debug.Log(transform.name + ": LoadSpawnPoint", gameObject);
    }

    private void LoadPlacePoint()
    {
        if (this.placePoint != null) return;
        this.placePoint = transform.GetComponentInChildren<PlacePointManager>();
        Debug.Log(transform.name + ": LoadPlacePoint", gameObject);
    }
}
