using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PauseBlur : MonoBehaviour
{
    public Volume volume;
    bool paused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
            DepthOfField dof;
            if (volume.profile.TryGet<DepthOfField>(out dof))
            {
                dof.active = paused;
            }
            Time.timeScale = paused ? 0.0f : 1.0f;
        }
    }
}
