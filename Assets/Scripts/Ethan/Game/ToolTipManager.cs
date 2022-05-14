using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ToolTipManager : MonoBehaviour
{
    public ToolTips[] toolTips;

    public void ShowUI(string name, string text, Vector2 Position)
    {
        ToolTips tips = Array.Find(toolTips, toolTips => toolTips.name == name);
        if(tips == null)
        {
            Debug.LogWarning("UI" + name + "not found!");
            return;
        }
        tips.ShowInfo(text, Position);
    }
    public void HideUI(string name)
    {
        ToolTips tips = Array.Find(toolTips, toolTips => toolTips.name == name);
        if (tips == null)
        {
            Debug.LogWarning("UI" + name + "not found!");
            return;
        }
        tips.HideInfo();
    }
}
