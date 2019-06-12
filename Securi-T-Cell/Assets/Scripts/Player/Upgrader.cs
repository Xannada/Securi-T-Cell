using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrader : MonoBehaviour
{
    public List<string> traits;

    private List<string> stats;

    public int upgradeInterval = 3;

    private int upgradeIndex = 0;


    void Awake()
    {
        stats = new List<string>();
        stats.Add("Health");
        stats.Add("Speed");
        stats.Add("FireRate");
    }

    public void GainUpgradePoint()
    {
        upgradeIndex++;

        if (upgradeIndex % upgradeInterval == 0)
        {
            List<string> upgrades = GetTwoTraits();
            if (upgrades != null)
                Upgrade(upgrades);
        }
    }

    private void Upgrade(List<string> upgrades)
    {

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

        return result;
    }

}