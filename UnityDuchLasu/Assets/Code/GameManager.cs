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
            Invoke("Restart",2f);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        UILevelCom.SetActive(false);
    }

    public void LevelCompleted()
    {
        if (!gameHasEnded)
        {
            Debug.Log("Level Completed");
            gameHasEnded = true;
            UILevelCom.SetActive(true);
            Invoke("Restart", 4f);
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
