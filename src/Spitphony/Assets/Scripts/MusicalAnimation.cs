using DragonBones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(UnityArmatureComponent))]
public class MusicalAnimation : MonoBehaviour
{
    [SerializeField]
    private UnityArmatureComponent _armature = null;

    private int _currentAnimIndex = -1;

    private void Start()
    {
        if (_armature != null && _armature.animation.animations.Count > 0)
        {
            _currentAnimIndex = 0;

            _armature.animation.Stop();
        }
    }

    void OnEnable()
    {
        MusicSystem.Instance.OnHandleBeat += OnHandleBeat;
    }

     void OnDisable()
    {
        MusicSystem.Instance.OnHandleBeat -= OnHandleBeat;
    }

    private void OnHandleBeat(object sender, EventArgs args)
    {
        if (_armature != null && _armature.animation.animations.Count > 0)
        {
            var animName = _armature.animation.animationNames[_currentAnimIndex++];
            _armature.animation.Play(animName, 1);

            if (_currentAnimIndex >= _armature.animation.animations.Count)
                _currentAnimIndex = 0;
        }
    }
}
