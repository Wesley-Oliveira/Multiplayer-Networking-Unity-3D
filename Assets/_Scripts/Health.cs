using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Health : NetworkBehaviour
{
    public const int maxHealth = 100;
    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;
    public RectTransform healthBar;
    public bool destroyOnDeath;
    public Transform[] respawn;

    public void TakeDamage(int amount)
    {
        if(!isServer)
        {
            return;
        }

        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Debug.Log("Dead!");
            currentHealth = maxHealth;
            RpcRespawn();
        }
        //atualiza no server
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }

    public void OnChangeHealth(int health)
    {
        //atualiza no client
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if(destroyOnDeath)
        {
            Destroy(gameObject);
        }
        else
        {
            if (isLocalPlayer)
            {
                int respawnLocal = Random.Range(1, 6);

                switch(respawnLocal)
                {
                    case 1:
                        transform.position = respawn[0].position;
                        break;
                    case 2:
                        transform.position = respawn[1].position;
                        break;
                    case 3:
                        transform.position = respawn[2].position;
                        break;
                    case 4:
                        transform.position = respawn[3].position;
                        break;
                    case 5:
                        transform.position = respawn[4].position;
                        break;
                }
            }
        }
    }
}
