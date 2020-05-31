﻿using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    public static BuildInfo Cur;
    public Texture slimeImage;
    public Texture nullImage;
    public BuildInfo[] towers;

    private void OnGUI()
    {
        ShowCurrentTower();
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 100, 0, 300, 64));
        GUILayout.BeginHorizontal("box");
        GUILayout.Box(new GUIContent(SlimeCollector.Cash.ToString(), slimeImage));
        foreach (var bi in towers)
        {
            GUI.enabled = SlimeCollector.Cash >= bi.price;
            if (GUILayout.Button(new GUIContent(bi.price.ToString(), bi.previewImage)))
            {
                Cur = Cur == bi ? null : bi;
            }
        }

        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }

    private void ShowCurrentTower()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 4f, 0, 100, 64));
        GUILayout.BeginHorizontal("box");
        var curBox = new GUIContent(Cur == null ? nullImage : Cur.previewImage);
        GUILayout.Box(curBox);

        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }
}
