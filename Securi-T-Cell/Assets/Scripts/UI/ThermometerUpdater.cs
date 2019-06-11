using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ThermometerUpdater : MonoBehaviour
{
    //public Vector2 heightRange, yPosRange;
    public GameObject bar;
    public int delayedUpdateAmount;//runs update once every n frames whre this is n
    
    private GameObject EnemyParent;
    private Image Fill;
    // Start is called before the first frame update
    void Start()
    {
        EnemyParent = GameObject.Find("Enemies");
        Fill = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % delayedUpdateAmount != 0) return;//do nothing and exit if not yet time to update.
        float percentToEnd = EnemyParent.transform.childCount / 100f;
        bar.GetComponent<RectTransform>().sizeDelta = new Vector2(20, percentToEnd * 200f);

        /*Fill.rectTransform.position = 
            new Vector3(
                Fill.rectTransform.position.x,
                Mathf.Lerp(yPosRange[0], yPosRange[1], percentToEnd),
                Fill.rectTransform.position.z
                );
        Fill.rectTransform.sizeDelta =
            new Vector2(
                Fill.rectTransform.sizeDelta.x,
                Mathf.Lerp(heightRange[0], heightRange[1], percentToEnd)
                );*/
    }
}
