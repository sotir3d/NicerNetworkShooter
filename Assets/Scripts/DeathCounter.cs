using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class DeathCounter : MonoBehaviour
{
    private UnityEngine.UI.Text _deathCounter;

//    public LocalPlayer localPlayer;
    private GameObject _localPlayer;

    // Start is called before the first frame update
    void Start()
    {
        _deathCounter = GetComponent<UnityEngine.UI.Text>();
    }

    private void Update()
    {
        if (_localPlayer == null)
        {
            var allPlayers = GameObject.FindGameObjectsWithTag("Player").ToList();
            foreach (var player in allPlayers)
            {
                if (player.GetComponent<PlayerManager>().isLocalPlayer)
                    _localPlayer = player;
            }
        }

        if (_localPlayer != null)
        {
            if (_localPlayer.GetComponent<PlayerManager>() != null)
                _deathCounter.text = "Deaths: " + _localPlayer.GetComponent<PlayerManager>().deathCounter;
        }
    }
}