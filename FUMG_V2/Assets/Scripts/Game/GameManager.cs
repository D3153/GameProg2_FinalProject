using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text PlayerObjectiveText;
    public Text EnemyObjectiveText;    

    public GameObject objective;

    public Transform[] spawnPoints;
    public Transform spawnPoint;

    public static GameManager Instance { get; private set; }

    public float playerPoints;
    public float enemyPoints;
    float pointIncreasedPerSec = 2.0f;
    
    public Slider playerSlider;
    public Slider enemySlider;
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
        SpawnObjective();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerObjectiveText.text = "Player Objective Progress :" + ((int)playerPoints).ToString();
        playerSlider.value = playerPoints;
        EnemyObjectiveText.text = "Enemy Objective Progress :" + ((int)enemyPoints).ToString();
        enemySlider.value = enemyPoints;        
    }

    public void IncreasePlayerScore()
    {
        // playerPoints += pointsPerSec;
        playerPoints += pointIncreasedPerSec * Time.fixedDeltaTime;
        if(playerPoints >= 100){
            Debug.Log("Player Wins");
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(4);
        }
    }

    public void IncreaseEnemyScore()
    {
        // enemyPoints += pointsPerSec;
        enemyPoints += pointIncreasedPerSec * Time.fixedDeltaTime;
        if(enemyPoints >= 100){
            Debug.Log("Enemy Wins");
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(4);
        }
    }

    public Transform GetRandomSpawnPoint()
    {
        int index = Random.Range(0, spawnPoints.Length);
        return spawnPoints[index];
    }

    public void SpawnObjective()
    {
        spawnPoint = GetRandomSpawnPoint();
        Debug.Log(spawnPoint);
        Instantiate(objective, spawnPoint.position, spawnPoint.rotation);
    }

}
