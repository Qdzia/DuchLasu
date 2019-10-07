using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        transform.gameObject.SetActive(false);
        SceneManager.LoadScene("Level01");
    }

}
