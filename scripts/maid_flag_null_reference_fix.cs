// #author 90135
// #name TJSFuncGetMaidFlag Null Reference Fix
// #desc Used to fix an error caused by a certain plugin in business switching (switching to CM3D2 mode in COM3D2). Fixed a null reference exception in the ScriptManager.TJSFuncGetMaidFlag method, some plugin was causing it but I couldn't find it so I just patched the original game
// #desc 用于修复经营切替（在 COM3D2 中切换到 CM3D2 模式）中由某个插件导致的错误。修复 ScriptManager.TJSFuncGetMaidFlag 方法中的空引用异常，某个插件导致了它，但我找不到，所以我只是补丁原始游戏
// #LICENSE The Unlicense
// #version 1.0.0
using HarmonyLib;
using System;
using UnityEngine;

public static class MaidFlagNullReferenceFix
{
    static Harmony harmonyInstance;

    public static void Main()
    {
        harmonyInstance = Harmony.CreateAndPatchAll(typeof(MaidFlagNullReferenceFix));
    }

    public static void Unload()
    {
        if (harmonyInstance != null)
        {
            harmonyInstance.UnpatchSelf();
            harmonyInstance = null;
        }
    }

    [HarmonyPatch(typeof(ScriptManager), "TJSFuncGetMaidFlag")]
    [HarmonyPrefix]
    private static bool TJSFuncGetMaidFlagPrefix(TJSVariantRef[] param, TJSVariantRef result)
    {
        try
        {
            // First check if result is null
            if (result == null)
            {
                Debug.LogWarning("MaidFlagNullReferenceFix: result is null");
                return false;
            }

            // Parameter Check
            if (param == null || param.Length < 1)
            {
                Debug.LogWarning("MaidFlagNullReferenceFix: Invalid parameters");
                result.SetInteger(-1); // Set the default return value
                return false; // Skip the original method
            }

            int num = 0;
            string text = string.Empty;
            bool flag = false;

            // Get Parameters
            if (param.Length == 3)
            {
                num = param[0].AsInteger();
                text = param[1].AsString();
                if (param[2].AsBool())
                {
                    flag = true;
                }
            }
            else if (param.Length == 2)
            {
                num = param[0].AsInteger();
                text = param[1].AsString();
            }
            else
            {
                text = param[0].AsString();
            }

            // Check if GameMain.Instance is null
            if (GameMain.Instance == null)
            {
                Debug.LogError("MaidFlagNullReferenceFix: GameMain.Instance is null");
                result.SetInteger(-1);
                return false;
            }

            // Check if CharacterMgr is null
            if (GameMain.Instance.CharacterMgr == null)
            {
                Debug.LogError("MaidFlagNullReferenceFix: CharacterMgr is null");
                result.SetInteger(-1);
                return false;
            }

            // Get the Maid object and check if it is null
            Maid maid = GameMain.Instance.CharacterMgr.GetMaid(num);
            if (maid == null)
            {
                Debug.LogWarning($"MaidFlagNullReferenceFix: Maid with index {num} not found");
                result.SetInteger(-1);
                return false;
            }

            // Check if maid.status is null
            if (maid.status == null)
            {
                Debug.LogWarning($"MaidFlagNullReferenceFix: Maid status is null for maid {num}");
                result.SetInteger(-1);
                return false;
            }

            // Get the current script manager instance
            ScriptManager scriptManager = GameMain.Instance.ScriptMgr;
            if (scriptManager == null)
            {
                Debug.LogWarning("MaidFlagNullReferenceFix: ScriptManager instance is null");
                result.SetInteger(-1);
                return false;
            }

            // Set different flag values ​​according to compatibility mode
            if ((scriptManager.compatibilityMode || scriptManager.tjsLegacyMode) && !flag)
            {
                if (maid.status.OldStatus == null)
                {
                    Debug.LogWarning($"MaidFlagNullReferenceFix: OldStatus is null for maid {num}");
                    result.SetInteger(-1);
                    return false;
                }
                result.SetInteger(maid.status.OldStatus.GetFlag(text));
            }
            else
            {
                result.SetInteger(maid.status.GetFlag(text));
            }

            // Successfully obtain the flag value, skipping the original method
            return false;
        }
        catch (Exception ex)
        {
            Debug.LogError($"MaidFlagNullReferenceFix: Exception in patch: {ex.Message}\n{ex.StackTrace}");
            if (result != null)
            {
                result.SetInteger(-1);
            }
            return false;
        }
    }
}
