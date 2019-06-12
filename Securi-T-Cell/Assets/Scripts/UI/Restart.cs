using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenURL()
    {
        Application.OpenURL("https://www.vaccines.gov/basics");
    }
}
