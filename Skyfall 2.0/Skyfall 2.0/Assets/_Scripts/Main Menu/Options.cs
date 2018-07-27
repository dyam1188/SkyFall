using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//menu handling for options menu in main menu and game (while paused)
public class Options : Menu
{
    [SerializeField]
    AudioSource backgroundMusic;

    [SerializeField]
    Slider musicSlider;

    [SerializeField]
    Slider soundSlider;

    [Space]

    [SerializeField]
    Image musicSliderFill;

    [SerializeField]
    Image soundSliderFill;

    [Space]

    [SerializeField]
    Text musicVolumeValue;

    [SerializeField]
    Text soundVolumeValue;

    protected override void Awake()
    {
        base.Awake();
        UpdateMusic();
    }

    protected override void Start()
    {
        base.Start();
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            PlayerController pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            SetOutlineColor(pc.uiColor);
        }
    }

    void SetOutlineColor(Color c)
    {
        foreach (Text t in textArray)
        {
            t.GetComponent<Outline>().effectColor = c;
        }

        musicSliderFill.color = c;
        soundSliderFill.color = c;

        musicVolumeValue.GetComponent<Outline>().effectColor = c;
        soundVolumeValue.GetComponent<Outline>().effectColor = c;
    }

    protected override void Update()
    {
        base.Update();
        UpdateText();
        UpdateMusic();
    }

    void UpdateText()
    {
        musicVolumeValue.text = musicSlider.value.ToString();
        soundVolumeValue.text = soundSlider.value.ToString();
    }

    void UpdateMusic()
    {
        backgroundMusic.volume = musicSlider.value / musicSlider.maxValue;
    }

    protected override void GetKeyInput()
    {
        base.GetKeyInput();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            BackToMainMenu();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            switch (choice)
            {
                case 0:
                    ChangeVolume(musicSlider, -1);
                    break;
                case 1:
                    ChangeVolume(soundSlider, -1);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            switch (choice)
            {
                case 0:
                    ChangeVolume(musicSlider, 1);
                    break;
                case 1:
                    ChangeVolume(soundSlider, 1);
                    break;
            }
        }
    }

    void ChangeVolume(Slider s, int amount)
    {
        s.value += amount;
    }

    protected override void MakeChoice(int choice)
    {
        if (choice == textArray.Length - 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                BackToMainMenu();
            }
            else
            {
                BackToPauseMenu();
            }
        }
    }
}