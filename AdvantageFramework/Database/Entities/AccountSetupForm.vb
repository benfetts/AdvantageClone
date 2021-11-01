Namespace Database.Entities

    <System.ComponentModel.DataAnnotations.Schema.Table("ACCOUNT_SETUP_FORM")>
    Public Class AccountSetupForm
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            JobNumber
            JobComponentNumber
            ClientCode
            DivisionCode
            ProductCode
            AccountSetupCode1
            AccountSetupCode2
            AccountSetupCode3
            AccountSetupCode4
            PercentSplit
            Balanced
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.ComponentModel.DataAnnotations.Schema.Column("ACCT_SETUP_ID"),
        System.ComponentModel.DataAnnotations.Key,
        System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer

        <System.ComponentModel.DataAnnotations.Schema.Column("JOB_NUMBER"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property JobNumber() As Integer

        <System.ComponentModel.DataAnnotations.Schema.Column("JOB_COMPONENT_NBR"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property JobComponentNumber() As Short

        <System.ComponentModel.DataAnnotations.Schema.Column("CL_CODE"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ClientCode() As String

        <System.ComponentModel.DataAnnotations.Schema.Column("DIV_CODE"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionCode() As String

        <System.ComponentModel.DataAnnotations.Schema.Column("PRD_CODE"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductCode() As String

        <System.ComponentModel.DataAnnotations.Schema.Column("ACCT_SETUP_CODE_1"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AccountSetupCode1() As String

        <System.ComponentModel.DataAnnotations.Schema.Column("ACCT_SETUP_CODE_2"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AccountSetupCode2() As String

        <System.ComponentModel.DataAnnotations.Schema.Column("ACCT_SETUP_CODE_3"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AccountSetupCode3() As String

        <System.ComponentModel.DataAnnotations.Schema.Column("ACCT_SETUP_CODE_4"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AccountSetupCode4() As String

        <System.ComponentModel.DataAnnotations.Schema.Column("PERCENT_SPLIT"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property PercentSplit() As Decimal

        <System.ComponentModel.DataAnnotations.Schema.Column("BALANCED"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Balanced() As Boolean

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
