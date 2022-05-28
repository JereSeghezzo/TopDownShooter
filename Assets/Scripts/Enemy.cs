using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 public int Health;
 public float speed;
 public float stoppingDistance;
 public float retreatDistance;
 public float FollowDistance;

 private float shootDelay;
 public float ShootingSpeed;

 public Transform firePoint;
 public GameObject bulletPrefab;
 public float bulletForce = 20f;

 public Transform player;

 private Rigidbody2D rb;

 private GameManager gameManager;

 void Start() 
 {
   gameManager = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameManager>();  
   rb = this.GetComponent<Rigidbody2D>(); 
   player = GameObject.FindGameObjectWithTag("Player").transform;  
 }

 void Update()
 {
     if(shootDelay < ShootingSpeed)
     {
         shootDelay += Time.deltaTime;
     }

    Vector3 direction = player.position - transform.position;
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    rb.rotation = angle+90;

    if(Vector2.Distance(transform.position, player.position) < FollowDistance)
 {
   if(Vector2.Distance(transform.position, player.position) > stoppingDistance) 
   {
       transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
   } else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
   {
       transform.position = this.transform.position;
       if(shootDelay >= ShootingSpeed)
       {
        Shoot();
        shootDelay = 0f;
       }
   } else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
   {
       transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
   }
 }

 }

 void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rbullet = bullet.GetComponent<Rigidbody2D>();
        rbullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

 public void Hit()
 {
     Health -= 1;
     if( Health <= 0)
     {
       gameManager.Kill();  
       Destroy(gameObject);
     }
 }
}
