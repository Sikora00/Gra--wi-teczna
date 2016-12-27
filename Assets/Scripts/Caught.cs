using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caught : MonoBehaviour {

    public Vector3 spawnPoint;
    // Use this for initialization
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        collision.transform.position = spawnPoint;
    }
}
