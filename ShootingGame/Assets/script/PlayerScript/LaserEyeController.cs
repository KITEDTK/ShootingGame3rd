using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEyeController : MonoBehaviour
{
    [SerializeField]
    private float damage = 10f;



    public float range = 500f;

    public Camera fpsCam;

    private float nextTimeToFire = 0f;
    public float fireRate = 15f;

    public Transform eye;

    public GameObject Laser;
   
    public Transform Asuna;

    [SerializeField]
    private Vector3 gunOffset;

    
    private Vector3 gunRotation;

    public AudioSource gun;
    public AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        gunRotation = fpsCam.transform.eulerAngles + gunOffset;
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            GameObject currentLaser = Instantiate(Laser, this.transform.position, /*fpsCam.transform.rotation + new Vector3(0,0,0)*/Quaternion.Euler(gunRotation));
            Shoot();
        }
    }
    public void Shoot()
    {

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        { 
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            
            if (enemy != null)
            {
                enemy.takeDamage(damage);
            }
        }
        gun.PlayOneShot(sound);
    }
}
