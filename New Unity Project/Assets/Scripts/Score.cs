using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text AltınSayisi;
    public Text DemirSayisi;
    private int BaslangicDenirSayısı;
    private int BaslagicAltınSayısı;
    void Start()
    {
        BaslagicAltınSayısı = 0;
        BaslangicDenirSayısı = 0;
        AltınSayisi.text = "Score : " + BaslagicAltınSayısı;
        DemirSayisi.text = "Demir : " + BaslangicDenirSayısı;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DemirBar")
        {
            BaslangicDenirSayısı += 1;
            Destroy(other.gameObject);
            DemirSayisi.text = "Score" + BaslangicDenirSayısı;
        }
        if (other.tag == "AltinBar")
        {
            BaslagicAltınSayısı += 1;
            Destroy(other.gameObject);
            AltınSayisi.text = "Score" + BaslagicAltınSayısı;
        }
    }

    private void FixedUpdate()
    {
        if (BaslagicAltınSayısı == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
