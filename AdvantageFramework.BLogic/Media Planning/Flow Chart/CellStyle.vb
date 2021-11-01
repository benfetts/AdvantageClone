Namespace MediaPlanning.FlowChart

    Public Class CellStyle

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DisplayString As String = String.Empty

#End Region

#Region " Properties "

        Public Property IsBold As Boolean
        Public Property IsItalic As Boolean
        Public Property Underline As Boolean
        Public Property HorizontalAlignment As Aspose.Cells.TextAlignmentType
        Public Property VerticalAlignment As Aspose.Cells.TextAlignmentType
        Public Property FontColor As System.Drawing.Color
        Public Property BackgroundColor As System.Drawing.Color
        Public Property DisplayString As String
            Get

                If _DisplayString = String.Empty Then

                    DisplayString = Me.DefaultDisplayString

                Else

                    DisplayString = _DisplayString

                End If

            End Get
            Set(value As String)
                _DisplayString = value
            End Set
        End Property
        Public Property CellValueType As CellValueType
        Public ReadOnly Property DefaultDisplayString As String
            Get

                If CellValueType = CellValueType.General Then

                    DefaultDisplayString = String.Empty

                ElseIf CellValueType = CellValueType.Text Then

                    DefaultDisplayString = "@"

                ElseIf CellValueType = CellValueType.Integer Then

                    DefaultDisplayString = "#,##0"

                ElseIf CellValueType = CellValueType.Decimal Then

                    DefaultDisplayString = "#,##0.00"

                ElseIf CellValueType = CellValueType.Currency Then

                    DefaultDisplayString = "$#,##0.00_);($#,##0.00)"

                ElseIf CellValueType = CellValueType.Percentage Then

                    DefaultDisplayString = "0.00%"

                ElseIf CellValueType = CellValueType.Date Then

                    DefaultDisplayString = "m/d/yyyy"

                ElseIf CellValueType = CellValueType.Time Then

                    DefaultDisplayString = "h:mm AM/PM"

                ElseIf CellValueType = CellValueType.Accounting Then

                    DefaultDisplayString = "#,##0_);(#,##0)"

                Else

                    DefaultDisplayString = String.Empty

                End If

            End Get
        End Property
        Public Property TopBorder As CellBorder
        Public Property BottomBorder As CellBorder
        Public Property LeftBorder As CellBorder
        Public Property RightBorder As CellBorder
        Public Property TextWrapped As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.IsBold = False
            Me.IsItalic = False
            Me.Underline = False
            Me.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Left
            Me.VerticalAlignment = Aspose.Cells.TextAlignmentType.Center
            Me.FontColor = System.Drawing.Color.Black
            Me.BackgroundColor = System.Drawing.Color.Empty
            Me.DisplayString = String.Empty
            Me.CellValueType = CellValueType.General
            Me.TextWrapped = False

            Me.TopBorder = New CellBorder
            Me.BottomBorder = New CellBorder
            Me.LeftBorder = New CellBorder
            Me.RightBorder = New CellBorder

        End Sub
        Public Function Copy() As CellStyle

            'objects
            Dim CopiedCellStyle As CellStyle = Nothing

            CopiedCellStyle = New CellStyle

            CopiedCellStyle.IsBold = Me.IsBold
            CopiedCellStyle.IsItalic = Me.IsItalic
            CopiedCellStyle.Underline = Me.Underline
            CopiedCellStyle.HorizontalAlignment = Me.HorizontalAlignment
            CopiedCellStyle.VerticalAlignment = Me.VerticalAlignment
            CopiedCellStyle.FontColor = Me.FontColor
            CopiedCellStyle.BackgroundColor = Me.BackgroundColor
            CopiedCellStyle.DisplayString = Me.DisplayString
            CopiedCellStyle.CellValueType = Me.CellValueType
            CopiedCellStyle.TextWrapped = Me.TextWrapped

            CopiedCellStyle.TopBorder = Me.TopBorder.Copy
            CopiedCellStyle.BottomBorder = Me.BottomBorder.Copy
            CopiedCellStyle.LeftBorder = Me.LeftBorder.Copy
            CopiedCellStyle.RightBorder = Me.RightBorder.Copy

            Copy = CopiedCellStyle

        End Function

#End Region

    End Class

End Namespace
