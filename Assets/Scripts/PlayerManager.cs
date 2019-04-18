using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.Serialization;

public class PlayerManager : NetworkBehaviour
{
    public int deathCounter = 0;
    
    private NetworkStartPosition[] _startPositions;

    private void Start()
    {
        if (isLocalPlayer)
        {
            _startPositions = FindObjectsOfType<NetworkStartPosition>();
            GameObject.FindGameObjectWithTag("LocalPlayer").GetComponent<LocalPlayer>().localPlayer = gameObject;
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
        GetComponent<SpriteRenderer>().color = Color.blue;
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
