Namespace Database.Core

    <Serializable()>
    Public Class JobComponent
        Inherits AdvantageFramework.BaseClasses.BaseCore

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobNumber
            Number
            ID
            JobProcessNumber
            Description
        End Enum

#End Region

#Region " Variables "

        Private _JobNumber As Integer = Nothing
        Private _Number As Short = Nothing
        Private _Description As String = Nothing
        Private _ID As Integer = Nothing
        Private _JobProcessNumber As Nullable(Of Short) = Nothing

#End Region

#Region " Properties "

        Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Integer)
                _JobNumber = value
            End Set
        End Property
        Public Property Number() As Short
            Get
                Number = _Number
            End Get
            Set(ByVal value As Short)
                _Number = value
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
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        Public Property JobProcessNumber() As Nullable(Of Short)
            Get
                JobProcessNumber = _JobProcessNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _JobProcessNumber = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Shadows Function ToString(ByVal WithDescription As Boolean)

            If WithDescription Then

                ToString = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(Me.Number, 2, "0", True, True) & " - " & Me.Description).Trim

            Else

                ToString = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(Me.Number, 2, "0", True, True)).Trim

            End If

        End Function
        Public Sub New()


        End Sub
        Public Sub New(ByVal JobComponent As Object)

            MyBase.SetValues(JobComponent)

        End Sub

#End Region

    End Class

End Namespace