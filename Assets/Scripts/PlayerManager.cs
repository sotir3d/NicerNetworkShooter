using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerManager : NetworkBehaviour
{
    int playerHealth = 1;
    int deaths = 0;
    private NetworkStartPosition[] _startPositions;

    public Text deathCounter;

    private void Start()
    {
        if (isLocalPlayer)
        {
            _startPositions = FindObjectsOfType<NetworkStartPosition>();
        }
    }

    public void Respawn()
    {
        RpcRespawn();
    }
    
    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            if (_startPositions != null && _startPositions.Length > 0)
            {
                transform.position = _startPositions[Random.Range(0, _startPositions.Length)].transform.position;
            }
        }
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        GetComponent<SpriteRenderer>().color = Color.red;
    }
    
//    void OnCollisionEnter2D(Collision2D coll)
//    {
//            if (coll.gameObject.CompareTag("Bullet"))
//            {
//                playerHealth--;
//                Invoke("Respawn", 2f);
//            }
//    }

//    void Respawn()
//    {
//        deaths++;
//        deathCounter.text = "Deaths: " + deaths;
//    }
}
