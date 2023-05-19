using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour

{
   // original code
  public float life = 3;
  public float Damage;
  public float KOTime;
  public float MaxSpeed;
  private float Speed;
 
  void Awake()
  {
   Destroy(gameObject, life);
  }
  //testing script
  void OnCollisionEnter(Collision collision)
  {
   if(collision.gameObject.CompareTag("Enemy"))
   {
    collision.collider.gameObject.GetComponent<Health>().TakeDamage(Damage);
   StartCoroutine(AttackDelay(KOTime));
   }
  }

  private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has a specific tag (e.g., "Player")
        if (other.CompareTag("Enemy"))
        {
            // Destroy the current GameObject
            Destroy(gameObject);
        }
    }
  IEnumerator AttackDelay(float Delay)
   {
       Speed = 0;
       yield return new WaitForSeconds(Delay);
       Speed = MaxSpeed;
   }
}

