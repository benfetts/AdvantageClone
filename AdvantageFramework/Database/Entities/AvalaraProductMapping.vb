Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.AVALARA_PRODUCT_MAPPING")>
    Public Class AvalaraProductMapping
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            SalesClassCode
            FunctionCode
            AvalaraTaxID
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = 0
        Private _SalesClassCode As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _AvalaraTaxID As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AVALARA_PRODUCT_MAPPING_ID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DBType:="int NOT NULL IDENTITY"), _
        System.ComponentModel.DisplayName("ID"), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)> _
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SC_CODE", Storage:="_SalesClassCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("SalesClassCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, PropertyType:=BaseClasses.PropertyTypes.SalesClassCode)>
		Public Property SalesClassCode() As String
			Get
				SalesClassCode = _SalesClassCode
			End Get
			Set(ByVal value As String)
				_SalesClassCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FNC_CODE", Storage:="_FunctionCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("FunctionCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.FunctionCode)>
		Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AVALARA_TAX_ID", Storage:="_AvalaraTaxID", DBType:="int"), _
        System.ComponentModel.DisplayName("AvalaraTaxID"), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.AvalaraTaxID)> _
        Public Property AvalaraTaxID() As Nullable(Of Integer)
            Get
                AvalaraTaxID = _AvalaraTaxID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _AvalaraTaxID = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        
#End Region

    End Class

End Namespace

