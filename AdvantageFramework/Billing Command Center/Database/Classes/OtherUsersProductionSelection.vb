Namespace BillingCommandCenter.Database.Classes

    <Serializable()>
    Public Class OtherUsersProductionSelection

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            BillingCommandCenterID
            BillingUser
            EmployeeName
            JobNumber
            JobComponentNumber
            ClientCode
            DivisionCode
            ProductCode
            BatchName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BillingCommandCenterID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BillingUser() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeName() As String

        Public Property JobNumber() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Component")>
        Public Property JobComponentNumber() As Short

        Public Property ClientCode() As String

        Public Property DivisionCode() As String

        Public Property ProductCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BatchName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BillingUserRaw() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.BillingCommandCenterID.ToString

        End Function

#End Region

    End Class

End Namespace
