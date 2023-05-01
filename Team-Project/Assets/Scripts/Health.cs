using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float MaxHealth;
    [SerializeField] private float CurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float Amount)
    {
        CurrentHealth -= Amount;

        if(CurrentHealth <= 0)
        {
            Debug.Log("The player died.");
            CurrentHealth = 0;
        }
    }
}