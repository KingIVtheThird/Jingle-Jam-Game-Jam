using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_interact : MonoBehaviour {

    public GameObject target = null;
    public bool hasSeed = false;

    private bool plotInter = false;
    private bool crateInter = false;

    public plant plant;
    public crop_plot plot;


    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Plot")) {
            plotInter = true;
            target = other.gameObject;
        }
        if (other.CompareTag("Crate")) {
            crateInter = true;
            target = other.gameObject;
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E) && plotInter) {
            crop_plot plot = target.GetComponent<crop_plot>();
            Debug.Log("Clicked plot");

            plot.PlantThePlot(this);
        }
        if (Input.GetKeyDown(KeyCode.E) && crateInter) {
            placeholder_crate crate = target.GetComponent<placeholder_crate>();
            Debug.Log("Picked up seed");
            crate.c_Interact(this);
        }
        if (Input.GetKeyDown(KeyCode.G)) {
            Debug.Log("Passed day");
            FindObjectOfType<crop_plot>().plantGrowth(1);
        }


    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Plot")) {
            plotInter = false;
            target = null;
        }
        if (other.CompareTag("Crate")) {
            crateInter = false;
            target = null;
        }
    }
}
