using CustomSabersLite.Components.Game;
using CustomSabersLiteTextureWrapClampPatch.Configuration;
using HarmonyLib;
using UnityEngine;

namespace CustomSabersLiteTextureWrapClampPatch.HarmonyPatches
{
    [HarmonyPatch(typeof(LiteSaberModelController), nameof(LiteSaberModelController.SetColor))]
    public class LiteSaberModelController_PreInitPatch
    {
        static void Postfix(ref LiteSaberTrail[] ___customTrailInstances)
        {
            if (PluginConfig.Instance.Enable && ___customTrailInstances != null)
            {
                foreach (var customTrail in ___customTrailInstances)
                {
                    if (customTrail?._trailRenderer?._meshRenderer?.material?.mainTexture != null)
                    {
                        customTrail._trailRenderer._meshRenderer.material.mainTexture.wrapMode = TextureWrapMode.Clamp;
                    }
                }
            }
        }
    }
}
