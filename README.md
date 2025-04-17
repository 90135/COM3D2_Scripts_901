[English](#english) | [简体中文](#%E7%AE%80%E4%BD%93%E4%B8%AD%E6%96%87)

[![Github All Releases](https://img.shields.io/github/downloads/90135/COM3D2_Scripts_901/total.svg)]()

# English
# COM3D2_Scripts_901

901's COM3D2 script collections

<br>

## Usage

1. You need the doc (krypto5863) version of [ScriptLoader.dll](https://github.com/krypto5863/BepInEx.ScriptLoader). Unfortunately, there is no easy way to determine whether it is a new version; [CMI](https://github.com/krypto5863/COM-Modular-Installer) from March 1, 2024 and later come with this version (CMI.2.5.21-RC3.zip)

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

1. 你需要 doc（krypto5863） 版本的 [ScriptLoader.dll](https://github.com/krypto5863/BepInEx.ScriptLoader)，很不幸没有简单的办法判断是不是新版；2024 年 3 月 1 日 及之后的 [CMI](https://github.com/krypto5863/COM-Modular-Installer) 内附带的都是此版本的（CMI.2.5.21-RC3.zip）

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

