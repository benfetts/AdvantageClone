Namespace DTO.Media.Traffic

    Public Class PrintSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            UserCode
            MediaType
            LocationID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ID As Integer
        Public Property UserCode As String
        Public Property MediaType As String
        Public Property LocationID As String
        Public Property IncludeGuidelines As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(UserCode As String, MediaType As String)

            Me.UserCode = UserCode
            Me.MediaType = MediaType
            Me.LocationID = Nothing
            Me.IncludeGuidelines = False

        End Sub
        Public Sub New(MediaTrafficPrintSetting As AdvantageFramework.Database.Entities.MediaTrafficPrintSetting)

            Me.ID = MediaTrafficPrintSetting.ID
            Me.UserCode = MediaTrafficPrintSetting.UserCode
            Me.MediaType = MediaTrafficPrintSetting.MediaType
            Me.LocationID = MediaTrafficPrintSetting.LocationID
            Me.IncludeGuidelines = MediaTrafficPrintSetting.IncludeGuidelines

        End Sub
        Public Sub SaveToEntity(ByRef MediaTrafficPrintSetting As AdvantageFramework.Database.Entities.MediaTrafficPrintSetting)

            MediaTrafficPrintSetting.UserCode = Me.UserCode
            MediaTrafficPrintSetting.MediaType = Me.MediaType
            MediaTrafficPrintSetting.LocationID = Me.LocationID
            MediaTrafficPrintSetting.IncludeGuidelines = Me.IncludeGuidelines

        End Sub

#End Region

    End Class

End Namespace
