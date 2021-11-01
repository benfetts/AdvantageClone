Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.ATB_REV_DTL_ORDER")>
    Public Class MediaATBRevisionDetailOrder
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            DetailID
            OrderMonth
            OrderYear
            OrderID
            OrderLineID
            OrderLineNumber
            OrderNumber
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _DetailID As Long = 0
        Private _OrderMonth As Long = 0
        Private _OrderYear As Long = 0
        Private _OrderID As System.Nullable(Of Long) = 0
        Private _OrderLineID As System.Nullable(Of Long) = 0
        Private _OrderLineNumber As System.Nullable(Of Long) = 0
        Private _OrderNumber As System.Nullable(Of Long) = 0

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ATB_REV_DTL_ORDER_ID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DBType:="int NOT NULL IDENTITY"), _
        System.ComponentModel.DisplayName("ID")> _
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ATB_REV_DTL_ID", Storage:="_DetailID", DBType:="int"), _
        System.ComponentModel.DisplayName("DetailID")> _
        Public Property DetailID() As Long
            Get
                DetailID = _DetailID
            End Get
            Set(ByVal value As Long)
                _DetailID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MONTH", Storage:="_OrderMonth", DBType:="int"), _
        System.ComponentModel.DisplayName("OrderMonth")> _
        Public Property OrderMonth() As Long
            Get
                OrderMonth = _OrderMonth
            End Get
            Set(ByVal value As Long)
                _OrderMonth = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="YEAR", Storage:="_OrderYear", DBType:="int"), _
        System.ComponentModel.DisplayName("OrderYear")> _
        Public Property OrderYear() As Long
            Get
                OrderYear = _OrderYear
            End Get
            Set(ByVal value As Long)
                _OrderYear = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ORDER_ID", Storage:="_OrderID", DBType:="int"), _
        System.ComponentModel.DisplayName("OrderID")> _
        Public Property OrderID() As System.Nullable(Of Long)
            Get
                OrderID = _OrderID
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _OrderID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ORDER_LINE_ID", Storage:="_OrderLineID", DBType:="int"), _
        System.ComponentModel.DisplayName("OrderLineID")> _
        Public Property OrderLineID() As System.Nullable(Of Long)
            Get
                OrderLineID = _OrderLineID
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _OrderLineID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ORDER_LINE_NBR", Storage:="_OrderLineNumber", DBType:="int"), _
        System.ComponentModel.DisplayName("OrderLineNumber")> _
        Public Property OrderLineNumber() As System.Nullable(Of Long)
            Get
                OrderLineNumber = _OrderLineNumber
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _OrderLineNumber = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ORDER_NBR", Storage:="_OrderNumber", DBType:="int"), _
        System.ComponentModel.DisplayName("OrderNumber")> _
        Public Property OrderNumber() As System.Nullable(Of Long)
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _OrderNumber = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
