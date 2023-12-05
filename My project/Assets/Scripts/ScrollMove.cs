using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMove : MonoBehaviour
{
    private Rigidbody2D player;
    public float hor;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public float speed = 4f;
    private int jumpCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Hor", hor);
        if (hor < 0){
            spriteRenderer.flipX = true;
        } else if(hor > 0){
            spriteRenderer.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            if (jumpCount < 5){
                player.AddForce(new Vector2(0,100));
                jumpCount++;}
        // else if (Input.GetKeyDown(KeyCode.UpArrow)){
        //    player.transform.position = new Vector3(transform.position.x, 50f,0f);
        //}
    }
    }

    void FixedUpdate()
    {
        player.velocity = new Vector2(hor * speed, player.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
            jumpCount = 0;
    }
}
