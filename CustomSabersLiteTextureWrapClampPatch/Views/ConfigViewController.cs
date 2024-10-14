using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Settings;
using CustomSabersLiteTextureWrapClampPatch.Configuration;
using System;
using Zenject;


namespace CustomSabersLiteTextureWrapClampPatch.Views
{
    public class ConfigViewController : IInitializable, IDisposable
    {
        private bool _disposedValue;
        private readonly BSMLSettings _bSMLSettings;
        public string ResourceName => string.Join(".", GetType().Namespace, GetType().Name);
        public ConfigViewController(BSMLSettings bSMLSettings)
        {
            this._bSMLSettings = bSMLSettings;
        }
        public void Initialize()
        {
            this._bSMLSettings.AddSettingsMenu("<size=60%>CustomSabersLite TextureClamp</size>", this.ResourceName, this);
        }
        [UIValue("Enable")]
        public bool Enable
        {
            get => PluginConfig.Instance.Enable;
            set => PluginConfig.Instance.Enable = value;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    this._bSMLSettings?.RemoveSettingsMenu(this);
                }

                // TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
                // TODO: 大きなフィールドを null に設定します
                _disposedValue = true;
            }
        }
        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
