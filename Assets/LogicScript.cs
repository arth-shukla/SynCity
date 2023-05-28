using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LogicScript : MonoBehaviour
{

    // scene tracking counters
    public bool farmlandQuality = false;
    public int farmlandGrowth = 0;

    public bool forestDead = false;

    public int airPollution = 0;
    public int waterPollution = 0;

    public int populationDensity = 0;

    // single function to update scene, callable from external gameobjects
    [ContextMenu("UpdateScene")]
    public void UpdateScene()
    {

    }
}
