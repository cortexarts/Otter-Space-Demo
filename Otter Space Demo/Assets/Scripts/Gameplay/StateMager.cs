using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StateMager : MonoBehaviour
{
    AudioManager audioManager;
    private bool SpaceMusicIsPlaying = false;

    // Use this for initialization
    void Start ()
    {
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

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Landscape")
        {
            GameObject cameraPointer = GameObject.Find("MainCamera");
            UnityStandardAssets._2D.Camera2DFollow cameraScript = cameraPointer.GetComponent<UnityStandardAssets._2D.Camera2DFollow>();
            cameraScript.Follow = true;

            GetComponent<RocketController>().hasLeftEarth = true;

            if (!SpaceMusicIsPlaying)
            {
                audioManager.StopSound("BackgroundMusic");
                audioManager.PlaySound("BackgroundMusicSpace");
                SpaceMusicIsPlaying = true;
            }
        }
        else if (coll.gameObject.name == "Moon")
        {
            GetComponent<RocketController>().SaveProgress();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (coll.gameObject.tag == "MoonEscape")
        {
            GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "MoonLand")
        {
            GetComponent<RocketController>().SaveProgress();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
