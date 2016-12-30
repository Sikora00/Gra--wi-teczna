using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Movement : NetworkBehaviour
{
    // Use this for initialization
    public float Speed = 10;
    public float Force = 300;
    Rigidbody2D rigidbody;
    private Transform groundCheck;
    [SerializeField]
    private LayerMask whatIsGround; // A mask determining what is ground to the character
    private float groundedRadius = 0.2f; // Radius of the overlap circle to determine if grounded
    private bool grounded = false; // Whether or not the player is grounded.
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
    }
    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) return;

        if (Input.GetKeyDown(jump) && grounded)
        {
            rigidbody.velocity = new Vector2(0, 0);
            rigidbody.AddForce(new Vector2(0, Force));
        }

        if (Input.GetKey(right))
        {
            rigidbody.velocity = new Vector2(Speed, rigidbody.velocity.y);
            transform.localScale = new Vector3(3, 3, 3);
        }
        else if (Input.GetKey(left))
        {
            rigidbody.velocity = new Vector2(-Speed, rigidbody.velocity.y);
            transform.localScale = new Vector3(-3, 3, 3);
        }
        else
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel(0);
        }
    }
}

