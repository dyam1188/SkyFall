using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : Menu
{
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
        BackToMainMenu();
    }
}
