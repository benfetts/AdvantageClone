Namespace PurchaseOrder

    Public Class PurchaseOrderDetailsSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault = Nothing
        Private _HideClientProductLabel As Boolean = True
        Private _HideJobCompLabel As Boolean = True

#End Region

#Region " Properties "

        Public WriteOnly Property PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault
            Set(value As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault)
                _PurchaseOrderPrintDefault = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Function LoadCurrentPurchaseOrderDetail() As AdvantageFramework.Database.Classes.PurchaseOrderDetail

            'objects
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing

            Try

                PurchaseOrderDetail = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Classes.PurchaseOrderDetail)

            Catch ex As Exception
                PurchaseOrderDetail = Nothing
            End Try

            LoadCurrentPurchaseOrderDetail = PurchaseOrderDetail

        End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub PurchaseOrderDetailsSubReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            If _PurchaseOrderPrintDefault IsNot Nothing Then

                If _PurchaseOrderPrintDefault.ClientName.GetValueOrDefault(0) = 1 OrElse
                   _PurchaseOrderPrintDefault.ProductName.GetValueOrDefault(0) = 1 OrElse
                   _PurchaseOrderPrintDefault.FunctionDescription.GetValueOrDefault(0) = 1 Then

                    _HideClientProductLabel = False

                End If

                If _PurchaseOrderPrintDefault.JobComponentNumber.GetValueOrDefault(0) = 1 OrElse
                   _PurchaseOrderPrintDefault.JobDescription.GetValueOrDefault(0) = 1 OrElse
                   _PurchaseOrderPrintDefault.JobComponentDescription.GetValueOrDefault(0) = 1 Then

                    _HideJobCompLabel = False

                End If

            Else

                _HideClientProductLabel = True
                _HideJobCompLabel = True

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub LabelHeader_ClientProduct_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelHeader_ClientProduct.BeforePrint

            'objects
            Dim HeaderText As String = ""

            Try

                If _PurchaseOrderPrintDefault IsNot Nothing Then

                    If _PurchaseOrderPrintDefault.ClientName.GetValueOrDefault(0) = 1 And _PurchaseOrderPrintDefault.ProductName.GetValueOrDefault(0) = 1 And _PurchaseOrderPrintDefault.FunctionDescription.GetValueOrDefault(0) = 1 Then

                        HeaderText = "Client / Product / Function"

                    ElseIf _PurchaseOrderPrintDefault.ClientName.GetValueOrDefault(0) = 1 And _PurchaseOrderPrintDefault.ProductName.GetValueOrDefault(0) = 1 And _PurchaseOrderPrintDefault.FunctionDescription.GetValueOrDefault(0) = 0 Then

                        HeaderText = "Client / Product"

                    ElseIf _PurchaseOrderPrintDefault.ClientName.GetValueOrDefault(0) = 1 And _PurchaseOrderPrintDefault.ProductName.GetValueOrDefault(0) = 0 And _PurchaseOrderPrintDefault.FunctionDescription.GetValueOrDefault(0) = 1 Then

                        HeaderText = "Client / Function"

                    ElseIf _PurchaseOrderPrintDefault.ClientName.GetValueOrDefault(0) = 0 And _PurchaseOrderPrintDefault.ProductName.GetValueOrDefault(0) = 1 And _PurchaseOrderPrintDefault.FunctionDescription.GetValueOrDefault(0) = 1 Then

                        HeaderText = "Product / Function"

                    ElseIf _PurchaseOrderPrintDefault.ClientName.GetValueOrDefault(0) = 0 And _PurchaseOrderPrintDefault.ProductName.GetValueOrDefault(0) = 0 And _PurchaseOrderPrintDefault.FunctionDescription.GetValueOrDefault(0) = 1 Then

                        HeaderText = "Function"

                    ElseIf _PurchaseOrderPrintDefault.ClientName.GetValueOrDefault(0) = 0 And _PurchaseOrderPrintDefault.ProductName.GetValueOrDefault(0) = 1 And _PurchaseOrderPrintDefault.FunctionDescription.GetValueOrDefault(0) = 0 Then

                        HeaderText = "Product"

                    ElseIf _PurchaseOrderPrintDefault.ClientName.GetValueOrDefault(0) = 1 And _PurchaseOrderPrintDefault.ProductName.GetValueOrDefault(0) = 0 And _PurchaseOrderPrintDefault.FunctionDescription.GetValueOrDefault(0) = 0 Then

                        HeaderText = "Client"

                    End If

                End If

            Catch ex As Exception
                HeaderText = ""
            Finally
                LabelHeader_ClientProduct.Text = HeaderText
            End Try

        End Sub
        Private Sub LabelHeader_JobComp_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelHeader_JobComp.BeforePrint

            'objects
            Dim HeaderText As String = ""

            Try

                If _PurchaseOrderPrintDefault IsNot Nothing Then

                    If _PurchaseOrderPrintDefault.JobComponentNumber.GetValueOrDefault(0) = 1 OrElse
                       _PurchaseOrderPrintDefault.JobDescription.GetValueOrDefault(0) = 1 OrElse
                       _PurchaseOrderPrintDefault.JobComponentDescription.GetValueOrDefault(0) = 1 Then

                        HeaderText = "Job"

                    End If

                End If

            Catch ex As Exception
                HeaderText = ""
            Finally
                LabelHeader_JobComp.Text = HeaderText
            End Try

        End Sub
        Private Sub Label_Description_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_Description.BeforePrint

            Try

                If _HideClientProductLabel AndAlso _HideJobCompLabel Then

                    Label_Description.Visible = False

                Else

                    Label_Description.Visible = True

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub Label_BigDescription_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_BigDescription.BeforePrint

            Try

                If _HideClientProductLabel AndAlso _HideJobCompLabel Then

                    Label_BigDescription.Visible = True

                Else

                    Label_BigDescription.Visible = False

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub Label_ClientProduct_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_ClientProduct.BeforePrint

            'objects
            Dim Values As Generic.List(Of String) = Nothing
            Dim Lines As String() = Nothing
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
            Dim Visible As Boolean = False

            Try

                If _HideClientProductLabel = False Then

                    Visible = True

                    PurchaseOrderDetail = LoadCurrentPurchaseOrderDetail()

                    Values = New Generic.List(Of String)

                    If _PurchaseOrderPrintDefault.ClientName.GetValueOrDefault(0) = 1 Then

                        Values.Add(PurchaseOrderDetail.ClientName)

                    End If

                    If _PurchaseOrderPrintDefault.ProductName.GetValueOrDefault(0) = 1 Then

                        Values.Add(PurchaseOrderDetail.ProductDescription)

                    End If

                    If _PurchaseOrderPrintDefault.FunctionDescription.GetValueOrDefault(0) = 1 Then

                        Values.Add(PurchaseOrderDetail.FunctionDescription)

                    End If

                    If Values IsNot Nothing Then

                        Lines = Values.ToArray

                    End If

                End If

            Catch ex As Exception
                Lines = Nothing
                Visible = False
            Finally
                Label_ClientProduct.Visible = Visible
                Label_ClientProduct.Lines = Lines
            End Try

        End Sub
        Private Sub Label_JobComp_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_JobComp.BeforePrint

            'objects
            Dim LabelText As String = Nothing
            Dim Values As Generic.List(Of String) = Nothing
            Dim Lines As String() = Nothing
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
            Dim Visible As Boolean = False

            Try

                If _HideJobCompLabel = False Then

                    Visible = True

                    PurchaseOrderDetail = LoadCurrentPurchaseOrderDetail()

                    Values = New Generic.List(Of String)

                    If _PurchaseOrderPrintDefault.JobComponentNumber.GetValueOrDefault(0) = 1 Then

                        If PurchaseOrderDetail.JobNumber.GetValueOrDefault(0) > 0 AndAlso PurchaseOrderDetail.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                            Values.Add(String.Format("{0}-{1}", AdvantageFramework.StringUtilities.PadWithCharacter(PurchaseOrderDetail.JobNumber.GetValueOrDefault(0).ToString, 6, "0", True), AdvantageFramework.StringUtilities.PadWithCharacter(PurchaseOrderDetail.JobComponentNumber.GetValueOrDefault(0).ToString, 3, "0", True)))

                        End If

                    End If

                    If _PurchaseOrderPrintDefault.JobDescription.GetValueOrDefault(0) = 1 Then

                        Values.Add(PurchaseOrderDetail.JobDescription)

                    End If


                    If _PurchaseOrderPrintDefault.JobComponentDescription.GetValueOrDefault(0) = 1 Then

                        Values.Add(PurchaseOrderDetail.JobComponentDescription)

                    End If

                    If Values IsNot Nothing Then

                        Lines = Values.ToArray

                    End If

                End If

            Catch ex As Exception
                LabelText = Nothing
                Visible = False
            Finally
                Label_JobComp.Visible = Visible
                Label_JobComp.Lines = Lines
            End Try

        End Sub
        Private Sub Label_DetailDescriptionAndInstructions_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_DetailDescriptionAndInstructions.BeforePrint

            'objects
            Dim Visible As Boolean = False
            Dim Lines As String() = Nothing
            Dim Values As Generic.List(Of String) = Nothing
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing

            Try

                Values = New Generic.List(Of String)

                PurchaseOrderDetail = LoadCurrentPurchaseOrderDetail()

                If PurchaseOrderDetail IsNot Nothing Then

                    If _PurchaseOrderPrintDefault.DetailDescription.GetValueOrDefault(0) = 1 Then

                        If String.IsNullOrWhiteSpace(PurchaseOrderDetail.DetailDescription) = False Then

                            Visible = True
                            Values.Add("Description: " & PurchaseOrderDetail.DetailDescription)

                        End If

                    End If

                    If _PurchaseOrderPrintDefault.DetailInstruction.GetValueOrDefault(0) = 1 Then

                        If String.IsNullOrWhiteSpace(PurchaseOrderDetail.Instructions) = False Then

                            Visible = True
                            Values.Add("Instructions: " & PurchaseOrderDetail.Instructions)

                        End If
                        
                    End If

                    If Values IsNot Nothing Then

                        Lines = Values.ToArray

                    End If

                End If

            Catch ex As Exception
                Visible = False
                Lines = Nothing
            Finally
                Label_DetailDescriptionAndInstructions.Visible = Visible
                Label_DetailDescriptionAndInstructions.Lines = Lines
            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace
