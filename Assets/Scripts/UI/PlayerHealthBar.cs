using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : GameMonoBehaviour
{
    public Slider slider;
    private static PlayerHealthBar instance;
    public static PlayerHealthBar Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake(); 
        instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
    }

    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = transform.GetComponent<Slider>();
        Debug.Log(transform.name + ": LoadSlider", gameObject);
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
