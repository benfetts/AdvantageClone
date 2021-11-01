Namespace BillingCommandCenter.Classes

    <Serializable()>
    Public Class BillingSelectionCriteria
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            InvoiceDate
            PostPeriodCode
            UseComboBilling
            ComboAssignInvoicesBy
            ProductionAssignInvoicesBy
            MediaAssignInvoicesBy
        End Enum

#End Region

#Region " Variables "

        Private _InvoiceDate As Nullable(Of Date) = Nothing
        Private _PostPeriodCode As String = Nothing
        Private _ShowPostPeriodWarning As Boolean = False
        Private _ComboAssignInvoicesBy As Short = 0
        Private _ProductionAssignInvoicesBy As String = Nothing
        Private _MediaAssignInvoicesBy As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(value As Nullable(Of Date))
                _InvoiceDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.PostPeriodCode, CustomColumnCaption:="Posting Period")>
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set(value As String)
                _PostPeriodCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public Property ShowPostPeriodWarning() As Boolean
            Get
                ShowPostPeriodWarning = _ShowPostPeriodWarning
            End Get
            Set(value As Boolean)
                _ShowPostPeriodWarning = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Use Combo Billing (Override Default)")>
        Public Property UseComboBilling() As Boolean

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.PropertyTypes.AssignComboInvoiceBy, CustomColumnCaption:="Combo Assign Invoices By (Override Default)")>
        Public Property ComboAssignInvoicesBy() As Short
            Get
                ComboAssignInvoicesBy = _ComboAssignInvoicesBy
            End Get
            Set(value As Short)
                _ComboAssignInvoicesBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.PropertyTypes.AssignProductionInvoiceBy, CustomColumnCaption:="Production Assign Invoices By (Override Default)")>
        Public Property ProductionAssignInvoicesBy() As String
            Get
                ProductionAssignInvoicesBy = _ProductionAssignInvoicesBy
            End Get
            Set(value As String)
                _ProductionAssignInvoicesBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.PropertyTypes.AssignMediaInvoiceBy, CustomColumnCaption:="Media Assign Invoices By (Override Default)")>
        Public Property MediaAssignInvoicesBy() As String
            Get
                MediaAssignInvoicesBy = _MediaAssignInvoicesBy
            End Get
            Set(value As String)
                _MediaAssignInvoicesBy = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsProcessed() As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal InvoiceDate As Date, ByVal PostPeriodCode As String)

            _InvoiceDate = InvoiceDate
            _PostPeriodCode = PostPeriodCode

        End Sub
        Public Sub New(BillingCommandCenterInvoiceDatePostPeriod As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingCommandCenterInvoiceDatePostPeriod)

            _InvoiceDate = BillingCommandCenterInvoiceDatePostPeriod.InvoiceDate
            _PostPeriodCode = BillingCommandCenterInvoiceDatePostPeriod.PostPeriodCode
            Me.UseComboBilling = BillingCommandCenterInvoiceDatePostPeriod.UseComboBilling
            _ComboAssignInvoicesBy = BillingCommandCenterInvoiceDatePostPeriod.ComboAssignInvoicesBy
            _ProductionAssignInvoicesBy = BillingCommandCenterInvoiceDatePostPeriod.ProductionAssignInvoicesBy
            _MediaAssignInvoicesBy = BillingCommandCenterInvoiceDatePostPeriod.MediaAssignInvoicesBy

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.PostPeriodCode.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveARPostPeriods(DbContext)
                            Where Entity.Code = DirectCast(PropertyValue, String)
                            Select Entity).Any = False Then

                            IsValid = False

                            ErrorText = "Please select an open posting period."

                        End If

                    End If

                Case AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.ComboAssignInvoicesBy.ToString

                    PropertyValue = Value

                    If PropertyValue Is Nothing OrElse (Me.UseComboBilling AndAlso DirectCast(PropertyValue, Short) <= 0) Then

                        IsValid = False

                        ErrorText = "Please select for combo assign invoices by."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Sub SetRequiredFields()

            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            For Each PropertyDescriptor In PropertyDescriptors

                Select Case PropertyDescriptor.Name

                    Case AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.ComboAssignInvoicesBy.ToString

                        SetRequired(PropertyDescriptor, Me.UseComboBilling)

                End Select

            Next

        End Sub

#End Region

    End Class

End Namespace