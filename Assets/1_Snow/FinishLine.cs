using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Invoke("ReloadScene", 1f);
            Debug.Log("Player reached the finish line!");
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene("level1");
    }
}
