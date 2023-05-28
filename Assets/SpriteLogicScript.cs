using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpriteLogicScript : MonoBehaviour
{

    // sky tracking
    public int airPollution = 0;
    public const int GOOD_SKY = 0;
    public const int OK_SKY = 1;
    public const int BAD_SKY = 2;
    public GameObject Sky;

    [ContextMenu("UpdateSky")]
    public void UpdateSky()
    {
        SpriteChanger SkySC = Sky.GetComponent<SpriteChanger>();
        SkySC.ChangeSprite(airPollution);
    }
    
    // testing methods
    [ContextMenu("IncrSky")]
    public void IncrSky()
    {
        ++airPollution;
    }
    [ContextMenu("DecrSky")]
    public void DecrSky()
    {
        --airPollution;
    }

    // scene tracking counters
    public int farmlandGrowth = 0;

    public bool forestDead = false;

    public int waterPollution = 0;

    public int populationDensity = 0;
}
