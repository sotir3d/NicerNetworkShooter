using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerHealth : NetworkBehaviour
{
    public const int maxHealth = 100;
    [SyncVar(hook = "OnChangeHealth")] public int currentHealth = maxHealth;
    public RectTransform healthbar;

    private PlayerManager _playerManager;

    public GameObject particleDestruction;

    private void Start()
    {
        _playerManager = GetComponent<PlayerManager>();
    }

    public void TakeDamage(int amount)
    {
        if (!isServer)
        {
            return;
        }

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            if (!isLocalPlayer)
                _playerManager.deathCounter++;
            
            currentHealth = maxHealth;
            CmdParticleSpawn();
            _playerManager.Respawn();
        }
    }

    [Command]
    void CmdParticleSpawn()
    {
        GameObject particleEffect = Instantiate(particleDestruction, transform.position, Quaternion.identity);
        NetworkServer.Spawn(particleEffect);
    }

    void OnChangeHealth(int health)
    {
        healthbar.sizeDelta = new Vector2(health / 100.0f * 0.36f, healthbar.sizeDelta.y);
    }
}