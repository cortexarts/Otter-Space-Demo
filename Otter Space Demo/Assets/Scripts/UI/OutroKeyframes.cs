﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroKeyframes : MonoBehaviour {

    public int CurrentFrame = 1;
    public bool CanPlayNextAnimation = true;
    public bool TrackAnimationTime = false;
    public float AnimationTracker = 0.0f;

    [SerializeField]
    string pageTurn = "PageTurnSound";

    AudioManager audioManager;

    // Use this for initialization
    void Start()
    {
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("No audiomanager found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (TrackAnimationTime && AnimationTracker <= 2.0f)
        {
            AnimationTracker += Time.deltaTime;
            CanPlayNextAnimation = false;
        }
        else
        {
            CanPlayNextAnimation = true;
        }

        if (CurrentFrame >= 4 && CanPlayNextAnimation)
        {
            SceneManager.LoadScene("Main_menu");
        }
    }

    public void NextFrame()
    {
        if (CurrentFrame == 1 && CanPlayNextAnimation)
        {
            audioManager.PlaySound(pageTurn);
            GetComponent<Animation>().Play("KeyFrame_cinematic_1");
            CurrentFrame++;
            AnimationTracker = 0.0f;
            TrackAnimationTime = true;
        }
        else if (CurrentFrame == 2 && CanPlayNextAnimation)
        {
            audioManager.PlaySound(pageTurn);
            GetComponent<Animation>().Play("KeyFrame_cinematic_2");
            CurrentFrame++;
            AnimationTracker = 0.0f;
            TrackAnimationTime = true;
        }
        else if (CurrentFrame == 3 && CanPlayNextAnimation)
        {
            audioManager.PlaySound(pageTurn);
            GetComponent<Animation>().Play("KeyFrame_cinematic_3");
            CurrentFrame++;
            AnimationTracker = 0.0f;
            TrackAnimationTime = true;
        }
    }
}
