using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float torqueAmount = 0;
    Rigidbody2D _rigidbody2D;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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
}
