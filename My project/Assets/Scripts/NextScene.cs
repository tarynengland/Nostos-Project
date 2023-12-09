using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string scene;

    
    public void OnTriggerEnter2D(Collider2D collision) {
        print("Entered..");
        
        if (collision.gameObject.CompareTag("Player") ) {
            GameManager.instance.ChangeScene(scene);
        }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}
    
