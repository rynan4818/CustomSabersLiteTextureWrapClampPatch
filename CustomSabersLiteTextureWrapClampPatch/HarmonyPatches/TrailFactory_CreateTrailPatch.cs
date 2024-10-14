using HarmonyLib;
using System;
using CustomSabersLite.Components.Managers;
using CustomSabersLite.Components.Game;
using CustomSabersLiteTextureWrapClampPatch.Configuration;
using UnityEngine;
using CustomSabersLite.Data;

/// <summary>
/// See https://github.com/BepInEx/HarmonyX/wiki for a full reference on Harmony.
/// </summary>
namespace CustomSabersLiteTextureWrapClampPatch.HarmonyPatches
{
    /// <summary>
    /// This patches TrailFactory.CreateTrail
    /// </summary>
    [HarmonyPatch(typeof(TrailFactory), nameof(TrailFactory.CreateTrail), new Type[] { typeof(GameObject), typeof(CustomTrailData), typeof(float) })]
    public class TrailFactory_CreateTrailPatch
    {
        /// <summary>
        /// This code is run after the original code in MethodToPatch is run.
        /// </summary>
        /// <param name="__instance">The instance of ClassToPatch</param>
        /// <param name="arg1">The Parameter1Type arg1 that was passed to MethodToPatch</param>
        /// <param name="____privateFieldInClassToPatch">Reference to the private field in ClassToPatch named '_privateFieldInClassToPatch', 
        ///     added three _ to the beginning to reference it in the patch. Adding ref means we can change it.</param>
        static void Postfix(ref LiteSaberTrail __result)
        {
            if (PluginConfig.Instance.Enable)
            {
                __result._trailRenderer._meshRenderer.material.mainTexture.wrapMode = UnityEngine.TextureWrapMode.Clamp;
            }
        }
    }
}