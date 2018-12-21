using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        
        Application.targetFrameRate = 30;
        //   Application.targetFrameRate = 60;

        //Screen.SetResolution((int)Screen.width, (int)Screen.height, true);
    }

    // Update is called once per frame
    void LateUpdate () {
        
    }
}
