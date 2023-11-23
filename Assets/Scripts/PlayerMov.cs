using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEditor.ShaderKeywordFilter;

public class PlayerControls : MonoBehaviour
{

    
    Vector3 MovDir;
    Vector3 RotDir;
    public float RotSpeed;
    public float speed;
    Rigidbody rb;
    [SerializeField] private WeaponBase myWeapon;
    private bool weaponShotToggle;
    Rigidbody rb2;
    public GameObject player;
    public static bool shotgun;

    [SerializeField] private EPlayerMovementState currentState;
    public enum EPlayerMovementState
    {
        Idle,
        Moving,
        Jumping
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InputManager.Init(this);
        InputManager.EnableInGame();
        setState(EPlayerMovementState.Idle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Movement();
        rotate();
      
        

    }


    public void setState(EPlayerMovementState newState)
    {
        currentState = newState;
    }
    public void Movement()
    {
        rb.AddForce(MovDir * speed);   
    }

    public void SetMovDir(Vector3 movDir)
    {
        MovDir = movDir;
    }

    public void SetJump()
    {
        rb.AddForce(Vector3.up * 250);
    }

    public void rotate()
    {
        
        player.transform.Rotate(RotDir * RotSpeed);
    }
  
    

    public void Shoot()
    {
        print("I shot: " + InputManager.GetCameraRay());
        weaponShotToggle = !weaponShotToggle;
        if (weaponShotToggle) myWeapon.StartShooting();
        else myWeapon.StopShooting();

    }

    public void SetRotDir(Vector3 rotDir)
    {
        RotDir = rotDir;
    }

    public void switchWeapon()
    {
        shotgun = !shotgun;
    }
    
    public void reload()
    {
        if (ProjectileWeapon.reserveAmmo > 0)
        {
            for(int i = 0; ProjectileWeapon.clipAmmo < 15; i++)
        {

                if (ProjectileWeapon.reserveAmmo < 1)
                {
                    break;
                }
            ProjectileWeapon.clipAmmo++;
            ProjectileWeapon.reserveAmmo--;
            

        }
        }
        
    }
}
