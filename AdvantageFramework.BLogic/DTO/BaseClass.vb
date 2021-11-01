'Namespace DTO

'	Public Class BaseClass
'		Implements System.ComponentModel.IDataErrorInfo

'#Region " Constants "



'#End Region

'#Region " Enum "



'#End Region

'#Region " Variables "

'		Protected _ErrorHashtable As Hashtable = Nothing
'		Protected _EntityError As String = ""

'#End Region

'#Region " Properties "

'		<System.ComponentModel.Browsable(False),
'		Xml.Serialization.XmlIgnore()>
'		Public ReadOnly Property [Error] As String Implements System.ComponentModel.IDataErrorInfo.Error
'			Get
'				[Error] = _EntityError
'			End Get
'		End Property
'		<System.ComponentModel.Browsable(False),
'		Xml.Serialization.XmlIgnore()>
'		Default Public ReadOnly Property Item(PropertyName As String) As String Implements System.ComponentModel.IDataErrorInfo.Item
'			Get
'				Item = LoadErrorText(PropertyName)
'			End Get
'		End Property

'#End Region

'#Region " Methods "

'		Public Sub New()

'			_ErrorHashtable = New Hashtable

'		End Sub
'		Public Sub SetEntityError(EntityError As String)

'			_EntityError = EntityError

'		End Sub
'		Public Sub SetPropertyError(PropertyName As String, ErrorText As String)

'			_ErrorHashtable(PropertyName) = ErrorText

'			_EntityError = String.Empty

'			For Each PropName In _ErrorHashtable.Keys.OfType(Of String)

'				If String.IsNullOrWhiteSpace(_ErrorHashtable(PropName)) = False Then

'					_EntityError = IIf(_EntityError = "", _ErrorHashtable(PropName), _EntityError & Environment.NewLine & _ErrorHashtable(PropName))

'				End If

'			Next

'		End Sub
'		Public Overridable Function LoadErrorText(PropertyName As String) As String

'			'objects
'			Dim ErrorText As String = ""

'			Try

'				ErrorText = _ErrorHashtable(PropertyName)

'			Catch ex As Exception
'				ErrorText = ""
'			Finally
'				LoadErrorText = ErrorText
'			End Try

'		End Function
'		Public Overridable Function HasError() As Boolean

'			'objects
'			Dim EntityHasError As Boolean = False

'			Try

'				If String.IsNullOrWhiteSpace(_EntityError) = False Then

'					EntityHasError = True

'				End If

'			Catch ex As Exception
'				EntityHasError = False
'			End Try

'			HasError = EntityHasError

'		End Function
'        Public Sub SetRequired(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal IsRequired As Boolean)

'            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

'            Try

'                EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

'            Catch ex As Exception
'                EntityAttribute = Nothing
'            End Try

'            If EntityAttribute IsNot Nothing Then

'                EntityAttribute.IsRequired = IsRequired

'            End If

'        End Sub
'        Public Overridable Function DuplicateEntity() As AdvantageFramework.DTO.BaseClass

'            'objects
'            Dim Entity As AdvantageFramework.DTO.BaseClass = Nothing
'            Dim Browsable As Boolean = False

'            Try

'                If Me.GetType.GetConstructor(Type.EmptyTypes) IsNot Nothing Then

'                    Entity = System.Activator.CreateInstance(Me.GetType)

'                End If

'            Catch ex As Exception
'                Entity = Nothing
'            End Try

'            If Entity IsNot Nothing Then

'                For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(Me.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)()

'                    Browsable = True

'                    If PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.BrowsableAttribute).Any Then

'                        Try

'                            Browsable = PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.BrowsableAttribute).FirstOrDefault.Browsable

'                        Catch ex As Exception
'                            Browsable = True
'                        End Try

'                    End If

'                    If Browsable Then

'                        PropertyDescriptor.SetValue(Entity, PropertyDescriptor.GetValue(Me))

'                    End If

'                Next

'            End If

'            DuplicateEntity = Entity

'        End Function

'#End Region

'    End Class

'End Namespace
