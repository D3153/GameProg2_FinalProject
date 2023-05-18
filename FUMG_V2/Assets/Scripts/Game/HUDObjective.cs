using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDObjective : MonoBehaviour
{
    public Text PlayerObjectiveText;
    public Text EnemyObjectiveText;
    public float playerPoints;
    public float enemyPoints;
    public GameObject playerObjective;
    public GameObject enemyObjective;
    float pointIncreasedPerSec = 2.0f;
    public Slider playerSlider;
    public Slider enemySlider;

    // Update is called once per frame
    void Update()
    {
        PlayerObjectiveText.text = "Player Objective Progress :";
        playerSlider.value = playerPoints;
        EnemyObjectiveText.text = "Enemy Objective Progress :" + enemyPoints;
        enemySlider.value = enemyPoints;
    }

    private void FixedUpdate() 
    {
        // points = pointIncreasedPerSec * Time.fixedDeltaTime;
        if(GameManager.Instance.playerPoints < 100){
            GameManager.Instance.IncreasePlayerScore();
        }
        Debug.Log(GameManager.Instance.playerPoints);
    }

    public void IncreasePlayerScore()
    {
        if(playerObjective = GameObject.FindWithTag("PlayerObjective"))
        // playerPoints += pointsPerSec;
        playerPoints += pointIncreasedPerSec * Time.fixedDeltaTime;
        if(playerPoints >= 100){
            Debug.Log("Player Wins");
        }
    }

    public void IncreaseEnemyScore()
    {
        if(enemyObjective = GameObject.FindWithTag("EnemyObjective"))
        // enemyPoints += pointsPerSec;
        enemyPoints += pointIncreasedPerSec * Time.fixedDeltaTime;
        
        if(enemyPoints >= 100){
            Debug.Log("Enemy Wins");
        }
    }
}
