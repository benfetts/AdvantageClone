Imports System.Data
Imports System.Data.SqlClient
Namespace wPurchaseOrder
    Public Class cPurchaseOrder
        Dim oSQL As Webvantage.SqlHelper

#Region "Public Shared Functions"
        Public Shared Function Calculate_CPM_Total(ByVal Qty As Integer, ByVal Rate As Decimal) As Decimal
            If Qty > 0 Then
                Return ((Qty / 1000) * Rate)
            End If
        End Function

        Public Function CachePOPrintDef(ByVal UserId As String, ByVal bDateToPrint As Int16, ByVal Show_Ship_Instruction As Int16, _
ByVal Show_PO_Instruction As Int16, ByVal Show_Footer_Comment As Int16, ByVal Show_Detail_Description As Int16, _
ByVal Show_Detail_Instruction As Int16, ByVal Show_Vendor_Contact As Int16, ByVal Show_Client_Name As Int16, _
ByVal Show_Product_Name As Int16, ByVal Show_Job_Comp As Int16, ByVal Location_Id As String, ByVal Logo_Path As String, _
ByVal Report_Format As String, ByVal Show_Func_Descrip As Int16, ByVal Show_Job_Descrip As Int16) As Integer

        End Function

#End Region

#Region "Constructors"
        Public Sub New(ByVal ConnectionString As String)
            _ConnectionString = ConnectionString
        End Sub
#End Region

#Region "Properties"
        Public Property PO_Date() As String
            Get
                Return _PO_Date
            End Get
            Set(ByVal value As String)
                _PO_Date = value
            End Set
        End Property
        Public Property PO_Description() As String
            Get
                Return _PO_Description
            End Get
            Set(ByVal value As String)
                PO_Description = value
            End Set
        End Property
        Public Property Vendor_Code() As String
            Get
                Return _Vn_Code
            End Get
            Set(ByVal value As String)
                _Vn_Code = value
            End Set
        End Property
        Public Property Issue_By_Emp_Code() As String
            Get
                Return _Issue_By_Emp_Code
            End Get
            Set(ByVal value As String)
                _Issue_By_Emp_Code = value
            End Set
        End Property
        Public ReadOnly Property Issue_By_Emp_Name() As String
            Get
                Return _Issue_By_Emp_Name
            End Get
        End Property

        Public ReadOnly Property Vendor_Name() As String
            Get
                Return _Vn_VendorName
            End Get
        End Property
        Public Property PO_Due_Date() As String
            Get
                Return _PO_Due_Date
            End Get
            Set(ByVal value As String)
                _PO_Due_Date = value
            End Set
        End Property
        Public ReadOnly Property Vendor_Address1() As String
            Get
                Return _Vn_Address1
            End Get
        End Property
        Public ReadOnly Property Vendor_Address2() As String
            Get
                Return _Vn_Address2
            End Get
        End Property
        Public ReadOnly Property Vendor_Address3() As String
            Get
                Return _Vn_Address3
            End Get
        End Property
        Public ReadOnly Property Vendor_CityStateZip() As String
            Get
                Return _Vn_CityStateZip
            End Get
        End Property
        Public Property Vendor_Contact_Code() As String
            Get
                Return _Vn_Contact_Code
            End Get
            Set(ByVal value As String)
                _Vn_Contact_Code = value
            End Set
        End Property
        Public ReadOnly Property Vendor_Contact_Name() As String
            Get
                Return _Vn_Contact_Name
            End Get
        End Property
        Public ReadOnly Property Vendor_Contact_Email() As String
            Get
                Return _Vn_Contact_Email
            End Get
        End Property
        Public Property PO_Total() As Decimal
            Get
                Return _PO_Total
            End Get
            Set(ByVal value As Decimal)
                PO_Total = value
            End Set
        End Property
        Public ReadOnly Property PO_Main_Instruct() As String
            Get
                Return _PO_Main_Instruct
            End Get
        End Property
        Public ReadOnly Property Delivery_Instructions() As String
            Get
                Return _Del_Instruct
            End Get
        End Property
        Public ReadOnly Property PO_Footer() As String
            Get
                Return _PO_Footer
            End Get
        End Property
        Public ReadOnly Property PO_Voided() As Boolean
            Get
                Return _PO_Voided
            End Get
        End Property
        Public ReadOnly Property PO_Complete() As Boolean
            Get
                Return _PO_Complete
            End Get
        End Property
        Public Property PO_Work_Complete() As Boolean
            Get
                Return _PO_Work_Complete
            End Get
            Set(ByVal value As Boolean)
                _PO_Work_Complete = value
            End Set
        End Property
        Public Property PO_Revision() As Int16
            Get
                Return _PO_Revision
            End Get
            Set(ByVal value As Int16)
                _PO_Revision = value
            End Set
        End Property
        Public ReadOnly Property PO_Pad() As String
            Get
                Return _PO_Pad
            End Get
        End Property
        Public ReadOnly Property Void_Info() As String
            Get
                Return _Void_Info
            End Get
        End Property
        Public ReadOnly Property PO_Approval_Flag() As Integer
            Get
                Return _PO_Approval_Flag
            End Get
        End Property
        Public ReadOnly Property PO_Appr_Rule_Code() As String
            Get
                Return _PO_Appr_Rule_Code
            End Get
            'Set(ByVal value As String)
            '    _PO_Appr_Rule_Code = value
            'End Set
        End Property
        Public Property Exceed() As Integer
            Get
                Return _Exceed
            End Get
            Set(ByVal value As Integer)
                _Exceed = value
            End Set
        End Property
        Public Property PO_Printed() As Integer
            Get
                Return _PO_Printed
            End Get
            Set(ByVal value As Integer)
                _PO_Printed = value
            End Set
        End Property
        Public ReadOnly Property Default_Memo_Text() As String
            Get
                Return _Default_Memo_Text
            End Get
        End Property
        Public ReadOnly Property ModifiedBy() As String
            Get
                Return _ModifiedBy
            End Get
        End Property
        Public ReadOnly Property ModifiedDate() As Nullable(Of Date)
            Get
                Return _ModifiedDate
            End Get
        End Property

#End Region

#Region "Private Class Variables"
        Private _ConnectionString As String
        Private _PO_Number As Integer
        Private _PO_Pad As String
        Private _Issue_By_Emp_Code As String
        Private _Issue_By_Emp_Name As String
        Private _Vn_Code As String
        Private _Vn_VendorName As String
        Private _Vn_Address1 As String
        Private _Vn_Address2 As String
        Private _Vn_Address3 As String
        Private _Vn_CityStateZip As String

        Private _Vn_Contact_Code As String
        Private _Vn_Contact_Name As String
        Private _Vn_Contact_Email As String

        Private _PO_Due_Date As String
        Private _PO_Date As String
        Private _PO_Description As String
        Private _PO_Total As Decimal


        Private _PO_Main_Instruct As String
        Private _PO_Complete As Boolean
        Private _Del_Instruct As String
        Private _Void_Flag As Boolean
        Private _Voided_By As String
        Private _Void_Date As New Date
        Private _Void_Info As String
        Private _PO_Revision As Int16
        Private _PO_Work_Complete As Boolean
        Private _Archive_Flag As Boolean
        Private _VN_Cont_Code As String
        Private _PO_Footer As String
        Private _PO_Approval_Flag As Integer
        Private _PO_Appr_Rule_Code As String
        Private _Exceed As Integer
        Private _PO_Printed As Integer

        Private _PO_Voided As Boolean

        Private _Default_Memo_Text As String
        Private _ModifiedBy As String
        Private _ModifiedDate As Nullable(Of Date)


#End Region

#Region "Database Functions"
        Public Function LoadAll_POList(ByVal filter_id As Integer, ByVal string1 As String, ByVal string2 As String, ByVal string3 As DateTime,
         ByVal string4 As DateTime, ByVal string5 As String, ByVal string6 As String, ByVal string7 As String, ByVal string8 As String,
         ByVal string9 As String, ByVal string10 As String, ByVal string11 As DateTime,
         ByVal string12 As String, ByVal stringsort As String, ByVal CurrentPage As Integer, ByVal MaxRows As Integer,
         ByRef TotalRows As Integer, ByVal string13 As String, ByVal printed As Integer, ByVal string14 As String, ByVal voided As Integer, ByVal closed As Integer, ByVal userid As String) As DataSet
            'filtered list of all purchase orders...
            Dim dr As DataSet
            Dim dr2 As SqlDataReader

            Dim arParams(23) As SqlParameter

            'Dim parmOutput As New SqlParameter("@totalrows", SqlDbType.Int, 4)
            'parmOutput.Direction = ParameterDirection.Output
            'arParams(0) = parmOutput

            Dim parmfilter As New SqlParameter("@filter", SqlDbType.Int, 4)
            parmfilter.Value = filter_id
            arParams(1) = parmfilter

            Dim parmstring1 As New SqlParameter("@str1", SqlDbType.VarChar, 15)
            parmstring1.Value = string1
            arParams(2) = parmstring1

            Dim parmstring2 As New SqlParameter("@str2", SqlDbType.VarChar, 15)
            parmstring2.Value = string2
            arParams(3) = parmstring2

            Dim parmstring3 As New SqlParameter("@str3", SqlDbType.SmallDateTime)
            If string3 = Nothing Then
                parmstring3.Value = DBNull.Value
            Else
                parmstring3.Value = string3
            End If
            arParams(4) = parmstring3

            Dim parmstring4 As New SqlParameter("@str4", SqlDbType.SmallDateTime)
            If string4 = Nothing Then
                parmstring4.Value = DBNull.Value
            Else
                parmstring4.Value = string4
            End If
            arParams(5) = parmstring4

            Dim parmstring5 As New SqlParameter("@str5", SqlDbType.VarChar, 15)
            parmstring5.Value = string5
            arParams(6) = parmstring5

            Dim parmstring6 As New SqlParameter("@str6", SqlDbType.VarChar, 15)
            parmstring6.Value = string6
            arParams(7) = parmstring6

            Dim parmstring7 As New SqlParameter("@str7", SqlDbType.VarChar, 15)
            parmstring7.Value = string7
            arParams(8) = parmstring7

            Dim parmstring8 As New SqlParameter("@str8", SqlDbType.VarChar, 15)
            parmstring8.Value = string8
            arParams(9) = parmstring8

            Dim parmstring9 As New SqlParameter("@str9", SqlDbType.VarChar, 15)
            parmstring9.Value = string9
            arParams(10) = parmstring9

            Dim parmstring10 As New SqlParameter("@str10", SqlDbType.VarChar, 15)
            parmstring10.Value = string10
            arParams(11) = parmstring10

            Dim parmstring11 As New SqlParameter("@str11", SqlDbType.SmallDateTime)
            If string11 = Nothing Then
                parmstring11.Value = DBNull.Value
            Else
                parmstring11.Value = string11
            End If
            arParams(12) = parmstring11

            Dim parmstring12 As New SqlParameter("@str12", SqlDbType.VarChar, 10)
            parmstring12.Value = string12
            arParams(13) = parmstring12

            Dim parmstring13 As New SqlParameter("@sort", SqlDbType.VarChar, 100)
            parmstring13.Value = stringsort
            arParams(14) = parmstring13

            Dim parmstring14 As New SqlParameter("@currentpage", SqlDbType.Int, 4)
            parmstring14.Value = CurrentPage
            arParams(15) = parmstring14

            Dim parmstring15 As New SqlParameter("@maxrows", SqlDbType.Int, 4)
            parmstring15.Value = MaxRows
            arParams(16) = parmstring15

            Dim parmstring16 As New SqlParameter("@str13", SqlDbType.VarChar, 15)
            parmstring16.Value = string13
            arParams(17) = parmstring16

            Dim parmstring17 As New SqlParameter("@printed", SqlDbType.Int)
            parmstring17.Value = printed
            arParams(18) = parmstring17

            Dim parmstring19 As New SqlParameter("@str14", SqlDbType.VarChar, 15)
            parmstring19.Value = string14
            arParams(19) = parmstring19

            Dim parmstring20 As New SqlParameter("@voided", SqlDbType.Int)
            parmstring20.Value = voided
            arParams(20) = parmstring20

            Dim parmstring21 As New SqlParameter("@closed", SqlDbType.Int)
            parmstring21.Value = closed
            arParams(21) = parmstring21

            Dim parmstringUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parmstringUserID.Value = userid
            arParams(22) = parmstringUserID

            Try
                dr = oSQL.ExecuteDataset(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_LoadAll", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:GetLoadAll_POList", Err.Description)
            End Try
            Return dr
        End Function
        Public Function LoadAll_POListDS(ByVal filter_id As Integer, ByVal string1 As String, ByVal string2 As String, ByVal string3 As String, _
         ByVal string4 As String, ByVal string5 As String, ByVal string6 As String, ByVal string7 As String, ByVal string8 As String, _
         ByVal string9 As String, ByVal string10 As String, ByVal string11 As String, _
         ByVal string12 As String, ByVal stringsort As String, ByVal CurrentPage As Integer, ByVal MaxRows As Integer, _
         ByRef TotalRows As Integer) As DataSet
            'filtered list of all purchase orders...
            Dim dr As DataSet
            Dim dr2 As SqlDataReader

            Dim arParams(18) As SqlParameter

            Dim parmOutput As New SqlParameter("@totalrows", SqlDbType.Int, 4)
            parmOutput.Direction = ParameterDirection.Output
            arParams(0) = parmOutput

            Dim parmfilter As New SqlParameter("@filter", SqlDbType.Int, 4)
            parmfilter.Value = filter_id
            arParams(1) = parmfilter

            Dim parmstring1 As New SqlParameter("@str1", SqlDbType.VarChar, 15)
            parmstring1.Value = string1
            arParams(2) = parmstring1

            Dim parmstring2 As New SqlParameter("@str2", SqlDbType.VarChar, 15)
            parmstring2.Value = string2
            arParams(3) = parmstring2

            Dim parmstring3 As New SqlParameter("@str3", SqlDbType.VarChar, 15)
            parmstring3.Value = string3
            arParams(4) = parmstring3

            Dim parmstring4 As New SqlParameter("@str4", SqlDbType.VarChar, 15)
            parmstring4.Value = string4
            arParams(5) = parmstring4

            Dim parmstring5 As New SqlParameter("@str5", SqlDbType.VarChar, 15)
            parmstring5.Value = string5
            arParams(6) = parmstring5

            Dim parmstring6 As New SqlParameter("@str6", SqlDbType.VarChar, 15)
            parmstring6.Value = string6
            arParams(7) = parmstring6

            Dim parmstring7 As New SqlParameter("@str7", SqlDbType.VarChar, 15)
            parmstring7.Value = string7
            arParams(8) = parmstring7

            Dim parmstring8 As New SqlParameter("@str8", SqlDbType.VarChar, 15)
            parmstring8.Value = string8
            arParams(9) = parmstring8

            Dim parmstring9 As New SqlParameter("@str9", SqlDbType.VarChar, 15)
            parmstring9.Value = string9
            arParams(10) = parmstring9

            Dim parmstring10 As New SqlParameter("@str10", SqlDbType.VarChar, 15)
            parmstring10.Value = string10
            arParams(11) = parmstring10

            Dim parmstring11 As New SqlParameter("@str11", SqlDbType.VarChar, 15)
            parmstring11.Value = string11
            arParams(12) = parmstring11

            Dim parmstring12 As New SqlParameter("@str12", SqlDbType.VarChar, 10)
            parmstring12.Value = string12
            arParams(13) = parmstring12

            Dim parmstring13 As New SqlParameter("@sort", SqlDbType.VarChar, 100)
            parmstring13.Value = stringsort
            arParams(14) = parmstring13

            Dim parmstring14 As New SqlParameter("@currentpage", SqlDbType.Int, 4)
            parmstring14.Value = CurrentPage
            arParams(15) = parmstring14

            Dim parmstring15 As New SqlParameter("@maxrows", SqlDbType.Int, 4)
            parmstring15.Value = MaxRows
            arParams(16) = parmstring15

            Try
                dr = oSQL.ExecuteDataset(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_LoadAll", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:GetLoadAll_POList", Err.Description)
            End Try
            Return dr
        End Function

        Public Function LoadAll_PO_Estimate_Details(ByVal funct_id As Integer, ByVal po_number As Integer, ByVal str As String) As SqlDataReader
            'approved estimate lines for all Jobs attached to a purchase order...
            Dim dr As SqlDataReader

            Dim arParams(3) As SqlParameter

            Dim P0 As New SqlParameter("@funct", SqlDbType.Int, 4)
            P0.Value = funct_id
            arParams(0) = P0

            Dim P1 As New SqlParameter("@ponumber", SqlDbType.Int, 4)
            P1.Value = po_number
            arParams(1) = P1

            Dim P2 As New SqlParameter("@str", SqlDbType.VarChar, 25)
            P2.Value = str
            arParams(2) = P2

            Try
                dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Estimate_LoadByPO", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:PO_Estimate_LoadByPO", Err.Description)
            End Try

            Return dr

        End Function
        Public Function LoadAll_PO_Funct_Totals(ByVal funct_id As Integer, ByVal po_number As Integer, ByVal ref_id As Integer, ByVal str1 As String, ByVal str2 As String) As SqlDataReader
            Dim dr As SqlDataReader

            Dim arParams(5) As SqlParameter

            Dim P0 As New SqlParameter("@funct", SqlDbType.Int, 4)
            P0.Value = funct_id
            arParams(0) = P0

            Dim P1 As New SqlParameter("@po_number", SqlDbType.Int, 4)
            P1.Value = po_number
            arParams(1) = P1

            Dim P2 As New SqlParameter("@ref_id", SqlDbType.Int, 4)
            P2.Value = ref_id
            arParams(2) = P2

            Dim P3 As New SqlParameter("@str", SqlDbType.VarChar, 15)
            P3.Value = str1
            arParams(3) = P3

            Dim P4 As New SqlParameter("@str2", SqlDbType.VarChar, 15)
            P4.Value = str2
            arParams(4) = P4

            Try
                dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_GetFunctTotals", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:LoadAll_PO_Funct_Totals:" + funct_id.ToString(), Err.Description)
            End Try

            Return dr

        End Function
        Public Function LoadAll_PO_Vendors(ByVal funct_id As Integer, ByVal ref_id As Integer, ByVal str1 As String, ByVal str2 As String, ByVal str_sort As String) As SqlDataReader
            Dim dr As SqlDataReader

            Dim arParams(5) As SqlParameter

            Dim P0 As New SqlParameter("@funct", SqlDbType.Int, 4)
            P0.Value = funct_id
            arParams(0) = P0

            Dim P1 As New SqlParameter("@ref_id", SqlDbType.Int, 4)
            P1.Value = ref_id
            arParams(1) = P1

            Dim P2 As New SqlParameter("@str1", SqlDbType.VarChar, 25)
            P2.Value = str1
            arParams(2) = P2

            Dim P3 As New SqlParameter("@str2", SqlDbType.VarChar, 25)
            P3.Value = str1
            arParams(3) = P3

            Dim P4 As New SqlParameter("@sort", SqlDbType.VarChar, 100)
            P4.Value = str_sort
            arParams(4) = P4

            Try
                dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Vendors_LoadAll", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:LoadAll_PO_Vendors", Err.Description)
            End Try

            Return dr
        End Function
        Public Function LoadAll_PO_Issuers(ByVal funct_id As Integer, ByVal str1 As String, ByVal str2 As String)
            Dim dr As SqlDataReader

            Dim arParams(3) As SqlParameter

            Dim P0 As New SqlParameter("@funct", SqlDbType.Int, 4)
            P0.Value = funct_id
            arParams(0) = P0

            Dim P1 As New SqlParameter("@str1", SqlDbType.VarChar, 15)
            P1.Value = str1
            arParams(1) = P1

            Dim P2 As New SqlParameter("@str2", SqlDbType.VarChar, 15)
            P2.Value = str1
            arParams(2) = P2

            Try
                dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Issuer_LoadAll", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:LoadAll_PO_Issuers", Err.Description)
            End Try

            Return dr

        End Function
        Public Function LoadAll_PO_Emp_Recent_Vendors(ByVal Days_Past As Integer, ByVal Emp_Code As String, ByVal Vendor_Code As String, ByVal str1 As String, ByVal str2 As String) As SqlDataReader
            Dim dr As SqlDataReader

            Dim arParams(8) As SqlParameter

            Dim P0 As New SqlParameter("@funct", SqlDbType.Int, 4)
            P0.Value = 2 'recent vendors used by employee
            arParams(0) = P0

            Dim P1 As New SqlParameter("@backdays", SqlDbType.Int, 4)
            P1.Value = Days_Past
            arParams(1) = P1

            Dim P2 As New SqlParameter("@emp_code", SqlDbType.VarChar, 6)
            P2.Value = Emp_Code
            arParams(2) = P2

            Dim P3 As New SqlParameter("@vn_code", SqlDbType.VarChar, 6)
            P3.Value = Vendor_Code
            arParams(3) = P3

            Dim P4 As New SqlParameter("@str1", SqlDbType.VarChar, 15)
            P4.Value = Vendor_Code
            arParams(4) = P4

            Dim P5 As New SqlParameter("@str2", SqlDbType.VarChar, 15)
            P5.Value = Vendor_Code
            arParams(5) = P5

            Dim P6 As New SqlParameter("@voided", SqlDbType.Int)
            P6.Value = 0
            arParams(6) = P6

            Dim P7 As New SqlParameter("@closed", SqlDbType.Int)
            P7.Value = 0
            arParams(7) = P7

            Try
                dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_LoadByEmp", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:LoadAll_PO_Emp_Recent_Vendors:" + Emp_Code, Err.Description)
            End Try

            Return dr

        End Function
        Public Function LoadAll_PO_ByEmp(ByVal Funct_Id As Integer, ByVal Days_Past As Integer, ByVal Emp_Code As String, ByVal Vendor_Code As String, ByVal str1 As String, ByVal str2 As String, ByVal voided As Integer, ByVal closed As Integer) As DataSet
            Dim dr As DataSet

            Dim arParams(8) As SqlParameter

            Dim P0 As New SqlParameter("@funct", SqlDbType.Int, 4)
            P0.Value = Funct_Id
            arParams(0) = P0

            Dim P1 As New SqlParameter("@backdays", SqlDbType.Int, 4)
            P1.Value = Days_Past
            arParams(1) = P1

            Dim P2 As New SqlParameter("@emp_code", SqlDbType.VarChar, 6)
            P2.Value = Emp_Code
            arParams(2) = P2

            Dim P3 As New SqlParameter("@vn_code", SqlDbType.VarChar, 6)
            P3.Value = Vendor_Code
            arParams(3) = P3

            Dim P4 As New SqlParameter("@str1", SqlDbType.VarChar, 15)
            P4.Value = Vendor_Code
            arParams(4) = P4

            Dim P5 As New SqlParameter("@str2", SqlDbType.VarChar, 15)
            P5.Value = Vendor_Code
            arParams(5) = P5

            Dim P6 As New SqlParameter("@voided", SqlDbType.Int)
            P6.Value = voided
            arParams(6) = P6

            Dim P7 As New SqlParameter("@closed", SqlDbType.Int)
            P7.Value = closed
            arParams(7) = P7

            Try
                dr = oSQL.ExecuteDataset(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_LoadByEmp", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:LoadAll_PO_Emp_Recent_Vendors:" + Emp_Code, Err.Description)
            End Try

            Return dr
        End Function
        Public Function LoadAll_PO_VendorPrices(ByVal funct_id As Integer, ByVal VN_Code As String, ByVal JobType_Code As String, ByVal str As String, ByVal sort As String) As SqlDataReader
            Dim dr As SqlDataReader

            Dim arParams(5) As SqlParameter

            Dim P0 As New SqlParameter("@funct", SqlDbType.Int, 4)
            P0.Value = funct_id
            arParams(0) = P0

            Dim P1 As New SqlParameter("@vn_code", SqlDbType.Char, 6)
            P1.Value = VN_Code
            arParams(1) = P1

            Dim P2 As New SqlParameter("@jt_code", SqlDbType.VarChar, 15)
            P2.Value = JobType_Code
            arParams(2) = P2

            Dim P3 As New SqlParameter("@str", SqlDbType.VarChar, 15)
            P3.Value = str
            arParams(3) = P3

            Dim P4 As New SqlParameter("@sort", SqlDbType.VarChar, 100)
            P4.Value = sort
            arParams(4) = P4

            Try
                dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Vendor_Pricing_LoadAll", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:proc_WV_PO_Vendor_Pricing_LoadAll", Err.Description)
            End Try

            Return dr
        End Function
        Public Function LoadAll_PO_VendorPrices_SelectedVendor(ByVal funct_id As Integer, ByVal VN_Code As String, ByVal JobType_Code As String, ByVal str As String, ByVal sort As String) As SqlDataReader
            Dim dr As SqlDataReader

            Dim arParams(5) As SqlParameter

            Dim P0 As New SqlParameter("@funct", SqlDbType.Int, 4)
            P0.Value = funct_id
            arParams(0) = P0

            Dim P1 As New SqlParameter("@vn_code", SqlDbType.Char, 6)
            P1.Value = VN_Code
            arParams(1) = P1

            Dim P2 As New SqlParameter("@jt_code", SqlDbType.VarChar, 15)
            P2.Value = JobType_Code
            arParams(2) = P2

            Dim P3 As New SqlParameter("@str", SqlDbType.VarChar, 15)
            P3.Value = str
            arParams(3) = P3

            Dim P4 As New SqlParameter("@sort", SqlDbType.VarChar, 100)
            P4.Value = sort
            arParams(4) = P4

            Try
                dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Vendor_Pricing_SelectedVendor", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:proc_WV_PO_Vendor_Pricing_LoadAll", Err.Description)
            End Try

            Return dr
        End Function
        Public Function LoadAll_PO_Functions(ByVal funct_id As Integer, ByVal ref_code As String, ByVal ref_id As Integer, ByVal sort As String)
            Dim dr As SqlDataReader

            Dim arParams(4) As SqlParameter

            Dim P0 As New SqlParameter("@funct", SqlDbType.Int, 4)
            P0.Value = funct_id
            arParams(0) = P0

            Dim P1 As New SqlParameter("@ref_code", SqlDbType.VarChar, 6)
            P1.Value = ref_code
            arParams(1) = P1

            Dim P2 As New SqlParameter("@ref_id", SqlDbType.Int, 4)
            P2.Value = ref_id
            arParams(2) = P2

            Dim P3 As New SqlParameter("@sort", SqlDbType.VarChar, 50)
            P3.Value = sort
            arParams(3) = P3

            Try
                dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Functions_LoadAll", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:LoadAll_PO_Functions", Err.Description)
            End Try

            Return dr

        End Function
        Public Function Select_PO_Memo(ByVal Column_Name As String, ByVal PO_Number As Integer) As Integer
            Dim dr As SqlDataReader
            'Column name denotes field to update (PO_MAIN_INSTRUCT, DEL_INSTRUCT, PO_FOOTER

            Dim arParams(2) As SqlParameter

            Dim P0 As New SqlParameter("@column", SqlDbType.VarChar, 25)
            P0.Value = Column_Name
            arParams(0) = P0

            Dim P1 As New SqlParameter("@po_number", SqlDbType.Int, 4)
            P1.Value = PO_Number
            arParams(1) = P1

            Try
                dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Memos_LoadByPrimaryKey", arParams)

                dr.Read()
                Select Case Column_Name
                    Case "po_main_instruct"
                        _PO_Main_Instruct = dr.GetString(0)
                    Case "del_instruct"
                        _Del_Instruct = dr.GetString(0)
                    Case "po_footer"
                        _PO_Footer = dr.GetString(0)
                End Select
                dr.Close()
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:Select_PO_Memo:" + Column_Name, Err.Description)
            End Try
        End Function
        Public Function Select_PO_Memo_Default(ByVal funct As String, ByVal RefId As Integer, ByVal str As String, ByVal fn_code As String, ByVal seq_nbr As Integer) As Integer
            Dim dr As SqlDataReader
            Dim arParams(6) As SqlParameter

            Dim P0 As New SqlParameter("@funct", SqlDbType.VarChar, 25)
            P0.Value = funct
            arParams(0) = P0

            Dim P1 As New SqlParameter("@refid", SqlDbType.Int, 4)
            P1.Value = RefId
            arParams(1) = P1

            Dim P2 As New SqlParameter("@str", SqlDbType.VarChar, 25)
            P2.Value = str
            arParams(2) = P2

            Dim P3 As New SqlParameter("@reftype", SqlDbType.Char, 5)
            P3.Value = "PO"
            arParams(3) = P3

            Dim P4 As New SqlParameter("@fn_code", SqlDbType.Char, 5)
            P4.Value = ""
            arParams(4) = P4

            Dim P5 As New SqlParameter("@seq_nbr", SqlDbType.Int)
            P5.Value = seq_nbr
            arParams(5) = P5
            Try
                dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Memos_LoadDefault", arParams)

                dr.Read()
                Me._Default_Memo_Text = dr.GetString(0)
                dr.Close()
                Return 0
            Catch
                '  Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:Select_PO_Memo_Default", Err.Description)
                Me._Default_Memo_Text = Err.Description
                Return 1
            End Try
        End Function
        Public Function Select_PO_Estimate_Memos(ByVal funct As String, ByVal RefId As Integer, ByVal RefType As String, ByVal str As String, ByVal fn_code As String, ByVal seq_nbr As Integer) As SqlDataReader
            Dim dr As SqlDataReader
            Dim arParams(6) As SqlParameter

            Dim P0 As New SqlParameter("@funct", SqlDbType.VarChar, 25)
            P0.Value = funct
            arParams(0) = P0

            Dim P1 As New SqlParameter("@refid", SqlDbType.Int, 4)
            P1.Value = RefId
            arParams(1) = P1

            Dim P2 As New SqlParameter("@str", SqlDbType.VarChar, 25)
            P2.Value = str
            arParams(2) = P2

            Dim P3 As New SqlParameter("@reftype", SqlDbType.Char, 5)
            P3.Value = RefType
            arParams(3) = P3

            Dim P4 As New SqlParameter("@fn_code", SqlDbType.Char, 6)
            P4.Value = fn_code
            arParams(4) = P4

            Dim P5 As New SqlParameter("@seq_nbr", SqlDbType.Int)
            P5.Value = seq_nbr
            arParams(5) = P5

            Try
                dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Memos_LoadDefault", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:Select_PO_Estimate_Memos", Err.Description)
            End Try

            Return dr

        End Function
        Public Function Select_PO_Estimate_MemosDS(ByVal funct As String, ByVal RefId As Integer, ByVal RefType As String, ByVal str As String, ByVal fn_code As String, ByVal seq_nbr As Integer)
            Dim ds As DataSet
            Dim arParams(6) As SqlParameter

            Dim P0 As New SqlParameter("@funct", SqlDbType.VarChar, 25)
            P0.Value = funct
            arParams(0) = P0

            Dim P1 As New SqlParameter("@refid", SqlDbType.Int, 4)
            P1.Value = RefId
            arParams(1) = P1

            Dim P2 As New SqlParameter("@str", SqlDbType.VarChar, 25)
            P2.Value = str
            arParams(2) = P2

            Dim P3 As New SqlParameter("@reftype", SqlDbType.Char, 5)
            P3.Value = RefType
            arParams(3) = P3

            Dim P4 As New SqlParameter("@fn_code", SqlDbType.Char, 6)
            P4.Value = fn_code
            arParams(4) = P4

            Dim P5 As New SqlParameter("@seq_nbr", SqlDbType.Int)
            P5.Value = seq_nbr
            arParams(5) = P5

            Try
                ds = oSQL.ExecuteDataset(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Memos_LoadDefault", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:Select_PO_Estimate_Memos", Err.Description)
            End Try

            Return ds

        End Function
        Public Function LoadAll_PO_Vendor_Contact(ByVal funct_id As Integer, ByVal vn_code As String, ByVal string1 As String) As SqlDataReader
            Dim dr As SqlDataReader

            Dim arParams(3) As SqlParameter

            Dim P0 As New SqlParameter("@funct", SqlDbType.Int, 4)
            P0.Value = funct_id
            arParams(0) = P0

            Dim P1 As New SqlParameter("@code", SqlDbType.VarChar, 15)
            P1.Value = vn_code
            arParams(1) = P1

            Dim P2 As New SqlParameter("@str", SqlDbType.VarChar, 15)
            P2.Value = string1
            arParams(2) = P2

            Try
                dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Vend_Contact_LoadAll", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:LoadAll_PO_Vendor_Contact", Err.Description)
            End Try

            Return dr

        End Function
        Public Function Get_PO_Vendor_Primary_Contact(ByVal vn_Code As String, ByRef vc_code As String, ByRef vc_name As String, ByRef vc_email As String) As String
            Dim arParams(4) As SqlParameter

            Dim P0 As New SqlParameter("@vc_code", SqlDbType.Char, 6)
            P0.Direction = ParameterDirection.Output
            arParams(0) = P0

            Dim P1 As New SqlParameter("@vc_name", SqlDbType.VarChar, 255)
            P1.Direction = ParameterDirection.Output
            arParams(1) = P1

            Dim P2 As New SqlParameter("@vc_email", SqlDbType.VarChar, 255)
            P2.Direction = ParameterDirection.Output
            arParams(2) = P2

            Dim P3 As New SqlParameter("@vn_code", SqlDbType.VarChar, 15)
            P3.Value = vn_Code
            arParams(3) = P3


            Try
                oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Vend_GetDefaultContact", arParams)
                vc_code = arParams(0).Value
                vc_name = arParams(1).Value
                vc_email = arParams(2).Value
                Return vc_code

            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:Get_PO_Vendor_Primary", Err.Description)
            End Try
        End Function
        Public Function Get_PO_Emp_Limit(ByVal funct_id As Integer, ByVal EmpCode As String, ByRef User_Code As String, ByRef User_Name As String) As Decimal
            Dim arParams(5) As SqlParameter

            Dim P0 As New SqlParameter("@po_limit", SqlDbType.Decimal)
            P0.Direction = ParameterDirection.Output
            P0.Scale = 2
            arParams(0) = P0

            Dim P1 As New SqlParameter("@user_code", SqlDbType.VarChar, 15)
            P1.Direction = ParameterDirection.Output
            arParams(1) = P1

            Dim P2 As New SqlParameter("@user_name", SqlDbType.VarChar, 255)
            P2.Direction = ParameterDirection.Output
            arParams(2) = P2

            Dim P3 As New SqlParameter("@funct", SqlDbType.Int, 4)
            P3.Value = funct_id
            arParams(3) = P3

            Dim P4 As New SqlParameter("@emp_code", SqlDbType.Char, 6)
            P4.Value = EmpCode
            arParams(4) = P4

            Try
                oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_GetEmpPOLimit", arParams)
                User_Code = arParams(1).Value
                User_Name = arParams(2).Value
                Return arParams(0).Value 'retrun PO limit for employee...

            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:Get_PO_Emp_Limit", Err.Description)
                Return 0 'returning zero will disallow purchase order creation.
            End Try

        End Function
        Public Function Get_PO_Emp_Amount_Remaining(ByVal EmpCode As String, ByVal PONumber As Integer, ByRef POLimit As Decimal, ByRef UsedAmount As Decimal) As Decimal
            Dim arParams(5) As SqlParameter

            Dim P0 As New SqlParameter("@limit", SqlDbType.Decimal)
            P0.Direction = ParameterDirection.Output
            arParams(0) = P0

            Dim P1 As New SqlParameter("@used_amount", SqlDbType.Decimal)
            P1.Direction = ParameterDirection.Output
            arParams(1) = P1

            Dim P2 As New SqlParameter("@remaining_amount", SqlDbType.Decimal)
            P2.Direction = ParameterDirection.Output
            arParams(2) = P2

            Dim P3 As New SqlParameter("@emp_code", SqlDbType.Char, 6)
            P3.Value = EmpCode
            arParams(3) = P3

            Dim P4 As New SqlParameter("@ponumber", SqlDbType.Int, 4)
            P4.Value = PONumber
            arParams(4) = P4

            Try
                oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_GetEmpPOLimit_Remaining_Amt", arParams)
                POLimit = arParams(0).Value
                UsedAmount = arParams(1).Value
                Return arParams(2).Value 'retrun remaining dollar amount before reaching PO limit for employee...

            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:Get_PO_Emp_Amount_Remaining", Err.Description)
                Return 0 'returning zero will disallow purchase order creation.
            End Try

        End Function
        Public Function Get_PO_Count(ByVal Count_Item As String, ByVal Ref_Id As Integer, ByVal Ref_Id2 As Integer, ByVal UserID As String) As Integer
            Dim arParams(4) As SqlParameter

            Dim P0 As New SqlParameter("@result", SqlDbType.Int, 2)
            P0.Direction = ParameterDirection.Output
            arParams(0) = P0

            Dim P1 As New SqlParameter("@count_item", SqlDbType.VarChar, 20)
            P1.Value = Count_Item
            arParams(1) = P1

            Dim P2 As New SqlParameter("@ref_id", SqlDbType.Int, 4)
            P2.Value = Ref_Id
            arParams(2) = P2

            Dim P3 As New SqlParameter("@ref_id2", SqlDbType.Int, 4)
            P3.Value = Ref_Id2
            arParams(3) = P3

            Dim P4 As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            P4.Value = UserID
            arParams(4) = P4


            Try
                oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Get_Count", arParams)
                Return arParams(0).Value
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:Get_PO_Count:" + Count_Item, Err.Description)
            End Try

        End Function
        Public Function Get_PO_Vendor_Main_Address(ByVal Vn_Code As String, ByVal iFormat As Integer, ByRef vn_Address1 As String, _
         ByRef vn_Address2 As String, ByRef vn_Address3 As String, ByRef vn_CityStateZip As String) As Integer
            Dim dr As SqlDataReader

            Dim arParams(2) As SqlParameter

            Dim P0 As New SqlParameter("@vn_code", SqlDbType.Char, 6)
            P0.Value = Vn_Code
            arParams(0) = P0

            Dim P1 As New SqlParameter("@format", SqlDbType.Int, 4)
            P1.Value = iFormat
            arParams(1) = P1

            Try
                dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Vendor_LoadAddress", arParams)
                dr.Read()
                vn_Address1 = dr.GetString(2)
                vn_Address2 = dr.GetString(3)
                vn_Address3 = ""
                vn_CityStateZip = dr.GetString(7)
                dr.Close()
                Return (0)

            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:Get_PO_Vendor_Main_Address", Err.Description)
            End Try


        End Function
        Public Function Get_PO_Vendor_EmailDS(ByVal funct As Integer, ByVal Ref_Id As Integer, ByVal Str As String) As DataSet
            Dim ds1 As New DataSet
            Dim arParams(3) As SqlParameter

            Dim P0 As New SqlParameter("@funct", SqlDbType.Int, 4)
            P0.Value = funct
            arParams(0) = P0

            Dim P1 As New SqlParameter("@ref_id", SqlDbType.Int, 4)
            P1.Value = Ref_Id
            arParams(1) = P1

            Dim P3 As New SqlParameter("@str", SqlDbType.VarChar, 25)
            P3.Value = Str
            arParams(2) = P3

            Try
                ds1 = oSQL.ExecuteDataset(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Vendor_LoadEmail", arParams)

            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:Get_PO_Vendor_EmailDS", Err.Description)
            End Try

            Return ds1

        End Function

        Public Function Select_POHeader(ByVal po_number As Integer, ByVal optionstr As String) As SqlDataReader
            Dim dr As SqlDataReader

            Dim arParams(2) As SqlParameter

            Dim P1 As New SqlParameter("@ref_id", SqlDbType.Int, 4)
            P1.Value = po_number
            arParams(0) = P1

            Dim P2 As New SqlParameter("@option", SqlDbType.VarChar, 25)
            P2.Value = optionstr
            arParams(1) = P2

            Try
                dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_LoadByPrimaryKey", arParams)

                dr.Read()
                If IsDBNull(dr("PO_DATE")) = True Then
                    _PO_Date = ""
                Else
                    _PO_Date = dr.GetDateTime(0).ToShortDateString
                End If
                _Vn_Code = dr.GetString(2)
                _PO_Description = dr.GetString(6)
                _Issue_By_Emp_Code = dr.GetString(3)
                If IsDBNull(dr("VOID_DATE")) = True Then
                    _Void_Info = ""
                Else
                    _Void_Info = "**Voided** " & LoGlo.FormatDate(dr.GetDateTime(29).ToShortDateString) & " by " & dr.GetString(30)
                End If
                _Issue_By_Emp_Name = dr.GetString(16)
                _Vn_VendorName = dr.GetString(11)
                If IsDBNull(dr("PO_DUE_DATE")) = True Then
                    _PO_Due_Date = ""
                Else
                    _PO_Due_Date = dr.GetDateTime(5).ToShortDateString
                End If
                _Vn_Address1 = dr.GetString(12)
                _Vn_Address2 = dr.GetString(13)
                _Vn_Address3 = dr.GetString(14)
                _Vn_CityStateZip = dr.GetString(15)
                _Vn_Contact_Code = dr.GetString(17)
                _Vn_Contact_Name = dr.GetString(18)
                _Vn_Contact_Email = dr.GetString(19)
                _PO_Total = dr.GetDecimal(20)
                _PO_Revision = dr.GetInt16(9)
                _PO_Approval_Flag = dr.GetInt16(25)
                _PO_Appr_Rule_Code = dr.GetString(26)
                _Exceed = dr.GetInt16(27)
                _PO_Printed = dr.GetInt16(28)

                If IsDBNull(dr("USER_MODIFIED")) = True Then
                    _ModifiedBy = Nothing
                Else
                    _ModifiedBy = dr.GetString(31)
                End If

                If IsDBNull(dr("MODIFIED_DATE")) = True Then
                    _ModifiedDate = Nothing
                Else
                    _ModifiedDate = dr.GetDateTime(32).ToShortDateString
                End If

                If dr.GetInt16(23) = 1 Then
                    _PO_Voided = True
                Else
                    _PO_Voided = False
                End If

                If dr.GetInt16(7) = 1 Then
                    _PO_Complete = True
                Else
                    _PO_Complete = False
                End If

                If dr.GetInt16(10) = 1 Then
                    _PO_Work_Complete = True
                Else
                    _PO_Work_Complete = False
                End If

                _PO_Pad = dr.GetString(24)
                dr.Close()
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:Select_POHeader", Err.Description)
            End Try

            Return dr

        End Function


        Public Function Insert_POHeader(ByVal Sys_UserID As String, ByVal VN_Code As String, ByVal VN_Cont_Code As String, _
           ByVal Emp_Code As String, ByVal PO_Date As DateTime, ByVal PO_Due_Date As Object, _
           ByVal PO_Description As String, ByVal PO_Complete As Int16, ByVal PO_Revision As Integer, _
           ByVal PO_Work_Complete As Int16, ByVal PO_Appr_Rule_Code As String) As Integer

            Dim arParams(12) As SqlParameter
            Dim Return_PO_Number As Integer = -1

            Dim P0 As New SqlParameter("@PO_NUM", SqlDbType.Int, 4)
            P0.Direction = ParameterDirection.Output
            arParams(0) = P0

            Dim P1 As New SqlParameter("@SYS_USER_ID", SqlDbType.VarChar, 100)
            P1.Value = Sys_UserID
            arParams(1) = P1

            Dim P2 As New SqlParameter("@VN_CODE", SqlDbType.VarChar, 6)
            P2.Value = VN_Code
            arParams(2) = P2

            Dim P3 As New SqlParameter("@VN_CONT_CODE", SqlDbType.VarChar, 4)
            P3.Value = VN_Cont_Code
            arParams(3) = P3

            Dim P4 As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            P4.Value = Emp_Code
            arParams(4) = P4

            Dim P5 As New SqlParameter("@PO_DATE", SqlDbType.DateTime)
            P5.Value = PO_Date
            arParams(5) = P5

            Dim P6 As New SqlParameter("@PO_DUE_DATE", SqlDbType.DateTime)
            P6.IsNullable = True
            P6.Value = PO_Due_Date
            arParams(6) = P6

            Dim P7 As New SqlParameter("@PO_DESCRIPTION", SqlDbType.VarChar, 40)
            P7.Value = PO_Description
            arParams(7) = P7

            Dim P8 As New SqlParameter("@PO_COMPLETE", SqlDbType.Int, 2) 'not used, system generated.
            P8.Value = PO_Complete
            arParams(8) = P8

            Dim P9 As New SqlParameter("@PO_REVISION", SqlDbType.Int)
            P9.Value = PO_Revision
            arParams(9) = P9

            Dim P10 As New SqlParameter("@PO_WORK_COMPLETE", SqlDbType.Int, 2)
            P10.Value = PO_Work_Complete
            arParams(10) = P10

            Dim P11 As New SqlParameter("@PO_APPR_RULE_CODE", SqlDbType.VarChar)
            If PO_Appr_Rule_Code = "" Then
                P11.Value = DBNull.Value
            Else
                P11.Value = PO_Appr_Rule_Code
            End If
            arParams(11) = P11

            Try
                oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Insert_Header", arParams)
                Return_PO_Number = arParams(0).Value
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:Insert_POHeader", Err.Description)
            End Try

            Insert_POHeader = Return_PO_Number
        End Function
        Public Function Update_POHeader(ByVal PO_Number As Integer, ByVal Sys_UserID As String, ByVal VN_Code As String, ByVal VN_Cont_Code As String, _
        ByVal Emp_Code As String, ByVal PO_Date As DateTime, ByVal PO_Due_Date As Object, _
        ByVal PO_Description As String, ByVal PO_Complete As Int16, ByVal PO_Revision As Integer, _
        ByVal PO_Work_Complete As Int16, ByVal exceed As Integer) As Integer

            Dim arParams(12) As SqlParameter

            Dim P0 As New SqlParameter("@PO_NUMBER", SqlDbType.Int, 4)
            P0.Value = PO_Number
            arParams(0) = P0

            Dim P1 As New SqlParameter("@SYS_USER_ID", SqlDbType.VarChar, 100)
            P1.Value = Sys_UserID
            arParams(1) = P1

            Dim P2 As New SqlParameter("@VN_CODE", SqlDbType.VarChar, 6)
            P2.Value = VN_Code
            arParams(2) = P2

            Dim P3 As New SqlParameter("@VN_CONT_CODE", SqlDbType.VarChar, 4)
            P3.Value = VN_Cont_Code
            arParams(3) = P3

            Dim P4 As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            P4.Value = Emp_Code
            arParams(4) = P4

            Dim P5 As New SqlParameter("@PO_DATE", SqlDbType.DateTime)
            If PO_Date = Nothing Then
                P5.Value = System.DBNull.Value
            Else
                P5.Value = PO_Date
            End If
            arParams(5) = P5

            Dim P6 As New SqlParameter("@PO_DUE_DATE", SqlDbType.DateTime)
            P6.IsNullable = True
            If PO_Due_Date = Nothing Then
                P6.Value = System.DBNull.Value
            Else
                P6.Value = PO_Due_Date
            End If
            arParams(6) = P6

            Dim P7 As New SqlParameter("@PO_DESCRIPTION", SqlDbType.VarChar, 40)
            P7.Value = PO_Description
            arParams(7) = P7

            Dim P8 As New SqlParameter("@PO_COMPLETE", SqlDbType.Int, 2) 'not used, system generated.
            P8.Value = PO_Complete
            arParams(8) = P8

            Dim P9 As New SqlParameter("@PO_REVISION", SqlDbType.Int)
            P9.Value = PO_Revision
            arParams(9) = P9

            Dim P10 As New SqlParameter("@PO_WORK_COMPLETE", SqlDbType.Int, 2)
            P10.Value = PO_Work_Complete
            arParams(10) = P10

            Dim P11 As New SqlParameter("@Exceed", SqlDbType.SmallInt)
            P11.Value = exceed
            arParams(11) = P11

            Try
                oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Update_Header", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:Update_POHeader", Err.Description)
            End Try

        End Function
        Public Function UpdatePOPrintDef(ByVal UserId As String, ByVal bDateToPrint As Int16, ByVal Show_Ship_Instruction As Int16, _
        ByVal Show_PO_Instruction As Int16, ByVal Show_Footer_Comment As Int16, ByVal Show_Detail_Description As Int16, _
        ByVal Show_Detail_Instruction As Int16, ByVal Show_Vendor_Contact As Int16, ByVal Show_Client_Name As Int16, _
        ByVal Show_Product_Name As Int16, ByVal Show_Job_Comp As Int16, ByVal Location_Id As String, ByVal Logo_Path As String, _
        ByVal Report_Format As String, ByVal Show_Func_Descrip As Int16, ByVal Show_Job_Descrip As Int16, ByVal Show_emp_sig As Int16, _
        ByVal Vendor_Code As Int16) As Integer

            Dim arParams(18) As SqlParameter

            Dim P0 As New SqlParameter("@userid", SqlDbType.VarChar, 100)
            P0.Value = UserId
            arParams(0) = P0

            Dim P1 As New SqlParameter("@date_to_print", SqlDbType.SmallInt)
            P1.Value = bDateToPrint
            arParams(1) = P1

            Dim P2 As New SqlParameter("@shp_instruction", SqlDbType.SmallInt)
            P2.Value = Show_Ship_Instruction
            arParams(2) = P2

            Dim P3 As New SqlParameter("@po_instruction", SqlDbType.SmallInt)
            P3.Value = Show_PO_Instruction
            arParams(3) = P3

            Dim P4 As New SqlParameter("@footer_comment", SqlDbType.SmallInt)
            P4.Value = Show_Footer_Comment
            arParams(4) = P4

            Dim P5 As New SqlParameter("@detail_description", SqlDbType.SmallInt)
            P5.Value = Show_Detail_Description
            arParams(5) = P5

            Dim P6 As New SqlParameter("@detail_instruction", SqlDbType.SmallInt)
            P6.Value = Show_Detail_Instruction
            arParams(6) = P6

            Dim P7 As New SqlParameter("@vendor_contact", SqlDbType.SmallInt)
            P7.Value = Show_Vendor_Contact
            arParams(7) = P7

            Dim P8 As New SqlParameter("@client_name", SqlDbType.SmallInt)
            P8.Value = Show_Client_Name
            arParams(8) = P8

            Dim P9 As New SqlParameter("@product_name", SqlDbType.SmallInt)
            P9.Value = Show_Product_Name
            arParams(9) = P9

            Dim P10 As New SqlParameter("@job_cmp_nbr", SqlDbType.SmallInt)
            P10.Value = Show_Job_Comp
            arParams(10) = P10

            Dim P11 As New SqlParameter("@location_id", SqlDbType.VarChar, 6)
            P11.Value = Location_Id
            arParams(11) = P11

            Dim P12 As New SqlParameter("@logo_path", SqlDbType.VarChar, 254)
            P12.Value = Logo_Path
            arParams(12) = P12

            Dim P13 As New SqlParameter("@report_format", SqlDbType.VarChar, 50)
            P13.Value = Report_Format
            arParams(13) = P13

            Dim P14 As New SqlParameter("@fnc_description", SqlDbType.SmallInt)
            P14.Value = Show_Func_Descrip
            arParams(14) = P14

            Dim P15 As New SqlParameter("@job_desc", SqlDbType.SmallInt)
            P15.Value = Show_Job_Descrip
            arParams(15) = P15

            Dim P16 As New SqlParameter("@USE_EMP_SIG", SqlDbType.SmallInt)
            P16.Value = Show_emp_sig
            arParams(16) = P16

            Dim P17 As New SqlParameter("@vendor_code", SqlDbType.SmallInt)
            P17.Value = Vendor_Code
            arParams(17) = P17


            Try
                oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Update_PrintDef", arParams)
                Return 0
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:proc_WV_PO_Update_PrintDef", Err.Description)
                Return 1
            End Try

        End Function
        Public Function Void_PO(ByVal PO_Number As Integer, ByVal SysUserId As String) As Integer
            Dim arParams(2) As SqlParameter

            Dim P0 As New SqlParameter("@po_number", SqlDbType.Int, 4)
            P0.Value = PO_Number
            arParams(0) = P0

            Dim P1 As New SqlParameter("@sys_user_id", SqlDbType.VarChar, 100)
            P1.Value = SysUserId
            arParams(1) = P1

            Try
                oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Void", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:Void_PO", Err.Description)
            End Try

        End Function
        Public Function Void_PO_Undo(ByVal PO_Number As Integer) As Integer
            Dim arParams(1) As SqlParameter

            Dim P0 As New SqlParameter("@po_number", SqlDbType.Int, 4)
            P0.Value = PO_Number
            arParams(0) = P0

            Try
                oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Void_Undo", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:Void_PO_Undo", Err.Description)
            End Try
        End Function
        Public Function Increment_PO_Revision(ByVal funct_id As Integer, ByVal PO_Number As Integer) As Int16
            Dim arParams(3) As SqlParameter
            Dim New_Rev_Number As Int16 = 0

            Dim P0 As New SqlParameter("@new_revision_num", SqlDbType.Int, 2)
            P0.Direction = ParameterDirection.Output
            arParams(0) = P0

            Dim P1 As New SqlParameter("@funct", SqlDbType.Int, 4)
            P1.Value = funct_id
            arParams(1) = P1

            Dim P2 As New SqlParameter("@po_number", SqlDbType.Int, 4)
            P2.Value = PO_Number
            arParams(2) = P2

            Try
                oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Update_Revision", arParams)
                New_Rev_Number = arParams(0).Value
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:proc_WV_PO_Update_Revision", Err.Description)
            End Try

            Increment_PO_Revision = New_Rev_Number

        End Function
        Public Function UpdatePOMemo(ByVal Update_Column As String, ByVal PO_Number As Integer, ByVal sText As Object)
            Dim arParams(3) As SqlParameter

            Dim P0 As New SqlParameter("@update_column", SqlDbType.VarChar, 25)
            P0.Value = Update_Column
            arParams(0) = P0

            Dim P1 As New SqlParameter("@po_number", SqlDbType.Int, 4)
            P1.Value = PO_Number
            arParams(1) = P1

            Dim P2 As New SqlParameter("@text", SqlDbType.Text, 2147483647)
            P2.IsNullable = True
            If sText.ToString() = "" Then
                P2.Value = DBNull.Value
            Else
                P2.Value = sText.ToString
            End If
            arParams(2) = P2

            Try
                oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Update_Header_Memos", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:UpdatePOMemo:" + Update_Column, Err.Description)
            End Try
        End Function
        Public Function Copy_PO(ByVal Copy_From_PO_Number As Integer, ByVal Sys_UserId As String, ByVal PO_Date As DateTime, _
         ByVal PO_Due_Date As Object, ByVal New_Emp_Code As String, ByVal Copy_Memo_Flg As Int16, ByVal PORuleCode As String) As Integer

            Dim arParams(8) As SqlParameter
            Dim Return_PO_Number As Integer = -1

            Dim P0 As New SqlParameter("@new_po_num", SqlDbType.Int, 4)
            P0.Direction = ParameterDirection.Output
            arParams(0) = P0

            Dim P1 As New SqlParameter("@copy_from_po_num", SqlDbType.Int, 4)
            P1.Value = Copy_From_PO_Number
            arParams(1) = P1

            Dim P2 As New SqlParameter("@sys_user_id", SqlDbType.VarChar, 100)
            P2.Value = Sys_UserId
            arParams(2) = P2

            Dim P3 As New SqlParameter("@podate", SqlDbType.DateTime)
            P3.Value = PO_Date
            arParams(3) = P3

            Dim P4 As New SqlParameter("@duedate", SqlDbType.DateTime)
            P4.IsNullable = True
            P4.Value = PO_Due_Date
            arParams(4) = P4

            Dim P5 As New SqlParameter("@change_emp_code", SqlDbType.Char, 6)  'passing empty string uses existing empcode on source PO.
            P5.Value = New_Emp_Code
            arParams(5) = P5

            Dim P6 As New SqlParameter("@copy_memos_flag", SqlDbType.SmallInt)
            P6.Value = Copy_Memo_Flg
            arParams(6) = P6

            Dim P7 As New SqlParameter("@porulecode", SqlDbType.VarChar)
            If PORuleCode = "" Then
                P7.Value = DBNull.Value
            Else
                P7.Value = PORuleCode
            End If
            arParams(7) = P7


            Try
                oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Insert_PO_Copy", arParams)
                Return_PO_Number = arParams(0).Value
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:Copy_PO:", Err.Description)
            End Try

            Copy_PO = Return_PO_Number
        End Function
        Public Function ValidatePOHeader(ByVal Emp_Code As String, ByVal Vendor_Code As String, ByVal Vend_Contact_Code As String, ByRef sErrorList As String) As Integer
            'validate database constraints for free-format data.
            Dim arParams(10) As SqlParameter

            Dim P0 As New SqlParameter("@msg", SqlDbType.VarChar, 2000)
            P0.Direction = ParameterDirection.Output
            arParams(0) = P0

            Dim P1 As New SqlParameter("@errorcount", SqlDbType.Int, 4)
            P1.Direction = ParameterDirection.Output
            arParams(1) = P1

            Dim P2 As New SqlParameter("@check", SqlDbType.Int, 4)
            P2.Value = 2 'validate PO header.
            arParams(2) = P2

            Dim P3 As New SqlParameter("@job_number", SqlDbType.VarChar, 25)
            P3.Value = "" 'used only in detail check
            arParams(3) = P3

            Dim P4 As New SqlParameter("@component_nbr", SqlDbType.VarChar, 10)
            P4.Value = "" 'used only in detail check
            arParams(4) = P4

            Dim P5 As New SqlParameter("@fnc_code", SqlDbType.Char, 6)
            P5.Value = "" 'used only in detail check
            arParams(5) = P5

            Dim P6 As New SqlParameter("@emp_code", SqlDbType.Char, 6)
            P6.Value = Emp_Code
            arParams(6) = P6

            Dim P7 As New SqlParameter("@vn_code", SqlDbType.Char, 6)
            P7.Value = Vendor_Code
            arParams(7) = P7

            Dim P8 As New SqlParameter("@vc_code", SqlDbType.Char, 4)
            P8.Value = Vend_Contact_Code
            arParams(8) = P8

            Dim P9 As New SqlParameter("@gla_code", SqlDbType.VarChar, 30)
            P9.Value = "" 'used only in detail check
            arParams(9) = P9

            Try
                oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Validation", arParams)
                sErrorList = arParams(0).Value 'error description text.
                Return arParams(1).Value 'return error count
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:ValidateDetail", Err.Description)
            End Try
        End Function
        Public Function GetPOReqdExtAmount_Flg() As Int16
            Dim arParams(8) As SqlParameter

            Dim P0 As New SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4)
            P0.Direction = ParameterDirection.ReturnValue
            arParams(0) = P0

            Dim P1 As New SqlParameter("@funct", SqlDbType.Int, 4)
            P1.Value = 1
            arParams(1) = P1

            Try
                oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_GetRequiredAmt_flg", arParams)
                Return arParams(0).Value 'return
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:GetPOReqdExtAmount_Flg", Err.Description)
            End Try

        End Function
        Public Function GetPOEstimateRestrictions(ByVal funct As Integer, ByVal EmpCode As String, ByVal JobNumber As Integer, ByRef Allow_Without_Estimate As Int16, _
          ByRef Allow_Exceed_Estimate As Int16, ByRef Op1 As Int16, ByRef Op2 As Int16, ByRef Display_Msg As String) As Integer
            Dim arParams(8) As SqlParameter

            Dim P0 As New SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4)
            P0.Direction = ParameterDirection.ReturnValue
            arParams(0) = P0

            Dim P1 As New SqlParameter("@allow_wo_estimate", SqlDbType.Int, 2)
            P1.Direction = ParameterDirection.Output
            arParams(1) = P1

            Dim P2 As New SqlParameter("@allow_exceed_estimate", SqlDbType.Int, 2)
            P2.Direction = ParameterDirection.Output
            arParams(2) = P2

            Dim P3 As New SqlParameter("@op2", SqlDbType.Int, 2)
            P3.Direction = ParameterDirection.Output
            arParams(3) = P3

            Dim P4 As New SqlParameter("@op4", SqlDbType.Int, 2)
            P4.Direction = ParameterDirection.Output
            arParams(4) = P4

            Dim P5 As New SqlParameter("@display_msg", SqlDbType.VarChar, 100)
            P5.Direction = ParameterDirection.Output
            arParams(5) = P5

            Dim P6 As New SqlParameter("@funct", SqlDbType.Int, 4)
            P6.Value = funct
            arParams(6) = P6

            Dim P7 As New SqlParameter("@empcode", SqlDbType.Char, 6)
            P7.Value = EmpCode
            arParams(7) = P7

            Dim P8 As New SqlParameter("@job", SqlDbType.Int, 4)
            P8.Value = JobNumber
            arParams(8) = P8

            Try
                oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_LoadEstRqd_Options", arParams)
                Allow_Without_Estimate = arParams(1).Value
                Allow_Exceed_Estimate = arParams(2).Value
                Op1 = arParams(3).Value
                Op2 = arParams(4).Value
                Display_Msg = arParams(5).Value.ToString

                Return arParams(0).Value 'return
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:GetPOEstimateRestrictions", Err.Description)
            End Try

        End Function
        Public Function GetCustomPickList(ByVal List_Code As String, ByVal Str1 As String, ByVal Sort As String) As SqlDataReader
            'variable picklist..
            Dim dr As SqlDataReader

            Dim arParams(3) As SqlParameter

            Dim P0 As New SqlParameter("@list_code", SqlDbType.VarChar, 100)
            P0.Value = List_Code
            arParams(0) = P0

            Dim P1 As New SqlParameter("@str", SqlDbType.VarChar, 15)
            P1.Value = Str1
            arParams(1) = P1

            Dim P2 As New SqlParameter("@sort", SqlDbType.VarChar, 100)
            P2.Value = Sort
            arParams(2) = P2

            Try
                dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_GetCustomPickList", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:GetCustomPickList:" + List_Code, Err.Description)
            End Try

            Return dr

        End Function
        Public Function GetCustomPickList_DTable(ByVal List_Code As String, ByVal Str1 As String, ByVal Sort As String, ByVal user As String) As DataTable
            Dim arParams(4) As SqlParameter
            Dim dt As DataTable

            Dim P0 As New SqlParameter("@list_code", SqlDbType.VarChar, 100)
            P0.Value = List_Code
            arParams(0) = P0

            Dim P1 As New SqlParameter("@str", SqlDbType.VarChar, 15)
            P1.Value = Str1
            arParams(1) = P1

            Dim P2 As New SqlParameter("@sort", SqlDbType.VarChar, 100)
            P2.Value = Sort
            arParams(2) = P2

            Dim P3 As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            P3.Value = user
            arParams(3) = P3

            Try
                dt = oSQL.ExecuteDataTable(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_GetCustomPickList", "tbl_Picklist", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:GetCustomPickList:", Err.Description)
            End Try

            Return dt

        End Function
        Public Function GetPO_PrintDef_By_User_DTable(ByVal UserID As String) As DataTable
            Dim arParams(1) As SqlParameter
            Dim dt As DataTable

            Dim P0 As New SqlParameter("@userid", SqlDbType.VarChar, 100)
            P0.Value = UserID
            arParams(0) = P0

            Try
                dt = oSQL.ExecuteDataTable(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_PrintDef_LoadByPrimaryKey", "tbl_Def", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:GetPO_PrintDef_By_User:" + UserID, Err.Description)
            End Try

            Return dt

        End Function
        Public Function GetPO_PrintDef_LocationName(ByVal LocationID As String) As String
            Dim arParams(1) As SqlParameter
            Dim dt As String

            Dim P0 As New SqlParameter("@locid", SqlDbType.VarChar, 6)
            P0.Value = LocationID
            arParams(0) = P0

            Try
                dt = oSQL.ExecuteScalar(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_PrintDef_LocationName", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:GetPO_PrintDef_LocName:" + LocationID, Err.Description)
            End Try

            Return dt

        End Function
        Public Function GetPOApprRuleCodebyDept(ByVal dept As String) As String
            Dim arParams(8) As SqlParameter
            Dim code As String
            'Dim P0 As New SqlParameter("@RETURN_VALUE", SqlDbType.VarChar, 6)
            'P0.Direction = ParameterDirection.ReturnValue
            'arParams(0) = P0

            Dim P1 As New SqlParameter("@Dept", SqlDbType.VarChar, 4)
            P1.Value = dept
            arParams(0) = P1

            Try
                code = oSQL.ExecuteScalar(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_GetPOApprRuleCode_Dept", arParams)
                Return code
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:GetPOApprRuleCode_Dept", Err.Description)
            End Try

        End Function
        Public Function GetPOApprRuleCodebyEmp(ByVal empcode As String) As String
            Dim arParams(8) As SqlParameter
            Dim code As String
            'Dim P0 As New SqlParameter("@RETURN_VALUE", SqlDbType.VarChar, 6)
            'P0.Direction = ParameterDirection.ReturnValue
            'arParams(0) = P0

            Dim P1 As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            P1.Value = empcode
            arParams(0) = P1

            Try
                code = oSQL.ExecuteScalar(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_GetPOApprRuleCode_Emp", arParams)
                Return code
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:GetPOApprRuleCode_Emp", Err.Description)
            End Try

        End Function
        Public Function GetPO_Locations(ByVal funct As Integer, ByVal UserId As String) As SqlDataReader
            Dim dr As SqlDataReader
            Dim arParams(2) As SqlParameter

            Dim P0 As New SqlParameter("@funct", SqlDbType.Int, 4)
            P0.Value = funct
            arParams(0) = P0

            Dim P1 As New SqlParameter("@userid", SqlDbType.VarChar, 100)
            P1.Value = UserId
            arParams(1) = P1

            Try
                dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Locations_LoadAll", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:GetPO_Locations", Err.Description)
            End Try

            Return dr
        End Function
        Public Function GetPOApprovals(ByVal ponumber As Integer) As SqlDataReader
            Dim arParams(2) As SqlParameter
            Dim dr As SqlDataReader

            Dim P1 As New SqlParameter("@PONumber", SqlDbType.Int)
            P1.Value = ponumber
            arParams(0) = P1

            Try
                dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_GetPOApprovals", arParams)
                Return dr
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:GetPOApprovals", Err.Description)
            End Try

        End Function
        Public Function GetPOActions() As DataTable

            Dim dt As DataTable

            Try

                dt = oSQL.ExecuteDataTable(_ConnectionString, CommandType.StoredProcedure, "advsp_po_action_list", "Details", Nothing)

                Return dt

            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:GetPOActions", Err.Description)
            End Try

        End Function
        Public Function GetPOApprRules(ByVal porulecode As String, ByVal poamount As Decimal)
            Dim arParams(2) As SqlParameter
            Dim dr As SqlDataReader

            Dim P1 As New SqlParameter("@PORuleCode", SqlDbType.VarChar)
            P1.Value = porulecode
            arParams(0) = P1

            Dim P2 As New SqlParameter("@POAmount", SqlDbType.Decimal)
            P2.Value = poamount
            arParams(1) = P2

            Try
                dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_GetPOApprRules", arParams)
                Return dr
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:GetPOApprRules", Err.Description)
            End Try

        End Function
        Public Function GetPOApprData(ByVal poempcode As String, ByVal ponum As Integer)
            Dim arParams(2) As SqlParameter
            Dim dr As SqlDataReader

            Dim P1 As New SqlParameter("@POEmpCode", SqlDbType.VarChar)
            P1.Value = poempcode
            arParams(0) = P1

            Dim P2 As New SqlParameter("@PONum", SqlDbType.Int)
            P2.Value = ponum
            arParams(1) = P2

            Try
                dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_GetPOApprData", arParams)
                Return dr
            Catch ex As Exception
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:GetPOApprData", Err.Description)
            End Try

        End Function
        Public Function GetPOApprDataByPO(ByVal ponum As Integer)
            Dim arParams(1) As SqlParameter
            Dim dr As SqlDataReader

            Dim P1 As New SqlParameter("@PONum", SqlDbType.Int)
            P1.Value = ponum
            arParams(0) = P1

            Try
                dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_GetPOApprDataByPO", arParams)
                Return dr
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:GetPOApprDataByPO", Err.Description)
            End Try

        End Function
        Public Function AddPOApproval(ByVal PONum As Integer, ByVal RuleCode As String, ByVal SeqNum As Integer, _
                                      ByVal RuleID As Integer, ByVal ApprovalFlag As String, ByVal ApprovalUser As String, _
                                      ByVal ApprovalDate As String, ByVal ApprovalNotes As String)

            Dim arParams(9) As SqlParameter

            Dim P0 As New SqlParameter("@PO_NUMBER", SqlDbType.Int)
            P0.Value = PONum
            arParams(0) = P0

            Dim P1 As New SqlParameter("@PO_APPR_RULE_CODE", SqlDbType.VarChar)
            P1.Value = RuleCode
            arParams(1) = P1

            Dim P2 As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
            P2.Value = SeqNum
            arParams(2) = P2

            Dim P3 As New SqlParameter("@PO_APPR_RULE_ID", SqlDbType.Int)
            P3.Value = RuleID
            arParams(3) = P3

            Dim P4 As New SqlParameter("@PO_APPROVAL_FLAG", SqlDbType.Bit)
            If ApprovalFlag = "" Then
                P4.Value = DBNull.Value
            Else
                P4.Value = ApprovalFlag
            End If
            arParams(4) = P4

            Dim P5 As New SqlParameter("@PO_APPROVAL_USER", SqlDbType.VarChar)
            If ApprovalFlag = "" Then
                P5.Value = DBNull.Value
            Else
                P5.Value = ApprovalUser
            End If
            arParams(5) = P5

            Dim P6 As New SqlParameter("@PO_APPROVAL_DATE", SqlDbType.DateTime)
            If ApprovalFlag = "" Then
                P6.Value = DBNull.Value
            Else
                P6.Value = CDate(ApprovalDate).ToShortDateString
            End If
            arParams(6) = P6

            Dim P7 As New SqlParameter("@PO_APPROVAL_NOTES", SqlDbType.Text)
            If ApprovalFlag = "" Then
                P7.Value = DBNull.Value
            Else
                P7.Value = ApprovalNotes
            End If
            arParams(7) = P7

            Try
                oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_AddPOApproval", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:AddPOApproval", Err.Description)
            End Try

        End Function
        Public Function UpdatePOApproval(ByVal PONum As Integer, ByVal RuleCode As String, ByVal SeqNum As Integer, _
                                      ByVal RuleID As Integer, ByVal ApprovalFlag As String, ByVal ApprovalUser As String, _
                                      ByVal ApprovalDate As String, ByVal ApprovalNotes As String)

            Dim arParams(9) As SqlParameter

            Dim P0 As New SqlParameter("@PO_NUMBER", SqlDbType.Int)
            P0.Value = PONum
            arParams(0) = P0

            Dim P1 As New SqlParameter("@PO_APPR_RULE_CODE", SqlDbType.VarChar)
            P1.Value = RuleCode
            arParams(1) = P1

            Dim P2 As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
            P2.Value = SeqNum
            arParams(2) = P2

            Dim P3 As New SqlParameter("@PO_APPR_RULE_ID", SqlDbType.Int)
            P3.Value = RuleID
            arParams(3) = P3

            Dim P4 As New SqlParameter("@PO_APPROVAL_FLAG", SqlDbType.Bit)
            If ApprovalFlag = "" Then
                P4.Value = DBNull.Value
            Else
                P4.Value = ApprovalFlag
            End If
            arParams(4) = P4

            Dim P5 As New SqlParameter("@PO_APPROVAL_USER", SqlDbType.VarChar)
            If ApprovalFlag = "" Then
                P5.Value = DBNull.Value
            Else
                P5.Value = ApprovalUser
            End If
            arParams(5) = P5

            Dim P6 As New SqlParameter("@PO_APPROVAL_DATE", SqlDbType.DateTime)
            If ApprovalFlag = "" Then
                P6.Value = DBNull.Value
            Else
                P6.Value = CDate(ApprovalDate).ToShortDateString
            End If
            arParams(6) = P6

            Dim P7 As New SqlParameter("@PO_APPROVAL_NOTES", SqlDbType.Text)
            If ApprovalFlag = "" Then
                P7.Value = DBNull.Value
            Else
                P7.Value = ApprovalNotes
            End If
            arParams(7) = P7

            Try
                oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_UpdatePOApproval", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:UpdatePOApproval", Err.Description)
            End Try

        End Function
        Public Function UpdatePOPrint(ByVal funct_id As Integer, ByVal PO_Number As Integer, ByVal PO_Print As Integer)
            Dim arParams(3) As SqlParameter

            Dim P0 As New SqlParameter("@printed", SqlDbType.SmallInt)
            P0.Value = PO_Print
            arParams(0) = P0

            Dim P1 As New SqlParameter("@funct", SqlDbType.Int, 4)
            P1.Value = funct_id
            arParams(1) = P1

            Dim P2 As New SqlParameter("@po_number", SqlDbType.Int, 4)
            P2.Value = PO_Number
            arParams(2) = P2

            Try
                oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Update_Printed", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:proc_WV_PO_Update_Printed", Err.Description)
            End Try


        End Function

        Public Function GetPOEmpInOutStatus(ByVal poempcode As String)
            Dim arParams(1) As SqlParameter
            Dim inout As Integer

            Dim P1 As New SqlParameter("@POEmpCode", SqlDbType.VarChar)
            P1.Value = poempcode
            arParams(0) = P1

            Try
                inout = oSQL.ExecuteScalar(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_GetPOEmpInOutStatus", arParams)
                Return inout
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:GetPOEmpInOutStatus", Err.Description)
            End Try

        End Function
        Public Function GetPODoOwnSecurity(ByVal usercode As String)
            Dim arParams(1) As SqlParameter
            Dim doown As String

            Dim P1 As New SqlParameter("@UserCode", SqlDbType.VarChar)
            P1.Value = usercode
            arParams(0) = P1

            Try
                doown = oSQL.ExecuteScalar(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_GetPODoOwnPOSecurity", arParams)
                Return doown
            Catch
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:GetPODoOwnPOSecurity", Err.Description)
            End Try

        End Function
        Public Function GetPOBudgetComparisons(ByVal podate As DateTime, ByVal glacode As String)
            Dim arParams(2) As SqlParameter
            Dim dr As SqlDataReader

            Dim P1 As New SqlParameter("@PODate", SqlDbType.DateTime)
            P1.Value = podate
            arParams(0) = P1

            Dim P2 As New SqlParameter("@GlaCode", SqlDbType.VarChar)
            P2.Value = glacode
            arParams(1) = P2

            Try
                dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Budget_Comparisons", arParams)
                Return dr
            Catch ex As Exception
                Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:GetPOBudgetComparisons", Err.Description)
            End Try

        End Function
#End Region

        Public Class cPurchaseOrderDetail
            Dim oSQL As Webvantage.SqlHelper

#Region "PO Detail Private Class Variables"
            Private _ConnectionString As String
            Private _PO_Number As Integer
            Private _Ref_ID As Integer
            Private _Line_Number As Integer
            Private _Line_Desc As String
            Private _Det_Desc As String
            Private _Det_Instruct As String
            Private _Job_Number As Integer
            Private _Job_Component_Nbr As Integer
            Private _Fnc_Code As String
            Private _Fnc_Description As String
            Private _PO_Rate As Decimal
            Private _PO_Qty As Integer
            Private _PO_Ext_Amount
            Private _PO_Ext_Markup_Amt As Decimal
            Private _PO_Comm_Pct As Decimal
            Private _Line_Total As Decimal
            Private _PO_Complete_Flag As Boolean
            Private _CL_Code As String
            Private _Div_Code As String
            Private _Prd_Code As String
            Private _Attached_To_AP_Flag As Boolean
            Private _PO_Tax_Pct As Decimal
            Private _Use_CPM_Flag As Boolean
            Private _PO_Complete As Boolean  'from header
            Private _Vendor_Code As String 'from header
            Private _Job_Type_Code As String
            Private _PO_Voided As Boolean 'from header
            Private _Gla_Code As String
            Private _Gla_Description As String

#End Region

#Region "PO Detail Properties"
            Public Property PO_Number() As Integer
                Get
                    Return _PO_Number
                End Get
                Set(ByVal value As Integer)
                    _PO_Number = value
                End Set
            End Property
            Public Property ref_id() As Integer  'not used
                Get
                    Return _Ref_ID
                End Get
                Set(ByVal value As Integer)
                    ref_id = value
                End Set
            End Property
            Public Property Line_Number() As Integer
                Get
                    Return _Line_Number
                End Get
                Set(ByVal value As Integer)
                    _Line_Number = value
                End Set
            End Property
            Public Property Line_Desc() As String
                Get
                    Return _Line_Desc
                End Get
                Set(ByVal value As String)
                    _Line_Desc = value
                End Set
            End Property
            Public Property Det_Desc() As String
                Get
                    Return _Det_Desc
                End Get
                Set(ByVal value As String)
                    Det_Desc = value
                End Set
            End Property
            Public Property Det_Instructions() As String
                Get
                    Return _Det_Instruct
                End Get
                Set(ByVal value As String)
                    _Det_Instruct = value
                End Set
            End Property
            Public Property Job_Number() As Integer
                Get
                    Return _Job_Number
                End Get
                Set(ByVal value As Integer)
                    _Job_Number = value
                End Set
            End Property
            Public Property Job_Component_Nbr() As Integer
                Get
                    Return _Job_Component_Nbr
                End Get
                Set(ByVal value As Integer)
                    _Job_Component_Nbr = value
                End Set
            End Property
            Public Property Fnc_Code() As String
                Get
                    Return _Fnc_Code
                End Get
                Set(ByVal value As String)
                    _Fnc_Code = value
                End Set
            End Property
            Public ReadOnly Property Fnc_Descrip() As String
                Get
                    Return _Fnc_Description
                End Get
            End Property
            Public Property PO_Rate() As Decimal
                Get
                    Return _PO_Rate
                End Get
                Set(ByVal value As Decimal)
                    _PO_Rate = value
                End Set
            End Property
            Public Property PO_Qty() As Integer
                Get
                    Return _PO_Qty
                End Get
                Set(ByVal value As Integer)
                    _PO_Qty = value
                End Set
            End Property
            Public Property PO_Ext_Amount() As Decimal
                Get
                    Return _PO_Ext_Amount
                End Get
                Set(ByVal value As Decimal)
                    _PO_Ext_Amount = value
                End Set
            End Property
            Public Property PO_Ext_Markup_Amount() As Decimal
                Get
                    Return _PO_Ext_Markup_Amt
                End Get
                Set(ByVal value As Decimal)
                    _PO_Ext_Markup_Amt = value
                End Set
            End Property
            Public Property PO_Comm_Percent() As Double
                Get
                    Return _PO_Comm_Pct
                End Get
                Set(ByVal value As Double)
                    _PO_Comm_Pct = value
                End Set
            End Property
            Public Property Line_Total_wth_Markup() As Decimal
                Get
                    Return _Line_Total
                End Get
                Set(ByVal value As Decimal)
                    _Line_Total = value
                End Set
            End Property
            Public Property PO_Complete_Flag() As Boolean
                Get
                    Return _PO_Complete_Flag
                End Get
                Set(ByVal value As Boolean)
                    _PO_Complete_Flag = value
                End Set
            End Property
            Public Property Client_Code() As String
                Get
                    Return _CL_Code
                End Get
                Set(ByVal value As String)
                    _CL_Code = value
                End Set
            End Property
            Public Property Division_Code() As String
                Get
                    Return _Div_Code
                End Get
                Set(ByVal value As String)
                    _Div_Code = value
                End Set
            End Property
            Public Property Product_Code() As String
                Get
                    Return _Prd_Code
                End Get
                Set(ByVal value As String)
                    _Prd_Code = value
                End Set
            End Property
            Public Property Attached_to_AP_Flag() As Boolean
                Get
                    Return _Attached_To_AP_Flag
                End Get
                Set(ByVal value As Boolean)
                    _Attached_To_AP_Flag = value
                End Set
            End Property
            Public Property Tax_Percent() As Decimal
                Get
                    Return _PO_Tax_Pct
                End Get
                Set(ByVal value As Decimal)
                    _PO_Tax_Pct = value
                End Set
            End Property
            Public Property Use_CPM_Flag() As Boolean
                Get
                    Return _Use_CPM_Flag
                End Get
                Set(ByVal value As Boolean)
                    _Use_CPM_Flag = value
                End Set
            End Property
            Public ReadOnly Property PO_COMPLETE() As Boolean
                Get
                    Return _PO_Complete
                End Get
            End Property
            Public ReadOnly Property Vendor_Code() As String
                Get
                    Return _Vendor_Code
                End Get
            End Property
            Public ReadOnly Property Job_Type_Code() As String
                Get
                    Return _Job_Type_Code
                End Get
            End Property
            Public ReadOnly Property PO_Voided() As Boolean
                Get
                    Return _PO_Voided
                End Get
            End Property
            Public Property Gla_Code() As String
                Get
                    Return _Gla_Code
                End Get
                Set(ByVal value As String)
                    _Gla_Code = value
                End Set
            End Property
            Public Property Gla_Description() As String
                Get
                    Return _Gla_Description
                End Get
                Set(ByVal value As String)
                    _Gla_Description = value
                End Set
            End Property


#End Region

#Region "PO Detail Constructors"
            Public Sub New(ByVal ConnectionString As String)
                _ConnectionString = ConnectionString
            End Sub
#End Region

#Region "PO Detail Database Functions"

            Public Function LoadAll_PO_Detail_List(ByVal filter_id As Integer, ByVal ref_id As Integer, ByVal string1 As String, ByVal string2 As String) As SqlDataReader
                Dim dr As SqlDataReader

                Dim arParams(4) As SqlParameter

                Dim P0 As New SqlParameter("@filter", SqlDbType.Int, 4)
                P0.Value = filter_id
                arParams(0) = P0

                Dim P1 As New SqlParameter("@ref_id", SqlDbType.Int, 4)
                P1.Value = ref_id
                arParams(1) = P1

                Dim P2 As New SqlParameter("@str1", SqlDbType.VarChar, 25)
                P2.Value = string2
                arParams(2) = P2

                Dim P3 As New SqlParameter("@str2", SqlDbType.VarChar, 25)
                P3.Value = string2
                arParams(3) = P3

                Try
                    dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Detail_LoadAll", arParams)
                Catch
                    Err.Raise(Err.Number, "Class:cPurchaseOrder:CPurchaseOrderDetail Routine:GetLoadAll_PO_Detail_List", Err.Description)
                End Try

                Return dr
            End Function

            Public Function GetBillRateMarkup(ByVal emp_code As String, ByVal fnc_code As String, ByVal Client As String, ByVal Division As String, ByVal Product As String, ByVal Job As Integer, ByVal JobComp As Integer) As Decimal
                Dim arParams(23) As SqlParameter
                Dim billable As Integer

                Dim parameterEmp As New SqlParameter("@emp_code", SqlDbType.VarChar, 6)
                parameterEmp.Value = emp_code
                arParams(0) = parameterEmp

                Dim parameterEffDate As New SqlParameter("@eff_date", SqlDbType.DateTime, 0)
                parameterEffDate.Value = Date.Today
                arParams(1) = parameterEffDate

                Dim parameterFnc As New SqlParameter("@fnc_code", SqlDbType.VarChar, 6)
                parameterFnc.Value = fnc_code
                arParams(2) = parameterFnc

                Dim parameterClient As New SqlParameter("@cl_code", SqlDbType.VarChar, 6)
                parameterClient.Value = Client
                arParams(3) = parameterClient

                Dim parameterDiv As New SqlParameter("@div_code", SqlDbType.VarChar, 6)
                parameterDiv.Value = Division
                arParams(4) = parameterDiv

                Dim parameterProd As New SqlParameter("@prd_code", SqlDbType.VarChar, 6)
                parameterProd.Value = Product
                arParams(5) = parameterProd

                Dim parameterSC As New SqlParameter("@sc_code", SqlDbType.VarChar, 6)
                parameterSC.Value = ""
                arParams(6) = parameterSC

                Dim parameterFncType As New SqlParameter("@fnc_type", SqlDbType.VarChar, 1)
                parameterFncType.Value = "V"
                arParams(7) = parameterFncType

                Dim parameterJob As New SqlParameter("@job_number", SqlDbType.Int, 0)
                parameterJob.Value = Job
                arParams(8) = parameterJob

                Dim parameterJobComp As New SqlParameter("@job_component_nbr", SqlDbType.Int, 0)
                parameterJobComp.Value = JobComp
                arParams(9) = parameterJobComp




                '@billing_rate decimal(9,2) OUTPUT
                Dim parameterbillrate As New SqlParameter("@billing_rate", SqlDbType.Decimal, 9)
                parameterbillrate.Direction = ParameterDirection.Output
                arParams(10) = parameterbillrate


                '@rate_level smallint OUTPUT, 
                Dim parameterratelevel As New SqlParameter("@rate_level", SqlDbType.Int, 0)
                parameterratelevel.Direction = ParameterDirection.Output
                arParams(11) = parameterratelevel

                '@tax_code varchar(4) OUTPUT, 
                Dim parametertaxcode As New SqlParameter("@tax_code", SqlDbType.VarChar, 4)
                parametertaxcode.Direction = ParameterDirection.Output
                arParams(12) = parametertaxcode

                '@tax_level smallint OUTPUT, 
                Dim parametertaxlevel As New SqlParameter("@tax_level", SqlDbType.Int, 0)
                parametertaxlevel.Direction = ParameterDirection.Output
                arParams(13) = parametertaxlevel

                '@nobill_flag smallint OUTPUT, 
                Dim parameternobill As New SqlParameter("@nobill_flag", SqlDbType.Int, 0)
                parameternobill.Direction = ParameterDirection.Output
                arParams(14) = parameternobill

                '@nobill_level smallint OUTPUT, 
                Dim parameternobilllevel As New SqlParameter("@nobill_level", SqlDbType.Int, 0)
                parameternobilllevel.Direction = ParameterDirection.Output
                arParams(15) = parameternobilllevel

                '@comm decimal(9,3) OUTPUT, 
                Dim parametercomm As New SqlParameter("@comm", SqlDbType.Float)
                parametercomm.Direction = ParameterDirection.Output
                arParams(16) = parametercomm

                '@comm_level smallint OUTPUT, 
                Dim parametercomm_level As New SqlParameter("@comm_level", SqlDbType.Int, 0)
                parametercomm_level.Direction = ParameterDirection.Output
                arParams(17) = parametercomm_level

                '@tax_comm smallint OUTPUT, 
                Dim parametertax_comm As New SqlParameter("@tax_comm", SqlDbType.Int, 0)
                parametertax_comm.Direction = ParameterDirection.Output
                arParams(18) = parametertax_comm

                '@tax_comm_only smallint OUTPUT, 
                Dim parametertax_comm_only As New SqlParameter("@tax_comm_only", SqlDbType.Int, 0)
                parametertax_comm_only.Direction = ParameterDirection.Output
                arParams(19) = parametertax_comm_only

                '@tax_comm_flags_level smallint OUTPUT, 
                Dim parametertax_comm_flags_level As New SqlParameter("@tax_comm_flags_level", SqlDbType.Int, 0)
                parametertax_comm_flags_level.Direction = ParameterDirection.Output
                arParams(20) = parametertax_comm_flags_level

                '@fee_time_flag smallint OUTPUT, 
                Dim parameterfee_time_flag As New SqlParameter("@fee_time_flag", SqlDbType.Int, 0)
                parameterfee_time_flag.Direction = ParameterDirection.Output
                arParams(21) = parameterfee_time_flag

                '@fee_time_level smallint OUTPUT
                Dim parameterfee_time_level As New SqlParameter("@fee_time_level", SqlDbType.Int, 0)
                parameterfee_time_level.Direction = ParameterDirection.Output
                arParams(22) = parameterfee_time_level


                Try
                    oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "sp_get_billing_rates", arParams)
                Catch
                    Err.Raise(9999, "Class:cJobFunctions Routine:IsJobBillable", Err.Description)
                End Try

                If IsDBNull(parametercomm.Value) Then
                    parametercomm.Value = -1
                End If
                Return parametercomm.Value

            End Function

            Public Function LoadAll_PO_Detail_ListDTable(ByVal filter_id As Integer, ByVal ref_id As Integer, ByVal string1 As String, ByVal string2 As String) As DataTable
                Dim dt As DataTable

                Dim arParams(4) As SqlParameter

                Dim P0 As New SqlParameter("@filter", SqlDbType.Int, 4)
                P0.Value = filter_id
                arParams(0) = P0

                Dim P1 As New SqlParameter("@ref_id", SqlDbType.Int, 4)
                P1.Value = ref_id
                arParams(1) = P1

                Dim P2 As New SqlParameter("@str1", SqlDbType.VarChar, 25)
                P2.Value = string2
                arParams(2) = P2

                Dim P3 As New SqlParameter("@str2", SqlDbType.VarChar, 25)
                P3.Value = string2
                arParams(3) = P3

                Try
                    dt = oSQL.ExecuteDataTable(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Detail_LoadAll", "Details", arParams)
                Catch
                    Err.Raise(Err.Number, "Class:cPurchaseOrder:CPurchaseOrderDetail Routine:GetLoadAll_PO_Detail_ListDTable", Err.Description)
                End Try

                Return dt
            End Function

            Public Function LoadAll_PO_Apprv_Estm_Lines_ByJobComp(ByVal funct_id As Integer, ByVal Job_Number As Integer, ByVal Job_Component_Nbr As Integer, _
            ByVal Fnc_Code As String) As SqlDataReader
                Dim dr As SqlDataReader

                Dim arParams(4) As SqlParameter

                Dim P0 As New SqlParameter("@funct", SqlDbType.Int, 4)
                P0.Value = funct_id
                arParams(0) = P0

                Dim P1 As New SqlParameter("@job_number", SqlDbType.Int, 4)
                P1.Value = Job_Number
                arParams(1) = P1

                Dim P2 As New SqlParameter("@job_component_nbr", SqlDbType.Int, 4)
                P2.Value = Job_Component_Nbr
                arParams(2) = P2

                Dim P3 As New SqlParameter("@fnc_code", SqlDbType.VarChar, 6)
                P3.Value = Fnc_Code
                arParams(3) = P3

                Try
                    dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Estimate_LoadByJobComp", arParams)
                Catch
                    Err.Raise(Err.Number, "Class:cPurchaseOrder:CPurchaseOrderDetail Routine:LoadAll_PO_Apprv_Estm_Lines_ByJobComp", Err.Description)
                End Try

                Return dr
            End Function
            Public Function Select_PODetail_AP_Complete_Dtl(ByVal funct_Id As Integer, ByVal Ref_Id As Integer, ByVal str As String, ByVal Sort As String) As SqlDataReader
                Dim dr As SqlDataReader

                Dim arParams(4) As SqlParameter

                Dim P0 As New SqlParameter("@funct", SqlDbType.Int, 4)
                P0.Value = funct_Id
                arParams(0) = P0

                Dim P1 As New SqlParameter("@ref_id", SqlDbType.Int, 4)
                P1.Value = Ref_Id
                arParams(1) = P1

                Dim P2 As New SqlParameter("@str", SqlDbType.VarChar, 25)
                P2.Value = str
                arParams(2) = P2

                Dim P3 As New SqlParameter("@sort", SqlDbType.VarChar, 6)
                P3.Value = Sort
                arParams(3) = P3

                Try
                    dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_AP_Complete", arParams)
                Catch
                    Err.Raise(Err.Number, "Class:cPurchaseOrder:CPurchaseOrderDetail Routine:Select_PODetail_AP_Complete_Dtl", Err.Description)
                End Try

                Return dr
            End Function
            Public Function Select_PODetail(ByVal funct_id As Integer, ByVal ref_id As Integer, ByVal ref_id2 As Integer) As SqlDataReader
                Try
                    Dim dr As SqlDataReader

                    Dim arParams(2) As SqlParameter

                    Dim P1 As New SqlParameter("@funct_id", SqlDbType.Int, 4)
                    P1.Value = funct_id
                    arParams(0) = P1

                    Dim P2 As New SqlParameter("@ref_id", SqlDbType.Int, 4)
                    P2.Value = ref_id
                    arParams(1) = P2

                    Dim P3 As New SqlParameter("@ref_id2", SqlDbType.Int, 4)
                    P3.Value = ref_id2
                    arParams(2) = P3

                    '   Try
                    dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Detail_LoadByPrimaryKey", arParams)

                    If dr.HasRows = True Then
                        dr.Read()
                        _PO_Number = dr.GetInt32(0)
                        _Ref_ID = ref_id
                        _Line_Number = dr.GetInt32(2)
                        _Line_Desc = dr.GetString(3)
                        _Det_Desc = dr.GetString(4)
                        _Det_Instruct = dr.GetString(5)
                        _Job_Number = dr.GetInt32(6)
                        _Job_Component_Nbr = dr.GetInt16(7)
                        _Fnc_Code = dr.GetString(8)
                        _Fnc_Description = dr.GetString(9)
                        _PO_Rate = dr.GetDecimal(10)
                        _PO_Qty = dr.GetInt32(11)
                        _PO_Ext_Amount = dr.GetDecimal(12)
                        _PO_Comm_Pct = dr.GetDecimal(13)
                        _PO_Ext_Markup_Amt = dr.GetDecimal(14)
                        _Line_Total = dr.GetDecimal(15)
                        _PO_Complete_Flag = CBool(dr.GetInt16(16))
                        _CL_Code = dr.GetString(17)
                        _Div_Code = dr.GetString(18)
                        _Prd_Code = dr.GetString(19)
                        _Attached_To_AP_Flag = CBool(dr.GetInt32(20))
                        _PO_Tax_Pct = dr.GetDecimal(21)
                        If dr.GetInt16(22) = 1 Then
                            _Use_CPM_Flag = True
                        Else
                            _Use_CPM_Flag = False
                        End If
                        If dr.GetInt16(23) = 1 Then
                            _PO_Complete = True
                        Else
                            _PO_Complete = False
                        End If
                        _Vendor_Code = dr.GetString(24)
                        _Job_Type_Code = dr.GetString(25)
                        If dr.GetInt16(26) = 1 Then
                            _PO_Voided = True
                        Else
                            _PO_Voided = False
                        End If
                        _Gla_Code = dr.GetString(27)
                        _Gla_Description = dr.GetString(28)
                    Else

                    End If

                    Return dr
                Catch ex As Exception

                End Try

            End Function
            Public Function Update_PODetail(ByVal ref_id As Integer, ByVal po_number As Integer, ByVal line_number As Integer, _
                 ByVal line_desc As String, ByVal po_qty As Integer, ByVal po_rate As Decimal, ByVal po_tax_pct As Decimal, _
                 ByVal job_number As Integer, ByVal job_component_nbr As Integer, ByVal fnc_code As String, _
                 ByVal po_comm_pct As Decimal, ByVal ext_markup_amt As Decimal, ByVal ext_amount As Decimal, ByVal gla_code As String) As Decimal


                Dim arParams(16) As SqlParameter

                Dim P0 As New SqlParameter("po_ext_amount", SqlDbType.Int)
                P0.Direction = ParameterDirection.Output
                arParams(0) = P0

                Dim P1 As New SqlParameter("@ref_id", SqlDbType.Int, 4)
                P1.Value = ref_id
                arParams(1) = P1

                Dim P2 As New SqlParameter("@po_number", SqlDbType.Int, 4)
                P2.Value = po_number
                arParams(2) = P2

                Dim P3 As New SqlParameter("@line_number", SqlDbType.Int, 4)
                P3.Value = line_number
                arParams(3) = P3

                Dim P4 As New SqlParameter("@line_desc", SqlDbType.VarChar, 40)
                P4.Value = line_desc
                arParams(4) = P4

                Dim P5 As New SqlParameter("@po_qty", SqlDbType.Int, 4)
                P5.Value = po_qty
                arParams(5) = P5

                Dim P6 As New SqlParameter("@po_rate", SqlDbType.Decimal)
                P6.Value = po_rate
                arParams(6) = P6

                Dim P7 As New SqlParameter("@po_tax_pct", SqlDbType.Decimal)
                P7.Value = po_tax_pct
                arParams(7) = P7

                Dim P8 As New SqlParameter("@job_number", SqlDbType.Int, 4)
                P8.Value = job_number
                arParams(8) = P8

                Dim P9 As New SqlParameter("@job_component_nbr", SqlDbType.Int, 4)
                P9.Value = job_component_nbr
                arParams(9) = P9

                Dim P10 As New SqlParameter("@fnc_code", SqlDbType.VarChar, 6)
                P10.Value = fnc_code.Trim
                arParams(10) = P10

                Dim P11 As New SqlParameter("@po_comm_pct", SqlDbType.Decimal)
                P11.Value = po_comm_pct
                arParams(11) = P11

                Dim P12 As New SqlParameter("@ext_markup_amt", SqlDbType.Decimal)
                P12.Value = ext_markup_amt
                arParams(12) = P12

                Dim P13 As New SqlParameter("@ext_amount", SqlDbType.Decimal)
                P13.Value = ext_amount
                arParams(13) = P13

                Dim P14 As New SqlParameter("@gla_code", SqlDbType.VarChar, 30)
                If gla_code = "" Then
                    P14.Value = DBNull.Value
                Else
                    P14.Value = gla_code
                End If
                arParams(14) = P14

                Try
                    oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Update_Detail", arParams)
                    Return arParams(0).Value
                Catch
                    Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:Update_PODetail", Err.Description)
                End Try
            End Function
            Public Function Insert_PODetail(ByVal ref_id As Integer, ByVal po_number As Integer, _
                 ByVal line_desc As String, ByVal po_qty As Integer, ByVal po_rate As Decimal, ByVal po_tax_pct As Decimal, _
                 ByVal job_number As Integer, ByVal job_component_nbr As Integer, ByVal fnc_code As String, _
                 ByVal po_comm_pct As Decimal, ByVal ext_markup_amt As Decimal, ByVal ext_amount As Decimal, ByVal gla_code As String) As Integer

                Dim arParams(14) As SqlParameter

                Dim P0 As New SqlParameter("@new_line_num", SqlDbType.Int)
                P0.Direction = ParameterDirection.Output
                arParams(0) = P0

                Dim P1 As New SqlParameter("@ref_id", SqlDbType.Int, 4)
                P1.Value = ref_id
                arParams(1) = P1

                Dim P2 As New SqlParameter("@po_number", SqlDbType.Int, 4)
                P2.Value = po_number
                arParams(2) = P2

                Dim P3 As New SqlParameter("@line_desc", SqlDbType.VarChar, 40)
                P3.Value = line_desc
                arParams(3) = P3

                Dim P4 As New SqlParameter("@po_qty", SqlDbType.Int, 4)
                P4.Value = po_qty
                arParams(4) = P4

                Dim P5 As New SqlParameter("@po_rate", SqlDbType.Decimal)
                P5.Value = po_rate
                arParams(5) = P5

                Dim P6 As New SqlParameter("@po_tax_pct", SqlDbType.Decimal)
                P6.Value = po_tax_pct
                arParams(6) = P6

                Dim P7 As New SqlParameter("@job_number", SqlDbType.Int, 4)
                P7.Value = job_number
                arParams(7) = P7

                Dim P8 As New SqlParameter("@job_component_nbr", SqlDbType.Int, 4)
                P8.Value = job_component_nbr
                arParams(8) = P8

                Dim P9 As New SqlParameter("@fnc_code", SqlDbType.VarChar, 6)
                P9.IsNullable = True
                P9.Value = fnc_code.Trim
                arParams(9) = P9

                Dim P10 As New SqlParameter("@po_comm_pct", SqlDbType.Decimal)
                P10.Value = po_comm_pct
                arParams(10) = P10

                Dim P11 As New SqlParameter("@ext_markup_amt", SqlDbType.Decimal)
                P11.Value = ext_markup_amt
                arParams(11) = P11

                Dim P12 As New SqlParameter("@ext_amount", SqlDbType.Decimal)
                P12.IsNullable = True
                P12.Value = ext_amount
                arParams(12) = P12

                Dim P13 As New SqlParameter("@gla_code", SqlDbType.VarChar, 30)
                P13.IsNullable = True
                If gla_code = "" Then
                    P13.Value = DBNull.Value
                Else
                    P13.Value = gla_code
                End If
                arParams(13) = P13

                Try
                    oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Insert_Detail", arParams)
                    '     Insert_PODetail = P0.Value
                    Return arParams(0).Value
                Catch
                    Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:Insert_PODetail", Err.Description)
                End Try
            End Function
            Public Function DeletePODetail(ByVal po_number As Integer, ByVal line_number As Integer) As Integer
                Dim arParams(2) As SqlParameter

                Dim P0 As New SqlParameter("@po_number", SqlDbType.Int, 4)
                P0.Value = po_number
                arParams(0) = P0

                Dim P1 As New SqlParameter("@line_number", SqlDbType.Int, 4)
                P1.Value = line_number
                arParams(1) = P1

                Try
                    oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Delete_Detail", arParams)
                    Return 0
                Catch
                    Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:DeletePODetail", Err.Description)
                    Return 1
                End Try

            End Function
            Public Function UpdatePODetailMemoText(ByVal update_column As String, ByVal ref_id As Integer, ByVal ref_id2 As Integer, ByVal stext As String) As Integer
                Dim arParams(3) As SqlParameter

                Dim P0 As New SqlParameter("@update_column", SqlDbType.VarChar, 15)
                P0.Value = update_column.ToString
                arParams(0) = P0

                Dim P1 As New SqlParameter("@ref_id", SqlDbType.Int, 4)
                P1.Value = ref_id
                arParams(1) = P1

                Dim P2 As New SqlParameter("@ref_id2", SqlDbType.Int, 4)
                P2.Value = ref_id2
                arParams(2) = P2

                Dim P3 As New SqlParameter("@text", SqlDbType.VarChar, 9000)
                P3.Value = stext
                arParams(3) = P3

                Try
                    oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Update_Detail_Memos", arParams)
                Catch
                    Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:Update_PODetailMemoText:" + update_column, Err.Description)
                End Try

            End Function

            Public Function GetPODtlInfo(ByVal po_num As Integer) As DataSet
                Dim ds1 As DataSet
                Dim arParams(1) As SqlParameter

                Dim P0 As New SqlParameter("@po_num", SqlDbType.Int, 8)
                P0.Value = po_num
                arParams(0) = P0

                Try
                    ds1 = oSQL.ExecuteDataset(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Detail_Info", arParams)
                Catch ex As Exception
                    Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:GetPODtlInfo, Err.Description")
                End Try
                Return ds1
            End Function
            Public Function GetPOTotal(ByVal PO_Number As Integer) As Decimal
                Dim arParams(2) As SqlParameter

                Dim P0 As New SqlParameter("@po_total", SqlDbType.Decimal)
                P0.Direction = ParameterDirection.Output
                arParams(0) = P0

                Dim P1 As New SqlParameter("@po_number", SqlDbType.Int, 4)
                P1.Value = PO_Number
                arParams(1) = P1

                Try
                    oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_GetPOTotal", arParams)
                    Return arParams(0).Value
                Catch
                    Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:GetPOTotal:", Err.Description)
                End Try

            End Function
            Public Function ValidateDetail(ByVal sJob As String, ByVal sComp As String, ByVal Func_Code As String, ByRef sErrorList As String, ByVal gla_code As String) As Integer
                'validate database constraints for free-format data.
                Dim arParams(10) As SqlParameter

                Dim P0 As New SqlParameter("@msg", SqlDbType.VarChar, 2000)
                P0.Direction = ParameterDirection.Output
                arParams(0) = P0

                Dim P1 As New SqlParameter("@errorcount", SqlDbType.Int, 4)
                P1.Direction = ParameterDirection.Output
                arParams(1) = P1

                Dim P2 As New SqlParameter("@check", SqlDbType.Int, 4)
                P2.Value = 1 'validate PO detail line
                arParams(2) = P2

                Dim P3 As New SqlParameter("@job_number", SqlDbType.VarChar, 25)
                P3.Value = sJob
                arParams(3) = P3

                Dim P4 As New SqlParameter("@component_nbr", SqlDbType.VarChar, 10)
                P4.Value = sComp
                arParams(4) = P4

                Dim P5 As New SqlParameter("@fnc_code", SqlDbType.Char, 6)
                P5.Value = Func_Code
                arParams(5) = P5

                Dim P6 As New SqlParameter("@emp_code", SqlDbType.Char, 6)
                P6.Value = sJob
                arParams(6) = P6

                Dim P7 As New SqlParameter("@vn_code", SqlDbType.Char, 6)
                P7.Value = "" 'not used for this validation
                arParams(7) = P7

                Dim P8 As New SqlParameter("@vc_code", SqlDbType.Char, 4)
                P8.Value = "" 'not used for this validation
                arParams(8) = P8

                Dim P9 As New SqlParameter("@gla_code", SqlDbType.VarChar, 30)
                P9.Value = gla_code
                arParams(9) = P9

                Try
                    oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Validation", arParams)
                    sErrorList = arParams(0).Value 'error description text.
                    Return arParams(1).Value 'return error count
                Catch
                    Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:ValidateDetail", Err.Description)
                End Try

            End Function

            Public Function CheckNonBilliableFNCFlag(ByVal FncCode As String) As Boolean
                Dim arParams(1) As SqlParameter
                Dim i As Integer

                Dim fncParam As New SqlParameter("@fnc_code", SqlDbType.Char, 6)
                fncParam.Value = FncCode
                arParams(0) = fncParam


                Try
                    i = oSQL.ExecuteScalar(_ConnectionString, CommandType.StoredProcedure, "usp_wv_fnc_NonBillableFlag", arParams)
                    If i = 1 Then
                        Return True
                    Else
                        Return False
                    End If

                Catch
                    Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:CheckNonBilliableFNCFlag:", Err.Description)
                End Try

            End Function

            Public Function CheckNonBilliableFlag(ByVal JobNumber As Integer, ByVal JobCompNumber As Integer) As Boolean
                Dim arParams(2) As SqlParameter
                Dim i As Integer

                Dim JobNumberParam As New SqlParameter("@JobNumber", SqlDbType.Int)
                JobNumberParam.Value = JobNumber
                arParams(0) = JobNumberParam

                Dim JobCompNumberParam As New SqlParameter("@JobCompNumber", SqlDbType.Int)
                JobCompNumberParam.Value = JobCompNumber
                arParams(1) = JobCompNumberParam

                Try
                    i = oSQL.ExecuteScalar(_ConnectionString, CommandType.StoredProcedure, "usp_wv_job_NonBillableFlag", arParams)
                    If i = 1 Then
                        Return True
                    Else
                        Return False
                    End If

                Catch
                    Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:CheckNonBilliableFlag:", Err.Description)
                End Try

            End Function

            Public Function GetFunctionInfo(ByVal Func_Code As String, ByVal PO_Number As Integer, ByVal Qty As Integer, _
                   ByRef Func_Description As String, ByRef UseCPMFlag As Boolean, ByRef CPMQty As Integer, ByRef Func_PO_Total As Decimal, _
                   ByRef Glacode As String, ByRef Gladesc As String) As Integer
                'get function description, CPM flag/CPM generated Qty, Total on PO for selected Funct Code...
                Dim arParams(10) As SqlParameter

                Dim P0 As New SqlParameter("@desc", SqlDbType.VarChar, 100)
                P0.Direction = ParameterDirection.Output
                arParams(0) = P0

                Dim P1 As New SqlParameter("@use_cpm", SqlDbType.Int, 2)
                P1.Direction = ParameterDirection.Output
                arParams(1) = P1

                Dim P3 As New SqlParameter("@cpmqty", SqlDbType.Int, 4)
                P3.Direction = ParameterDirection.Output
                arParams(2) = P3

                Dim P4 As New SqlParameter("@funct_po_total", SqlDbType.Decimal)
                P4.Direction = ParameterDirection.Output
                arParams(3) = P4

                Dim P5 As New SqlParameter("@funct", SqlDbType.Int, 4)
                P5.Value = 1
                arParams(4) = P5

                Dim P6 As New SqlParameter("@po_number", SqlDbType.Int, 4)
                P6.Value = PO_Number
                arParams(5) = P6

                Dim P7 As New SqlParameter("@func_code", SqlDbType.Char, 6)
                P7.Value = Func_Code
                arParams(6) = P7

                Dim P8 As New SqlParameter("@qty", SqlDbType.Int, 4)
                P8.Value = Qty
                arParams(7) = P8

                Dim P9 As New SqlParameter("@glacode", SqlDbType.VarChar, 30)
                P9.Direction = ParameterDirection.Output
                arParams(8) = P9

                Dim P10 As New SqlParameter("@gladesc", SqlDbType.VarChar, 75)
                P10.Direction = ParameterDirection.Output
                arParams(9) = P10

                Try
                    oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_GetFunctDescCPM", arParams)
                    Func_Description = arParams(0).Value
                    If arParams(1).Value = 1 Then
                        UseCPMFlag = True
                    Else
                        UseCPMFlag = False
                    End If
                    CPMQty = arParams(2).Value
                    Func_PO_Total = arParams(3).Value
                    Glacode = arParams(8).Value
                    Gladesc = arParams(9).Value
                    Return 0
                Catch
                    Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:proc_WV_PO_GetFunctDescCPM", Err.Description)
                    Return 1
                End Try

            End Function
            Public Function Select_PODetailsDS(ByVal po_number As Integer, ByVal optionstr As String, ByVal PrintOps As String, ByVal LocationID As String) As DataSet
                Dim ds1 As New DataSet
                Dim arParams(4) As SqlParameter

                Dim P0 As New SqlParameter("@ref_id", SqlDbType.Int, 4)
                P0.Value = po_number
                arParams(0) = P0

                Dim P1 As New SqlParameter("@userid", SqlDbType.VarChar, 100)
                P1.Value = optionstr
                arParams(1) = P1

                Dim P2 As New SqlParameter("@ops", SqlDbType.VarChar, 200)
                P2.Value = PrintOps
                arParams(2) = P2

                Dim P3 As New SqlParameter("@LocationID", SqlDbType.VarChar, 6)
                P3.Value = LocationID
                arParams(3) = P3

                Try
                    ds1 = oSQL.ExecuteDataset(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Detail_LoadReportInfo_Ops", arParams)
                Catch
                    Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:Select_POHeaderDTable", Err.Description)
                End Try

                Return ds1

            End Function
            Public Function CheckJobEstimateAmount(ByVal funct_id As Integer, ByVal job_number As Integer, ByVal job_comp_nbr As Integer, ByVal ref_Id As Integer, ByVal fnc_code As String, ByRef estimate_info As String, ByRef Used_Amt As Decimal, ByVal line_num As Integer) As Decimal
                Dim arParams(11) As SqlParameter

                Dim P0 As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
                P0.Direction = ParameterDirection.ReturnValue
                arParams(0) = P0

                Dim P1 As New SqlParameter("@est_info", SqlDbType.VarChar, 100)
                P1.Direction = ParameterDirection.Output
                arParams(1) = P1

                Dim P2 As New SqlParameter("@amt_approved", SqlDbType.Decimal)
                P2.IsNullable = True
                P2.Direction = ParameterDirection.Output
                P2.Precision = 15
                P2.Scale = 2
                arParams(2) = P2

                Dim P3 As New SqlParameter("@approved", SqlDbType.SmallInt)
                P3.Direction = ParameterDirection.Output
                arParams(3) = P3

                Dim P4 As New SqlParameter("@used_amt", SqlDbType.Decimal)
                P4.Direction = ParameterDirection.Output
                P4.Precision = 15
                P4.Scale = 2
                arParams(4) = P4

                Dim P5 As New SqlParameter("@funct", SqlDbType.Int, 4)
                P5.Value = funct_id
                arParams(5) = P5

                Dim P6 As New SqlParameter("@job_number", SqlDbType.Int, 4)
                P6.Value = job_number
                arParams(6) = P6

                Dim P7 As New SqlParameter("@job_component_nbr", SqlDbType.Int, 4)
                P7.Value = job_comp_nbr
                arParams(7) = P7

                Dim P8 As New SqlParameter("@ref_id", SqlDbType.Int, 4)
                P8.Value = ref_Id
                arParams(8) = P8

                Dim P9 As New SqlParameter("@fnc_code", SqlDbType.Char, 6)
                P9.Value = fnc_code
                arParams(9) = P9

                Dim P10 As New SqlParameter("@line_num", SqlDbType.Int, 4)
                P10.Value = line_num
                arParams(10) = P10

                Try
                    oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_CheckJobEstimate", arParams)
                    estimate_info = P1.Value.ToString
                    Used_Amt = P4.Value

                    If Not arParams(2).Value Is Nothing Then
                        Return P2.Value
                    Else
                        Return 0
                    End If

                Catch
                    Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:CheckJobEstimateAmount", Err.Description)
                    Return 0
                End Try
            End Function
            Public Function CheckJobEstimateExists(ByVal job_number As Integer, ByVal job_comp As Integer, ByRef estimate_info As String) As Integer
                Dim arParams(11) As SqlParameter

                Dim P0 As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
                P0.Direction = ParameterDirection.ReturnValue
                arParams(0) = P0

                Dim P1 As New SqlParameter("@est_info", SqlDbType.VarChar, 100)
                P1.Direction = ParameterDirection.Output
                arParams(1) = P1

                Dim P2 As New SqlParameter("@amt_approved", SqlDbType.Decimal)
                P2.Direction = ParameterDirection.Output
                arParams(2) = P2

                Dim P3 As New SqlParameter("@approved", SqlDbType.SmallInt)
                P3.Direction = ParameterDirection.Output
                arParams(3) = P3

                Dim P4 As New SqlParameter("@used_amt", SqlDbType.Decimal)
                P4.IsNullable = True
                P4.Direction = ParameterDirection.Output
                arParams(4) = P4

                Dim P5 As New SqlParameter("@funct", SqlDbType.Int, 4)
                P5.Value = 2
                arParams(5) = P5

                Dim P6 As New SqlParameter("@job_number", SqlDbType.Int, 4)
                P6.Value = job_number
                arParams(6) = P6

                Dim P7 As New SqlParameter("@job_component_nbr", SqlDbType.Int, 4)
                P7.Value = job_comp
                arParams(7) = P7

                Dim P8 As New SqlParameter("@ref_id", SqlDbType.Int, 4)
                P8.Value = 0
                arParams(8) = P8

                Dim P9 As New SqlParameter("@fnc_code", SqlDbType.Char, 6)
                P9.Value = ""
                arParams(9) = P9

                Dim P10 As New SqlParameter("@line_num", SqlDbType.Int, 4)
                P10.Value = 0
                arParams(10) = P10

                Try
                    oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_CheckJobEstimate", arParams)
                    estimate_info = P1.Value.ToString
                    Return arParams(0).Value
                Catch
                    Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:CheckJobEstimateExists", Err.Description)
                    Return 0
                End Try
            End Function

            Public Function LoadAll_PO_Detail_PO_AP_Transactions(ByVal Funct_Id As Integer, ByVal Ref_id As Integer, ByVal Ref_id2 As Integer, ByVal Str1 As String) As SqlDataReader
                Dim dr As SqlDataReader

                Dim arParams(4) As SqlParameter

                Dim P0 As New SqlParameter("@funct", SqlDbType.Int, 4)
                P0.Value = Funct_Id
                arParams(0) = P0

                Dim P1 As New SqlParameter("@ref_id", SqlDbType.Int, 4)
                P1.Value = Ref_id
                arParams(1) = P1

                Dim P2 As New SqlParameter("@ref_id2", SqlDbType.Int, 4)
                P2.Value = Ref_id2
                arParams(2) = P2

                Dim P3 As New SqlParameter("@str", SqlDbType.VarChar, 25)
                P3.Value = Str1
                arParams(3) = P3

                Try
                    dr = oSQL.ExecuteReader(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Transactions_LoadAll", arParams)
                Catch
                    Err.Raise(Err.Number, "Class:cPurchaseOrder:CPurchaseOrderDetail Routine:LoadAll_PO_Detail_Transactions", Err.Description)
                End Try

                Return dr
            End Function

            Public Function GetPOGLAccountSelection(ByVal empcode As String)
                Dim arParams(1) As SqlParameter
                Dim gl As Integer

                Dim P1 As New SqlParameter("@EmpCode", SqlDbType.VarChar)
                P1.Value = empcode
                arParams(0) = P1

                Try
                    gl = oSQL.ExecuteScalar(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_GetPOGLSelectionFlag", arParams)
                    Return gl
                Catch
                    Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:GetPOGLAccountSelection", Err.Description)
                End Try

            End Function

            Public Function CheckPOGLLimitOffice(ByVal empcode As String, ByVal glacode As String)
                Dim arParams(2) As SqlParameter
                Dim gl As Integer

                Dim P1 As New SqlParameter("@EmpCode", SqlDbType.VarChar)
                P1.Value = empcode
                arParams(0) = P1

                Dim P2 As New SqlParameter("@GlaCode", SqlDbType.VarChar)
                P2.Value = glacode
                arParams(1) = P2

                Try
                    gl = oSQL.ExecuteScalar(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_CheckPOGLLimitByOffice", arParams)
                    If gl = 1 Then
                        Return True
                    Else
                        Return False
                    End If

                Catch
                    Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:CheckPOGLLimitByOffice", Err.Description)
                End Try

            End Function
            Public Function DeletePOApproval(ByVal po_number As Integer) As Integer
                Dim arParams(2) As SqlParameter

                Dim P0 As New SqlParameter("@po_number", SqlDbType.Int, 4)
                P0.Value = po_number
                arParams(0) = P0

                Try
                    oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "proc_WV_PO_Delete_Approval", arParams)
                    Return 0
                Catch
                    Err.Raise(Err.Number, "Class:cPurchaseOrder Routine:DeletePOApproval", Err.Description)
                    Return 1
                End Try

            End Function

#End Region
        End Class


    End Class

End Namespace







