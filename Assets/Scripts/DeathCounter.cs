using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathCounter : MonoBehaviour
{
    public TextMeshProUGUI deathCounter;
    public LocalPlayer localPlayer;

    // Start is called before the first frame update
    void Start()
    {
        deathCounter = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (localPlayer.localPlayer != null)
        {
            deathCounter.text = "Deaths: " + localPlayer.localPlayer.GetComponent<PlayerManager>().deathCounter;
        }
    }
}