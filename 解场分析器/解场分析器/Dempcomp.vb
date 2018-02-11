Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Friend Module Dempcomp
    Friend PreserveCount As Integer = 3
    ''' <summary>
    ''' 分析侧重方向。0:侧重分数 1:侧重生物数目差 2:侧重解场
    ''' </summary>
    ''' <remarks></remarks>
    Friend AnaArg As Integer = 0
    Friend Class GameWorld
        Friend Shared WrdHearthStone As New GameWorld
        Friend Shared WrdSoulHunter As New GameWorld
        Shared Sub New()
            With WrdHearthStone
                .ATKValue = 0.5
                .HPValue = 0.5
                .ExtraEva = New Func(Of Unit, Double)(
                    Function(u As Unit) As Double
                        Dim r As Double
                        With u
                            If .HP < 2 Then r -= 0.5
                            If .HP > 4 Then r += 0.5
                            If .ATK > 4 Then r += 0.5
                            r += (.ATKCount - 1) * .ATK * WrdHearthStone.ATKValue
                        End With
                        Return r
                    End Function)
                .TauntValue = 0.5
                .PoisonousValue = 1
                .ShieldValue = 0.5
                .BlastValue = 1
                .CantReValue = -1
                .AFValue = 0.5
                .tipFly.TipValue = 0.5
            End With
            With WrdSoulHunter
                .ATKValue = 0
                .HPValue = 0
                .ExtraEva = New Func(Of Unit, Double)(
                    Function(u As Unit) As Double
                        Dim r As Double
                        With u
                            Dim i As Integer = 1
                            While True
                                Dim ust As New Unit(i * 100, i * 300)
                                If Not Duel(ust, u) Then Exit While
                                If Not Duel(u, ust) Then Exit While
                                i += 1
                            End While
                            r = i + .ATK * 0.0001
                        End With
                        Return r
                    End Function)
                .TauntValue = 2
                .BlastValue = 2
                .AFValue = 1
                .tipFly.TipValue = 2
            End With
        End Sub
        Sub New()
            tipFly.TipName = "飞行"
        End Sub
        Friend Function Clone() As GameWorld
            Dim gw As New GameWorld
            gw.HPValue = HPValue
            gw.ATKValue = ATKValue
            gw.PoisonousValue = PoisonousValue
            gw.ShieldValue = ShieldValue
            gw.CantReValue = CantReValue
            gw.TauntValue = TauntValue
            gw.BlastValue = BlastValue
            gw.AFValue = AFValue
            gw.ExtraEva = ExtraEva
            gw.tipFly = tipFly
            Return gw
        End Function
        Friend HPValue As Double
        Friend ATKValue As Double
        Friend PoisonousValue As Double '剧毒
        Friend ShieldValue As Double '圣盾
        Friend CantReValue As Double '不能反击
        Friend TauntValue As Double '嘲讽
        Friend BlastValue As Double '爆破
        Friend AFValue As Double '空军
        Friend ExtraEva As Func(Of Unit, Double)
        Friend tipFly As Tip '飞行
        Friend Structure Tip
            Friend TipName As String
            Friend TipValue As Double
        End Structure

        <Serializable>
        Friend Structure Unit
            Friend Dead As Boolean
            Friend HP As Int32
            Friend ATK As Int32
            Friend ATKCountRest As Integer '剩余可攻击次数
            Friend ATKCount As Integer '可攻击次数
            Friend Poisonous As Boolean '剧毒
            Friend Shield As Boolean '圣盾
            Friend CantRe As Boolean '不能反击
            Friend Taunt As Boolean '嘲讽
            Friend Blast As Boolean '爆破
            Friend AF As Boolean '空军
            Friend ExtraValue As Double
            Friend Die As Action ' List(Of Action)
            'Friend Enraged As List(Of Action)
            Sub New(ByVal _hp As Int32, ByVal _atk As Int32)
                HP = _hp
                ATK = _atk
                ATKCount = 1
                ATKCountRest = 1
            End Sub
            Friend Function GetTip() As String
                Dim r As String = ""
                If Taunt Then r += "嘲讽 "
                If Blast Then r += "爆破 "
                If Shield Then r += "圣盾 "
                If AF Then r += "空军 "
                If Poisonous Then r += "剧毒 "
                If CantRe Then r += "不能反击 "
                Return r
            End Function
            Friend Function Evaluate_Simple(ByRef gw As GameWorld) As Double
                If Dead Then Return 0
                Dim r As Double
                r = HP * gw.HPValue + ATK * gw.ATKValue
                If Poisonous Then r += gw.PoisonousValue
                If Shield Then r += gw.ShieldValue
                If CantRe Then r += gw.CantReValue
                If Taunt Then r += gw.TauntValue
                If Blast Then r += gw.BlastValue
                If AF Then r += gw.AFValue
                r += gw.ExtraEva(Me)
                r += ExtraValue
                Return r
            End Function
        End Structure
        <Serializable>
        Friend Class Situation
            ' 没有进行封装。不要直接修改。其实应该存储指针。
            Friend MyUnits As New List(Of Unit)
            ' 没有进行封装。不要直接修改。其实应该存储指针。
            Friend OpUnits As New List(Of Unit)
            Friend Valid As Boolean = True
            Private tauntc As Int16
            Friend Sub AddMyUnit(ByRef u As Unit)
                MyUnits.Add(u)
            End Sub
            Friend Sub AddOpUnit(ByRef u As Unit)
                OpUnits.Add(u)
            End Sub
            Friend Sub CleanUp()
                Dim i As Int16
                While True
                    If i = OpUnits.Count Then Exit While
                    If OpUnits(i).Dead Then OpUnits.RemoveAt(i) : i = i - 1
                    i += 1
                End While
                i = 0
                While True
                    If i = MyUnits.Count Then Exit While
                    If MyUnits(i).Dead Then MyUnits.RemoveAt(i) : i = i - 1
                    i += 1
                End While
            End Sub
            Friend Sub Reverse()
                Dim temp = OpUnits
                OpUnits = MyUnits
                MyUnits = temp
            End Sub
            Friend Function SituationAna(ByRef gw As GameWorld) As LinkedList(Of Situation)
                Dim ac As Int32
                For Each myu In MyUnits
                    ac += myu.ATKCount
                Next
                If ac = 0 Then MsgBox("没有可以发动的攻击。") : Return Nothing
                If ac > 20 Then MsgBox("20次以上的攻击会导致溢出哦亲~") : Return Nothing
                tauntc = 0
                For Each u In OpUnits
                    If u.Taunt Then
                        tauntc += 1
                        u.Die = New Action(Sub()
                                               tauntc -= 1
                                           End Sub)
                    End If
                Next
                ReDim DeduceInd(ac - 1)
                TempSituation = New LinkedList(Of Situation)
                Dim em As New Situation
                em.Score = -100000
                TempSituation.AddFirst(em)
                Select Case AnaArg
                    Case 0 '侧重得分
                        If tauntc = 0 Then
                            Dim templ1 As New List(Of Unit), templ2 As New List(Of Unit)
                            For Each u In OpUnits
                                If u.Shield Then templ1.Add(u) Else templ2.Add(u)
                            Next
                            If templ1.Count > 0 Then
                                SituationAna_Shield(gw, ac)
                            Else
                                SituationAna_Simple_Beginning(gw, ac)
                            End If
                        Else
                            Dim templ1 As New List(Of Unit), templ2 As New List(Of Unit)
                            For Each u In OpUnits
                                If u.Shield AndAlso u.Taunt Then templ1.Add(u) Else templ2.Add(u)
                            Next
                            If templ1.Count > 0 Then
                                SituationAna_TauntWithShield(gw, ac)
                            Else
                                SituationAna_Taunt(gw, ac)
                            End If
                        End If
                    Case 1 '侧重生物数量差

                    Case 2 '侧重解场
                End Select
                TurnReset()
                Return TempSituation
            End Function
            Friend Sub TurnReset()
                For Each u In MyUnits
                    u.ATKCountRest = u.ATKCount
                Next
                For Each u In OpUnits
                    u.ATKCountRest = u.ATKCount
                Next
            End Sub
            Friend Shared TempSituation As New LinkedList(Of Situation)
            ''' <summary>
            ''' 场面：只要存在圣盾嘲讽。
            ''' </summary>
            ''' <param name="gw">相应的世界观。</param>
            ''' <param name="ac">攻击次数。</param>
            ''' <remarks></remarks>
            Private Sub SituationAna_TauntWithShield(ByRef gw As GameWorld, ByRef ac As Int16)
                Dim tempopu1 As New List(Of Unit) '非嘲讽
                Dim tempopu2 As New List(Of Unit) '圣盾+嘲讽
                For Each u In OpUnits
                    If u.Shield And u.Taunt Then
                        tempopu2.Add(u)
                    Else
                        tempopu1.Add(u)
                    End If
                Next
                Dim i As Int64, m As Int64 = (tempopu2.Count + 1) ^ ac
                For i = 1 To m
                    Dim temps_ = Clone() '圣盾+嘲讽
                    Dim temps = Clone() '其他
                    temps.OpUnits = ListClone(tempopu1)
                    temps_.OpUnits = ListClone(tempopu2)
                    temps_.Deduce()
                    If temps_.Valid Then
                        temps_.CleanUp()
                        If temps_.OpUnits.Count = 0 Then '击破全部圣盾+嘲讽
                            temps.Log = temps_.Log
                            temps.MyUnits = temps_.MyUnits
                            If temps.tauntc = 0 Then
                                Dim flag As Boolean
                                For Each u In temps.OpUnits
                                    If u.Shield Then flag = True : Exit For
                                Next
                                If flag Then
                                    ac = temps.SA_PreNextStep(gw)
                                    If ac Then
                                        Dim tempind = DeduceInd
                                        ReDim DeduceInd(ac - 1)
                                        temps.SituationAna_Shield(gw, ac)
                                        DeduceInd = tempind
                                    End If
                                Else
                                    ac = temps.SA_PreNextStep(gw)
                                    If ac Then
                                        Dim tempind = DeduceInd
                                        ReDim DeduceInd(ac - 1)
                                        temps.SA_StepLast(gw, ac)
                                        DeduceInd = tempind
                                    End If
                                End If
                            Else
                                ac = temps.SA_PreNextStep(gw)
                                If ac Then
                                    Dim tempind = DeduceInd
                                    ReDim DeduceInd(ac - 1)
                                    temps.SituationAna_Taunt(gw, ac)
                                    DeduceInd = tempind
                                End If
                            End If
                        End If
                    End If
                Next
            End Sub
            ''' <summary>
            ''' 场面：非圣盾嘲讽、其他。
            ''' </summary>
            ''' <param name="gw"></param>
            ''' <param name="ac"></param>
            ''' <remarks></remarks>
            Private Sub SituationAna_Taunt(ByRef gw As GameWorld, ByRef ac As Int16)
                Dim temps = Clone() '无圣盾嘲讽
                Dim tempopu As New List(Of Unit) '非嘲讽
                Dim i As Int16
                While True
                    If i = temps.OpUnits.Count Then Exit While
                    If Not temps.OpUnits(i).Taunt Then tempopu.Add(temps.OpUnits(i)) : temps.OpUnits.RemoveAt(i) : i = i - 1
                    i += 1
                End While
                Dim flag As Boolean
                For Each u In tempopu
                    If u.Shield Then flag = True
                Next
                If flag Then
                    'ac、DeduceInd已经经过重新计算或者还不需要重新计算。
                    temps.SA_TWS_Step2(gw, ac, tempopu)
                Else
                    temps.SA_T_Step2(gw, ac, tempopu)
                End If
            End Sub
            Private Sub SA_TWS_Step2(ByRef gw As GameWorld, ByRef ac As Int16, ByRef tempopu As List(Of Unit))
                Dim i As Int64, m As Int64 = (OpUnits.Count + 1) ^ ac
                For i = 1 To m
                    Dim temps = Clone()
                    temps.Deduce() '无圣盾嘲讽
                    If temps.Valid Then
                        temps.CleanUp()
                        If temps.OpUnits.Count = 0 Then
                            ac = temps.SA_PreNextStep(gw)
                            If ac Then
                                temps.OpUnits.AddRange(tempopu) '非嘲讽
                                Dim tempind = DeduceInd
                                ReDim DeduceInd(ac - 1)
                                Dim flag As Boolean
                                For Each u In temps.OpUnits
                                    If u.Shield Then flag = True : Exit For
                                Next
                                If flag Then
                                    temps.SituationAna_Shield(gw, ac)
                                Else
                                    temps.SA_StepLast(gw, ac)
                                End If
                                DeduceInd = tempind
                            End If
                        End If
                    End If
                Next
            End Sub
            Private Sub SA_T_Step2(ByRef gw As GameWorld, ByRef ac As Int16, ByRef tempopu As List(Of Unit))
                Dim i As Int64, m As Int64 = (OpUnits.Count + 1) ^ ac
                For i = 1 To m
                    Dim temps = Clone()
                    temps.Deduce()
                    If temps.Valid Then
                        temps.CleanUp()
                        If temps.OpUnits.Count = 0 Then
                            ac = temps.SA_PreNextStep(gw)
                            If ac Then
                                Dim tempind = DeduceInd
                                ReDim DeduceInd(ac - 1)
                                temps.OpUnits.AddRange(tempopu)
                                temps.SA_StepLast(gw, ac)
                                DeduceInd = tempind
                            End If
                        End If
                    End If
                Next
            End Sub
            ''' <summary>
            ''' 进行下一步的必须步骤。请在之后重置DeduceInd。
            ''' </summary>
            ''' <param name="gw"></param>
            ''' <returns>剩余攻击次数。</returns>
            ''' <remarks></remarks>
            Private Function SA_PreNextStep(ByRef gw As GameWorld) As Int16
                Dim ac As Int32
                For Each myu In MyUnits
                    ac += myu.ATKCountRest
                Next
                If ac = 0 Then
                    CleanUp()
                    SituationEva_Score_Simple(gw)
                    Dim node As LinkedListNode(Of Situation) = TempSituation.Last
                    Dim nc = TempSituation.First
                    While nc IsNot Nothing
                        If nc.Value.Score < Score Then
                            If TempSituation.Count < 3 Then
                                node = nc
                                TempSituation.AddBefore(node, Me)
                                Exit While
                            Else
                                nc.Value = Me
                            End If
                        End If
                        nc = nc.Next
                    End While
                End If
                Return ac
            End Function
            ''' <summary>
            ''' 
            ''' </summary>
            ''' <param name="gw"></param>
            ''' <param name="ac">剩余攻击次数。</param>
            ''' <remarks></remarks>
            Private Sub SA_StepLast(ByRef gw As GameWorld, ByVal ac As Int16)
                Dim i As Int64, m As Int64 = (OpUnits.Count + 1) ^ ac
                For i = 1 To m
                    Dim temps = Clone()
                    temps.Deduce()
                    If temps.Valid Then
                        temps.SituationEva_Score_Simple(gw)
                        Dim node As LinkedListNode(Of Situation) = TempSituation.Last
                        Dim nc = TempSituation.First
                        While nc IsNot Nothing
                            If nc.Value.Score < temps.Score Then
                                node = nc
                                Exit While
                            End If
                            nc = nc.Next
                        End While
                        temps.CleanUp()
                        TempSituation.AddBefore(node, temps)
                        If TempSituation.Count = PreserveCount + 1 Then Exit For
                    End If
                Next
                TempSituation.RemoveLast()
                Dim _temps = Clone()
                Dim _t = Clone()
                For h = i + 1 To m
                    _temps.Deduce()
                    If _temps.Valid Then
                        _temps.SituationEva_Score_Simple(gw)
                        Dim nc = TempSituation.First
                        While nc IsNot Nothing
                            If nc.Value.Score < _temps.Score Then
                                _temps.CleanUp()
                                nc.Value = _temps
                                _temps = _t
                                Exit While
                            End If
                            nc = nc.Next
                        End While
                    End If
                Next
            End Sub
            Friend Log As String
            ''' <summary>
            ''' 演绎。嘲讽已被消除。
            ''' </summary>
            ''' <remarks></remarks>
            Private Sub Deduce()
                Dim j As Int16 = UBound(DeduceInd)
                While DeduceInd(j) = OpUnits.Count + 1
                    If j = 0 Then j = -1 : Exit While
                    DeduceInd(j) = 0
                    j -= 1
                    DeduceInd(j) += 1
                End While
                If j = -1 Then Exit Sub
                Dim _ac As Int16
                For i = 0 To MyUnits.Count - 1
                    ' 判断本次攻击者。
                    Dim myu = MyUnits(i)
                    If myu.ATKCountRest = 0 Then Continue For
                    ' 无效攻击的场合变成不攻击。去除重复计算。
                    If myu.HP > 0 Then
                        Dim targind = DeduceInd(_ac)
                        If targind = OpUnits.Count Then
                            _ac += 1
                            Continue For
                        End If
                        Dim targ = OpUnits(targind)
                        If targ.HP > 0 AndAlso (myu.AF OrElse Not targ.AF) Then
                            Attack(MyUnits(i), OpUnits(targind))
                            Log += myu.ATK & "/" & myu.HP & "攻击" & targ.ATK & "/" & targ.HP & "!" & vbCrLf
                            _ac += 1
                        Else
                            Valid = False
                            Exit For
                        End If
                    End If
                Next
                DeduceInd(UBound(DeduceInd)) += 1
            End Sub
            ''' <summary>
            ''' 场面：圣盾、无嘲讽。
            ''' </summary>
            ''' <param name="gw"></param>
            ''' <param name="ac"></param>
            ''' <remarks></remarks>
            Private Sub SituationAna_Shield(ByRef gw As GameWorld, ByRef ac As Int16)
                Dim tempopu1 As New List(Of Unit) '非圣盾
                Dim tempopu2 As New List(Of Unit) '圣盾
                For Each u In OpUnits
                    If u.Shield Then
                        tempopu2.Add(u)
                    Else
                        tempopu1.Add(u)
                    End If
                Next
                Dim i As Int64, m As Int64 = (tempopu2.Count + 1) ^ ac
                For i = 1 To m
                    Dim temps_ = Clone() '圣盾
                    Dim temps = Clone() '非圣盾
                    temps_.OpUnits = ListClone(tempopu2)
                    temps.OpUnits = ListClone(tempopu1)
                    temps_.Deduce()
                    If temps_.Valid Then
                        temps.Log = temps_.Log
                        temps_.CleanUp()
                        temps.MyUnits = temps_.MyUnits
                        ac = temps.SA_PreNextStep(gw)
                        If ac Then
                            Dim tempind = DeduceInd
                            ReDim DeduceInd(ac - 1)
                            temps.SA_Complex_StepLast(gw, ac, temps_.OpUnits)
                            DeduceInd = tempind
                        End If
                    End If
                Next
            End Sub
            ''' <summary>
            ''' 存在顺序影响时的最后一步。
            ''' </summary>
            ''' <param name="gw"></param>
            ''' <param name="templ">因为预先考虑而被移除的对方单位序列，将在这里移回。</param>
            ''' <remarks></remarks>
            Private Sub SA_Complex_StepLast(ByRef gw As GameWorld, ByVal ac As Int16, ByRef templ As List(Of Unit))
                Dim i As Int64, m As Int64 = (OpUnits.Count + 1) ^ ac
                For i = 1 To m
                    Dim temps = Clone()
                    temps.Deduce()
                    If temps.Valid Then
                        temps.OpUnits.AddRange(templ)
                        temps.SituationEva_Score_Simple(gw)
                        Dim node As LinkedListNode(Of Situation) = TempSituation.Last
                        Dim nc = TempSituation.First
                        While nc IsNot Nothing
                            If nc.Value.Score < temps.Score Then
                                node = nc
                                Exit While
                            End If
                            nc = nc.Next
                        End While
                        temps.CleanUp()
                        TempSituation.AddBefore(node, temps)
                        If TempSituation.Count = PreserveCount + 1 Then Exit For
                    End If
                Next
                TempSituation.RemoveLast()
                Dim _temps = Clone()
                Dim _t = Clone()
                For h = i + 1 To m
                    _temps.Deduce()
                    If _temps.Valid Then
                        _temps.OpUnits.AddRange(templ)
                        _temps.SituationEva_Score_Simple(gw)
                        Dim nc = TempSituation.First
                        While nc IsNot Nothing
                            If nc.Value.Score < _temps.Score Then
                                _temps.CleanUp()
                                nc.Value = _temps
                                _temps = _t
                                Exit While
                            End If
                            nc = nc.Next
                        End While
                    End If
                Next
            End Sub
            ''' <summary>
            ''' 开始局面。局面：无嘲讽、无圣盾。
            ''' </summary>
            ''' <param name="gw"></param>
            ''' <param name="ac"></param>
            ''' <remarks></remarks>
            Private Sub SituationAna_Simple_Beginning(ByRef gw As GameWorld, ByRef ac As Int16)
                Dim i As Int64
                For i = 1 To (OpUnits.Count + 1) ^ ac
                    Dim operation As String = ""
                    Dim temps = Clone()
                    temps.Deduce_Simple(operation)
                    If temps.Valid Then
                        temps.CleanUp()
                        temps.SituationEva_Score_Simple(gw)
                        Dim node As LinkedListNode(Of Situation) = TempSituation.Last
                        Dim nc = TempSituation.First
                        While nc IsNot Nothing
                            If nc.Value.Score < temps.Score Then
                                node = nc
                                Exit While
                            End If
                            nc = nc.Next
                        End While
                        TempSituation.AddBefore(node, temps)
                        If TempSituation.Count = PreserveCount + 1 Then Exit For
                    End If
                Next
                TempSituation.RemoveLast()
                Dim _temps = Clone()
                Dim _t = Clone()
                For h = i + 1 To (OpUnits.Count + 1) ^ ac
                    Dim operation As String = ""
                    _temps.Deduce_Simple(operation)
                    If _temps.Valid Then
                        _temps.CleanUp()
                        _temps.SituationEva_Score_Simple(gw)
                        Dim nc = TempSituation.First
                        While nc IsNot Nothing
                            If nc.Value.Score < _temps.Score Then
                                nc.Value = _temps
                                _temps = _t
                                Exit While
                            End If
                            nc = nc.Next
                        End While
                    End If
                Next
            End Sub
            Private Shared DeduceInd As Int16()
            ''' <summary>
            ''' 演绎。场上不存在嘲讽。不考虑圣盾。
            ''' </summary>
            ''' <param name="o">用于储存操作过程。</param>
            ''' <remarks></remarks>
            Private Sub Deduce_Simple(ByRef o As String)
                Dim ac = UBound(DeduceInd)
                Dim j As Int16 = ac
                While DeduceInd(j) = OpUnits.Count + 1
                    If j = 0 Then j = -1 : Exit While
                    DeduceInd(j) = 0
                    j -= 1
                    DeduceInd(j) += 1
                End While
                If j = -1 Then Exit Sub
                Dim _ac As Int16
                Dim _uind As Int16
                For i = 0 To ac
                    ' 判断本次攻击者。
                    While _ac < i
                        _ac += MyUnits(_uind).ATKCount
                        If _uind < MyUnits.Count - 1 Then _uind += 1 Else Exit While
                    End While
                    Dim myu = MyUnits(_uind)
                    ' 无效攻击的场合变成不攻击。去除重复计算。
                    If myu.HP > 0 Then
                        Dim targind = DeduceInd(i)
                        If targind = OpUnits.Count Then
                            Continue For
                        End If
                        Dim targ = OpUnits(targind)
                        If targ.HP > 0 AndAlso (myu.AF OrElse Not targ.AF) Then
                            Battle(MyUnits(_uind), OpUnits(targind))
                            Log += myu.ATK & "/" & myu.HP & "攻击" & targ.ATK & "/" & targ.HP & "!" & vbCrLf
                        Else
                            Valid = False
                            Exit For
                        End If
                    End If
                Next
                DeduceInd(ac) += 1
            End Sub
            Friend Shared Function ListClone(Of T)(ByRef l As List(Of T)) As List(Of T)
                Dim stream As New MemoryStream()
                Dim formatter As New BinaryFormatter()
                formatter.Serialize(stream, l)
                stream.Position = 0
                Return formatter.Deserialize(stream)
            End Function
            Friend Function Clone() As Situation
                Dim stream As New MemoryStream()
                Dim formatter As New BinaryFormatter()
                formatter.Serialize(stream, Me)
                stream.Position = 0
                Return formatter.Deserialize(stream)
            End Function
            Friend Sub SituationEva_Score_Simple(ByRef gw As GameWorld)
                Dim r As Double
                For Each u In MyUnits
                    r += u.Evaluate_Simple(gw)
                Next
                For Each u In OpUnits
                    r -= u.Evaluate_Simple(gw)
                Next
                Score = r
            End Sub
            Friend Score As Double

            Friend Function SituationAna2(ByRef gw As GameWorld) As LinkedList(Of Situation)
                Dim ac As Int32
                For Each myu In MyUnits
                    ac += myu.ATKCount
                Next
                If ac = 0 Then MsgBox("没有可以发动的攻击。") : Return Nothing
                If ac > 20 Then MsgBox("20次以上的攻击会导致溢出哦亲~") : Return Nothing
                ReDim DeduceInd(ac - 1)
                Dim s As New LinkedList(Of Situation)
                Dim i As Int64
                For i = 1 To (OpUnits.Count + 1) ^ ac
                    Dim operation As String = ""
                    Dim temps = Clone()
                    temps.Deduce_Simple(operation)
                    If temps.Valid Then
                        temps.SituationEva_Score_Simple(gw)
                        s.AddFirst(temps) : GoTo _2
                    End If
                Next
_2:
                For h = i + 1 To (OpUnits.Count + 1) ^ ac
                    Dim operation As String = ""
                    Dim temps = Clone()
                    temps.Deduce_Simple(operation)
                    If temps.Valid Then
                        temps.SituationEva_Score_Simple(gw)
                        Dim node As LinkedListNode(Of Situation) = s.Last
                        Dim nc = s.First
                        While nc IsNot Nothing
                            If nc.Value.Score < temps.Score Then
                                node = nc
                                Exit While
                            End If
                            nc = nc.Next
                        End While
                        s.AddBefore(node, temps)
                    End If
                Next
                Return s
            End Function
        End Class
        Friend Shared Sub AttackWithNoRe(ByRef u1 As Unit, ByRef u2 As Unit)
            If u2.Shield Then
                u2.Shield = False
            ElseIf u1.Poisonous Then
                u2.HP = 0
                If u2.Die IsNot Nothing Then u2.Die()
                '    For Each act In u2.Die
                '        act()
                '    Next
                'End If
                u2.Dead = True
            Else
                u2.HP -= u1.ATK
                'If u2.Enraged IsNot Nothing Then
                '    For Each act In u2.Enraged
                '        act()
                '    Next
                'End If
                If u2.HP <= 0 Then
                    If u2.Die IsNot Nothing Then u2.Die()
                    u2.Dead = True
                End If
            End If
        End Sub
        ''' <summary>
        ''' u1攻击u2。没有预先判定目标可行性（是否死亡，是否可以作为攻击目标）。
        ''' </summary>
        ''' <param name="u1"></param>
        ''' <param name="u2"></param>
        ''' <remarks></remarks>
        Friend Shared Sub Attack(ByRef u1 As Unit, ByRef u2 As Unit)
            u1.ATKCountRest -= 1
            AttackWithNoRe(u1, u2)
            If Not u2.CantRe Then AttackWithNoRe(u2, u1)
        End Sub
        ''' <summary>
        ''' u1攻击u2。没有预先判定目标可行性（是否死亡，是否可以作为攻击目标）。
        ''' </summary>
        ''' <param name="u1"></param>
        ''' <param name="u2"></param>
        ''' <remarks></remarks>
        Friend Shared Sub Battle(ByRef u1 As Unit, ByRef u2 As Unit)
            AttackWithNoRe(u1, u2)
            If Not u2.CantRe Then AttackWithNoRe(u2, u1)
        End Sub
        ''' <summary>
        ''' 轮回攻击，判断u1是否能够击破u2。
        ''' </summary>
        ''' <param name="u1"></param>
        ''' <param name="u2"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Shared Function Duel(ByVal u1 As Unit, ByVal u2 As Unit) As Boolean
            If u1.ATK = 0 Then Return False
            While True
                Battle(u1, u2)
                If u2.Dead Then Return True
                If u1.Dead Then Return False
            End While
            Return False
        End Function
    End Class
    Friend Function m2n(ByVal num As Integer, ByVal fomat As Integer) As String
        Dim s As Stack = New Stack
        While num <> 0
            Dim t As Integer = num Mod fomat
            s.Push(t)
            num = (num - t) / fomat
        End While
        Dim n As Integer = s.Count
        Dim res As String = ""
        Dim i As Integer = 0
        Do While i < n
            res &= s.Pop
            i += 1
        Loop
        Return res
    End Function
End Module
