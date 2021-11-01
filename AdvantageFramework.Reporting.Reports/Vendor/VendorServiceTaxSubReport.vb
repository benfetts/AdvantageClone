Namespace Vendor

    Public Class VendorServiceTaxSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _VendorServiceTaxList As Generic.List(Of AdvantageFramework.Database.Entities.VendorServiceTax) = Nothing

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

#End Region

#Region " Methods "

        Private Function LoadCurrentVendor() As AdvantageFramework.Database.Entities.Vendor

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            Try

                Vendor = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Vendor)

            Catch ex As Exception
                Vendor = Nothing
            Finally
                LoadCurrentVendor = Vendor
            End Try

        End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub VendorServiceTaxSubReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            Using DataContext As New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                _VendorServiceTaxList = AdvantageFramework.Database.Procedures.VendorServiceTax.Load(DataContext).ToList

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

        Private Sub CheckBox_Enabled_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles CheckBox_Enabled.BeforePrint

            'objects
            Dim Checked As Boolean = False
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Checked = Convert.ToBoolean(Vendor.ServiceTaxEnabled.GetValueOrDefault(False))

                End If

            Catch ex As Exception
                Checked = False
            Finally
                CheckBox_Enabled.Checked = Checked
            End Try

        End Sub
        Private Sub CheckBox_Waiver_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBox_Waiver.BeforePrint

            'objects
            Dim Checked As Boolean = False
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Checked = Convert.ToBoolean(Vendor.ServiceTaxWaiver.GetValueOrDefault(False))

                End If

            Catch ex As Exception
                Checked = False
            Finally
                CheckBox_Waiver.Checked = Checked
            End Try

        End Sub
        Private Sub Label_ServiceTaxCode_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_ServiceTaxCode.BeforePrint

            'objects
            Dim ServiceTaxCode As String = ""
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorServiceTax As AdvantageFramework.Database.Entities.VendorServiceTax = Nothing

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing AndAlso Vendor.VendorServiceTaxID.HasValue Then

                    VendorServiceTax = _VendorServiceTaxList.Where(Function(VST) VST.ID = Vendor.VendorServiceTaxID.Value).FirstOrDefault()

                    If VendorServiceTax IsNot Nothing Then

                        ServiceTaxCode = VendorServiceTax.Code

                    End If

                End If

            Catch ex As Exception
                ServiceTaxCode = ""
            Finally
                Label_ServiceTaxCode.Text = ServiceTaxCode
            End Try

        End Sub
        Private Sub Label_ServiceTaxType_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_ServiceTaxType.BeforePrint

            'objects
            Dim ServiceTaxType As String = ""
            Dim EnumObjectAttribute As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing AndAlso Vendor.ServiceTaxType.HasValue Then

                    EnumObjectAttribute = AdvantageFramework.EnumUtilities.LoadEnumObject(GetType(AdvantageFramework.Database.Entities.VendorServiceTaxType), Vendor.ServiceTaxType.ToString)

                    If EnumObjectAttribute IsNot Nothing Then

                        ServiceTaxType = EnumObjectAttribute.Description

                    End If

                End If

            Catch ex As Exception
                ServiceTaxType = ""
            Finally
                Label_ServiceTaxType.Text = ServiceTaxType
            End Try

        End Sub

    End Class

End Namespace
