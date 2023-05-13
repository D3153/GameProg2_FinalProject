using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float playerPoints;
    float enemyPoints;
    float playerExp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WinLose(){
        if(playerPoints == 100){
            playerExp += 100;
        }
        else if(enemyPoints == 100){
            playerExp += 50;
        }
    }
}
