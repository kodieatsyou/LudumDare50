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

    public Text testText;

    public TextAsset song;
    AudioSource source;
    string[] bars;
    int bar = 0;
    public AudioClip[] barClips;


// Start is called before the first frame update
void Start()
    {
        bars = song.text.Split('.');
        StartCoroutine(Play((60f/BPM)/4f));
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator Play(float seconds)
    {
        for (int i = 0; i < bars.Length; i++) {
            ReadBar(bars[i]);
            yield return new WaitForSecondsRealtime(seconds);
        }
    }

    void ReadBar(string bar)
    {
        for (int i = 0; i < bar.Length; i++)
        {
            if (bar[i] == 'L')
            {
                GameObject newArrow = Instantiate(arrow, leftArrowSpawner.transform);
                if(i != 0)
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
        }
    }
}
