using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GameMonoBehaviour
{
    [SerializeField] bool isStartUpDone = false;
    [SerializeField] Transform spawnPos;
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    [SerializeField] Transform currentShipPlayer;

    private static GameManager instance;

    public static GameManager Instance { get => instance; }

    private float onLoseDelay = 1f;
    private float onLoseTimer = 0f;
    private float onWinDelay = 2f;
    private float onWinTimer = 2f;

    private float scrollSpeed = 0.5f;
    protected override void Awake()
    {
        base.Awake();
        GameManager.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoint();
    }

    private void LoadPoint()
    {
        this.spawnPos = GameObject.Find("SpawnPoint").transform;
        if (this.spawnPos == null )
        {
            this.spawnPos.position = new Vector2(0, -2);
        }
        this.startPos = GameObject.Find("StartPoint").transform;
        if (this.startPos == null)
        {
            this.startPos.position = new Vector2(0, 0.5f);
        }
        this.endPos = GameObject.Find("EndPoint").transform;
        if (this.endPos == null)
        {
            this.endPos.position = new Vector2(0, 2f);
        }
    }

    protected override void Start()
    {
        base.Start();
        StartCoroutine(this.LoadStartUp());
    }

    private void Update()
    {
        CheckOnWinLevel();
        CheckOnLoseLevel();
    }

    private IEnumerator LoadStartUp()
    {
        while (true)
        {
            if (GameCtrl.Instance.CurrentShip != null) break;
            yield return new WaitForEndOfFrame();
        }
        currentShipPlayer = GameCtrl.Instance.CurrentShip;
        currentShipPlayer.position = spawnPos.position;
        while (currentShipPlayer.position != startPos.position)
        {
            currentShipPlayer.position = Vector2.MoveTowards(currentShipPlayer.position, startPos.position, 0.5f * Time.deltaTime);
            BackgroundManager.Instance.Backgrounds.SetScrollSpeed(scrollSpeed);
            yield return new WaitForEndOfFrame();
        }
        isStartUpDone = true;
        StartUp();
    }

    public void SetShipPlayerMovementAndShooting(GameObject ship, bool isSet)
    {
        Transform currentShip = ship.transform;
        ShipMovement shipMovement = currentShip.GetComponentInChildren<ShipMovement>();
        ShipShooting shipShooting = currentShip.GetComponentInChildren<ShipShooting>();
        ShipSubShooting shipSubShooting = currentShip.GetComponentInChildren<ShipSubShooting>();
        shipMovement.enabled = isSet;
        shipShooting.enabled = isSet;
        shipSubShooting.enabled = isSet;
    }

    public void StartUp()
    {
        if (isStartUpDone)
        {
            BackgroundManager.Instance.Backgrounds.ResetScrollSpeed();
            SetShipPlayerMovementAndShooting(currentShipPlayer.gameObject, true);
            LevelManager.Instance.StartLevel();
        }
    }

    public void CheckOnLoseLevel()
    {
        if (GameCtrl.Instance.CurrentShip == null)
        {
            if (onLoseTimer < onLoseDelay)
            {
                onLoseTimer += Time.deltaTime;
                return;
            }
            LevelOver();
        }
       
    }

    public void CheckOnWinLevel()
    {
        if (LevelManager.Instance.CurrentState == State.Completed)
        {
            if (onWinTimer < onLoseDelay)
            {
                onWinTimer += Time.deltaTime;
                return;
            }
            SetShipPlayerMovementAndShooting(currentShipPlayer.gameObject, false);
            currentShipPlayer.Translate(Vector2.up * 2f * Time.deltaTime);
            BackgroundManager.Instance.Backgrounds.SetScrollSpeed(scrollSpeed);
            if (currentShipPlayer.position.y < endPos.position.y) return;
            LevelWin();
        }
    }

    public void LevelWin()
    {
        MenuManager.Instance.SwitchCanvas(Menu.GAME_WIN);
    }

    public void LevelOver()
    {
        MenuManager.Instance.SwitchCanvas(Menu.GAME_OVER);
    }
}
