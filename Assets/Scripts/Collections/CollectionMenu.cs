using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionMenu : MonoBehaviour
{
    public Image [] images;
    public Text [] titles;

    public int Options()
    {
        return images.Length;
    }

    public void SetOption(int index, Sprite image, string text)
    {
        images[index].sprite = image;
        images[index].enabled = true;
        titles[index].text = text;
        titles[index].enabled = true;
    }

    public void HideOption(int index)
    {
        images[index].enabled = false;
        titles[index].enabled = false;
    }
}
