using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public string Name;
    public Sprite icon;
    public GameObject PickUp;
    Inventory inventory;

    // Start is called before the first frame update/ find object
    void Start()
    {
        inventory = GameObject.FindObjectOfType<Inventory>(); 
    }

    void OnTriggerEnter(Collider other)
    {
        print("hello");
        if (other.tag == "Player")
        {
            inventory.AddItem(this);
            gameObject.SetActive(false);
        }
    }
}
