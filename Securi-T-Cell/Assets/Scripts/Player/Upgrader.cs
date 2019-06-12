using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrader : MonoBehaviour
{
    public GameObject upgradeWindow;
    public Button leftButton;
    public Button rightButton;

    public PlayerStats playerStats;

    public List<string> traits;

    private List<string> stats;

    private List<string> upgrades;

    public int upgradeInterval = 3;

    private int upgradeIndex = 0;




    void Awake()
    {
        leftButton.onClick.AddListener(LeftButtonClicked);
        rightButton.onClick.AddListener(rightButtonClicked);
        /*stats = new List<string>();
        stats.Add("Health");
        stats.Add("Speed");
        stats.Add("FireRate");*/
    }

    public void Update()
    {
        if (upgradeWindow.activeSelf)
        {
            float input = Input.GetAxis("Selection");

            if (input == 1)
            {
                rightButtonClicked();
            }
            else if (input == -1)
            {
                LeftButtonClicked();
            }
        }
    }

    public void GainUpgradePoint()
    {
        upgradeIndex++;

        if (upgradeIndex % upgradeInterval == 0)
        {
            upgrades = GetTwoTraits();
            if (upgrades != null)
                Upgrade(upgrades);
        }
    }

    public void LeftButtonClicked()
    {
        playerStats.addTrait(upgrades[0]);
        traits.Remove(upgrades[0]);
        clearUI();
    }

    public void rightButtonClicked()
    {
        playerStats.addTrait(upgrades[1]);
        traits.Remove(upgrades[1]);
        clearUI();
    }

    private void clearUI()
    {
        upgradeWindow.SetActive(false);
        Time.timeScale = 1f;

        upgrades = null;
    }

    private void Upgrade(List<string> upgrades)
    {
        upgradeWindow.SetActive(true);
        Time.timeScale = 0f;

        leftButton.image.sprite = Resources.Load<Sprite>(upgrades[0]);
        rightButton.image.sprite = Resources.Load<Sprite>(upgrades[1]);
    }


    private List<string> GetTwoTraits()
    {
        if (traits.Count <= 1)
        {
            return null;
        }

        List<string> result = new List<string>();

        int random = Random.Range(0, traits.Count);

        result.Add(traits[random]);

        traits.RemoveAt(random);

        random = Random.Range(0, traits.Count);

        result.Add(traits[random]);

        traits.RemoveAt(random);

        traits.AddRange(result);

        return result;
    }

}