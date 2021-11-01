Namespace WinForm.Presentation.Controls

    Public Class ListBox
        Inherits DevExpress.XtraEditors.ListBoxControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl

        Public Event ReloadComboBox()

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum [Type]
            [Default]
            Office
            Report
        End Enum

        Public Enum ExtraListBoxItems
            [Nothing] = 1
            Custom = 0
        End Enum

#End Region

#Region " Variables "

        Protected _ControlType As ListBox.Type = ListBox.Type.Default
        Protected _FormSettingsLoaded As Boolean = False
        Protected _ExtraListBoxItem As ExtraListBoxItems = ExtraListBoxItems.Nothing
        Protected _IsRequired As Boolean = False
        Protected _ExtraListBoxItemDisplayText As String = Nothing
        Protected _ExtraListBoxItemValueObject As Object = Nothing

#End Region

#Region " Properties "

        Public Property ControlType() As ListBox.Type
            Get
                ControlType = _ControlType
            End Get
            Set(value As ListBox.Type)
                _ControlType = value
                SetControlType()
            End Set
        End Property
        Public Shadows Property DataSource() As Object
            Get
                DataSource = MyBase.DataSource
            End Get
            Set(ByVal value As Object)
                LoadDataSource(value)
            End Set
        End Property
        Public Property ExtraListBoxItem() As ExtraListBoxItems
            Get
                ExtraListBoxItem = _ExtraListBoxItem
            End Get
            Set(ByVal value As ExtraListBoxItems)
                _ExtraListBoxItem = value
            End Set
        End Property
        Public Property ExtraListBoxItemDisplayText() As String
            Get
                ExtraListBoxItemDisplayText = _ExtraListBoxItemDisplayText
            End Get
            Set(value As String)
                _ExtraListBoxItemDisplayText = value
            End Set
        End Property
        Public Property ExtraListBoxItemValueObject() As Object
            Get
                ExtraListBoxItemValueObject = _ExtraListBoxItemValueObject
            End Get
            Set(value As Object)
                _ExtraListBoxItemValueObject = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.LookAndFeel.UseDefaultLookAndFeel = False
            Me.DoubleBuffered = True
            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form) Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl.LoadFormSettings

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso _
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Protected Sub SetControlType()

            Select Case _ControlType

                Case Type.Default

                    Me.ValueMember = ""
                    Me.DisplayMember = ""

                Case Type.Office

                    Me.ValueMember = "Code"
                    Me.DisplayMember = "Name"

                Case Type.Report

                    Me.ValueMember = "Code"
                    Me.DisplayMember = "Description"

            End Select

        End Sub
        Protected Sub LoadExtraListBoxItem(ByVal ExtraListBoxItem As ExtraListBoxItems, ByRef BindingSource As System.Windows.Forms.BindingSource)

            If ExtraListBoxItem = ExtraListBoxItems.Custom Then

                AddExtraListBoxItemToExistingDatasource(BindingSource, Me.ExtraListBoxItemDisplayText, Me.ExtraListBoxItemValueObject, True)

            ElseIf ExtraListBoxItem <> ExtraListBoxItems.Nothing Then

                AddExtraListBoxItemToExistingDatasource(BindingSource, "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraListBoxItem.ToString) & "]", AdvantageFramework.EnumUtilities.GetValue(ExtraListBoxItem.GetType, ExtraListBoxItem.ToString), True)

            End If

        End Sub
        Public Sub AddExtraListBoxItemToExistingDatasource(ByVal DisplayValue As String, ByVal Value As String, ByVal InsertInFirstPosition As Boolean)

            AddExtraListBoxItemToExistingDatasource(Me.DataSource, DisplayValue, Value, InsertInFirstPosition)

        End Sub
        Private Sub AddExtraListBoxItemToExistingDatasource(ByRef BindingSource As System.Windows.Forms.BindingSource, ByVal DisplayValue As String, ByVal Value As String, ByVal InsertInFirstPosition As Boolean)

            'objects
            Dim DataBoundType As System.Type = Nothing
            Dim NewListItem = Nothing
            Dim ParametersList As Generic.List(Of Object) = Nothing
            Dim ConstructorInfos() As System.Reflection.ConstructorInfo = Nothing
            Dim HasConstructor As Boolean = False

            AdvantageFramework.WinForm.Presentation.Controls.SuspendBindingOnABindingSource(BindingSource)

            Try

                DataBoundType = System.Type.GetType(BindingSource.List.AsQueryable.ElementType.AssemblyQualifiedName)

                ParametersList = New Generic.List(Of Object)

                For Each PropertyInfo In DataBoundType.GetProperties

                    If PropertyInfo.Name = Me.DisplayMember Then

                        If PropertyInfo.PropertyType Is GetType(String) Then

                            ParametersList.Add(DisplayValue)

                        End If

                    ElseIf PropertyInfo.Name = Me.ValueMember Then

                        If PropertyInfo.PropertyType Is GetType(String) Then

                            ParametersList.Add(CStr(Value))

                        ElseIf PropertyInfo.PropertyType Is GetType(Long) Then

                            ParametersList.Add(CLng(Value))

                        ElseIf PropertyInfo.PropertyType Is GetType(Decimal) Then

                            ParametersList.Add(CDec(Value))

                        ElseIf PropertyInfo.PropertyType Is GetType(Integer) Then

                            ParametersList.Add(CInt(Value))

                        ElseIf PropertyInfo.PropertyType Is GetType(Short) Then

                            ParametersList.Add(CShort(Value))

                        End If

                    End If

                Next
                
                ConstructorInfos = DataBoundType.GetConstructors()

                For Each ConstructorInfo In ConstructorInfos

                    If ConstructorInfo.GetParameters.Count = ParametersList.Count Then

                        HasConstructor = True
                        Exit For

                    End If

                Next

                If HasConstructor Then

                    NewListItem = System.Activator.CreateInstance(DataBoundType, ParametersList.ToArray)

                    If InsertInFirstPosition Then

                        BindingSource.Insert(0, NewListItem)

                    Else

                        BindingSource.Add(NewListItem)

                    End If

                End If

            Catch ex As Exception
                DataBoundType = Nothing
                NewListItem = Nothing
                ParametersList = Nothing
            End Try

            AdvantageFramework.WinForm.Presentation.Controls.ResumeBindingOnABindingSource(BindingSource)

        End Sub
        Protected Sub LoadDataSource(ByRef Value As Object)

            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            If Me.DesignMode = False Then

                BindingSource = New System.Windows.Forms.BindingSource

                BindingSource.DataSource = LoadDataSourceView(Value)

                If Value IsNot Nothing Then

                    If _ExtraListBoxItem <> ExtraListBoxItems.Nothing Then

                        If Me.DisplayMember = "" Then

                            Me.SetControlType()

                        End If

                        LoadExtraListBoxItem(_ExtraListBoxItem, BindingSource)

                    End If

                End If

                MyBase.DataSource = BindingSource

                If Me.DisplayMember = "" Then

                    Me.SetControlType()

                End If

            End If

        End Sub
        Protected Function LoadDataSourceView(ByVal Value As Object) As Object

            Dim View As Object = Nothing

            If TypeOf Value Is IEnumerable Then

                If TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Office) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Office)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.Report) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.Report)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)))

                Else

                    View = Value

                End If

            Else

                View = Value

            End If

            LoadDataSourceView = View

        End Function
        Protected Function LoadDataSourceView(ByVal Offices As IEnumerable(Of AdvantageFramework.Database.Entities.Office)) As Object

            LoadDataSourceView = (From Office In Offices.ToList _
                                  Select [Code] = Office.Code,
                                         [Name] = Office.ToString).ToList

        End Function
        Protected Function LoadDataSourceView(ByVal Reports As IEnumerable(Of AdvantageFramework.Security.Database.Entities.Report)) As Object

            LoadDataSourceView = (From Report In Reports.ToList _
                                  Select [Code] = Report.Code,
                                         [Description] = Report.ToString _
                                  Order By Description).ToList

        End Function
        Protected Function LoadDataSourceView(ByVal EnumObjectAttributes As IEnumerable(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)) As Object

            LoadDataSourceView = (From EnumObjectAttribute In EnumObjectAttributes.ToList _
                                  Select [Code] = EnumObjectAttribute.Code,
                                         [Description] = EnumObjectAttribute.Description _
                                  Order By Code).ToList

        End Function

#Region "  Control Event Handlers "



#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace