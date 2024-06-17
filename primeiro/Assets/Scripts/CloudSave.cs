using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.CloudSave;
using Unity.Services.Core;
using System.Threading.Tasks;
using UnityEngine.UI;
using System;
using Unity.Services.Authentication;
using Unity.Services.CloudSave.Models;

public class CloudSave : MonoBehaviour
{
    public LogicScript logic;
    public void Start() {
        logic = GetComponent<LogicScript>();
    }

    public async void SaveData(int highestScore)
    {
        var data = new Dictionary<string, object>
        {
            ["highestScore"] = highestScore
        };

        await CloudSaveService.Instance.Data.ForceSaveAsync(data);
        Debug.Log("Data saved.");
    }
}