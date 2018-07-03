using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [SerializeField]
    new string name;

    [SerializeField]
    GameObject healthBar;

    protected override void Start()
    {
        base.Start();
        EnterScene();
    }

    protected override void Update()
    {
        CheckState();

        if (GetComponent<SpriteRenderer>().material.color.a == 1)
        {
            LookAt();
            Shoot(10);
        }
    }

    void EnterScene()
    {
        float fadeSpeed = 0.01f;

        StartCoroutine(MoveIn());
        StartCoroutine(FadeIn(fadeSpeed));
    }

    //controls move in
    IEnumerator MoveIn()
    {
        while (transform.position.y > 3)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 2);
            yield return null;
        }
    }

    //controls fade in
    IEnumerator FadeIn(float fadeSpeed)
    {
        for (float alpha = 0f; alpha <= 1f; alpha += fadeSpeed)
        {
            alpha = Mathf.Round(alpha * 100) / 100;
            Color c = new Color(1, 1, 1, alpha);
            GetComponent<SpriteRenderer>().material.color = c;
            yield return null;
        }
    }
}
