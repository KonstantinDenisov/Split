﻿using Split.Infrastructure.GameController;
using Zenject;

namespace Split.Game.Units.SelectedFolder
{
    public class SelectedServiceInstaller : Installer<SelectedServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ISelectedService>().To<SelectedService>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}