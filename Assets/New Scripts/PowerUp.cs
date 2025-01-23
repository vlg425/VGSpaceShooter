using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    public GameObject explosion;
    private PlayerController1 playerController1;

    void Start() {
        GameObject playerControllerObject = GameObject.FindGameObjectWithTag("Player1");
        if (playerControllerObject != null) {
            playerController1 = playerControllerObject.GetComponent<PlayerController1>();
            Debug.Log(playerController1);
        }
        if (playerController1 == null) {
            Debug.Log("Cannot find 'GameController1' script");
            Debug.Log(playerControllerObject);  

        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag != "Player1") {
            return;
        }

        if (other.tag == "Player1") {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        playerController1.PowerUp();
        Destroy(gameObject);
    }
}

