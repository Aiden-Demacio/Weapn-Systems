using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ProjectileWeapon : WeaponBase
{

    [SerializeField] private Rigidbody myBullet;
    [SerializeField] private Rigidbody myBullet2;
    [SerializeField] private float force = 50;
    public static float reserveAmmo = 30;
    public static float clipAmmo = 15;
    [SerializeField] public WeaponBase myWeapon;
    private bool weaponShootToggle;
    public bool Shotgun;
    [SerializeField] private TextMeshProUGUI clipAmmoText;
    [SerializeField] private TextMeshProUGUI reserveAmmoText;

    private void Start()
    {
        clipAmmoText.text = clipAmmo.ToString();
        reserveAmmoText.text = reserveAmmo.ToString();
    }
    private void Update()
    {
        Shotgun = PlayerControls.shotgun;
        clipAmmoText.text = clipAmmo.ToString();
        reserveAmmoText.text = reserveAmmo.ToString();
    }
    protected override void Attack(float percent)
    {
        print("My weapon attacked" + percent);
        Ray camRay = InputManager.GetCameraRay();
        if(Shotgun && clipAmmo >= 5)
        {
            for(int i = 0; i < 5; i++)
            {
                Rigidbody shotgunRb = Instantiate(percent > 0.5f ? myBullet2 : myBullet, camRay.origin, transform.rotation);
                shotgunRb.AddForce(Mathf.Max(percent, 0.1f) * force * camRay.direction, ForceMode.Impulse);
                clipAmmo--;
            }
            
        }
        else if(clipAmmo > 0)
        {
            Rigidbody rb = Instantiate(percent>0.5f?myBullet2:myBullet, camRay.origin, transform.rotation);
            rb.AddForce(Mathf.Max(percent, 0.1f) * force * camRay.direction, ForceMode.Impulse);
            clipAmmo--;
            
        }
        
        
    }


}
