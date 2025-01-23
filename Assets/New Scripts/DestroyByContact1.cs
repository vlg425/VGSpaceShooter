using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact1 : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController1 gameController1;

    void Start() {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController1");
        if (gameControllerObject != null) {
            gameController1 = gameControllerObject.GetComponent<GameController1>();
            
        }
        if (gameController1 == null) {
            Debug.Log("Cannot find 'GameController1' script");
            
            
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Boundary1" || other.tag == "Enemy") {
            return;
        }

        if (explosion != null) {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player1") {
            gameController1.GameOver();
            Instantiate(playerExplosion, transform.position, transform.rotation);
        }

        gameController1.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
