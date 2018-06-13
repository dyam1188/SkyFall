using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnimation : MonoBehaviour
{
    private CharacterSelect cs;

    [SerializeField]
    private GameObject leftArrow, rightArrow;

    private const float small = 1f;
    private const float large = 1.1f;

    void Start()
    {
        cs = GetComponent<CharacterSelect>();
        leftArrow.SetActive(false);
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
            leftArrow.SetActive(false);
        }
        else if (cs.menuChoice == cs.players.Length - 1)
        {
            rightArrow.SetActive(false);
        }
        else
        {
            leftArrow.SetActive(true);
            rightArrow.SetActive(true);
        }
    }

    void GetKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Resize(leftArrow, large);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Resize(leftArrow, small);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Resize(rightArrow, large);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Resize(rightArrow, small);
        }
    }

    //resizes the arrows appropriately
    void Resize(GameObject arrow, float size)
    {
        arrow.transform.localScale = new Vector3(size, size, 1);
    }
}
