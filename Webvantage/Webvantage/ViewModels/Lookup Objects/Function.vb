Namespace ViewModels.LookupObjects

    Public Class [Function]
        Inherits ViewModels.LookupObjects.BaseLookupObject

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            FunctionCode
            FunctionDescription
            FunctionType
            CPMFlag
            IncludeInactive
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property FunctionCode As String
        Public Property FunctionDescription As String
        Public Property FunctionType As String
        Public Property CPMFlag As Boolean
        Public Property IncludeInactive As Boolean
        Public Overrides ReadOnly Property SearchText As String
            Get
                Return (FunctionCode + Space(1) + FunctionDescription).ToLower
            End Get
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace


