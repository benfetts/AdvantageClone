Namespace ViewModels.LookupObjects

    Public Class JobComponent
        Inherits ViewModels.LookupObjects.BaseLookupObject

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            IncludeInactive
            SalesClass
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ClientCode As String
        Public Property ClientName As String
        Public Property DivisionCode As String
        Public Property DivisionName As String
        Public Property ProductCode As String
        Public Property ProductName As String
        Public Property JobNumber As Integer?
        Public Property JobDescription As String
        Public Property JobComponentNumber As Short?
        Public Property JobComponentDescription As String
        Public Property IncludeInactive As Boolean
        Public Property SalesClass As String
        Public Overrides ReadOnly Property SearchText As String
            Get
                'objects
                Dim JobNumberString As String = If(Me.JobNumber.GetValueOrDefault(0) > 0, Me.JobNumber.Value.ToString, [String].Empty)
                Dim JobComponentNumberString As String = If(Me.JobComponentNumber.GetValueOrDefault(0) > 0, Me.JobComponentNumber.Value.ToString, [String].Empty)

                Return (ClientCode + Space(1) + ClientName + Space(1) + DivisionCode + Space(1) + DivisionName + Space(1) + ProductCode + Space(1) + ProductName + Space(1) + _
                        JobNumberString + Space(1) + JobDescription + Space(1) + JobComponentNumberString + Space(1) + JobComponentDescription).ToLower

            End Get
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace


