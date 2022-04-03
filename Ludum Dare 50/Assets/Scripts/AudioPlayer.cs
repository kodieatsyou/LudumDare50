using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip[] missSounds;
    public AudioSource source;
    public AudioSource missSource;

    public AudioClip StartUp;

    public AudioClip tapIn;

    AudioClip song;

    bool playingSong = false;

    public void Load(AudioClip songClip) 
    {
        song = songClip;
    }

    // Update is called once per frame
    void Update()
    {
        if(playingSong)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("Playing", true);
        } else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("Playing", false);
        }
    }

    public void PlaySongOnMute()
    {
        if(!source.isPlaying)
        {
            source.Play();
            source.mute = true;
        }
    }

    public void PlayMiss()
    {
        int sound = Random.Range(0, missSounds.Length - 1);
        missSource.clip = missSounds[sound];
        StartCoroutine(MuteSongforHalfSecond());
        missSource.Play();
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().tickPerformanceDown();
    }

    IEnumerator MuteSongforHalfSecond()
    {
        source.mute = true;
        yield return new WaitForSeconds(0.5f);
        source.mute = false;
    }

    public void TapIn()
    {
        if(source.clip != tapIn)
        {
            source.clip = tapIn;
        }
        source.Play();
    }

    public void PlaySong()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().tickPerformanceUp();
        if (!source.isPlaying)
        {
            playingSong = true;
            source.clip = song;
            source.Play();
            source.mute = false;
        }
        if (source.mute == false)
        {
            return;
        }
        else
        {
            source.mute = false;
        }
    }

    public void StopSong()
    {
        PlayMiss();
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().tickPerformanceDown();
        if (!source.isPlaying)
        {
            source.clip = song;
            source.Play();
        }
        if (!source.mute)
        {
            playingSong = false;
            //source.mute = true;
        }
    }

    public void PlayStartUp()
    {
        source.clip = StartUp;
        source.mute = false;
        source.Play();
        StartCoroutine(WaitForStartUp());
    }

    IEnumerator WaitForStartUp()
    {
        yield return new WaitForSeconds(source.clip.length);
        GameObject.FindGameObjectWithTag("Dropper").GetComponent<ArrowDropper>().StartDropping();
        source.clip = song;
        source.time = 0;
    }

}
