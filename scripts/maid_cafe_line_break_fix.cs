// #author 90135
// #name maid cafe LineBreakComment Fix
// #desc 修复女仆咖啡厅DLC弹幕文本换行时的字符串越界异常 Fixed maid cafe DLC string out-of-bounds exception when comment text wrapping
// #LICENSE The Unlicense
// #version 1.0.3
using HarmonyLib;
using MaidCafe;
using UnityEngine;
using UnityEngine.UI;

public static class LineBreakCommentFix
{
    static Harmony harmonyInstance;

    public static void Main()
    {
        harmonyInstance = Harmony.CreateAndPatchAll(typeof(LineBreakCommentFix));
    }

    public static void Unload()
    {
        if (harmonyInstance != null){
            harmonyInstance.UnpatchSelf();
            harmonyInstance = null;
        }
    }

    [HarmonyPatch(typeof(MaidCafeComment), "LineBreakComment")]
    [HarmonyPrefix]
    private static bool LineBreakCommentPrefix(MaidCafeComment __instance, string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            __instance.m_commentText.text = string.Empty;
            return false;
        }

        try
        {
            // separate text safely
            int splitIndex = Mathf.Min(20, text.Length);
            string modifiedText = text.Substring(0, splitIndex);

            // add a second line only if there is leftover text
            if (splitIndex < text.Length) {
                modifiedText += "\n" + text.Substring(splitIndex);
            }

            // keep original UI update logic
            __instance.m_commentText.text = modifiedText;
        } catch (System.Exception e) {
            const int FALLBACK_MAX_LENGTH = 30;
            string fallbackText = text ?? string.Empty;
            string safeText = fallbackText.Length > FALLBACK_MAX_LENGTH
                ? fallbackText.Substring(0, FALLBACK_MAX_LENGTH) + "..."
                : fallbackText;

            __instance.m_commentText.text = safeText;


            Debug.LogError($"LineBreakCommentPrefix failed (input: '{text}'): {e}");
        }

        // prevent original method execution
        return false;
    }

    // There is a same methon in MaidCafeSuperChatComment
    [HarmonyPatch(typeof(MaidCafeSuperChatComment), "LineBreakComment")]
    [HarmonyPrefix]
    private static bool SuperChatLineBreakCommentPrefix(MaidCafeComment __instance, string text)
    {
        return LineBreakCommentPrefix(__instance, text);
    }
}
