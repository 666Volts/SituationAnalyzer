<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUSet
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
        Me.TbxATK = New System.Windows.Forms.TextBox()
        Me.TbxHP = New System.Windows.Forms.TextBox()
        Me.TbrATKC = New System.Windows.Forms.TrackBar()
        Me.CbxTaunt = New System.Windows.Forms.CheckBox()
        Me.CbxShield = New System.Windows.Forms.CheckBox()
        Me.CbxPoisonous = New System.Windows.Forms.CheckBox()
        Me.CbxAF = New System.Windows.Forms.CheckBox()
        Me.CbxCantRe = New System.Windows.Forms.CheckBox()
        Me.TbxEXB = New System.Windows.Forms.TextBox()
        Me.ButOK = New System.Windows.Forms.Button()
        Me.LblAC = New System.Windows.Forms.Label()
        Me.CbxDie = New System.Windows.Forms.CheckBox()
        CType(Me.TbrATKC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TbxATK
        '
        Me.TbxATK.Location = New System.Drawing.Point(12, 12)
        Me.TbxATK.Name = "TbxATK"
        Me.TbxATK.Size = New System.Drawing.Size(72, 21)
        Me.TbxATK.TabIndex = 0
        Me.TbxATK.Text = "ATK"
        '
        'TbxHP
        '
        Me.TbxHP.Location = New System.Drawing.Point(90, 12)
        Me.TbxHP.Name = "TbxHP"
        Me.TbxHP.Size = New System.Drawing.Size(182, 21)
        Me.TbxHP.TabIndex = 1
        Me.TbxHP.Text = "HP"
        '
        'TbrATKC
        '
        Me.TbrATKC.LargeChange = 4
        Me.TbrATKC.Location = New System.Drawing.Point(12, 39)
        Me.TbrATKC.Maximum = 4
        Me.TbrATKC.Name = "TbrATKC"
        Me.TbrATKC.Size = New System.Drawing.Size(260, 45)
        Me.TbrATKC.TabIndex = 2
        Me.TbrATKC.Value = 1
        '
        'CbxTaunt
        '
        Me.CbxTaunt.AutoSize = True
        Me.CbxTaunt.Location = New System.Drawing.Point(12, 68)
        Me.CbxTaunt.Name = "CbxTaunt"
        Me.CbxTaunt.Size = New System.Drawing.Size(48, 16)
        Me.CbxTaunt.TabIndex = 3
        Me.CbxTaunt.Text = "嘲讽"
        Me.CbxTaunt.UseVisualStyleBackColor = True
        '
        'CbxShield
        '
        Me.CbxShield.AutoSize = True
        Me.CbxShield.Location = New System.Drawing.Point(12, 112)
        Me.CbxShield.Name = "CbxShield"
        Me.CbxShield.Size = New System.Drawing.Size(48, 16)
        Me.CbxShield.TabIndex = 5
        Me.CbxShield.Text = "圣盾"
        Me.CbxShield.UseVisualStyleBackColor = True
        '
        'CbxPoisonous
        '
        Me.CbxPoisonous.AutoSize = True
        Me.CbxPoisonous.Location = New System.Drawing.Point(90, 112)
        Me.CbxPoisonous.Name = "CbxPoisonous"
        Me.CbxPoisonous.Size = New System.Drawing.Size(48, 16)
        Me.CbxPoisonous.TabIndex = 6
        Me.CbxPoisonous.Text = "剧毒"
        Me.CbxPoisonous.UseVisualStyleBackColor = True
        '
        'CbxAF
        '
        Me.CbxAF.AutoSize = True
        Me.CbxAF.Location = New System.Drawing.Point(164, 112)
        Me.CbxAF.Name = "CbxAF"
        Me.CbxAF.Size = New System.Drawing.Size(48, 16)
        Me.CbxAF.TabIndex = 8
        Me.CbxAF.Text = "空军"
        Me.CbxAF.UseVisualStyleBackColor = True
        '
        'CbxCantRe
        '
        Me.CbxCantRe.AutoSize = True
        Me.CbxCantRe.Location = New System.Drawing.Point(12, 157)
        Me.CbxCantRe.Name = "CbxCantRe"
        Me.CbxCantRe.Size = New System.Drawing.Size(72, 16)
        Me.CbxCantRe.TabIndex = 9
        Me.CbxCantRe.Text = "不能反击"
        Me.CbxCantRe.UseVisualStyleBackColor = True
        '
        'TbxEXB
        '
        Me.TbxEXB.Location = New System.Drawing.Point(90, 155)
        Me.TbxEXB.Name = "TbxEXB"
        Me.TbxEXB.Size = New System.Drawing.Size(182, 21)
        Me.TbxEXB.TabIndex = 10
        Me.TbxEXB.Text = "额外价值(比如抽卡效果算2费)"
        '
        'ButOK
        '
        Me.ButOK.Location = New System.Drawing.Point(63, 195)
        Me.ButOK.Name = "ButOK"
        Me.ButOK.Size = New System.Drawing.Size(149, 54)
        Me.ButOK.TabIndex = 11
        Me.ButOK.Text = "设置完成"
        Me.ButOK.UseVisualStyleBackColor = True
        '
        'LblAC
        '
        Me.LblAC.AutoSize = True
        Me.LblAC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblAC.Location = New System.Drawing.Point(204, 68)
        Me.LblAC.Name = "LblAC"
        Me.LblAC.Size = New System.Drawing.Size(65, 12)
        Me.LblAC.TabIndex = 12
        Me.LblAC.Text = "攻击次数:1"
        '
        'CbxDie
        '
        Me.CbxDie.AutoSize = True
        Me.CbxDie.Location = New System.Drawing.Point(90, 68)
        Me.CbxDie.Name = "CbxDie"
        Me.CbxDie.Size = New System.Drawing.Size(78, 16)
        Me.CbxDie.TabIndex = 13
        Me.CbxDie.Text = "激怒/亡语"
        Me.CbxDie.UseVisualStyleBackColor = True
        '
        'FormUSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.CbxDie)
        Me.Controls.Add(Me.LblAC)
        Me.Controls.Add(Me.ButOK)
        Me.Controls.Add(Me.TbxEXB)
        Me.Controls.Add(Me.CbxCantRe)
        Me.Controls.Add(Me.CbxAF)
        Me.Controls.Add(Me.CbxPoisonous)
        Me.Controls.Add(Me.CbxShield)
        Me.Controls.Add(Me.CbxTaunt)
        Me.Controls.Add(Me.TbrATKC)
        Me.Controls.Add(Me.TbxHP)
        Me.Controls.Add(Me.TbxATK)
        Me.Name = "FormUSet"
        Me.Text = "设置……"
        CType(Me.TbrATKC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TbxATK As System.Windows.Forms.TextBox
    Friend WithEvents TbxHP As System.Windows.Forms.TextBox
    Friend WithEvents TbrATKC As System.Windows.Forms.TrackBar
    Friend WithEvents CbxTaunt As System.Windows.Forms.CheckBox
    Friend WithEvents CbxShield As System.Windows.Forms.CheckBox
    Friend WithEvents CbxPoisonous As System.Windows.Forms.CheckBox
    Friend WithEvents CbxAF As System.Windows.Forms.CheckBox
    Friend WithEvents CbxCantRe As System.Windows.Forms.CheckBox
    Friend WithEvents TbxEXB As System.Windows.Forms.TextBox
    Friend WithEvents ButOK As System.Windows.Forms.Button
    Friend WithEvents LblAC As System.Windows.Forms.Label
    Friend WithEvents CbxDie As System.Windows.Forms.CheckBox
End Class
