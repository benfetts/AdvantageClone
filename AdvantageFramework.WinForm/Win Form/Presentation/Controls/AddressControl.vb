Namespace WinForm.Presentation.Controls

    Public Class AddressControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl

        Public Event AddressChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _FormSettingsLoaded As Boolean = False
        Protected _Session As AdvantageFramework.Security.Session = Nothing
        Protected _ReadOnly As Boolean = False
        Protected _UserEntryChanged As Boolean = False
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _SuspendedForLoading As Boolean = False
        Protected _ShowCounty As Boolean = True
        Protected _ShowCountry As Boolean = True

#End Region

#Region " Properties "

        Public Property ShowCounty As Boolean
            Get
                ShowCounty = _ShowCounty
            End Get
            Set(ByVal value As Boolean)
                _ShowCounty = value
            End Set
        End Property
        Public Property ShowCountry As Boolean
            Get
                ShowCountry = _ShowCountry
            End Get
            Set(ByVal value As Boolean)
                _ShowCountry = value
            End Set
        End Property
        Public Property Title As String
            Get
                Title = GroupBoxControl_Address.Text
            End Get
            Set(ByVal value As String)
                GroupBoxControl_Address.Text = value
            End Set
        End Property
        Public Property Address As String
            Get
                Address = TextBoxAddress_Address.GetText
            End Get
            Set(ByVal value As String)
                TextBoxAddress_Address.Text = value
            End Set
        End Property
        Public Property Address2 As String
            Get
                Address2 = TextBoxAddress_Address2.GetText
            End Get
            Set(ByVal value As String)
                TextBoxAddress_Address2.Text = value
            End Set
        End Property
        Public Property Address3 As String
            Get
                Address3 = TextBoxAddress_Address3.GetText
            End Get
            Set(ByVal value As String)
                TextBoxAddress_Address3.Text = value
            End Set
        End Property
        Public Property County As String
            Get
                County = TextBoxAddress_County.GetText
            End Get
            Set(ByVal value As String)
                TextBoxAddress_County.Text = value
            End Set
        End Property
        Public Property City As String
            Get
                City = TextBoxAddress_City.GetText
            End Get
            Set(ByVal value As String)
                TextBoxAddress_City.Text = value
            End Set
        End Property
        Public Property Zip As String
            Get
                Zip = TextBoxAddress_Zip.GetText
            End Get
            Set(ByVal value As String)
                TextBoxAddress_Zip.Text = value
            End Set
        End Property
        Public Property State As String
            Get
                State = TextBoxAddress_State.GetText
            End Get
            Set(ByVal value As String)
                TextBoxAddress_State.Text = value
            End Set
        End Property
        Public Property Country As String
            Get
                Country = TextBoxAddress_Country.GetText
            End Get
            Set(ByVal value As String)
                TextBoxAddress_Country.Text = value
            End Set
        End Property
        Public Property DisableCountry As Boolean
            Get
                DisableCountry = Not TextBoxAddress_Country.Enabled
            End Get
            Set(ByVal value As Boolean)
                TextBoxAddress_Country.Enabled = Not value
            End Set
        End Property
        Public Property DisableCounty As Boolean
            Get
                DisableCounty = Not TextBoxAddress_County.Enabled
            End Get
            Set(ByVal value As Boolean)
                TextBoxAddress_County.Enabled = Not value
            End Set
        End Property
        Public Property [ReadOnly] As Boolean
            Get
                [ReadOnly] = _ReadOnly
            End Get
            Set(ByVal value As Boolean)
                _ReadOnly = value
                SetReadOnly()
            End Set
        End Property
        Public Shadows Property TabStop As Boolean
            Get
                TabStop = MyBase.TabStop
            End Get
            Set(ByVal value As Boolean)
                MyBase.TabStop = value
                SetTabStop()
            End Set
        End Property
        Public ReadOnly Property UserEntryChanged As Boolean Implements Interfaces.IUserEntryControl.UserEntryChanged
            Get

                Dim EntryChanged As Boolean = False

                If _ByPassUserEntryChanged = False Then

                    For Each Control In GroupBoxControl_Address.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ToList

                        If Control.UserEntryChanged Then

                            EntryChanged = True
                            Exit For

                        End If

                    Next

                End If

                UserEntryChanged = EntryChanged

            End Get
        End Property
        Public WriteOnly Property ByPassUserEntryChanged As Boolean Implements Controls.Interfaces.IUserEntryControl.ByPassUserEntryChanged
            Set(ByVal value As Boolean)

                For Each Control In GroupBoxControl_Address.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ToList

                    Control.ByPassUserEntryChanged = value

                Next

                _ByPassUserEntryChanged = value

            End Set
        End Property
        Public WriteOnly Property SuspendedForLoading As Boolean Implements Interfaces.IUserEntryControl.SuspendedForLoading
            Set(value As Boolean)

                For Each Control In GroupBoxControl_Address.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ToList

                    Control.SuspendedForLoading = value

                Next

                _SuspendedForLoading = value

            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.DoubleBuffered = True

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso _
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                End If

                If Me.ShowCounty = False OrElse Me.ShowCountry = False Then

                    If Me.ShowCounty = False AndAlso Me.ShowCountry = False Then

                        RemoveCountyControls()
                        RemoveCountryControls()

                    ElseIf Me.ShowCounty = False AndAlso Me.ShowCountry Then

                        RemoveCountyControls()

                    ElseIf Me.ShowCounty AndAlso Me.ShowCountry = False Then

                        RemoveCountryControls()

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Protected Sub RemoveCountryControls()

            Me.LabelAddress_Country.Visible = False
            Me.TextBoxAddress_Country.Visible = False

        End Sub
        Protected Sub RemoveCountyControls()

            Dim StateInputLocation As System.Drawing.Point = Nothing
            Dim ZipInputLocation As System.Drawing.Point = Nothing
            Dim CountryInputLocation As System.Drawing.Point = Nothing
            Dim StateLabelLocation As System.Drawing.Point = Nothing
            Dim ZipLabelLocation As System.Drawing.Point = Nothing
            Dim CountryLabelLocation As System.Drawing.Point = Nothing

            StateInputLocation = Me.TextBoxAddress_State.Location
            ZipInputLocation = Me.TextBoxAddress_Zip.Location
            CountryInputLocation = Me.TextBoxAddress_Country.Location

            StateLabelLocation = Me.LabelAddress_State.Location
            ZipLabelLocation = Me.LabelAddress_Zip.Location
            CountryLabelLocation = Me.LabelAddress_Country.Location

            Me.TextBoxAddress_State.Location = New System.Drawing.Point(StateInputLocation.X, StateInputLocation.Y - 26)
            Me.TextBoxAddress_Zip.Location = New System.Drawing.Point(ZipInputLocation.X, ZipInputLocation.Y - 26)
            Me.TextBoxAddress_Country.Location = New System.Drawing.Point(CountryInputLocation.X, CountryInputLocation.Y - 26)

            Me.LabelAddress_State.Location = New System.Drawing.Point(StateLabelLocation.X, StateLabelLocation.Y - 26)
            Me.LabelAddress_Zip.Location = New System.Drawing.Point(ZipLabelLocation.X, ZipLabelLocation.Y - 26)
            Me.LabelAddress_Country.Location = New System.Drawing.Point(CountryLabelLocation.X, CountryLabelLocation.Y - 26)

            Me.LabelAddress_County.Visible = False
            Me.TextBoxAddress_County.Visible = False

        End Sub
        Public Sub SetStreetPropertySettings(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext, ByVal EnumProperty As [Enum])

            TextBoxAddress_Address.SetPropertySettings(EnumProperty, "")

        End Sub
        Public Sub SetStreetPropertySettings(ByVal DataContext As AdvantageFramework.BaseClasses.DataContext, ByVal EnumProperty As [Enum])

            TextBoxAddress_Address.SetPropertySettings(EnumProperty, "")

        End Sub
        Public Sub SetStreetPropertySettings(ByVal PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor), ByVal EnumProperty As [Enum])

            TextBoxAddress_Address.SetPropertySettings(PropertyDescriptorsList, EnumProperty)

        End Sub
        Public Sub SetAddress2PropertySettings(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext, ByVal EnumProperty As [Enum])

            TextBoxAddress_Address2.SetPropertySettings(EnumProperty, "")

        End Sub
        Public Sub SetAddress2PropertySettings(ByVal DataContext As AdvantageFramework.BaseClasses.DataContext, ByVal EnumProperty As [Enum])

            TextBoxAddress_Address2.SetPropertySettings(EnumProperty, "")

        End Sub
        Public Sub SetAddress2PropertySettings(ByVal PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor), ByVal EnumProperty As [Enum])

            TextBoxAddress_Address2.SetPropertySettings(PropertyDescriptorsList, EnumProperty)

        End Sub
        Public Sub SetAddress3PropertySettings(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext, ByVal EnumProperty As [Enum])

            TextBoxAddress_Address3.SetPropertySettings(EnumProperty, "")

        End Sub
        Public Sub SetAddress3PropertySettings(ByVal DataContext As AdvantageFramework.BaseClasses.DataContext, ByVal EnumProperty As [Enum])

            TextBoxAddress_Address3.SetPropertySettings(EnumProperty, "")

        End Sub
        Public Sub SetAddress3PropertySettings(ByVal PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor), ByVal EnumProperty As [Enum])

            TextBoxAddress_Address3.SetPropertySettings(PropertyDescriptorsList, EnumProperty)

        End Sub
        Public Sub SetCityPropertySettings(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext, ByVal EnumProperty As [Enum])

            TextBoxAddress_City.SetPropertySettings(EnumProperty, "")

        End Sub
        Public Sub SetCityPropertySettings(ByVal DataContext As AdvantageFramework.BaseClasses.DataContext, ByVal EnumProperty As [Enum])

            TextBoxAddress_City.SetPropertySettings(EnumProperty, "")

        End Sub
        Public Sub SetCityPropertySettings(ByVal PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor), ByVal EnumProperty As [Enum])

            TextBoxAddress_City.SetPropertySettings(PropertyDescriptorsList, EnumProperty)

        End Sub
        Public Sub SetCountyPropertySettings(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext, ByVal EnumProperty As [Enum])

            TextBoxAddress_County.SetPropertySettings(EnumProperty, "")

        End Sub
        Public Sub SetCountyPropertySettings(ByVal DataContext As AdvantageFramework.BaseClasses.DataContext, ByVal EnumProperty As [Enum])

            TextBoxAddress_County.SetPropertySettings(EnumProperty, "")

        End Sub
        Public Sub SetCountyPropertySettings(ByVal PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor), ByVal EnumProperty As [Enum])

            TextBoxAddress_County.SetPropertySettings(PropertyDescriptorsList, EnumProperty)

        End Sub
        Public Sub SetStatePropertySettings(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext, ByVal EnumProperty As [Enum])

            TextBoxAddress_State.SetPropertySettings(EnumProperty, "")

        End Sub
        Public Sub SetStatePropertySettings(ByVal DataContext As AdvantageFramework.BaseClasses.DataContext, ByVal EnumProperty As [Enum])

            TextBoxAddress_State.SetPropertySettings(EnumProperty, "")

        End Sub
        Public Sub SetStatePropertySettings(ByVal PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor), ByVal EnumProperty As [Enum])

            TextBoxAddress_State.SetPropertySettings(PropertyDescriptorsList, EnumProperty)

        End Sub
        Public Sub SetZipPropertySettings(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext, ByVal EnumProperty As [Enum])

            TextBoxAddress_Zip.SetPropertySettings(EnumProperty)

        End Sub
        Public Sub SetZipPropertySettings(ByVal DataContext As AdvantageFramework.BaseClasses.DataContext, ByVal EnumProperty As [Enum])

            TextBoxAddress_Zip.SetPropertySettings(EnumProperty)

        End Sub
        Public Sub SetZipPropertySettings(ByVal PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor), ByVal EnumProperty As [Enum])

            TextBoxAddress_Zip.SetPropertySettings(PropertyDescriptorsList, EnumProperty)

        End Sub
        Public Sub SetCountryPropertySettings(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext, ByVal EnumProperty As [Enum])

            TextBoxAddress_Country.SetPropertySettings(EnumProperty)

        End Sub
        Public Sub SetCountryPropertySettings(ByVal DataContext As AdvantageFramework.BaseClasses.DataContext, ByVal EnumProperty As [Enum])

            TextBoxAddress_Country.SetPropertySettings(EnumProperty)

        End Sub
        Public Sub SetCountryPropertySettings(ByVal PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor), ByVal EnumProperty As [Enum])

            TextBoxAddress_Country.SetPropertySettings(PropertyDescriptorsList, EnumProperty)

        End Sub
        Public Sub ClearControl()

            TextBoxAddress_Address.Text = ""
            TextBoxAddress_Address2.Text = ""
            TextBoxAddress_Address3.Text = ""
            TextBoxAddress_City.Text = ""
            TextBoxAddress_State.Text = ""
            TextBoxAddress_Zip.Text = ""
            TextBoxAddress_Country.Text = ""
            TextBoxAddress_County.Text = ""

        End Sub
        Protected Sub SetReadOnly()

            TextBoxAddress_Address.ReadOnly = _ReadOnly
            TextBoxAddress_Address2.ReadOnly = _ReadOnly
            TextBoxAddress_Address3.ReadOnly = _ReadOnly
            TextBoxAddress_City.ReadOnly = _ReadOnly
            TextBoxAddress_State.ReadOnly = _ReadOnly
            TextBoxAddress_Zip.ReadOnly = _ReadOnly
            TextBoxAddress_Country.ReadOnly = _ReadOnly
            TextBoxAddress_County.ReadOnly = _ReadOnly

        End Sub
        Protected Sub SetTabStop()

            TextBoxAddress_Address.TabStop = MyBase.TabStop
            TextBoxAddress_Address2.TabStop = MyBase.TabStop
            TextBoxAddress_Address3.TabStop = MyBase.TabStop
            TextBoxAddress_City.TabStop = MyBase.TabStop
            TextBoxAddress_State.TabStop = MyBase.TabStop
            TextBoxAddress_Zip.TabStop = MyBase.TabStop
            TextBoxAddress_Country.TabStop = MyBase.TabStop
            TextBoxAddress_County.TabStop = MyBase.TabStop

        End Sub
        Public Sub ClearChanged() Implements Interfaces.IUserEntryControl.ClearChanged

            TextBoxAddress_Country.ClearChanged()
            TextBoxAddress_Zip.ClearChanged()
            TextBoxAddress_State.ClearChanged()
            TextBoxAddress_County.ClearChanged()
            TextBoxAddress_City.ClearChanged()
            TextBoxAddress_Address2.ClearChanged()
            TextBoxAddress_Address.ClearChanged()
            TextBoxAddress_Address3.ClearChanged()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub

#Region "  Control Event Handlers "

        Private Sub AddressControl_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated

            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Private Sub AddressControl_HandleDestroyed(sender As Object, e As EventArgs) Handles Me.HandleDestroyed

            'RemoveHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Private Sub AddressControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub TextBoxAddress_Address_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxAddress_Address.TextChanged

            RaiseEvent AddressChangedEvent()

        End Sub
        Private Sub TextBoxAddress_Address2_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxAddress_Address2.TextChanged

            RaiseEvent AddressChangedEvent()

        End Sub
        Private Sub TextBoxAddress_Address3_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxAddress_Address3.TextChanged

            RaiseEvent AddressChangedEvent()

        End Sub
        Private Sub TextBoxAddress_City_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxAddress_City.TextChanged

            RaiseEvent AddressChangedEvent()

        End Sub
        Private Sub TextBoxAddress_Country_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxAddress_Country.TextChanged

            RaiseEvent AddressChangedEvent()

        End Sub
        Private Sub TextBoxAddress_County_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxAddress_County.TextChanged

            RaiseEvent AddressChangedEvent()

        End Sub
        Private Sub TextBoxAddress_State_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxAddress_State.TextChanged

            RaiseEvent AddressChangedEvent()

        End Sub
        Private Sub TextBoxAddress_Zip_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxAddress_Zip.TextChanged

            RaiseEvent AddressChangedEvent()

        End Sub

#End Region

#End Region

    End Class

End Namespace
