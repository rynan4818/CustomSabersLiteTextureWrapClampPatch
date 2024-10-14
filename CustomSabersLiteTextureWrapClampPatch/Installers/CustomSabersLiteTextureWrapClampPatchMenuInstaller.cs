using CustomSabersLiteTextureWrapClampPatch.Views;
using Zenject;

namespace CustomSabersLiteTextureWrapClampPatch.Installers
{
    public class CustomSabersLiteTextureWrapClampPatchMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            this.Container.BindInterfacesAndSelfTo<ConfigViewController>().AsSingle().NonLazy();
        }
    }
}