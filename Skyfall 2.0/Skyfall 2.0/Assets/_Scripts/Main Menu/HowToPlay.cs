using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//menu handling for how to play menu in main menu
public class HowToPlay : Menu
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            BackToMainMenu();
        }
    }

    protected override void MakeChoice(int choice)
    {
        switch (choice)
        {
            case 0:
                BackToMainMenu();
                break;
        }
    }
}
