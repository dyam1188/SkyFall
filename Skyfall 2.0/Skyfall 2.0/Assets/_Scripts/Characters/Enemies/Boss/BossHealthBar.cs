using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//controls fill amount of the boss's health bar
//attached to Game -> Canvas -> Health Bar (boss)
public class BossHealthBar : MonoBehaviour
{
    Boss b;
    bool coroutineFinished;

    void Start()
    {
        b = GameObject.FindWithTag("Boss").GetComponent<Boss>();
        StartCoroutine(EnterScene(b.fadeSpeed));
    }

    void Update()
    {
        //track boss's health only when it finishes entering the scene
        if (coroutineFinished)
        {
            GetComponent<Image>().fillAmount = b.health / b.maxHealth;
        }

        if (b.health <= 0)
        {
            this.enabled = false;
        }
    }

    IEnumerator EnterScene(float coroutineInterval)
    {
        for (float i = 0; i <= 1; i += coroutineInterval)
        {
            i = Mathf.Round(i * 100) / 100;
            GetComponent<Image>().fillAmount = Mathf.Lerp(0, 1, Mathf.Sin((Mathf.PI / 2) * i));
            GetComponent<Image>().color = new Color(1, 1, 1, Mathf.Lerp(0, 1, Mathf.Sin((Mathf.PI / 2) * i)));
            yield return null;
        }
        coroutineFinished = true;
    }
}
