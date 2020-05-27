using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    public static BuildInfo cur;
    public Texture slimeImage;
    public Texture nullImage;
    public BuildInfo[] towers;

    void OnGUI() {
        ShowCurrentTower();
        GUILayout.BeginArea(new Rect(Screen.width/2 - 100, 0, 300,64));
        GUILayout.BeginHorizontal("box");
        GUILayout.Box(new GUIContent(SlimeCollector.cash.ToString(), slimeImage));
        foreach (BuildInfo bi in towers){
            GUI.enabled = SlimeCollector.cash >= bi.price;
            if (GUILayout.Button(new GUIContent(bi.price.ToString(), bi.previewImage))){
                if (cur == bi){
                    cur = null;
                }
                else {
                    cur = bi;
                }
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.EndArea();

    }

    void ShowCurrentTower(){
        GUILayout.BeginArea(new Rect(Screen.width/4, 0, 100,64));
        GUILayout.BeginHorizontal("box");
        if (cur == null){
            GUILayout.Box(new GUIContent(nullImage));
        }
        else {
            GUILayout.Box(new GUIContent(cur.previewImage));
        }
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }
}
