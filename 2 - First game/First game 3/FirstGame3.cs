using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstGame3 : MonoBehaviour
{
    // Hey hey hey little bro, check this out *does a flip*
    // https://docs.google.com/document/d/16xGzHvDWZtjLKQTjK4y9w55150aM0Uw4zaC4YpzICVw/edit
    // Because im kinda cool I wanna break down many of these loops etc to methods for next time and make the code a lil cleaner overall
    void Start()
    {
    // MissionOne();
    // MissionTwo();
    // MissionThree();
    MissionFantasticFour();
    }
    static void MissionOne(){
        int TotalPins = 10;
        int PlayerThrow1 = TotalPins - UnityEngine.Random.Range(0, TotalPins + 1);
        int PlayerThrow2 = UnityEngine.Random.Range(0, TotalPins + 1 - PlayerThrow1);
        int Total = PlayerThrow1 + PlayerThrow2;

        string PlayerThrow1Symbol = PlayerThrow1 == TotalPins ? "X" : $"{PlayerThrow1}";
        string PlayerThrow2Symbol = Total == TotalPins ? "/" : $"{PlayerThrow2}";

        Debug.LogFormat($"First Throw: {PlayerThrow1Symbol}");
        if(PlayerThrow2 != 0)
        {
            Debug.LogFormat($"Second Throw: {PlayerThrow2Symbol}");
        }
        Debug.LogFormat($"Knocked Pins: {Total}");
    }

    static void MissionTwo(){
        int WarriorHp = UnityEngine.Random.Range(1, 101);
        string StartingCast = WarriorHp >= 50 ? "The Warrior's HP is too high! Interrupting Regenerate." : "Starting Regenerate cast . . .";

        Debug.Log(StartingCast);
        while (WarriorHp <= 50)
        {
            WarriorHp += 10;
            Debug.LogFormat($"Warrior HP: {WarriorHp}");
            if (WarriorHp >= 50)
            {
                Debug.Log("Regenerate cast complete!");
            }
        }
    }

    static void MissionThree(){
        int Total = 0;
        bool NotSix = true;
        while (NotSix)
        {
            int DiceRoll = UnityEngine.Random.Range(1, 7);
            Debug.LogFormat($"The player rolls: {DiceRoll}");
            Total += DiceRoll;

            if (DiceRoll == 6)
            {
                NotSix = false;
                Debug.LogFormat($"Total: {Total}");
            }
        }
    }

    static void MissionFantasticFour(){
        int SpawnAmount = 100;
        int CharacterStrength = 0;
        int SlimeArmyHp = 0;
        int SingleSlimeHp = 40;

        for (int x = 0; x < 3; x++)
        {
            int StrengthRoll = UnityEngine.Random.Range(1, 7);
            CharacterStrength += StrengthRoll;
        }

        for (int z = 0; z < 8; z++)
        {
            int HpRoll = UnityEngine.Random.Range(1, 11);
            SingleSlimeHp += HpRoll;
        } 

        for (int y = 0; y < SpawnAmount; y++)
        {   
            int SlimeHp = 40;

            for (int z = 0; z < 8; z++)
            {
                int HpRoll = UnityEngine.Random.Range(1, 11);
                SlimeHp += HpRoll;
            } 
            SlimeArmyHp += SlimeHp;
        }
        Debug.LogFormat($"Character strength: {CharacterStrength}");
        Debug.LogFormat($"Slime army HP: {SlimeArmyHp}");
        Debug.LogFormat($"One Mr. Slime has {SingleSlimeHp} HP, i didnt wanna print out 100 slimes' HP :)");
    }
}

