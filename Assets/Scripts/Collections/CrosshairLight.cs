using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairLight : MonoBehaviour
{
    public float rayLength;
    public Image crosshair;
    public Transform cam;


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, rayLength))
        {
            if (hit.collider.tag == "Item" || hit.collider.tag == "InteractiveObject")
            {
                crosshair.color = Color.green;
            }

            else
            {
                crosshair.color = Color.white;
            }
        }
    }
}
