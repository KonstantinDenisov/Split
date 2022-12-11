using Zenject;

namespace Split.Game.Units.SelectedFolder
{
    public class CameraRayCasterInstaller: Installer<CameraRayCasterInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<CameraRayCaster>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}


