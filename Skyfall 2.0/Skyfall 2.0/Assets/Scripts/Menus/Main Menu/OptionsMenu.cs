using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//main controller for Options Menu
//attached to Main Menu -> Script Holder - Options
public class OptionsMenu : MonoBehaviour
{
    [SerializeField]
    private Canvas optionsCanvas;

    [Space]

    //sliders
    [SerializeField]
    Slider bgmSlider;

    [SerializeField]
    Slider sfxSlider;

    [Space]

    //slider number value text
    [SerializeField]
    Text text_bgmValue;

    [SerializeField]
    Text text_sfxValue;

    [Space]

    //text array
    [SerializeField]
    public Text[] optionsText = new Text[3];
    public int menuChoice = 0;

    //text sizes
    private const int fontLarge = 28;
    private const int fontSmall = 22;

    [Space]

    [SerializeField]
    private AudioSource BGM;

    void Awake()
    {
        DontDestroyOnLoad(BGM);
    }

    void Start()
    {
        BGM = BGM.GetComponent<AudioSource>();
        optionsText[menuChoice].fontSize = fontLarge;
    }

    void Update()
    {
        if (optionsCanvas.gameObject.activeSelf)
        {
            GetKeyInput();
        }
    }

    void GetKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && menuChoice != 0)
        {
            menuChoice--;
            ResizeText();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && menuChoice != optionsText.Length - 1)
        {
            menuChoice++;
            ResizeText();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            switch (menuChoice)
            {
                case 0:
                    ChangeBGMVolume(-1);
                    break;
                case 1:
                    ChangeSFXVolume(-1);
                    break;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            switch (menuChoice)
            {
                case 0:
                    ChangeBGMVolume(1);
                    break;
                case 1:
                    ChangeSFXVolume(1);
                    break;
            }
        }
    }

    //scales the selected menu option larger
    public void ResizeText()
    {
        for (int i = 0; i < optionsText.Length; i++)
        {
            if (i == menuChoice)
            {
                SetText(optionsText[i], fontLarge);
            }
            else
            {
                SetText(optionsText[i], fontSmall);
            }
        }
    }

    //scales the selected text
    Text SetText(Text t, int size)
    {
        t.fontSize = size;
        return t;
    }

    void ChangeBGMVolume(int changeValue)
    {
        bgmSlider.value += changeValue;
        BGM.volume = (bgmSlider.value / 100);
        text_bgmValue.text = bgmSlider.value.ToString();
    }

    void ChangeSFXVolume(int changeValue)
    {
        sfxSlider.value += changeValue;
        text_sfxValue.text = sfxSlider.value.ToString();
    }
}