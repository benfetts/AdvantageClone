Namespace Importing.Classes

    <Serializable()>
    Public Class StrataBroadcastDetail
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            OrderID
            Week
            Spots
            Cost
            Voucher
            LineNumber
        End Enum

#End Region

#Region " Variables "

        Private _OrderID As Integer = 0
        Private _Week As Nullable(Of Date) = Nothing
        Private _Spots As Nullable(Of Integer) = Nothing
        Private _Cost As Nullable(Of Decimal) = Nothing
        Private _Voucher As String = Nothing
        Private _OrderLineID As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OrderID() As Integer
            Get
                OrderID = _OrderID
            End Get
            Set(value As Integer)
                _OrderID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Week() As Nullable(Of Date)
            Get
                Week = _Week
            End Get
            Set(value As Nullable(Of Date))
                _Week = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Spots() As Nullable(Of Integer)
            Get
                Spots = _Spots
            End Get
            Set(value As Nullable(Of Integer))
                _Spots = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public Property Cost() As Nullable(Of Decimal)
            Get
                Cost = _Cost
            End Get
            Set(value As Nullable(Of Decimal))
                _Cost = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Voucher() As String
            Get
                Voucher = _Voucher
            End Get
            Set(value As String)
                _Voucher = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OrderLineID() As Nullable(Of Integer)
            Get
                OrderLineID = _OrderLineID
            End Get
            Set(value As Nullable(Of Integer))
                _OrderLineID = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal FileLineData As String)

            Try

                _OrderID = CInt(Mid(FileLineData, 1, 8).Trim)

            Catch ex As Exception
                _OrderID = 0
            End Try

            Try

                _Week = CDate(Mid(FileLineData, 9, 8).Trim)

            Catch ex As Exception
                _Week = Nothing
            End Try

            Try

                _Spots = CDec(Mid(FileLineData, 17, 3).Trim)

            Catch ex As Exception
                _Spots = Nothing
            End Try

            Try

                _Cost = CDec(Mid(FileLineData, 20, 10).Trim)

            Catch ex As Exception
                _Cost = Nothing
            End Try

            _Voucher = Mid(FileLineData, 30, 8).Trim

            Try

                _OrderLineID = CInt(Mid(FileLineData, 38, 8).Trim)

            Catch ex As Exception
                _OrderLineID = Nothing
            End Try

            If _OrderLineID IsNot Nothing Then

                _Cost = FormatNumber(_Cost.GetValueOrDefault(0) * _Spots.GetValueOrDefault(0), 2)

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = _OrderID.ToString

        End Function

#End Region

    End Class

End Namespace

