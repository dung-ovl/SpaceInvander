using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Wave> Waves;
    public int CurrentWaveIndex = 0;

    private bool waveCompleted = true;

    void Update()
    {
        if (waveCompleted)
        {
            StartCoroutine(SpawnWave());
            waveCompleted = false;
        }
    }

    IEnumerator SpawnWave()
    {
        Wave currentWave = Waves[CurrentWaveIndex];

        yield return new WaitForSeconds(1.0f);
 

        while (GameObject.FindWithTag("Enemy") != null)
        {
            yield return null;
        }

        waveCompleted = true;
        CurrentWaveIndex++;
        if (CurrentWaveIndex >= Waves.Count)
        {
            CurrentWaveIndex = 0;
        }
    }
}
