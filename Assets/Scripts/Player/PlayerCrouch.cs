using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    CharacterController charCollider;

    public bool isCrouched;
    public float smoothLerp = 2.0f;
    public float smoothCrouch = 0.1f;
    float crouchLerp = 0;

    // Start is called before the first frame update
    void Start()
    {
        charCollider = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            isCrouched = !isCrouched;
        }

        if(isCrouched)
        {
            charCollider.height = Mathf.Lerp(charCollider.height, 1.0f, Time.deltaTime);
        }

        if(!isCrouched)
        {
            charCollider.height = Mathf.Lerp(charCollider.height, 2.0f, Time.deltaTime * smoothCrouch);
        }
    }
}
