using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject UILevelCom;
    public void EndOfGame()
    {
        if (!gameHasEnded)
        {
            Debug.Log("Game Over");
            gameHasEnded = true;
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        UILevelCom.SetActive(false);
    }

    public void LevelCompleted()
    {
        if (!gameHasEnded)
        {
            Debug.Log("Level Completed");
            gameHasEnded = true;
            UILevelCom.SetActive(true);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
