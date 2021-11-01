Namespace Exporting.DataFilterClasses

    <Serializable()>
    Public Class YayPayInvoiceWithPaymentsAlt
        Implements AdvantageFramework.Exporting.Interfaces.IExportDataFilter

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            UserCode
            PeriodCutoff
            AgingDate
            AgingOption
            IncludeDetails
            RecordSource
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property UserCode() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property PeriodCutoff() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property AgingDate() As Date
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property AgingOption() As Short
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property IncludeDetails() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property RecordSource() As Integer

#End Region

#Region " Methods "

        Public Sub New()

            Me.UserCode = String.Empty
            Me.PeriodCutoff = String.Empty
            Me.AgingDate = CDate(Now.ToShortDateString)
            Me.AgingOption = 1
            Me.IncludeDetails = True
            Me.RecordSource = 0

        End Sub
        Public Sub New(UserCode As String, PeriodCutoff As String, AgingDate As Date, AgingOption As Short, IncludeDetails As Boolean, RecordSource As Integer)

            Me.UserCode = UserCode
            Me.PeriodCutoff = PeriodCutoff
            Me.AgingDate = AgingDate
            Me.AgingOption = AgingOption
            Me.IncludeDetails = IncludeDetails
            Me.RecordSource = RecordSource

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.UserCode & " - " & Me.PeriodCutoff & " - " & Me.AgingDate.ToShortDateString & " - " & Me.AgingOption & " - " & Me.IncludeDetails & " - " & Me.RecordSource

        End Function
        Public Function EntityFilterString() As String Implements Interfaces.IExportDataFilter.EntityFilterString

            'objects
            Dim FilterString As String = ""

            FilterString = String.Format("EXEC dbo.usp_wv_Dataset_AR_Aging_YayPay '{0}', '{1}', '{2}', {3}, {4}, {5}", Me.UserCode, Me.PeriodCutoff, Me.AgingDate.ToShortDateString, Me.AgingOption, If(Me.IncludeDetails, 1, 0), Me.RecordSource)

            EntityFilterString = FilterString

        End Function
        Public Function Validate(ByRef ErrorMessage As String) As Boolean Implements Interfaces.IExportDataFilter.Validate

            'objects
            Dim IsValid As Boolean = False

            IsValid = True

            Validate = IsValid

        End Function

#End Region

    End Class

End Namespace
