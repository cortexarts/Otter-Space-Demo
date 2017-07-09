using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    public Transform loadingBar;
    public float currentfuelPointer;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject playerPointer = GameObject.Find("Rocket");
        RocketController playerScript = playerPointer.GetComponent<RocketController>();
        currentfuelPointer = playerScript.currentFuelAmount;

        loadingBar.GetComponent<Image>().fillAmount = currentfuelPointer / 100;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat("fuelAmount", currentfuelPointer);
    }
}
