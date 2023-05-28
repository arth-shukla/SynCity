using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLogic : MonoBehaviour
{  
    // ------------------------------------------------------------
    // sky tracking
    public int airPollution = 0;
    public GameObject Sky;

    [ContextMenu("UpdateSky")]
    public void UpdateSky() { Sky.GetComponent<SpriteChanger>().ChangeSprite((int)(airPollution / 2)); }
    
    // testing methods
    [ContextMenu("IncrAirPol")]
    public void IncrAirPol() { airPollution = System.Math.Min(5, airPollution + 1); }
    [ContextMenu("DecrAirPol")]
    public void DecrAirPol() { airPollution = System.Math.Max(0, airPollution - 1); }

    // ------------------------------------------------

    // scene tracking counters
    public int farmlandGrowth = 0;

    public bool forestDead = false;

    public int waterPollution = 0;

    public int populationDensity = 0;
}
