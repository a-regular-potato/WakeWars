using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;

[System.Serializable]
public class ToolTips
{
    public string name;
    public TextMeshProUGUI moduleInfo;
    public RectTransform moduleWindow;

    public bool ScaleBackground = true;

    public void ShowInfo(string text, Vector2 mousePos)
    {
        moduleInfo.text = text;
        if (ScaleBackground)
        {
            moduleWindow.sizeDelta = new Vector2(moduleInfo.preferredWidth > 500 ? 500 : moduleInfo.preferredWidth * 1.1f, moduleInfo.preferredHeight * 1.1f);
        }

        moduleWindow.gameObject.SetActive(true);
        moduleWindow.transform.position = new Vector2(mousePos.x + (moduleWindow.sizeDelta.x / 2), mousePos.y);
    }
    public void HideInfo()
    {
        moduleInfo.text = default;
        moduleWindow.gameObject.SetActive(false);
    }
}
