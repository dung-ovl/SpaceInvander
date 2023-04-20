using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCircle : GameMonoBehaviour
{
    [SerializeField] protected float timeAwait;
    public float TimeAwait => timeAwait;

    [SerializeField] protected float timeRemain;
    public float TimeRemain => timeRemain;

    [SerializeField] protected bool isCircling;
    public bool IsCircling => isCircling;

    protected float RotateSpeed = 2f;
    protected float Radius = 0.5f;

    protected Vector2 _centre;
    protected float _angle;

    LineRenderer lineRenderer;
    GameObject laserObj;


    protected override void OnEnable()
    {
        base.OnEnable();
        this.timeAwait = 0.5f;
        this.timeRemain = this.timeAwait;
        _angle = 0;


        this.lineRenderer = new LineRenderer();
        this.laserObj = new GameObject();
        this.laserObj.name = "OK";
        this.lineRenderer = this.laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        this.lineRenderer.startWidth = 0.02f;
        this.lineRenderer.endWidth = 0.02f;
        lineRenderer.material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));
        this.lineRenderer.startColor = Color.green;
        this.lineRenderer.endColor = Color.green;
        this.lineRenderer.sortingLayerName = "Space";
    }

    protected void Update()
    {
        if (!this.isCircling) return;
        this.timeRemain -= Time.deltaTime;
        if (this.timeRemain > 0) return;
        _centre = GameCtrl.Instance.CurrentShip.position;
        _angle += RotateSpeed * Time.deltaTime;
        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * (Radius);
        transform.parent.position = _centre + offset;
        lineRenderer.SetPosition(0, _centre);
        lineRenderer.SetPosition(1, transform.parent.position);
    }
}
