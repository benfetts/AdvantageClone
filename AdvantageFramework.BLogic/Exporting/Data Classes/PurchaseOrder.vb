Namespace Exporting.DataClasses

    <Serializable()>
    Public Class PurchaseOrder
        Implements AdvantageFramework.Exporting.Interfaces.IExportData

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Number
            CreateDate
            UserID
            VendorCode
            EmployeeCode
            PODate
            PODueDate
            Description
            MainInstruction
            IsComplete
            DeliveryInstruction
            IsVoided
            VoidBy
            VoidDate
            Revision
            IsWorkComplete
            VendorContactCode
            Footer
            WVFlag
            ApprovalFlag
            IsPrinted
            PurchaseOrderApprovalRuleCode
            ExceedFlag
            ModifiedByUserCode
            ModifiedDate
            DetailDescription
            LineNumber
            LineDescription
            Instructions
            Quantity
            Rate
            ExtendedAmount
            TaxPercent
            DetailIsComplete
            JobNumber
            JobComponentNumber
            FunctionCode
            CommissionPercent
            ExtendedMarkupAmount
            GLACode
        End Enum

#End Region

#Region " Variables "

        Private _Number As Integer = Nothing
        Private _CreateDate As Nullable(Of Date) = Nothing
        Private _UserID As String = Nothing
        Private _VendorCode As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _PODate As Nullable(Of Date) = Nothing
        Private _PODueDate As Nullable(Of Date) = Nothing
        Private _Description As String = Nothing
        Private _MainInstruction As String = Nothing
        Private _IsComplete As Boolean = False
        Private _DeliveryInstruction As String = Nothing
        Private _IsVoided As Boolean = False
        Private _VoidBy As String = Nothing
        Private _VoidDate As Nullable(Of Date) = Nothing
        Private _Revision As Nullable(Of Short) = Nothing
        Private _IsWorkComplete As Boolean = False
        Private _VendorContactCode As String = Nothing
        Private _Footer As String = Nothing
        Private _WVFlag As Nullable(Of Short) = Nothing
        Private _ApprovalFlag As Nullable(Of Short) = Nothing
        Private _IsPrinted As Boolean = False
        Private _PurchaseOrderApprovalRuleCode As String = Nothing
        Private _ExceedFlag As Boolean = False
        Private _ModifiedByUserCode As String = Nothing
        Private _ModifiedDate As Nullable(Of Date) = Nothing
        Private _LineNumber As Integer = Nothing
        Private _DetailDescription As String = Nothing
        Private _LineDescription As String = Nothing
        Private _Instructions As String = Nothing
        Private _Quantity As Nullable(Of Integer) = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _ExtendedAmount As Nullable(Of Decimal) = Nothing
        Private _TaxPercent As Nullable(Of Decimal) = Nothing
        Private _DetailIsComplete As Boolean = False
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _FunctionCode As String = Nothing
        Private _CommissionPercent As Nullable(Of Decimal) = Nothing
        Private _ExtendedMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _GLACode As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property Number() As Integer
            Get
                Number = _Number
            End Get
            Set(value As Integer)
                _Number = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreateDate() As Nullable(Of Date)
            Get
                CreateDate = _CreateDate
            End Get
            Set(value As Nullable(Of Date))
                _CreateDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserID() As String
            Get
                UserID = _UserID
            End Get
            Set(value As String)
                _UserID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PODate() As Nullable(Of Date)
            Get
                PODate = _PODate
            End Get
            Set(value As Nullable(Of Date))
                _PODate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PODueDate() As Nullable(Of Date)
            Get
                PODueDate = _PODueDate
            End Get
            Set(value As Nullable(Of Date))
                _PODueDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(value As String)
                _Description = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MainInstruction() As String
            Get
                MainInstruction = _MainInstruction
            End Get
            Set(value As String)
                _MainInstruction = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsComplete() As Boolean
            Get
                IsComplete = _IsComplete
            End Get
            Set(value As Boolean)
                _IsComplete = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DeliveryInstruction As String
            Get
                DeliveryInstruction = _DeliveryInstruction
            End Get
            Set(value As String)
                _DeliveryInstruction = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsVoided() As Boolean
            Get
                IsVoided = _IsVoided
            End Get
            Set(value As Boolean)
                _IsVoided = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VoidBy() As String
            Get
                VoidBy = _VoidBy
            End Get
            Set(value As String)
                _VoidBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VoidDate() As Nullable(Of Date)
            Get
                VoidDate = _VoidDate
            End Get
            Set(value As Nullable(Of Date))
                _VoidDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Revision() As Nullable(Of Short)
            Get
                Revision = _Revision
            End Get
            Set(value As Nullable(Of Short))
                _Revision = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsWorkComplete() As Boolean
            Get
                IsWorkComplete = _IsWorkComplete
            End Get
            Set(value As Boolean)
                _IsWorkComplete = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorContactCode() As String
            Get
                VendorContactCode = _VendorContactCode
            End Get
            Set(value As String)
                _VendorContactCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Footer() As String
            Get
                Footer = _Footer
            End Get
            Set(value As String)
                _Footer = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property WVFlag() As Nullable(Of Short)
            Get
                WVFlag = _WVFlag
            End Get
            Set(value As Nullable(Of Short))
                _WVFlag = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApprovalFlag() As Nullable(Of Short)
            Get
                ApprovalFlag = _ApprovalFlag
            End Get
            Set(value As Nullable(Of Short))
                _ApprovalFlag = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsPrinted() As Boolean
            Get
                IsPrinted = _IsPrinted
            End Get
            Set(value As Boolean)
                _IsPrinted = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PurchaseOrderApprovalRuleCode() As String
            Get
                PurchaseOrderApprovalRuleCode = _PurchaseOrderApprovalRuleCode
            End Get
            Set(value As String)
                _PurchaseOrderApprovalRuleCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExceedFlag() As Boolean
            Get
                ExceedFlag = _ExceedFlag
            End Get
            Set(value As Boolean)
                _ExceedFlag = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedByUserCode() As String
            Get
                ModifiedByUserCode = _ModifiedByUserCode
            End Get
            Set(value As String)
                _ModifiedByUserCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedDate() As Nullable(Of Date)
            Get
                ModifiedDate = _ModifiedDate
            End Get
            Set(value As Nullable(Of Date))
                _ModifiedDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LineNumber() As Integer
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Integer)
                _LineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property DetailDescription() As String
            Get
                DetailDescription = _DetailDescription
            End Get
            Set(value As String)
                _DetailDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LineDescription() As String
            Get
                LineDescription = _LineDescription
            End Get
            Set(value As String)
                _LineDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Instructions() As String
            Get
                Instructions = _Instructions
            End Get
            Set(value As String)
                _Instructions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property Quantity() As Nullable(Of Integer)
            Get
                Quantity = _Quantity
            End Get
            Set(value As Nullable(Of Integer))
                _Quantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3")>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(value As Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ExtendedAmount() As Nullable(Of Decimal)
            Get
                ExtendedAmount = _ExtendedAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n4")>
        Public Property TaxPercent() As Nullable(Of Decimal)
            Get
                TaxPercent = _TaxPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _TaxPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DetailIsComplete() As Boolean
            Get
                DetailIsComplete = _DetailIsComplete
            End Get
            Set(value As Boolean)
                _DetailIsComplete = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3")>
        Public Property CommissionPercent() As Nullable(Of Decimal)
            Get
                CommissionPercent = _CommissionPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _CommissionPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ExtendedMarkupAmount() As Nullable(Of Decimal)
            Get
                ExtendedMarkupAmount = _ExtendedMarkupAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedMarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLACode() As String
            Get
                GLACode = _GLACode
            End Get
            Set(value As String)
                _GLACode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
