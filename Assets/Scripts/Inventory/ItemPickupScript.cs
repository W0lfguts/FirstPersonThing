using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupScript : MonoBehaviour
{
    [Header("Variables")]
    public bool itemPickedup = false;
    bool canInteract = true;
    public float rayLength;
    public Transform cam;
    public Transform inspectTransform;
    public Vector2 inspectDistance = new Vector2(0.5f, 2.0f);
    public float smoothLerp = 2.0f;
    public float smoothZoom = 0.5f;
    float zoomLerp = 0;

    [Space(10)]
    public KeyCode interactKey;
    public float rotateSensitivity = 150.0f;

    [Header("Item Info")]
    public GameObject currItem;
    public Vector3 itemOriginPos;
    public Quaternion itemOriginRot;

    GameObject inv;

    //HIGHLIGHTOBJ

    public static string selectedObject;
    public string internalObject;
    public RaycastHit theObject;

    private void Start()
    {
        inv = GameObject.Find("NewInventory");
    }

    void Update()
    {

        //  Check if player can reach the item
        RaycastHit hit;
        if(Physics.Raycast(cam.position, cam.forward, out hit, rayLength))
        {
            if (hit.collider.tag == "Item" || hit.collider.tag == "ItemInv")
            {
                Debug.DrawLine(cam.position, hit.point, Color.green);
                //  Pick up item
                if(Input.GetKeyDown(interactKey) && !itemPickedup && canInteract)
                {
                    CancelInvoke();
                    canInteract = false;
                    Invoke("ResetInteract", 0.2f);
                    itemPickedup = true;
                    currItem = hit.collider.gameObject;
                    itemOriginPos = currItem.transform.position;
                    itemOriginRot = currItem.transform.rotation;
                    //LockPlayer();
                }
            }

            else
                Debug.DrawRay(cam.position, cam.forward * rayLength, Color.red);
        }
        else
            Debug.DrawRay(cam.position, cam.forward * rayLength, Color.red);

        //HIGHLIGHTOBJ
       // if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theObject))
       // {
          //  selectedObject = theObject.transform.gameObject.name;
          //  internalObject = theObject.transform.gameObject.name;
       // }





        //  Put item back down
       
        if(Input.GetKeyDown(interactKey) && itemPickedup && canInteract)
        {
            if (currItem.tag == "ItemInv")
            {
                // add item to inventory, do script later

                ResetInteract();
                itemPickedup = false;
                Destroy(currItem.gameObject);
                currItem = null;
                ResetItemInfo();

                print("Added item to inventory");
            }

            else
            {
                canInteract = false;
                Invoke("ResetInteract", 0.2f);
                itemPickedup = false;

                //reset item info
                Invoke("ResetItemInfo", 1.0f);
            }

            //UnlockPlayer();
        }

        if(currItem != null && !itemPickedup)
        {
            //print("moving item back");
            currItem.transform.position = Vector3.Lerp(currItem.transform.position, itemOriginPos, smoothLerp * Time.deltaTime);
            currItem.transform.rotation = Quaternion.Lerp(currItem.transform.rotation, itemOriginRot, smoothLerp * Time.deltaTime);
        }

        //  Move item to inspect position
        if(itemPickedup)
        {
            currItem.transform.position = Vector3.Lerp(currItem.transform.position, inspectTransform.position, smoothLerp * Time.deltaTime);

            // Rotate object while in inspect
            if(Input.GetMouseButton(0))
            {
                float x = Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSensitivity;
                float y = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSensitivity;
                currItem.transform.eulerAngles += new Vector3(x, -y, 0);
            }
        }



        //  Zoom things

        inspectTransform.localPosition = Vector3.Lerp(
            new Vector3(inspectTransform.localPosition.x, inspectTransform.localPosition.y, inspectDistance.y), 
            new Vector3(inspectTransform.localPosition.x, inspectTransform.localPosition.y, inspectDistance.x), 
            zoomLerp);
        
        //smooth zoom

        zoomLerp = Mathf.Clamp(zoomLerp, 0, 1);
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            zoomLerp += smoothZoom;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            zoomLerp -= smoothZoom;
        }

    }

    void ResetItemInfo()
    {
        currItem = null;
        itemOriginPos = Vector3.zero;
        itemOriginRot = Quaternion.identity;
    }

    void ResetInteract()
    {
        canInteract = true;
    }

    private void FixedUpdate()
    {
        inv.GetComponent<InventoryScript>().enabled = !itemPickedup;
        GetComponent<PlayerMove>().enabled = !itemPickedup;
        cam.GetComponent<PlayerLook>().enabled = !itemPickedup;
    }

    void LockPlayer()
    {
        GetComponent<PlayerMove>().enabled = false;
        cam.GetComponent<PlayerLook>().enabled = false;
    }

    void UnlockPlayer()
    {
        GetComponent<PlayerMove>().enabled = true;
        cam.GetComponent<PlayerLook>().enabled = true;
    }

}
