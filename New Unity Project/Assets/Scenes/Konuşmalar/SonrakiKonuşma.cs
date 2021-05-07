using UnityEngine;
using UnityEngine.SceneManagement;

public class SonrakiKonuşma : MonoBehaviour
{
    public void NextDialog()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
}