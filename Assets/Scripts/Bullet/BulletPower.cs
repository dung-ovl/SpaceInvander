using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPower : BulletAbstract
{
    public int timesSeparation;
    public int quantityOfEachTimes;
    public float timeWait;
    public float angleSeparation;
    float timeCount;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        timeWait = 0.5f;
        quantityOfEachTimes = 2;
        timesSeparation = 2;
        angleSeparation = 20;
        timeCount = 0;
    }

    protected virtual void FixedUpdate()
    {
        if (timesSeparation >= 1)
        {
            this.BulletController.isSendDamage = false;
            Separate();
        }
    }

    protected virtual void Separate()
    {
        timeCount += Time.fixedDeltaTime;
        if (timeCount < timeWait) return;
        this.CreateImpactFX();
        float tempAngle = Mathf.Abs(angleSeparation) * 2 / (quantityOfEachTimes - 1);
        float angle = angleSeparation;
        for (int i = 0; i < quantityOfEachTimes; i++)
        {
            Vector3 rot = transform.parent.rotation.eulerAngles;
            rot = new Vector3(rot.x, rot.y, rot.z + angle);
            Debug.Log(rot);
            Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.Instance.BulletOne, transform.position, Quaternion.Euler(rot));
            if (newBullet == null) return;
            newBullet.gameObject.SetActive(true);
            BulletController bulletController = newBullet.GetComponent<BulletController>();
            bulletController.BulletPower.timesSeparation = timesSeparation - 1;
            bulletController.SetShooter(GameCtrl.Instance.CurrentShip);
            bulletController.BulletBouncy.startPos = transform.parent.position;
            Debug.Log("Separate " + i);
            angle -= tempAngle;
        }
        this.bulletController.BulletDespawn.DespawnObject();
    }

    protected virtual void CreateImpactFX()
    {
        string fxImpactName = GetImpactFXName();
        Quaternion hitRot = transform.rotation;
        Transform newFxImpact = FXSpawner.Instance.Spawn(fxImpactName, transform.position, hitRot);
        if (newFxImpact == null) return;
        newFxImpact.gameObject.SetActive(true);
    }

    protected virtual string GetImpactFXName()
    {
        return FXSpawner.Instance.Impact1;
    }
}
