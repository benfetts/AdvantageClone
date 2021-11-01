Namespace Vendor

    Public Class VendorHistoryReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""
        Private _PayToVendor As AdvantageFramework.Database.Entities.Vendor = Nothing
        Private _AlternatePayToVendor As Boolean = False
        Private _PayToVendorTested As Boolean = False
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

#End Region

#Region " Methods "

        Private Function LoadCurrentVendorHistory() As AdvantageFramework.Database.Entities.VendorHistory

            Try

                LoadCurrentVendorHistory = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.VendorHistory)

            Catch ex As Exception
                LoadCurrentVendorHistory = Nothing
            End Try

        End Function
        Private Sub LoadPayToVendor()

            'objects
            Dim VendorHistory As AdvantageFramework.Database.Entities.VendorHistory = Nothing

            If _PayToVendorTested = False Then

                _PayToVendor = Nothing
                _AlternatePayToVendor = False

                Try

                    VendorHistory = LoadCurrentVendorHistory()

                    If VendorHistory.Code <> VendorHistory.PayToCode Then

                        _AlternatePayToVendor = True

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            _PayToVendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorHistory.PayToCode)

                        End Using

                    End If

                Catch ex As Exception
                    _AlternatePayToVendor = False
                    _PayToVendor = Nothing
                End Try

                _PayToVendorTested = True

            End If

        End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub VendorHistoryReport_DataSourceRowChanged(sender As Object, e As DevExpress.XtraReports.UI.DataSourceRowEventArgs) Handles Me.DataSourceRowChanged

            _PayToVendorTested = False

        End Sub
        Private Sub VendorHistoryReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub
        Private Sub PageFooter_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_DateAndUserCode.Text = _Date & vbTab & _Session.UserCode

        End Sub
        Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_Agency.Text = _AgencyName

        End Sub
        Private Sub Label_VendorCategory_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_VendorCategory.BeforePrint

            'objects
            Dim VendorHistory As AdvantageFramework.Database.Entities.VendorHistory = Nothing
            Dim Category As String = ""

            Try

                VendorHistory = LoadCurrentVendorHistory()

                If VendorHistory IsNot Nothing Then

                    Category = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.VendorCategory)).ToList
                                Where EnumObject.Code.ToUpper = VendorHistory.VendorCategory.ToUpper
                                Select EnumObject.Description).SingleOrDefault

                End If

            Catch ex As Exception
                Category = ""
            Finally
                Label_VendorCategory.Text = Category
            End Try

        End Sub
        Private Sub CheckBox_Active_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles CheckBox_Active.BeforePrint

            'objects
            Dim VendorHistory As AdvantageFramework.Database.Entities.VendorHistory = Nothing
            Dim Checked As Boolean = False

            Try

                VendorHistory = LoadCurrentVendorHistory()

                If VendorHistory IsNot Nothing Then

                    Checked = Convert.ToBoolean(VendorHistory.ActiveFlag.GetValueOrDefault(0))

                End If

            Catch ex As Exception
                Checked = ""
            Finally
                CheckBox_Active.Checked = Checked
            End Try

        End Sub
        Private Sub Label_PayToCode_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_PayToCode.BeforePrint

            'objects
            Dim VendorHistory As AdvantageFramework.Database.Entities.VendorHistory = Nothing

            LoadPayToVendor()

            VendorHistory = LoadCurrentVendorHistory()

            Label_PayToCode.Text = VendorHistory.PayToCode

        End Sub
        Private Sub Label_PayToName_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_PayToName.BeforePrint

            'objects
            Dim VendorHistory As AdvantageFramework.Database.Entities.VendorHistory = Nothing
            Dim PayToName As String = ""

            Try

                LoadPayToVendor()

                If _AlternatePayToVendor Then

                    PayToName = _PayToVendor.Name

                Else

                    VendorHistory = LoadCurrentVendorHistory()

                    PayToName = VendorHistory.PayToName

                End If

            Catch ex As Exception
                PayToName = ""
            Finally
                Label_PayToName.Text = PayToName
            End Try

        End Sub
        Private Sub Label_PayToAddress1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_PayToAddress1.BeforePrint

            'objects
            Dim VendorHistory As AdvantageFramework.Database.Entities.VendorHistory = Nothing
            Dim PayToAddress1 As String = ""

            Try

                LoadPayToVendor()

                If _AlternatePayToVendor Then

                    PayToAddress1 = _PayToVendor.StreetAddressLine1

                Else

                    VendorHistory = LoadCurrentVendorHistory()

                    PayToAddress1 = VendorHistory.PayToAddress1

                End If

            Catch ex As Exception
                PayToAddress1 = ""
            Finally
                Label_PayToAddress1.Text = PayToAddress1
            End Try

        End Sub
        Private Sub Label_PayToAddress2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_PayToAddress2.BeforePrint

            'objects
            Dim VendorHistory As AdvantageFramework.Database.Entities.VendorHistory = Nothing
            Dim PayToAddressLine2 As String = ""

            Try

                LoadPayToVendor()

                If _AlternatePayToVendor Then

                    PayToAddressLine2 = _PayToVendor.StreetAddressLine2

                Else

                    VendorHistory = LoadCurrentVendorHistory()

                    PayToAddressLine2 = VendorHistory.PayToAddress2

                End If

            Catch ex As Exception
                PayToAddressLine2 = ""
            Finally
                Label_PayToAddress2.Text = PayToAddressLine2
            End Try

        End Sub
        Private Sub Label_PayToAddress3_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_PayToAddress3.BeforePrint

            'objects
            Dim VendorHistory As AdvantageFramework.Database.Entities.VendorHistory = Nothing
            Dim PayToStreetAddressLine3 As String = ""

            Try

                LoadPayToVendor()

                If _AlternatePayToVendor Then

                    PayToStreetAddressLine3 = _PayToVendor.StreetAddressLine3

                Else

                    VendorHistory = LoadCurrentVendorHistory()

                    PayToStreetAddressLine3 = VendorHistory.PayToAddress3

                End If

            Catch ex As Exception
                PayToStreetAddressLine3 = ""
            Finally
                Label_PayToAddress3.Text = PayToStreetAddressLine3
            End Try

        End Sub
        Private Sub Label_PayToCounty_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_PayToCounty.BeforePrint

            'objects
            Dim VendorHistory As AdvantageFramework.Database.Entities.VendorHistory = Nothing
            Dim PayToCounty As String = ""

            Try

                LoadPayToVendor()

                If _AlternatePayToVendor Then

                    PayToCounty = _PayToVendor.County

                Else

                    VendorHistory = LoadCurrentVendorHistory()

                    PayToCounty = VendorHistory.PayToCounty

                End If

            Catch ex As Exception
                PayToCounty = ""
            Finally
                Label_PayToCounty.Text = PayToCounty
            End Try

        End Sub
        Private Sub Label_PayToCountry_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_PayToCountry.BeforePrint

            'objects
            Dim VendorHistory As AdvantageFramework.Database.Entities.VendorHistory = Nothing
            Dim PayToCountry As String = ""

            Try

                LoadPayToVendor()

                If _AlternatePayToVendor Then

                    PayToCountry = _PayToVendor.Country

                Else

                    VendorHistory = LoadCurrentVendorHistory()

                    PayToCountry = VendorHistory.PayToCountry

                End If

            Catch ex As Exception
                PayToCountry = ""
            Finally
                Label_PayToCountry.Text = PayToCountry
            End Try

        End Sub
        Private Sub Label_PayToCity_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_PayToCity.BeforePrint

            'objects
            Dim VendorHistory As AdvantageFramework.Database.Entities.VendorHistory = Nothing
            Dim PayToCity As String = ""

            Try

                LoadPayToVendor()

                If _AlternatePayToVendor Then

                    PayToCity = _PayToVendor.City

                Else

                    VendorHistory = LoadCurrentVendorHistory()

                    PayToCity = VendorHistory.PayToCity

                End If

            Catch ex As Exception
                PayToCity = ""
            Finally
                Label_PayToCity.Text = PayToCity
            End Try

        End Sub
        Private Sub Label_PayToState_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_PayToState.BeforePrint

            'objects
            Dim VendorHistory As AdvantageFramework.Database.Entities.VendorHistory = Nothing
            Dim PayToState As String = ""

            Try

                LoadPayToVendor()

                If _AlternatePayToVendor Then

                    PayToState = _PayToVendor.State

                Else

                    VendorHistory = LoadCurrentVendorHistory()

                    PayToState = VendorHistory.PayToState

                End If

            Catch ex As Exception
                PayToState = ""
            Finally
                Label_PayToState.Text = PayToState
            End Try

        End Sub
        Private Sub Label_PayToZip_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_PayToZip.BeforePrint

            'objects
            Dim VendorHistory As AdvantageFramework.Database.Entities.VendorHistory = Nothing
            Dim PayToZip As String = ""

            Try

                LoadPayToVendor()

                If _AlternatePayToVendor Then

                    PayToZip = _PayToVendor.ZipCode

                Else

                    VendorHistory = LoadCurrentVendorHistory()

                    PayToZip = VendorHistory.PayToZip

                End If

            Catch ex As Exception
                PayToZip = ""
            Finally
                Label_PayToZip.Text = PayToZip
            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace
