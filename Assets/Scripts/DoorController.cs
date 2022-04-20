using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Debug.Log("Door Triggered 1");
            Debug.Log("Door Triggered 2");
            //rigidbody2d.velocity = new Vector2(0f, 0f);
        }
    }
}
