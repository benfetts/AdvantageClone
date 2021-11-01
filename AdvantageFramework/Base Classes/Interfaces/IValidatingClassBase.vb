Namespace BaseClasses.Interfaces

    Public Interface IValidatingClassBase

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Function IsRequiredProperty(ByVal Type As System.Type, ByVal PropertyName As String) As Boolean
        Function CreateXML() As String
        Function ValidateEntity(ByRef IsValid As Boolean) As String
        Function ValidateEntityProperty(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String
        Function HasError() As Boolean

#End Region

    End Interface

End Namespace