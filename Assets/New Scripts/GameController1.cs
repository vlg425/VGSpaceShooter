using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController1 : MonoBehaviour {

    public GameObject asteroid;
    public GameObject powerUp;
    public float spawnInterval;
    public Vector3 spawnValues;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;
    // Start is called before the first frame update
    void Start() {

        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnPowerUp());
    }

    // Update is called once per frame
    void Update() {
        if (restart) {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator SpawnPowerUp() {
        yield return new WaitForSeconds(spawnInterval * 7); //spawn interval 1.0 seconds
        while (true) {

            Vector3 spawnPositionPower = new Vector3
            (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Instantiate(powerUp, spawnPositionPower, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval * 7);

            if (gameOver) {
                
                break;
            }


        }
    }
    IEnumerator SpawnWaves() {

        yield return new WaitForSeconds(spawnInterval); //spawn interval 1.0 seconds
        while (true) {

            Vector3 spawnPosition = new Vector3
            (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Instantiate(asteroid, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);

            if (gameOver) {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }
    public void AddScore(int newScoreValue) {
        score += newScoreValue;
        UpdateScore();
    }

 

    void UpdateScore() {
        scoreText.text = "Score: " + score;
    }

    public void GameOver() {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
                 