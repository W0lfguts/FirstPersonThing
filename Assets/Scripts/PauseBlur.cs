using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PauseBlur : MonoBehaviour
{
    public PostProcessVolume volume;
    bool paused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
            var dof = volume.profile.GetSetting<DepthOfField>();
            dof.enabled.Override(paused);
            Time.timeScale = paused? 0.0f : 1.0f;
        }
    }
}
