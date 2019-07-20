using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_dealer : MonoBehaviour
{
    public float dHealth = 20f;
    public float dDamage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        if(dHealth <= 10)
        {
            Destroy(gameObject);
        }
        else
        {
            dHealth -= dDamage;
        }
    }
}
