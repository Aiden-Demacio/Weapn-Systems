using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Impulse);
        Destroy(gameObject, 5);
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.transform.root.TryGetComponent(out IDamagable hitObject))
        {
            float currentDamage = 50;
            switch (other.transform.tag)
            {
                case "Head":
                    currentDamage *= 2;
                    break;
                case "body":
                    currentDamage = 50;
                    break;
                case "Limbs":
                    currentDamage *= 2; 
                    break;


            }




            hitObject.TakeDamage(100);
        }
    }
}
