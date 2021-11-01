Namespace DTO.Media.Traffic

    Public Class VendorStatus
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            VendorName
            StatusDescription
            StatusDate
            UserName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="")>
        Public Property VendorName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StatusDescription As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="g", CustomColumnCaption:="Date")>
        Public Property StatusDate() As Date
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property By As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
