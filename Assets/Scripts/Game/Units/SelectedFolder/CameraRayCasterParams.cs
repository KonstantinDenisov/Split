using System;
using UnityEngine.UI;
using UnityEngine;

namespace Split.Game.Units.SelectedFolder
{
    [Serializable] public class CameraRayCasterParams
    
    {
        [SerializeField] public LayerMask InteractiveObjects;
        [SerializeField] public Image FrameImage;
    }
}