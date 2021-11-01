Namespace DTO.Maintenance.Accounting.Vendor

    Public Class Market
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Description
            IsInactive
            CountryID
            Country
            StateProvince
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <MaxLength(10)>
        Public Property Code() As String
        <Required>
        <MaxLength(40)>
        Public Property Description() As String
        Public Property IsInactive() As Boolean
        Public Property CountryID() As Integer

        Public Property Country() As String
        Public Property StateProvince() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.Code = String.Empty
            Me.Description = String.Empty
            Me.IsInactive = False
            Me.CountryID = 0

        End Sub
        Public Sub New(Code As String, Description As String, IsInactive As Boolean, CountryID As Integer)

            Me.Code = Code
            Me.Description = Description
            Me.IsInactive = IsInactive
            Me.CountryID = CountryID

        End Sub
        Public Sub New(Market As AdvantageFramework.Database.Entities.Market)

            Me.Code = Market.Code
            Me.Description = Market.Description
            Me.IsInactive = If(Market.IsInactive.GetValueOrDefault(0) = 0, False, True)
            Me.CountryID = Market.CountryID.GetValueOrDefault(0)

            If Market.Country IsNot Nothing Then

                Me.Country = Market.Country.Name

            End If

            If Market.State IsNot Nothing Then

                Me.StateProvince = Market.State.StateName

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function

#End Region

    End Class

End Namespace
