<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTet
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tmrTet = New System.Windows.Forms.Timer(Me.components)
        Me.pnlTetPreview = New System.Windows.Forms.Panel()
        Me.pnlTetGame = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTetScore = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTetLevel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTetRows = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tmrTet
        '
        '
        'pnlTetPreview
        '
        Me.pnlTetPreview.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.pnlTetPreview.BackColor = System.Drawing.Color.Black
        Me.pnlTetPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlTetPreview.Location = New System.Drawing.Point(261, 259)
        Me.pnlTetPreview.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlTetPreview.Name = "pnlTetPreview"
        Me.pnlTetPreview.Size = New System.Drawing.Size(115, 67)
        Me.pnlTetPreview.TabIndex = 0
        '
        'pnlTetGame
        '
        Me.pnlTetGame.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTetGame.BackColor = System.Drawing.Color.Black
        Me.pnlTetGame.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlTetGame.Location = New System.Drawing.Point(14, 15)
        Me.pnlTetGame.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlTetGame.Name = "pnlTetGame"
        Me.pnlTetGame.Size = New System.Drawing.Size(238, 493)
        Me.pnlTetGame.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(261, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Score"
        '
        'lblTetScore
        '
        Me.lblTetScore.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTetScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTetScore.Font = New System.Drawing.Font("Microsoft JhengHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblTetScore.Location = New System.Drawing.Point(261, 30)
        Me.lblTetScore.Name = "lblTetScore"
        Me.lblTetScore.Size = New System.Drawing.Size(126, 43)
        Me.lblTetScore.TabIndex = 1
        Me.lblTetScore.Text = "0"
        Me.lblTetScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(261, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Level"
        '
        'lblTetLevel
        '
        Me.lblTetLevel.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTetLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTetLevel.Font = New System.Drawing.Font("Microsoft JhengHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblTetLevel.Location = New System.Drawing.Point(261, 88)
        Me.lblTetLevel.Name = "lblTetLevel"
        Me.lblTetLevel.Size = New System.Drawing.Size(126, 45)
        Me.lblTetLevel.TabIndex = 3
        Me.lblTetLevel.Text = "0"
        Me.lblTetLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(261, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Rows"
        '
        'lblTetRows
        '
        Me.lblTetRows.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTetRows.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTetRows.Font = New System.Drawing.Font("Microsoft JhengHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblTetRows.Location = New System.Drawing.Point(261, 148)
        Me.lblTetRows.Name = "lblTetRows"
        Me.lblTetRows.Size = New System.Drawing.Size(126, 49)
        Me.lblTetRows.TabIndex = 5
        Me.lblTetRows.Text = "0"
        Me.lblTetRows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(261, 240)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 15)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "NEXT"
        '
        'frmTet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 517)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.pnlTetGame)
        Me.Controls.Add(Me.lblTetRows)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.pnlTetPreview)
        Me.Controls.Add(Me.lblTetLevel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblTetScore)
        Me.Font = New System.Drawing.Font("Microsoft JhengHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmTet"
        Me.Text = "Tetris"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tmrTet As Timer
    Friend WithEvents pnlTetPreview As Panel
    Friend WithEvents pnlTetGame As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents lblTetRows As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblTetLevel As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTetScore As Label
    Friend WithEvents Label1 As Label
End Class
