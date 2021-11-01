Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.AVALARA_TAX")>
    Public Class AvalaraTax
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Code
            Description
            IsInactive
            LongDescription
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = 0
        Private _Code As String = ""
        Private _Description As String = ""
        Private _IsInactive As Boolean = False
        Private _LongDescription As String = ""

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AVALARA_TAX_ID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DBType:="int NOT NULL IDENTITY"), _
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
		System.ComponentModel.DataAnnotations.MaxLength(8000),
		AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
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
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
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

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.AvalaraTax.Properties.Code.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If Me.IsEntityBeingAdded() Then

                            If (From Entity In DirectCast(Me.DataContext, AdvantageFramework.Database.DataContext).AvalaraTaxes
                                Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                                Select Entity).Any Then

                                IsValid = False

                                ErrorText = "Please enter a unique code."

                            End If

                        Else

                            If (From Entity In DirectCast(Me.DataContext, AdvantageFramework.Database.DataContext).AvalaraTaxes _
                                        Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso _
                                              Entity.ID <> Me.ID
                                        Select Entity).Any Then

                                IsValid = False

                                ErrorText = "Please enter a unique code."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace

