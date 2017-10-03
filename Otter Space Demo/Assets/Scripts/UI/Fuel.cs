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
        RocketControllerII playerScript = playerPointer.GetComponent<RocketControllerII>();
        currentfuelPointer = playerScript.CurrentFuelAmount();

        loadingBar.GetComponent<Image>().fillAmount = currentfuelPointer / 100f;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat("fuelAmount", currentfuelPointer);
    }
}
