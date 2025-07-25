﻿using System;

using UnityEngine;

public enum SceneGame
{
    Menu,
    Loading,
    Penalty
}

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [Header("Manager References")]
    [SerializeField] private LoadingManager loadingManager = null;
    [SerializeField] private AudioManager audioManager = null;
    [SerializeField] private ApiClientManager apiClientManager = null;

    public LoadingManager LoadingManager => loadingManager;
    public AudioManager AudioManager => audioManager;
    public ApiClientManager ApiClientManager => apiClientManager;

    public override void Awake()
    {
        if (instance == null)
        {
            loadingManager.LoadingScene(SceneGame.Loading);
            audioManager.Init();
        }

        base.Awake();
    }

    public void ChangeScene(SceneGame nextScene, Action onComplete = null)
    {
        audioManager.StopCurrentMusic();
        loadingManager.TransitionScene(nextScene, onComplete);
    }
}