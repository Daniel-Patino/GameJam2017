using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MusicSystem : MonoBehaviour
{
    #region Singleton
    private static MusicSystem _instance;
    private static object _creationLock = new object();
    private static bool _stillAlive = true;

    public static MusicSystem Instance
    {
        get
        {
            lock (_creationLock)
            {
                if (_instance != null)
                    return _instance;

                var objects = FindObjectsOfType<MusicSystem>();

                if (objects.Length > 0)
                {
                    _instance = objects[0];

                    if (objects.Length > 1)
                    {
                        for (int i = 1; i < objects.Length; ++i)
                            Destroy(objects[i].gameObject);
                    }

                    return _instance;
                }

                if (_stillAlive)
                {
                    var go = new GameObject();
                    go.name = typeof(MusicSystem).Name;
                    _instance = go.AddComponent<MusicSystem>();
                }
            }

            return _instance;
        }
    }

    void OnApplicationQuit()
    {
        _stillAlive = false;
    }
    #endregion

    [SerializeField]
    private MusicBundle[] _musicBundles;

    [SerializeField]
    private AudioSource _baseTrack;

    [SerializeField]
    private AudioSource _harmonyTrack;

    [SerializeField]
    private AudioSource _melodyTrack;

    private int _currentMusicBundle;
    private int _currentSectionIndex;
    private float _currentBeatDelay = 0f;

    public delegate void BeatEventHandler(object sender, EventArgs args);
    public event BeatEventHandler OnHandleEarlyBeat;
    public event BeatEventHandler OnHandleBeat;
    public event BeatEventHandler OnHandleLateBeat;

    public MusicBundle.TimeSection CurrentSection
    {
        get
        {
            return _currentSectionIndex >= 0 && 
                _currentSectionIndex < _musicBundles[_currentMusicBundle].TimeSections.Length ?
                _musicBundles[_currentMusicBundle].TimeSections[_currentSectionIndex] :
                null;
        }
    }

    #region Unity Lifecycle

    private void Start()
    {
        if (_musicBundles != null && _musicBundles.Length > 0)
        {
            foreach (var bundle in _musicBundles)
                bundle.Parse();

            _currentMusicBundle = 0;
            _currentSectionIndex = _musicBundles[_currentMusicBundle].TimeSections.Length - 1;
        }

        PlayMusic();
    }

    private IEnumerator HandleBeats()
    {
        var delayThreshold = _currentBeatDelay * (0.25f - float.Epsilon);
        var earlyBeatDelay = _currentBeatDelay - (delayThreshold * 2);

        var beatHandler = OnHandleBeat;
        var lateHandler = OnHandleLateBeat;
        var earlyHandler = OnHandleEarlyBeat;

        while (true)
        {
            if (beatHandler != null)
                beatHandler(this, EventArgs.Empty);

            yield return new WaitForSeconds(delayThreshold);

            if (lateHandler != null)
                lateHandler(this, EventArgs.Empty);

            yield return new WaitForSeconds(earlyBeatDelay);

            if (earlyHandler != null)
                earlyHandler(this, EventArgs.Empty);

            yield return new WaitForSeconds(delayThreshold);
        }
    }

    #endregion

    public void PlayMusic()
    {
        if (_musicBundles != null && _currentMusicBundle >= 0 && _currentSectionIndex >= 0)
        {
            var timeSection = _musicBundles[_currentMusicBundle].TimeSections[0];
            var bps = timeSection.BPM / 60f;
            _currentBeatDelay = 1f / bps;

            _baseTrack.clip = _musicBundles[_currentMusicBundle].Music[0];
            _baseTrack.Play();
            StartCoroutine(HandleBeats());
        }
    }
}
