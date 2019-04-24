using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Serialization;

public class PlayerManager : NetworkBehaviour
{
    public int deathCounter;
    private NetworkStartPosition[] _startPositions;

    public Text deathCounterText;

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
                deathCounter++;
            }
        }
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        GetComponent<SpriteRenderer>().color = Color.black;
    }
}