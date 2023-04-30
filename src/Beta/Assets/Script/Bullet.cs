using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
//using UnityEditor.PackageManager;
using UnityEngine;
using Mirror;
using Mirror.Examples.MultipleMatch;

public class Bullet : NetworkBehaviour
{
    //Shot
    [SerializeField] public Player playerInfo;
    [SerializeField] public float distance;


    [SerializeField] public float deathTime;

    [SerializeField] public LayerMask layerMask;

    private void Start()
    {
    }

    void Update()
    {
         RaycastHit2D other = Physics2D.Raycast(transform.position, transform.right, distance, layerMask);
         //if (other.collider != null)
         //{
         //    if (other.collider.CompareTag("Item") == true)
         //    {
         //        other.collider.GetComponent<Item>().Damage(playerBulletDamage.bulletDamage);
         //        FlightTime(deathTime / 3);
         //    }
         //}
         BulletMovement(playerInfo.bulletSpeed);
         FlightTime();
    }

    private void BulletMovement(float bulletSpeed)
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    void FlightTime()
    {
        deathTime -= Time.deltaTime;
        if (deathTime <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
