Namespace Database.Procedures.BroadcastOrderVerificationView

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.BroadcastOrderVerificationView)

            Load = From BroadcastOrderVerificationView In DbContext.GetQuery(Of Database.Views.BroadcastOrderVerificationView)
                   Select BroadcastOrderVerificationView

        End Function

#End Region

    End Module

End Namespace
