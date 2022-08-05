using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    // Start is called before the first frame update
    string playerTag = "Player";
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == playerTag)
        {
            Debug.Log("Player passed:" + this.name);
        }
    }
}
