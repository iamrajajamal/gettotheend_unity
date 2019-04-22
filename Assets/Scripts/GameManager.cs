using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Vector2 playerInitialPostion;
    private GameObject[] enemies;
    private GameObject player;
    private void Awake()
    {
        if (instance == null)
            instance = this;

        Time.timeScale = 1f;
    }

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void PlayerReachedGoal()
    {
        player.transform.position = playerInitialPostion;
        player.GetComponent<PlayerScript>().moveSpeed += 0.3f;

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyScript>().moveSpeed += 1f;
        }
    }

    public void PlayerDied()
    {
        Time.timeScale = 0f;
        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
