using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    AudioClip[] barClips;
    AudioSource source;

    int curClip = 0;
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        barClips = new AudioClip[]{(AudioClip)Resources.Load("Songs/Test/1"),
                                     (AudioClip)Resources.Load("Songs/Test/2"),
                                     (AudioClip)Resources.Load("Songs/Test/3"),
                                     (AudioClip)Resources.Load("Songs/Test/4"),
                                     (AudioClip)Resources.Load("Songs/Test/5"),
                                     (AudioClip)Resources.Load("Songs/Test/6"),
                                     (AudioClip)Resources.Load("Songs/Test/7"),
                                     (AudioClip)Resources.Load("Songs/Test/8"),
                                     (AudioClip)Resources.Load("Songs/Test/9"),
                                     (AudioClip)Resources.Load("Songs/Test/10"),
                                     (AudioClip)Resources.Load("Songs/Test/11"),
                                     (AudioClip)Resources.Load("Songs/Test/12"),
                                     (AudioClip)Resources.Load("Songs/Test/13"),
                                     (AudioClip)Resources.Load("Songs/Test/14"),
                                     (AudioClip)Resources.Load("Songs/Test/15"),
                                     (AudioClip)Resources.Load("Songs/Test/16"),
                                     (AudioClip)Resources.Load("Songs/Test/17"),
                                     (AudioClip)Resources.Load("Songs/Test/18"),
                                     (AudioClip)Resources.Load("Songs/Test/19"),
                                     (AudioClip)Resources.Load("Songs/Test/20"),
                                     (AudioClip)Resources.Load("Songs/Test/21"),
                                     (AudioClip)Resources.Load("Songs/Test/22"),
                                     (AudioClip)Resources.Load("Songs/Test/23"),
                                     (AudioClip)Resources.Load("Songs/Test/24")};
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayNext()
    {
        source.clip = barClips[curClip];
        source.Play();
        curClip++;
    }
}
