Namespace ProjectManagement.Agile.Classes

    <Serializable()>
    Public Class CardAssignee

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ID
            AlertID
            EmployeeCode
            EmployeeEmail
            EmployeeFullName
            EmployeeImage
            IsCurrentRecipient
            IsCurrentNotify
            IsTaskEmployee
            IsTaskTempComplete
            EmployeePicture

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ID As Integer
        Public Property AlertID As Integer
        Public Property EmployeeCode As String
        Public Property EmployeeEmail As String
        Public Property EmployeeFullName As String
        Public Property EmployeeImage As Byte()
        Public Property IsCurrentRecipient As Boolean = False
        Public Property IsCurrentNotify As Boolean = False
        Public Property IsTaskEmployee As Boolean = False
        Public Property IsTaskTempComplete As Boolean = False
        Public Property IsRead As Boolean = False
        Public Property IsCurrentAssignee As Boolean = False
        Public ReadOnly Property EmployeePicture As String
            Get
                'objects
                Dim PictureString As String = Nothing

                'If Me.EmployeeImage IsNot Nothing Then

                '    Try

                '        PictureString = Convert.ToBase64String(Me.EmployeeImage, 0, EmployeeImage.Length)

                '    Catch ex As Exception

                '    End Try

                'End If

                Return PictureString

            End Get
        End Property

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace
