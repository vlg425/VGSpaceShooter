using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[System.Serializable]
public class Boundary1 { 
    public float xMin, xMax, zMin, zMax; 
}
public class PlayerController1 : MonoBehaviour
{

    public float speed;
    public Boundary1 boundary1;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;

    public float powerUpDuration;
    private float powerUpTimer;
    public float powerUpFireRate;


    private void Update() {
        if (Input.GetButton("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
           GetComponent<AudioSource>().Play();
        }
        if (powerUpTimer > 0) {
            powerUpTimer -= Time.deltaTime;
        } else {
            fireRate = 0.25f;
        }
    }

    void FixedUpdate() 
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary1.xMin, boundary1.xMax),
            0,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary1.zMin, boundary1.zMax)
            );
    }

    public void PowerUp() {
        powerUpTimer = powerUpDuration;
        fireRate -= powerUpFireRate;

    }
}
