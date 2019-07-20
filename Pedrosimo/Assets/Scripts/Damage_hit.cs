using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Damage_hit : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Enemy")
        {
            collisionInfo.gameObject.GetComponent<Damage_dealer>().TakeDamage();
            Destroy(gameObject);
        }

        if (collisionInfo.collider.enabled)
        {     
            Destroy(gameObject);
        }
    }

}
