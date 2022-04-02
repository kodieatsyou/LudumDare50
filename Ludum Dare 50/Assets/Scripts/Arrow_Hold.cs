using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Hold : MonoBehaviour
{
    public float dropSpeed = 0.1f;
    public Sprite left;
    public Sprite right;
    public Sprite up;
    public Sprite down;
    public Sprite leftHold;
    public Sprite rightHold;
    public Sprite upHold;
    public Sprite downHold;

    public GameObject holdLine;

    AudioPlayer aPlayer;

    public SpriteRenderer sr;

    public bool isMultiNote = false;

    float timeUntilNextNote = 0f;

    bool extend = false;

    void Awake()
    {
        sr.sprite = left;
        holdLine.GetComponent<SpriteRenderer>().sprite = leftHold;
        aPlayer = GameObject.FindGameObjectWithTag("AudioPlayer").GetComponent<AudioPlayer>();
    }

    private void Start()
    {
        StartCoroutine(SetExtend(timeUntilNextNote));
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - dropSpeed);
        if(extend)
        {
            holdLine.transform.localScale = new Vector3(holdLine.transform.localScale.x, holdLine.transform.localScale.y + dropSpeed, holdLine.transform.localScale.z);
        }
    }

    IEnumerator SetExtend(float time)
    {
        extend = true;
        yield return new WaitForSecondsRealtime(time);
        extend = false;
    }

    public void setSprite(string direction, float time)
    {
        if (direction == "left")
        {
            sr.sprite = left;
            holdLine.GetComponent<SpriteRenderer>().sprite = leftHold;
        }
        else if (direction == "right")
        {
            sr.sprite = right;
            holdLine.GetComponent<SpriteRenderer>().sprite = rightHold;
        }
        else if (direction == "up")
        {
            sr.sprite = up;
            holdLine.GetComponent<SpriteRenderer>().sprite = upHold;
        }
        else
        {
            sr.sprite = down;
            holdLine.GetComponent<SpriteRenderer>().sprite = downHold;
        }
        timeUntilNextNote = time;
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
