using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private void OnEnable()
    {
        MusicSystem.Instance.OnHandleBeat += OnHandleBeat;
        MusicSystem.Instance.OnHandleEarlyBeat += OnHandleEarly;
        MusicSystem.Instance.OnHandleLateBeat += OnHandleLate;
    }

    private void OnDisable()
    {
        MusicSystem.Instance.OnHandleBeat -= OnHandleBeat;
        MusicSystem.Instance.OnHandleEarlyBeat -= OnHandleEarly;
        MusicSystem.Instance.OnHandleLateBeat -= OnHandleLate;
    }

    private void OnHandleLate(object sender, EventArgs args)
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    private void OnHandleEarly(object sender, EventArgs args)
    {
        GetComponent<MeshRenderer>().material.color = Color.green;
    }

    private void OnHandleBeat(object sender, EventArgs args)
    {
    }
}
