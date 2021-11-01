Namespace DTO.GeneralLedger

    Public Class GeneralLedger
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Transaction
            PostedDate
            EnteredDate
            ModifiedDate
            PostPeriodCode
            UserCode
            Description
            GLSourceCode
            RowID
            BatchDate
            IsVoided
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Transaction() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PostedDate() As Nullable(Of Date)
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EnteredDate() As Date
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedDate() As Date
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PostPeriodCode() As String
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserCode() As String
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Description() As String
        <MaxLength(2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSourceCode() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RowID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BatchDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsVoided() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ReverseFlag() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.Transaction = 0
            Me.PostedDate = Nothing
            Me.EnteredDate = Now
            Me.ModifiedDate = Now
            Me.PostPeriodCode = Nothing
            Me.UserCode = Nothing
            Me.Description = Nothing
            Me.GLSourceCode = Nothing
            Me.RowID = 0
            Me.BatchDate = Nothing
            Me.IsVoided = Nothing
            Me.ReverseFlag = False

        End Sub
        Public Sub New(GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger)

            Me.Transaction = GeneralLedger.Transaction
            Me.PostedDate = GeneralLedger.PostedDate
            Me.EnteredDate = GeneralLedger.EnteredDate
            Me.ModifiedDate = GeneralLedger.ModifiedDate
            Me.PostPeriodCode = GeneralLedger.PostPeriodCode
            Me.UserCode = GeneralLedger.UserCode
            Me.Description = GeneralLedger.Description
            Me.GLSourceCode = GeneralLedger.GLSourceCode
            Me.RowID = GeneralLedger.RowID
            Me.BatchDate = GeneralLedger.BatchDate
            Me.IsVoided = GeneralLedger.IsVoided
            Me.ReverseFlag = If(GeneralLedger.ReverseFlag = "1", True, False)

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Transaction.ToString

        End Function

#End Region

    End Class

End Namespace
