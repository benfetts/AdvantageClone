Namespace Vendor

    Public Class VendorSummaryListReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""
        Private _SortedBy As String = ""
        Private _Date As String = String.Empty

#End Region

#Region " Properties "

        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property AgencyName As String
            Set(value As String)
                _AgencyName = value
            End Set
        End Property
        Public WriteOnly Property SortedBy As String
            Set(value As String)
                _SortedBy = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Function LoadCurrentVendor() As AdvantageFramework.Database.Entities.Vendor

            Try

                LoadCurrentVendor = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Vendor)

            Catch ex As Exception
                LoadCurrentVendor = Nothing
            End Try

        End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub VendorSummaryListReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub
        Private Sub PageFooter_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_DateAndUserCode.Text = _Date & vbTab & _Session.UserCode

        End Sub
        Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_Agency.Text = _AgencyName

        End Sub
        Private Sub LabelHeader_SortedBy_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelHeader_SortedBy.BeforePrint

            LabelHeader_SortedBy.Text = _SortedBy

        End Sub
        Private Sub Label_Address_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_Address.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Address As Generic.List(Of String) = Nothing

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Address = New Generic.List(Of String)

                    If String.IsNullOrEmpty(Vendor.StreetAddressLine1) = False Then

                        Address.Add(Vendor.StreetAddressLine1)

                    End If

                    If String.IsNullOrEmpty(Vendor.StreetAddressLine2) = False Then

                        Address.Add(Vendor.StreetAddressLine2)

                    End If

                    If String.IsNullOrEmpty(Vendor.StreetAddressLine3) = False Then

                        Address.Add(Vendor.StreetAddressLine3)

                    End If

                End If

            Catch ex As Exception
                Address = Nothing
            Finally

                If Address IsNot Nothing Then

                    Label_Address.Lines = Address.ToArray

                Else

                    Label_Address.Text = ""

                End If

            End Try

        End Sub
        Private Sub Label_PhoneAndExt_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_PhoneAndExt.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim PhoneList As Generic.List(Of String) = Nothing

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    PhoneList = New Generic.List(Of String)

                    If String.IsNullOrEmpty(Vendor.PhoneNumberExtension) = False Then

                        PhoneList.Add(String.Format("{0} EXT: {1}", Vendor.PhoneNumber, Vendor.PhoneNumberExtension))

                    Else

                        PhoneList.Add(Vendor.PhoneNumber)

                    End If

                    If String.IsNullOrEmpty(Vendor.FaxPhoneNumberExtension) = False Then

                        PhoneList.Add(String.Format("{0} EXT: {1}", Vendor.FaxPhoneNumber, Vendor.FaxPhoneNumberExtension))

                    Else

                        PhoneList.Add(Vendor.FaxPhoneNumber)

                    End If

                End If

            Catch ex As Exception
                PhoneList = Nothing
            Finally

                If PhoneList IsNot Nothing Then

                    Label_PhoneAndExt.Lines = PhoneList.ToArray

                Else

                    Label_PhoneAndExt.Text = ""

                End If

            End Try

        End Sub
        Private Sub Label_1099_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_1099.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Is1099 As String = "No"

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Is1099 = If(Vendor.Vendor1099Flag.GetValueOrDefault(0) = 0, "No", "Yes")

                End If

            Catch ex As Exception
                Is1099 = "No"
            Finally
                Label_1099.Text = Is1099
            End Try

        End Sub
        Private Sub Label_Active_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_Active.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim IsActive As String = "No"

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    IsActive = If(Vendor.ActiveFlag.GetValueOrDefault(0) = 0, "No", "Yes")

                End If

            Catch ex As Exception
                IsActive = "No"
            Finally
                Label_Active.Text = IsActive
            End Try

        End Sub
        Private Sub Label_LastPaid_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_LastPaid.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim LastPaid As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        LastPaid = (From Entity In AdvantageFramework.Database.Procedures.CheckRegister.Load(DbContext)
                                    Where Entity.PayToVenderCode = Vendor.Code
                                    Select Entity.CheckDate).Max.ToShortDateString

                    End Using

                End If

            Catch ex As Exception
                LastPaid = ""
            Finally
                Label_LastPaid.Text = LastPaid
            End Try

        End Sub
        Private Sub Label_Category_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_Category.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Category As String = ""

            Try

                If _SortedBy.ToUpper.Contains("CATEGORY") Then

                    Label_Category.Visible = True

                    Vendor = LoadCurrentVendor()

                    If Vendor IsNot Nothing Then

                        Category = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.VendorCategory)).ToList
                                    Where EnumObject.Code.ToUpper = Vendor.VendorCategory.ToUpper
                                    Select EnumObject.Description).SingleOrDefault

                    End If

                Else

                    Label_Category.Visible = False

                End If

            Catch ex As Exception
                Category = ""
            Finally
                Label_Category.Text = Category
            End Try

        End Sub
        Private Sub LabelDetail_Category_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelDetail_Category.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Category As String = ""

            Try

                If _SortedBy.ToUpper.Contains("CATEGORY") Then

                    LabelDetail_Category.Visible = True

                Else

                    LabelDetail_Category.Visible = False

                End If

            Catch ex As Exception

            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace
