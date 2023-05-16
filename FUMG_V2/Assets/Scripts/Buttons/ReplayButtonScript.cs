using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReplayButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button start = GetComponent<Button>();
        start.onClick.AddListener(ReplayGame);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(0);
        // GameManager.Instance.playerScore = 0;
    }
}
