Namespace Images

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadResource(ByVal ResourceName As String) As Object

            Try

                If ResourceName.Contains(".") Then

                    LoadResource = My.Resources.ResourceManager.GetObject(ResourceName.Substring(0, ResourceName.IndexOf(".")), My.Resources.Culture)

                Else

                    LoadResource = My.Resources.ResourceManager.GetObject(ResourceName, My.Resources.Culture)

                End If
                
            Catch ex As Exception
                LoadResource = Nothing
            End Try

        End Function
        Public Function ImageToByteArray(Image As System.Drawing.Image) As Byte()

            Dim ByteArray As Byte() = Nothing

            Using MemoryStream = New System.IO.MemoryStream()

                Image.Save(MemoryStream, Image.RawFormat)

                ByteArray = MemoryStream.ToArray()

            End Using

            ImageToByteArray = ByteArray

        End Function
        Public Function ImageToByteArray(Image As System.Drawing.Image, ImageFormat As System.Drawing.Imaging.ImageFormat) As Byte()

            Dim ByteArray As Byte() = Nothing

            Using MemoryStream = New System.IO.MemoryStream()

                Image.Save(MemoryStream, ImageFormat)

                ByteArray = MemoryStream.ToArray()

            End Using

            ImageToByteArray = ByteArray

        End Function

#End Region

    End Module

End Namespace
