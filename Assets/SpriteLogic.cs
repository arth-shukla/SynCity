using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLogic : MonoBehaviour
{  
    // ------------------------------------------------------------
    // scene tracking counters
    public int airPollution = 0;       // sky counter
    public int farmlandGrowth = 0;     // farm hill counter
    public int energySource = 0;    // front hill counter (used only once during decision)
    public int waterPollution = 0;   
    public int AirPolChoice = 0;
    public int waterDemand = 0;

    public int choiceState = 0;
    public int choiceCounter = 0;   // counter for ending dialogue

    public GameObject Sky;
    public GameObject FarmHill;
    public GameObject FrontHill;
    public GameObject CoalPlant;
    public GameObject Windmills;
    public GameObject Lake; 

    [ContextMenu("UpdateSky")]
    public void UpdateSky() { Sky.GetComponent<SpriteChanger>().ChangeSprite((int)(airPollution)); }    // was airPollution / 2, (using current for testing counter)

    [ContextMenu("UpdateFarmHill")]
    public void UpdateFarmHill() { FarmHill.GetComponent<SpriteChanger>().ChangeSprite((int)(farmlandGrowth / 2)); }

    [ContextMenu("UpdateForestHill")]
    public void UpdateForestHill() {

    }

    [ContextMenu("UpdateLake")]
    public void UpdateLake() { Lake.GetComponent<SpriteChanger>().ChangeSprite((int)(waterPollution / 2)); }

    [ContextMenu("UpdateFrontHill")]
    public void UpdateFrontHill() { 
        if(energySource == 2){
            FrontHill.SetActive(true);
            CoalPlant.SetActive(false);
            Windmills.SetActive(true);
        }
        else if(energySource == 4){
            FrontHill.SetActive(false);
            CoalPlant.SetActive(true);
            Windmills.SetActive(false);
        }
        else{
            FrontHill.SetActive(true);
            CoalPlant.SetActive(false);
            Windmills.SetActive(false);
        }
     }


    
    // testing methods (starter increment counters needs editting)
    [ContextMenu("IncrAirPol")]
    public void IncrAirPol() { airPollution = System.Math.Min(5, airPollution + 1); }
    [ContextMenu("DecrAirPol")]
    public void DecrAirPol() { airPollution = System.Math.Max(0, airPollution - 1); }

    // testing new counter for sky (finished and can be used for game)
    [ContextMenu("UpdateAirCount")]
    public void UpdateAirCount(){
        if(AirPolChoice == 1){  // bad choice for decision 2
            airPollution = System.Math.Min(5, airPollution + 1);
        }
        else if(AirPolChoice == 2){ // good choice for decision 2
            airPollution = System.Math.Max(0, airPollution - 1);
        }
    }

    [ContextMenu("IncrCropQual")]
    public void IncrCropQual() { farmlandGrowth = System.Math.Min(5, farmlandGrowth + 1); }
    [ContextMenu("DecrCropQual")]
    public void DecrCropQual() { farmlandGrowth = System.Math.Max(0, farmlandGrowth - 1); }

    [ContextMenu("EndingCounter")]
    public void EndingCounter() {
        if(choiceState == -1){  // if make a good choice 
            choiceCounter = System.Math.Min(5, choiceCounter - 1);
        }
        else if(choiceState == 0){  // if make an ok choice
            choiceCounter = choiceCounter;
        }
        else if(choiceState == 1){  // if make a bad choice
            choiceCounter = System.Math.Max(0, choiceCounter + 1);
        }
        
    }

    // ------------------------------------------------

    // scene tracking counters
   

    public bool forestDead = false;

    public int populationDensity = 0;
}
