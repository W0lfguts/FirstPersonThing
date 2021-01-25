using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionsController : MonoBehaviour
{
    public GameObject CollectionsMenuUI;
    public static bool CollectionsIsOpen = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (CollectionsIsOpen)
            {
                CloseCollections();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                OpenCollections();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    void CloseCollections()
    {
        CollectionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        CollectionsIsOpen = false;
    }

    void OpenCollections()
    {
        CollectionsMenuUI.SetActive(true);
        Time.timeScale = 0f;
        CollectionsIsOpen = true;
    }
}
