Namespace DTO.GeneralLedger.JournalEntry

    Public Class GeneralLedgerAccount
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Description
            OfficeCode
            Office
            CDPRequired
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <MaxLength(30)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Code() As String
        <Required>
        <MaxLength(75)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Description() As String
        <MaxLength(4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
        <MaxLength(30)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Office() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property CDPRequired As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.Code = String.Empty
            Me.Description = String.Empty
            Me.OfficeCode = Nothing
            Me.Office = String.Empty
            Me.CDPRequired = False

        End Sub
        Public Sub New(GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount)

            Me.Code = GeneralLedgerAccount.Code
            Me.Description = GeneralLedgerAccount.Description

            If GeneralLedgerAccount.GeneralLedgerOfficeCrossReference IsNot Nothing Then

                Me.OfficeCode = GeneralLedgerAccount.GeneralLedgerOfficeCrossReference.OfficeCode

                If GeneralLedgerAccount.GeneralLedgerOfficeCrossReference.Office IsNot Nothing Then

                    Me.Office = GeneralLedgerAccount.GeneralLedgerOfficeCrossReference.Office.Name

                Else

                    Me.Office = String.Empty

                End If

            Else

                Me.OfficeCode = Nothing
                Me.Office = String.Empty

            End If

            Me.CDPRequired = CBool(GeneralLedgerAccount.CDPRequired.GetValueOrDefault(0))

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function

#End Region

    End Class

End Namespace
