Namespace Classes.Media.MediaBroadcastWorksheet

    Public Class RadioDemoDataInfo

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            VendorCode
            RadioStationComboIDs
            RowIndexes
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property VendorCode As String
        Public Property IsComboRadioStation As Boolean
        Public Property RadioStationComboIDs As Generic.List(Of Integer)
        Public Property RowIndexes As Generic.List(Of Integer)

#End Region

#Region " Methods "

        Public Sub New()

            Me.VendorCode = String.Empty
            Me.IsComboRadioStation = False
            Me.RadioStationComboIDs = New Generic.List(Of Integer)
            Me.RowIndexes = New Generic.List(Of Integer)

        End Sub
        Public Sub New(VendorCode As String, IsComboRadioStation As Boolean)

            Me.New()

            Me.VendorCode = VendorCode
            Me.IsComboRadioStation = IsComboRadioStation

        End Sub
        Public Sub New(VendorCode As String, IsComboRadioStation As Boolean, RowIndex As Integer)

            Me.New()

            Me.VendorCode = VendorCode
            Me.IsComboRadioStation = IsComboRadioStation
            Me.RowIndexes.Add(RowIndex)

        End Sub
        Public Sub New(VendorCode As String, IsComboRadioStation As Boolean, RadioStationComboIDs As Generic.List(Of Integer), RowIndex As Integer)

            Me.New()

            Me.VendorCode = VendorCode
            Me.IsComboRadioStation = IsComboRadioStation
            Me.RadioStationComboIDs.AddRange(RadioStationComboIDs)
            Me.RowIndexes.Add(RowIndex)

        End Sub

#End Region

    End Class

End Namespace
