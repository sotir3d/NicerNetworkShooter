using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{
    public float moveSpeed;
    public float bulletSpeed;

    public GameObject bulletPrefab;
    public GameObject spawnPointW;
    public GameObject spawnPointD;
    public GameObject spawnPointA;
    public GameObject spawnPointS;
    public GameObject spawnPointQ;
    public GameObject spawnPointE;
    public GameObject spawnPointC;
    public GameObject spawnPointY;

    private Rigidbody2D rb2d; 
    
    enum FireDirection
    {
        up,
        down,
        left,
        right,
        upright,
        upleft,
        downright,
        downleft
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
            else if( Input.GetKeyDown(KeyCode.E))
            {
                CmdFire(FireDirection.upright);
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                CmdFire(FireDirection.upleft);
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                CmdFire(FireDirection.downright);
            }
            else if (Input.GetKeyDown(KeyCode.Y))
            {
                CmdFire(FireDirection.downleft);
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

            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletSpeed * Time.deltaTime;
        }
        else if (direction == FireDirection.down)
        {
            bullet = Instantiate(bulletPrefab, spawnPointS.transform.position, Quaternion.identity);

            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * -bulletSpeed * Time.deltaTime;
        }
        else if (direction == FireDirection.left)
        {
            bullet = Instantiate(bulletPrefab, spawnPointA.transform.position, Quaternion.identity);

            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * -bulletSpeed * Time.deltaTime;
        }
        else if (direction == FireDirection.right)
        {
            bullet = Instantiate(bulletPrefab, spawnPointD.transform.position, Quaternion.identity);

            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletSpeed * Time.deltaTime;
        }
        else if (direction == FireDirection.upright)
        {
            bullet = Instantiate(bulletPrefab, spawnPointE.transform.position, Quaternion.identity);

            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1,1) * bulletSpeed * Time.deltaTime;
        }
        else if (direction == FireDirection.upleft)
        {
            bullet = Instantiate(bulletPrefab, spawnPointQ.transform.position, Quaternion.identity);

            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 1) * bulletSpeed * Time.deltaTime;
        }
        else if (direction == FireDirection.downright)
        {
            bullet = Instantiate(bulletPrefab, spawnPointC.transform.position, Quaternion.identity);

            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1, -1) * bulletSpeed * Time.deltaTime;
        }
        else if (direction == FireDirection.downleft)
        {
            bullet = Instantiate(bulletPrefab, spawnPointY.transform.position, Quaternion.identity);

            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, -1) * bulletSpeed * Time.deltaTime;
        }

        NetworkServer.Spawn(bullet);
    }

    void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            //float moveHorizontal = Input.GetAxis("Horizontal");

            //float moveVertical = Input.GetAxis("Vertical");

            //Vector2 movement = new Vector2(moveHorizontal, moveVertical);

            //rb2d.AddForce(movement * speed);
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            //Vector3 movement = new Vector3(horizontal, vertical, 0f);

            //transform.position += movement * Time.deltaTime * moveSpeed;

            rb2d.velocity = new Vector2(horizontal, vertical) * Time.fixedDeltaTime * moveSpeed;
        }
    }
}
