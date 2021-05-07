using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour
{
    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        anim.SetBool("kazıyo", true);
        print("on trigger");
        if (other.gameObject.CompareTag("Demir") && Input.GetKey(KeyCode.E))
        {
            print("x");
            other.GetComponent<SpriteRenderer>().enabled = false;
            other.GetComponent<BoxCollider2D>().enabled = false;
            other.GetComponent<CircleCollider2D>().enabled = false;
            anim.SetBool("kazıyo", false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        anim.SetBool("kazıyo", false);
    }
}
