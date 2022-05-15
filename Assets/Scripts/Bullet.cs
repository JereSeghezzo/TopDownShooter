using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
      Destroy(gameObject, 4f);   
    }

 void OnCollisionEnter2D(Collision2D col)
 {
     Destroy(gameObject);
 }
}
