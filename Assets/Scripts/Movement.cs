using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    // Use this for initialization
    public float Speed = 10;
    public float Force = 300;
    Rigidbody2D rigidbody;
    private Animator anim;
    private SpriteRenderer mySpriteRenderer;
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
        anim = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        groundCheck = transform.Find("GroundCheck");
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
        if (grounded) anim.SetBool("grounded", true);
        else anim.SetBool("grounded", false);
    }
    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(jump) && grounded)
        {
            rigidbody.velocity = new Vector2(0, 0);
            rigidbody.AddForce(new Vector2(0, Force));
            anim.SetBool("grounded", false);
        }

        if (Input.GetKey(right))
        {
            rigidbody.velocity = new Vector2(Speed, rigidbody.velocity.y);
            if (grounded) anim.SetFloat("velocity", 10);
            transform.localScale = new Vector3(3, 3, 3);
        }
        else if (Input.GetKey(left))
        {
            rigidbody.velocity = new Vector2(-Speed, rigidbody.velocity.y);
            if (grounded) anim.SetFloat("velocity", 10);
            transform.localScale = new Vector3(-3, 3, 3);
        }
        else
        {
            anim.SetFloat("velocity", 0);
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }
    }
}

