Namespace Database.Core

    <Serializable()>
    Public Class Vendor
        Inherits AdvantageFramework.BaseClasses.BaseCore

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Name
            VendorCategory
            IsActive
        End Enum

#End Region

#Region " Variables "

        Private _Code As String = Nothing
        Private _Name As String = Nothing
        Private _VendorCategory As String = Nothing
        Private _ActiveFlag As Nullable(Of Short) = Nothing

#End Region

#Region " Properties "

        Public Property Code() As String
            Get
                Code = _Code
            End Get
            Set(ByVal value As String)
                _Code = value
            End Set
        End Property
        Public Property Name() As String
            Get
                Name = _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property
        Public Property VendorCategory() As String
            Get
                VendorCategory = _VendorCategory
            End Get
            Set(ByVal value As String)
                _VendorCategory = value
            End Set
        End Property
        Public Property ActiveFlag() As Nullable(Of Short)
            Get
                ActiveFlag = _ActiveFlag
            End Get
            Set(ByVal value As Nullable(Of Short))
                _ActiveFlag = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Name

        End Function
        Public Sub New()


        End Sub
        Public Sub New(ByVal Vendor As Object)

            MyBase.SetValues(Vendor)

        End Sub

#End Region

    End Class

End Namespace