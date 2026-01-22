Imports System.IO
Imports Markdig

Public Class MainForm
    ' Markdown 轉換器
    Private markdownPipeline As Markdig.MarkdownPipeline

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
            Dim markdownContent As String = File.ReadAllText(filePath)
            Dim htmlContent As String = Markdown.ToHtml(markdownContent, markdownPipeline)

            ' 建立完整的 HTML 文件
            Dim fullHtml As String = $"<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <style>
        body {{ font-family: 'Microsoft JhengHei', '微軟正黑體', sans-serif; padding: 20px; }}
        h1, h2, h3, h4, h5, h6 {{ color: #333; }}
        code {{ background-color: #f4f4f4; padding: 2px 5px; border-radius: 3px; }}
        pre {{ background-color: #f4f4f4; padding: 10px; border-radius: 5px; overflow-x: auto; }}
        blockquote {{ border-left: 4px solid #ddd; padding-left: 15px; color: #666; }}
        table {{ border-collapse: collapse; width: 100%; }}
        th, td {{ border: 1px solid #ddd; padding: 8px; text-align: left; }}
        th {{ background-color: #f2f2f2; }}
    </style>
</head>
<body>
{htmlContent}
</body>
</html>"

            webBrowser.DocumentText = fullHtml
            lblStatus.Text = $"已載入：{Path.GetFileName(filePath)}"
        Catch ex As Exception
            MessageBox.Show($"載入檔案時發生錯誤：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 關於對話框
    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        MessageBox.Show("Markdown 檢視器" & vbCrLf & vbCrLf &
                        "版本：1.0.0" & vbCrLf &
                        "使用 VB.NET Windows Forms 開發" & vbCrLf &
                        "支援標準 Markdown 語法",
                        "關於",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
    End Sub
End Class
