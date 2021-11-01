Namespace Vendor

    Public Class VendorContactsSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "


#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Function LoadCurrentVendorContact() As AdvantageFramework.Database.Entities.VendorContact

            'objects
            Dim VendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing

            Try

                VendorContact = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.VendorContact)

            Catch ex As Exception
                VendorContact = Nothing
            Finally
                LoadCurrentVendorContact = VendorContact
            End Try

        End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        

#End Region

#End Region

        Private Sub CheckBox_Inactive_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles CheckBox_Inactive.BeforePrint

            'objects
            Dim Checked As Boolean = False
            Dim VendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing

            Try

                VendorContact = LoadCurrentVendorContact()

                If VendorContact IsNot Nothing Then

                    Checked = Convert.ToBoolean(VendorContact.IsInactive.GetValueOrDefault(0))

                End If

            Catch ex As Exception
                Checked = False
            Finally
                CheckBox_Inactive.Checked = Checked
            End Try

        End Sub
        Private Sub Label_Name_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_Name.BeforePrint

            'objects
            Dim VendorContactName As String = ""
            Dim VendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing

            Try

                VendorContact = LoadCurrentVendorContact()

                If VendorContact IsNot Nothing Then

                    If String.IsNullOrEmpty(VendorContact.MiddleInitial) = False Then

                        VendorContactName = VendorContact.FirstName & " " & VendorContact.MiddleInitial & " " & VendorContact.LastName

                    Else

                        VendorContactName = VendorContact.FirstName & " " & VendorContact.LastName

                    End If

                End If

            Catch ex As Exception
                VendorContactName = ""
            Finally
                Label_Name.Text = VendorContactName
            End Try

        End Sub
        Private Sub Label_CityStateZip_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_CityStateZip.BeforePrint

            'objects
            Dim CityStateZip As String = ""
            Dim VendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing

            Try

                VendorContact = LoadCurrentVendorContact()

                If VendorContact IsNot Nothing Then

                    CityStateZip = VendorContact.City & ", " & VendorContact.State & "  " & VendorContact.Zip

                End If

            Catch ex As Exception
                CityStateZip = ""
            Finally
                Label_CityStateZip.Text = CityStateZip
            End Try

        End Sub

    End Class

End Namespace
