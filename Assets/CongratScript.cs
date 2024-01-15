﻿using System.Collections.Generic;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    [SerializeField] ParticleSystem SparksParticles;
    private List<string> TextToDisplay = new List<string>();

    private float RotatingSpeed;
    private float TimeToNextText;
    private int CurrentText;

    // Start is called before the first frame update
    void Start()
    {
        TimeToNextText = 0.0f;
        CurrentText = 0;
        RotatingSpeed = 1.0f;

        TextToDisplay.Add("Congratulation");
        TextToDisplay.Add("All Errors Fixed");

        
        SparksParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        TimeToNextText += Time.deltaTime;
        Text.text = TextToDisplay[CurrentText];

        Text.gameObject.transform.Rotate(0, RotatingSpeed, 0); //rotates text

        // Displays texts each 1.5s and repeats from start
        if (TimeToNextText > 1.5f)
        {
            TimeToNextText = 0.0f;
            CurrentText++;
            if (CurrentText >= TextToDisplay.Count)
            {
                CurrentText = 0;
                Text.text = TextToDisplay[CurrentText];
            }
        }
    }
}