using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraImport : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject secundaryCamera;
    public KeyCode switchcamera;
    Camera cam1;
    int i;

    // Use this for initialization
    void Start()
    {
        mainCamera.SetActive(true);
        secundaryCamera.SetActive(true);
        cam1 = mainCamera.GetComponent<Camera>();
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(switchcamera) && i == 0)
        {
            /*secundaryCamera.SetActive(false);
            mainCamera.SetActive(true);*/

            cam1.rect = new Rect(0, 0, 1, 1);
            //mainCamera.camera. = new Rect ()
            i++;
        }
        else
        {
            if (Input.GetKeyUp(switchcamera) && i == 1)
            {
                cam1.rect = new Rect(0, 0, 0.5f, 1);
                i = 0;
            }
        }

    }
}
