[English](#english) | [简体中文](#%E7%AE%80%E4%BD%93%E4%B8%AD%E6%96%87)

[![Github All Releases](https://img.shields.io/github/downloads/90135/COM3D2_Scripts_901/total.svg)]()

# English
# COM3D2_Scripts_901

901's COM3D2 script collections

<br>

## Usage

1. You need the doc (krypto5863) version of [ScriptLoader.dll](https://github.com/krypto5863/BepInEx.ScriptLoader)

    Unfortunately there is no easy way to tell if it is the doc version
    
    This version is included with [CMI](https://github.com/krypto5863/COM-Modular-Installer) from March 1, 2024 onwards (CMI.2.5.21-RC3.zip)
    
    If your plugin was created before 2024, it is almost certainly not the doc version.

2. Download the compressed package from Release and put the `script.cs` you want in the package into `COM3D2\scripts`

    If you really don't know, the Github download is usually in the [Releases](https://github.com/90135/COM3D2_Scripts_901/releases) tab on the right side of the repository homepage. After clicking Releases, there is a download in the Assets tab;
    
    If you want to download the entire repository, click the green Code button on the repository homepage, and then click Download ZIP.

## Script Description

### maid_cafe_line_break_fix.cs

This is used to fix the bug that the bullet screen of Maid Cafe DLC sometimes stops scrolling after translation.


<img src="https://github.com/user-attachments/assets/ee428b39-5e1a-4566-a516-ea50dccb1bc1" width="500"/>

```
[Error  : Unity Log] ArgumentOutOfRangeException: startIndex + length > this.length
Parameter name: length
Stack trace:
string string.Substring(int startIndex, int length)
void MaidCafe.MaidCafeComment.LineBreakComment(string text)
void MaidCafe.MaidCafeComment.UpdateCommentSize(int commentNum)
void MaidCafe.MaidCafeStreamManager.Update()
```

<br>

### maid_flag_null_reference_fix.cs

Used to fix a bug in the business switch (switching to CM3D2 mode in COM3D2) caused by a plugin.

The game works fine after disabling all plugins, so it should be caused by a plugin, but I can't find it, so I chose to patch the original game

```
[Error  : Unity Log] NullReferenceException: Object reference not set to an instance of an object
Stack trace:
void ScriptManager.TJSFuncGetMaidFlag(TJSVariantRef[] param, TJSVariantRef result)
void TJSScript.CallFunction(TJSParamAccess param_access, IntPtr result_ptr)
void TJSFunctionEvent.StaticFunction(IntPtr param_access_ptr, IntPtr result)
bool DLLKagScript.Exec(ref Data data)
bool BaseKagManager.Exec()
void BaseKagManager.Update()
void ScriptManager.Update()
void GameMain.Update()
```


## Other Repositories

You can also check out my other repositories

- [COM3D2 Simple MOD Guide Chinese](https://github.com/90135/COM3D2_Simple_MOD_Guide_Chinese)
- [COM3D2 MOD Editor](https://github.com/90135/COM3D2_MOD_EDITOR)
- [COM3D2 Plugin Chinese Translation](https://github.com/90135/COM3D2_Plugin_Translate_Chinese)
- [90135's COM3D2 Chinese Guide](https://github.com/90135/COM3D2_GUIDE_CHINESE)
- [90135's COM3D2 Script Collection](https://github.com/90135/COM3D2_Scripts_901)

<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>



# 简体中文
# 901 的 COM3D2 脚本收藏集

虽然叫收藏集，但是都是自制 “脚本”

<br>

## 用法

1. 你需要 doc（krypto5863） 版本的 [ScriptLoader.dll](https://github.com/krypto5863/BepInEx.ScriptLoader)
   
    很不幸没有简单的办法判断是不是 doc 版本的
    
    2024 年 3 月 1 日 及之后的 [CMI](https://github.com/krypto5863/COM-Modular-Installer) 内附带的都是此版本的（CMI.2.5.21-RC3.zip）
  
    如果你的插件的创建日期早于 2024 年之前，那么它几乎肯定不是 doc 版本的。
    
2. 到 Release 下载压缩包，把包内你想要的 `脚本.cs` 放到 `COM3D2\scripts`
    
    如果你真的不知道，Github 下载一般在仓库主页右边的 [Releases](https://github.com/90135/COM3D2_Scripts_901/releases) 标签中，点进去 Releases 后，在 Assets 标签中有下载；
    
    如果要下载整个仓库，点击仓库主页绿色的 Code 按钮，然后点击 Download ZIP。

<br>


## 脚本说明

### maid_cafe_line_break_fix.cs

用于修复 女仆咖啡厅 DLC 翻译后弹幕有时候会停止滚动的错误。

<img src="https://github.com/user-attachments/assets/ee428b39-5e1a-4566-a516-ea50dccb1bc1" width="500"/>

```
[Error  : Unity Log] ArgumentOutOfRangeException: startIndex + length > this.length
Parameter name: length
Stack trace:
string string.Substring(int startIndex, int length)
void MaidCafe.MaidCafeComment.LineBreakComment(string text)
void MaidCafe.MaidCafeComment.UpdateCommentSize(int commentNum)
void MaidCafe.MaidCafeStreamManager.Update()
```

<br>

### maid_flag_null_reference_fix.cs

用于修复经营切替（在 COM3D2 中切换到 CM3D2 模式）中由某个插件导致的错误。

禁用所有插件后游戏正常，所以它应当是某个插件引起的，但我找不到它，所以我选择对原始游戏打补丁

```
[Error  : Unity Log] NullReferenceException: Object reference not set to an instance of an object
Stack trace:
void ScriptManager.TJSFuncGetMaidFlag(TJSVariantRef[] param, TJSVariantRef result)
void TJSScript.CallFunction(TJSParamAccess param_access, IntPtr result_ptr)
void TJSFunctionEvent.StaticFunction(IntPtr param_access_ptr, IntPtr result)
bool DLLKagScript.Exec(ref Data data)
bool BaseKagManager.Exec()
void BaseKagManager.Update()
void ScriptManager.Update()
void GameMain.Update()
```


## 也可以看看我的其他仓库

- [COM3D2 简明 MOD 教程中文](https://github.com/90135/COM3D2_Simple_MOD_Guide_Chinese)
- [COM3D2 MOD 编辑器](https://github.com/90135/COM3D2_MOD_EDITOR)
- [COM3D2 插件中文翻译](https://github.com/90135/COM3D2_Plugin_Translate_Chinese)
- [90135 的 COM3D2 中文指北](https://github.com/90135/COM3D2_GUIDE_CHINESE)
- [90135 的 COM3D2 脚本收藏集](https://github.com/90135/COM3D2_Scripts_901)


