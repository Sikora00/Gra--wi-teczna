using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraImport : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject secundaryCamera;
    public KeyCode switchcamera;

    // Use this for initialization
    void Start()
    {
        mainCamera.SetActive(false);
        secundaryCamera.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(switchcamera))
        {
            secundaryCamera.SetActive(false);
            mainCamera.SetActive(true);
        }

    }
}
