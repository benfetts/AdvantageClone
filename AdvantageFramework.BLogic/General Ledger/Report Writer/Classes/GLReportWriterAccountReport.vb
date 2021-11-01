Namespace GeneralLedger.ReportWriter.Classes

    Public Class GLReportWriterAccountReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            GLAType
            GLACode
            GLADescription
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLAType As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLACode As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLADescription As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property GLACodeDescription As String
            Get
                GLACodeDescription = Me.GLACode & " - " & Me.GLADescription
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(GLAType As String, GLACode As String, GLADescription As String)

            _GLAType = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Database.Entities.GeneralLedgerAccountTypes), CInt(GLAType))

            _GLACode = GLACode
            _GLADescription = GLADescription

        End Sub

#End Region

    End Class

End Namespace

