Namespace Database.Views

    <Table("V_BRDCAST_ORDER_DTL")>
    Public Class BroadcastOrderDetailView
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            DetailID
            MediaType
            AccountPayableID
            SequenceNumber
            VendorCode
            VendorName
            Vendor
            OrderNumber
            OrderLineNumber
            RunDate
            RunTime
            RunDateTime
            DayOfWeekNumber
            Length
            AdNumber
            NetworkID
            ProgramName
            GrossRate
            Approved
            Comment
            ForeignGrossRate
        End Enum

#End Region

#Region " Variables "


#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
        <Column("DetailID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property DetailID() As Integer
        <Column("MediaType", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaType() As String
        <Column("AccountPayableID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property AccountPayableID() As Integer
        <Column("SequenceNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SequenceNumber() As Short
        <Column("VendorCode", TypeName:="varchar")>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property VendorCode() As String
        <Column("VendorName", TypeName:="varchar")>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property VendorName() As String
        <Column("Vendor", TypeName:="varchar")>
        <MaxLength(50)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property Vendor() As String
        <Column("OrderNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OrderNumber() As Integer
        <Column("OrderLineNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, IsReadOnlyColumn:=True, DisplayFormat:="", CustomColumnCaption:="Line")>
        Public Property OrderLineNumber() As Short?
        <Column("RunDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property RunDate() As Date?
        <NotMapped>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="t", CustomColumnCaption:="Run Time")>
        Public Property RunDateTime As Date?
            Get
                If Me.RunTime.HasValue Then
                    Return New Date(Now.Year, Now.Month, Now.Day, Me.RunTime.Value.Hours, Me.RunTime.Value.Minutes, 0)
                Else
                    Return Nothing
                End If
            End Get
            Set(value As Date?)
                If value.HasValue Then
                    Me.RunTime = New TimeSpan(value.Value.Hour, value.Value.Minute, 0)
                Else
                    Me.RunTime = Nothing
                End If
            End Set
        End Property
        <Column("RunTime")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property RunTime() As TimeSpan?
        <Column("DayOfWeekNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property DayOfWeekNumber() As Short?
        <Column("Length")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", MinValue:=0, UseMinValue:=True)>
        Public Property Length() As Short?
        <NotMapped>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Foreign Rate")>
        Public Property ForeignGrossRate As Decimal
        <Column("GrossRate")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2", CustomColumnCaption:="Rate")>
        Public Property GrossRate() As Decimal
        <Column("AdNumber", TypeName:="varchar")>
        <MaxLength(30)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.AdNumber)>
        Public Property AdNumber() As String
        <Column("NetworkID", TypeName:="varchar")>
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.CableNetworkStation)>
        Public Property NetworkID() As String
        <Column("ProgramName", TypeName:="varchar")>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProgramName() As String
        <Column("Approved")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.StandardCheckBox)>
        Public Property Approved() As Short?
        <Column("Comment", TypeName:="varchar")>
        <MaxLength(254)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property Comment() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.OrderNumber.ToString

        End Function
        Public Function GetAccountPayableRadioBroadcastDetail(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail

            Dim AccountPayableRadioBroadcastDetail As Entities.AccountPayableRadioBroadcastDetail = Nothing
            Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
            Dim IsNetOrder As Boolean = False

            If Me.IsEntityBeingAdded() = True OrElse Me.DetailID = 0 Then

                AccountPayableRadioBroadcastDetail = New Entities.AccountPayableRadioBroadcastDetail

            Else

                AccountPayableRadioBroadcastDetail = AdvantageFramework.Database.Procedures.AccountPayableRadioBroadcastDetail.LoadByID(DbContext, Me.DetailID)

            End If

            If AccountPayableRadioBroadcastDetail IsNot Nothing Then

                RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, Me.OrderNumber)

                If RadioOrder IsNot Nothing AndAlso RadioOrder.NetGross.GetValueOrDefault(1) = 0 Then

                    IsNetOrder = True

                End If

                AccountPayableRadioBroadcastDetail.AccountPayableID = Me.AccountPayableID
                AccountPayableRadioBroadcastDetail.AccountPayableSequenceNumber = Me.SequenceNumber
                AccountPayableRadioBroadcastDetail.OrderNumber = Me.OrderNumber
                AccountPayableRadioBroadcastDetail.OrderLineNumber = Me.OrderLineNumber

                If Me.RunDate.HasValue Then

                    AccountPayableRadioBroadcastDetail.RunDate = Me.RunDate
                    AccountPayableRadioBroadcastDetail.DayOfWeek = Me.RunDate.Value.DayOfWeek

                    If Me.RunDate.Value.DayOfWeek = DayOfWeek.Sunday Then

                        AccountPayableRadioBroadcastDetail.DayOfWeek = 7

                    End If

                Else

                    AccountPayableRadioBroadcastDetail.RunDate = Nothing
                    AccountPayableRadioBroadcastDetail.DayOfWeek = Nothing

                End If

                AccountPayableRadioBroadcastDetail.TimeOfDay = Me.RunTime
                AccountPayableRadioBroadcastDetail.Length = Me.Length
                AccountPayableRadioBroadcastDetail.AdNumber = Me.AdNumber

                If IsNetOrder Then

                    AccountPayableRadioBroadcastDetail.NetRate = Me.GrossRate

                Else

                    AccountPayableRadioBroadcastDetail.NetRate = Me.GrossRate * 0.85

                End If

                AccountPayableRadioBroadcastDetail.GrossRate = Me.GrossRate
                '_AccountPayableRadioBroadcastDetail.Piggyback = Me.Piggyback
                AccountPayableRadioBroadcastDetail.ProgramName = Me.ProgramName
                AccountPayableRadioBroadcastDetail.NetworkID = Me.NetworkID

            End If

            Return AccountPayableRadioBroadcastDetail

        End Function
        Public Function GetAccountPayableTVBroadcastDetail(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail

            Dim AccountPayableTVBroadcastDetail As Entities.AccountPayableTVBroadcastDetail = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
            Dim IsNetOrder As Boolean = False

            If Me.IsEntityBeingAdded() = True OrElse Me.DetailID = 0 Then

                AccountPayableTVBroadcastDetail = New Entities.AccountPayableTVBroadcastDetail

            Else

                AccountPayableTVBroadcastDetail = AdvantageFramework.Database.Procedures.AccountPayableTVBroadcastDetail.LoadByID(DbContext, Me.DetailID)

            End If

            If AccountPayableTVBroadcastDetail IsNot Nothing Then

                TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, Me.OrderNumber)

                If TVOrder IsNot Nothing AndAlso TVOrder.NetGross.GetValueOrDefault(1) = 0 Then

                    IsNetOrder = True

                End If

                AccountPayableTVBroadcastDetail.AccountPayableID = Me.AccountPayableID
                AccountPayableTVBroadcastDetail.AccountPayableSequenceNumber = Me.SequenceNumber
                AccountPayableTVBroadcastDetail.OrderNumber = Me.OrderNumber
                AccountPayableTVBroadcastDetail.OrderLineNumber = Me.OrderLineNumber

                If Me.RunDate.HasValue Then

                    AccountPayableTVBroadcastDetail.RunDate = Me.RunDate
                    AccountPayableTVBroadcastDetail.DayOfWeek = Me.RunDate.Value.DayOfWeek

                    If Me.RunDate.Value.DayOfWeek = DayOfWeek.Sunday Then

                        AccountPayableTVBroadcastDetail.DayOfWeek = 7

                    End If

                Else

                    AccountPayableTVBroadcastDetail.RunDate = Nothing
                    AccountPayableTVBroadcastDetail.DayOfWeek = Nothing

                End If

                AccountPayableTVBroadcastDetail.TimeOfDay = Me.RunTime
                AccountPayableTVBroadcastDetail.Length = Me.Length
                AccountPayableTVBroadcastDetail.AdNumber = Me.AdNumber

                If IsNetOrder Then

                    AccountPayableTVBroadcastDetail.NetRate = Me.GrossRate

                Else

                    AccountPayableTVBroadcastDetail.NetRate = Me.GrossRate * 0.85

                End If

                AccountPayableTVBroadcastDetail.GrossRate = Me.GrossRate
                '_AccountPayableTVBroadcastDetail.Piggyback = Me.Piggyback
                AccountPayableTVBroadcastDetail.ProgramName = Me.ProgramName
                AccountPayableTVBroadcastDetail.NetworkID = Me.NetworkID

            End If

            Return AccountPayableTVBroadcastDetail

        End Function
        Public Sub ValidateOrderLine(ByVal OrderLines As String(), ByRef IsValid As Boolean)

            'objects
            Dim OrderNumber As Integer = Nothing
            Dim OrderLineNumber As Short = Nothing
            Dim MatchFound As Boolean = False
            Dim OrderNumberErrorText As String = ""
            Dim OrderLineNumberErrorText As String = ""

            For Each OrderLine In OrderLines

                OrderNumber = Nothing
                OrderLineNumber = Nothing

                With OrderLine.Split("|")

                    Try

                        OrderNumber = CInt(.First)

                    Catch ex As Exception
                        OrderNumber = Nothing
                    End Try

                    Try

                        OrderLineNumber = CShort(.Last)

                    Catch ex As Exception
                        OrderLineNumber = Nothing
                    End Try

                End With

                If Me.OrderNumber = OrderNumber Then

                    'If Me.OrderLineNumber.HasValue Then

                    '    MatchFound = (Me.OrderLineNumber.Value = OrderLineNumber)

                    'Else

                    MatchFound = True

                    'End If

                End If

                If MatchFound Then

                    Exit For

                End If

            Next

            If Not MatchFound Then

                OrderNumberErrorText = "Please enter a valid Order Number."

                'If Me.OrderLineNumber.HasValue Then

                '    OrderLineNumberErrorText = "Please enter a valid Order Line Number."

                'End If

            End If

            _ErrorHashtable(Properties.OrderNumber.ToString) = OrderNumberErrorText
            _ErrorHashtable(Properties.OrderLineNumber.ToString) = OrderLineNumberErrorText

            IsValid = MatchFound

        End Sub
        Protected Overrides Sub FinalizeEntityPropertyValidation(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object, ByRef ErrorText As String,
                                                                 ByVal IsEntityKey As Boolean, ByVal IsNullable As Boolean, ByVal IsRequired As Boolean, ByVal MaxLength As Integer,
                                                                 ByVal Precision As Long, ByVal Scale As Long, ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes)

            Select Case PropertyName

                Case AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.AdNumber.ToString

                    ErrorText = ""
                    IsValid = True

            End Select

        End Sub
        'Public Overrides Function ValidateCustomProperties(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String


        '    'objects
        '    Dim ErrorText As String = ""
        '    Dim PropertyValue As Object = Nothing

        '    PropertyValue = Value

        '    Select Case PropertyName

        '        Case Properties.OrderNumber.ToString

        '            If PropertyValue IsNot Nothing Then

        '                If _OrderLines IsNot Nothing Then

        '                    If Not _OrderLines.Any(Function(line) CInt(line.Split("|").First) = CInt(PropertyValue)) Then

        '                        IsValid = False

        '                    End If

        '                End If

        '            End If

        '        Case Properties.OrderLineNumber.ToString

        '            If PropertyValue IsNot Nothing Then

        '                If _OrderLines IsNot Nothing Then

        '                    If Not _OrderLines.Any(Function(line) CInt(line.Split("|").First) = Me.OrderNumber AndAlso CShort(line.Split("|").Last) = CShort(PropertyValue)) Then

        '                        IsValid = False

        '                    End If

        '                End If

        '            End If

        '    End Select

        '    ValidateCustomProperties = ErrorText

        'End Function
        'Public Sub SetValidOrderLines(ByVal OrderLines As String())

        '    _OrderLines = OrderLines

        'End Sub

        'Private _OrderLines As String() = Nothing

#End Region

    End Class

End Namespace
