using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 rawInput;
    [SerializeField] float moveSpeed;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    Vector2 minBounds;
    Vector2 maxBounds;
    void Awake()
    {
        minBounds = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maxBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;

        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingTop, maxBounds.y - paddingBottom);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        Debug.Log(rawInput);
    }
}
