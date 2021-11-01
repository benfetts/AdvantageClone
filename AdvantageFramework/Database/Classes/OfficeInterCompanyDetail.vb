Namespace Database.Classes

    <Serializable()>
    Public Class OfficeInterCompanyDetail
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            OfficeInterCompany
            OfficeCode
            Code
            GeneralLedgerCrossReferenceCode
            DueFromGLACode
            DueToGLACode
        End Enum

#End Region

#Region " Variables "

        Private _GeneralLedgerCrossReferenceCode As String = Nothing
        Private _OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany = Nothing
        Private _DueFromGLACode As String = Nothing
        Private _DueToGLACode As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False), _
        System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany
            Get
                OfficeInterCompany = _OfficeInterCompany
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property OfficeCode As String
            Get
                OfficeCode = _OfficeInterCompany.OfficeCode
            End Get
            Set(ByVal value As String)
                _OfficeInterCompany.OfficeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Inter-Co Office", IsReadOnlyColumn:=True, PropertyType:=BaseClasses.PropertyTypes.Code)>
        Public Property Code As String
            Get
                Code = _OfficeInterCompany.Code
            End Get
            Set(ByVal value As String)
                _OfficeInterCompany.Code = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="GL Cross Reference", IsReadOnlyColumn:=True)>
        Public Property GeneralLedgerCrossReferenceCode As String
            Get
                GeneralLedgerCrossReferenceCode = _GeneralLedgerCrossReferenceCode
            End Get
            Set(ByVal value As String)
                _GeneralLedgerCrossReferenceCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Office Account", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property DueFromGLACode As String
            Get
                DueFromGLACode = _DueFromGLACode
            End Get
            Set(ByVal value As String)
                _DueFromGLACode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Inter-Company Office Account", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property DueToGLACode As String
            Get
                DueToGLACode = _DueToGLACode
            End Get
            Set(ByVal value As String)
                _DueToGLACode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _OfficeInterCompany = New AdvantageFramework.Database.Entities.OfficeInterCompany

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany)

            _OfficeInterCompany = OfficeInterCompany

            _DueFromGLACode = OfficeInterCompany.DueFromGLACode
            _DueToGLACode = OfficeInterCompany.DueToGLACode

            Try

                _GeneralLedgerCrossReferenceCode = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByOfficeCode(DbContext, OfficeInterCompany.Code).Code

            Catch ex As Exception
                _GeneralLedgerCrossReferenceCode = ""
            End Try

        End Sub
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Sub SetRequiredFields()

            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            For Each PropertyDescriptor In PropertyDescriptors

                Select Case PropertyDescriptor.Name

                    Case AdvantageFramework.Database.Classes.OfficeInterCompanyDetail.Properties.OfficeCode.ToString

                        If Not String.IsNullOrWhiteSpace(Me.DueToGLACode) OrElse Not String.IsNullOrWhiteSpace(Me.DueFromGLACode) Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                    Case AdvantageFramework.Database.Classes.OfficeInterCompanyDetail.Properties.DueFromGLACode.ToString

                        If Not String.IsNullOrWhiteSpace(Me.DueToGLACode) Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                    Case AdvantageFramework.Database.Classes.OfficeInterCompanyDetail.Properties.DueToGLACode.ToString
                        
                        If Not String.IsNullOrWhiteSpace(Me.DueFromGLACode) Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                End Select

            Next

        End Sub

#End Region

    End Class

End Namespace

