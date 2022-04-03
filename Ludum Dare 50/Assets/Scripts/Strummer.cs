using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strummer : MonoBehaviour
{
    SpriteRenderer sr;

    public Sprite lit;
    public Sprite dark;
    public GameObject hitParticle;

    List<GameObject> thingsInCollider = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
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
        if (thingsInCollider.Count == 0)
        {
            GameObject.FindGameObjectWithTag("AudioPlayer").GetComponent<AudioPlayer>().PlayMiss();
            yield return new WaitForSeconds(0.1f);
            sr.sprite = dark;
        } else
        {
            GameObject noteToPlay = thingsInCollider[0];
            thingsInCollider.RemoveAt(0);
            if (noteToPlay.gameObject.GetComponent<Arrow>().firstNote)
            {
                GameObject.FindGameObjectWithTag("AudioPlayer").GetComponent<AudioPlayer>().PlaySong();
            }
            Instantiate(hitParticle, gameObject.transform);
            noteToPlay.gameObject.GetComponent<Arrow>().StrumNote();
        }
        yield return new WaitForSeconds(0.1f);
        sr.sprite = dark;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            thingsInCollider.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            thingsInCollider.Remove(collision.gameObject);
        }
    }
}
