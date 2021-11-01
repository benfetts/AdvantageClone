Namespace Dashboard.Classes

    <Serializable()>
    Public Class EmployeeTimeForcastDashboard
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            ClientName
            ActualHours
            ActualAmount
            ForecastHours
            ForecastAmount
            VarianceHours
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ActualHours() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ActualAmount() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ForecastHours() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ForecastAmount() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VarianceHours() As Decimal


#End Region

#Region " Methods "

        Public Sub New()

            Me.ClientCode = ""
            Me.ClientName = ""
            Me.ActualHours = 0
            Me.ActualAmount = 0
            Me.ForecastHours = 0
            Me.ForecastAmount = 0
            Me.VarianceHours = 0

        End Sub
        Public Sub New(ByVal ClientCode As String, ByVal ClientName As String, ByVal ForecastHours As Decimal, ByVal ForecastAmount As Decimal, ByVal ActualHours As Decimal, ByVal ActualAmount As Decimal, ByVal VarianceHours As Decimal)

            Me.ClientCode = ClientCode
            Me.ClientName = ClientName
            Me.ActualHours = ActualHours
            Me.ActualAmount = ActualAmount
            Me.ForecastHours = ForecastHours
            Me.ForecastAmount = ForecastAmount
            Me.VarianceHours = VarianceHours

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ClientCode.ToString

        End Function

#End Region

    End Class

End Namespace