Namespace Database.Procedures.CheckWritingSelection

    <HideModuleName()> _
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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CheckWritingSelection)

            Load = From CheckWritingSelection In DbContext.GetQuery(Of Database.Entities.CheckWritingSelection)
                   Select CheckWritingSelection

        End Function
        Public Function LoadByVendorCode(ByVal DbContext As Database.DbContext, ByVal VendorCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CheckWritingSelection)

            LoadByVendorCode = From CheckWritingSelection In DbContext.GetQuery(Of Database.Entities.CheckWritingSelection)
                               Where CheckWritingSelection.Type = "V" AndAlso
                                     CheckWritingSelection.Code = VendorCode
                               Select CheckWritingSelection

        End Function

#End Region

    End Module

End Namespace
