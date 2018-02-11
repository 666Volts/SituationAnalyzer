<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.ButAddCom = New System.Windows.Forms.Button()
        Me.ButAddOpp = New System.Windows.Forms.Button()
        Me.ButAna = New System.Windows.Forms.Button()
        Me.ButRev = New System.Windows.Forms.Button()
        Me.ButClear = New System.Windows.Forms.Button()
        Me.ButRe = New System.Windows.Forms.Button()
        Me.ButGJ = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButAddCom
        '
        Me.ButAddCom.Location = New System.Drawing.Point(12, 12)
        Me.ButAddCom.Name = "ButAddCom"
        Me.ButAddCom.Size = New System.Drawing.Size(106, 23)
        Me.ButAddCom.TabIndex = 0
        Me.ButAddCom.Text = "添加我方单位"
        Me.ButAddCom.UseVisualStyleBackColor = True
        '
        'ButAddOpp
        '
        Me.ButAddOpp.Location = New System.Drawing.Point(124, 12)
        Me.ButAddOpp.Name = "ButAddOpp"
        Me.ButAddOpp.Size = New System.Drawing.Size(106, 23)
        Me.ButAddOpp.TabIndex = 1
        Me.ButAddOpp.Text = "添加对方单位"
        Me.ButAddOpp.UseVisualStyleBackColor = True
        '
        'ButAna
        '
        Me.ButAna.Location = New System.Drawing.Point(236, 12)
        Me.ButAna.Name = "ButAna"
        Me.ButAna.Size = New System.Drawing.Size(106, 23)
        Me.ButAna.TabIndex = 3
        Me.ButAna.Text = "进行解场分析"
        Me.ButAna.UseVisualStyleBackColor = True
        '
        'ButRev
        '
        Me.ButRev.Location = New System.Drawing.Point(572, 12)
        Me.ButRev.Name = "ButRev"
        Me.ButRev.Size = New System.Drawing.Size(106, 23)
        Me.ButRev.TabIndex = 5
        Me.ButRev.Text = "反转当前局面"
        Me.ButRev.UseVisualStyleBackColor = True
        '
        'ButClear
        '
        Me.ButClear.Location = New System.Drawing.Point(460, 12)
        Me.ButClear.Name = "ButClear"
        Me.ButClear.Size = New System.Drawing.Size(106, 23)
        Me.ButClear.TabIndex = 6
        Me.ButClear.Text = "清空全部局面"
        Me.ButClear.UseVisualStyleBackColor = True
        '
        'ButRe
        '
        Me.ButRe.Location = New System.Drawing.Point(348, 12)
        Me.ButRe.Name = "ButRe"
        Me.ButRe.Size = New System.Drawing.Size(106, 23)
        Me.ButRe.TabIndex = 7
        Me.ButRe.Text = "回到上一局面"
        Me.ButRe.UseVisualStyleBackColor = True
        '
        'ButGJ
        '
        Me.ButGJ.Location = New System.Drawing.Point(684, 12)
        Me.ButGJ.Name = "ButGJ"
        Me.ButGJ.Size = New System.Drawing.Size(88, 23)
        Me.ButGJ.TabIndex = 8
        Me.ButGJ.Text = "高级..."
        Me.ButGJ.UseVisualStyleBackColor = True
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 361)
        Me.Controls.Add(Me.ButGJ)
        Me.Controls.Add(Me.ButRe)
        Me.Controls.Add(Me.ButClear)
        Me.Controls.Add(Me.ButRev)
        Me.Controls.Add(Me.ButAna)
        Me.Controls.Add(Me.ButAddOpp)
        Me.Controls.Add(Me.ButAddCom)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMain"
        Me.Text = "解场分析器"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButAddCom As System.Windows.Forms.Button
    Friend WithEvents ButAddOpp As System.Windows.Forms.Button
    Friend WithEvents ButAna As System.Windows.Forms.Button
    Friend WithEvents ButRev As System.Windows.Forms.Button
    Friend WithEvents ButClear As System.Windows.Forms.Button
    Friend WithEvents ButRe As System.Windows.Forms.Button
    Friend WithEvents ButGJ As System.Windows.Forms.Button
End Class
