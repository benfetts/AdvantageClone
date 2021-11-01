Namespace MediaPlanning.FlowChart

    Public Class CellData

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property DataValue As Double
        Public Property Color As Integer
        Public Property BackgroundColor As System.Drawing.Color
        Public Property Note As String
        Public Property StartDate As Date
        Public Property EndDate As Date
        Public Property IsActualized As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.DataValue = 0
            Me.Color = 0
            Me.BackgroundColor = System.Drawing.Color.Empty
            Me.Note = String.Empty
            Me.StartDate = Date.MinValue
            Me.EndDate = Date.MinValue
            Me.IsActualized = False

        End Sub
        Public Sub New(DataValue As Double, Color As Integer, BackgroundColor As System.Drawing.Color, Note As String, StartDate As Date, EndDate As Date, IsActualized As Boolean)

            Me.DataValue = DataValue
            Me.Color = Color
            Me.BackgroundColor = BackgroundColor
            Me.Note = Note
            Me.StartDate = StartDate
            Me.EndDate = EndDate
            Me.IsActualized = IsActualized

        End Sub
        Public Function Copy() As CellData

            'objects
            Dim CopiedCellData As CellData = Nothing

            CopiedCellData = New CellData

            CopiedCellData.DataValue = Me.DataValue
            CopiedCellData.Color = Me.Color
            CopiedCellData.BackgroundColor = Me.BackgroundColor
            CopiedCellData.Note = Me.Note
            CopiedCellData.StartDate = Me.StartDate
            CopiedCellData.EndDate = Me.EndDate
            CopiedCellData.IsActualized = Me.IsActualized

            Copy = CopiedCellData

        End Function

#End Region

    End Class

End Namespace
