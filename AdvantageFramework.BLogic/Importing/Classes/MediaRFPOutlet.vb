Namespace Importing.Classes

    Public Class MediaRFPOutlet

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            OutletId
            OutletForListId
            HeaderComment
            CallLetters
            Network
            Syscode
            IsCable
            BatchNumber
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property OutletId() As String

        Public Property OutletForListId() As String

        Public Property HeaderComment() As String

        Public Property CallLetters() As String

        Public Property Syscode() As String

        Public Property IsCable() As Boolean

        Public Property BatchNumber() As Nullable(Of Short)

        Public Property HeaderAddedUpdated() As Boolean

        Public Property MediaRFPHeaderID() As Nullable(Of Integer)

        Public Property Band() As String

        Public Property CanadianVendorCode() As String

        Public Property StationElementInnerText() As String

#End Region

#Region " Methods "

        Public Sub New() 'used only for Canadian radio



        End Sub
        Public Sub New(OutletId As String, OutletForListId As String)

            Me.OutletId = OutletId
            Me.OutletForListId = OutletForListId

        End Sub

#End Region

    End Class

End Namespace
