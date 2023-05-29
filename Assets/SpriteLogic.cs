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

    public GameObject Sky;
    public GameObject FarmHill;
    public GameObject FrontHill;
    public GameObject CoalPlant;
    public GameObject Windmills;
    public GameObject Lake; 
    

    [ContextMenu("UpdateSky")]
    public void UpdateSky() { Sky.GetComponent<SpriteChanger>().ChangeSprite((int)(airPollution / 2)); }

    [ContextMenu("UpdateFarmHill")]
    public void UpdateFarmHill() { FarmHill.GetComponent<SpriteChanger>().ChangeSprite((int)(farmlandGrowth / 2)); }

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

    [ContextMenu("UpdateLake")]
    public void UpdateLake() { Lake.GetComponent<SpriteChanger>().ChangeSprite((int)(waterPollution / 2)); }
    
    // testing methods (starter increment counters needs editting)
    [ContextMenu("IncrAirPol")]
    public void IncrAirPol() { airPollution = System.Math.Min(5, airPollution + 1); }
    [ContextMenu("DecrAirPol")]
    public void DecrAirPol() { airPollution = System.Math.Max(0, airPollution - 1); }

    [ContextMenu("IncrCropQual")]
    public void IncrCropQual() { farmlandGrowth = System.Math.Min(5, farmlandGrowth + 1); }
    [ContextMenu("DecrCropQual")]
    public void DecrCropQual() { farmlandGrowth = System.Math.Max(0, farmlandGrowth - 1); }

    // ------------------------------------------------

    // scene tracking counters
   

    public bool forestDead = false;

    public int populationDensity = 0;
}
