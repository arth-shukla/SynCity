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
    public int waterEnergy = 0;
    public int conserveEff = 0;

    public int choiceState = 0;
    public int choiceCounter = 0;   // counter for ending dialogue

    public GameObject Sky;
    public GameObject FarmHill;
    public GameObject FrontHill;
    public GameObject CoalPlant;
    public GameObject Windmills;
    public GameObject Lake; 
    public GameObject SmokeHouse;
    public GameObject WaterTreat;
    public GameObject Waves;
    public GameObject Dam;
    public GameObject ForestHill;
    public GameObject WasteIncin;
    public GameObject Factory;
    public GameObject Park;
    public GameObject BadCrops;
    public GameObject GoodCrops;


    [ContextMenu("UpdateSky")]
    public void UpdateSky() { Sky.GetComponent<SpriteChanger>().ChangeSprite((int)(airPollution)); }    // was airPollution / 2, (using current for testing counter)

    [ContextMenu("UpdateFarmHill")]
    public void UpdateFarmHill() { 
        if(farmlandGrowth == 0){ // initial hill
            FarmHill.SetActive(true);
            BadCrops.SetActive(false);
            GoodCrops.SetActive(false);
        }
        else if(farmlandGrowth == 1){   // add good crops
            FarmHill.SetActive(false);
            GoodCrops.SetActive(true);
        }
        else if(farmlandGrowth == 2){   // add bad crops
            FarmHill.SetActive(false);
            BadCrops.SetActive(true);
        }
    }

    [ContextMenu("UpdateForestHill")]
    public void UpdateForestHill() { 
        if(conserveEff == 0){ // initial forest hill
            ForestHill.SetActive(true);
            WasteIncin.SetActive(false);
            Park.SetActive(false);
            Factory.SetActive(false);
        }
        else if(conserveEff == 1){  // add waste incinerator
            WasteIncin.SetActive(true);
        }
        else if(conserveEff == 2){  // add national park
            ForestHill.SetActive(false);
            Park.SetActive(true);
        }
        else if(conserveEff == 3){  // add factory
            ForestHill.SetActive(false);
            Factory.SetActive(true);
        }
    }

    [ContextMenu("UpdateLake")]
    public void UpdateLake() { Lake.GetComponent<SpriteChanger>().ChangeSprite((int)(waterPollution)); }

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

    [ContextMenu("UpdateTreatment")]
    public void UpdateTreatment() {
        if(waterDemand == 1){   // boiler efficiency
            SmokeHouse.SetActive(true);
            WaterTreat.SetActive(false);
        }
        else if(waterDemand == 2){  // water treatment
            SmokeHouse.SetActive(false);
            WaterTreat.SetActive(true);
        }
        else if(waterDemand == 3){  // turn off smoke image on next decision
            SmokeHouse.SetActive(false);
        }
        else{   // if ok decision or before decision 3
            SmokeHouse.SetActive(false);
            WaterTreat.SetActive(false);
        }
    }

    [ContextMenu("UpdateWaterEnergy")]
    public void UpdateWaterEnergy() {
        if(waterEnergy == 1){   // add dam
            Dam.SetActive(true);
        }
        else if(waterEnergy == 2){  // add wave power
            Waves.SetActive(true);
        }
        else{
            Dam.SetActive(false);
            Waves.SetActive(false);
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
            // choiceCounter = choiceCounter;
        }
        else if(choiceState == 1){  // if make a bad choice
            choiceCounter = System.Math.Max(0, choiceCounter + 1);
        }
        
    }

    [ContextMenu("EndingCounter")]
    public void ResetScene() {
        airPollution = 0;       // sky counter
        farmlandGrowth = 0;     // farm hill counter
        energySource = 0;    // front hill counter (used only once during decision)
        waterPollution = 0;   
        AirPolChoice = 0;
        waterDemand = 0;
        waterEnergy = 0;
        conserveEff = 0;
        choiceState = 0;
        choiceCounter = 0;   // counter for ending dialogue

        UpdateSky();
        UpdateFarmHill();
        UpdateForestHill();
        UpdateLake();
        UpdateFrontHill();
        UpdateTreatment();
        UpdateWaterEnergy();
        UpdateAirCount();
    }

    // ------------------------------------------------

    // scene tracking counters
   

    public bool forestDead = false;

    public int populationDensity = 0;
}
