using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public GameObject FireLeft;
    public GameObject FireRight;
    public GameObject FireEmitterLeft;
    public GameObject FireEmitterRight;

    AudioManager audioManager;
    private bool rocketEngineSoundIsPlaying = false;
    public bool hasLeftEarth = false;
    private bool hasPlayedEngineStart = false;

    public float currentFuelAmount = 100.0f;
    public float maxMoveSpeed = 5.0f;
    public float currentMoveSpeed = 0.0f;
    public float decayRatio = 0.0f;
    public float speedScalar = 0.0f;
    public float rotationScale = 0.1f;
    private float angle = 0.0f;
    private Vector3 vDir = Vector3.zero;

    private float cooldown = 0.0f;
    private bool playCooldown = false;

    // Use this for initialization
    void Start ()
    {
        if (PlayerPrefs.GetFloat("CurrentMoveSpeed") <= 0.0f)
        {
            PlayerPrefs.SetFloat("CurrentMoveSpeed", currentFuelAmount);
        }
        else
        {
            currentFuelAmount = PlayerPrefs.GetFloat("CurrentMoveSpeed");
        }

        if (PlayerPrefs.GetFloat("fuelAmount") <= 0.0f)
        {
            PlayerPrefs.SetFloat("fuelAmount", currentFuelAmount);
        }
        else
        {
            currentFuelAmount = PlayerPrefs.GetFloat("fuelAmount");
        }

        if (PlayerPrefs.GetString("hasLeftEarth") == "true")
        {
            hasLeftEarth = true;
        }
        else
        {
            hasLeftEarth = false;
        }

        audioManager = AudioManager.instance;

        if (audioManager == null)
        {
            Debug.LogError("No audiomanager found!");
        }

        if (PlayerPrefs.GetString("FuelType") == "Benzene")
        {
            maxMoveSpeed = 10.0f;
            speedScalar = 0.05f;
            decayRatio = 0.4f;
        }
        else if (PlayerPrefs.GetString("FuelType") == "Diesel")
        {
            maxMoveSpeed = 10.0f;
            speedScalar = 0.05f;
            decayRatio = 0.5f;
        }
        else if (PlayerPrefs.GetString("FuelType") == "Kerosene")
        {
            maxMoveSpeed = 12.0f;
            speedScalar = 0.09f;
            decayRatio = 0.2f;
        }
        else if (PlayerPrefs.GetString("FuelType") == "Hydrogen")
        {
            maxMoveSpeed = 15.0f;
            speedScalar = 0.09f;
            decayRatio = 0.2f;
        }
        else if (PlayerPrefs.GetString("FuelType") == "Coal")
        {
            maxMoveSpeed = 2.0f;
            speedScalar = 0.01f;
            decayRatio = 1.0f;
        }
        else
        {
            Debug.Log("FUELTYPE HAS NO VALUE!");
            maxMoveSpeed = 2.0f;
            speedScalar = 1.0f;
            decayRatio = 1.0f;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (playCooldown)
        {
            cooldown += Time.deltaTime;
        }

        if (Input.GetAxisRaw("Horizontal") > 0.0f || Input.GetAxisRaw("Vertical") > 0.0f && currentFuelAmount > 0.0f)
        {
            if (currentMoveSpeed < maxMoveSpeed)
            {
                currentMoveSpeed += Time.deltaTime * speedScalar;
            }
            else
            {
                currentMoveSpeed = maxMoveSpeed;
            }

            if (!FireLeft.activeInHierarchy && !FireRight.activeInHierarchy && hasLeftEarth == false)
            {
                FireLeft.SetActive(true);
                FireRight.SetActive(true);
            }

            if (!rocketEngineSoundIsPlaying && hasLeftEarth == false)
            {
                if (hasPlayedEngineStart && cooldown >= 7.0f)
                {
                    audioManager.PlaySound("RocketEngineLoop");
                    rocketEngineSoundIsPlaying = true;
                    playCooldown = false;
                    cooldown = 0.0f;
                }
                else if (!playCooldown)
                {
                    audioManager.PlaySound("RocketEngineStart");
                    playCooldown = true;
                    hasPlayedEngineStart = true;
                }
            }

            if (!FireEmitterLeft.activeInHierarchy && !FireEmitterRight.activeInHierarchy && hasLeftEarth == false)
            {
                FireEmitterLeft.SetActive(true);
                FireEmitterRight.SetActive(true);
            }

            currentFuelAmount -= Time.deltaTime * decayRatio;
        }
        else
        {
            if (FireLeft.activeInHierarchy || FireRight.activeInHierarchy)
            {
                FireLeft.SetActive(false);
                FireRight.SetActive(false);
            }

            if (rocketEngineSoundIsPlaying)
            {
                audioManager.StopSound("RocketEngineLoop");
                rocketEngineSoundIsPlaying = false;
            }

            if (FireEmitterLeft.activeInHierarchy || FireEmitterRight.activeInHierarchy)
            {
                FireEmitterLeft.SetActive(false);
                FireEmitterRight.SetActive(false);
            }
        }

        if (hasLeftEarth)
        {
            audioManager.StopSound("RocketEngineLoop");
            FireEmitterLeft.SetActive(false);
            FireEmitterRight.SetActive(false);
        }

        // Ammount to move
        vDir.x = Input.GetAxisRaw("Horizontal");
        vDir.y = Input.GetAxisRaw("Vertical");

        // Rotate player
        angle += Mathf.Atan2(vDir.x, vDir.y) * Mathf.Rad2Deg * Time.deltaTime * currentMoveSpeed * rotationScale;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);

        // Move the player
        transform.Translate(Vector3.up * vDir.magnitude * currentMoveSpeed * Time.deltaTime);
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetFloat("CurrentMoveSpeed", currentFuelAmount);
        PlayerPrefs.SetString("hasLeftEarth", "true");
    }
}
