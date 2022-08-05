using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Start is called before the first frame update
    float steerAmount = 0;
    float moveAmount = 0;
    [SerializeField] float steerSpeed = 0;
    [SerializeField] float moveSpeed = 0;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color32(255, 255, 0, 255);
    }

    // Update is called once per frame
    void Update()
    {
        steerAmount = Input.GetAxis("Horizontal");
        moveAmount = Input.GetAxis("Vertical");
        transform.Rotate(0, 0, -steerSpeed * steerAmount * Time.deltaTime);
        transform.Translate(0, moveSpeed * moveAmount * Time.deltaTime, 0);
    }
}
