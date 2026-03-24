Imports System.IO
Imports Markdig

Public Class MainForm
    ' Markdown 轉換器
    Private markdownPipeline As Markdig.MarkdownPipeline

    ' 目前開啟的檔案路徑
    Private currentFilePath As String = Nothing
    
    ' HTML 範本常數
    Private Const HtmlTemplate As String = "<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <base href='{1}'>
    <style>
        body {{ font-family: 'Microsoft JhengHei', '微軟正黑體', sans-serif; padding: 20px; }}
        h1, h2, h3, h4, h5, h6 {{ color: #333; }}
        code {{ background-color: #f4f4f4; padding: 2px 5px; border-radius: 3px; }}
        pre {{ background-color: #f4f4f4; padding: 10px; border-radius: 5px; overflow-x: auto; }}
        blockquote {{ border-left: 4px solid #ddd; padding-left: 15px; color: #666; }}
        img {{ max-width: 100%; height: auto; display: block; }}
        table {{ border-collapse: collapse; width: 100%; }}
        th, td {{ border: 1px solid #ddd; padding: 8px; text-align: left; }}
        th {{ background-color: #f2f2f2; }}
    </style>
</head>
<body>
{0}
</body>
</html>"

    ' 檔案大小限制（10 MB）
    Private Const MaxFileSizeBytes As Long = 10 * 1024 * 1024

    Public Sub New()
        InitializeComponent()
        ' 初始化 Markdown 管線
        markdownPipeline = New MarkdownPipelineBuilder().UseAdvancedExtensions().Build()
    End Sub

    ' 開啟檔案
    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "Markdown 檔案|*.md;*.markdown|所有檔案|*.*"
            openFileDialog.Title = "選擇 Markdown 檔案"

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                LoadMarkdownFile(openFileDialog.FileName)
            End If
        End Using
    End Sub

    ' 載入 Markdown 檔案
    Private Sub LoadMarkdownFile(filePath As String)
        Try
            ' 檢查檔案大小
            Dim fileInfo As New FileInfo(filePath)
            If fileInfo.Length > MaxFileSizeBytes Then
                MessageBox.Show($"檔案過大，無法載入。檔案大小限制為 {MaxFileSizeBytes / 1024 / 1024} MB。",
                                "錯誤",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning)
                Return
            End If

            Dim markdownContent As String = File.ReadAllText(filePath)
            Dim htmlContent As String = Markdown.ToHtml(markdownContent, markdownPipeline)

            ' 取得檔案所在目錄作為 base URL，以支援相對路徑圖片
            ' 使用 ToString() 而非 AbsoluteUri，避免中文路徑被 percent-encode 導致 WebBrowser 無法解析
            Dim baseUri As String = New Uri(Path.GetDirectoryName(filePath) & Path.DirectorySeparatorChar).ToString()

            ' 使用範本建立完整的 HTML 文件
            Dim fullHtml As String = String.Format(HtmlTemplate, htmlContent, baseUri)

            webBrowser.DocumentText = fullHtml
            currentFilePath = filePath
            btnRefresh.Enabled = True
            lblStatus.Text = $"已載入：{Path.GetFileName(filePath)}"
        Catch ex As Exception
            MessageBox.Show($"載入檔案時發生錯誤：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 關於對話框
    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        MessageBox.Show("Markdown 檢視器" & vbCrLf & vbCrLf &
                        "版本：1.1.0" & vbCrLf &
                        "使用 VB.NET Windows Forms 開發" & vbCrLf &
                        "支援標準 Markdown 語法",
                        "關於",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
    End Sub

    ' 重新整理（重新載入目前檔案）
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If currentFilePath IsNot Nothing AndAlso File.Exists(currentFilePath) Then
            LoadMarkdownFile(currentFilePath)
        Else
            MessageBox.Show("目前沒有開啟的檔案，或檔案已被刪除。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' 拖曳進入事件
    Private Sub MainForm_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim files As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            If files.Length = 1 Then
                Dim ext As String = Path.GetExtension(files(0)).ToLowerInvariant()
                If ext = ".md" OrElse ext = ".markdown" Then
                    e.Effect = DragDropEffects.Copy
                    Return
                End If
            End If
        End If
        e.Effect = DragDropEffects.None
    End Sub

    ' 拖曳放下事件
    Private Sub MainForm_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim files As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            If files.Length > 0 Then
                LoadMarkdownFile(files(0))
            End If
        End If
    End Sub
End Class
