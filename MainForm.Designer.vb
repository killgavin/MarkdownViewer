<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.toolStrip = New System.Windows.Forms.ToolStrip()
        Me.btnOpen = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAbout = New System.Windows.Forms.ToolStripButton()
        Me.statusStrip = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.webBrowser = New System.Windows.Forms.WebBrowser()
        Me.toolStrip.SuspendLayout()
        Me.statusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolStrip
        '
        Me.toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpen, Me.toolStripSeparator1, Me.btnAbout})
        Me.toolStrip.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip.Name = "toolStrip"
        Me.toolStrip.Size = New System.Drawing.Size(1000, 25)
        Me.toolStrip.TabIndex = 0
        Me.toolStrip.Text = "工具列"
        '
        'btnOpen
        '
        Me.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(60, 22)
        Me.btnOpen.Text = "開啟檔案"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnAbout
        '
        Me.btnAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(36, 22)
        Me.btnAbout.Text = "關於"
        '
        'statusStrip
        '
        Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.statusStrip.Location = New System.Drawing.Point(0, 575)
        Me.statusStrip.Name = "statusStrip"
        Me.statusStrip.Size = New System.Drawing.Size(1000, 22)
        Me.statusStrip.TabIndex = 1
        Me.statusStrip.Text = "狀態列"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(96, 17)
        Me.lblStatus.Text = "準備就緒"
        '
        'webBrowser
        '
        Me.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webBrowser.Location = New System.Drawing.Point(0, 25)
        Me.webBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webBrowser.Name = "webBrowser"
        Me.webBrowser.Size = New System.Drawing.Size(1000, 550)
        Me.webBrowser.TabIndex = 2
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 597)
        Me.Controls.Add(Me.webBrowser)
        Me.Controls.Add(Me.statusStrip)
        Me.Controls.Add(Me.toolStrip)
        Me.Name = "MainForm"
        Me.Text = "Markdown 檢視器"
        Me.toolStrip.ResumeLayout(False)
        Me.toolStrip.PerformLayout()
        Me.statusStrip.ResumeLayout(False)
        Me.statusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Private WithEvents toolStrip As ToolStrip
    Private WithEvents btnOpen As ToolStripButton
    Private WithEvents toolStripSeparator1 As ToolStripSeparator
    Private WithEvents btnAbout As ToolStripButton
    Private WithEvents statusStrip As StatusStrip
    Private WithEvents lblStatus As ToolStripStatusLabel
    Private WithEvents webBrowser As WebBrowser

End Class
