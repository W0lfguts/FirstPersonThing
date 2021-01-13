using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollection : MonoBehaviour
{
    public Collections collections;
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            collections.Collect("You", 0);
        }
        
        if (Input.GetKeyDown("2"))
        {
            collections.Collect("You", 1);
        }

        if (Input.GetKeyDown("3"))
        {
            collections.Collect("Misc", 0);
        }

        if (Input.GetKeyDown("4"))
        {
            collections.Collect("Misc", 1);
        }
    }
}
