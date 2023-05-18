using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneScript : MonoBehaviour
{
    public Text displayText;

    // Start is called before the first frame update
    void Start()
    {
        EndMessage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EndMessage()
    {
        if(GameManager.Instance.playerPoints >= 100){
            displayText.text = "You won";
        }

        if(GameManager.Instance.enemyPoints >= 100){
            displayText.text = "You lost";
        }
    }
}
