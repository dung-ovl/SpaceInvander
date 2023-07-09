using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSkill1 : SliderSkill
{
    protected static SliderSkill1 instance;
    public static SliderSkill1 Intance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (SliderSkill1.instance != null) Debug.LogError("Only 1 SliderSkill1 allow to exist");
        SliderSkill1.instance = this;
    }
    public override void SetSliderValue()
    {
        this.slider.maxValue = currentShip.GetComponent<ShipController>().ShipProfile.countDownSkill1;
        this.slider.value = 0;
    }

    public override void StartCountDown()
    {
        base.StartCountDown();
        this.timeRemain = GameCtrl.Instance.CurrentShip.GetComponent<ShipController>().ShipProfile.countDownSkill1;
    }
}
