Namespace BillingCommandCenter.Classes

    Public Class JobCoop

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobNumber
            JobDescription
            OfficeCode
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            BillingCoopCode
            BillingCoopDescription
        End Enum

#End Region

#Region " Variables "

        Private _Job As AdvantageFramework.Database.Entities.Job = Nothing
        Private _BillingCoopDescription As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job" & vbCrLf & "Number")>
        Public ReadOnly Property JobNumber() As Integer
            Get
                JobNumber = _Job.Number
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job" & vbCrLf & "Description")>
        Public ReadOnly Property JobDescription() As String
            Get
                JobDescription = _Job.Description
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Office" & vbCrLf & "Code")>
        Public ReadOnly Property OfficeCode() As String
            Get
                OfficeCode = _Job.OfficeCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client" & vbCrLf & "Code")>
        Public ReadOnly Property ClientCode() As String
            Get
                ClientCode = _Job.ClientCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client" & vbCrLf & "Name")>
        Public ReadOnly Property ClientName() As String
            Get
                ClientName = _Job.Client.Name
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Division" & vbCrLf & "Code")>
        Public ReadOnly Property DivisionCode() As String
            Get
                DivisionCode = _Job.DivisionCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Division" & vbCrLf & "Name")>
        Public ReadOnly Property DivisionName() As String
            Get
                DivisionName = _Job.Division.Name
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product" & vbCrLf & "Code")>
        Public ReadOnly Property ProductCode() As String
            Get
                ProductCode = _Job.ProductCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product" & vbCrLf & "Description")>
        Public ReadOnly Property ProductDescription() As String
            Get
                ProductDescription = _Job.Product.Name
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Billing" & vbCrLf & "Coop Code", PropertyType:=BaseClasses.PropertyTypes.BillingCoopCode)>
        Public Property BillingCoopCode() As String
            Get
                BillingCoopCode = _Job.BillingCoopCode
            End Get
            Set(value As String)
                _Job.BillingCoopCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Billing" & vbCrLf & "Coop Description", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.BillingCoopDescription)>
        Public Property BillingCoopDescription() As String
            Get
                BillingCoopDescription = _BillingCoopDescription
            End Get
            Set(value As String)
                _BillingCoopDescription = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Job As AdvantageFramework.Database.Entities.Job)

            Dim BillingCoop As AdvantageFramework.Database.Entities.BillingCoop = Nothing

            _Job = Job

            If Not String.IsNullOrWhiteSpace(_Job.BillingCoopCode) Then

                BillingCoop = (From BC In AdvantageFramework.Database.Procedures.BillingCoop.LoadByBillingCoopCode(DbContext, _Job.BillingCoopCode).ToList
                               Select BC).FirstOrDefault

                If BillingCoop IsNot Nothing Then

                    _BillingCoopDescription = BillingCoop.Description

                End If

            End If

        End Sub

#End Region

    End Class

End Namespace