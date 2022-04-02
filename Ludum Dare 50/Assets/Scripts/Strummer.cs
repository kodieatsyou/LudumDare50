using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strummer : MonoBehaviour
{

    BoxCollider2D bc;
    SpriteRenderer sr;

    public Sprite lit;
    public Sprite dark;

    bool strumming = false;

    bool colliding = false;

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
        if(!colliding)
        {
            //GameObject.FindGameObjectWithTag("AudioPlayer").GetComponent<AudioPlayer>().PlayMiss();
        }
        StartCoroutine(ActivateStrummer());
    }

    IEnumerator ActivateStrummer()
    {
        sr.sprite = lit;
        strumming = true;
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
                    collision.gameObject.GetComponent<Arrow>().StrumNote();
                }
                else
                {
                    collision.gameObject.GetComponent<Arrow_Hold>().StrumNote();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            colliding = true;
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
