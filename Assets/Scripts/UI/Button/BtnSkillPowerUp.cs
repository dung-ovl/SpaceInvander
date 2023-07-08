using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSkillPowerUp : BaseButton
{
    protected override void OnClick()
    {
        if (SliderSkill1.Intance.isCountDown) return;
        Debug.Log("Skill PowerUp Click");
        SliderSkill1.Intance.StartCountDown();
        PowerUpAbility powerUpAbility = GameCtrl.Instance.CurrentShip.GetComponentInChildren<PowerUpAbility>();
        if (powerUpAbility != null)
        {
            powerUpAbility.Active();
            Debug.Log("active power");
        }
        else
        {
            Debug.LogError("Can not get PowerUpAbility");
        }
    }
}
