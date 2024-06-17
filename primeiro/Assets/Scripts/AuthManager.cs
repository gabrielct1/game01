using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Threading.Tasks;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class AuthManager : MonoBehaviour
{
    public async void Start() {
        await UnityServices.InitializeAsync();
    }

    public async void SignIn() {
        await SignInAnnonymous();
    }

    async Task SignInAnnonymous() {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            SceneManager.LoadScene(1);
            Debug.Log("Login bem-sucedido.\nPlayerId: " + AuthenticationService.Instance.PlayerId);

        }
        catch (AuthenticationException ex)
        {
            Debug.Log(ex);
        }
    }
}
