<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEXEffect
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ButSummon = New System.Windows.Forms.Button()
        Me.ButATK = New System.Windows.Forms.Button()
        Me.ButHP = New System.Windows.Forms.Button()
        Me.ButCOST = New System.Windows.Forms.Button()
        Me.ButAbility = New System.Windows.Forms.Button()
        Me.LbxEx = New System.Windows.Forms.ListBox()
        Me.ButOK = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'ButSummon
        '
        Me.ButSummon.Location = New System.Drawing.Point(12, 12)
        Me.ButSummon.Name = "ButSummon"
        Me.ButSummon.Size = New System.Drawing.Size(75, 23)
        Me.ButSummon.TabIndex = 0
        Me.ButSummon.Text = "召唤单位"
        Me.ButSummon.UseVisualStyleBackColor = true
        '
        'ButATK
        '
        Me.ButATK.Location = New System.Drawing.Point(12, 41)
        Me.ButATK.Name = "ButATK"
        Me.ButATK.Size = New System.Drawing.Size(75, 23)
        Me.ButATK.TabIndex = 1
        Me.ButATK.Text = "攻击变化"
        Me.ButATK.UseVisualStyleBackColor = true
        '
        'ButHP
        '
        Me.ButHP.Location = New System.Drawing.Point(12, 70)
        Me.ButHP.Name = "ButHP"
        Me.ButHP.Size = New System.Drawing.Size(75, 23)
        Me.ButHP.TabIndex = 2
        Me.ButHP.Text = "生命变化"
        Me.ButHP.UseVisualStyleBackColor = true
        '
        'ButCOST
        '
        Me.ButCOST.Location = New System.Drawing.Point(12, 99)
        Me.ButCOST.Name = "ButCOST"
        Me.ButCOST.Size = New System.Drawing.Size(75, 23)
        Me.ButCOST.TabIndex = 3
        Me.ButCOST.Text = "价值变化"
        Me.ButCOST.UseVisualStyleBackColor = true
        '
        'ButAbility
        '
        Me.ButAbility.Cursor = System.Windows.Forms.Cursors.Default
        Me.ButAbility.Location = New System.Drawing.Point(12, 128)
        Me.ButAbility.Name = "ButAbility"
        Me.ButAbility.Size = New System.Drawing.Size(75, 23)
        Me.ButAbility.TabIndex = 4
        Me.ButAbility.Text = "能力变化"
        Me.ButAbility.UseVisualStyleBackColor = true
        '
        'LbxEx
        '
        Me.LbxEx.FormattingEnabled = true
        Me.LbxEx.ItemHeight = 12
        Me.LbxEx.Location = New System.Drawing.Point(93, 12)
        Me.LbxEx.Name = "LbxEx"
        Me.LbxEx.Size = New System.Drawing.Size(179, 244)
        Me.LbxEx.TabIndex = 5
        '
        'ButOK
        '
        Me.ButOK.Location = New System.Drawing.Point(12, 157)
        Me.ButOK.Name = "ButOK"
        Me.ButOK.Size = New System.Drawing.Size(75, 99)
        Me.ButOK.TabIndex = 6
        Me.ButOK.Text = "确    定"
        Me.ButOK.UseVisualStyleBackColor = true
        '
        'FormEXEffect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 12!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.ButOK)
        Me.Controls.Add(Me.LbxEx)
        Me.Controls.Add(Me.ButAbility)
        Me.Controls.Add(Me.ButCOST)
        Me.Controls.Add(Me.ButHP)
        Me.Controls.Add(Me.ButATK)
        Me.Controls.Add(Me.ButSummon)
        Me.Name = "FormEXEffect"
        Me.Text = "额外效果设置……"
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents ButSummon As System.Windows.Forms.Button
    Friend WithEvents ButATK As System.Windows.Forms.Button
    Friend WithEvents ButHP As System.Windows.Forms.Button
    Friend WithEvents ButCOST As System.Windows.Forms.Button
    Friend WithEvents ButAbility As System.Windows.Forms.Button
    Friend WithEvents LbxEx As System.Windows.Forms.ListBox
    Private WithEvents ButOK As System.Windows.Forms.Button
End Class
