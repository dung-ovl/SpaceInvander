using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FormationRenderer))]
public abstract class FormationBase : GameMonoBehaviour {
    [Header("Base Formation")]
    //[SerializeField] [Range(0, 1)] protected float _noise = 0;
    [SerializeField] protected int _posCount = 20;
    [SerializeField] protected float _spread = 1;   

    [SerializeField] string hole;
    public int posCountExact => GetPositions().Count;
    public abstract List<Vector3> GetPositions();


    protected List<int> GetHolePositions()
    {
        List<int> holePositions = new List<int>();
        if (!string.IsNullOrEmpty(hole))
        {
            string[] splitValues = hole.Trim().Split(' ');
            foreach (string value in splitValues)
            {
                int parsedValue;
                if (int.TryParse(value, out parsedValue))
                {
                    holePositions.Add(parsedValue);
                }
            }
        }
        return holePositions;
    }

    /*public Vector3 GetNoise(Vector3 pos) {
        var noise = Mathf.PerlinNoise(pos.x * _noise, pos.y * _noise);

        return new Vector3(noise, noise, 0);
    }*/
}