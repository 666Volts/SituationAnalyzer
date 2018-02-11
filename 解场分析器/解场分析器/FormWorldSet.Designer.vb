<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormWorldSet
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TbxHP = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TbxATK = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TbxTaunt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TbxShield = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TbxPoi = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TbxAF = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TbxCantRe = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "生命权重："
        '
        'TbxHP
        '
        Me.TbxHP.Location = New System.Drawing.Point(83, 6)
        Me.TbxHP.Name = "TbxHP"
        Me.TbxHP.Size = New System.Drawing.Size(189, 21)
        Me.TbxHP.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 226)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "保 存 ..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TbxATK
        '
        Me.TbxATK.Location = New System.Drawing.Point(83, 33)
        Me.TbxATK.Name = "TbxATK"
        Me.TbxATK.Size = New System.Drawing.Size(189, 21)
        Me.TbxATK.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "攻击权重："
        '
        'TbxTaunt
        '
        Me.TbxTaunt.Location = New System.Drawing.Point(83, 60)
        Me.TbxTaunt.Name = "TbxTaunt"
        Me.TbxTaunt.Size = New System.Drawing.Size(189, 21)
        Me.TbxTaunt.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "嘲讽权重："
        '
        'TbxShield
        '
        Me.TbxShield.Location = New System.Drawing.Point(83, 87)
        Me.TbxShield.Name = "TbxShield"
        Me.TbxShield.Size = New System.Drawing.Size(189, 21)
        Me.TbxShield.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "圣盾权重："
        '
        'TbxPoi
        '
        Me.TbxPoi.Location = New System.Drawing.Point(83, 114)
        Me.TbxPoi.Name = "TbxPoi"
        Me.TbxPoi.Size = New System.Drawing.Size(189, 21)
        Me.TbxPoi.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "剧毒权重："
        '
        'TbxAF
        '
        Me.TbxAF.Location = New System.Drawing.Point(83, 141)
        Me.TbxAF.Name = "TbxAF"
        Me.TbxAF.Size = New System.Drawing.Size(189, 21)
        Me.TbxAF.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "空军权重："
        '
        'TbxCantRe
        '
        Me.TbxCantRe.Location = New System.Drawing.Point(83, 168)
        Me.TbxCantRe.Name = "TbxCantRe"
        Me.TbxCantRe.Size = New System.Drawing.Size(189, 21)
        Me.TbxCantRe.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "不能反击："
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(93, 226)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(179, 23)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "恢 复 默 认 ....."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FormWorldSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TbxCantRe)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TbxAF)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TbxPoi)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TbxShield)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TbxTaunt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TbxATK)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TbxHP)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormWorldSet"
        Me.Text = "设置……"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TbxHP As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TbxATK As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TbxTaunt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TbxShield As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TbxPoi As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TbxAF As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TbxCantRe As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
