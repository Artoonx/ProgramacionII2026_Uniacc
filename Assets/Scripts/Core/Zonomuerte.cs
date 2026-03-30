using System;
using UnityEngine;

public class Zonomuerte : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.CompareTag("Player"))
        {
            VidaPlayer Saludplayer = colision.GetComponent<VidaPlayer>();
            if (Saludplayer != null)
            {
                Saludplayer.Takedamage((999));
            }
        }
    }
}
