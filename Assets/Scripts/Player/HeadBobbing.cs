using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobbing : MonoBehaviour
{
    CharacterController cC;

    public float horizontalMovement;
    public float verticalMovement;
    public float verticalOffset;
    [Space(10)]
    public float horizontalSpeed;
    public float verticalSpeed;   //vertical speed should ALWAYS be 2x more than horizontalSpeed so the cycle is in sync
    [Space(10)]
    public float smooth;
    public float maxVel;

    float curX = 0;
    float curY = 0;
    float lerp = 0;

    private void Awake()
    {
        cC = transform.root.GetComponent<CharacterController>();
    }

    void Update()
    {
        lerp = cC.velocity.magnitude / maxVel;

        curX = 0 + Mathf.Sin(Time.time * horizontalSpeed) * horizontalMovement * lerp;
        curY = verticalOffset + Mathf.Sin(Time.time * verticalSpeed) * verticalMovement * lerp;

        transform.localPosition = new Vector3(curX, curY, 0);
    }
}
