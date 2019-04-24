using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class CameraFollow : MonoBehaviour
{
    private Transform _target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    private void FixedUpdate()
    {
        if (_target == null)
        {
            List<GameObject> allPlayers = GameObject.FindGameObjectsWithTag("Player").ToList();
            foreach (var player in allPlayers)
            {
                if (player.GetComponent<PlayerManager>().isLocalPlayer)
                    _target = player.transform;
            }
        }

        if (_target != null)
        {
            Vector3 desiredPosition = _target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}