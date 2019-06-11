using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStats : MonoBehaviour
{
    public float health = 5;

    public bool readyToDie = false;

    public bool large = false;

    private SpriteRenderer spr_renderer;


    // Start is called before the first frame update
    void Start()
    {
        spr_renderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    public void Damage(float damage)
    {
        if (health > damage) 
        {
            health -= damage;
        }
        else 
        {
            readyToDie = true;
            EnemyMovementController emc = GetComponent<EnemyMovementController>();
            BigEnemyMovement bem = GetComponent<BigEnemyMovement>();
            if (emc) emc.enabled = false;
            if (bem) bem.enabled = false;
            StartCoroutine("Fade");
        }
    }

    IEnumerator Fade()
    {
        for (float t = 0; t < 150; t++)
        {
            //Debug.Log("Changing" + renderer.color + " to " + Color.Lerp(renderer.color, Color.gray, .01f));
            spr_renderer.color = Color.Lerp(spr_renderer.color, Color.gray, .025f);
            yield return null;
        }
    }


}
