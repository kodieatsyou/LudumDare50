using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SongObject", order = 1)]
public class SongObject : ScriptableObject
{
    public string songName;
    public string artist;
    string displayName;
    public int BPM;
    AudioClip songClip;
    TextAsset songText;

    public void loadData()
    {
        songClip = (AudioClip)Resources.Load("Songs/" + songName);
        songText = (TextAsset)Resources.Load("Text/" + songName);
        displayName = songName + " By: " + artist;
    }

    public AudioClip getAudioClip()
    {
        return songClip;
    }

    public TextAsset getSongText()
    {
        return songText;
    }
}
