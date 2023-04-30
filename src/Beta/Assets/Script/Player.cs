using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    //Player
    [SerializeField] public string playerName;
    [SerializeField] public float playerXP;

    //Tank characteristics
    [SerializeField] private float _maxHp;
    [SerializeField] public float hp;
    [SerializeField] public float bodyDamage;
    [SerializeField] public float bulletDamage;

    //BodyDamage
    //--

    //Shot
    [SerializeField] public GameObject bullet;
    [SerializeField] public Transform point;
    [SerializeField] public float reloadTime;
    public float time;
    [SerializeField] public float bulletSpeed;


    //Movement
    [SerializeField] public float Speed;


    //Rotation
    [SerializeField] public float TowerRotation;
    void Start()
    {
    }
    void Update()
    {
        if (!isLocalPlayer) return;
            CmdShot();
            TowerRotate();
            Movement();
    }
    [Command]void CmdShot()
    {
        RpcBulletSpawn();
    }

    [ClientRpc]private void RpcBulletSpawn()
    {
        if (!isLocalPlayer) return;
        if (time <= 0f)
        {
            if (Input.GetMouseButton(0))
            {
                GameObject bulletPrefab = Instantiate(bullet, point.position, transform.rotation);
                NetworkServer.Spawn(bulletPrefab);
                time = reloadTime;
            }
        }
        else
        {
            time -= Time.deltaTime;
        }
    }

    void TowerRotate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + TowerRotation);
    }

    void Movement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        gameObject.transform.position = new Vector2(transform.position.x + (h * Speed * Time.deltaTime),
           transform.position.y + (v * Speed * Time.deltaTime));
    }
}
