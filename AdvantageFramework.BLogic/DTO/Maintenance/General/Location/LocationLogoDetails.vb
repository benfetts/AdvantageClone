Namespace DTO.Maintenance.General.Location

    Public Class LocationLogoDetails

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            LocationID
            LocationLogoTypeID
            Image
            Thumbnail
            IsActive
            CreateDate
            UserCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ID As Integer = 0
        Public Property LocationID As String = Nothing
        Public Property LocationLogoTypeID As Integer = 0
        Public Property Image As String = Nothing
        Public Property Thumbnail As Byte() = Nothing
        Public Property IsActive As Boolean = Nothing
        Public Property CreateDate As Date = Nothing
        Public Property UserCode As String = Nothing

#End Region

#Region " Methods "

        Sub New()



        End Sub

#End Region

    End Class

End Namespace
