using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HealthUpdater : MonoBehaviour
{
    public int delayedUpdateAmount;//runs update once every n frames whre this is n
    public GameObject bar;
    private RectTransform rt;
    
    private Text counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = GetComponent<Text>();
        rt = bar.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % delayedUpdateAmount != 0) return;//do nothing and exit if not yet time to update.
        counter.text = "" + PlayerStats.player.health;
        rt.sizeDelta = new Vector2((PlayerStats.player.health / 10f)* 200f, 40);
    }
}
