Public Class FormEXEffect
    Friend TempEnraged As List(Of Action)
    Friend TempDie As List(Of Action)
    Friend REnraged As List(Of Action)
    Friend RDie As List(Of Action)
    Private UList As List(Of GameWorld.Unit)
    Friend Sub New(ByRef ul As List(Of GameWorld.Unit))
        ' 此调用是设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        UList = ul
    End Sub
    Private Sub ButSummon_Click(sender As Object, e As EventArgs) Handles ButSummon.Click
        Select Case MsgBox("""确定""的话是亡语，否则是激怒效果。", MsgBoxStyle.OkCancel)
            Case MsgBoxResult.Ok
                Dim u As New GameWorld.Unit
                Dim fus As New FormUSet
                fus.ShowDialog()
                If fus.RUnit.HP = 0 Then Exit Sub
                u = fus.RUnit
                TempDie.Add(Sub()
                                UList.Add(u)
                            End Sub)
            Case Else
                Dim u As New GameWorld.Unit
                Dim fus As New FormUSet
                fus.ShowDialog()
                If fus.RUnit.HP = 0 Then Exit Sub
                u = fus.RUnit
        End Select
    End Sub
    Private Sub ButOK_Click(sender As Object, e As EventArgs) Handles ButOK.Click
        REnraged = TempEnraged
        RDie = TempDie
        Close()
    End Sub
End Class