using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonoTrigger : MonoBehaviour
{
    public GameObject uiObject;
    static bool Displaying = false;
    static bool Cancel = false;


    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
    }

    //detect player collision
    private void OnTriggerEnter(Collider player)
    {
        if (Displaying)
        {
            Cancel = true;
            Debug.Log("Cancel");
        }
        if (player.gameObject.tag == "Player")
        {
            
            StartCoroutine("WaitForSec");  //this inistialises 
            Debug.Log("Hello");
        }    
    }
    // time waited before destroying text / if cancel becomes true then drop out
    IEnumerator WaitForSec()
    {
        while (Displaying)
        {
            yield return null; //as running, reach return, wait for next frame
        }
        Displaying = true;
        uiObject.SetActive(true);
        float time = 0f;
        
        while(time < 5.0f && !Cancel)
        {
            yield return null;
            time += Time.deltaTime;
        }
        Destroy(uiObject);
        Destroy(gameObject);
        Displaying = false;
        Cancel = false;
    }

}
