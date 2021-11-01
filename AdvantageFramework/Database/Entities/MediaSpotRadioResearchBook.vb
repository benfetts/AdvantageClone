Namespace Database.Entities

    <Table("MEDIA_SPOT_RADIO_RESEARCH_BOOK")>
    Public Class MediaSpotRadioResearchBook
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaSpotRadioResearchID
            NielsenRadioPeriodID1
            NielsenRadioPeriodID2
            NielsenRadioPeriodID3
            NielsenRadioPeriodID4
            NielsenRadioPeriodID5
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_SPOT_RADIO_RESEARCH_BOOK_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_SPOT_RADIO_RESEARCH_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaSpotRadioResearchID() As Integer
        <Required>
        <Column("NIELSEN_RADIO_PERIOD_ID1")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property NielsenRadioPeriodID1() As Integer
        <Column("NIELSEN_RADIO_PERIOD_ID2")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property NielsenRadioPeriodID2() As Nullable(Of Integer)
        <Column("NIELSEN_RADIO_PERIOD_ID3")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property NielsenRadioPeriodID3() As Nullable(Of Integer)
        <Column("NIELSEN_RADIO_PERIOD_ID4")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property NielsenRadioPeriodID4() As Nullable(Of Integer)
        <Column("NIELSEN_RADIO_PERIOD_ID5")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property NielsenRadioPeriodID5() As Nullable(Of Integer)

        <ForeignKey("MediaSpotRadioResearchID")>
        Public Overridable Property MediaSpotRadioResearch As Database.Entities.MediaSpotRadioResearch

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.MediaSpotRadioResearchBook.Properties.NielsenRadioPeriodID1.ToString

                    PropertyValue = Value

                    If PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Book 1 is invalid."

                    End If

                Case AdvantageFramework.Database.Entities.MediaSpotRadioResearchBook.Properties.NielsenRadioPeriodID2.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If PropertyValue = Me.NielsenRadioPeriodID1 OrElse PropertyValue = Me.NielsenRadioPeriodID3 OrElse
                                PropertyValue = Me.NielsenRadioPeriodID4 OrElse PropertyValue = Me.NielsenRadioPeriodID5 Then

                            IsValid = False

                            ErrorText = "Book 2 cannot be the same as the other books."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.MediaSpotRadioResearchBook.Properties.NielsenRadioPeriodID3.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If PropertyValue = Me.NielsenRadioPeriodID1 OrElse PropertyValue = Me.NielsenRadioPeriodID2 OrElse
                                PropertyValue = Me.NielsenRadioPeriodID4 OrElse PropertyValue = Me.NielsenRadioPeriodID5 Then

                            IsValid = False

                            ErrorText = "Book 3 cannot be the same as the other books."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.MediaSpotRadioResearchBook.Properties.NielsenRadioPeriodID4.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If PropertyValue = Me.NielsenRadioPeriodID1 OrElse PropertyValue = Me.NielsenRadioPeriodID2 OrElse
                                PropertyValue = Me.NielsenRadioPeriodID3 OrElse PropertyValue = Me.NielsenRadioPeriodID5 Then

                            IsValid = False

                            ErrorText = "Book 4 cannot be the same as the other books."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.MediaSpotRadioResearchBook.Properties.NielsenRadioPeriodID5.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If PropertyValue = Me.NielsenRadioPeriodID1 OrElse PropertyValue = Me.NielsenRadioPeriodID2 OrElse
                                PropertyValue = Me.NielsenRadioPeriodID3 OrElse PropertyValue = Me.NielsenRadioPeriodID4 Then

                            IsValid = False

                            ErrorText = "Book 5 cannot be the same as the other books."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
