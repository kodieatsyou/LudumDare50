using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKiller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Note")
        {
            if(collision.gameObject.GetComponent<Arrow>() != null)
            {
                collision.gameObject.GetComponent<Arrow>().MissNote();
            } else
            {
                collision.gameObject.GetComponent<Arrow_Hold>().MissNote();
            }
            
        }
    }
}
