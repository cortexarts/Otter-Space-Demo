using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BioDescriptionManager : MonoBehaviour
{
    AudioManager audioManager;

    public Text DescriptionText;

    public bool hasCell = false;

    // Use this for initialization
    void Start()
    {
        DescriptionText.text = "Look for a cell to heal Professor Onion with.";

        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("No audiomanager found!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectedCell1()
    {
        DescriptionText.text = "Yes I am indeed a plant, but I live underground. I don't have any chloroplasts for photosynthesis to generate energy.";
    }

    public void SelectedCell2()
    {
        hasCell = true;
        DescriptionText.text = "Yes that's the one, thank you!";
    }

    public void SelectedCell3()
    {
        DescriptionText.text = "No that won't work. I only need plant cells.";
    }

    public void UseCell()
    {
        if (hasCell)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            DescriptionText.text = "No, not that one!";
        }
    }
}
