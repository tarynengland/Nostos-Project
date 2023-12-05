using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject cam;
    private float lenght;
    private float start;
    public float following = 0f;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - following));
        float dist = (cam.transform.position.x * following);

        transform.position = new Vector3(start + dist, transform.position.y, transform.position.z);
        if (temp > start + lenght){ start += lenght;}
        else if (temp < start - lenght){ start -= lenght;}
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
