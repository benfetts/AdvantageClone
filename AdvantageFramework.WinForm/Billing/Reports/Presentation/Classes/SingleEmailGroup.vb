Namespace Billing.Reports.Presentation.Classes

    Public Class SingleEmailGroup
        Implements IEquatable(Of SingleEmailGroup)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ClientCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property DivisionCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ProductCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Type() As String

#End Region

#Region " Methods "

        Public Sub New(AutoEmailContact As AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact)

            Me.ClientCode = AutoEmailContact.ClientCode
            Me.DivisionCode = AutoEmailContact.DivisionCode
            Me.ProductCode = AutoEmailContact.ProductCode
            Me.Type = AutoEmailContact.Type

        End Sub
        Public Shadows Function Equals(other As SingleEmailGroup) As Boolean Implements IEquatable(Of SingleEmailGroup).Equals

            Dim IsEqualTo As Boolean = False

            If other IsNot Nothing Then

                If other.ClientCode = Me.ClientCode AndAlso other.DivisionCode = Me.DivisionCode AndAlso
                        other.ProductCode = Me.ProductCode AndAlso other.Type = Me.Type Then

                    IsEqualTo = True

                End If

            End If

            Equals = IsEqualTo

        End Function

#End Region

    End Class

End Namespace
