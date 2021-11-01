Namespace Reporting.Database.Classes

    <Serializable>
    Public Class SecurityUserLoginAudit

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            UserCode
            Employee
            IPAddress
            Application
            LoginTime
            LogoutTime
            Duration
            Successful
            FailureReason
        End Enum

#End Region

#Region " Variables "

        Private _Duration As String = String.Empty

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        Public Property UserCode() As String
        Public Property Employee() As String
        Public Property IPAddress() As String
        Public Property Application() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="G")>
        Public Property LoginTime() As DateTime
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="G")>
        Public Property LogoutTime() As Nullable(Of DateTime)
        Public ReadOnly Property Duration As String
            Get

                Dim TimeSpan As TimeSpan = Nothing

                If Me.LogoutTime <> DateTime.MinValue AndAlso _Duration = String.Empty Then

                    TimeSpan = Me.LoginTime - Me.LogoutTime

                    If TimeSpan.Days <> 0 Then

                        _Duration = TimeSpan.ToString("d\.hh\:mm\:ss")

                    Else

                        _Duration = TimeSpan.ToString("hh\:mm\:ss")

                    End If

                End If

                Duration = _Duration

            End Get
        End Property
        Public Property Successful() As Boolean
        Public Property FailureReason() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
