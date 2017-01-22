using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicBundle", menuName = "Music Bundle")]
public class MusicBundle : ScriptableObject
{
    public class TimeSection
    {
        public int Time { get; set; }
        public int BPM { get; set; }
        public int Subdivision { get; set; }
    }

    [SerializeField]
    private TextAsset _musicMetadata;

    [SerializeField]
    private AudioClip[] _musicTracks;

    private TimeSection[] _timeSections;
    
    public AudioClip[] Music { get { return _musicTracks; } }

    public TimeSection[] TimeSections { get { return _timeSections; } }

    public void Parse()
    {
        if (_musicMetadata == null)
            throw new NullReferenceException("_musicMetadata is null");

        _timeSections = JsonConvert.DeserializeObject<TimeSection[]>(_musicMetadata.text);
    }
}
