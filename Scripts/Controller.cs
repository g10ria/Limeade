using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
   Rigidbody2D rb;

   public float horizontalMultiplier = 8f;
   public float jumpSpeed = 17f;
   public float fallMultipler = 6f;
   public float lowJumpMultipler = 4f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   void FixedUpdate()
   {
      float moveInput = Input.GetAxis("Horizontal");

      rb.velocity = new Vector3(moveInput * horizontalMultiplier, rb.velocity.y, 0f);

      if (Input.GetKeyDown(KeyCode.UpArrow))    // jump
      {
         rb.velocity = Vector3.up * jumpSpeed;

      } else if (Input.GetKeyDown(KeyCode.DownArrow))    // roll
      {
         rb.velocity = Vector3.down *jumpSpeed;
      }

   }

   private void LateUpdate()
   {

      if (rb.velocity.y < 0)
      {
         rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultipler - 1) * Time.deltaTime;
      }
      else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
      { // increases fall speed when going up
         rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultipler - 1) * Time.deltaTime;
      }

   }
}
