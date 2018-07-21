using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : Menu
{
    [Space]

    [SerializeField]
    Slider musicSlider;

    [SerializeField]
    Slider soundSlider;

    [Space]

    [SerializeField]
    Text musicVolumeText;

    [SerializeField]
    Text soundVolumeText;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        musicVolumeText.text = musicSlider.value.ToString();
        soundVolumeText.text = soundSlider.value.ToString();
    }

    protected override void GetKeyInput()
    {
        base.GetKeyInput();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            BackToMainMenu();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
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

        if (Input.GetKey(KeyCode.RightArrow))
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
            BackToMainMenu();
        }
    }
}
