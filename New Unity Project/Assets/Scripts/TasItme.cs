using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasItme : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Daş"))
        {
            anim.SetBool("itiriyor", true);
        }
        else
        {
            anim.SetBool("itiriyor", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D atır)
    {
        if (atır.gameObject.CompareTag("Merdiven"))
        {
            anim.SetBool("tırmanıyo", false);
        }
        else
        {
            anim.SetBool("tırmanıyo", true);
        }
    }
}
