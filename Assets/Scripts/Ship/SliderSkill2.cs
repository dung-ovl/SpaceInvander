using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderSkill2 : SliderSkill
{
    protected static SliderSkill2 instance;
    public static SliderSkill2 Intance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (SliderSkill2.instance != null) Debug.LogError("Only 1 SliderSkill2 allow to exist");
        SliderSkill2.instance = this;
    }
    public override void SetSliderValue()
    {
        this.slider.maxValue = currentShip.GetComponent<ShipController>().ShipProfile.countDownSkill2;
        this.slider.value = 0;
    }

    public override void StartCountDown()
    {
        base.StartCountDown();
        Transform ship = GameCtrl.Instance.CurrentShip.transform;
        if (ship == null) return;
        this.timeRemain = ship.GetComponent<ShipController>().ShipProfile.countDownSkill2;
    }
}
