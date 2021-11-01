Namespace MediaPlanning.FlowChart

    Public Class CellBorder

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property CellBorderType As Aspose.Cells.CellBorderType
        Public Property Color As System.Drawing.Color

#End Region

#Region " Methods "

        Public Sub New()

            Me.CellBorderType = Aspose.Cells.CellBorderType.None
            Me.Color = System.Drawing.Color.Black

        End Sub
        Public Function Copy() As CellBorder

            'objects
            Dim CopiedCellBorder As CellBorder = Nothing

            CopiedCellBorder = New CellBorder

            CopiedCellBorder.CellBorderType = Me.CellBorderType
            CopiedCellBorder.Color = Me.Color

            Copy = CopiedCellBorder

        End Function

#End Region

    End Class

End Namespace