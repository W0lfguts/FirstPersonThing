using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Content : MonoBehaviour
{
    public Image [] images;

    public void SetImage(int index, Sprite image)
    {
        images[index].sprite = image;
        images[index].enabled = true;
    }

    public void HideImage(int index)
    {
        images[index].sprite = null;
        images[index].enabled = false;
    }
}
