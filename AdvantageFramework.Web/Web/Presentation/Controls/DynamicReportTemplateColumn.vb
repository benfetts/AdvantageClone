Namespace Web.Presentation.Controls

    Public Class DynamicReportTemplateColumn
        Implements System.Web.UI.ITemplate

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FieldName As String = ""
        Private _DisplayFormat As String = ""

#End Region

#Region " Properties "

        Public WriteOnly Property DisplayFormat As String
            Set(value As String)
                _DisplayFormat = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal FieldName As String)

            _FieldName = FieldName

        End Sub
        Private Sub InstantiateIn(ByVal Container As System.Web.UI.Control) Implements System.Web.UI.ITemplate.InstantiateIn

            'objects
            Dim GridViewDataItemTemplateContainer As DevExpress.Web.GridViewDataItemTemplateContainer = Nothing
            Dim HtmlGenericControl As System.Web.UI.HtmlControls.HtmlGenericControl = Nothing
            Dim RowValue As Object = Nothing

            GridViewDataItemTemplateContainer = CType(Container, DevExpress.Web.GridViewDataItemTemplateContainer)

            HtmlGenericControl = New System.Web.UI.HtmlControls.HtmlGenericControl()

            HtmlGenericControl.TagName = "div"
            HtmlGenericControl.Style("text-overflow") = "clip"
            HtmlGenericControl.Style("overflow") = "hidden"
            HtmlGenericControl.Style("white-space") = "nowrap"
            HtmlGenericControl.Style("Font-family") = "Arial"

            If TypeOf GridViewDataItemTemplateContainer.Grid.GetRowValues(GridViewDataItemTemplateContainer.ItemIndex, _FieldName) Is System.Guid Then

                HtmlGenericControl.InnerText = DirectCast(GridViewDataItemTemplateContainer.Grid.GetRowValues(GridViewDataItemTemplateContainer.ItemIndex, _FieldName), System.Guid).ToString()

            Else

                RowValue = GridViewDataItemTemplateContainer.Grid.GetRowValues(GridViewDataItemTemplateContainer.ItemIndex, _FieldName)

                Try

                    If _DisplayFormat <> "" AndAlso IsReference(RowValue) = False Then

                        HtmlGenericControl.InnerText = Format(RowValue, _DisplayFormat)

                    Else

                        If IsReference(RowValue) Then

                            If TypeOf RowValue Is String Then

                                HtmlGenericControl.InnerText = RowValue

                            ElseIf TypeOf RowValue Is DevExpress.Data.UnboundErrorObject Then

                                HtmlGenericControl.InnerText = DevExpress.Data.UnboundErrorObject.DisplayText

                            Else

                                HtmlGenericControl.InnerText = RowValue

                            End If

                        Else

                            HtmlGenericControl.InnerText = RowValue

                        End If

                    End If

                Catch ex As Exception

                End Try

            End If

            Container.Controls.Add(HtmlGenericControl)

        End Sub

#End Region

    End Class

End Namespace