using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaltoDenivel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("Scenes/Menu");
        }
    }
}    
    
