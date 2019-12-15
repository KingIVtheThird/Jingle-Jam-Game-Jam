using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crop_plot : MonoBehaviour {

    public plant n_plant;

    public SpriteRenderer plantSprite;

    public bool tile_Unplanted = true;

    public float plantMaturity; //How long it takes for the plant to raech production age
    private float growthLevel = 0; // Current Age

    //Main Command
    public void PlantThePlot(player_interact player) {
        if (player.hasSeed && tile_Unplanted == true) {
            plantPlant(player);
            return;
        }
        if (tile_Unplanted == false && !n_plant.caredFor()) { //Planted + Not cared
            carePlant();
            return;
        }
        if (n_plant.Bounty()) {// Plant Grown
            harvestFood(n_plant);
        }
        else return;
    }


    //Sup Actions
    void plantPlant(player_interact player) { //Maybe add modularity in the future for different plants
        tile_Unplanted = false;

        n_plant.growth = PlantGrowth.Uncared;
        UpdateSprite();

        Debug.Log("Used seed");
        player.hasSeed = false;
    }

    void carePlant() {
        Debug.Log("Caring fo rplant");
        n_plant.growth = PlantGrowth.Cared;
        UpdateSprite();
    }
    void harvestFood(plant p) {
        // add crop to player inv
        n_plant.growth = PlantGrowth.Dead;
        UpdateSprite();
    }
    public void plantGrowth(float plantMaturity) {
        if (n_plant.caredFor()) {
            growthLevel += 100f / plantMaturity;
            Debug.Log("plant growing" + growthLevel);
        }
        if (growthLevel >= 100f) {
            n_plant.growth = PlantGrowth.Bounty;
            UpdateSprite();
            Debug.Log("plant done growing");
        }
    }

    void UpdateSprite() {
        plantSprite.sprite = n_plant.GetPlantSprite();
    }


}
