Namespace WinForm.Presentation.Controls

    Public Class Address3LineControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.AddressControl

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "


#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Public Sub New()

            Me.Size = New System.Drawing.Size(354, 207)
            Me.DoubleBuffered = True

            MoveAddressLocations()

        End Sub
        Protected Sub MoveAddressLocations()

            Dim CityInputLocation As System.Drawing.Point = Nothing
            Dim CountyInputLocation As System.Drawing.Point = Nothing
            Dim StateInputLocation As System.Drawing.Point = Nothing
            Dim ZipInputLocation As System.Drawing.Point = Nothing
            Dim CountryInputLocation As System.Drawing.Point = Nothing
            Dim CityLabelLocation As System.Drawing.Point = Nothing
            Dim CountyLabelLocation As System.Drawing.Point = Nothing
            Dim StateLabelLocation As System.Drawing.Point = Nothing
            Dim ZipLabelLocation As System.Drawing.Point = Nothing
            Dim CountryLabelLocation As System.Drawing.Point = Nothing

            CityInputLocation = Me.TextBoxAddress_City.Location
            CountyInputLocation = Me.TextBoxAddress_County.Location
            StateInputLocation = Me.TextBoxAddress_State.Location
            ZipInputLocation = Me.TextBoxAddress_Zip.Location
            CountryInputLocation = Me.TextBoxAddress_Country.Location

            CityLabelLocation = Me.LabelAddress_City.Location
            CountyLabelLocation = Me.LabelAddress_County.Location
            StateLabelLocation = Me.LabelAddress_State.Location
            ZipLabelLocation = Me.LabelAddress_Zip.Location
            CountryLabelLocation = Me.LabelAddress_Country.Location

            Me.TextBoxAddress_City.Location = New System.Drawing.Point(CityInputLocation.X, CityInputLocation.Y + 26)
            Me.TextBoxAddress_County.Location = New System.Drawing.Point(CountyInputLocation.X, CountyInputLocation.Y + 26)
            Me.TextBoxAddress_State.Location = New System.Drawing.Point(StateInputLocation.X, StateInputLocation.Y + 26)
            Me.TextBoxAddress_Zip.Location = New System.Drawing.Point(ZipInputLocation.X, ZipInputLocation.Y + 26)
            Me.TextBoxAddress_Country.Location = New System.Drawing.Point(CountryInputLocation.X, CountryInputLocation.Y + 26)

            Me.LabelAddress_City.Location = New System.Drawing.Point(CityLabelLocation.X, CityLabelLocation.Y + 26)
            Me.LabelAddress_County.Location = New System.Drawing.Point(CountyLabelLocation.X, CountyLabelLocation.Y + 26)
            Me.LabelAddress_State.Location = New System.Drawing.Point(StateLabelLocation.X, StateLabelLocation.Y + 26)
            Me.LabelAddress_Zip.Location = New System.Drawing.Point(ZipLabelLocation.X, ZipLabelLocation.Y + 26)
            Me.LabelAddress_Country.Location = New System.Drawing.Point(CountryLabelLocation.X, CountryLabelLocation.Y + 26)

            Me.LabelAddress_Address3.Visible = True
            Me.TextBoxAddress_Address3.Visible = True

        End Sub

#Region "  Control Event Handlers "

        

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
