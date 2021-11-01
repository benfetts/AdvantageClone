Namespace Vendor

    Public Class VendorRepresentativesSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "


#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Function LoadCurrentVendorRepresentative() As AdvantageFramework.Database.Entities.VendorRepresentative

            'objects
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing

            Try

                VendorRepresentative = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.VendorRepresentative)

            Catch ex As Exception
                VendorRepresentative = Nothing
            Finally
                LoadCurrentVendorRepresentative = VendorRepresentative
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
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing

            Try

                VendorRepresentative = LoadCurrentVendorRepresentative()

                If VendorRepresentative IsNot Nothing Then

                    Checked = Convert.ToBoolean(VendorRepresentative.IsInactive.GetValueOrDefault(0))

                End If

            Catch ex As Exception
                Checked = False
            Finally
                CheckBox_Inactive.Checked = Checked
            End Try

        End Sub
        Private Sub Label_Name_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_Name.BeforePrint

            'objects
            Dim VendorRepresentativeName As String = ""
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing

            Try

                VendorRepresentative = LoadCurrentVendorRepresentative()

                If VendorRepresentative IsNot Nothing Then

                    If String.IsNullOrEmpty(VendorRepresentative.MiddleInitial) = False Then

                        VendorRepresentativeName = VendorRepresentative.FirstName & " " & VendorRepresentative.MiddleInitial & " " & VendorRepresentative.LastName

                    Else

                        VendorRepresentativeName = VendorRepresentative.FirstName & " " & VendorRepresentative.LastName

                    End If

                End If

            Catch ex As Exception
                VendorRepresentativeName = ""
            Finally
                Label_Name.Text = VendorRepresentativeName
            End Try

        End Sub
        Private Sub Label_CityStateZip_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_CityStateZip.BeforePrint

            'objects
            Dim CityStateZip As String = ""
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing

            Try

                VendorRepresentative = LoadCurrentVendorRepresentative()

                If VendorRepresentative IsNot Nothing Then

                    CityStateZip = VendorRepresentative.City & ", " & VendorRepresentative.State & "  " & VendorRepresentative.Zip

                End If

            Catch ex As Exception
                CityStateZip = ""
            Finally
                Label_CityStateZip.Text = CityStateZip
            End Try

        End Sub

    End Class

End Namespace
