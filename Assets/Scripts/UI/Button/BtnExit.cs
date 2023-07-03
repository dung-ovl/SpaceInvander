using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnExit : BaseButton
{
    protected override void OnClick()
    {
        AsyncLevelLoader.Instance.LoadLevel("MenuScene");
    }
}
