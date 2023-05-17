using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToMainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button mainMenu = GetComponent<Button>();
        mainMenu.onClick.AddListener(GoToMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
        // GameManager.Instance.score = 0;
    }

}
