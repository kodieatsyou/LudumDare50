using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDropper : MonoBehaviour
{

    float BPM;

    public GameObject leftArrowSpawner;
    public GameObject rightArrowSpawner;
    public GameObject upArrowSpawner;
    public GameObject downArrowSpawner;
    public GameObject arrow;
    public GameObject holdArrow;

    TextAsset song;
    string[] bars;

    // 60f/BPM

    public void Load(TextAsset songText, float songBPM)
    {
        song = songText;
        BPM = songBPM;
        bars = song.text.Split('.');
    }

    private void Srart()
    {
        
    }

    public void StartDropping()
    {
        StartCoroutine(DropArrows(60f / BPM));
    }
    IEnumerator DropArrows(float seconds)
    {
        for (int i = 0; i < bars.Length; i++)
        {
            if (i + 1 <= bars.Length - 1)
            {
                if(i == 0)
                {
                    StartCoroutine(PlayNotesInBar(bars[i], seconds / bars[i].Length, true));
                } else
                {
                    StartCoroutine(PlayNotesInBar(bars[i], seconds / bars[i].Length, false));
                }
                
            }
            yield return new WaitForSecondsRealtime(seconds);
        }
    }
    IEnumerator PlayNotesInBar(string bar, float time, bool firstBar)
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
                if (firstBar && i == 0)
                {
                    newArrow.GetComponent<Arrow>().firstNote = true;
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
                if (firstBar && i == 0)
                {
                    newArrow.GetComponent<Arrow>().firstNote = true;
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
                if (firstBar && i == 0)
                {
                    newArrow.GetComponent<Arrow>().firstNote = true;
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
                if (firstBar && i == 0)
                {
                    newArrow.GetComponent<Arrow>().firstNote = true;
                }
                newArrow.GetComponent<Arrow>().setSprite("down");
            }
            
            yield return new WaitForSecondsRealtime(time);
        }
    }
}