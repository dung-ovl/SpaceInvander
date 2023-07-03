using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TxtSelectedShipButton : GUISelectedShipReact<TMP_Text>
{
    protected override void OnShipSelected()
    {
        if (isShipSelected)
        {
            this.obj.text = "Selected";
        }
        else
        {
            this.obj.text = "Select";
        }
    }
}
