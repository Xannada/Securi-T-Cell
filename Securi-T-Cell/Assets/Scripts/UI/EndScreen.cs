using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public int delayedUpdateAmount;//runs update once every n frames whre this is n
    public int lossCount, winCount;
    private GameObject BasePanel;
    private GameObject WinParent, LossParent;
    private GameObject BacCount;
    public static float timer = 500;

    void Start()
    {
        BacCount = GameObject.Find("Enemies");
        BasePanel = transform.GetChild(0).gameObject;
        WinParent = BasePanel.transform.GetChild(0).GetChild(0).gameObject;
        LossParent = BasePanel.transform.GetChild(0).GetChild(1).gameObject;
    }

    void Update()
    {
        if (Time.deltaTime > timer) timer = 0;
        else timer -= Time.deltaTime;
        if (Time.frameCount % delayedUpdateAmount != 0) return;//do nothing and exit if not yet time to update.
        if(BacCount.transform.childCount >= lossCount)
        {
            BasePanel.SetActive(true);
            LossParent.SetActive(true);
        }else if(timer == 0 || BacCount.transform.childCount <= winCount)
        {
            BasePanel.SetActive(true);
            WinParent.SetActive(true);
        }
    }
}
