Namespace MediaManager.Classes

    <Serializable()>
    Public Class GenerateOrderVendorRep

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Process
            DefaultCorrespondenceMethod
            Vendor
            VendorRep
            VendorRepEmail
            ContactType
            VendorFrom
            OrderNumber
            Quote
            Cancelled
            VendorCode
            VendorRepCode
        End Enum

#End Region

#Region " Variables "

        Private _Vendor As String = Nothing
        Private _VendorRep As String = Nothing
        Private _VendorRepEmail As String = Nothing
        Private _ContactType As Nullable(Of Integer) = Nothing
        Private _VendorRepFrom As String = Nothing
        Private _OrderNumber As Integer = Nothing
        Private _Quote As Boolean = Nothing
        Private _Cancelled As Boolean = Nothing
        Private _VendorCode As String = Nothing
        Private _VendorRepCode As String = Nothing
        Private _VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Process")>
        Public Property Process() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Print/Email")>
        Public Property DefaultCorrespondenceMethod() As Nullable(Of Short)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Vendor")>
        Public ReadOnly Property Vendor() As String
            Get
                Vendor = _Vendor
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Vendor" & vbCrLf & "Rep")>
        Public ReadOnly Property VendorRep() As String
            Get
                VendorRep = _VendorRep
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Vendor" & vbCrLf & "Rep Email")>
        Public ReadOnly Property VendorRepEmail() As String
            Get
                VendorRepEmail = _VendorRepEmail
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Contact" & vbCrLf & "Type", PropertyType:=BaseClasses.PropertyTypes.ContactTypeID)>
        Public ReadOnly Property ContactType() As Nullable(Of Integer)
            Get
                ContactType = _ContactType
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Vendor" & vbCrLf & "Rep From")>
        Public ReadOnly Property VendorRepFrom() As String
            Get
                VendorRepFrom = _VendorRepFrom
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Order" & vbCrLf & "Number")>
        Public ReadOnly Property OrderNumber() As Integer
            Get
                OrderNumber = _OrderNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Quote() As Boolean
            Get
                Quote = _Quote
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Cancelled() As Boolean
            Get
                Cancelled = _Cancelled
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property VendorRepCode() As String
            Get
                VendorRepCode = _VendorRepCode
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(VendorCode As String, VendorRepCode As String)

            _VendorCode = VendorCode
            _VendorRepCode = VendorRepCode

        End Sub
        Public Sub New(GenerateOrder As AdvantageFramework.MediaManager.Classes.GenerateOrder, Vendor As AdvantageFramework.Database.Entities.Vendor,
                       VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative, Process As Boolean, SendToOrderReps As Boolean)

            If GenerateOrder IsNot Nothing AndAlso Vendor IsNot Nothing AndAlso VendorRepresentative IsNot Nothing Then

                Me.Process = Process
                Me.DefaultCorrespondenceMethod = GenerateOrder.DefaultCorrespondenceMethod
                _Vendor = Vendor.Name
                _VendorRep = If(String.IsNullOrWhiteSpace(VendorRepresentative.MiddleInitial) = False, VendorRepresentative.FirstName & " " & VendorRepresentative.MiddleInitial & ". " & VendorRepresentative.LastName, VendorRepresentative.FirstName & " " & VendorRepresentative.LastName)
                _VendorRepEmail = VendorRepresentative.EmailAddress
                _ContactType = VendorRepresentative.ContactTypeID

                If SendToOrderReps Then

                    _VendorRepFrom = "Order"

                Else

                    _VendorRepFrom = "Vendor"

                End If

                _OrderNumber = GenerateOrder.OrderNumber
                _Quote = GenerateOrder.Quote
                _Cancelled = GenerateOrder.Cancelled
                _VendorCode = Vendor.Code
                _VendorRepCode = VendorRepresentative.Code

                _VendorRepresentative = VendorRepresentative

            End If

        End Sub
        Public Function GetVendorRepresentative() As AdvantageFramework.Database.Entities.VendorRepresentative

            GetVendorRepresentative = _VendorRepresentative

        End Function

#End Region

    End Class

End Namespace