Namespace BaseClasses

    <Serializable()>
    <NotMapped>
    Public MustInherit Class DataContext
        Inherits System.Data.Linq.DataContext

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _UserCode As String = ""
        Protected _IsDisposed As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property UserCode As String
            Get
                UserCode = _UserCode
            End Get
        End Property
        Public ReadOnly Property IsDisposed As Boolean
            Get
                IsDisposed = _IsDisposed
            End Get
        End Property

#End Region

#Region " Methods "

        Friend Sub New(ByVal ConnectionString As String, ByVal UserCode As String)

            MyBase.New(ConnectionString)
            MyBase.CommandTimeout = 0

            _UserCode = UserCode

        End Sub
        Protected Overrides Sub Dispose(disposing As Boolean)

            MyBase.Dispose(True)

            _IsDisposed = True

        End Sub

#End Region

    End Class

End Namespace