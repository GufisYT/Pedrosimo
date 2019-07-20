using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using TMPro;


public class Pistol_Shooting : MonoBehaviour
{
    public TextMeshPro pAmmo_l;
    public GameObject pBullet;
    public Transform pBarrel;
    public readonly int pDamage = 10;
    public float pSpeed;

    private int pCurrentAmmo = 0;
    private readonly int pMagSize = 12;

   
    // Start is called before the first frame update
    void Start()
    {
        pCurrentAmmo = pMagSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        if (pCurrentAmmo > 0)
        {
            //The Bullet instantiation happens here.
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(pBullet, pBarrel.transform.position, pBarrel.transform.rotation) as GameObject;

            //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
            Temporary_RigidBody.AddForce(transform.forward * pSpeed);

            //Subtract bullets from magazine.
            pCurrentAmmo--;

            pAmmo_l.text = pCurrentAmmo.ToString();

            //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
            Destroy(Temporary_Bullet_Handler, 10.0f);
        }
        else
        {
            Debug.Log("No bullets left!");
        }
    }
   
   

}
