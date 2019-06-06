using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerEating : MonoBehaviour
{
    public float maxScale;
    public float minScale;

    public float scaleIncreaseDelta;
    public float scaleDecreasePerSec;

    private float currScale;

    private float timer;
    private GameObject digesting = null;

    void Start()
    {
        if (minScale == 0)
        {
            minScale = transform.transform.localScale.x;
        }
        if (maxScale < minScale)
        {
            maxScale = minScale * 2;
        }

        SetScale();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1f)
        {
            timer = 0;
            
            SetScale(currScale - scaleDecreasePerSec);
        }
    }

    void Eat()
    {
        SetScale(currScale + scaleIncreaseDelta);
    }

    void SetScale(float value = 0)
    {
        if (value <= minScale)
        {
            value = minScale;
            Destroy(digesting);
            digesting = null;
        }
        if (value > maxScale)
        {
            value = maxScale;
        }

        currScale = value;

        transform.localScale = new Vector3(value, 1, value);
        if (digesting && value != 0) digesting.transform.localScale = new Vector3(1 / value, 1, 1 / value);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag("Enemy"))
        {
            EnemyStats target = col.transform.GetComponent<EnemyStats>();

            if (!digesting && target.readyToDie)
            {
                if (!target.large)
                { 
                    
                    digesting = Instantiate(Resources.Load("GenericCell"), transform) as GameObject;
                    digesting.GetComponentInChildren<SpriteRenderer>().color = target.GetComponentInChildren<SpriteRenderer>().color - new Color(0, 0, 0, .5f);
                    digesting.transform.localPosition = Vector3.up * 2;
                    Eat();
                    Destroy(col.transform.gameObject);
                }
                else
                {
                    Instantiate(Resources.Load("Chunks"), target.transform.position, Quaternion.identity);
                    Destroy(col.transform.gameObject);
                }
            }
        }
    }
}
