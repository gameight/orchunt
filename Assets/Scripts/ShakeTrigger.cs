using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTrigger : MonoBehaviour {

    public CameraShake cameraShake;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //StartCoroutine(cameraShake.Shake(.15f, .1f));

        }
    }
}
