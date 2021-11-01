Namespace MediaManager.Classes

    <Serializable()>
    Public Class MediaManagerPurchaseOrderStatus

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            PONumber
            RevisionNumber
            OrderDescription
            OrderStatusID
            OrderStatusDescription
            RevisedDate
            RevisedByName
        End Enum

#End Region

#Region " Variables "

        Private _RevisedDate As Nullable(Of Date) = Nothing
        Private _TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="PO" & vbCrLf & "Number")>
        Public Property PONumber() As Integer

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Revision" & vbCrLf & "Number")>
        Public Property RevisionNumber() As Integer

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="PO" & vbCrLf & "Description")>
        Public Property OrderDescription() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property OrderStatusID() As Short

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="PO Status" & vbCrLf & "Description")>
        Public Property OrderStatusDescription() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="G", CustomColumnCaption:="Date")>
        Public Property RevisedDate() As Nullable(Of Date)
            Get
                RevisedDate = AdvantageFramework.VCC.DisplayLocalDate(_TimezoneOffset, _RevisedDate)
            End Get
            Set(value As Nullable(Of Date))
                _RevisedDate = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="By")>
        Public Property RevisedByName() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(PurchaseOrderStatus As AdvantageFramework.Database.Entities.PurchaseOrderStatus, OrderDescription As String, TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset)

            Me.ID = PurchaseOrderStatus.ID
            Me.PONumber = PurchaseOrderStatus.PONumber
            Me.RevisionNumber = PurchaseOrderStatus.RevisionNumber
            Me.OrderStatusID = PurchaseOrderStatus.OrderStatusID
            Me.OrderStatusDescription = PurchaseOrderStatus.OrderStatus.Description
            _RevisedDate = PurchaseOrderStatus.RevisedDate
            Me.RevisedByName = PurchaseOrderStatus.RevisedByName
            Me.OrderDescription = OrderDescription
            _TimezoneOffset = TimezoneOffset

        End Sub

#End Region

    End Class

End Namespace