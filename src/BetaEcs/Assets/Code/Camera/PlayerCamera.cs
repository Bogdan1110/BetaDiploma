using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerCamera : NetworkBehaviour
{
    [SerializeField] private Vector3 Target;
    [SerializeField] public float speed;
    [SerializeField] public Transform Player;

    private void Start()
    {
        Player = gameObject.transform;
    }

    void Update()
    {
        if (isLocalPlayer)
        {
            CameraMovementForPlayer();
        }
    }

    private void CameraMovementForPlayer()
    {
        Target = PlayerPositionWithFreezeZ();
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, Target, speed * Time.deltaTime);
    }

    private Vector3 PlayerPositionWithFreezeZ()
    {
        return new Vector3(transform.position.x, transform.position.y, -10);
    }
}