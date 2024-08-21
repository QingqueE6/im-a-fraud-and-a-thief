using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGame1 : MonoBehaviour
{
    // exercise:
    // https://docs.google.com/document/d/1mYa6-e4SeYdFVyx7RdEMNDMPvQsWBQt2yWzWYpqSCxw/edit

    // Mission 3

    private string UserSystem = System.Environment.OSVersion.VersionString;
    public void SystemCheck(string OperatingSystem)
    {
        var result = UserSystem.Contains(OperatingSystem) ? true : false;
        Debug.Log($"You are using {OperatingSystem}: " + result);
    }

    // Start is called before the first frame update
    void Start()
    {
        SystemCheck("Windows");
        SystemCheck("Linux");
        SystemCheck("Mac");
    }

}

