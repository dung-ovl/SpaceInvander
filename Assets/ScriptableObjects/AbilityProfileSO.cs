using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "ScriptableObject/AbilityProfile")]
public class AbilityProfileSO : ScriptableObject
{
    public new string name = "no-name";
    public float activeTime = 5f;

}
