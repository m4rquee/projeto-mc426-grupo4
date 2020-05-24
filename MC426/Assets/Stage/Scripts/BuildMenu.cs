using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    public static BuildInfo cur;
    public Texture slimeImage;
    public BuildInfo[] towers;

    void OnGUI() {
        GUILayout.BeginArea(new Rect(Screen.width/2 - 100, 0, 200,64));
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
}
