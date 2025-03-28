// #author 90135
// #name maid cafe LineBreakComment Fix
// #desc 修复女仆咖啡厅DLC弹幕文本换行时的字符串越界异常 Fixed maid cafe DLC string out-of-bounds exception when comment text wrapping
// #LICENSE The Unlicense
// #version 1.0.0
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
        // separate text safely
        int splitIndex = Mathf.Min(20, text.Length);
        string modifiedText = text.Substring(0, splitIndex) + "\n";

        // add a second line only if there is leftover text
        if (text.Length > 20) {
            modifiedText += text.Substring(20);
        }

        // keep original UI update logic
        __instance.m_commentText.text = modifiedText;

        // prevent original method execution
        return false;
    }
}