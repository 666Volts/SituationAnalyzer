Public Class FormWorldSet

    Private Sub FormWorldSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TbxHP.Text = FormMain.MainGameWorld.HPValue
        TbxATK.Text = FormMain.MainGameWorld.ATKValue
        TbxTaunt.Text = FormMain.MainGameWorld.TauntValue
        TbxShield.Text = FormMain.MainGameWorld.ShieldValue
        TbxPoi.Text = FormMain.MainGameWorld.PoisonousValue
        TbxCantRe.Text = FormMain.MainGameWorld.CantReValue
        TbxAF.Text = FormMain.MainGameWorld.AFValue
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FormMain.MainGameWorld = GameWorld.WrdHearthStone.Clone
        TbxHP.Text = FormMain.MainGameWorld.HPValue
        TbxATK.Text = FormMain.MainGameWorld.ATKValue
        TbxTaunt.Text = FormMain.MainGameWorld.TauntValue
        TbxShield.Text = FormMain.MainGameWorld.ShieldValue
        TbxPoi.Text = FormMain.MainGameWorld.PoisonousValue
        TbxCantRe.Text = FormMain.MainGameWorld.CantReValue
        TbxAF.Text = FormMain.MainGameWorld.AFValue
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FormMain.MainGameWorld.HPValue = TbxHP.Text
        FormMain.MainGameWorld.ATKValue = TbxATK.Text
        FormMain.MainGameWorld.TauntValue = TbxTaunt.Text
        FormMain.MainGameWorld.ShieldValue = TbxShield.Text
        FormMain.MainGameWorld.PoisonousValue = TbxPoi.Text
        FormMain.MainGameWorld.CantReValue = TbxCantRe.Text
        FormMain.MainGameWorld.AFValue = TbxAF.Text
        Close()
    End Sub
End Class