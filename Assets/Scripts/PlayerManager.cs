using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class PlayerManager : MonoBehaviour
{
    int playerHealth = 1;
    int deaths = 0;

    public TextMeshProUGUI deathCounter;

    void OnCollisionEnter2D(Collision2D coll)
    {
        
        
            if (coll.gameObject.CompareTag("Bullet"))
            {
                playerHealth--;
                Invoke("Respawn", 2f);
            }
        
    }

    void Respawn()
    {
        deaths++;
        deathCounter.text = "Deaths: " + deaths;
    }
}
