using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    List<PickupItem> Items = new List<PickupItem>();
    public GameObject InventoryPanel;
    public Image InventoryImage;

    // Start is called before the first frame update
    void Start()
    {
        InventoryPanel.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryPanel.activeSelf == true)
            {
                DestroyInventory();
                InventoryPanel.SetActive(false);
            }
            else
            {
                DisplayInventory();
                InventoryPanel.SetActive(true);
            }
           
        }
    }

    void DestroyInventory()
    {
        foreach (Transform item in InventoryPanel.transform)
        {
            Destroy(item.gameObject);
        }
    }
    void DisplayInventory()
    {
        for (int i = 0; i < Items.Count; i++)
        {
            Image Icon = Instantiate(InventoryImage);
            Icon.transform.parent = InventoryPanel.transform; 
            Icon.sprite = Items[i].icon;
        }
        
    }

    public void AddItem(PickupItem p)
    {
        Items.Add(p);
    }
}
