using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerEating : MonoBehaviour
{
    public float maxScale;
    public float minScale;

    public float damage = 1;

    public float scaleIncreaseDelta;
    public float scaleDecreasePerSec;

    private float currScale;
    private ParticleSystem.MainModule body;
    private Color initalColor;

    private float timer;
    private GameObject digesting = null;

    private void Awake()
    {
        body = GetComponent<ParticleSystem>().main;
    }

    void Start()
    {
        initalColor = body.startColor.color;

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
        
        body.startColor = Color.Lerp(body.startColor.color, initalColor, Time.deltaTime);
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

            if (target.readyToDie)
            {
                if (!target.large)
                { 
                    if (!digesting)
                    {
                        digesting = Instantiate(Resources.Load("GenericCell"), transform) as GameObject;
                        digesting.GetComponentInChildren<SpriteRenderer>().color = target.GetComponentInChildren<SpriteRenderer>().color - new Color(0, 0, 0, .5f);
                        digesting.transform.localPosition = Vector3.up * 2;
                        Eat();
                        Destroy(col.transform.gameObject);
                        PlayerStats.player.Heal(1);
                    }
                }
                else
                {
                    target.GetComponent<BigEnemyMovement>().respawn();
                    Instantiate(Resources.Load("Chunks"), target.transform.position, Quaternion.identity);
                    Destroy(col.transform.gameObject);
                }
            }
            else
            {
                if (!target.large)
                {
                    GetComponent<PlayerMovement>().Stun();
                    Destroy(col.transform.gameObject);
                    GameObject chunks = Instantiate<GameObject>(Resources.Load("Chunks") as GameObject, target.transform.position, Quaternion.identity);
                    chunks.transform.localScale /= 2;
                    ParticleSystem.MainModule setting = chunks.GetComponent<ParticleSystem>().main;
                    setting.startColor = Color.yellow;
                    body.startColor = Color.yellow;
                    PlayerStats.player.Damage(damage);
                }
            }
        }
    }
}
