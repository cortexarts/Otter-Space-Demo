using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DescriptionManager : MonoBehaviour
{
    public Text DescriptionTitle;
    public Text DescriptionText;

    // Use this for initialization
    void Start ()
    {
        DescriptionTitle.text = "Choose one of the fuel types.";
        DescriptionText.text = " ";
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void SelectedBenzine()
    {
        DescriptionTitle.text = "Benzine";
        DescriptionText.text = "A propellant consisting of benzine won't come far.";
    }

    public void SelectedCoal()
    {
        DescriptionTitle.text = "Coal";
        DescriptionText.text = "The only thing coal will boost is the American economy according to President Donald Trump.";
    }

    public void SelectedMethane()
    {
        DescriptionTitle.text = "Liquid Methane";
        DescriptionText.text = "Liquid oxygen (LOX) and liquid methane (CH4) are cryogenic propellants. A small restartable LOX methane rocket engine can deliver 5,000 pounds-force (22 kN) thrust and a specific impulse of 321 seconds.";
    }

    public void SelectedHydrogen()
    {
        DescriptionTitle.text = "Liquid Hydrogen";
        DescriptionText.text = "Liquid oxygen (LOX, O2) and liquid hydrogen (LH2, H2) are cryogenic propellants.";
    }
}
