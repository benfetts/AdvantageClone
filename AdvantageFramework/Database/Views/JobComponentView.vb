Namespace Database.Views

    <Table("V_JOB_COMPONENT")>
    Public Class JobComponentView
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            JobComponentNumber
            JobComponentDescription
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            JobNumber
            JobDescription
            OfficeCode
            OfficeName
            IsOpen
			JobProcessControl
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("ROWID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <Column("JOB_COMPONENT_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Number")>
        Public Property JobComponentNumber() As Short
        <Required>
        <MaxLength(60)>
        <Column("JOB_COMP_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Description")>
        Public Property JobComponentDescription() As String
        <Required>
        <MaxLength(6)>
        <Column("CL_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
        <MaxLength(40)>
        <Column("CL_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientName() As String
        <Required>
        <MaxLength(6)>
        <Column("DIV_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCode() As String
        <MaxLength(40)>
        <Column("DIV_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionName() As String
        <Required>
        <MaxLength(6)>
        <Column("PRD_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode() As String
        <MaxLength(40)>
        <Column("PRD_DESCRIPTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Product Name")>
        Public Property ProductDescription() As String
        <Required>
        <Column("JOB_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True)>
        Public Property JobNumber() As Integer
        <MaxLength(60)>
        <Column("JOB_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDescription() As String
        <MaxLength(4)>
        <Column("OFFICE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
        <MaxLength(30)>
        <Column("OFFICE_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeName() As String
        <Required>
        <Column("COMP_OPEN")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsOpen() As Integer
        <Column("JOB_PROCESS_CONTRL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property JobProcessControl() As Nullable(Of Short)

#End Region

#Region " Methods "

		Public Shadows Function ToString(ByVal WithJobDetails As Boolean, ByVal WithDescription As Boolean) As String

            If WithJobDetails Then

                If WithDescription Then

                    ToString = CStr(CStr(AdvantageFramework.StringUtilities.PadWithCharacter(Me.JobNumber, 6, "0", True, True) & " - " & Me.JobDescription).Trim & " | " & AdvantageFramework.StringUtilities.PadWithCharacter(Me.JobComponentNumber, 2, "0", True, True) & " - " & Me.JobComponentDescription).Trim

                Else

                    ToString = CStr(CStr(AdvantageFramework.StringUtilities.PadWithCharacter(Me.JobNumber, 6, "0", True, True)).Trim & " - " & AdvantageFramework.StringUtilities.PadWithCharacter(Me.JobComponentNumber, 2, "0", True, True)).Trim

                End If

            Else

                If WithDescription Then

                    ToString = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(Me.JobComponentNumber, 2, "0", True, True) & " - " & Me.JobComponentDescription).Trim

                Else

                    ToString = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(Me.JobComponentNumber, 2, "0", True, True)).Trim

                End If

            End If

        End Function

#End Region

    End Class

End Namespace
