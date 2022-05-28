using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public int Health;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;

    public Slider slider;
    private GameManager gameManager;
    public SpriteRenderer spriteRender;

    void Start()
    {
     rb = GetComponent<Rigidbody2D>(); 
     gameManager = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<GameManager>();  
    }

    void Update()
    {

      slider.value = Health;
      movement.x = Input.GetAxisRaw("Horizontal");   
      movement.y = Input.GetAxisRaw("Vertical");  

      mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
      rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

      Vector2 lookDir= mousePos - rb.position;
      float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90;
      rb.rotation = angle;
    }

     public void Hit()
 {
     Health -= 1;
     if( Health <= 0)
     {
       spriteRender.enabled = false;
       gameManager.Lose();
     }
 }
}
