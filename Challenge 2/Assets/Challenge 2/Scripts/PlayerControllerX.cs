using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerControllerX : MonoBehaviour
{
    public static PlayerControllerX Instance { get; private set; }
    public GameObject dogPrefab;
    public float MinTimeBetweenDogs;
    public int InitialDogsRemaining = 5;
    public int AddMoreDogsIfBallGetCaptured = 5;
    private int DogsRemaining;
    private float LastDogSpawned;

    // Counters & menu texts
    private int Score;
    public Text ScoreText;
    public Text DogsLeftText;
    public Text LoseGameText;
    public Text RoundScoreText;

    public void BallHitDog()
    {
        DogsRemaining += AddMoreDogsIfBallGetCaptured;
    }

    private void Awake()
    {
        if(Instance != null)
        {
            throw new InvalidOperationException("Only one Instance allowed");
        }

        Instance = this;
    }

    private void Start()
    {
        DogsRemaining = InitialDogsRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        var dogCount = GameObject.FindGameObjectsWithTag("Dog").Count();


        // Update text
        Score += dogCount;
        DogsLeftText.text = $"Dogs left: {DogsRemaining}";
        ScoreText.text = $"Score: {Score}";


        if(dogCount == 0 && DogsRemaining == 0)
        {
            LoseGame();
        }
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= LastDogSpawned + MinTimeBetweenDogs)
        {
            if(DogsRemaining > 0)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                DogsRemaining--;
                LastDogSpawned = Time.time;
            }
        }
    }

    private void LoseGame()
    {

        DogsLeftText.enabled = false;
        ScoreText.enabled = false;

        LoseGameText.text = "Lose game!";
        LoseGameText.enabled = true;

        RoundScoreText.text = $"Score: {Score}";
        RoundScoreText.enabled = true;
    }
}
