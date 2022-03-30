using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField] private ObjectType type;
    [SerializeField] private List<Television> videos;

    public ObjectType ObjectType => type;
    public bool IsPlaying => videos.TrueForAll(x => x.gameObject.activeInHierarchy);

    public virtual void PlayVideo()
    {
        videos.ForEach(x => x.gameObject.SetActive(true));
    }

    public virtual void HideVideo()
    {
        videos.ForEach(x => x.gameObject.SetActive(false));
    }
}
