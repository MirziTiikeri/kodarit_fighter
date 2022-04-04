using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{


    public float Speed = 5f;
    public float JumpForce = 7.5f;

    private float HorizontalMovement = 0f;
    public int Facing = 1;

    public Rigidbody2D MyRigidbody2D; 
    public CircleCollider2D Feet;

    public Animator Animator;

    void Update()
    {
        HorizontalMovement = Input.GetAxis("Horizontal");
        bool IsHit = GetComponent<HealthScript>().IsHit;

        if (!IsHit) {
            if (Input.GetButtonDown("Jump") && 
            Feet.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
                MyRigidbody2D.AddForce(new Vector2(0f, JumpForce), 
                ForceMode2D.Impulse);
                Animator.SetTrigger("Jump");
            }
            if (Feet.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
                Animator.SetBool("IsTouchingGround", true);
            } else {
                Animator.SetBool("IsTouchingGround", false);
            }
        }
    }

    private void FixedUpdate() {
        bool IsHit = GetComponent<HealthScript>().IsHit;
        if (!IsHit) {
            MyRigidbody2D.velocity = new Vector2(HorizontalMovement * Speed,
                MyRigidbody2D.velocity.y);
            Animator.SetFloat("Speed", Mathf.Abs(HorizontalMovement));
        }
    }



}
