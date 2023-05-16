using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float playerPoints;
    public float enemyPoints;
    float pointIncreasedPerSec = 2.0f;
    // float playerExp;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        // goal = GetRandomGoalScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreasePlayerScore()
    {
        // playerPoints += pointsPerSec;
        playerPoints += pointIncreasedPerSec * Time.fixedDeltaTime;
        if(playerPoints >= 100){
            Debug.Log("Player Wins");
            SceneManager.LoadScene(4);
        }
    }

    public void IncreaseEnemyScore()
    {
        // enemyPoints += pointsPerSec;
        enemyPoints += pointIncreasedPerSec * Time.fixedDeltaTime;
        if(enemyPoints >= 100){
            Debug.Log("Enemy Wins");
            SceneManager.LoadScene(4);
        }
    }

    void WinLose(){
        if(playerPoints >= 50){
            // playerExp += 100;
            Debug.Log("Player Wins");
        }
        else if(enemyPoints == 100){
            // playerExp += 50;
        }
    }
}
