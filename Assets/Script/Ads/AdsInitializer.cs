using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    private const string _androidGameId = "5812253";
    private const string _iOSGameId = "5812252";
    [SerializeField] bool _testMode = true;

    private string _gameId;

    private void Awake()
    {
        this.InitializedAds();
    }

    private void InitializedAds()
    {
#if UNITY_IOS
        _gameId = _iOSGameId;
#elif UNITY_ANDROID
        _gameId = _androidGameId;
#elif UNITY_EDITOR
        _gameId = _androidGameId; //only for testing the functionality in editor
#endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
            Advertisement.Initialize(_gameId, _testMode, this);

    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete!");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unitty Ads initialization failed {error.ToString()} - {message}");
    }
}
