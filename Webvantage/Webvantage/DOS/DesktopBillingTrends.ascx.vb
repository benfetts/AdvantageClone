Imports System.Data.SqlClient
Imports cCharting
Imports Telerik.Web.UI

Public Class DesktopBillingTrends
    Inherits Webvantage.BaseDesktopObject

    Public strRecType As String = ""
    Public strClient As String = ""
    Public strSales As String = ""
    Public strOffice As String = ""
    Public strDivision As String = ""
    Public strProduct As String = ""
    Public year1 As String = ""
    Public year2 As String = ""

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Page.IsPostBack = False Then
            LoadClientDropdownlist()
            LoadSalesClassDropdownlist()
            LoadOfficeDropdownlist()
            LoadDivisionDropdownlist()
            LoadProductDropdownlist()
            LoadYears()
        End If
        strRecType = Me.ddType.SelectedValue
        strClient = Me.ClientDropDownList.SelectedValue
        strSales = Me.SalesClassDropDownList.SelectedValue
        strOffice = Me.ddOffice.SelectedValue
        strDivision = Me.DivisionDropDownList.SelectedValue
        strProduct = Me.ProductDropDownList.SelectedValue
        year1 = Me.RadComboBoxYearFrom.SelectedValue
        year2 = Me.RadComboBoxYearTo.SelectedValue
        Me.butPrint.Attributes.Add("onclick", "window.open('dtp_billing_trends.aspx?rectype=" & strRecType & "&client=" & strClient & "&sales=" & strSales & "&office=" & strOffice & "&division=" & strDivision & "&product=" & strProduct & "&year1=" & year1 & "&year2=" & year2 & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=615,height=500,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;")
        LoadData()
    End Sub

    Private Sub LoadClientDropdownlist()
        Me.ClientDropDownList.Items.Clear()
        Dim cli As String
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        Me.ClientDropDownList.DataSource = oDD.GetClientList(Session("UserCode"))
        Me.ClientDropDownList.DataTextField = "Description"
        Me.ClientDropDownList.DataValueField = "Code"
        Me.ClientDropDownList.DataBind()
        Me.ClientDropDownList.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Clients", "%"))

    End Sub

    Private Sub LoadSalesClassDropdownlist()
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        Me.SalesClassDropDownList.DataTextField = "description"
        Me.SalesClassDropDownList.DataValueField = "code"
        Me.SalesClassDropDownList.DataSource = oDD.GetSalesClass
        Me.SalesClassDropDownList.DataBind()
        Me.SalesClassDropDownList.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Sales Classes", "%"))
    End Sub

    Private Sub LoadDivisionDropdownlist()
        Try
            Dim cli As String

            Me.DivisionDropDownList.Items.Clear()

            cli = Me.ClientDropDownList.SelectedValue
            Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

            With Me.DivisionDropDownList
                .DataSource = oDD.GetDivisionList(Session("UserCode"), cli)
                .DataValueField = "Code"
                .DataTextField = "Description"
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Divisions", "%"))
                .SelectedIndex = 0
            End With

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String

            taskVar = otask.getAppVars(Session("UserCode"), "ClientAging", "CADivision")
            If taskVar <> "" Then
                Me.DivisionDropDownList.SelectedValue = taskVar
            Else
                Me.DivisionDropDownList.SelectedValue = ""
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadProductDropdownlist()
        Try
            Dim cli, div As String

            Me.ProductDropDownList.Items.Clear()

            cli = Me.ClientDropDownList.SelectedValue
            div = Me.DivisionDropDownList.SelectedValue
            Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

            With Me.ProductDropDownList
                .DataSource = oDD.GetProductList(Session("UserCode"), cli, div)
                .DataValueField = "Code"
                .DataTextField = "Description"
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Products", "%"))
                .SelectedIndex = 0
            End With

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String

            taskVar = otask.getAppVars(Session("UserCode"), "ClientAging", "CAProduct")
            If taskVar <> "" Then
                Me.ProductDropDownList.SelectedValue = taskVar
            Else
                Me.ProductDropDownList.SelectedValue = ""
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadOfficeDropdownlist()
        Me.ddOffice.Items.Clear()
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        With Me.ddOffice
            .DataSource = oDD.GetOfficesEmp(Session("UserCode"))
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Offices", "%"))
        End With

    End Sub

    Private Sub LoadYears()
        Me.RadComboBoxYearFrom.Items.Clear()

        Dim PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(Session("COnnString"), Session("UserCode"))

            With Me.RadComboBoxYearFrom
                .DataSource = (From PostPeriod In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllYearEndPostPeriods(DbContext).OrderByDescending(Function(PP) PP.Year)
                               Select New With {.[Year] = PostPeriod.Year}).ToList.OrderByDescending(Function(PP) PP.Year).ToList
                .DataValueField = "Year"
                .DataTextField = "Year"
                .DataBind()
                '.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Offices", "%"))
            End With

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String

            taskVar = otask.getAppVars(Session("UserCode"), "BillingTrends", "BTYearFrom")
            If taskVar <> "" Then
                Me.RadComboBoxYearFrom.SelectedValue = taskVar
            End If

            With Me.RadComboBoxYearTo
                .DataSource = (From PostPeriod In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllYearEndPostPeriods(DbContext)
                               Select New With {.[Year] = PostPeriod.Year}).ToList.OrderByDescending(Function(PP) PP.Year).ToList
                .DataValueField = "Year"
                .DataTextField = "Year"
                .DataBind()
                '.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Offices", "%"))
            End With

            taskVar = otask.getAppVars(Session("UserCode"), "BillingTrends", "BTYearTo")
            If taskVar <> "" Then
                Me.RadComboBoxYearTo.SelectedValue = taskVar
            End If

        End Using


    End Sub

    Private Sub LoadData()
        Session("dsBillingTrends") = ""
        Session("dsBillingTrends") = Nothing
        Dim dr As SqlDataReader
        Dim oDesktop As cDesktopObjects = New cDesktopObjects(Session("ConnString"))
        Dim strClient1 As String

        dr = oDesktop.GetBillingTrends(strClient, strRecType, strSales, Session("UserCode"), strOffice, strDivision, strProduct, Me.RadComboBoxYearFrom.SelectedValue, Me.RadComboBoxYearTo.SelectedValue)

        Dim ds As DataSet = New DataSet
        Dim ThisTable As DataTable = New DataTable("BillingTrends")

        ThisTable.Columns.Add("Year", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Jan", System.Type.GetType("System.Decimal"))
        ThisTable.Columns.Add("Feb", System.Type.GetType("System.Decimal"))
        ThisTable.Columns.Add("Mar", System.Type.GetType("System.Decimal"))
        ThisTable.Columns.Add("Apr", System.Type.GetType("System.Decimal"))
        ThisTable.Columns.Add("May", System.Type.GetType("System.Decimal"))
        ThisTable.Columns.Add("Jun", System.Type.GetType("System.Decimal"))
        ThisTable.Columns.Add("Jul", System.Type.GetType("System.Decimal"))
        ThisTable.Columns.Add("Aug", System.Type.GetType("System.Decimal"))
        ThisTable.Columns.Add("Sep", System.Type.GetType("System.Decimal"))
        ThisTable.Columns.Add("Oct", System.Type.GetType("System.Decimal"))
        ThisTable.Columns.Add("Nov", System.Type.GetType("System.Decimal"))
        ThisTable.Columns.Add("Dec", System.Type.GetType("System.Decimal"))

        Dim ThisRow As DataRow
        Dim FirstYear As String = ""
        Dim ThisYear As String = ""
        Dim ThisMonth As Integer = 0
        Dim ThisValue As Decimal
        Dim RowIndex As Integer = -1
        Do While dr.Read
            ThisYear = dr.GetString(2).ToString
            If ThisYear <> FirstYear Then
                If FirstYear <> "" Then
                    ThisTable.Rows.Add(ThisRow)
                End If
                FirstYear = ThisYear
                ThisRow = ThisTable.NewRow
                ThisRow("Year") = ThisYear.ToString
                ThisRow("Jan") = 0.0
                ThisRow("Feb") = 0.0
                ThisRow("Mar") = 0.0
                ThisRow("Apr") = 0.0
                ThisRow("May") = 0.0
                ThisRow("Jun") = 0.0
                ThisRow("Jul") = 0.0
                ThisRow("Aug") = 0.0
                ThisRow("Sep") = 0.0
                ThisRow("Oct") = 0.0
                ThisRow("Nov") = 0.0
                ThisRow("Dec") = 0.0
            End If
            ThisMonth = dr.GetSqlInt16(1).Value
            ThisValue = CDec(dr.GetSqlDecimal(0).Value)
            Select Case ThisMonth
                Case 1
                    ThisRow("Jan") += ThisValue
                Case 2
                    ThisRow("Feb") += ThisValue
                Case 3
                    ThisRow("Mar") += ThisValue
                Case 4
                    ThisRow("Apr") += ThisValue
                Case 5
                    ThisRow("May") += ThisValue
                Case 6
                    ThisRow("Jun") += ThisValue
                Case 7
                    ThisRow("Jul") += ThisValue
                Case 8
                    ThisRow("Aug") += ThisValue
                Case 9
                    ThisRow("Sep") += ThisValue
                Case 10
                    ThisRow("Oct") += ThisValue
                Case 11
                    ThisRow("Nov") += ThisValue
                Case 12
                    ThisRow("Dec") += ThisValue
            End Select
        Loop

        If Not ThisRow Is Nothing Then
            ThisTable.Rows.Add(ThisRow)
            ThisTable.AcceptChanges()
        End If

        If ThisTable.Rows.Count > 0 Then
            ds.Tables.Add(ThisTable)
            Session("dsBillingTrends") = ds
        Else
            Session("dsBillingTrends") = Nothing
        End If
        dr.Close()

        CreateChart()

    End Sub

    Private Sub butRefresh_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butRefresh.Click
        LoadData()
    End Sub

    Private Sub CreateChart()

        cCharting.GetLineChart_BillingTrends(RadHtmlChartBillingTrends, Session("dsBillingTrends"))

    End Sub

    Public Function WriteURL() As String
        Dim str As String = cCharting.getFCXMLData_MultiLine_BillingTrends(Session("dsBillingTrends")) '"Flash/DataStream.aspx?ChartType=MultiLine_BillingTrends" '%26"
        Return str
    End Function
    Private Sub ImageButtonFilter_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonFilter.Click

        Me.CollapsablePanelFilter.Collapsed = Not Me.CollapsablePanelFilter.Collapsed
        Me.CollapsablePanelFilter.Visible = Not Me.CollapsablePanelFilter.Visible

    End Sub

    Private Sub ClientDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClientDropDownList.SelectedIndexChanged
        LoadData()
        LoadDivisionDropdownlist()
        LoadProductDropdownlist()
    End Sub

    Private Sub ddType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddType.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub SalesClassDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SalesClassDropDownList.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub DivisionDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DivisionDropDownList.SelectedIndexChanged
        LoadData()
        LoadProductDropdownlist()
    End Sub

    Private Sub ProductDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProductDropDownList.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub ddOffice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddOffice.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub RadComboBoxYearTo_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxYearTo.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))

        otask.setAppVars(Session("UserCode"), "BillingTrends", "BTYearTo", "", Me.RadComboBoxYearTo.SelectedValue)
        LoadData()
    End Sub

    Private Sub RadComboBoxYearFrom_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxYearFrom.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))

        otask.setAppVars(Session("UserCode"), "BillingTrends", "BTYearFrom", "", Me.RadComboBoxYearFrom.SelectedValue)
        LoadData()
    End Sub
End Class

Public Class BTYear
    Private mJan As Double = 0.0
    Private mFeb As Double = 0.0
    Private mMar As Double = 0.0
    Private mApr As Double = 0.0
    Private mMay As Double = 0.0
    Private mJun As Double = 0.0
    Private mJul As Double = 0.0
    Private mAug As Double = 0.0
    Private mSep As Double = 0.0
    Private mOct As Double = 0.0
    Private mNov As Double = 0.0
    Private mDec As Double = 0.0
    Public Property Jan() As Double
        Get
            Return mJan
        End Get
        Set(ByVal Value As Double)
            mJan = Value
        End Set
    End Property
    Public Property Feb() As Double
        Get
            Return mFeb
        End Get
        Set(ByVal Value As Double)
            mFeb = Value
        End Set
    End Property
    Public Property Mar() As Double
        Get
            Return mMar
        End Get
        Set(ByVal Value As Double)
            mMar = Value
        End Set
    End Property
    Public Property Apr() As Double
        Get
            Return mApr
        End Get
        Set(ByVal Value As Double)
            mApr = Value
        End Set
    End Property
    Public Property May() As Double
        Get
            Return mMay
        End Get
        Set(ByVal Value As Double)
            mMay = Value
        End Set
    End Property
    Public Property Jun() As Double
        Get
            Return mJun
        End Get
        Set(ByVal Value As Double)
            mJun = Value
        End Set
    End Property
    Public Property Jul() As Double
        Get
            Return mJul
        End Get
        Set(ByVal Value As Double)
            mJul = Value
        End Set
    End Property
    Public Property Aug() As Double
        Get
            Return mAug
        End Get
        Set(ByVal Value As Double)
            mAug = Value
        End Set
    End Property
    Public Property Sep() As Double
        Get
            Return mSep
        End Get
        Set(ByVal Value As Double)
            mSep = Value
        End Set
    End Property
    Public Property Oct() As Double
        Get
            Return mOct
        End Get
        Set(ByVal Value As Double)
            mOct = Value
        End Set
    End Property
    Public Property Nov() As Double
        Get
            Return mNov
        End Get
        Set(ByVal Value As Double)
            mNov = Value
        End Set
    End Property
    Public Property Dec() As Double
        Get
            Return mDec
        End Get
        Set(ByVal Value As Double)
            mDec = Value
        End Set
    End Property
End Class

Public Class BillingTrends
    Inherits CollectionBase
    Default Public Property Item(ByVal index As Integer) As BTYear
        Get
            Return CType(List(index), BTYear)
        End Get
        Set(ByVal Value As BTYear)
            List(index) = Value
        End Set
    End Property
    Public Function Add(ByVal value As BTYear) As Integer
        Return List.Add(value)
    End Function
    Public Function IndexOf(ByVal value As BTYear) As Integer
        Return List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As BTYear)
        List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As BTYear)
        List.Remove(value)
    End Sub
    Public Function Contains(ByVal value As BTYear) As Boolean
        Return List.Contains(value)
    End Function
End Class



