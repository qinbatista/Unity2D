using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    Image image;
    float cooldownTime = 5f;
    static float TimerRepeatTime = 0.04f;
    void Start()
    {
        InvokeRepeating("Cooldown", 0f, TimerRepeatTime);
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Cooldown()
    {
        image.fillAmount -= 1f / cooldownTime * TimerRepeatTime;
    }
}
