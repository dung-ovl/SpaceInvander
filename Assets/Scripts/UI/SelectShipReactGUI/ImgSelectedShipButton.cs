using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImgSelectedShipButton : GUISelectedShipReact<Image>
{
    protected override void OnShipSelected()
    {
        if (isShipSelected)
        {
            this.obj.enabled = true;
        }
        else
        {
            this.obj.enabled = false;
        }
    }
}
