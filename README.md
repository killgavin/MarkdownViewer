# Markdown 檢視器 (MarkdownViewer)

使用 VB.NET Windows Forms 開發的 Markdown 文件檢視軟體。

## 專案簡介

Markdown 檢視器是一個簡單易用的桌面應用程式，可以開啟並預覽 Markdown 格式的文件。本專案採用 SDD（軟體設計文件）方式開發，並使用正體中文介面。

## 主要功能

- ✅ 開啟並顯示 Markdown 檔案
- ✅ 支援完整的 Markdown 語法（包括表格、程式碼區塊等）
- ✅ 即時 HTML 渲染與預覽
- ✅ 友善的正體中文使用者介面
- ✅ 狀態列顯示當前檔案資訊

## 技術規格

- **開發語言：** VB.NET
- **應用框架：** Windows Forms (.NET 10.0)
- **Markdown 引擎：** Markdig 0.37.0
- **目標平台：** Windows
- **介面語言：** 正體中文（Traditional Chinese）

## 系統需求

- Windows 10 或更新版本
- .NET 10.0 Runtime

## 開發環境設定

### 必要工具

- .NET SDK 10.0 或更新版本
- Visual Studio 2022 或 Visual Studio Code（選用）

### 建置專案

```bash
# 還原相依套件
dotnet restore

# 建置專案
dotnet build

# 執行程式
dotnet run
```

## 使用說明

1. 啟動程式後，點選工具列上的「開啟檔案」按鈕
2. 在檔案選擇對話框中選擇 Markdown 檔案（.md 或 .markdown）
3. 選擇的檔案內容會立即轉換為 HTML 並顯示在視窗中
4. 狀態列會顯示當前已載入的檔案名稱

## 專案結構

```
MarkdownViewer/
├── Program.vb              # 程式進入點
├── MainForm.vb             # 主視窗邏輯
├── MainForm.Designer.vb    # 主視窗介面設計
├── MarkdownViewer.vbproj   # 專案設定檔
├── 範例.md                  # 範例 Markdown 檔案
├── README.md               # 專案說明文件
└── 軟體設計文件.md          # 軟體設計文件 (SDD)
```

## 軟體設計文件

詳細的軟體設計文件請參閱 [軟體設計文件.md](軟體設計文件.md)。

## 開發歷程

本專案採用迭代式開發，每個階段的修改都會推送至版本控制系統。開發階段包括：

1. **專案初始化** - 建立 VB.NET Windows Forms 專案
2. **核心功能開發** - 實作 Markdown 載入與顯示功能
3. **介面優化** - 完善正體中文使用者介面
4. **測試與文件** - 建立測試檔案與說明文件

## 授權條款

本專案採用開源授權，詳細資訊請參閱 LICENSE 檔案。

## 貢獻指南

歡迎提交 Issue 或 Pull Request 來改進本專案。

## 聯絡資訊

如有任何問題或建議，歡迎透過 GitHub Issues 回報。
