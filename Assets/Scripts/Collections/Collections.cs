using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    public Sprite image;
    public bool collected;
}

[System.Serializable]
public class Collection
{
    public string title;
    public Sprite image;
    public List<Item> contents;

    public int Found()
    {
        return contents.FindAll((item) => item.collected).Count;
    }

    public int Size()
    {
        return contents.Count;
    }
}

public class Collections : MonoBehaviour
{
    public List<Collection> collections;
    public CollectionMenu menu;
    public Content content;
    int pageOffset = 0;

    void Start()
    {
        UpdatePages();
    }

    public void OpenCollection(int collection)
    {
        Collection data = collections[collection];
        for (int i = 0; i < 6; i++)
        {
            if (i < data.contents.Count && data.contents[i].collected)
            {
                content.SetImage(i, data.contents[i].image);
            }
            else
            {
                content.HideImage(i);
            }
        }

        content.gameObject.SetActive(true);
    }

    public void CloseCollection()
    {
        content.gameObject.SetActive(false);
    }

    public void Collect(string title, int index)
    {
        Collection collection = 
            collections.Find((entry) => entry.title == title);

        if (collection != null && index < collection.contents.Count)
        {
            collection.contents[index].collected = true;
            Debug.LogFormat("{0} {1} collected", title, index);
        }
        else
        {
            Debug.LogWarningFormat(
                "Item {0} {1} does not exist",
                title,
                index);
        }
    }

    public void UpdatePages()
    {
        for (int i = 0; i < menu.Options(); ++i)
        {
            if (pageOffset + i < collections.Count)
            {
                Collection collection = collections[pageOffset + i];
                menu.SetOption(
                    i,
                    collection.image,
                    string.Format(
                        "{0} {1}/{2}",
                        collection.title,
                        collection.Found(),
                        collection.Size()));
            }
            else
            {
                menu.HideOption(i);
            }
        }
    }

    public void PageLeft()
    {
        if (pageOffset > 0)
        {
            pageOffset -= menu.Options();
            UpdatePages();
        }
    }

    public void PageRight()
    {
        if (pageOffset < collections.Count - menu.Options())
        {
            pageOffset += menu.Options();
            UpdatePages();
        }
    }
}
