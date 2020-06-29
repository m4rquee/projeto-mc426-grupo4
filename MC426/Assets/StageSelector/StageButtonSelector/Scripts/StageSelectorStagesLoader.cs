using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectorStagesLoader : MonoBehaviour
{
    private static int unlockedStages;
    public static int stagesQuantity = 10;
    // Start is called before the first frame update
    void Start()
    {
        unlockedStages = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void setUnlockedStages(int stages){
        if (stages > stagesQuantity){
            unlockedStages = stagesQuantity;
        }
        else if (stages < 1){
            unlockedStages = 1;
        }
        else {
            unlockedStages = stages;
        }
    }

    public static int getUnlockedStages(){
        return unlockedStages;
    }
}
