using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class plant {


    public PlantGrowth growth;

    public Sprite emptySprite;
    public Sprite caredSprite;
    public Sprite uncaredSprite;
    public Sprite bountySprite;
    public Sprite deadSprite;


    // Actions

    public Sprite GetPlantSprite() {
        Debug.Log("Retrieving sprite...");
        switch (growth) {
            case PlantGrowth.Unplanted:
                return emptySprite;
            case PlantGrowth.Cared:
                return caredSprite;
            case PlantGrowth.Uncared:
                return uncaredSprite;
            case PlantGrowth.Bounty:
                return bountySprite;
            case PlantGrowth.Dead:
                return deadSprite;
        }
        Debug.Log("Sprite fail to be retrieved");
        return emptySprite;
    }

    // Checks
    public bool Unplanted() {
        Debug.Log("Planted check");
        if (growth == PlantGrowth.Unplanted)
            return true;
        else
            return false;
    }
    public bool caredFor() {// Returns True if plant is cared
        Debug.Log("Care check");
        if (growth == PlantGrowth.Cared)
            return true;
        else
            return false;
    }


    public bool Bounty() {
        Debug.Log("Produce check");
        if (growth == PlantGrowth.Bounty)
            return true;
        else
            return false;
    }

}


public enum PlantGrowth
{
    Unplanted,
    Uncared,
    Cared,
    Bounty,
    Dead
}
