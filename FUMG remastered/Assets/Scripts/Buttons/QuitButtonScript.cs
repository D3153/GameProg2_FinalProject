using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button quit = GetComponent<Button>();
        quit.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
