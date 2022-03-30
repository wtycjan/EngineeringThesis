using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Television : MonoBehaviour
{
	[SerializeField] private VideoPlayer videoPlayer;

    public void OnEnable()
    {
        videoPlayer.Play();
    }

    public void OnDisable()
    {
        videoPlayer.Stop();
    }
}
