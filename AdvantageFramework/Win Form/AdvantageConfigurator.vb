Namespace WinForm

    Public Class AdvantageConfigurator

#Region " Constants "

        <Xml.Serialization.XmlIgnore>
        Public Const AdvantageConfigurationFileName As String = "AdvantageConfiguration.xml"

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property NTAuthAutoEnable As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.NTAuthAutoEnable = False

        End Sub
        Public Shared Function Load() As AdvantageConfigurator

            Dim AdvantageConfigurator As AdvantageConfigurator = Nothing
            Dim XMLFile As String = String.Empty
            Dim XML As String = String.Empty

            Try

                XMLFile = AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & AdvantageFramework.WinForm.AdvantageConfigurator.AdvantageConfigurationFileName

                XML = My.Computer.FileSystem.ReadAllText(XMLFile)

                AdvantageConfigurator = AdvantageFramework.BaseClasses.ImportFromXML(XML, GetType(AdvantageFramework.WinForm.AdvantageConfigurator))

            Catch ex As Exception
                AdvantageConfigurator = Nothing
            End Try

            If AdvantageConfigurator Is Nothing Then

                AdvantageConfigurator = New AdvantageFramework.WinForm.AdvantageConfigurator

            End If

            Load = AdvantageConfigurator

        End Function

#End Region

    End Class

End Namespace