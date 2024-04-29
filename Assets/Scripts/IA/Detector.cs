using System;
using Unity.VisualScripting;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField]private Samurai _samurai;

    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _samurai.AttackOn = true;
            }
        }
    }
