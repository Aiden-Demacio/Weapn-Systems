using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [field: SerializeField] public float Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    private Animator myAnimator;
    

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void Die()
    {
        Rigidbody[] myRbs = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in myRbs)
        {

            rb.isKinematic = false;
        }

        myAnimator.enabled = false;
    }


}
