Namespace Database.Classes

    <Serializable()>
    Public Class OfficeOverheadSet
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            OverheadAccountCode
            OverheadAccountDescription
            Code
            OfficeCode
        End Enum

#End Region

#Region " Variables "

        Private _OfficeOverheadSet As AdvantageFramework.Database.Entities.OfficeOverheadSet = Nothing
        Private _OverheadAccountDescription As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False), _
        System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property OfficeOverheadSet As AdvantageFramework.Database.Entities.OfficeOverheadSet
            Get
                OfficeOverheadSet = _OfficeOverheadSet
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Overhead Set", PropertyType:=BaseClasses.PropertyTypes.OverheadAccountCode)>
        Public Property OverheadAccountCode() As String
            Get
                OverheadAccountCode = _OfficeOverheadSet.OverheadAccountCode
            End Get
            Set(value As String)
                _OfficeOverheadSet.OverheadAccountCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Description", IsReadOnlyColumn:=True)>
        Public Property OverheadAccountDescription() As String
            Get
                OverheadAccountDescription = _OverheadAccountDescription
            End Get
            Set(value As String)
                _OverheadAccountDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Code() As String
            Get
                Code = _OfficeOverheadSet.Code
            End Get
            Set(value As String)
                _OfficeOverheadSet.Code = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeOverheadSet.OfficeCode
            End Get
            Set(value As String)
                _OfficeOverheadSet.OfficeCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _OfficeOverheadSet = New AdvantageFramework.Database.Entities.OfficeOverheadSet

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeOverheadSet As AdvantageFramework.Database.Entities.OfficeOverheadSet)

            Dim OverheadAccount As AdvantageFramework.Database.Entities.OverheadAccount = Nothing

            _OfficeOverheadSet = OfficeOverheadSet

            OverheadAccount = AdvantageFramework.Database.Procedures.OverheadAccount.LoadSingleByCode(DbContext, OfficeOverheadSet.OverheadAccountCode)

            If OverheadAccount IsNot Nothing Then

                _OverheadAccountDescription = OverheadAccount.Description

            End If
            
        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.OverheadAccountCode

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.OfficeOverheadSet.Properties.Code.ToString

                    PropertyValue = Value

                    If Me.OfficeOverheadSet.DatabaseAction = Action.Inserting Then

                        If String.IsNullOrWhiteSpace(PropertyValue) = False Then

                            If AdvantageFramework.Database.Procedures.OfficeOverheadSet.LoadByOfficeCode(Me.DataContext, Me.OfficeCode).Where(Function(OOS) OOS.Code = DirectCast(PropertyValue, String)).Any Then

                                IsValid = False
                                ErrorText = "Overhead set already exists."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace