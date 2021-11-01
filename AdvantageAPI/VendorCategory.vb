<DataContract>
Public Class VendorCategory

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <DataMember>
    Public Property Code As String
    <DataMember>
    Public Property Description As String

#End Region

#Region " Methods "

    Friend Sub New()



    End Sub
    Friend Sub New(ByVal VendorCategory As AdvantageFramework.Database.Entities.VendorCategory)

        'objects
        Dim EnumObject As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing

        Try

            EnumObject = AdvantageFramework.EnumUtilities.LoadEnumObject(VendorCategory)

        Catch ex As Exception
            EnumObject = Nothing
        End Try

        If EnumObject IsNot Nothing Then

            Me.Code = EnumObject.Code
            Me.Description = EnumObject.Description

        End If

    End Sub

#End Region

End Class
