using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    Boss b;

    void Start()
    {
        b = GameObject.FindWithTag("Boss").GetComponent<Boss>();
        StartCoroutine(FadeIn(0.01f));
    }

    void Update()
    {      
        GetComponent<Image>().fillAmount = b.health / b.maxHealth;
    }

    IEnumerator FadeIn(float fadeSpeed)
    {
        for (float alpha = 0; alpha <= 1; alpha += fadeSpeed)
        {
            alpha = Mathf.Round(alpha * 100) / 100;
            Color c = new Color(1, 1, 1, alpha);
            GetComponent<Image>().color = c;
            yield return null;
        }
    }
}
