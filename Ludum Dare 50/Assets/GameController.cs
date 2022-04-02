using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public float performance = 0f;
    GameObject uiObj;

    private void Awake()
    {
        uiObj = GameObject.FindGameObjectWithTag("UIObject");
    }

    // Start is called before the first frame update
    void Start()
    {
        performance = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tickPerformanceDown()
    {
        if(performance - 1 >= -100)
        {
            performance = performance - 1;
            uiObj.GetComponent<UIController>().MoveNeedle(-10);
        } else
        {
            //Loose
        }
    }

    public void tickPerformanceUp()
    {
        if(performance + 1 <= 100)
        {
            performance = performance + 1;
            uiObj.GetComponent<UIController>().MoveNeedle(10);
        }
    }

}
