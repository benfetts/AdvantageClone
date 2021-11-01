Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.IMP_AVALARA_TAX_STAGING")>
    Public Class ImportAvalaraTaxStaging
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ImportID
            BatchName
            IsNew
            IsOnHold
            Code
            Description
            LongDescription
            IsInactive
        End Enum

#End Region

#Region " Variables "

        Private _ImportID As Integer = 0
        Private _BatchName As String = Nothing
        Private _IsNew As Boolean = False
        Private _IsOnHold As Boolean = False
        Private _Code As String = Nothing
        Private _Description As String = Nothing
        Private _LongDescription As String = Nothing
        Private _IsInactive As Boolean = False

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="IMPORT_ID", Storage:="_ImportID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DBType:="int NOT NULL IDENTITY"), _
        System.ComponentModel.DisplayName("ImportID"), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)> _
        Public Property ImportID() As Integer
            Get
                ImportID = _ImportID
            End Get
            Set(ByVal value As Integer)
                _ImportID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="BATCH_NAME", Storage:="_BatchName", DbType:="varchar"),
		System.ComponentModel.DisplayName("BatchName"),
		System.ComponentModel.DataAnnotations.MaxLength(50),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
		Public Property BatchName() As String
			Get
				BatchName = _BatchName
			End Get
			Set(ByVal value As String)
				_BatchName = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="IS_NEW", Storage:="_IsNew", DbType:="bit"),
		System.ComponentModel.DisplayName("IsNew"),
		AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox, IsReadOnlyColumn:=True)>
		Public Property IsNew() As Boolean
			Get
				IsNew = _IsNew
			End Get
			Set(ByVal value As Boolean)
				_IsNew = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ON_HOLD", Storage:="_IsOnHold", DbType:="bit"),
		System.ComponentModel.DisplayName("IsOnHold"),
		AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsOnHold() As Boolean
			Get
				IsOnHold = _IsOnHold
			End Get
			Set(ByVal value As Boolean)
				_IsOnHold = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CODE", Storage:="_Code", DbType:="varchar"),
		System.ComponentModel.DisplayName("Code"),
		System.ComponentModel.DataAnnotations.MaxLength(8),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
			Get
				Code = _Code
			End Get
			Set(ByVal value As String)
				_Code = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DESCRIPTION", Storage:="_Description", DbType:="varchar"),
		System.ComponentModel.DisplayName("Description"),
		System.ComponentModel.DataAnnotations.MaxLength(300)>
		Public Property Description() As String
			Get
				Description = _Description
			End Get
			Set(ByVal value As String)
				_Description = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LONG_DESCRIPTION", Storage:="_LongDescription", DbType:="varchar"),
		System.ComponentModel.DisplayName("LongDescription"),
		System.ComponentModel.DataAnnotations.MaxLength(8000)>
		Public Property LongDescription() As String
            Get
                LongDescription = _LongDescription
            End Get
            Set(ByVal value As String)
                _LongDescription = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="INACTIVE_FLAG", Storage:="_IsInactive", DBType:="bit"), _
        System.ComponentModel.DisplayName("IsInactive"), _
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)> _
        Public Property IsInactive() As Boolean
            Get
                IsInactive = _IsInactive
            End Get
            Set(ByVal value As Boolean)
                _IsInactive = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging.Properties.Code.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If Me.IsNew Then

                            If (From Entity In DirectCast(Me.DataContext, AdvantageFramework.Database.DataContext).AvalaraTaxes _
                                    Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper _
                                    Select Entity).Any Then

                                IsValid = False

                                ErrorText = "Code already exists in the system."

                            Else

                                ErrorText = AdvantageFramework.BaseClasses.ValidatePropertyType(DbContext, DataContext, BaseClasses.PropertyTypes.Code, Value, IsValid)

                            End If

                        Else

                            If (From Entity In DirectCast(Me.DataContext, AdvantageFramework.Database.DataContext).AvalaraTaxes _
                                    Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                                    Select Entity).Any = False Then

                                IsValid = False

                                ErrorText = "Code does not exist in the system."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function


#End Region

    End Class

End Namespace
