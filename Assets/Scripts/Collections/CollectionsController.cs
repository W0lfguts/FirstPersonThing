using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionsController : MonoBehaviour
{
    public GameObject CollectionsMenuUI;
    public static bool CollectionsIsOpen = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (CollectionsIsOpen)
            {
                CloseCollections();
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                OpenCollections();
                Cursor.lockState = CursorLockMode.None;
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
