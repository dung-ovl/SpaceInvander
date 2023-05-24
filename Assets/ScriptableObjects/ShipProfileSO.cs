using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ship", menuName = "ScriptableObject/Ship")]

public class ShipProfileSO : ScriptableObject
{
    public string shipName = "Ship";
    public float maxHeath = 10f;
    public float damage = 1f;
    public float attackSpeed = 0.2f;
    public float shieldTimeUp = 0f;
    public float powerTimeUp = 0f;
    public List<ShipPointInfo> mainBulletList;
    public List<ShipPointInfo> subBulletList;
}
