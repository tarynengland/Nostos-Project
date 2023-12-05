using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {get; private set;}
    public GameObject Background;
    public GameObject menubtn;
    public GameObject curtain;
    public GameObject canvas;
    private bool raiseLower = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame(){
        Background.SetActive(false);
        menubtn.SetActive(true);
    }
    IEnumerator ColorLerpFunction(bool fadeout, float duration)
    {
        float time = 0;
        raiseLower = true;
        Image curtainImg = curtain.GetComponent<Image>();
        Color startValue;
        Color endValue;
        if (fadeout) {
            startValue = new Color(0, 0, 0, 0);
            endValue = new Color(0, 0, 0, 1);
        } else {
            startValue = new Color(0, 0, 0, 1);
            endValue = new Color(0, 0, 0, 0);
        }
        while (time < duration)
        {
            curtainImg.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        curtainImg.color = endValue;
        raiseLower = false;
    }
     IEnumerator LoadYourAsyncScene(string scene)
    {
        StartCoroutine(ColorLerpFunction(true, 1));
        while (raiseLower)
        {
            yield return null;
        }
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

    while(!asyncLoad.isDone)
    {
        yield return null;
    }
    
    StartCoroutine(ColorLerpFunction(false, 1));
    }

    public void ChangeScene(string scene){
        StartCoroutine(LoadYourAsyncScene(scene));
        }
}
