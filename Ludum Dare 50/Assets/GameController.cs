using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int performance = 0;
    public int missAmnt = 2;
    public int playAmnt = 1;
    GameObject uiObj;
    GameObject MusicAudioPlayer;

    public bool performingSong = false;

    private void Awake()
    {
        uiObj = GameObject.FindGameObjectWithTag("UIObject");
        MusicAudioPlayer = GameObject.FindGameObjectWithTag("AudioPlayer");
        performingSong = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        performance = 0;
        MusicAudioPlayer.GetComponent<AudioPlayer>().PlayStartUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tickPerformanceDown()
    {
        if(performance - missAmnt > -150)
        {
            performance = performance - missAmnt;
        } else if (performance - missAmnt <= -150)
        {
            performance = -150;
        }
        uiObj.GetComponent<UIController>().MoveNeedle(performance);
    }

    public void tickPerformanceUp()
    {
        if(performance + playAmnt < 150)
        {
            performance = performance + playAmnt; 
        } else if (performance + playAmnt >= 150)
        {
            performance = 150;
        }
        uiObj.GetComponent<UIController>().MoveNeedle(performance);
    }

}
