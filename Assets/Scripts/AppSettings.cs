using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Bathroom,
    Toilet,
    Patio,
    Lockers,
    Sink,
    Mirror
}

[System.Serializable]
public struct PcsSound
{
    public ObjectType objectType;
    public AudioClip sound;
}

[CreateAssetMenu(fileName = "AppSettings", menuName = "Settings/AppSettings")]
public class AppSettings : ScriptableObject
{
    [SerializeField] private List<PcsSound> sounds;
    [SerializeField] private LayerMask interactiveObjectLayer;
    [SerializeField] private LayerMask videoLayer;
    [SerializeField] private float raycastLength;
    [SerializeField] private float timeToShowVideo;
    [SerializeField] private float timeToHideVideo;

    public List<PcsSound> Sounds => sounds;
    public LayerMask InteractiveObjectLayer => interactiveObjectLayer;
    public LayerMask VideoLayer => videoLayer;
    public float RaycastLength => raycastLength;
    public float TimeToShowVideo => timeToShowVideo;
    public float TimeToHideVideo => timeToHideVideo;
}
