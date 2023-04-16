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
    public abstract List<Vector3> GetPositions();

    /*public Vector3 GetNoise(Vector3 pos) {
        var noise = Mathf.PerlinNoise(pos.x * _noise, pos.y * _noise);

        return new Vector3(noise, noise, 0);
    }*/
}