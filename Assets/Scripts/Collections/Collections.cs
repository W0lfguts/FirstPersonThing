using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Collection
{
    public string title;
    public Sprite image;
    public List<Sprite> contents;
}

public class Collections : MonoBehaviour
{
    public List<Collection> collections;
    public Content content;

    public void OpenCollection(int collection)
    {
        //counting starts at 0
        Collection data = collections[collection];
        for (int i = 0; i < 6; i++)
        {
            if (i < data.contents.Count && data.contents[i] != null)
            {
                content.images[i].sprite = data.contents[i];
                content.images[i].enabled = true;
            }
            else
            {
                content.images[i].sprite = null;
                content.images[i].enabled = false;
            }
        }

        content.gameObject.SetActive(true);
    }

    public void CloseCollection()
    {
        content.gameObject.SetActive(false);
    }

}
