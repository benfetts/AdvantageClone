Namespace Database.Procedures.BroadcastOrderDetailVerificationView

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.BroadcastOrderDetailVerificationView)

            Load = From BroadcastOrderDetailVerificationView In DbContext.GetQuery(Of Database.Views.BroadcastOrderDetailVerificationView)
                   Select BroadcastOrderDetailVerificationView

        End Function

#End Region

    End Module

End Namespace
