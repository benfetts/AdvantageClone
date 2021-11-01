Namespace EmployeeTimesheet.Classes

    <Serializable()>
    Public Class DayStatus
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Enum "

        Public Enum Properties
            DayDate
            TotalHours
            StandardHours
            MissingHours
            PercentOfStandardHours
            Status
            ApprovalNotes
        End Enum

#End Region

#Region " Variables "

        Private _DayDate As Date = Nothing
        Private _TotalHours As Decimal = 0
        Private _StandardHours As Decimal = 0
        Private _Status As Short = 0
        Private _ApprovalNotes As String = ""

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Date")>
        Public Property DayDate As Date
            Get
                DayDate = _DayDate
            End Get
            Set(value As Date)
                _DayDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True)>
        Public Property TotalHours As Decimal
            Get
                TotalHours = _TotalHours
            End Get
            Set(value As Decimal)
                _TotalHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property StandardHours As Decimal
            Get
                StandardHours = _StandardHours
            End Get
            Set(value As Decimal)
                _StandardHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property MissingHours As Decimal
            Get
                MissingHours = StandardHours - TotalHours
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property PercentOfStandardHours As Decimal
            Get

                If StandardHours <> 0 Then

                    PercentOfStandardHours = TotalHours / StandardHours

                Else

                    PercentOfStandardHours = 0

                End If

            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Status")>
        Public Property Status As Short
            Get
                Status = _Status
            End Get
            Set(value As Short)
                _Status = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ApprovalNotes As String
            Get
                ApprovalNotes = _ApprovalNotes
            End Get
            Set(value As String)
                _ApprovalNotes = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
