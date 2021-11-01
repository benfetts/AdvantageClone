Namespace SignalR.Classes

    Public Class UserEmployeeMapping

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Public Property UserCode As String = ""
        Public Property EmployeeCode As String = ""
        Public Property FullName As String = ""
        Public Property ConnectionString As String = ""
        Public Property Picture As Byte()

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub LoadPicture()

            If String.IsNullOrWhiteSpace(Me.UserCode) = False AndAlso
               String.IsNullOrWhiteSpace(Me.ConnectionString) = False AndAlso
               String.IsNullOrWhiteSpace(Me.EmployeeCode) = False Then

                Using oc = New AdvantageFramework.Database.ObjectContext(ConnectionString, Me.UserCode)

                    Dim ep As New AdvantageFramework.Database.Entities.EmployeePicture

                    ep = Nothing

                    ep = AdvantageFramework.Database.Procedures.EmployeePicture.LoadByEmployeeCode(oc, Me.EmployeeCode)

                    If ep IsNot Nothing Then

                        If ep.Image IsNot Nothing Then

                            Me.Picture = ep.Image

                        End If

                    End If

                End Using

            End If

        End Sub

        Sub New()

            Me.LoadPicture()

        End Sub
        Sub New(UserCode, EmployeeCode, FullName, ConnectionString)

            Me.UserCode = UserCode
            Me.EmployeeCode = EmployeeCode
            Me.FullName = FullName
            Me.ConnectionString = ConnectionString

            Me.LoadPicture()

        End Sub

#End Region

    End Class

End Namespace

