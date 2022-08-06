using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    [SerializeField] AudioClip crashSFX;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("Player crashed!");
            Invoke("ReloadScene", 1f);
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene("level1");
    }
}
