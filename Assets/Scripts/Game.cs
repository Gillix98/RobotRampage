using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private static Game singleton;

    [SerializeField]
    RobotSpawn[] spawns;

    public GameUI gameUI;
    public GameObject player;
    public int score;
    public int WaveCountdown;
    public bool isGameOver;
    public int enemiesLeft;

    // Start is called before the first frame update
    void Start()
    {
        singleton = this;
        StartCoroutine("increaseScoreEachSecond");
        isGameOver = false;
        Time.timeScale = 1;
        WaveCountdown = 30;
        enemiesLeft = 0;
        StartCoroutine("updateWaveTimer");
        spawnRobots();
    }

    private void spawnRobots()
    {
        foreach (RobotSpawn spawn in spawns)
        {
            spawn.SpawnRobot();
            enemiesLeft++;
        }
        gameUI.SetEnemyText(enemiesLeft);
    }

    private IEnumerator updatedWaveTimer()
    {
        while(!isGameOver)
        {
            yield return new WaitForSeconds(1f);
            WaveCountdown--;
            gameUI.SetWaveText(WaveCountdown);

            if (WaveCountdown == 0)
            {
                spawnRobots();
                WaveCountdown = 30;
                gameUI.ShowNewWave();
            }
        }
    }

    public static void RemoveEnemy()
    {
        singleton.enemiesLeft--;
        singleton.gameUI.SetEnemyText(singleton.enemiesLeft);

        if (singleton.enemiesLeft == 0)
            {
            singleton.score += 50;
            singleton.gameUI.ShowWaveClearBonus();
        }
    }

    public void AddRobotKillToScore()
    {
        score += 10;
        gameUI.SetScoreText(score);
    }

    IEnumerator increaseScoreEachSecond()
    {
        while(!isGameOver)
        {
            yield return new WaitForSeconds(1);
            score += 1;
            gameUI.SetScoreText(score);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
