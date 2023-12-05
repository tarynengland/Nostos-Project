using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCam : MonoBehaviour
{
    public float following = 2f;
    public Transform player;

    // Start is called before the first frame update
    void Start(){}
    void FixedUpdate()
    {
        Vector3 newPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, newPosition, following);
    }

    // Update is called once per frame
    void Update(){}
}
