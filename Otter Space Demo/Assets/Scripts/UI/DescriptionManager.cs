using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DescriptionManager : MonoBehaviour
{
    AudioManager audioManager;

    public Text DescriptionText;

    // Use this for initialization
    void Start ()
    {
        DescriptionText.text = "Choose one of the fuel types as your rocket propellant.";

        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("No audiomanager found!");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void SelectedBenzene()
    {
        PlayerPrefs.SetString("FuelType", "Benzene");
        audioManager.PlaySound("ButtonPress");
        DescriptionText.text = "Benzene (C6H6) is a rather good fuel, endothermal but with good stability. Even though benzene is one of the most common used fuels, a propellant of benzene has serious drawbacks. Benzene freezes readily and is highly inefficient. Diesel is less expensive and less inefficient.";
    }

    public void SelectedDiesel()
    {
        PlayerPrefs.SetString("FuelType", "Diesel");
        audioManager.PlaySound("ButtonPress");
        DescriptionText.text = "Diesel (C12H23) is a very efficient and relatively cheap fuel. The only downside it has are requirement of bigger, and therefore heavier, engines and the emission of fine particulates.";
    }

    public void SelectedKerosene()
    {
        PlayerPrefs.SetString("FuelType", "Kerosene");
        audioManager.PlaySound("ButtonPress");
        DescriptionText.text = "Liquid oxygen (LOX) and Kerosene (CxHy) are cryogenic propellants. Kerosene is a very practical fuel for rocket booster. A downside is that this specific application requires full atmoshperic pressure and mostly is used for the first stage of a launch.";
    }

    public void SelectedHydrogen()
    {
        PlayerPrefs.SetString("FuelType", "Hydrogen");
        audioManager.PlaySound("ButtonPress");
        DescriptionText.text = "Liquid oxygen (LOX, O2) and liquid hydrogen (LH2, H2) are cryogenic propellants. The result of these components is Liquid Hydrogen (LH2). Liquid Hydrogen is used in most stages of a rocket or space shuttle, therefore a very good choice as rocket propellant.";
    }

    public void SelectedCoal()
    {
        PlayerPrefs.SetString("FuelType", "Coal");
        audioManager.PlaySound("ButtonPress");
        DescriptionText.text = "The only thing coal will boost is the American economy according to President Donald Trump.";
    }
}
