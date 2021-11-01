Namespace Security.Database.Views

    <Table("V_SEC_GROUP_PERMISSION")>
    Public Class GroupPermission
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ApplicationID
            ModuleID
            ModuleCode
            [Module]
            ModuleIsCategory
            ModuleInfoID
            GroupID
            GroupName
            GroupDescription
            IsBlocked
            CanPrint
            CanUpdate
            CanAdd
            Custom1
            Custom2
            ApplicationIsBlocked
            ApplicationCanPrint
            ApplicationCanUpdate
            ApplicationCanAdd
            ApplicationCustom1
            ApplicationCustom2

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Guid
        <Required>
        <Column("ApplicationID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApplicationID() As Integer
        <Required>
        <Column("ModuleID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModuleID() As Integer
        <Required>
        <MaxLength(100)>
        <Column("ModuleCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModuleCode() As String
        <Required>
        <MaxLength(100)>
        <Column("Module", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property [Module]() As String
        <Required>
        <Column("ModuleIsCategory")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModuleIsCategory() As Boolean
        <Required>
        <Column("ModuleInfoID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModuleInfoID() As Integer
        <Required>
        <Column("GroupID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupID() As Integer
        <MaxLength(50)>
        <Column("GroupName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupName() As String
        <MaxLength(100)>
        <Column("GroupDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupDescription() As String
        <Required>
        <Column("IsBlocked")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsBlocked() As Boolean
        <Required>
        <Column("CanPrint")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CanPrint() As Boolean
        <Required>
        <Column("CanUpdate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CanUpdate() As Boolean
        <Required>
        <Column("CanAdd")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CanAdd() As Boolean
        <Required>
        <Column("Custom1")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Custom1() As Boolean
        <Required>
        <Column("Custom2")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Custom2() As Boolean
        <Required>
        <Column("ApplicationIsBlocked")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApplicationIsBlocked() As Boolean
        <Required>
        <Column("ApplicationCanPrint")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApplicationCanPrint() As Boolean
        <Required>
        <Column("ApplicationCanUpdate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApplicationCanUpdate() As Boolean
        <Required>
        <Column("ApplicationCanAdd")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApplicationCanAdd() As Boolean
        <Required>
        <Column("ApplicationCustom1")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApplicationCustom1() As Boolean
        <Required>
        <Column("ApplicationCustom2")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApplicationCustom2() As Boolean


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
