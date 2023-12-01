using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidPlayer : MonoBehaviour
{
    public float speed;
    //public GameObject Player;
    public float range;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 distance = GameObject.FindWithTag("Player").transform.position - transform.position;
        
        if(distance.magnitude < range){
            float dis = distance.magnitude - range;
            body.AddForce(distance.normalized * speed * dis - body.velocity); 
    }
}
}
