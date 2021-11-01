Namespace Attributes

    <AttributeUsage(AttributeTargets.[Property], Inherited:=False, AllowMultiple:=False)>
    Public NotInheritable Class DecimalPrecisionAttribute
        Inherits Attribute

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Precision
            Scale
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Precision() As Integer
        Public Property Scale() As Integer

#End Region

#Region " Methods "

        Public Sub New(Precision As Integer, Scale As Integer)

            Me.Precision = Precision
            Me.Scale = Scale

        End Sub

#End Region

    End Class

End Namespace


