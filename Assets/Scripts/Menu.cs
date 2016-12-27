using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    Ray ray = new Ray();
    RaycastHit hit = new RaycastHit();


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "PlayButton")
                    Application.LoadLevel(1);
                if (hit.transform.name == "ExitButton")
                    Application.Quit();
            }
        }

    }
}
