using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    private float shootDelay;
    public float ShootingSpeed;
    public GameObject BulletReadyText;

    public Slider slider;

    void Update()
    {

     slider.value = shootDelay;

     if(shootDelay < ShootingSpeed)
     {
         shootDelay += Time.deltaTime;
        BulletReadyText.SetActive(false);
     } else {
          BulletReadyText.SetActive(true);
     }

     

      if(Input.GetButtonDown("Fire1") && shootDelay >= ShootingSpeed) 
      {
          Shoot();
          shootDelay = 0f;
      }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
