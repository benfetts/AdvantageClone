Namespace DTO.Desktop

    <Serializable()>
    Public Class AlertRecipient

        Public Property ID As Integer = 0
        Public Property AlertID As Integer = 0
        Public Property EmployeeCode As String = String.Empty
        Public Property EmployeeEmail As String = String.Empty
        Public Property EmployeeFullName As String = String.Empty
        Public Property EmployeeImage As Byte()
        Public Property IsCurrentRecipient As Boolean = False
        Public Property IsCurrentNotify As Boolean = False
        Public Property IsTaskEmployee As Boolean = False
        Public Property IsTaskTempComplete As Boolean = False
        Public Property ClientContactID As Integer = 0
        Public Property IsClientContact As Boolean = False
        Public Property CompletedDismissed As Boolean = False
        Public Property AlertTemplateID As Integer? = 0
        Public Property AlertStateID As Integer? = 0
        Public Property CurrentStateCompleted As Boolean? = False
        Public Property IsCurrentAssignee As Boolean = False

        'Public ReadOnly Property EmployeePicture As String
        '    Get
        '        'objects
        '        Dim PictureString As String = Nothing

        '        If Me.EmployeeImage IsNot Nothing Then

        '            Try

        '                PictureString = Convert.ToBase64String(Me.EmployeeImage, 0, EmployeeImage.Length)

        '            Catch ex As Exception

        '            End Try

        '        End If

        '        Return PictureString

        '    End Get
        'End Property
        Public ReadOnly Property Code As String
            Get
                Return EmployeeCode
            End Get
        End Property
        Public ReadOnly Property FullName As String
            Get
                Return EmployeeFullName
            End Get
        End Property
        Public ReadOnly Property Name As String
            Get
                Return EmployeeFullName
            End Get
        End Property
    End Class

    <Serializable()>
    Public Class AlertRecipientLookUp

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            Code
            FullName
            IsEmployee
            IsClientContact
            InAlertGroup
            ConceptShareUserID
            IsConceptShareUser

        End Enum


#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Code As String = String.Empty
        Public Property FullName As String = String.Empty
        Public Property IsEmployee As Boolean? = False
        Public Property IsClientContact As Boolean? = False
        Public Property InAlertGroup As Boolean? = False
        Public Property ConceptShareUserID As Integer? = 0
        Public Property IsConceptShareUser As Boolean? = False
        Public ReadOnly Property EmployeeCode As String
            Get
                Return Code
            End Get
        End Property
        Public ReadOnly Property EmployeeFullName As String
            Get
                Return FullName
            End Get
        End Property
        Public ReadOnly Property Name As String
            Get
                Return FullName
            End Get
        End Property

#End Region

#Region " Methods "

        Sub New()

        End Sub
        'Public Shared Function FromDataRow(ByVal DataRow As System.Data.DataRow) As AlertRecipientLookUp

        '    Dim A As New AlertRecipientLookUp

        '    A = A.GetDataRowValue(DataRow, )

        '    Return A

        'End Function
        'Private Function GetDataRowValue(ByVal DataRow As System.Data.DataRow, FieldName As String, ConvertToType As Type) As Object

        '    'objects
        '    Dim Value As Object = Nothing

        '    Try

        '        If Not IsDBNull(DataRow(FieldName)) AndAlso DataRow(FieldName) IsNot Nothing Then

        '            Value = Convert.ChangeType(DataRow(FieldName), ConvertToType)

        '        End If

        '    Catch ex As Exception

        '    End Try

        '    Return Value

        'End Function

#End Region

    End Class

End Namespace
