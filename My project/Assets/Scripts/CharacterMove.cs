using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private Rigidbody2D body;
    public float hor;
    public float ver;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private float moveLimiter = 0.6f;
    public float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Hor", hor);
        ver = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Ver", ver);
        if(hor < 0){
            spriteRenderer.flipX = true;
        }else if(hor > 0){
            spriteRenderer.flipX = false;
        }
        
    }
    void FixedUpdate(){
        if(hor != 0 && ver != 0){
            animator.SetFloat("Hor",hor);
            animator.SetFloat("Ver",ver);
            hor *= moveLimiter;
            ver *= moveLimiter;
        }
        body.velocity = new Vector2(hor * speed, ver * speed);
    }
}
