using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strummer : MonoBehaviour
{

    BoxCollider2D bc;
    SpriteRenderer sr;

    public Sprite lit;
    public Sprite dark;
    public GameObject hitParticle;

    bool strumming = false;

    bool colliding = false;

    GameObject collisionObj = null;

    // Start is called before the first frame update
    void Start()
    {
        bc = gameObject.GetComponent<BoxCollider2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Strum()
    {
        StartCoroutine(ActivateStrummer());
    }

    IEnumerator ActivateStrummer()
    {
        sr.sprite = lit;
        strumming = true;
        if(!colliding)
        {
            strumming = false;
            GameObject.FindGameObjectWithTag("AudioPlayer").GetComponent<AudioPlayer>().PlayMiss();
            yield return new WaitForSeconds(0.1f);
            sr.sprite = dark;
        }
        yield return new WaitForSeconds(0.1f);
        sr.sprite = dark;
        strumming = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Note")
        {
            colliding = true;
            if (strumming)
            {
                if (collision.gameObject.GetComponent<Arrow>() != null)
                {
                    Instantiate(hitParticle, gameObject.transform);
                    collision.gameObject.GetComponent<Arrow>().StrumNote();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            GameObject.FindGameObjectWithTag("AudioPlayer").GetComponent<AudioPlayer>().PlaySongOnMute();
            colliding = true;
            if (strumming)
            {
                if (collision.gameObject.GetComponent<Arrow>() != null)
                {
                    collision.gameObject.GetComponent<Arrow>().StrumNote();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            colliding = false;
        }
    }
}
