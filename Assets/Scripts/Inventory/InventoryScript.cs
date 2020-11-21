using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    [Header("Inventory Controls")]
    public KeyCode invToggle;
    bool showInv = false;
    public bool canCheckInv = true;

    [Header("Items")]
    public GameObject[] board1Items;
    public GameObject[] board2Items;



    [Space(10)]
    public GameObject board1;
    public GameObject board2;

    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
//      ShowBoard1();
    }


    void Update()
    {
//      transform.GetChild(0).gameObject.SetActive(showInv);

        if(Input.GetKeyDown(invToggle) && canCheckInv)
        {
            showInv = !showInv;

            if(showInv)
            {
                Cursor.lockState = CursorLockMode.None;
            }

            if(!showInv)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    private void FixedUpdate()
    {
        player.GetComponent<ItemPickupScript>().enabled = !showInv;
        player.GetComponent<PlayerMove>().enabled = !showInv;
        player.transform.GetChild(0).GetComponent<PlayerLook>().enabled = !showInv;
    }

    public void ShowBoard1()
    {
        board1.SetActive(true);
        board2.SetActive(false);
    }

    public void ShowBoard2()
    {
        board1.SetActive(false);
        board2.SetActive(true);
    }
}
