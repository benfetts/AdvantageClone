Namespace Database.Classes

    <Serializable()>
    Public Class PurchaseOrderComplex

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Number
            DisplayPONumber
            Description
            IsVoid
            IsComplete
            EmployeeCode
            EmployeeName
            VendorCode
            VendorName
            PODate
            PODueDate
            ModifiedByUserCode
            ModifiedDate
            SortOrder
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Number() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Number")>
        Public Property DisplayPONumber() As String

        Public Property Description() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Issued By")>
        Public Property EmployeeCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="")>
        Public Property EmployeeName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Issued To")>
        Public Property VendorCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="")>
        Public Property VendorName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Date")>
        Public Property PODate() As Nullable(Of Date)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Due Date")>
        Public Property PODueDate() As Nullable(Of Date)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsVoid() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsComplete() As Nullable(Of Short)

        Public Property ModifiedByUserCode() As String

        Public Property ModifiedDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SortOrder() As Integer

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Number.ToString

        End Function

#End Region

    End Class

End Namespace
