Namespace DTO

    Public Class File
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Name
            ModifiedDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Name() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="g")>
        Public Property ModifiedDate() As Date

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(Name As String, ModifiedDate As Date)

            Me.Name = Name
            Me.ModifiedDate = ModifiedDate

        End Sub

#End Region

    End Class

End Namespace
