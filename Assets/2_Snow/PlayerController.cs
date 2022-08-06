using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float torqueAmount = 0;
    Rigidbody2D _rigidbody2D;
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] ParticleSystem _particleSystem;
    List<double> longList = new List<double>();
    List<double> shortList = new List<double>();
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        // TestTime();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondToBoost();
    }
    void TestTime()
    {
        for(int i = 0; i < 1000000; i++)
        {
            longList.Add(transform.position.x);
        }
        for(int i = 0; i < 100; i++)
        {
            shortList.Add(transform.position.x);
        }


        float timeNowStart = Time.realtimeSinceStartup;
        for(int i = 0; i < 1000000; i++)
        {
            longList[999999] = 1;
        }
        float timeNowEnd = Time.realtimeSinceStartup;;
        float longDuration = timeNowEnd - timeNowStart;


        timeNowStart = Time.realtimeSinceStartup;;
        for(int i = 0; i < 1000000; i++)
        {
            shortList[0] = 1;
        }
        timeNowEnd = Time.realtimeSinceStartup;;
        float shortDuration = timeNowEnd - timeNowStart;

        Debug.Log("long:sort=>" + longDuration+":"+ shortDuration);
    }
    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            surfaceEffector2D.speed = 20;
        }
        else
        {
            surfaceEffector2D.speed = 10;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody2D.AddTorque(torqueAmount);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody2D.AddTorque(-torqueAmount);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Player enter collision with " + other.collider.name);
        _particleSystem.Play();
    }
    void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Player exit collision with " + other.collider.name);
        _particleSystem.Stop();
    }
}
