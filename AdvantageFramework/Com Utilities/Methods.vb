Namespace ComUtilities

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Private Const FrameworkDirectoryv2x86 As String = "C:\Windows\Microsoft.NET\Framework\v2.0.50727\"
        Private Const FrameworkDirectoryv2x64 As String = "C:\Windows\Microsoft.NET\Framework64\v2.0.50727\"
        Private Const FrameworkDirectoryv4x86 As String = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\"
        Private Const FrameworkDirectoryv4x64 As String = "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\"

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function RegisterDLL(FileName As String, ClassName As String) As Boolean

            'objects
            Dim Registered As Boolean = False
            Dim PreRegistered As Boolean = False
            Dim RegAsmFile As String = String.Empty
            Dim DLLFile As String = String.Empty
            Dim CommandFile As String = String.Empty
            Dim ProcessStartInfo As System.Diagnostics.ProcessStartInfo = Nothing
            Dim PingLibrary As Object = Nothing
            Dim TextForRegFile As String = String.Empty
            Dim ErrorMessage As String = String.Empty

            RegAsmFile = AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & "regasm.exe"
            DLLFile = AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & FileName
            CommandFile = AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & "Advantage Registry Command File.bat"

            TextForRegFile = """" & RegAsmFile & """ " & FileName & " /unregister"
            TextForRegFile &= System.Environment.NewLine & """" & RegAsmFile & """ " & FileName & " /tlb /unregister"
            TextForRegFile &= System.Environment.NewLine & """" & RegAsmFile & """ " & FileName & " /codebase"
            TextForRegFile &= System.Environment.NewLine & """" & RegAsmFile & """ " & FileName & " /tlb"

            TextForRegFile &= System.Environment.NewLine
            'TextForRegFile &= System.Environment.NewLine & "PAUSE"

            If My.Computer.FileSystem.FileExists(CommandFile) Then

                My.Computer.FileSystem.DeleteFile(CommandFile)

            End If

            My.Computer.FileSystem.WriteAllText(CommandFile, TextForRegFile, False, System.Text.Encoding.ASCII)

            Try

                ProcessStartInfo = New System.Diagnostics.ProcessStartInfo

                ProcessStartInfo.FileName = CommandFile
                ProcessStartInfo.UseShellExecute = False

                If System.Diagnostics.Process.Start(ProcessStartInfo).WaitForExit(30000) Then

                    'PingLibrary = CreateObject(ClassName)
                    'PingLibrary = Nothing

                    Registered = True

                End If

            Catch ex As Exception

            End Try

            If My.Computer.FileSystem.FileExists(CommandFile) Then

                My.Computer.FileSystem.DeleteFile(CommandFile)

            End If

            RegisterDLL = Registered

        End Function
        Private Function GetRegAsmFile() As String

            Dim File As String = String.Empty

            If My.Computer.FileSystem.FileExists(FrameworkDirectoryv4x64 & "regasm.exe") Then

                File = FrameworkDirectoryv4x64 & "regasm.exe"

            ElseIf My.Computer.FileSystem.FileExists(FrameworkDirectoryv2x64 & "regasm.exe") Then

                File = FrameworkDirectoryv2x64 & "regasm.exe"

            ElseIf My.Computer.FileSystem.FileExists(FrameworkDirectoryv4x86 & "regasm.exe") Then

                File = FrameworkDirectoryv4x86 & "regasm.exe"

            ElseIf My.Computer.FileSystem.FileExists(FrameworkDirectoryv2x86 & "regasm.exe") Then

                File = FrameworkDirectoryv2x86 & "regasm.exe"

            End If

            GetRegAsmFile = File

        End Function

#End Region

    End Module

End Namespace
