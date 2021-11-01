Namespace Templates

    Public Class AdvantageAPIforMedia

#Region " Enum "

        Public Enum ApiMethods
            CheckForValidSettings
            LoadBanks
            LoadClients
            LoadDivisions
            LoadProducts
            LoadVCCStatuses
            LoadVendorCategories
            LoadVendorContacts
            LoadVendorRepresentatives
            LoadVendorTerms
            LoadMediaOrders
            LoadMediaOrderStatuses
            LoadMarkets
            LoadCampaigns
            LoadVendors
            SaveMarket
            SaveVendor
            SaveVendorContact
            SaveVendorRepresentative
            UpdateMediaOrderStatus
            UpdateMatCompDate
            UpdateMaterialNotes
        End Enum

#End Region

#Region " Properties "

        Public Property NoBank As Boolean

#End Region

#Region " Methods "

        Private Function GetDocumentationMethods() As Reflection.MethodInfo()

            If Me.NoBank = True Then

                Return GetType(APIService).GetMethods().Where(Function(m) [Enum].GetNames(GetType(ApiMethods)).Contains(m.Name) AndAlso m.Name <> ApiMethods.LoadBanks.ToString).OrderBy(Function(m) m.Name).ToArray

            Else

                Return GetType(APIService).GetMethods().Where(Function(m) [Enum].GetNames(GetType(ApiMethods)).Contains(m.Name)).OrderBy(Function(m) m.Name).ToArray

            End If

        End Function
        Private Function GetFriendlyTypeName(ByVal Type As System.Type) As String

            If Type = GetType(Int32) OrElse Type = GetType(Integer) OrElse Type = GetType(Int32?) OrElse Type = GetType(Integer?) Then

                Return "Integer"

            ElseIf Type = GetType(Int16) OrElse Type = GetType(Short) OrElse Type = GetType(Int16?) OrElse Type = GetType(Short?) Then

                Return "Short"

            Else

                Return Type.Name.ToString

            End If

        End Function
        Private Sub SetPicutureBoxImage(ByVal PictureBox As DevExpress.XtraReports.UI.XRPictureBox, ByVal ImagePath As String)

            'objects
            Dim Bitmap As Drawing.Bitmap = Nothing
            Dim Height As Integer = Nothing

            Bitmap = New Drawing.Bitmap(ImagePath)

            If Bitmap.Width > PictureBox.SizeF.Width OrElse Bitmap.Height > 900 Then

                Height = CInt((Bitmap.Height * PictureBox.SizeF.Width) / Bitmap.Width)
                Height = Math.Min(Height, 900)
                PictureBox.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze
                PictureBox.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.TopLeft

            Else

                Height = Bitmap.Height
                PictureBox.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Normal

            End If

            PictureBox.SizeF = New Drawing.SizeF(PictureBox.SizeF.Width, Height)
            PictureBox.Image = Bitmap

        End Sub

#End Region

#Region " Event Handlers "

        Private Sub AdvantageAPI_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            If Me.NoBank = True Then

                SetPicutureBoxImage(PictureBoxPage2_PublicClassLayout, My.Application.Info.DirectoryPath & "\Images\APIforMediaClassDiagram1NoBank.png")

            Else

                SetPicutureBoxImage(PictureBoxPage2_PublicClassLayout, My.Application.Info.DirectoryPath & "\Images\APIforMediaClassDiagram1.png")

            End If

            SetPicutureBoxImage(PictureBoxPage2Continued_PublicClassLayout, My.Application.Info.DirectoryPath & "\Images\APIforMediaClassDiagram2.png")

        End Sub
        Private Sub TablePage3_Methods_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TablePage3_Methods.BeforePrint

            'objects
            Dim XRTableRow As DevExpress.XtraReports.UI.XRTableRow = Nothing
            Dim ParameterInfos As Reflection.ParameterInfo() = Nothing
            Dim Parameters As Generic.List(Of String) = Nothing
            Dim ReturnType As String = Nothing
            Dim Counter As Integer = 1

            TablePage3_Methods.DeleteRow(TableRowMethodsTable_TempRow1)
            TablePage3_Methods.DeleteRow(TableRowMethodsTable_TempRow2)

            For Each MethodInfo In GetDocumentationMethods()

                Parameters = New List(Of String)

                XRTableRow = TablePage3_Methods.InsertRowBelow(TablePage3_Methods.Rows.LastRow)

                XRTableRow.Cells(1).Multiline = True

                ParameterInfos = MethodInfo.GetParameters()

                If ParameterInfos IsNot Nothing AndAlso ParameterInfos.Count > 0 Then

                    For Each ParameterInfo In ParameterInfos

                        Parameters.Add(ParameterInfo.Name & " as " & GetFriendlyTypeName(ParameterInfo.ParameterType))

                    Next

                End If

                ReturnType = MethodInfo.ReturnType.Name.ToString()

                Try

                    If MethodInfo.ReturnType.IsGenericType AndAlso MethodInfo.ReturnType.GetGenericTypeDefinition() = GetType(List(Of )) Then

                        ReturnType = "Array Of " & MethodInfo.ReturnType.GetGenericArguments().First.Name.ToString

                    End If

                Catch ex As Exception

                End Try

                If Counter Mod 2 = 1 Then

                    XRTableRow.Styles.Style = OddStyle

                Else

                    XRTableRow.Styles.Style = EvenStyle

                End If

                XRTableRow.Cells(0).Text = MethodInfo.Name
                XRTableRow.Cells(1).Text = String.Join(", " & vbCrLf, Parameters)
                XRTableRow.Cells(2).Text = ReturnType

                Counter += 1

            Next

        End Sub
        Private Sub TablePage4_Method_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TablePage4_Method.BeforePrint

            'objects
            Dim XRTableRow As DevExpress.XtraReports.UI.XRTableRow = Nothing
            Dim ParameterInfos As Reflection.ParameterInfo() = Nothing
            Dim Parameters As Generic.List(Of String) = Nothing
            Dim Counter As Integer = 1

            TablePage4_Method.DeleteRow(TableRowMethod_TempRow1)
            TablePage4_Method.DeleteRow(TableRowMethod_TempRow2)

            For Each MethodInfo In GetDocumentationMethods()

                Parameters = New List(Of String)

                XRTableRow = TablePage4_Method.InsertRowBelow(TablePage4_Method.Rows.LastRow)

                ParameterInfos = MethodInfo.GetParameters()

                If ParameterInfos IsNot Nothing AndAlso ParameterInfos.Count > 0 Then

                    For Each ParameterInfo In ParameterInfos

                        Parameters.Add(ParameterInfo.Name & "={" & ParameterInfo.Name.ToUpper & "}")

                    Next

                End If

                If Counter Mod 2 = 1 Then

                    XRTableRow.Styles.Style = OddStyle

                Else

                    XRTableRow.Styles.Style = EvenStyle

                End If

                XRTableRow.Cells(0).Text = MethodInfo.Name & "?" & String.Join("&", Parameters)

                Counter += 1

            Next

        End Sub

#End Region

    End Class

End Namespace