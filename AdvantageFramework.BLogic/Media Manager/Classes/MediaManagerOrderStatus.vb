Namespace MediaManager.Classes

    <Serializable()>
    Public Class MediaManagerOrderStatus

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaType
            OrderNumber
            LineNumber
            MonthNumber
            YearNumber
            RevisionNumber
            OrderDescription
            OrderStatusID
            OrderStatusDescription
            RevisedDate
            RevisedByName
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _MediaType As String = Nothing
        Private _OrderNumber As Integer = Nothing
        Private _LineNumber As Short = Nothing
        Private _RevisionNumber As Integer = Nothing
        Private _OrderDescription As String = Nothing
        Private _OrderStatusID As Short = Nothing
        Private _OrderStatusDescription As String = Nothing
        Private _RevisedDate As Nullable(Of Date) = Nothing
        Private _RevisedByName As String = Nothing
        Private _TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Media" & vbCrLf & "Type")>
        Public Property MediaType() As String
            Get
                MediaType = _MediaType
            End Get
            Set(value As String)
                _MediaType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Order" & vbCrLf & "Number")>
        Public Property OrderNumber() As Integer
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As Integer)
                _OrderNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Line" & vbCrLf & "Number")>
        Public Property LineNumber() As Short
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Short)
                _LineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Month")>
        Public Property MonthNumber() As Nullable(Of Short)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Year")>
        Public Property YearNumber() As Nullable(Of Short)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Revision" & vbCrLf & "Number")>
        Public Property RevisionNumber() As Integer
            Get
                RevisionNumber = _RevisionNumber
            End Get
            Set(value As Integer)
                _RevisionNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Order" & vbCrLf & "Description")>
        Public Property OrderDescription() As String
            Get
                OrderDescription = _OrderDescription
            End Get
            Set(value As String)
                _OrderDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property OrderStatusID() As Short
            Get
                OrderStatusID = _OrderStatusID
            End Get
            Set(value As Short)
                _OrderStatusID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Order Status" & vbCrLf & "Description")>
        Public Property OrderStatusDescription() As String
            Get
                OrderStatusDescription = _OrderStatusDescription
            End Get
            Set(value As String)
                _OrderStatusDescription = value
            End Set
        End Property
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
            Get
                RevisedByName = _RevisedByName
            End Get
            Set(value As String)
                _RevisedByName = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal InternetOrderStatus As AdvantageFramework.Database.Entities.InternetOrderStatus, ByVal OrderDescription As String, TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset)

            _ID = InternetOrderStatus.ID
            _OrderNumber = InternetOrderStatus.OrderNumber
            _LineNumber = InternetOrderStatus.LineNumber
            _RevisionNumber = InternetOrderStatus.RevisionNumber
            _OrderStatusID = InternetOrderStatus.RevisionNumber
            _OrderStatusDescription = InternetOrderStatus.OrderStatus.Description
            _RevisedDate = InternetOrderStatus.RevisedDate
            _RevisedByName = InternetOrderStatus.RevisedByName
            _MediaType = "Internet"
            _OrderDescription = OrderDescription
            _TimezoneOffset = TimezoneOffset

        End Sub
        Public Sub New(ByVal MagazineOrderStatus As AdvantageFramework.Database.Entities.MagazineOrderStatus, ByVal OrderDescription As String, TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset)

            _ID = MagazineOrderStatus.ID
            _OrderNumber = MagazineOrderStatus.OrderNumber
            _LineNumber = MagazineOrderStatus.LineNumber
            _RevisionNumber = MagazineOrderStatus.RevisionNumber
            _OrderStatusID = MagazineOrderStatus.RevisionNumber
            _OrderStatusDescription = MagazineOrderStatus.OrderStatus.Description
            _RevisedDate = MagazineOrderStatus.RevisedDate
            _RevisedByName = MagazineOrderStatus.RevisedByName
            _MediaType = "Magazine"
            _OrderDescription = OrderDescription
            _TimezoneOffset = TimezoneOffset

        End Sub
        Public Sub New(ByVal NewspaperOrderStatus As AdvantageFramework.Database.Entities.NewspaperOrderStatus, ByVal OrderDescription As String, TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset)

            _ID = NewspaperOrderStatus.ID
            _OrderNumber = NewspaperOrderStatus.OrderNumber
            _LineNumber = NewspaperOrderStatus.LineNumber
            _RevisionNumber = NewspaperOrderStatus.RevisionNumber
            _OrderStatusID = NewspaperOrderStatus.RevisionNumber
            _OrderStatusDescription = NewspaperOrderStatus.OrderStatus.Description
            _RevisedDate = NewspaperOrderStatus.RevisedDate
            _RevisedByName = NewspaperOrderStatus.RevisedByName
            _MediaType = "Newspaper"
            _OrderDescription = OrderDescription
            _TimezoneOffset = TimezoneOffset

        End Sub
        Public Sub New(ByVal OutOfHomeOrderStatus As AdvantageFramework.Database.Entities.OutOfHomeOrderStatus, ByVal OrderDescription As String, TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset)

            _ID = OutOfHomeOrderStatus.ID
            _OrderNumber = OutOfHomeOrderStatus.OrderNumber
            _LineNumber = OutOfHomeOrderStatus.LineNumber
            _RevisionNumber = OutOfHomeOrderStatus.RevisionNumber
            _OrderStatusID = OutOfHomeOrderStatus.RevisionNumber
            _OrderStatusDescription = OutOfHomeOrderStatus.OrderStatus.Description
            _RevisedDate = OutOfHomeOrderStatus.RevisedDate
            _RevisedByName = OutOfHomeOrderStatus.RevisedByName
            _MediaType = "Out Of Home"
            _OrderDescription = OrderDescription
            _TimezoneOffset = TimezoneOffset

        End Sub
        Public Sub New(RadioOrderStatus As AdvantageFramework.Database.Entities.RadioOrderStatus, OrderDescription As String, TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset,
                       RadioOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.RadioOrderDetail))

            _ID = RadioOrderStatus.ID
            _OrderNumber = RadioOrderStatus.OrderNumber
            _LineNumber = RadioOrderStatus.LineNumber
            _RevisionNumber = RadioOrderStatus.RevisionNumber
            _OrderStatusID = RadioOrderStatus.RevisionNumber
            _OrderStatusDescription = RadioOrderStatus.OrderStatus.Description
            _RevisedDate = RadioOrderStatus.RevisedDate
            _RevisedByName = RadioOrderStatus.RevisedByName
            _MediaType = "Radio"
            _OrderDescription = OrderDescription
            _TimezoneOffset = TimezoneOffset
            Me.MonthNumber = RadioOrderDetails.Where(Function(Entity) Entity.LineNumber = Me.LineNumber).First.MonthNumber
            Me.YearNumber = RadioOrderDetails.Where(Function(Entity) Entity.LineNumber = Me.LineNumber).First.YearNumber

        End Sub
        Public Sub New(TVOrderStatus As AdvantageFramework.Database.Entities.TVOrderStatus, OrderDescription As String, TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset,
                       TVOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.TVOrderDetail))

            _ID = TVOrderStatus.ID
            _OrderNumber = TVOrderStatus.OrderNumber
            _LineNumber = TVOrderStatus.LineNumber
            _RevisionNumber = TVOrderStatus.RevisionNumber
            _OrderStatusID = TVOrderStatus.RevisionNumber
            _OrderStatusDescription = TVOrderStatus.OrderStatus.Description
            _RevisedDate = TVOrderStatus.RevisedDate
            _RevisedByName = TVOrderStatus.RevisedByName
            _MediaType = "TV"
            _OrderDescription = OrderDescription
            _TimezoneOffset = TimezoneOffset
            Me.MonthNumber = TVOrderDetails.Where(Function(Entity) Entity.LineNumber = Me.LineNumber).First.MonthNumber
            Me.YearNumber = TVOrderDetails.Where(Function(Entity) Entity.LineNumber = Me.LineNumber).First.YearNumber

        End Sub

#End Region

    End Class

End Namespace