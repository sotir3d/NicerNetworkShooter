using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{
    public float speed;

    public GameObject bulletPrefab;
    public GameObject spawnPointW;
    public GameObject spawnPointD;
    public GameObject spawnPointA;
    public GameObject spawnPointS;

    private Rigidbody2D rb2d; 
    
    enum FireDirection
    {
        up,
        down,
        left,
        right
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isLocalPlayer)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                CmdFire(FireDirection.up);
            }

            else if (Input.GetKeyDown(KeyCode.D))
            {

                CmdFire(FireDirection.right);
            }

            else if (Input.GetKeyDown(KeyCode.A))
            {

                CmdFire(FireDirection.left);
            }

            else if (Input.GetKeyDown(KeyCode.S))
            {

                CmdFire(FireDirection.down);
            }
        }
    }

    [Command]
    void CmdFire(FireDirection direction)
    {
        GameObject bullet = null;

        if (direction == FireDirection.up)
        {
            bullet = Instantiate(bulletPrefab, spawnPointW.transform.position, Quaternion.identity);

            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * 10f;
        }
        else if(direction == FireDirection.down)
        {
            bullet = Instantiate(bulletPrefab, spawnPointS.transform.position, Quaternion.identity);

            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * -10f;
        }
        else if(direction == FireDirection.left)
        {
            bullet = Instantiate(bulletPrefab, spawnPointA.transform.position, Quaternion.identity);

            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * -10f;
        }
        else if(direction == FireDirection.right)
        {
            bullet = Instantiate(bulletPrefab, spawnPointD.transform.position, Quaternion.identity);

            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * 10f;
        }

        NetworkServer.Spawn(bullet);
    }

    void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");

            float moveVertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);

            rb2d.AddForce(movement * speed);
        }
    }
}
