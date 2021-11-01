Namespace AvaTax.Classes

    <Serializable> _
    Public Class OfficeCompanyCode
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            OfficeCode
            AvaTaxCompanyCode
        End Enum

#End Region

#Region " Variables "

        Private _OfficeCode As String = Nothing
        Private _AvaTaxCompanyCode As String = Nothing
        
#End Region

#Region " Properties "

        Public Overrides ReadOnly Property AttachedEntityType As Type
            Get
                AttachedEntityType = GetType(AdvantageFramework.Database.Entities.Office)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, IsReadOnlyColumn:=True)>
        Public Property OfficeCode As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(ByVal value As String)
                _OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="AvaTax Company Code")>
        Public Property AvaTaxCompanyCode As String
            Get
                AvaTaxCompanyCode = _AvaTaxCompanyCode
            End Get
            Set(ByVal value As String)
                _AvaTaxCompanyCode = value
            End Set
        End Property
       
#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal OfficeCode As String, ByVal AvaTaxCompanyCode As String)

            _OfficeCode = OfficeCode
            _AvaTaxCompanyCode = AvaTaxCompanyCode

        End Sub

#End Region

    End Class

End Namespace