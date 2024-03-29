using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public GameObject performanceNeedle;
    public GameObject alienHead;

    public Sprite alienMid;
    public Sprite alienMad;
    public Sprite alienHappy;

    float needlePlusMinus = 0;

    // Start is called before the first frame update
    void Start()
    {
        alienHead.GetComponent<Image>().sprite = alienMid;
    }

    // Update is called once per frame
    void Update()
    {
        if(needlePlusMinus > 50)
        {
            alienHead.GetComponent<Image>().sprite = alienHappy;
        } else if(needlePlusMinus < -50)
        {
            alienHead.GetComponent<Image>().sprite = alienMad;
        } else
        {
            alienHead.GetComponent<Image>().sprite = alienMid;
        }
    }

    public void MoveNeedle(int amnt)
    {
        needlePlusMinus = amnt;
        GameObject.FindGameObjectWithTag("Needle").transform.localPosition = new Vector3(amnt, 0, 0);
    }
}
