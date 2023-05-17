using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button tutorial = GetComponent<Button>();
        tutorial.onClick.AddListener(TutorialLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TutorialLevel()
    {
        SceneManager.LoadScene(1);
        // GameManager.Instance.score = 0;
    }
}
