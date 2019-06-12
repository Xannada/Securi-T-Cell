using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private float vaccinatedTimer = 60;
    [SerializeField] private float unvaccinatedTimer = 600;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject info;
    [SerializeField] private GameObject difficulty;


    public void startGame(bool vaccinated)
    {
        EndScreen.timer = vaccinated ? vaccinatedTimer : unvaccinatedTimer;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Update()
    {
        if (menu && info && difficulty)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                info.SetActive(false);
                difficulty.SetActive(false);
                menu.SetActive(true);
            }
        }
    }
}
