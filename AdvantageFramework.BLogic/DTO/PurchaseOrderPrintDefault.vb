Namespace DTO

    Public Class PurchaseOrderPrintDefault
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            UserID
            DateToPrint
            ShippingInstructions
            PurchaseOrderInstructions
            FooterComment
            DetailDescription
            DetailInstruction
            VendorContact
            ClientName
            ProductName
            JobComponentNumber
            LocationID
            LogoPath
            ReportFormat
            FunctionDescription
            JobDescription
            UseEmployeeSignature
            VendorCode
            UseUserSignature
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property UserID() As String
        Public Property DateToPrint() As String
        Public Property ShippingInstructions() As Boolean
        Public Property PurchaseOrderInstructions() As Boolean
        Public Property FooterComment() As Boolean
        Public Property DetailDescription() As Boolean
        Public Property DetailInstruction() As Boolean
        Public Property VendorContact() As Boolean
        Public Property ClientName() As Boolean
        Public Property ProductName() As Boolean
        Public Property JobComponentNumber() As Boolean
        Public Property LocationID() As String
        Public Property LogoPath() As String
        Public Property ReportFormat() As String
        Public Property FunctionDescription() As Boolean
        Public Property JobDescription() As Boolean
        Public Property UseEmployeeSignature() As Boolean
        Public Property VendorCode() As Boolean
        Public Property UseUserSignature() As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault)

            Me.DateToPrint = CStr(PurchaseOrderPrintDefault.DateToPrint.GetValueOrDefault(0))
            Me.ShippingInstructions = CBool(PurchaseOrderPrintDefault.ShippingInstructions.GetValueOrDefault(0))
            Me.PurchaseOrderInstructions = CBool(PurchaseOrderPrintDefault.PurchaseOrderInstructions.GetValueOrDefault(0))
            Me.FooterComment = CBool(PurchaseOrderPrintDefault.FooterComment.GetValueOrDefault(0))
            Me.DetailDescription = CBool(PurchaseOrderPrintDefault.DetailDescription.GetValueOrDefault(0))
            Me.DetailInstruction = CBool(PurchaseOrderPrintDefault.DetailInstruction.GetValueOrDefault(0))
            Me.VendorContact = CBool(PurchaseOrderPrintDefault.VendorContact.GetValueOrDefault(0))
            Me.ClientName = CBool(PurchaseOrderPrintDefault.ClientName.GetValueOrDefault(0))
            Me.ProductName = CBool(PurchaseOrderPrintDefault.ProductName.GetValueOrDefault(0))
            Me.JobComponentNumber = CBool(PurchaseOrderPrintDefault.JobComponentNumber.GetValueOrDefault(0))
            Me.LocationID = PurchaseOrderPrintDefault.LocationID
            Me.LogoPath = PurchaseOrderPrintDefault.LogoPath
            Me.ReportFormat = PurchaseOrderPrintDefault.ReportFormat
            Me.FunctionDescription = CBool(PurchaseOrderPrintDefault.FunctionDescription.GetValueOrDefault(0))
            Me.JobDescription = CBool(PurchaseOrderPrintDefault.JobDescription.GetValueOrDefault(0))
            Me.UseEmployeeSignature = CBool(PurchaseOrderPrintDefault.UseEmployeeSignature.GetValueOrDefault(0))
            Me.VendorCode = CBool(PurchaseOrderPrintDefault.VendorCode.GetValueOrDefault(0))
            Me.UseUserSignature = CBool(PurchaseOrderPrintDefault.UseUserSignature.GetValueOrDefault(0))

        End Sub
        Public Sub SaveToEntity(ByRef PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault)

            PurchaseOrderPrintDefault.DateToPrint = Convert.ToInt16(Me.DateToPrint)
            PurchaseOrderPrintDefault.ShippingInstructions = Convert.ToInt16(Me.ShippingInstructions)
            PurchaseOrderPrintDefault.PurchaseOrderInstructions = Convert.ToInt16(Me.PurchaseOrderInstructions)
            PurchaseOrderPrintDefault.FooterComment = Convert.ToInt16(Me.FooterComment)
            PurchaseOrderPrintDefault.DetailDescription = Convert.ToInt16(Me.DetailDescription)
            PurchaseOrderPrintDefault.DetailInstruction = Convert.ToInt16(Me.DetailInstruction)
            PurchaseOrderPrintDefault.VendorContact = Convert.ToInt16(Me.VendorContact)
            PurchaseOrderPrintDefault.ClientName = Convert.ToInt16(Me.ClientName)
            PurchaseOrderPrintDefault.ProductName = Convert.ToInt16(Me.ProductName)
            PurchaseOrderPrintDefault.JobComponentNumber = Convert.ToInt16(Me.JobComponentNumber)
            PurchaseOrderPrintDefault.LocationID = Me.LocationID
            PurchaseOrderPrintDefault.LogoPath = Me.LogoPath
            PurchaseOrderPrintDefault.ReportFormat = Me.ReportFormat
            PurchaseOrderPrintDefault.FunctionDescription = Convert.ToInt16(Me.FunctionDescription)
            PurchaseOrderPrintDefault.JobDescription = Convert.ToInt16(Me.JobDescription)
            PurchaseOrderPrintDefault.UseEmployeeSignature = Convert.ToInt16(Me.UseEmployeeSignature)
            PurchaseOrderPrintDefault.VendorCode = Convert.ToInt32(Me.VendorCode)
            PurchaseOrderPrintDefault.UseUserSignature = Convert.ToInt16(Me.UseUserSignature)

        End Sub

#End Region

    End Class

End Namespace