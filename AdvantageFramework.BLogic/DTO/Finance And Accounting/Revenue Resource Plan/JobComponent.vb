Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    Public Class JobComponent
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ClientCode() As String
        <Required>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ClientName() As String
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property DivisionCode() As String
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property DivisionName() As String
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ProductCode() As String
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ProductName() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property JobNumber() As Integer
        <MaxLength(60)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property JobDescription() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Comp Number")>
        Public Property JobComponentNumber() As Short
        <Required>
        <MaxLength(60)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Comp Description")>
        Public Property JobComponentDescription() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.ClientCode = String.Empty
            Me.ClientName = String.Empty
            Me.DivisionCode = String.Empty
            Me.DivisionName = String.Empty
            Me.ProductCode = String.Empty
            Me.ProductName = String.Empty
            Me.JobNumber = 0
            Me.JobDescription = String.Empty
            Me.JobComponentNumber = 0
            Me.JobComponentDescription = String.Empty

        End Sub
        Public Sub New(JobComponent As AdvantageFramework.Database.Views.JobComponentView)

            Me.ClientCode = JobComponent.ClientCode
            Me.ClientName = JobComponent.ClientName
            Me.DivisionCode = JobComponent.DivisionCode
            Me.DivisionName = JobComponent.DivisionName
            Me.ProductCode = JobComponent.ProductCode
            Me.ProductName = JobComponent.ProductDescription
            Me.JobNumber = JobComponent.JobNumber
            Me.JobDescription = JobComponent.JobDescription
            Me.JobComponentNumber = JobComponent.JobComponentNumber
            Me.JobComponentDescription = JobComponent.JobComponentDescription

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ClientCode.ToString & "-" & Me.DivisionCode.ToString & "-" & Me.ProductCode.ToString & "  " & Me.JobNumber & "-" & Me.JobComponentNumber

        End Function

#End Region

    End Class

End Namespace
