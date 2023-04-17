using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;



public class WaveManager : GameMonoBehaviour
{
    [SerializeField] private float startDelay = 2f;
    [SerializeField] private bool isFollowPathDone = false;
    [SerializeField] private FormationBase _formation;
    [SerializeField] private List<MovePath> _paths;
    [SerializeField] private float _unitSpeed = 2;
    private List<Vector3> _formationPoints;
    [SerializeField] private List<Transform> _spawnedUnits;
    [SerializeField] private State currentState;

    public State CurrentState => currentState;
    public bool isWaveSpawnComplete = false;
    public bool isAllSpawnedUnitsDead = false;


    protected override void OnEnable()
    {
        base.OnEnable();

    }
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        this.SetUpFormation();
        this.CheckOnWaveCompleted();
        this.CheckOnAllUnitDead();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFormation();
        this.LoadPaths();
    }
    private void LoadFormation()
    {
        if (_formation != null) return;
        _formation = transform.GetComponentInChildren<FormationBase>();
        Debug.Log(transform.name + ": LoadFormation", gameObject);
    }

    private void LoadPaths()
    {
        if (_paths.Count > 0) return;
        Transform prefabsObj = transform.Find("MovePaths");
        foreach (Transform prefab in prefabsObj)
        {
            this._paths.Add(prefab.GetComponent<MovePath>());
        }
        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }


    protected virtual void CheckOnWaveCompleted()
    {
        if (this.currentState == State.NotStarted) return;
        if (!this.isWaveSpawnComplete) return;
        if (!this.isAllSpawnedUnitsDead) return;
        this.currentState = State.Completed;
    }

    public virtual void StartWave()
    {
        if (this.currentState == State.NotStarted)
        {
            this.currentState = State.Started;
            StartCoroutine(StartSpawn());
        }
    }

    protected virtual IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds(2f);
        SpawnEnemy();
    }
    protected virtual void SpawnEnemy()
    {
        int posCount = this._formation.GetPositions().Count; // example integer
        int pathCount = this._paths.Count;
        // calculate the number of times n can be divided equally among the elements of lst
        int amountDivided = posCount / pathCount;

        // calculate the remainder of the division
        int amountRemainder = posCount % pathCount;

        // create the dictionary
        Dictionary<MovePath, int> amountPerPath = new Dictionary<MovePath, int>();
        for (int i = 0; i < pathCount; i++)
        {
            int value = amountDivided;
            if (amountRemainder > 0) // distribute remainder
            {
                value += 1;
                amountRemainder -= 1;
            }
            amountPerPath[_paths[i]] = value;
        }
        foreach (var item in amountPerPath)
        {
            StartCoroutine(SpawnEnemyEachPath(item.Key, item.Value));
        }
        /*foreach (int pos in enemyPerPath)
        {
            foreach (MovePath item in _paths)
            {
                Vector3 spawnPos = item.Points[0].transform.position;
                string enemyName = EnemySpawner.Instance.E1Scout;
                Quaternion enemyRot = Quaternion.Euler(0, 0, 0);
                Transform newEnemy = EnemySpawner.Instance.Spawn(enemyName, spawnPos, enemyRot);
                if (newEnemy == null) yield return null;
                newEnemy.gameObject.SetActive(true);
                this._spawnedUnits.Add(newEnemy);
                Debug.Log("Spawn");
            }
            yield return new WaitForSeconds(0.02f);
        }*/
    }

    private IEnumerator SpawnEnemyEachPath(MovePath movePath, int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            Vector3 spawnPos = movePath.Points[0].transform.position;
            string enemyName = EnemySpawner.Instance.E1Scout;
            Quaternion enemyRot = Quaternion.Euler(0, 0, 0);
            Transform newEnemy = EnemySpawner.Instance.Spawn(enemyName, spawnPos, enemyRot);
            if (newEnemy == null) yield return null;
            this._spawnedUnits.Add(newEnemy);
            newEnemy.gameObject.SetActive(true);

            yield return new WaitForSeconds(0.02f);
        }
        this.isWaveSpawnComplete = true;
    }

    protected void SetUpFormation()
    {
        this.SetFormationPoints(this._formation.GetPositions().ToList());
        for (var i = 0; i < _spawnedUnits.Count; i++)
        {
            this._spawnedUnits[i].transform.position = Vector3.MoveTowards(this._spawnedUnits[i].transform.position, this._formationPoints[i], this._unitSpeed * Time.deltaTime);
        }
    }

    private void SetFormationPoints(List<Vector3> points)
    {
        this._formationPoints = points.ToList();
    }

    public void CheckOnAllUnitDead()
    {
        if (!this.isWaveSpawnComplete) return;
        foreach (var spawnedUnit in this._spawnedUnits)
        {
            if (!EnemySpawner.Instance.CheckObjectInPool(spawnedUnit)) return;
        }
        this.isAllSpawnedUnitsDead = true;
    }
}
