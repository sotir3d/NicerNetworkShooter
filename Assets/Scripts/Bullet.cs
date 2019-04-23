using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyBullet", 2f);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag ("Tilemap"))
        {
            Debug.Log("Getroffen");
            Destroy(gameObject);
        }

        GameObject hit = coll.gameObject;
        PlayerHealth health = hit.GetComponent<PlayerHealth>();
        if(health != null)
        {
            health.TakeDamage(5);
            DestroyBullet();
        }
    }
}
