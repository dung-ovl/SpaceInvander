using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;



public class WaveManager : GameMonoBehaviour
{
    [SerializeField] private float startDelay = 2f;
    public float StartDelay => startDelay;
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
    public bool isUnitInFormationPoint = false;


    private List<float> _speeds = new List<float>();
    private float amplitudeOscillates = 0.03f;

    private static WaveManager instance;
    public static WaveManager Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        WaveManager.instance = this;
    }
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
        this.FormationOscillatesX();
        this.FormationUnitOscillatesY();
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
            if (!this._spawnedUnits.Contains(newEnemy))
            {
                this._speeds.Add(Random.Range(0.05f, 0.08f));
                this._spawnedUnits.Add(newEnemy); 
            }
            newEnemy.gameObject.SetActive(true);

            yield return new WaitForSeconds(0.02f);
        }
        this.isWaveSpawnComplete = true;
    }

    protected void SetUpFormation()
    {
        if (this.isUnitInFormationPoint) return;
        this.SetFormationPoints(this._formation.GetPositions().ToList());
        for (var i = 0; i < _spawnedUnits.Count; i++)
        {
            this._spawnedUnits[i].transform.position = Vector3.MoveTowards(this._spawnedUnits[i].transform.position, this._formationPoints[i], this._unitSpeed * Time.deltaTime);
        }
        if (!isWaveSpawnComplete) return;
        for (var i = 0; i < _spawnedUnits.Count; i++)
        {
            if (this._spawnedUnits[i].transform.position != this._formationPoints[i]) return;
        }
        this.isUnitInFormationPoint = true;
    }

    private void SetFormationPoints(List<Vector3> points)
    {
        this._formationPoints = points.ToList();

    }

    private void FormationOscillatesX()
    {
        if (!this.isUnitInFormationPoint) return;
        bool isOscillatesX = true;
        if (isOscillatesX)
        {
            float maxX = this._formationPoints.Select(point => point.x).Max();
            float minX = this._formationPoints.Select(point => point.x).Min();
            float amplitudeMax = GameCtrl.Instance.M_maxX - maxX+ -0.05f;
            float amplitudeMin = GameCtrl.Instance.M_minX - minX + 0.05f;
            
            for (var i = 0; i < _spawnedUnits.Count; i++)
            {
                Vector3 pointA = new Vector3(this._formationPoints[i].x + amplitudeMax, this._spawnedUnits[i].transform.position.y, 0);
                Vector3 pointB = new Vector3(this._formationPoints[i].x + amplitudeMin, this._spawnedUnits[i].transform.position.y, 0);
                _spawnedUnits[i].transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time * 0.2f, 1.0f));
                // Move the object towards the target position
/*                float newX = this._formationPoints[i].x + Mathf.PingPong(oscillatesXTimer * 0.007f, (amplitudeMax - amplitudeMin)) + amplitudeMin;
                this.oscillatesXTimer += Time.deltaTime;
                // move the object to its new position
                _spawnedUnits[i].transform.position = new Vector3(newX, _spawnedUnits[i].transform.position.y, 0);*/

            }
        }
    }
    private float oscillatesYTimer = 0.0f;
    private float oscillatesXTimer = 0.0f;
    protected virtual void FormationUnitOscillatesY()
    {
        if (!this.isUnitInFormationPoint) return;
        bool isOscillatesY = true;
        if (isOscillatesY)
        {
            for (var i = 0; i < _spawnedUnits.Count; i++)
            {
                // Move the object towards the target position
                float newY = _formationPoints[i].y + Mathf.PingPong(oscillatesYTimer * _speeds[i], amplitudeOscillates * 2) - amplitudeOscillates;
                
                // move the object to its new position
                _spawnedUnits[i].transform.position = new Vector3(_spawnedUnits[i].transform.position.x, newY, 0);
            }
            this.oscillatesYTimer += Time.deltaTime;
        }
    }
    public void CheckOnAllUnitDead()
    {
        if (!this.isWaveSpawnComplete) return;
        foreach (var spawnedUnit in this._spawnedUnits)
        {
            if (!EnemySpawner.Instance.CheckObjectInPool(spawnedUnit)) return;
        }
        this._spawnedUnits.Clear();
        this.isAllSpawnedUnitsDead = true;
    }
}
