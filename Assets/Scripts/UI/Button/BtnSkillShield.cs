using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSkillShield : BaseButton
{
    protected override void OnClick()
    {
        if (SliderSkill2.Intance.isCountDown) return;
        Debug.Log("Skill Shield Click");
        SliderSkill2.Intance.StartCountDown();
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
