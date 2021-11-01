Namespace DTO.GeneralLedger.JournalEntry

    Public Class JournalEntry
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            HasDocuments
            Transaction
            PostPeriodCode
            GLSourceCode
            Description
            PostedDate
            EnteredDate
            ModifiedDate
            UserCode
            RowID
            BatchDate
            IsVoided
            ReverseFlag
            CreateDate
            PostedToSummary
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:=" ")>
        Public Property HasDocuments() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Transaction() As Integer
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property PostPeriodCode() As String
        <Required>
        <MaxLength(2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property GLSourceCode() As String
        <Required>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Description() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property PostedDate() As Nullable(Of Date)
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EnteredDate() As Date
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ModifiedDate() As Date
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property UserCode() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property RowID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BatchDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, CustomColumnCaption:="Voided")>
        Public Property IsVoided() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ReverseFlag() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CreateDate() As Date
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property PostedToSummary() As Boolean

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
            Me.IsVoided = False
            Me.ReverseFlag = False
            Me.HasDocuments = False

        End Sub
        Public Sub New(GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger)

            LoadProperties(GeneralLedger)

        End Sub
        Public Sub SaveToEntity(ByRef GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger)

            'GeneralLedger.Transaction = Me.Transaction
            GeneralLedger.PostedDate = Me.PostedDate
            GeneralLedger.EnteredDate = Me.EnteredDate
            GeneralLedger.ModifiedDate = Me.ModifiedDate
            GeneralLedger.PostPeriodCode = Me.PostPeriodCode
            GeneralLedger.UserCode = Me.UserCode
            GeneralLedger.Description = Me.Description
            GeneralLedger.GLSourceCode = Me.GLSourceCode
            GeneralLedger.BatchDate = Me.BatchDate
            GeneralLedger.CreateDate = Me.CreateDate

            If Me.IsVoided Then

                GeneralLedger.IsVoided = 1

            Else

                GeneralLedger.IsVoided = Nothing

            End If

            GeneralLedger.ReverseFlag = If(Me.ReverseFlag, "1", Nothing)

        End Sub
        Public Sub Refresh(GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger)

            LoadProperties(GeneralLedger)

        End Sub
        Private Sub LoadProperties(GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger)

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
            Me.IsVoided = If(GeneralLedger.IsVoided.GetValueOrDefault(0) = 1, True, False)
            Me.ReverseFlag = If(GeneralLedger.ReverseFlag = "1", True, False)
            Me.CreateDate = GeneralLedger.CreateDate
            Me.PostedToSummary = Me.PostedDate.HasValue

            If GeneralLedger.GeneralLedgerDocuments IsNot Nothing AndAlso GeneralLedger.GeneralLedgerDocuments.Count > 0 Then

                Me.HasDocuments = True

            Else

                Me.HasDocuments = False

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Transaction.ToString

        End Function

#End Region

    End Class

End Namespace