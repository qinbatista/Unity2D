using UnityEngine;
using UnityEngine.InputSystem;
public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 moveInput;
    Rigidbody2D _rigidbody2D;
    Animator _animator;
    int runningID;
    CapsuleCollider2D _capsuleCollider2D;
    int groundLayerID;
    int climbingID;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        runningID = Animator.StringToHash("Running");
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        groundLayerID = LayerMask.GetMask("Ground");
        climbingID = LayerMask.GetMask("Climbing");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // FlipSprite();
        // ClimbingLadder();
        _rigidbody2D.velocity = new Vector2(moveInput.x*5, _rigidbody2D.velocity.y);
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
        // _rigidbody2D.velocity = new Vector2(moveInput.x*5,_rigidbody2D.velocity.y);
        bool running = Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Epsilon;
        if (running)
        {
            // Debug.Log("Running");
            _animator.SetBool(runningID, true);
        }
        else
        {
            // Debug.Log("Stop");
            _animator.SetBool(runningID, false);
        }
        FlipSprite();
    }
    void OnJump(InputValue value)
    {
        if (value.isPressed && _capsuleCollider2D.IsTouchingLayers(groundLayerID))
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 5f);
        }
    }

    void FlipSprite()
    {
        bool PlayerSpeed = Mathf.Abs(moveInput.x) > Mathf.Epsilon;
        if (PlayerSpeed)
            transform.localScale = new Vector2(Mathf.Sign(moveInput.x), 1f);
    }
    void ClimbingLadder()
    {
        // Debug.Log("climbing");
        Vector2 climbVelocity = new Vector2 (_rigidbody2D.velocity.x, 5);
        _rigidbody2D.velocity = climbVelocity;
    }
}
