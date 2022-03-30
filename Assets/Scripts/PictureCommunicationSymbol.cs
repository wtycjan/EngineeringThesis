using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureCommunicationSymbol : InteractiveObject
{
    [SerializeField] private SpriteRenderer symbol;
    [SerializeField] private BoxCollider boxCollider;

    public override void PlayVideo()
    {
        base.PlayVideo();
        symbol.enabled = false;
        boxCollider.enabled = false;
    }

    public override void HideVideo()
    {
        base.HideVideo();
        symbol.enabled = true;
        boxCollider.enabled = true;
    }
}
