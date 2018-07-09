using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Enemy
{
    [Header("Boss-specific Data")]

    [SerializeField]
    new string name;

    [SerializeField]
    Image healthBar;

    [SerializeField]
    Canvas canvas;

    public float maxHealth;         //variable is required to scale its health bar, unlike common enemies

    float fadeSpeed = 0.01f;

    void Awake()
    {
        GetComponent<Collider2D>().enabled = false;
        maxHealth = health;
    }

    protected override void Start()
    {
        base.Start();
        EnterScene();
    }

    protected override void Update()
    {
        UpdateState();
        if (GetComponent<SpriteRenderer>().material.color.a == 1)
        {
            LookAt();
            Shoot(10);
        }
    }

    void EnterScene()
    {
        Instantiate(healthBar, canvas.transform);
        StartCoroutine(MoveIn());
        StartCoroutine(FadeIn(fadeSpeed));
    }

    void UpdateState()
    {
        if (health <= 0)
        {
           StartCoroutine(FadeOut(fadeSpeed));
        }
    }

    IEnumerator MoveIn()
    {
        while (transform.position.y > 3)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 2);
            yield return null;
        }
    }

    //sets alpha from 0 - 1
    public IEnumerator FadeIn(float fadeSpeed)
    {
        for (float alpha = 0f; alpha <= 1f; alpha += fadeSpeed)
        {
            alpha = Mathf.Round(alpha * 100) / 100;
            Color c = new Color(1, 1, 1, alpha);
            GetComponent<SpriteRenderer>().material.color = c;
            yield return null;
        }
        GetComponent<Collider2D>().enabled = true;
    }

    //sets alpha from 1 - 0
    IEnumerator FadeOut(float fadeSpeed)
    {
        GetComponent<Collider2D>().enabled = false;
        for (float alpha = 1f; alpha >= 0f; alpha -= fadeSpeed)
        {
            alpha = Mathf.Round(alpha * 100) / 100;
            Color c = new Color(1, 1, 1, alpha);
            GetComponent<SpriteRenderer>().material.color = c;
            yield return null;
        }
        Destroy(gameObject);
    }
}
