using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDropper : MonoBehaviour
{

    public float BPM;

    public GameObject leftArrowSpawner;
    public GameObject rightArrowSpawner;
    public GameObject upArrowSpawner;
    public GameObject downArrowSpawner;
    public GameObject arrow;
    public GameObject holdArrow;

    public Text testText;

    public TextAsset song;
    string[] bars;

    int countBarsIn = 0;
    bool start = false;

    // 60f/BPM

    // Start is called before the first frame update
    void Start()
    {
        bars = song.text.Split('.');
        start = false;
        StartCoroutine(DropArrows(60f/BPM));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DropArrows(float seconds)
    {
        if(!start)
        {
            start = true;
            yield return new WaitForSecondsRealtime(seconds);
        }
        while(countBarsIn < 4)
        {
            countBarsIn++;
            GameObject.FindGameObjectWithTag("AudioPlayer").GetComponent<AudioPlayer>().TapIn();
            yield return new WaitForSecondsRealtime(seconds);
        } 
        for (int i = 0; i < bars.Length; i++)
        {
            if (i + 1 <= bars.Length - 1)
            {
                StartCoroutine(PlayNotesInBar(bars[i], seconds / bars[i].Length));
            }
            yield return new WaitForSecondsRealtime(seconds);
        }
    }

    IEnumerator PlayNotesInBar(string bar, float time)
    {
        for (int i = 0; i < bar.Length; i++)
        {
            if (bar[i] == 'L')
            {
                GameObject newArrow = Instantiate(arrow, leftArrowSpawner.transform);
                if (i != 0)
                {
                    newArrow.GetComponent<Arrow>().isMultiNote = true;
                }
                newArrow.GetComponent<Arrow>().setSprite("left");
            }
            else if (bar[i] == 'R')
            {
                GameObject newArrow = Instantiate(arrow, rightArrowSpawner.transform);
                if (i != 0)
                {
                    newArrow.GetComponent<Arrow>().isMultiNote = true;
                }
                newArrow.GetComponent<Arrow>().setSprite("right");
            }
            else if (bar[i] == 'U')
            {
                GameObject newArrow = Instantiate(arrow, upArrowSpawner.transform);
                if (i != 0)
                {
                    newArrow.GetComponent<Arrow>().isMultiNote = true;
                }
                newArrow.GetComponent<Arrow>().setSprite("up");
            }
            else if (bar[i] == 'D')
            {
                GameObject newArrow = Instantiate(arrow, downArrowSpawner.transform);
                if (i != 0)
                {
                    newArrow.GetComponent<Arrow>().isMultiNote = true;
                }
                newArrow.GetComponent<Arrow>().setSprite("down");
            }
            yield return new WaitForSecondsRealtime(time);
        }
    }
}