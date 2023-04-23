using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<WaveManager> waves;
    [SerializeField] private int currentWaveIndex = 0;


    private State currentState = State.NotStarted;
    private bool levelCompleted = false;


    private void Start()
    {
         this.StartLevel();
    }

    void Update()
    {
        if (currentState != State.Started) return;
        /*if (waves[currentWaveIndex].CurrentState != State.Completed) return;*/
        if (currentWaveIndex < waves.Count)
        {
            // Check if the current wave has been completed
            if (waves[currentWaveIndex].CurrentState == State.Completed)
            {
                waves[currentWaveIndex].gameObject.SetActive(false);
                currentWaveIndex++;
                if (currentWaveIndex < waves.Count)
                {
                    waves[currentWaveIndex].gameObject.SetActive(true);
                    waves[currentWaveIndex].StartWave();
                }
            }
        }
        // End the level if all waves have been completed
        else if (currentState == State.Started && currentWaveIndex == waves.Count)
        {
            EndLevel();
        }
    }


    private void StartLevel()
    {
        if (currentState == State.NotStarted)
        {
            if (waves.Count <= 0) return;
            waves[currentWaveIndex].gameObject.SetActive(true);
            waves[currentWaveIndex].StartWave();
            currentState = State.Started;
        }
    }

    private void EndLevel()
    {
        currentState = State.Completed;
        Debug.Log("End level");
    }

    /*    IEnumerator SpawnWave()
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
        }*/
}
