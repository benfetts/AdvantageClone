Namespace ViewModels.Media

    Public Class ResearchCriteriaViewModel

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum ResearchType
            SpotRadio
            SpotTV
            SpotRadioCounty
            National
            SpotTVPuertoRico
        End Enum

#End Region

#Region " Variables "

        Private _ResearchType As ResearchType = ResearchType.SpotTV
        Private _IsCopy As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property AddVisible As Boolean
            Get
                If Not _IsCopy AndAlso _ResearchType = ResearchType.SpotTV Then

                    AddVisible = Me.ResearchCriteria IsNot Nothing AndAlso Not DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotTV.ResearchCriteria).ID.HasValue

                ElseIf Not _IsCopy AndAlso _ResearchType = ResearchType.SpotRadio Then

                    AddVisible = Me.ResearchCriteria IsNot Nothing AndAlso Not DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria).ID.HasValue

                ElseIf Not _IsCopy AndAlso _ResearchType = ResearchType.SpotRadioCounty Then

                    AddVisible = Me.ResearchCriteria IsNot Nothing AndAlso Not DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchCriteria).ID.HasValue

                ElseIf Not _IsCopy AndAlso _ResearchType = ResearchType.National Then

                    AddVisible = Me.ResearchCriteria IsNot Nothing AndAlso Not DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.National.ResearchCriteria).ID.HasValue

                ElseIf Not _IsCopy AndAlso _ResearchType = ResearchType.SpotTVPuertoRico Then

                    AddVisible = Me.ResearchCriteria IsNot Nothing AndAlso Not DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchCriteria).ID.HasValue

                Else

                    AddVisible = False

                End If
            End Get
        End Property
        Public ReadOnly Property UpdateVisible As Boolean
            Get
                If Not _IsCopy AndAlso _ResearchType = ResearchType.SpotTV Then

                    UpdateVisible = Me.ResearchCriteria IsNot Nothing AndAlso DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotTV.ResearchCriteria).ID.HasValue

                ElseIf Not _IsCopy AndAlso _ResearchType = ResearchType.SpotRadio Then

                    UpdateVisible = Me.ResearchCriteria IsNot Nothing AndAlso DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria).ID.HasValue

                ElseIf Not _IsCopy AndAlso _ResearchType = ResearchType.SpotRadioCounty Then

                    UpdateVisible = Me.ResearchCriteria IsNot Nothing AndAlso DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchCriteria).ID.HasValue

                ElseIf Not _IsCopy AndAlso _ResearchType = ResearchType.National Then

                    UpdateVisible = Me.ResearchCriteria IsNot Nothing AndAlso DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.National.ResearchCriteria).ID.HasValue

                ElseIf Not _IsCopy AndAlso _ResearchType = ResearchType.SpotTVPuertoRico Then

                    UpdateVisible = Me.ResearchCriteria IsNot Nothing AndAlso DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchCriteria).ID.HasValue

                Else

                    UpdateVisible = False

                End If
            End Get
        End Property
        Public ReadOnly Property CopyVisible As Boolean
            Get
                CopyVisible = _IsCopy
            End Get
        End Property
        Public ReadOnly Property FormCaption As String
            Get
                If _ResearchType = ResearchType.SpotTV Then

                    If _IsCopy Then

                        FormCaption = "Copy " & DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotTV.ResearchCriteria).CriteriaName & " to:"

                    Else

                        FormCaption = If(Me.ResearchCriteria IsNot Nothing AndAlso DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotTV.ResearchCriteria).ID.HasValue, "Edit Report", "Add Report")

                    End If

                ElseIf _ResearchType = ResearchType.SpotRadio Then

                    If _IsCopy Then

                        FormCaption = "Copy " & DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria).CriteriaName & " to:"

                    Else

                        FormCaption = If(Me.ResearchCriteria IsNot Nothing AndAlso DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria).ID.HasValue, "Edit Report", "Add Report")

                    End If

                ElseIf _ResearchType = ResearchType.SpotRadioCounty Then

                    If _IsCopy Then

                        FormCaption = "Copy " & DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchCriteria).CriteriaName & " to:"

                    Else

                        FormCaption = If(Me.ResearchCriteria IsNot Nothing AndAlso DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchCriteria).ID.HasValue, "Edit Report", "Add Report")

                    End If

                ElseIf _ResearchType = ResearchType.National Then

                    If _IsCopy Then

                        FormCaption = "Copy " & DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.National.ResearchCriteria).CriteriaName & " to:"

                    Else

                        FormCaption = If(Me.ResearchCriteria IsNot Nothing AndAlso DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.National.ResearchCriteria).ID.HasValue, "Edit Report", "Add Report")

                    End If

                Else

                    If _IsCopy Then

                        FormCaption = "Copy " & DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchCriteria).CriteriaName & " to:"

                    Else

                        FormCaption = If(Me.ResearchCriteria IsNot Nothing AndAlso DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchCriteria).ID.HasValue, "Edit Report", "Add Report")

                    End If

                End If
            End Get
        End Property

        Public Property ResearchCriteria As Object
        Public ReadOnly Property CriteriaName As String
            Get
                If Not _IsCopy AndAlso _ResearchType = ResearchType.SpotTV Then

                    CriteriaName = If(Me.ResearchCriteria IsNot Nothing, DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotTV.ResearchCriteria).CriteriaName, Nothing)

                ElseIf Not _IsCopy AndAlso _ResearchType = ResearchType.SpotRadio Then

                    CriteriaName = If(Me.ResearchCriteria IsNot Nothing, DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria).CriteriaName, Nothing)

                ElseIf Not _IsCopy AndAlso _ResearchType = ResearchType.SpotRadioCounty Then

                    CriteriaName = If(Me.ResearchCriteria IsNot Nothing, DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchCriteria).CriteriaName, Nothing)

                ElseIf Not _IsCopy AndAlso _ResearchType = ResearchType.National Then

                    CriteriaName = If(Me.ResearchCriteria IsNot Nothing, DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.National.ResearchCriteria).CriteriaName, Nothing)

                ElseIf Not _IsCopy AndAlso _ResearchType = ResearchType.SpotTVPuertoRico Then

                    CriteriaName = If(Me.ResearchCriteria IsNot Nothing, DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchCriteria).CriteriaName, Nothing)

                Else

                    CriteriaName = String.Empty

                End If
            End Get
        End Property
        Public ReadOnly Property ID As Integer
            Get
                If _ResearchType = ResearchType.SpotTV Then

                    ID = If(Me.ResearchCriteria IsNot Nothing, DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotTV.ResearchCriteria).ID.Value, 0)

                ElseIf _ResearchType = ResearchType.SpotRadio Then

                    ID = If(Me.ResearchCriteria IsNot Nothing, DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria).ID.Value, 0)

                ElseIf _ResearchType = ResearchType.SpotRadioCounty Then

                    ID = If(Me.ResearchCriteria IsNot Nothing, DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchCriteria).ID.Value, 0)

                ElseIf _ResearchType = ResearchType.National Then

                    ID = If(Me.ResearchCriteria IsNot Nothing, DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.National.ResearchCriteria).ID.Value, 0)

                Else

                    ID = If(Me.ResearchCriteria IsNot Nothing, DirectCast(Me.ResearchCriteria, AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchCriteria).ID.Value, 0)

                End If
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(Type As ResearchType, IsCopy As Boolean)

            _ResearchType = Type
            _IsCopy = IsCopy

            If _ResearchType = ResearchType.SpotTV Then

                ResearchCriteria = New AdvantageFramework.DTO.Media.SpotTV.ResearchCriteria

            ElseIf _ResearchType = ResearchType.SpotRadio Then

                ResearchCriteria = New AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria

            ElseIf _ResearchType = ResearchType.SpotRadioCounty Then

                ResearchCriteria = New AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchCriteria

            ElseIf _ResearchType = ResearchType.National Then

                ResearchCriteria = New AdvantageFramework.DTO.Media.National.ResearchCriteria

            ElseIf _ResearchType = ResearchType.SpotTVPuertoRico Then

                ResearchCriteria = New AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchCriteria

            End If

        End Sub

#End Region

    End Class

End Namespace
