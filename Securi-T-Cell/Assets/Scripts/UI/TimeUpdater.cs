using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TimeUpdater : MonoBehaviour
{
    public int delayedUpdateAmount;//runs update once every n frames whre this is n

    private Text counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % delayedUpdateAmount != 0) return;//do nothing and exit if not yet time to update.
        counter.text = "" + (int) EndScreen.timer;
    }
}
