using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class GameCtrl : GameMonoBehaviour
{
    private static GameCtrl instance;
    public static GameCtrl Instance { get => instance; }

    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera { get => mainCamera; }

    [SerializeField] protected Transform currentShip;
    public Transform CurrentShip { get => currentShip; }

    protected override void Awake()
    {
        base.Awake();
        if (GameCtrl.instance != null) Debug.LogError("Only 1 GameCtrl allow to exist");
        GameCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
        this.LoadCurrentShip();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = GameCtrl.FindObjectOfType<Camera>();
        Debug.Log(transform.name + ": LoadCamera", gameObject);
    }

    protected virtual void LoadCurrentShip()
    {
        if (this.currentShip != null) return;
        this.currentShip = GameObject.Find("Ship").transform;
        Debug.Log(transform.name + ": LoadCurrentShip", gameObject);
    }
}
