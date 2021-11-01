Namespace DTO

    Public Class SalesClass
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Description
            SalesClassTypeCode
            IsInactive
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <MaxLength(6)>
        Public Property Code() As String
        <MaxLength(30)>
        Public Property Description() As String
        Public Property SalesClassTypeCode() As String
        Public Property IsInactive() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.Code = String.Empty
            Me.Description = String.Empty
            Me.SalesClassTypeCode = String.Empty
            Me.IsInactive = False

        End Sub
        Public Sub New(SalesClass As AdvantageFramework.Database.Entities.SalesClass)

            Me.Code = SalesClass.Code
            Me.Description = SalesClass.Description
            Me.SalesClassTypeCode = SalesClass.SalesClassTypeCode
            Me.IsInactive = If(SalesClass.IsInactive.GetValueOrDefault(0) = 0, False, True)

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function

#End Region

    End Class

End Namespace
