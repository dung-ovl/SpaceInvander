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



public class FormationWaveManager : WaveManager
{
    [SerializeField] private FormationBase _formation;
    [SerializeField] private float _unitSpeed = 2;
    private List<Vector3> _formationPoints;

    private List<float> _unitOscillatesSpeeds = new List<float>();
    private float amplitudeOscillates = 0.03f;

    public bool isAllUnitInFormation = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFormation();
    }

    protected override void Start()
    {
        base.Start();
        this.amountOfUnit = this._formation.GetPositions().Count;
    }

    protected override void Update()
    {
        base.Update();
        this.SetUpFormation();
        this.FormationOscillatesX();
        this.FormationUnitOscillatesY();
    }

    private void LoadFormation()
    {
        if (_formation != null) return;
        _formation = transform.GetComponentInChildren<FormationBase>();
        Debug.Log(transform.name + ": LoadFormation", gameObject);
    }


    protected override IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds(2f);
        this.SpawnEnemy();
    }

    protected virtual void SpawnEnemy()
    {
        int posCount = this.amountOfUnit; // example integer
        int pathCount = this._paths.Count;
        // create the dictionary
        Dictionary<MovePath, int> movePaths = this.GetPathAndAmount(posCount, pathCount);
        foreach (var item in movePaths)
        {
            StartCoroutine(SpawnEnemyEachPath(item.Key, item.Value));
        }
    }

    protected virtual IEnumerator SpawnEnemyEachPath(MovePath movePath, int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            if (this.SpawnEnemyInPath(movePath))
            {
                this._unitOscillatesSpeeds.Add(Random.Range(0.05f, 0.08f));
                yield return new WaitForSeconds(0.02f);
            }
            else
            {
                i--;
            }
        }
        this.isWaveSpawnComplete = true;
    }

    protected void SetUpFormation()
    {
        if (this.isAllUnitInFormation) return;
        this.SetFormationPoints(this._formation.GetPositions().ToList());
        for (var i = 0; i < _spawnedUnits.Count; i++)
        {
            this._spawnedUnits[i].transform.position = Vector3.MoveTowards(this._spawnedUnits[i].transform.position, this._formationPoints[i], this._unitSpeed * Time.deltaTime);
        }
        this.CheckOnAllUnitInFormation();
    }

    private void SetFormationPoints(List<Vector3> points)
    {
        this._formationPoints = points.ToList();

    }

    private void FormationOscillatesX()
    {
        if (!this.isAllUnitInFormation) return;
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
        if (!this.isAllUnitInFormation) return;
        bool isOscillatesY = true;
        if (isOscillatesY)
        {
            for (var i = 0; i < _spawnedUnits.Count; i++)
            {
                // Move the object towards the target position
                float newY = _formationPoints[i].y + Mathf.PingPong(oscillatesYTimer * _unitOscillatesSpeeds[i], amplitudeOscillates * 2) - amplitudeOscillates;
                
                // move the object to its new position
                _spawnedUnits[i].transform.position = new Vector3(_spawnedUnits[i].transform.position.x, newY, 0);
            }
            this.oscillatesYTimer += Time.deltaTime;
        }
    }

    public void CheckOnAllUnitInFormation()
    {
        if (!this.isWaveSpawnComplete) return;
        foreach (var spawnedUnit in this._spawnedUnits)
        {
            if (spawnedUnit.transform.position != this._formationPoints[this._spawnedUnits.IndexOf(spawnedUnit)]) return;
        }
        this.isAllUnitInFormation = true;
    }
}
