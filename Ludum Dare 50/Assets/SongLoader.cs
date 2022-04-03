using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongLoader : MonoBehaviour
{

    public Object[] songs;

    public SongObject currentSong;

    public int songChoice = 0;

    ArrowDropper dropper;
    AudioPlayer aPlayer;

    // Start is called before the first frame update
    void Start()
    {
        songs = Resources.LoadAll("SongObjects", typeof(SongObject));
        aPlayer = GameObject.FindGameObjectWithTag("AudioPlayer").GetComponent<AudioPlayer>();
        dropper = GameObject.FindGameObjectWithTag("Dropper").GetComponent<ArrowDropper>();
        LoadSong();
        QueueSong();
    }

    void LoadSong()
    {
        currentSong = (SongObject)songs[songChoice];
        currentSong.loadData();
    }

    void QueueSong()
    {
        aPlayer.Load(currentSong.getAudioClip());
        dropper.Load(currentSong.getSongText(), currentSong.BPM);
    }

    //AudioPlayer Needs Song
    //ArrowDropper needs BPM and text data

}
