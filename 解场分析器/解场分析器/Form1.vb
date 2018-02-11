Public Class FormUSet
    Friend RUnit As GameWorld.Unit
    Private Sub TbrATKC_Scroll(sender As Object, e As EventArgs) Handles TbrATKC.Scroll
        LblAC.Text = TbrATKC.Value
    End Sub
    Private Sub ButOK_Click(sender As Object, e As EventArgs) Handles ButOK.Click
        RUnit.ATK = Val(TbxATK.Text)
        RUnit.HP = Val(TbxHP.Text)
        RUnit.ATKCount = TbrATKC.Value
        RUnit.ATKCountRest = RUnit.ATKCount
        RUnit.Taunt = CbxTaunt.Checked

        RUnit.Shield = CbxShield.Checked
        RUnit.Poisonous = CbxPoisonous.Checked
        RUnit.AF = CbxAF.Checked
        RUnit.CantRe = CbxCantRe.Checked
        RUnit.ExtraValue = Val(TbxEXB.Text)
        Close()
    End Sub
    Private Sub CbxDie_CheckedChanged(sender As Object, e As EventArgs) Handles CbxDie.CheckedChanged

    End Sub
    Private Sub CbxDie_Click(sender As Object, e As EventArgs) Handles CbxDie.Click
        If CbxDie.Checked Then
            MsgBox("敬请期待！")
        End If
    End Sub
End Class