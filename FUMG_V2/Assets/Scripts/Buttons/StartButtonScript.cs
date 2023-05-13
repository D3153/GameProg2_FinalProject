using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button start = GetComponent<Button>();
        start.onClick.AddListener(PickCharacter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickCharacter()
    {
        SceneManager.LoadScene(2);
        // GameManager.Instance.score = 0;
    }
}
