using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce=10f;
    [SerializeField]
    private float jumpForce=10f;
    private Rigidbody2D mybody;
    private Animator anim;
    private SpriteRenderer sr;
    private string WALK_ANIMATION = "walk";
    private float movementX;
    private string Ground_Tag = "Ground";
    private string Enemy_Tag = "Enemy";
    private bool isGrounded=true;

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementKeyboard();
        AnimatePlayer();
    }
    void FixedUpdate()
    { 
       JumpPlayer();
    }
    void PlayerMovementKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce* Time.deltaTime;
        
    }
    void AnimatePlayer()
    {
        if(movementX>0)
          {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false; 
        }
        else if(movementX<0)
            {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
        
    }
    void JumpPlayer()
    {
        if(Input.GetButtonDown("Jump")&& isGrounded)
        {
            isGrounded = false;
            mybody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            
        }
    }
private void OnCollisionEnter2D(Collision2D collision)
{
    if(collision.gameObject.CompareTag(Ground_Tag))
        {
            isGrounded = true;
        }
    if(collision.gameObject.CompareTag(Enemy_Tag))
        {
            Destroy(gameObject);
        }
}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag(Enemy_Tag))
        {
            Destroy(gameObject);
        }
    }
}
