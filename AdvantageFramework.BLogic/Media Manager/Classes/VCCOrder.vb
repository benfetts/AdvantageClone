Namespace MediaManager.Classes

    <Serializable()>
    Public Class VCCOrder

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobNumber
            JobComponentNumber
            JobMediaBillDate
            OrderNumber
            LineNumber
            OrderDescription
            VendorCode
            VendorName
            VendorCost
            VendorCollected
            CardAmount
            TotalClearedAmount
            CardStatus
            CardNumberCVCCode
            NumberOfUses
            ExpirationDate
            Reviewed
            Resolved
            FollowupDate
            LastComment
            LastCommentDate
            LastRefreshedDate
            LastFour
            ModifiedByUserCode
            ModifiedDate
            LastTransactionAction
            VCCIssuedAndUpdated
            TransactionDeclined
            TransactionsOutOfBalance
            TransactionsInBalance
            VCCUpdateMessage
            DateToBill
            JobOrMediaDateToBill
            Cancelled
            DeclinedDate
        End Enum

#End Region

#Region " Variables "

        Private _VCCCard As AdvantageFramework.Database.Interfaces.IVCCCard = Nothing
        Private _VCCUpdateMessage As String = Nothing
        Private _OriginalStatus As String = Nothing
        Private _OriginalCardAmount As Decimal = 0
        Private _VendorCollected As Decimal = 0
        Private _TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Job" & vbCrLf & "Number")>
        Public Property JobNumber() As Nullable(Of Integer)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Component" & vbCrLf & "Number")>
        Public Property JobComponentNumber() As Nullable(Of Short)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Job Media" & vbCrLf & "Date to Bill")>
        Public Property JobMediaBillDate() As Nullable(Of Date)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="PO" & vbCrLf & "Number")>
        Public Property PONumber() As Nullable(Of Integer)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Order" & vbCrLf & "Number")>
        Public Property OrderNumber() As Nullable(Of Integer)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Line" & vbCrLf & "Number")>
        Public Property LineNumber() As Nullable(Of Integer)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Order" & vbCrLf & "Description")>
        Public Property OrderDescription() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Vendor" & vbCrLf & "Code")>
        Public Property VendorCode() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Vendor" & vbCrLf & "Name")>
        Public Property VendorName() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2", CustomColumnCaption:="Total Cost" & vbCrLf & "Payable to Vendor")>
        Public Property VendorCost() As Decimal

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Vendor" & vbCrLf & "Collected")>
        Public Property VendorCollected() As Decimal
            Get
                VendorCollected = _VendorCollected
            End Get
            Set(value As Decimal)
                _VendorCollected = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", IsRequired:=True, CustomColumnCaption:="Card" & vbCrLf & "Amount")>
        Public Property CardAmount() As Decimal
            Get
                CardAmount = _VCCCard.CardAmount
            End Get
            Set(value As Decimal)
                _VCCCard.CardAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", IsRequired:=True, CustomColumnCaption:="Total Cleared" & vbCrLf & "Amount")>
        Public ReadOnly Property TotalClearedAmount() As Decimal
            Get
                TotalClearedAmount = (From Entity In _VCCCard.VCCCardDetails.ToList
                                      Where Entity.Action = AdvantageFramework.Database.Entities.VCCAction.ClearedTransaction
                                      Select Entity).Sum(Function(Entity) Entity.Amount)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Card" & vbCrLf & "Status", PropertyType:=BaseClasses.Methods.PropertyTypes.VCCStatus, IsAutoFillProperty:=True)>
        Public Property CardStatus() As String
            Get
                CardStatus = _VCCCard.Status
            End Get
            Set(value As String)
                _VCCCard.Status = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Card Number/" & vbCrLf & "CVC Code")>
        Public ReadOnly Property CardNumberCVCCode As String
            Get
                CardNumberCVCCode = AdvantageFramework.Security.Encryption.ASCIIDecoding(_VCCCard.CardNumber) & " / " & AdvantageFramework.Security.Encryption.ASCIIDecoding(_VCCCard.CVCCode)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Number" & vbCrLf & "of Uses")>
        Public ReadOnly Property NumberOfUses() As Integer
            Get
                NumberOfUses = _VCCCard.NumberOfUses
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Expiration" & vbCrLf & "Date")>
        Public ReadOnly Property ExpirationDate() As Date
            Get
                ExpirationDate = _VCCCard.ExpirationDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Reviewed() As Boolean
            Get
                Reviewed = _VCCCard.Reviewed
            End Get
            Set(value As Boolean)
                _VCCCard.Reviewed = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Resolved() As Boolean
            Get
                Resolved = _VCCCard.Resolved
            End Get
            Set(value As Boolean)
                _VCCCard.Resolved = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Follow-up" & vbCrLf & "Date")>
        Public Property FollowupDate() As Nullable(Of Date)
            Get
                FollowupDate = _VCCCard.FollowupDate
            End Get
            Set(value As Nullable(Of Date))
                _VCCCard.FollowupDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Last" & vbCrLf & "Comment")>
        Public ReadOnly Property LastComment() As String
            Get
                Dim MaxID As Integer = 0

                If _VCCCard.VCCCardNotes IsNot Nothing AndAlso _VCCCard.VCCCardNotes.Count > 0 Then

                    MaxID = (From VN In _VCCCard.VCCCardNotes
                             Select VN.ID).Max

                End If

                If MaxID <> 0 Then

                    LastComment = (From Entity In _VCCCard.VCCCardNotes
                                   Where Entity.ID = MaxID
                                   Select Entity.Note).FirstOrDefault

                Else

                    LastComment = Nothing

                End If

            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Last" & vbCrLf & "Comment Date", DisplayFormat:="G")>
        Public ReadOnly Property LastCommentDate() As Nullable(Of Date)
            Get
                Dim MaxID As Integer = 0
                Dim CommentDate As Date = Nothing

                If _VCCCard.VCCCardNotes IsNot Nothing AndAlso _VCCCard.VCCCardNotes.Count > 0 Then

                    MaxID = (From VN In _VCCCard.VCCCardNotes
                             Select VN.ID).Max

                End If

                If MaxID <> 0 Then

                    CommentDate = (From Entity In _VCCCard.VCCCardNotes
                                   Where Entity.ID = MaxID
                                   Select Entity.CreatedDate).FirstOrDefault

                    LastCommentDate = AdvantageFramework.VCC.DisplayLocalDate(_TimezoneOffset, CommentDate)

                Else

                    LastCommentDate = Nothing

                End If

            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Last" & vbCrLf & "Refreshed", DisplayFormat:="G")>
        Public ReadOnly Property LastRefreshedDate() As Nullable(Of Date)
            Get
                LastRefreshedDate = AdvantageFramework.VCC.DisplayLocalDate(_TimezoneOffset, _VCCCard.LastRefreshedDate)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Last" & vbCrLf & "Four")>
        Public ReadOnly Property LastFour() As String
            Get
                LastFour = Right(AdvantageFramework.Security.Encryption.ASCIIDecoding(_VCCCard.CardNumber), 4)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, CustomColumnCaption:="Modified By")>
        Public ReadOnly Property ModifiedByUserCode() As String
            Get
                ModifiedByUserCode = _VCCCard.ModifiedByUserCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ModifiedDate() As Nullable(Of Date)
            Get
                ModifiedDate = _VCCCard.ModifiedDate
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property NetCost As Decimal
            Get
                NetCost = If(Me.VendorCollected = 0, Me.TotalCostPayableToVendor.GetValueOrDefault(0), Me.VendorCollected)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property LastTransactionAction As Short
            Get
                Dim IVCCCardDetail As AdvantageFramework.Database.Interfaces.IVCCCardDetail = Nothing
                Dim LastAction As Short = 0

                If Not Me.NoTransactions AndAlso _VCCCard IsNot Nothing AndAlso _VCCCard.VCCCardDetails IsNot Nothing AndAlso _VCCCard.VCCCardDetails.Count > 0 Then

                    IVCCCardDetail = (From Entity In _VCCCard.VCCCardDetails
                                      Select Entity).OrderByDescending(Function(V) V.ProcessDateTime).FirstOrDefault

                    If IVCCCardDetail IsNot Nothing Then

                        LastAction = IVCCCardDetail.Action

                    End If

                End If

                LastTransactionAction = LastAction
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property VCCIssuedAndUpdated As Boolean
            Get
                If Not Me.NoTransactions AndAlso
                        (Me.LastTransactionAction = AdvantageFramework.Database.Entities.VCCAction.CreditCardRequest OrElse
                        Me.LastTransactionAction = AdvantageFramework.Database.Entities.VCCAction.CreditCardUpdate) Then

                    VCCIssuedAndUpdated = True

                Else

                    VCCIssuedAndUpdated = False

                End If
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property TransactionDeclined As Boolean
            Get
                If Not Me.NoTransactions AndAlso Me.LastTransactionAction = AdvantageFramework.Database.Entities.VCCAction.RejectedTransaction Then

                    TransactionDeclined = True

                Else

                    TransactionDeclined = False

                End If
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property TransactionsOutOfBalance As Boolean
            Get
                TransactionsOutOfBalance = Me.VCCIssuedAndUpdated = False AndAlso Me.TransactionDeclined = False AndAlso Me.TransactionsInBalance = False AndAlso Me.NoTransactions = False
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property NoTransactions As Boolean
            Get
                If _VCCCard IsNot Nothing AndAlso (_VCCCard.VCCCardDetails Is Nothing OrElse (_VCCCard.VCCCardDetails IsNot Nothing AndAlso _VCCCard.VCCCardDetails.Where(Function(D) D.Action = AdvantageFramework.Database.Entities.VCCAction.ClearedTransaction OrElse
                                                                                                                                                                                      D.Action = AdvantageFramework.Database.Entities.VCCAction.PendingTransaction OrElse
                                                                                                                                                                                      D.Action = AdvantageFramework.Database.Entities.VCCAction.RejectedTransaction).Any = False)) Then
                    NoTransactions = True
                Else
                    NoTransactions = False
                End If
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property TransactionsInBalance As Boolean
            Get
                Dim IsInBalance As Boolean = False

                If Not Me.NoTransactions AndAlso Me.LastTransactionAction = AdvantageFramework.Database.Entities.VCCAction.ClearedTransaction OrElse
                        Me.LastTransactionAction = AdvantageFramework.Database.Entities.VCCAction.PendingTransaction Then

                    If _VCCCard IsNot Nothing AndAlso _VCCCard.VCCCardDetails IsNot Nothing Then

                        If _VCCCard.VCCCardDetails.Where(Function(VCD) VCD.Action = AdvantageFramework.Database.Entities.VCCAction.PendingTransaction).Sum(Function(VCD) VCD.Amount) = Me.NetCost OrElse
                                _VCCCard.VCCCardDetails.Where(Function(VCD) VCD.Action = AdvantageFramework.Database.Entities.VCCAction.ClearedTransaction).Sum(Function(VCD) VCD.Amount) = Me.NetCost Then

                            IsInBalance = True

                        End If

                    End If

                End If

                TransactionsInBalance = IsInBalance
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VCCUpdateMessage() As String
            Get
                VCCUpdateMessage = _VCCUpdateMessage
            End Get
            Set(value As String)
                _VCCUpdateMessage = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property OriginalStatus() As String
            Get
                OriginalStatus = _OriginalStatus
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property OriginalCardAmount() As Decimal
            Get
                OriginalCardAmount = _OriginalCardAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property DateToBill() As Nullable(Of Date)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property StartDate() As Nullable(Of Date)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property ClientName() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property CreditCardNumberExpDateCVC() As String
            Get
                Dim CardNumber As String = Nothing
                CardNumber = AdvantageFramework.Security.Encryption.ASCIIDecoding(_VCCCard.CardNumber)
                CreditCardNumberExpDateCVC = "MC:" & CardNumber.Substring(0, 4) & "-" & CardNumber.Substring(4, 4) & "-" & CardNumber.Substring(8, 4) & "-" & CardNumber.Substring(12, 4) & " Exp: " & _VCCCard.ExpirationDate.ToString("MMyy") & " CVC: " & AdvantageFramework.Security.Encryption.ASCIIDecoding(_VCCCard.CVCCode)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Job or Media" & vbCrLf & "Date to Bill")>
        Public Property JobOrMediaDateToBill() As Nullable(Of Date)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property Cancelled() As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DeclinedDate As Nullable(Of Date)
            Get
                If Not Me.NoTransactions AndAlso Me.LastTransactionAction = AdvantageFramework.Database.Entities.VCCAction.RejectedTransaction Then

                    DeclinedDate = (From Entity In _VCCCard.VCCCardDetails
                                    Where Entity.Action = AdvantageFramework.Database.Entities.VCCAction.RejectedTransaction
                                    Select Entity).OrderByDescending(Function(Entity) Entity.ProcessDateTime).FirstOrDefault.ProcessDateTime

                Else

                    DeclinedDate = Nothing

                End If
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property RevisionNumber As Nullable(Of Integer)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Quote As Boolean
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VendorCollectedCopy() As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VCCCardID() As Nullable(Of Integer)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TotalCostPayableToVendor() As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property TransactionIDField() As String
            Get
                Dim ID As String = Nothing

                If _VCCCard.CardType = Database.Interfaces.IVCCCard.EnumCardType.MediaOrder Then

                    ID = "1" & AdvantageFramework.StringUtilities.PadWithCharacter(Me.OrderNumber.Value, 14, "0", True, True) & AdvantageFramework.StringUtilities.PadWithCharacter(Me.LineNumber.Value, 4, "0", True, True)

                ElseIf _VCCCard.CardType = Database.Interfaces.IVCCCard.EnumCardType.PurchaseOrder Then

                    ID = "2" & AdvantageFramework.StringUtilities.PadWithCharacter(Me.PONumber.Value, 18, "0", True, True)

                End If

                TransactionIDField = ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EFSMessage As String

#End Region

#Region " Methods "

        Public Sub New(MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail, VCCCard As AdvantageFramework.Database.Interfaces.IVCCCard,
                       TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset)

            Me.JobNumber = MediaManagerReviewDetail.JobNumber
            Me.JobComponentNumber = MediaManagerReviewDetail.JobComponentNumber
            Me.JobMediaBillDate = MediaManagerReviewDetail.JobMediaBillDate
            Me.OrderNumber = MediaManagerReviewDetail.OrderNumber
            Me.LineNumber = MediaManagerReviewDetail.LineNumber
            Me.OrderDescription = MediaManagerReviewDetail.OrderDescription
            Me.VendorCode = MediaManagerReviewDetail.VendorCode
            Me.VendorName = MediaManagerReviewDetail.VendorName
            Me.VendorCost = MediaManagerReviewDetail.TotalCostPayableToVendor.GetValueOrDefault(0)
            Me.DateToBill = MediaManagerReviewDetail.DateToBill
            Me.StartDate = MediaManagerReviewDetail.StartDate
            Me.ClientName = MediaManagerReviewDetail.ClientName
            Me.JobOrMediaDateToBill = MediaManagerReviewDetail.JobOrMediaDateToBill
            Me.Cancelled = MediaManagerReviewDetail.Cancelled

            _VCCCard = VCCCard
            _TimezoneOffset = TimezoneOffset

            _OriginalStatus = _VCCCard.Status
            _OriginalCardAmount = _VCCCard.CardAmount

            _VendorCollected = MediaManagerReviewDetail.VendorCollected.GetValueOrDefault(0)

            Me.RevisionNumber = MediaManagerReviewDetail.RevisionNumber
            Me.Quote = MediaManagerReviewDetail.Quote
            Me.VendorCollectedCopy = MediaManagerReviewDetail.VendorCollectedCopy
            Me.VCCCardID = MediaManagerReviewDetail.VCCCardID
            Me.TotalCostPayableToVendor = MediaManagerReviewDetail.TotalCostPayableToVendor

        End Sub
        Public Sub New(MediaManagerPODetail As AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail, VCCCard As AdvantageFramework.Database.Interfaces.IVCCCard,
                       TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset)

            Me.PONumber = MediaManagerPODetail.PONumber
            Me.OrderDescription = MediaManagerPODetail.PODescription
            Me.VendorCode = MediaManagerPODetail.VendorCode
            Me.VendorName = MediaManagerPODetail.VendorName

            Me.StartDate = MediaManagerPODetail.PODate
            Me.VendorCost = MediaManagerPODetail.POAmount
            Me.TotalCostPayableToVendor = MediaManagerPODetail.POAmount

            _VCCCard = VCCCard
            _TimezoneOffset = TimezoneOffset

            _OriginalStatus = _VCCCard.Status
            _OriginalCardAmount = _VCCCard.CardAmount

        End Sub
        Public Function GetVCCCardEntity() As AdvantageFramework.Database.Interfaces.IVCCCard

            GetVCCCardEntity = _VCCCard

        End Function
        Public Sub RefreshNotes(DbContext As AdvantageFramework.Database.DbContext)

            _VCCCard.RefreshNotes(DbContext)

        End Sub
        Public Function Clone() As AdvantageFramework.MediaManager.Classes.VCCOrder

            Dim ClassClone As AdvantageFramework.MediaManager.Classes.VCCOrder = Nothing

            ClassClone = DirectCast(Me.MemberwiseClone, AdvantageFramework.MediaManager.Classes.VCCOrder)

            Clone = ClassClone

        End Function

#End Region

    End Class

End Namespace