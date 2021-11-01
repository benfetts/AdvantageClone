Imports Telerik.Web.UI

Namespace Web.Presentation

    <Serializable()>
    Public Class Colors

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum ColorFamily

            Base
            Light
            Lighter
            Dark
            Darker

        End Enum
        Public Enum Color

            Blue
            Green
            Yellow
            Teal
            Peach
            Cyan
            Orange
            Red
            Advantage
            Gray

            Blue1
            Green1
            Yellow1
            Teal1
            Peach1
            Cyan1
            Orange1
            Red1
            Advantage1
            Gray1

            Blue2
            Green2
            Yellow2
            Teal2
            Peach2
            Cyan2
            Orange2
            Red2
            Advantage2
            Gray2

        End Enum

#End Region

#Region " Variables "

        Private Property _CurrentColorInt As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadNextHexColorString() As String

            Dim StandardColors As List(Of String)
            StandardColors = Me.LoadBaseColors()

            If Me._CurrentColorInt > StandardColors.Count - 1 Then

                Me._CurrentColorInt = 0

            End If

            Me._CurrentColorInt += 1

            Return StandardColors(Me._CurrentColorInt)

        End Function

        'Public Function LoadColorFamily(ByVal Color As Color) As ColorFamily

        '    Dim cf As New ColorFamily

        '    Select Case Color
        '        Case Colors.Color.Amber
        '        Case Colors.Color.Blue
        '        Case Colors.Color.BlueGrey
        '        Case Colors.Color.Brown
        '        Case Colors.Color.Cyan
        '        Case Colors.Color.DeepOrange
        '        Case Colors.Color.DeepPurple
        '        Case Colors.Color.Green
        '        Case Colors.Color.Grey
        '        Case Colors.Color.Indigo
        '        Case Colors.Color.LightBlue
        '        Case Colors.Color.LightGreen
        '        Case Colors.Color.Lime
        '        Case Colors.Color.Orange
        '        Case Colors.Color.Pink
        '        Case Colors.Color.Purple
        '        Case Colors.Color.Red
        '        Case Colors.Color.Teal
        '        Case Colors.Color.Yellow
        '    End Select

        '    Return cf

        'End Function
        'Public Function LoadColorHexString(ByVal Color As Color) As String

        '    Return ""

        'End Function

        Public Function LoadColor(Color As Web.Presentation.Colors.Color, ColorFamily As Web.Presentation.Colors.ColorFamily) As System.Drawing.Color

            Return System.Drawing.ColorTranslator.FromHtml(LoadHex(Color, ColorFamily))

        End Function
        Public Function LoadHex(Color As Web.Presentation.Colors.Color, ColorFamily As Web.Presentation.Colors.ColorFamily) As String

            Dim ColorString As String = String.Empty

            Select Case ColorFamily
                Case ColorFamily.Base
                    Select Case Color
                        Case Colors.Color.Red
                            ColorString = "#DC3545"
                        Case Colors.Color.Blue
                            ColorString = "#007BFF"
                        Case Colors.Color.Green
                            ColorString = "#5CB85C"
                        Case Colors.Color.Peach 'PURPLE !!!!
                            ColorString = "#6F42C1"
                        Case Colors.Color.Teal
                            ColorString = "#20C997"
                        Case Colors.Color.Cyan
                            ColorString = "#17A2B8"
                        Case Colors.Color.Yellow ', Colors.Color.TweetyBird
                            ColorString = "#ffc107"
                        Case Colors.Color.Advantage
                            ColorString = "#2A579A"
                        Case Colors.Color.Gray
                            ColorString = "#adb5bd"
                        Case Colors.Color.Orange
                            ColorString = "#fd7e14"
                        Case Colors.Color.Red1
                            ColorString = "#E35D6A"
                        Case Colors.Color.Peach1 'PURPLE!!!!
                            ColorString = "#8C68CD"
                        Case Colors.Color.Gray1
                            ColorString = "#CED4DA"
                        Case Colors.Color.Green1
                            ColorString = "#479F76"
                        Case Colors.Color.Orange1
                            ColorString = "#FD9843"
                        Case Colors.Color.Blue1
                            ColorString = "#3D8BFD"
                        Case Colors.Color.Teal1
                            ColorString = "#4DD4AC"
                        Case Colors.Color.Cyan1
                            ColorString = "#3DD5F3"
                        Case Colors.Color.Yellow1 ', Colors.Color.TweetyBird1
                            ColorString = "#FFCD39"
                        Case Colors.Color.Advantage1
                            ColorString = "#113E81"
                        Case Colors.Color.Red2
                            ColorString = "#842029"
                        Case Colors.Color.Peach2 'PURPLE !!!!
                            ColorString = "#432874"
                        Case Colors.Color.Gray2
                            ColorString = "#495057"
                        Case Colors.Color.Green2
                            ColorString = "#0F5132"
                        Case Colors.Color.Orange2
                            ColorString = "#984C0C"
                        Case Colors.Color.Blue2
                            ColorString = "#084298"
                        Case Colors.Color.Teal2
                            ColorString = "#13795B"
                        Case Colors.Color.Cyan2
                            ColorString = "#087990"
                        Case Colors.Color.Yellow2 ', Colors.Color.TweetyBird2
                            ColorString = "#997404"
                        Case Colors.Color.Advantage2
                            ColorString = "#4471B4"
                        Case Else
                            ColorString = "#2A579A"
                    End Select
                Case ColorFamily.Light
                    Select Case Color
                        Case Colors.Color.Red
                            ColorString = "#E35D6A"
                        Case Colors.Color.Peach
                            ColorString = "#8C68CD"
                        Case Colors.Color.Gray
                            ColorString = "#CED4DA"
                        Case Colors.Color.Green
                            ColorString = "#479F76"
                        Case Colors.Color.Orange
                            ColorString = "#FD9843"
                        Case Colors.Color.Blue
                            ColorString = "#3D8BFD"
                        Case Colors.Color.Teal
                            ColorString = "#4DD4AC"
                        Case Colors.Color.Cyan
                            ColorString = "#3DD5F3"
                        Case Colors.Color.Yellow
                            ColorString = "#FFCD39"
                        Case Colors.Color.Advantage
                            ColorString = "#113E81"
                    End Select
                Case ColorFamily.Lighter
                    Select Case Color
                        Case Colors.Color.Red
                            ColorString = "#FF6878"
                        'Case Colors.Color.Peach 'PURPLE!!!!
                        '    ColorString = "#A275F4"
                        Case Colors.Color.Gray
                            ColorString = "#9FA8B0"
                        Case Colors.Color.Green
                            ColorString = "#5BDA78"
                        Case Colors.Color.Orange
                            ColorString = "#FFB147"
                        Case Colors.Color.Blue
                            ColorString = "#33AEFF"
                        'Case Colors.Color.Brown
                        '    ColorString = "#715A56"
                        Case Colors.Color.Teal
                            ColorString = "#53FCCA"
                        Case Colors.Color.Cyan
                            ColorString = "#4AD5EB"
                        Case Colors.Color.Yellow ', Colors.Color.TweetyBird
                            ColorString = "#FFF43A"
                        Case Colors.Color.Advantage
                            ColorString = "#5D8ACD"
                        Case Else
                            ColorString = "#5D8ACD"
                    End Select
                Case ColorFamily.Dark
                    Select Case Color
                        Case Colors.Color.Red
                            ColorString = "#842029"
                        Case Colors.Color.Peach 'PURPLE !!!!
                            ColorString = "#432874"
                        Case Colors.Color.Gray
                            ColorString = "#495057"
                        Case Colors.Color.Green
                            ColorString = "#0F5132"
                        Case Colors.Color.Orange
                            ColorString = "#984C0C"
                        Case Colors.Color.Blue
                            ColorString = "#084298"
                        Case Colors.Color.Teal
                            ColorString = "#13795B"
                        Case Colors.Color.Cyan
                            ColorString = "#087990"
                        Case Colors.Color.Yellow
                            ColorString = "#997404"
                        Case Colors.Color.Advantage
                            ColorString = "#4471B4"
                        Case Else
                            ColorString = "#113E81"
                    End Select
                Case ColorFamily.Darker
                    Select Case Color
                        Case Colors.Color.Red
                            ColorString = "#A90212"
                        'Case Colors.Color.Peach 'PURPLE !!!!
                        '    ColorString = "#3C0F8E"
                        Case Colors.Color.Gray
                            ColorString = "#39424A"
                        Case Colors.Color.Green
                            ColorString = "#007412"
                        Case Colors.Color.Orange
                            ColorString = "#CA4B00"
                        Case Colors.Color.Blue
                            ColorString = "#0048CC"
                        'Case Colors.Color.Brown
                        '    ColorString = "#0B0000"
                        Case Colors.Color.Teal
                            ColorString = "#009664"
                        Case Colors.Color.Cyan
                            ColorString = "#006F85"
                        Case Colors.Color.Yellow ', Colors.Color.TweetyBird
                            ColorString = "#CC8E00"
                        Case Colors.Color.Advantage
                            ColorString = "#002467"
                        Case Else
                            ColorString = "#002467"
                    End Select
            End Select

            Return ColorString

        End Function
        Public Function LoadAllColors() As List(Of String)

            Dim list As New List(Of String)
            Dim ColorString As String = String.Empty

            With list

                ColorString = "#DC3545"
                list.Add(ColorString)
                ColorString = "#4D82B8"
                list.Add(ColorString)
                ColorString = "#EDC87E"
                list.Add(ColorString)
                ColorString = "#808080"
                list.Add(ColorString)
                ColorString = "#5CB85C"
                list.Add(ColorString)
                ColorString = "#ED9A56"
                list.Add(ColorString)
                ColorString = "#B89A7C"
                list.Add(ColorString)
                ColorString = "#009688"
                list.Add(ColorString)
                ColorString = "#F2F25A"
                list.Add(ColorString)
                ColorString = "#00BCD4"
                list.Add(ColorString)
                ColorString = "#EFC1B4"
                list.Add(ColorString)
                ColorString = "#2A579A"
                list.Add(ColorString)

                ColorString = "#EEACB9"
                list.Add(ColorString)
                ColorString = "#78A1CA"
                list.Add(ColorString)
                ColorString = "#F2D9A8"
                list.Add(ColorString)
                ColorString = "#AEAEAE"
                list.Add(ColorString)
                ColorString = "#99C3B8"
                list.Add(ColorString)
                ColorString = "#F5C7A1"
                list.Add(ColorString)
                ColorString = "#D3C0AD"
                list.Add(ColorString)
                ColorString = "#4DB6AC"
                list.Add(ColorString)
                ColorString = "#FFFFCC"
                list.Add(ColorString)
                ColorString = "#4DD0E1"
                list.Add(ColorString)
                ColorString = "#F1C8BD"
                list.Add(ColorString)

                ColorString = "#F7D5DB"
                list.Add(ColorString)
                ColorString = "#B2C9E0"
                list.Add(ColorString)
                ColorString = "#F6E3BC"
                list.Add(ColorString)
                ColorString = "#F6DDD6"
                list.Add(ColorString)
                ColorString = "#CAE0DA"
                list.Add(ColorString)
                ColorString = "#F9DEC7"
                list.Add(ColorString)
                ColorString = "#E4D9CE"
                list.Add(ColorString)
                ColorString = "#E0F2F1"
                list.Add(ColorString)
                ColorString = "#FCFCEB"
                list.Add(ColorString)
                ColorString = "#E0F7FA"
                list.Add(ColorString)
                ColorString = "#F6DDD6"
                list.Add(ColorString)

                ColorString = "#D63251"
                list.Add(ColorString)
                ColorString = "#3A6692"
                list.Add(ColorString)
                ColorString = "#E2A62E"
                list.Add(ColorString)
                ColorString = "#515151"
                list.Add(ColorString)
                ColorString = "#4B7D70"
                list.Add(ColorString)
                ColorString = "#C96615"
                list.Add(ColorString)
                ColorString = "#826446"
                list.Add(ColorString)
                ColorString = "#0C6666"
                list.Add(ColorString)
                ColorString = "#D2D20F"
                list.Add(ColorString)
                ColorString = "#0097A7"
                list.Add(ColorString)
                ColorString = "#caa297"
                list.Add(ColorString)

                ColorString = "#801A2D"
                list.Add(ColorString)
                ColorString = "#203850"
                list.Add(ColorString)
                ColorString = "#B07D18"
                list.Add(ColorString)
                ColorString = "#2A2A2A"
                list.Add(ColorString)
                ColorString = "#355950"
                list.Add(ColorString)
                ColorString = "#AA5712"
                list.Add(ColorString)
                ColorString = "#5C4732"
                list.Add(ColorString)
                ColorString = "#004D40"
                list.Add(ColorString)
                ColorString = "#A0A000"
                list.Add(ColorString)
                ColorString = "#006064"
                list.Add(ColorString)
                ColorString = "#a5877f"
                list.Add(ColorString)

            End With

            Return list

        End Function
        Public Function LoadColors() As List(Of String)

            Dim list As New List(Of String)
            Dim ColorString As String = String.Empty

            With list

                ColorString = "#F44336"
                list.Add(ColorString)
                ColorString = "#2196F3"
                list.Add(ColorString)
                ColorString = "#FFEB3B"
                list.Add(ColorString)
                ColorString = "#4CAF50"
                list.Add(ColorString)
                ColorString = "#808080"
                list.Add(ColorString)
                ColorString = "#FF9800"
                list.Add(ColorString)
                ColorString = "#795548"
                list.Add(ColorString)
                ColorString = "#009688"
                list.Add(ColorString)
                ColorString = "#00BCD4"
                list.Add(ColorString)
                ColorString = "#3F51B5"
                list.Add(ColorString)
                ColorString = "#EFC1B4"
                list.Add(ColorString)
                ColorString = "#2a579a"
                list.Add(ColorString)

            End With

            Return list

        End Function
        'Public Function LoadStandardColors() As List(Of String)
        '    Dim list As New List(Of String)

        '    With list

        '        .Add("#DC3545")
        '        .Add("#4D82B8")
        '        .Add("#EDC87E")
        '        .Add("#808080")
        '        .Add("#5CB85C")
        '        .Add("#ED9A56")
        '        .Add("#B89A7C")
        '        .Add("#008080")

        '        .Add("#EFC1B4")

        '    End With

        '    Return list

        'End Function

        Public Function LoadBaseColors() As Generic.List(Of String)

            Dim ColorsList As New Generic.List(Of String)
            Dim Colors As Array = System.Enum.GetValues(GetType(AdvantageFramework.Web.Presentation.Colors.Color))

            For Each Color As AdvantageFramework.Web.Presentation.Colors.Color In Colors

                ColorsList.Add(LoadHex(Color, ColorFamily.Base))

            Next

            Return ColorsList

        End Function
        Public Function LoadColorsDictionary(ColorFamily As Web.Presentation.Colors.ColorFamily) As Dictionary(Of String, String)

            Dim ColorsDictionary As New Dictionary(Of String, String)
            Dim Colors As Array = System.Enum.GetValues(GetType(AdvantageFramework.Web.Presentation.Colors.Color))

            For Each Color As AdvantageFramework.Web.Presentation.Colors.Color In Colors

                ColorsDictionary.Add(LoadHex(Color, ColorFamily.Base), Color.ToString())

            Next

            Return ColorsDictionary

        End Function

        Public Function LoadDarkColorHexByHex(ByVal Hex As String) As String

            Dim DarkColorString As String = ""

            Dim ThisColor As Colors.Color = DirectCast([Enum].Parse(GetType(Colors.Color), LoadColorsDictionary(ColorFamily.Dark).Item(Hex).ToString().Replace(" ", "")), Colors.Color)

            DarkColorString = LoadDarkHex(ThisColor)

            Return DarkColorString

        End Function
        Public Function LoadDarkColor(Color As Web.Presentation.Colors.Color) As System.Drawing.Color

            Return System.Drawing.ColorTranslator.FromHtml(LoadDarkHex(Color))

        End Function
        Public Function LoadDarkHex(ByVal Color As Web.Presentation.Colors.Color) As String

            Return LoadHex(Color, ColorFamily.Dark)

        End Function


        Public Function LoadDarkerHighlightColorHexByHex(ByVal Hex As String) As String

            Dim DarkerColorString As String = ""
            Dim ThisColor As Colors.Color = DirectCast([Enum].Parse(GetType(Colors.Color), LoadColorsDictionary(ColorFamily.Darker).Item(Hex).ToString().Replace(" ", "")), Colors.Color)

            DarkerColorString = LoadDarkerHex(ThisColor)

            Return DarkerColorString

        End Function
        Public Function LoadDarkerColor(Color As Web.Presentation.Colors.Color) As System.Drawing.Color

            Return System.Drawing.ColorTranslator.FromHtml(LoadDarkerHex(Color))

        End Function
        Public Function LoadDarkerHex(ByVal Color As Web.Presentation.Colors.Color) As String

            Return LoadHex(Color, ColorFamily.Darker)

        End Function

        Public Function LoadLightColorHexByHex(ByVal Hex As String) As String

            Dim LightColorString As String = ""
            Dim ThisColor As Colors.Color = DirectCast([Enum].Parse(GetType(Colors.Color), LoadColorsDictionary(ColorFamily.Light).Item(Hex).ToString().Replace(" ", "")), Colors.Color)

            LightColorString = LoadLightHex(ThisColor)

            Return LightColorString

        End Function
        Public Function LoadLightColor(Color As Web.Presentation.Colors.Color) As System.Drawing.Color

            Return System.Drawing.ColorTranslator.FromHtml(LoadLightHex(Color))

        End Function
        Public Function LoadLightHex(ByVal Color As Web.Presentation.Colors.Color) As String

            Return LoadHex(Color, ColorFamily.Light)

        End Function


        Public Function LoadLighterColorHexByHex(ByVal Hex As String) As String

            Dim LighterColorString As String = ""
            Dim ThisColor As Colors.Color = DirectCast([Enum].Parse(GetType(Colors.Color), LoadColorsDictionary(ColorFamily.Lighter).Item(Hex).ToString().Replace(" ", "")), Colors.Color)

            LighterColorString = LoadLightHex(ThisColor)

            Return LighterColorString

        End Function
        Public Function LoadLighterColor(Color As Web.Presentation.Colors.Color) As System.Drawing.Color

            Return System.Drawing.ColorTranslator.FromHtml(LoadLighterHex(Color))

        End Function
        Public Function LoadLighterHex(ByVal Color As Web.Presentation.Colors.Color) As String

            Return LoadHex(Color, ColorFamily.Lighter)

        End Function




        Public Function LoadColorCombos() As Generic.List(Of ColorCombo)
            Dim l As New Generic.List(Of ColorCombo)
            Dim cc As ColorCombo

            cc = New ColorCombo
            cc.Name = "Red"
            cc.PrimaryColor = "#F44336"
            cc.SecondaryColor = "#D32F2F"
            cc.AccentColor = "#"
            l.Add(cc)
            cc = Nothing

            cc = New ColorCombo
            cc.Name = "Pink"
            cc.PrimaryColor = "#E91E63"
            cc.SecondaryColor = "#C2185B"
            cc.AccentColor = "#"
            l.Add(cc)
            cc = Nothing

            cc = New ColorCombo
            cc.Name = "Purple"
            cc.PrimaryColor = "#9C27B0"
            cc.SecondaryColor = "#7B1FA2"
            cc.AccentColor = "#"
            l.Add(cc)
            cc = Nothing

            cc = New ColorCombo
            cc.Name = "Deep Purple"
            cc.PrimaryColor = "#673AB7"
            cc.SecondaryColor = "#512DA8"
            cc.AccentColor = "#"
            l.Add(cc)
            cc = Nothing

            cc = New ColorCombo
            cc.Name = "Indigo"
            cc.PrimaryColor = "#3F51B5"
            cc.SecondaryColor = "#303F9F"
            cc.AccentColor = "#"
            l.Add(cc)
            cc = Nothing

            cc = New ColorCombo
            cc.Name = "Blue"
            cc.PrimaryColor = "#2196F3"
            cc.SecondaryColor = "#1976D2"
            cc.AccentColor = "#"
            l.Add(cc)
            cc = Nothing

            cc = New ColorCombo
            cc.Name = "Light Blue"
            cc.PrimaryColor = "#03A9F4"
            cc.SecondaryColor = "#0288D1"
            cc.AccentColor = "#"
            l.Add(cc)
            cc = Nothing

            cc = New ColorCombo
            cc.Name = "Cyan"
            cc.PrimaryColor = "#00BCD4"
            cc.SecondaryColor = "#0097A7"
            cc.AccentColor = "#8BC34A"
            l.Add(cc)
            cc = Nothing

            cc = New ColorCombo
            cc.Name = "Teal"
            cc.PrimaryColor = "#009688"
            cc.SecondaryColor = "#00796B"
            cc.AccentColor = "#"
            l.Add(cc)
            cc = Nothing

            cc = New ColorCombo
            cc.Name = "Green"
            cc.PrimaryColor = "#4CAF50"
            cc.SecondaryColor = "#388E3C"
            cc.AccentColor = "#"
            l.Add(cc)
            cc = Nothing

            cc = New ColorCombo
            cc.Name = "Light Green"
            cc.PrimaryColor = "#8BC34A"
            cc.SecondaryColor = "#689F38"
            cc.AccentColor = "#"
            l.Add(cc)
            cc = Nothing

            cc = New ColorCombo
            cc.Name = "Lime"
            cc.PrimaryColor = "#CDDC39"
            cc.SecondaryColor = "#AFB42B"
            cc.AccentColor = "#"
            l.Add(cc)
            cc = Nothing

            cc = New ColorCombo
            cc.Name = "Yellow"
            cc.PrimaryColor = "#FFEB3B"
            cc.SecondaryColor = "#FBC02D"
            cc.AccentColor = "#"
            l.Add(cc)
            cc = Nothing

            cc = New ColorCombo
            cc.Name = "Amber"
            cc.PrimaryColor = "#FFC107"
            cc.SecondaryColor = "#FFA000"
            cc.AccentColor = "#"
            l.Add(cc)
            cc = Nothing

            cc = New ColorCombo
            cc.Name = "Orange"
            cc.PrimaryColor = "#FF9800"
            cc.SecondaryColor = "#F57C00"
            cc.AccentColor = "#"
            l.Add(cc)
            cc = Nothing

            cc = New ColorCombo
            cc.Name = "Deep Orange"
            cc.PrimaryColor = "#FF5722"
            cc.SecondaryColor = "#E64A19"
            cc.AccentColor = "#"
            l.Add(cc)
            cc = Nothing

            cc = New ColorCombo
            cc.Name = "Brown"
            cc.PrimaryColor = "#795548"
            cc.SecondaryColor = "#5D4037"
            cc.AccentColor = "#"
            l.Add(cc)
            cc = Nothing

            cc = New ColorCombo
            cc.Name = "Grey"
            cc.PrimaryColor = "#9E9E9E"
            cc.SecondaryColor = "#616161"
            cc.AccentColor = "#"
            l.Add(cc)
            cc = Nothing

            cc = New ColorCombo
            cc.Name = "Blue Grey"
            cc.PrimaryColor = "#607D8B"
            cc.SecondaryColor = "#455A64"
            cc.AccentColor = "#"
            l.Add(cc)
            cc = Nothing

            cc = New ColorCombo
            cc.Name = "Advantage"
            cc.PrimaryColor = "#2A579A"
            cc.SecondaryColor = "#2A579A"
            cc.AccentColor = "#"
            l.Add(cc)
            cc = Nothing

            Return l

        End Function
        '#Region " Color Families "

        '        Public Class ColorFamily

        '            Public Property P50 As String
        '            Public Property P100 As String
        '            Public Property P200 As String
        '            Public Property P300 As String
        '            Public Property P400 As String
        '            Public Property Primary_P500 As String
        '            Public Property P600 As String
        '            Public Property P700 As String
        '            Public Property P800 As String
        '            Public Property P900 As String
        '            Public Property A100 As String
        '            Public Property A200 As String
        '            Public Property A400 As String
        '            Public Property A700 As String

        '            Sub New()

        '            End Sub

        '        End Class
        '        Public Class Red
        '            Inherits Web.Presentation.Colors.ColorFamily

        '            Sub New()

        '                Me.P50 = "#"

        '            End Sub

        '        End Class

        '#End Region

        Sub New()

        End Sub

#End Region

    End Class

    <Serializable()> Public Class ColorCombo

        Public Property Name As String = ""
        Public Property PrimaryColor As String = ""
        Public Property SecondaryColor As String = ""
        Public Property AccentColor As String = ""

        Sub New()

        End Sub

    End Class
    Public Class Charting

        Private _ColorList As New Dictionary(Of String, String)
        Private _Counter As Integer = 0

        Public Function AddChartColumn(ByRef Chart As Telerik.Web.UI.RadHtmlChart, ByVal ColumnName As String, ByVal Value As Decimal,
                                       ByVal Color As AdvantageFramework.Web.Presentation.Colors.Color) As Boolean

            Try

                Value = Math.Round(Value, 2)

                Dim Colors As New AdvantageFramework.Web.Presentation.Colors

                Chart.PlotArea.XAxis.Items.Add(ColumnName)

                Dim ColumnSeries As Telerik.Web.UI.ColumnSeries
                ColumnSeries = Chart.PlotArea.Series(0)

                'Dim ColumnSeries As New Telerik.Web.UI.ColumnSeries

                'ColumnSeries.Appearance.FillStyle.BackgroundColor = Colors.LoadColor(Color)
                'ColumnSeries.LabelsAppearance.DataFormatString = DataFormatString
                'ColumnSeries.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.BarColumnLabelsPosition.OutsideEnd

                'ColumnSeries.TooltipsAppearance.DataFormatString = DataFormatString
                'ColumnSeries.TooltipsAppearance.Color = System.Drawing.Color.White
                'ColumnSeries.TooltipsAppearance.Visible = False

                Dim CategorySeriesItem As New Telerik.Web.UI.CategorySeriesItem
                CategorySeriesItem.Y = Value
                CategorySeriesItem.BackgroundColor = Colors.LoadColor(Color, Colors.ColorFamily.Base)

                ColumnSeries.SeriesItems.Add(CategorySeriesItem)

                'Chart.PlotArea.Series.Add(ColumnSeries)

                Return True

            Catch ex As Exception

                Return False

            End Try

        End Function


        Sub New()

            Dim Colors As New AdvantageFramework.Web.Presentation.Colors()
            _ColorList = Colors.LoadColorsDictionary(Colors.ColorFamily.Base)

        End Sub

    End Class

End Namespace
