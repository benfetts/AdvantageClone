Namespace Database.Entities

    <Table("CLIENT_ORDER")>
    Public Class ClientOrder
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientID
            OrderNumber
            OrderDateTime
            LastChangedDateTime
            StartYear
            EndYear
            OrderDuration
            Report
            ClientAlias
            IsSuspended
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("CLIENT_ORDER_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property ID() As Integer

        <Required>
        <Column("CLIENT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ClientID() As Integer

        <Required>
        <Column("ORDER_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property OrderNumber() As Integer

        <Required>
        <Column("ORDER_DATETIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property OrderDateTime() As Date

        <Required>
        <Column("LAST_CHANGED_DATETIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property LastChangedDateTime() As Date

        <Required>
        <Column("START_YEAR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property StartYear() As Short

        <Required>
        <Column("END_YEAR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property EndYear() As Short

        <MaxLength(100)>
        <Column("ORDER_DURATION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property OrderDuration() As String

        <MaxLength(100)>
        <Column("REPORT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property Report() As String

        <MaxLength(100)>
        <Column("CLIENT_ALIAS", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property ClientAlias() As String

        <Required>
        <Column("IS_SUSPENDED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property IsSuspended() As Boolean

        <ForeignKey("ClientID")>
        Public Overridable Property Client As Database.Entities.Client

        Public Overridable Property ClientOrderDetails As ICollection(Of Database.Entities.ClientOrderDetail)

#End Region

#Region " Methods "

        Public Sub New()

            Me.ClientOrderDetails = New HashSet(Of Database.Entities.ClientOrderDetail)

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case Database.Entities.ClientOrder.Properties.OrderNumber.ToString

                    PropertyValue = Value

                    If Me.IsEntityBeingAdded Then

                        If (From Entity In Database.Procedures.ClientOrder.Load(DbContext)
                            Where Entity.OrderNumber = DirectCast(PropertyValue, Integer)).Any Then

                            IsValid = False

                            ErrorText = "Order Number exists."

                        End If

                    ElseIf (From Entity In Database.Procedures.ClientOrder.Load(DbContext)
                            Where Entity.OrderNumber = DirectCast(PropertyValue, Integer) AndAlso
                                  Entity.ID <> Me.ID).Any Then

                        IsValid = False

                        ErrorText = "Order Number exists."

                    End If

                    If PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Invalid order number."

                    End If

                Case Database.Entities.ClientOrder.Properties.StartYear.ToString

                    PropertyValue = Value

                    If PropertyValue < 2010 OrElse PropertyValue > 2079 Then

                        IsValid = False

                        ErrorText = "Invalid start year."

                        'ElseIf Math.Abs(PropertyValue - Me.EndYear) > 1 Then

                        '    IsValid = False

                        '    ErrorText = "Start year and end year should not be more than one year apart."

                    ElseIf PropertyValue >= Me.EndYear Then

                        IsValid = False

                        ErrorText = "Start year must be before end year."

                    End If

                Case Database.Entities.ClientOrder.Properties.EndYear.ToString

                    PropertyValue = Value

                    If PropertyValue < 2010 OrElse PropertyValue > 2079 Then

                        IsValid = False

                        ErrorText = "Invalid end year."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
