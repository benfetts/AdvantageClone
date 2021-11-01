Imports System.Collections.Generic

Namespace Repositories
    Public Class RepositoryBase

#Region " Variables "
       
#End Region

#Region " Properties "
        Public Property DataContext As AdvantageFramework.Database.DataContext
        Public Property Session As AdvantageFramework.Security.Session
#End Region

#Region " Methods "


        Public Sub New()

        End Sub

        Public Sub New(DataContext As AdvantageFramework.Database.DataContext, Session As AdvantageFramework.Security.Session)
            Me.DataContext = DataContext
            Me.Session = Session
        End Sub
#End Region


    End Class
End Namespace
