using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    CharacterController charCon;
    float originalHeight;
    public float reduceHeight;

    // Start is called before the first frame update
    void Start()
    {
        charCon = GetComponent<CharacterController>();
        originalHeight = charCon.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            Crouching();
        else if (Input.GetKeyUp(KeyCode.Q))
            GoUp();
    }

    void Crouching()
    {
        charCon.height = reduceHeight;
    }

    void GoUp()
    {
        charCon.height = originalHeight;
    }
}
