using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnimation : MonoBehaviour
{
    public CharacterSelect charSelect;

    [SerializeField]
    private GameObject leftArrow, rightArrow;

    private const float small = 1f;
    private const float large = 1.1f;

    void Start()
    {
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
        if (charSelect.menuChoice == 0)
        {
            leftArrow.SetActive(false);
        }
        else if (charSelect.menuChoice == 3)
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
