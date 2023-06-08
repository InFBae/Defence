using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["ContinueButton"].onClick.AddListener(OnContinueButton);
        buttons["SettingButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/ConfigPopUpUI"); });
    }

    public void OnContinueButton()
    {
        GameManager.UI.ClosePopUpUI();
    }
}
