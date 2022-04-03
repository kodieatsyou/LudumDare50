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

    public AudioClip fullSong;

    public float BPM;

    float timeInSong = 0;

    bool playingSong = false;
    // Start is called before the first frame update
    void Start()
    {

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
        source.mute = true;
        missSource.Play();
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().tickPerformanceDown();
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
            source.clip = fullSong;
            source.Play();
        }
        if (!source.mute)
        {
            return;
        }
        else
        {
            playingSong = true;
            source.mute = false;
        }
    }

    public void MoveSongForward()
    {
        timeInSong += (60f / BPM) / 4f;
        Debug.Log("Moving forward time now = " + timeInSong);
    }

    public void StopSong()
    {
        PlayMiss();
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().tickPerformanceDown();
        if (!source.isPlaying)
        {
            source.clip = fullSong;
            source.Play();
        }
        if (!source.mute)
        {
            playingSong = false;
            source.mute = true;
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
        source.clip = fullSong;
        source.Play();
    }

}
