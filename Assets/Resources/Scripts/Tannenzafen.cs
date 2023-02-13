using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tannenzafen : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreCounter.instance.IncrementScoreTannenzafen();
            Destroy(gameObject);
        }
    }
}
