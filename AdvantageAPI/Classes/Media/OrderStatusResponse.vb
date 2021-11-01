<DataContract>
Public Class OrderStatusResponse

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

#End Region

#Region " Properties "

    <DataMember>
    Public Property OrderNumber As Integer
    <DataMember>
    Public Property LineNumber As Short
    <DataMember>
    Public Property RevisionNumber As Integer
    <DataMember>
    Public Property OrderStatusID As Short
    <DataMember>
    Public Property RevisedDate As Nullable(Of Date)
    <DataMember>
    Public Property RevisedByUserCode As String
    <DataMember>
    Public Property RevisedByName As String


#End Region

#Region " Methods "

    Public Sub New(InternetOrderStatus As AdvantageFramework.Database.Entities.InternetOrderStatus)

        Me.OrderNumber = InternetOrderStatus.OrderNumber
        Me.LineNumber = InternetOrderStatus.LineNumber
        Me.RevisionNumber = InternetOrderStatus.RevisionNumber
        Me.OrderStatusID = InternetOrderStatus.OrderStatusID
        Me.RevisedDate = InternetOrderStatus.RevisedDate
        Me.RevisedByUserCode = InternetOrderStatus.RevisedByUserCode
        Me.RevisedByName = InternetOrderStatus.RevisedByName

    End Sub

    Public Sub New(NewspaperOrderStatus As AdvantageFramework.Database.Entities.NewspaperOrderStatus)

        Me.OrderNumber = NewspaperOrderStatus.OrderNumber
        Me.LineNumber = NewspaperOrderStatus.LineNumber
        Me.RevisionNumber = NewspaperOrderStatus.RevisionNumber
        Me.OrderStatusID = NewspaperOrderStatus.OrderStatusID
        Me.RevisedDate = NewspaperOrderStatus.RevisedDate
        Me.RevisedByUserCode = NewspaperOrderStatus.RevisedByUserCode
        Me.RevisedByName = NewspaperOrderStatus.RevisedByName

    End Sub

    Public Sub New(MagazineOrderStatus As AdvantageFramework.Database.Entities.MagazineOrderStatus)

        Me.OrderNumber = MagazineOrderStatus.OrderNumber
        Me.LineNumber = MagazineOrderStatus.LineNumber
        Me.RevisionNumber = MagazineOrderStatus.RevisionNumber
        Me.OrderStatusID = MagazineOrderStatus.OrderStatusID
        Me.RevisedDate = MagazineOrderStatus.RevisedDate
        Me.RevisedByUserCode = MagazineOrderStatus.RevisedByUserCode
        Me.RevisedByName = MagazineOrderStatus.RevisedByName

    End Sub

    Public Sub New(OutOfHomeOrderStatus As AdvantageFramework.Database.Entities.OutOfHomeOrderStatus)

        Me.OrderNumber = OutOfHomeOrderStatus.OrderNumber
        Me.LineNumber = OutOfHomeOrderStatus.LineNumber
        Me.RevisionNumber = OutOfHomeOrderStatus.RevisionNumber
        Me.OrderStatusID = OutOfHomeOrderStatus.OrderStatusID
        Me.RevisedDate = OutOfHomeOrderStatus.RevisedDate
        Me.RevisedByUserCode = OutOfHomeOrderStatus.RevisedByUserCode
        Me.RevisedByName = OutOfHomeOrderStatus.RevisedByName

    End Sub

    Public Sub New(TVOrderStatus As AdvantageFramework.Database.Entities.TVOrderStatus)

        Me.OrderNumber = TVOrderStatus.OrderNumber
        Me.LineNumber = TVOrderStatus.LineNumber
        Me.RevisionNumber = TVOrderStatus.RevisionNumber
        Me.OrderStatusID = TVOrderStatus.OrderStatusID
        Me.RevisedDate = TVOrderStatus.RevisedDate
        Me.RevisedByUserCode = TVOrderStatus.RevisedByUserCode
        Me.RevisedByName = TVOrderStatus.RevisedByName

    End Sub

    Public Sub New(RadioOrderStatus As AdvantageFramework.Database.Entities.RadioOrderStatus)

        Me.OrderNumber = RadioOrderStatus.OrderNumber
        Me.LineNumber = RadioOrderStatus.LineNumber
        Me.RevisionNumber = RadioOrderStatus.RevisionNumber
        Me.OrderStatusID = RadioOrderStatus.OrderStatusID
        Me.RevisedDate = RadioOrderStatus.RevisedDate
        Me.RevisedByUserCode = RadioOrderStatus.RevisedByUserCode
        Me.RevisedByName = RadioOrderStatus.RevisedByName

    End Sub

#End Region

End Class

