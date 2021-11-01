Namespace Database.Core

    <Serializable()>
    Public Class Job
        Inherits AdvantageFramework.BaseClasses.BaseCore

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Number
            OfficeCode
            ClientCode
            DivisionCode
            ProductCode
            Description
            IsActive
        End Enum

#End Region

#Region " Variables "

        Private _Number As Integer = Nothing
        Private _OfficeCode As String = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _Description As String = Nothing
        Private _IsOpen As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "

        Public Property Number() As Integer
            Get
                Number = _Number
            End Get
            Set(ByVal value As Integer)
                _Number = value
            End Set
        End Property
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(ByVal value As String)
                _OfficeCode = value
            End Set
        End Property
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property
        Public Property IsOpen() As Nullable(Of Integer)
            Get
                IsOpen = _IsOpen
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _IsOpen = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Shadows Function ToString(ByVal WithDescription As Boolean) As String

            If WithDescription Then

                ToString = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(Me.Number, 6, "0", True, True) & " - " & Me.Description).Trim

            Else

                ToString = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(Me.Number, 6, "0", True, True)).Trim

            End If

        End Function
        Public Sub New()


        End Sub
        Public Sub New(ByVal Job As Object)

            MyBase.SetValues(Job)

        End Sub

#End Region

    End Class

End Namespace