Namespace DTO.Media.RFP

    Public Class PrintSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            UserCode
            MediaType
            IncludeCPP
            IncludeGRP
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ID As Integer
        Public Property UserCode As String
        Public Property MediaType As String
        Public Property IncludeCPP As Short
        Public Property IncludeGRP As Short

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(UserCode As String, MediaType As String)

            Me.UserCode = UserCode
            Me.MediaType = MediaType

            If MediaType = "T" OrElse MediaType = "R" Then

                Me.IncludeCPP = AdvantageFramework.Media.MediaRFPIncludeCPPSettings.ShowTotal
                Me.IncludeGRP = AdvantageFramework.Media.MediaRFPIncludeCPPSettings.ShowTotal

            End If

        End Sub
        Public Sub New(MediaRFPPrintSetting As AdvantageFramework.Database.Entities.MediaRFPPrintSetting)

            Me.ID = MediaRFPPrintSetting.ID
            Me.UserCode = MediaRFPPrintSetting.UserCode
            Me.MediaType = MediaRFPPrintSetting.MediaType
            Me.IncludeCPP = MediaRFPPrintSetting.IncludeCPP
            Me.IncludeGRP = MediaRFPPrintSetting.IncludeGRP

        End Sub
        Public Sub SaveToEntity(ByRef MediaRFPPrintSetting As AdvantageFramework.Database.Entities.MediaRFPPrintSetting)

            MediaRFPPrintSetting.UserCode = Me.UserCode
            MediaRFPPrintSetting.MediaType = Me.MediaType
            MediaRFPPrintSetting.IncludeCPP = Me.IncludeCPP
            MediaRFPPrintSetting.IncludeGRP = Me.IncludeGRP

        End Sub

#End Region

    End Class

End Namespace
