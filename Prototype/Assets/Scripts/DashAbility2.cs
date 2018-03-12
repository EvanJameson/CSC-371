using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility2 : MonoBehaviour {
     
     public DashState dashState;
     public float dashTimer;
     public float maxDash = 20f;
 
     public Vector2 savedVelocity;
     
     void Update () 
     {
         switch (dashState) 
         {
         case DashState.Ready:
             var isDashKeyDown = Input.GetKeyDown (KeyCode.LeftShift);
             if(isDashKeyDown)
             {
                 savedVelocity = rigidbody.velocity;
                 Rigidbody2D.velocity =  new Vector2(Rigidbody2D.velocity.x * 3f, Rigidbody2D.velocity.y);
                 dashState = DashState.Dashing;
             }
             break;
         case DashState.Dashing:
             dashTimer += Time.deltaTime * 3;
             if(dashTimer >= maxDash)
             {
                 dashTimer = maxDash;
                 Rigidbody2D.velocity = savedVelocity;
                 dashState = DashState.Cooldown;
             }
             break;
         case DashState.Cooldown:
             dashTimer -= Time.deltaTime;
             if(dashTimer <= 0)
             {
                 dashTimer = 0;
                 dashState = DashState.Ready;
             }
             break;
         }
     }
 }
 
 public enum DashState 
 {
     Ready,
     Dashing,
     Cooldown
 }
