using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGame2 : MonoBehaviour
{
    // Exercise:
    // https://docs.google.com/document/d/1ETKuNvnYTug19tk2slPRDdXCEqbSnDeh5dL70o51kws/edit
    void Start()
    {
        // Mission 1 + 2
        int minValue = 1;
        int maxValue = 6;

        int randomInteger1 = UnityEngine.Random.Range(minValue, maxValue + 1);
        int randomInteger2 = UnityEngine.Random.Range(minValue, maxValue + 1);
        int randomInteger3 = UnityEngine.Random.Range(minValue, maxValue + 1);
        int TotalScore = (randomInteger1 + randomInteger2 + (randomInteger3 * 3)) * 2;

        Debug.LogFormat($"Random numbers: {randomInteger1}. {randomInteger2} and {randomInteger3}.");
        Debug.LogFormat("Random numbers: {0}, {1} and {2}", randomInteger1, randomInteger2, randomInteger3);
        Debug.LogFormat($"Total Score: {TotalScore}.");

        // Mission 3
        int TotalPins = 10;

        int PlayerThrow1 = TotalPins - UnityEngine.Random.Range(0, TotalPins + 1);
        int PlayerThrow2 = PlayerThrow1 - UnityEngine.Random.Range(0, PlayerThrow1 + 1);
        Debug.LogFormat($"First Throw: {PlayerThrow1}, Second Throw: {PlayerThrow2}");

        // Mission 4
        int MinimumShots = 10;
        int MaximumShots = 20;

        int TotalShots = UnityEngine.Random.Range(MinimumShots, MaximumShots + 1);
        int EnemyHits = UnityEngine.Random.Range(0, TotalShots + 1);
        double HitAccuracy = ((double)EnemyHits / (double)TotalShots) * 100;
        Debug.LogFormat($"Total shots: {TotalShots}, Enemy hits: {EnemyHits}, Accuracy: {HitAccuracy}");

        // Mission 5
        // references: 
        // https://en.wikipedia.org/wiki/Light-year
        // https://en.wikipedia.org/wiki/Alpha_Centauri#Distance_estimates
        double AlphaCentauriLightyear = 4.365;
        double ParsecPerLightyear = 0.306601;

        double AlphaCentauriParsec = AlphaCentauriLightyear * ParsecPerLightyear;
        Debug.LogFormat($"The distance between earth and Alpha Centauri is: {AlphaCentauriParsec} (pc).");

    }

}
