using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    { 
      Destroy(gameObject, 2f);   
    }

 void OnTriggerEnter2D(Collider2D col)
 {
   if(col.gameObject.CompareTag("Player"))
   {
     col.gameObject.GetComponent<PlayerMovement>().Hit();
     Destroy(gameObject);
   }

   if(col.gameObject.CompareTag("Enemy"))
   {
     col.gameObject.GetComponent<Enemy>().Hit();
     Destroy(gameObject);
   }
 }
}
