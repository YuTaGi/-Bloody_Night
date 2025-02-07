using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        if (gameObject.CompareTag("Play"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

        public void QuitGame()
    {
        if (gameObject.CompareTag("Exit"))
        {
            Application.Quit();
        }
    }
        public void BackToMenu()
    {
        if (gameObject.CompareTag("BackToMenu"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
    public void StartGame1()
    {
        if (gameObject.CompareTag("Plays"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
    public void BackToMenu1()
    {
        if (gameObject.CompareTag("BackToMenu1"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
    }    

}
