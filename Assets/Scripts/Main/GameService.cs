using ServiceLocator.Events;
using ServiceLocator.Map;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Utilities;
using ServiceLocator.Wave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    public PlayerService playerService { get; private set; } //public get and private set. Anyone can get but everyone cannot set.
    public SoundService soundService { get; private set; }
    public WaveService waveService { get; private set; }
    public EventService eventService { get; private set; }
    public MapService mapService { get; private set; }

    [SerializeField] private UIService uIService;
    public UIService UIService=>uIService;

    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    [SerializeField] private SoundScriptableObject soundScriptableObject;
    [SerializeField] private WaveScriptableObject waveScriptableObject;
    [SerializeField] private MapScriptableObject mapScriptableObject;

    [SerializeField ]private AudioSource audioEffects;
    [SerializeField ]private AudioSource backgroundMusic;

    private void Start()
    {
        eventService = new EventService();
        UIService.SubscribeToEvents();
        playerService = new PlayerService(playerScriptableObject);
        mapService = new MapService(mapScriptableObject);
        soundService = new SoundService(soundScriptableObject, audioEffects, backgroundMusic);
        waveService = new WaveService(waveScriptableObject);
    }

    private void Update()
    {
        playerService.Update();
    }
}
