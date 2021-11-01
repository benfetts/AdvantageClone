Public Class Expense_SelectItems
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _InvoiceNumber As Integer = 0
    Private _DocumentID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub Save_Click()

        'objects
        Dim ExpenseReportDetails As Generic.List(Of ExpenseReportDetail) = Nothing
        Dim ExpenseReportDetail As ExpenseReportDetail = Nothing
        Dim ExpenseDetailDocument As AdvantageFramework.Database.Entities.ExpenseDetailDocument = Nothing
        Dim DetailDocumentExists As Boolean = False

        If RadGrid_ExpenseItems.Items.Count > 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    ExpenseReportDetails = Session("Expense_SelectItems_ERDs")

                Catch ex As Exception
                    ExpenseReportDetails = Nothing
                End Try

                If ExpenseReportDetails IsNot Nothing Then

                    For Each ExpenseReportDetail In ExpenseReportDetails

                        ExpenseDetailDocument = AdvantageFramework.Database.Procedures.ExpenseDetailDocument.LoadByDocumentIDAndExpenseDetailID(DbContext, _DocumentID, ExpenseReportDetail.ID)

                        DetailDocumentExists = If(ExpenseDetailDocument IsNot Nothing, True, False)

                        If ExpenseReportDetail.Selected Then

                            If DetailDocumentExists = False Then

                                ExpenseDetailDocument = New AdvantageFramework.Database.Entities.ExpenseDetailDocument

                                ExpenseDetailDocument.DocumentID = _DocumentID
                                ExpenseDetailDocument.ExpenseDetailID = ExpenseReportDetail.ID

                                AdvantageFramework.Database.Procedures.ExpenseDetailDocument.Insert(DbContext, ExpenseDetailDocument)

                            End If

                        Else

                            If DetailDocumentExists Then

                                AdvantageFramework.Database.Procedures.ExpenseDetailDocument.Delete(DbContext, ExpenseDetailDocument)

                            End If

                        End If

                    Next

                End If

            End Using

        End If

        Me.CloseThisWindow()

        Me.RefreshCaller("Expense_Edit_V2.aspx", True)

    End Sub
    Public Shared Sub ResetSessionVariables()

        HttpContext.Current.Session("Expense_SelectItems_ERDs") = Nothing

    End Sub

#Region "  Form Event Handlers "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim ExpenseReportDetails As Generic.List(Of ExpenseReportDetail) = Nothing
        Dim IsSelected As Boolean = False

        Try

            _InvoiceNumber = Request.QueryString("InvNbr")

        Catch ex As Exception

        End Try

        Try

            _DocumentID = Request.QueryString("DocID")

        Catch ex As Exception

        End Try

        If Me.IsPostBack = False AndAlso Me.IsCallback = False Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DbContext.Database.Connection.Open()

                ExpenseReportDetails = New Generic.List(Of ExpenseReportDetail)

                For Each ERD In AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, _InvoiceNumber, False).ToList

                    IsSelected = False

                    Try

                        If AdvantageFramework.Database.Procedures.ExpenseDetailDocument.LoadByDocumentIDAndExpenseDetailID(DbContext, _DocumentID, ERD.ID) IsNot Nothing Then

                            IsSelected = True

                        End If

                    Catch ex As Exception
                        IsSelected = False
                    End Try

                    ExpenseReportDetails.Add(New ExpenseReportDetail(ERD, IsSelected))

                Next

                Session("Expense_SelectItems_ERDs") = ExpenseReportDetails

                DbContext.Database.Connection.Close()

            End Using

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarExpense_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarExpense.ButtonClick

        'objects
        Dim CommandName As String = Nothing

        Try

            CommandName = DirectCast(e.Item, Telerik.Web.UI.RadToolBarButton).CommandName

        Catch ex As Exception
            CommandName = ""
        End Try

        Select Case CommandName

            Case "Save"

                Save_Click()

        End Select

    End Sub
    Private Sub RadGrid_ExpenseItems_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid_ExpenseItems.ItemDataBound

        'objects
        'Dim ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
        'Dim IsSelected As Boolean = False
        'Dim CheckBox As System.Web.UI.WebControls.CheckBox = Nothing

        'If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

        '    Try

        '        ExpenseReportDetail = DirectCast(e.Item.DataItem, AdvantageFramework.Database.Entities.ExpenseReportDetail)

        '    Catch ex As Exception
        '        ExpenseReportDetail = Nothing
        '    End Try

        '    If ExpenseReportDetail IsNot Nothing Then

        '        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '            Try

        '                If AdvantageFramework.Database.Procedures.ExpenseDetailDocument.LoadByDocumentIDAndExpenseDetailID(DbContext, _DocumentID, ExpenseReportDetail.ID) IsNot Nothing Then

        '                    IsSelected = True

        '                End If

        '            Catch ex As Exception
        '                IsSelected = False
        '            End Try

        '        End Using

        '        Try

        '            DirectCast(DirectCast(e.Item, Telerik.Web.UI.GridDataItem)("SelectColumn").Controls(0), System.Web.UI.WebControls.CheckBox).Checked = IsSelected
        '            e.Item.Selected = IsSelected

        '        Catch ex As Exception

        '        End Try

        '    End If

        'End If

    End Sub
    Protected Sub CheckBoxSelected_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim IsSelected As Boolean = True
        Dim ExpenseReportDetails As Generic.List(Of ExpenseReportDetail) = Nothing
        Dim ExpenseReportDetail As ExpenseReportDetail = Nothing

        Try

            Try

                ExpenseReportDetails = Session("Expense_SelectItems_ERDs")

            Catch ex As Exception
                ExpenseReportDetails = Nothing
            End Try

            If ExpenseReportDetails IsNot Nothing Then

                GridDataItem = CType(CType(sender, CheckBox).Parent.Parent, Telerik.Web.UI.GridDataItem)

                IsSelected = CType(GridDataItem.FindControl("CheckBoxSelected"), CheckBox).Checked

                Try

                    ExpenseReportDetail = ExpenseReportDetails.Where(Function(ERD) ERD.ID = GridDataItem.GetDataKeyValue("ID")).SingleOrDefault

                Catch ex As Exception
                    ExpenseReportDetail = Nothing
                End Try

                If ExpenseReportDetail IsNot Nothing Then

                    ExpenseReportDetail.Selected = IsSelected

                End If

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadGrid_ExpenseItems_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid_ExpenseItems.NeedDataSource

        'objects
        Dim ExpenseReportDetails As Generic.List(Of ExpenseReportDetail) = Nothing

        Try

            ExpenseReportDetails = Session("Expense_SelectItems_ERDs")

        Catch ex As Exception
            ExpenseReportDetails = New Generic.List(Of ExpenseReportDetail)
        End Try

        RadGrid_ExpenseItems.DataSource = ExpenseReportDetails

        'Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '    Try

        '        RadGrid_ExpenseItems.DataSource = AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, _InvoiceNumber, False).ToList

        '    Catch ex As Exception

        '    End Try

        'End Using

    End Sub

#End Region

#End Region

End Class
<Serializable()>
Public Class ExpenseReportDetail

#Region " Constants "



#End Region

#Region " Enum "

    Public Enum Properties
        Selected
        ID
        InvoiceNumber
        LineNumber
        ItemDate
        Description
        CreditCardFlag
        ClientCode
        DivisionCode
        ProductCode
        JobNumber
        JobComponentNumber
        FunctionCode
        Quantity
        Rate
        CreditCardAmount
        Amount
        APComment
        CreatedBy
        ModifiedBy
        ModifiedDate
        PaymentType
    End Enum

#End Region

#Region " Variables "

    Private _Selected As Boolean = False
    Private _ID As Integer = Nothing
    Private _InvoiceNumber As Integer = Nothing
    Private _LineNumber As Integer = Nothing
    Private _ItemDate As Nullable(Of Date) = Nothing
    Private _Description As String = Nothing
    Private _CreditCardFlag As Nullable(Of Boolean) = Nothing
    Private _ClientCode As String = Nothing
    Private _DivisionCode As String = Nothing
    Private _ProductCode As String = Nothing
    Private _JobNumber As Nullable(Of Integer) = Nothing
    Private _JobComponentNumber As Nullable(Of Short) = Nothing
    Private _FunctionCode As String = Nothing
    Private _Quantity As Nullable(Of Integer) = Nothing
    Private _Rate As Nullable(Of Decimal) = Nothing
    Private _CreditCardAmount As Nullable(Of Decimal) = Nothing
    Private _Amount As Nullable(Of Decimal) = Nothing
    Private _APComment As String = Nothing
    Private _CreatedBy As String = Nothing
    Private _ModifiedBy As String = Nothing
    Private _ModifiedDate As Nullable(Of Date) = Nothing
    Private _PaymentType As Nullable(Of Short) = Nothing

#End Region

#Region " Properties "

    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property Selected() As Boolean
        Get
            Selected = _Selected
        End Get
        Set(value As Boolean)
            _Selected = value
        End Set
    End Property
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property ID() As Integer
        Get
            ID = _ID
        End Get
        Set(value As Integer)
            _ID = value
        End Set
    End Property
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property InvoiceNumber() As Integer
        Get
            InvoiceNumber = _InvoiceNumber
        End Get
        Set(ByVal value As Integer)
            _InvoiceNumber = value
        End Set
    End Property
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property LineNumber() As Integer
        Get
            LineNumber = _LineNumber
        End Get
        Set(value As Integer)
            _LineNumber = value
        End Set
    End Property
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property ClientCode() As String
        Get
            ClientCode = _ClientCode
        End Get
        Set(ByVal value As String)
            _ClientCode = value
        End Set
    End Property
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property DivisionCode() As String
        Get
            DivisionCode = _DivisionCode
        End Get
        Set(ByVal value As String)
            _DivisionCode = value
        End Set
    End Property
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property ProductCode() As String
        Get
            ProductCode = _ProductCode
        End Get
        Set(ByVal value As String)
            _ProductCode = value
        End Set
    End Property
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property JobNumber() As Nullable(Of Integer)
        Get
            JobNumber = _JobNumber
        End Get
        Set(ByVal value As Nullable(Of Integer))
            _JobNumber = value
        End Set
    End Property
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property JobComponentNumber() As Nullable(Of Short)
        Get
            JobComponentNumber = _JobComponentNumber
        End Get
        Set(ByVal value As Nullable(Of Short))
            _JobComponentNumber = value
        End Set
    End Property
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property FunctionCode() As String
        Get
            FunctionCode = _FunctionCode
        End Get
        Set(ByVal value As String)
            _FunctionCode = value
        End Set
    End Property
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property Quantity() As Nullable(Of Integer)
        Get
            Quantity = _Quantity
        End Get
        Set(ByVal value As Nullable(Of Integer))
            _Quantity = value
        End Set
    End Property
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property Rate() As Nullable(Of Decimal)
        Get
            Rate = _Rate
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _Rate = value
        End Set
    End Property
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property Amount() As Nullable(Of Decimal)
        Get
            Amount = _Amount
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _Amount = value
        End Set
    End Property
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property CreditCardFlag() As Nullable(Of Boolean)
        Get
            CreditCardFlag = _CreditCardFlag
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            _CreditCardFlag = value
        End Set
    End Property
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property Description() As String
        Get
            Description = _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property CreditCardAmount() As Nullable(Of Decimal)
        Get
            CreditCardAmount = _CreditCardAmount
        End Get
        Set(value As Nullable(Of Decimal))
            _CreditCardAmount = value
        End Set
    End Property
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property APComment() As String
        Get
            APComment = _APComment
        End Get
        Set(value As String)
            _APComment = value
        End Set
    End Property
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property CreatedBy() As String
        Get
            CreatedBy = _CreatedBy
        End Get
        Set(value As String)
            _CreatedBy = value
        End Set
    End Property
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property ModifiedBy() As String
        Get
            ModifiedBy = _ModifiedBy
        End Get
        Set(value As String)
            _ModifiedBy = value
        End Set
    End Property
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property ModifiedDate() As Nullable(Of Date)
        Get
            ModifiedDate = _ModifiedDate
        End Get
        Set(value As Nullable(Of Date))
            _ModifiedDate = value
        End Set
    End Property
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property ItemDate() As Nullable(Of Date)
        Get
            ItemDate = _ItemDate
        End Get
        Set(value As Nullable(Of Date))
            _ItemDate = value
        End Set
    End Property
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property PaymentType() As Nullable(Of Short)
        Get
            PaymentType = _PaymentType
        End Get
        Set(value As Nullable(Of Short))
            _PaymentType = value
        End Set
    End Property

#End Region

#Region " Methods "

    Public Sub New(ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail, ByVal Selected As Boolean)

        _Selected = Selected
        _ID = ExpenseReportDetail.ID
        _InvoiceNumber = ExpenseReportDetail.InvoiceNumber
        _LineNumber = ExpenseReportDetail.LineNumber
        _ItemDate = ExpenseReportDetail.ItemDate
        _Description = ExpenseReportDetail.Description
        _CreditCardFlag = ExpenseReportDetail.CreditCardFlag
        _ClientCode = ExpenseReportDetail.ClientCode
        _DivisionCode = ExpenseReportDetail.DivisionCode
        _ProductCode = ExpenseReportDetail.ProductCode
        _JobNumber = ExpenseReportDetail.JobNumber
        _JobComponentNumber = ExpenseReportDetail.JobComponentNumber
        _FunctionCode = ExpenseReportDetail.FunctionCode
        _Quantity = ExpenseReportDetail.Quantity
        _Rate = ExpenseReportDetail.Rate
        _CreditCardAmount = ExpenseReportDetail.CreditCardAmount
        _Amount = ExpenseReportDetail.Amount
        _APComment = ExpenseReportDetail.APComment
        _CreatedBy = ExpenseReportDetail.CreatedBy
        _ModifiedBy = ExpenseReportDetail.ModifiedBy
        _ModifiedDate = ExpenseReportDetail.ModifiedDate
        _PaymentType = ExpenseReportDetail.PaymentType

    End Sub
    Public Overrides Function ToString() As String

        ToString = Me.ID

    End Function

#End Region

End Class
