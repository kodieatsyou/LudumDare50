using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public float dropSpeed = 0.1f;
    public Sprite left;
    public Sprite right;
    public Sprite up;
    public Sprite down;

    AudioPlayer aPlayer;

    public SpriteRenderer sr;

    public bool isMultiNote = false;

    public bool firstNote = false;

    // Start is called before the first frame update
    void Awake()
    {
        sr.sprite = left;
        firstNote = false;
        aPlayer = GameObject.FindGameObjectWithTag("AudioPlayer").GetComponent<AudioPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - dropSpeed);
    }

    public void setSprite(string direction)
    {
        if(direction == "left")
        {
            sr.sprite = left;
        } else if (direction == "right")
        {
            sr.sprite = right;
        } else if (direction == "up")
        {
            sr.sprite = up;
        } else
        {
            sr.sprite = down;
        }
    }

    public void StrumNote()
    {
        aPlayer.PlaySong();
        Destroy(this.gameObject);
    }

    public void MissNote()
    {
        aPlayer.StopSong();
        Destroy(this.gameObject);
    }
}
