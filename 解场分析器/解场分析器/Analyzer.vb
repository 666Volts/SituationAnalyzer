Public Class FormMain
    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox("还是测试版！有Bug欢迎反馈！" & vbCrLf &
               "                                           by 车万伏特")
        MainGameWorld = GameWorld.WrdHearthStone.Clone
    End Sub
    Friend Shared MainGameWorld As GameWorld
    Friend Shared LastSituations As New Stack(Of GameWorld.Situation)
    Friend Shared CurrSituation As New GameWorld.Situation
    Private Sub ButAna_Click(sender As Object, e As EventArgs) Handles ButAna.Click
        Dim n = CurrSituation.SituationAna(MainGameWorld)
        If n IsNot Nothing Then
            Dim s = n.First.Value
            Dim fs As New FormS(s)
            fs.Present()
            fs.ShowDialog()
            If fs.RSituation IsNot Nothing Then
                LastSituations.Push(CurrSituation)
                CurrSituation = fs.RSituation
                SetFromS()
            End If
            s.Log = ""
        End If
    End Sub
    Private Sub ButAddCom_Click(sender As Object, e As EventArgs) Handles ButAddCom.Click
        Dim fus As New FormUSet
        fus.ShowDialog()
        If fus.RUnit.HP = 0 Then Exit Sub
        CurrSituation.AddMyUnit(fus.RUnit)
        SetFromS()
    End Sub
    Private Sub ButAddOpp_Click(sender As Object, e As EventArgs) Handles ButAddOpp.Click
        Dim fus As New FormUSet
        fus.ShowDialog()
        If fus.RUnit.HP = 0 Then Exit Sub
        CurrSituation.AddOpUnit(fus.RUnit)
        SetFromS()
    End Sub
    Private Sub ButRe_Click(sender As Object, e As EventArgs) Handles ButRe.Click
        If LastSituations.Count > 0 Then CurrSituation = LastSituations.Pop() : SetFromS()
    End Sub
    Private Sub ButClear_Click(sender As Object, e As EventArgs) Handles ButClear.Click
        LastSituations.Clear()
        CurrSituation = New GameWorld.Situation
        SetFromS()
    End Sub
    Private Sub ButRev_Click(sender As Object, e As EventArgs) Handles ButRev.Click
        CurrSituation.Reverse()
        SetFromS()
    End Sub
    Private Sub ButGJ_Click(sender As Object, e As EventArgs) Handles ButGJ.Click
        Dim f As New FormWorldSet
        f.ShowDialog()
    End Sub
    Friend Units As New List(Of UnitLabel)
    Friend Sub SetFromS()
        For Each u In Units
            u.Remove(Me)
        Next
        Units = New List(Of UnitLabel)
        For i = 0 To CurrSituation.MyUnits.Count - 1
            Dim u As New UnitLabel(CurrSituation.MyUnits(i), MainGameWorld)
            u.Left = Width - (i + 1) * 100
            u.Top = 60
            u.Update()
            u.Add(Me)
            Units.Add(u)
        Next
        For i = 0 To CurrSituation.OpUnits.Count - 1
            Dim u As New UnitLabel(CurrSituation.OpUnits(i), MainGameWorld)
            u.Left = i * 100
            u.Top = 280
            u.Update()
            u.Add(Me)
            Units.Add(u)
        Next
    End Sub
    Friend Class UnitLabel
        Private RelatedUnit As GameWorld.Unit
        Friend Left As Integer
        Friend Top As Integer
        Friend WithEvents BasicProperty As New Label
        Friend WithEvents ExtraProperty As New Label
        Sub New(ByVal ru As GameWorld.Unit, ByRef gw As GameWorld)
            RelatedUnit = ru
            Dim r = Math.Max(IIf((ru.Evaluate_Simple(gw) - ru.ExtraValue) * 30 > 255, 255,
                                 (ru.Evaluate_Simple(gw) - ru.ExtraValue) * 30), 0)
            Dim b = Math.Max(IIf(ru.ExtraValue * 30 > 255, 255, ru.ExtraValue * 30), 0)

            BasicProperty.ForeColor = Color.FromArgb(r, 0, b)
            BasicProperty.AutoSize = True
            BasicProperty.Font = New Drawing.Font("宋体", 19)
            ExtraProperty.ForeColor = Color.FromArgb(r, 0, b)
            ExtraProperty.AutoSize = True
            ExtraProperty.Font = New Drawing.Font("宋体", 10)
            Update()
        End Sub
        Friend Sub Update()
            BasicProperty.Text = RelatedUnit.ATK & " / " & RelatedUnit.HP
            ExtraProperty.Text = RelatedUnit.GetTip
            BasicProperty.Left = Left
            BasicProperty.Top = Top
            ExtraProperty.Left = Left
            ExtraProperty.Top = Top + BasicProperty.Height
        End Sub
        Friend Sub Add(ByRef f As Form)
            f.Controls.Add(BasicProperty)
            f.Controls.Add(ExtraProperty)
        End Sub
        Friend Sub Remove(ByRef f As Form)
            f.Controls.Remove(BasicProperty)
            f.Controls.Remove(ExtraProperty)
        End Sub
    End Class
    Friend Class FormS
        Inherits Form
        Friend RSituation As GameWorld.Situation
        Friend WithEvents ButOK As New Button With {.Text = "保存", .Left = 200, .Top = 200, .Width = 50, .Height = 30}
        Friend WithEvents ButCancel As New Button With {.Text = "取消", .Left = 260, .Top = 200, .Width = 50, .Height = 30}
        Private temps As GameWorld.Situation
        Sub New(ByRef s As GameWorld.Situation)
            temps = s
            Width = 800
            Height = 400
            Controls.Add(ButOK)
            Controls.Add(ButCancel)
        End Sub
        Private Sub ButOK_Click(sender As Object, e As EventArgs) Handles ButOK.Click
            RSituation = temps
            Close()
        End Sub
        Private Sub ButCancel_Click(sender As Object, e As EventArgs) Handles ButCancel.Click
            Close()
        End Sub
        Friend Sub Present()
            For i = 0 To temps.MyUnits.Count - 1
                Dim u As New UnitLabel(temps.MyUnits(i), MainGameWorld)
                u.Left = Width - (i + 1) * 100
                u.Top = 60
                u.Update()
                u.Add(Me)
            Next
            For i = 0 To temps.OpUnits.Count - 1
                Dim u As New UnitLabel(temps.OpUnits(i), MainGameWorld)
                u.Left = i * 100
                u.Top = 280
                u.Update()
                u.Add(Me)
            Next
        End Sub
        Private Sub FormS_Shown(sender As Object, e As EventArgs) Handles Me.Shown
            MsgBox(temps.Log)
        End Sub
    End Class
End Class