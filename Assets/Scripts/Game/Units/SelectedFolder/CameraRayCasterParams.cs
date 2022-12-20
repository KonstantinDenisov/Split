using System;
using UnityEngine.UI;
using UnityEngine;

namespace Split.Game.Units.SelectedFolder
{
    [Serializable] 
    public class CameraRayCasterParams
    {
        public LayerMask InteractiveObjects; 
        public Image FrameImage;
    }
}