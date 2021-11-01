Namespace Database.Classes

    <Serializable()>
    Public Class TrafficScheduleUserColumn

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ColumnName
            ColumnLongDescription
            ColumnShortDescription
            AgencyRequired
            ClientRequired
            Active
            DefaultShowLongDescription
            ShowLongDescription
            SequenceNumber
            HeaderCode
            ShowOnGrid
            ShowOnAddNew
            ShowFull
            HeaderText
            DisplayType
            ColumnOrder
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ColumnName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Column Heading")>
        Public Property ColumnShortDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Description")>
        Public Property ColumnLongDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AgencyRequired() As Byte

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ClientRequired() As Byte

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Active() As Byte

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DefaultShowLongDescription() As Byte

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ShowLongDescription() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SequenceNumber() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HeaderCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property ShowOnGrid() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ShowOnAddNew() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ShowFull() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HeaderText() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DisplayType() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ColumnOrder() As Short

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
