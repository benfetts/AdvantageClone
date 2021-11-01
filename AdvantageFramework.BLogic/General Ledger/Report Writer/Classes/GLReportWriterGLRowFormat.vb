Namespace GeneralLedger.ReportWriter.Classes

    Public Class GLReportWriterGLRowFormatReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ReportTemplateDescription
            RowIndex
            Description
            BalanceType
            DisplayType
            LinkType
            AccountType
            GLACode
            GLACodeRangeStart
            GLACodeRangeTo
            Wildcard
            AccountGroupCode
            Type
            TotalType
            UseBaseAccountCodes
            IndentSpaces
            UnderlineAmount
            IsBold
            UseCurrencyFormat
            SuppressIfAllZeros
            NumberOfDecimalPlaces
            RollUp
            DataOption
            DataCalculation
            CreatedByUserCode
            CreatedDate
            ModifiedByUserCode
            ModifiedDate
			DoubleUnderlineAmount
			IsVisible
		End Enum

#End Region

#Region " Variables "

        Private _GLReportTemplateRow As AdvantageFramework.Database.Entities.GLReportTemplateRow = Nothing
        Private _ReportTemplateDescription As String = Nothing
        Private _GLReportWriterAccountReportList As Generic.List(Of AdvantageFramework.GeneralLedger.ReportWriter.Classes.GLReportWriterAccountReport) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property GLReportTemplateRow As AdvantageFramework.Database.Entities.GLReportTemplateRow
            Get
                GLReportTemplateRow = _GLReportTemplateRow
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property RowIndex As Integer
            Get
                RowIndex = _GLReportTemplateRow.RowIndex
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Description As String
            Get
                Description = _GLReportTemplateRow.Description
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property BalanceType As String
            Get

                Dim BalanceTypeString As String = Nothing

                Select Case _GLReportTemplateRow.BalanceType

                    Case AdvantageFramework.GeneralLedger.ReportWriter.BalanceTypes.Credit

                        BalanceTypeString = "Credit"

                    Case AdvantageFramework.GeneralLedger.ReportWriter.BalanceTypes.Debit

                        BalanceTypeString = "Debit"

                End Select

                BalanceType = BalanceTypeString

            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DisplayType As String
            Get

                Dim DisplayTypeString As String = Nothing

                Select Case _GLReportTemplateRow.DisplayType

                    Case AdvantageFramework.GeneralLedger.ReportWriter.DisplayTypes.AccountCode

                        DisplayTypeString = "Account Code"

                    Case AdvantageFramework.GeneralLedger.ReportWriter.DisplayTypes.AccountDescription

                        DisplayTypeString = "Account Description"

                    Case AdvantageFramework.GeneralLedger.ReportWriter.DisplayTypes.Description

                        DisplayTypeString = "Description"

                    Case AdvantageFramework.GeneralLedger.ReportWriter.DisplayTypes.FullAccount

                        DisplayTypeString = "Full Account"

                End Select

                DisplayType = DisplayTypeString

            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property LinkType As Integer
            Get
                LinkType = _GLReportTemplateRow.LinkType
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property AccountType As Integer?
            Get
                AccountType = _GLReportTemplateRow.AccountType
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property GLACode As String
            Get
                GLACode = _GLReportTemplateRow.GLACode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property GLACodeRangeStart As String
            Get
                GLACodeRangeStart = _GLReportTemplateRow.GLACodeRangeStart
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property GLACodeRangeTo As String
            Get
                GLACodeRangeTo = _GLReportTemplateRow.GLACodeRangeTo
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Wildcard As String
            Get
                Wildcard = _GLReportTemplateRow.Wildcard
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property AccountGroupCode As String
            Get
                AccountGroupCode = _GLReportTemplateRow.AccountGroupCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Type As String
            Get

                Dim TypeString As String = Nothing

                Select Case _GLReportTemplateRow.Type

                    Case AdvantageFramework.GeneralLedger.ReportWriter.RowTypes.Account
                        TypeString = "Account"

                    Case AdvantageFramework.GeneralLedger.ReportWriter.RowTypes.Other
                        TypeString = "Other"

                    Case AdvantageFramework.GeneralLedger.ReportWriter.RowTypes.Total
                        TypeString = "Total"

                End Select

                Type = TypeString

            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property TotalType As Integer
            Get
                TotalType = _GLReportTemplateRow.TotalType
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property UseBaseAccountCodes As Boolean
            Get
                UseBaseAccountCodes = _GLReportTemplateRow.UseBaseAccountCodes
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property IndentSpaces As Integer
            Get
                IndentSpaces = _GLReportTemplateRow.IndentSpaces
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property UnderlineAmount As Boolean
            Get
                UnderlineAmount = _GLReportTemplateRow.UnderlineAmount
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property IsBold As Boolean
            Get
                IsBold = _GLReportTemplateRow.IsBold
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property UseCurrencyFormat As Boolean
            Get
                UseCurrencyFormat = _GLReportTemplateRow.UseCurrencyFormat
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property SuppressIfAllZeros As Boolean
            Get
                SuppressIfAllZeros = _GLReportTemplateRow.SuppressIfAllZeros
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property NumberOfDecimalPlaces As Integer
            Get
                NumberOfDecimalPlaces = _GLReportTemplateRow.NumberOfDecimalPlaces
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property RollUp As Boolean
            Get
                RollUp = _GLReportTemplateRow.RollUp
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DataOption As Integer
            Get
                DataOption = _GLReportTemplateRow.DataOption
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DataCalculation As Integer
            Get
                DataCalculation = _GLReportTemplateRow.DataCalculation
            End Get
        End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity()>
		Public ReadOnly Property DoubleUnderlineAmount As Boolean
			Get
				DoubleUnderlineAmount = _GLReportTemplateRow.DoubleUnderlineAmount
			End Get
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity()>
		Public ReadOnly Property IsVisible As Boolean
			Get
				IsVisible = _GLReportTemplateRow.IsVisible
			End Get
		End Property
		Public ReadOnly Property GLReportWriterAccountReportList As Generic.List(Of AdvantageFramework.GeneralLedger.ReportWriter.Classes.GLReportWriterAccountReport)
            Get
                GLReportWriterAccountReportList = _GLReportWriterAccountReportList
            End Get
        End Property
        Public ReadOnly Property ReportTemplateDescription As String
            Get
                ReportTemplateDescription = _ReportTemplateDescription
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(GLReportTemplateRow As AdvantageFramework.Database.Entities.GLReportTemplateRow)

            _GLReportTemplateRow = GLReportTemplateRow

            _ReportTemplateDescription = GLReportTemplateRow.GLReportTemplate.Description

        End Sub
        Public Sub SetGLA(GLReportWriterAccountReportList As Generic.List(Of AdvantageFramework.GeneralLedger.ReportWriter.Classes.GLReportWriterAccountReport))

            _GLReportWriterAccountReportList = GLReportWriterAccountReportList

        End Sub

#End Region

    End Class

End Namespace

