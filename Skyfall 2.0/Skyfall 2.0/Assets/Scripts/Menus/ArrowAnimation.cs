using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnimation : MonoBehaviour
{
    public CharacterSelect cs;

    [SerializeField]
    private GameObject leftArrow, rightArrow;

    private const float small = 1f;
    private const float large = 1.1f;
    private const float resizeSpeed = 0.02f;

    private Color invisible = new Color(1, 1, 1, 0);
    private Color visible = new Color(1, 1, 1, 1);

    void Start()
    {
        leftArrow.GetComponent<SpriteRenderer>().color = invisible;
    }

    void Update()
    {
        Redisplay();
        GetKeyInput();
    }

    //make selection arrows disappear at appropriate times
    void Redisplay()
    {
        if (cs.menuChoice == 0)
        {
            leftArrow.GetComponent<SpriteRenderer>().color = invisible;
        }
        else if (cs.menuChoice == 3)
        {
            rightArrow.GetComponent<SpriteRenderer>().color = invisible;
        }
        else
        {
            leftArrow.GetComponent<SpriteRenderer>().color = visible;
            rightArrow.GetComponent<SpriteRenderer>().color = visible;
        }
    }

    void GetKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(SetLarge(leftArrow));
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            StartCoroutine(SetSmall(leftArrow));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(SetLarge(rightArrow));
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            StartCoroutine(SetSmall(rightArrow));
        }
    }

    IEnumerator SetLarge(GameObject go)
    {
        for (float i = transform.localScale.x; i <= large; i += resizeSpeed)
        {
            go.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(i, i, 1);
            yield return null;
        }
    }

    IEnumerator SetSmall(GameObject go)
    {
        for (float i = transform.localScale.x; i >= small; i -= resizeSpeed)
        {
            go.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(i, i, 1);
            yield return null;
        }
    }
}
