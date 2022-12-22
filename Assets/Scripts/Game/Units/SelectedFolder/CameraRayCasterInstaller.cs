using System;
using UnityEngine;
using Zenject;

namespace Split.Game.Units.SelectedFolder
{
    
    public class CameraRayCasterInstaller: MonoInstaller 
    {
        [SerializeField] private CameraRayCasterParams _cameraRayCasterParams;
        
        public override void InstallBindings()
        {
            Container.Bind<CameraRayCaster>().FromNewComponentOnNewGameObject().AsSingle().WithArguments(_cameraRayCasterParams);
        }
    }
}


