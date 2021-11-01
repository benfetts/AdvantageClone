Namespace Database.Classes

    <Serializable()>
    Public Class PurchaseOrderDetailsComplex

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            PONumber
            PODescription
            ClientCode
            DivisionCode
            ProductCode
            JobNumber
            JobComponentNumber
            LineTotal
            IsAttachedToAP
            DisplayPONumber
            VoidFlag
            POComplete
            ModifiedByUserCode
            ModifiedDate
            SortOrder
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property PONumber() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", CustomColumnCaption:="Number")>
        Public Property DisplayPONumber() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", CustomColumnCaption:="Description")>
        Public Property PODescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", CustomColumnCaption:="")>
        Public Property ClientCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", CustomColumnCaption:="")>
        Public Property DivisionCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", CustomColumnCaption:="")>
        Public Property ProductCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", CustomColumnCaption:="")>
        Public Property JobNumber() As Nullable(Of Integer)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", CustomColumnCaption:="")>
        Public Property JobComponentNumber() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", CustomColumnCaption:="Amount")>
        Public Property LineTotal() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", CustomColumnCaption:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsAttachedToAP() As Nullable(Of Boolean)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", CustomColumnCaption:="Is Void", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property VoidFlag() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", CustomColumnCaption:="Is Complete", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property POComplete() As Nullable(Of Short)

        Public Property ModifiedByUserCode() As String

        Public Property ModifiedDate() As Nullable(Of Date)

        Public Property SortOrder() As Integer

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.PONumber.ToString

        End Function

#End Region

    End Class

End Namespace
