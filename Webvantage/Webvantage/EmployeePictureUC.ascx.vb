Imports Telerik.Web.UI

Public Class EmployeePictureUC
    Inherits Webvantage.BaseUserControl

#Region " Constants "

    Private Const _Space As String = " "

#End Region

#Region " Enum "

    Public Enum NameDisplay

        FullNameWithoutNickname
        FullNameWithFirstNameAndNickname
        FullNameWithNickname
        NicknameOnly
        FirstAndLastWithoutNickname
        FirstAndLastWithNickname

    End Enum
    Public Enum ControlSize

        Small
        Medium
        Large

    End Enum
#End Region

#Region " Properties "

    Public Property EmployeePicture As SimpleEmployeePicture
    Public Property EmployeeCode As String = String.Empty
    Public Property DbContext As AdvantageFramework.Database.DbContext = Nothing

#End Region

#Region " Variables "


#End Region

#Region " Page "


#End Region

#Region " Controls "


#End Region

#Region " Methods "

    Public Sub Load()

        Me.EmployeePicture = New SimpleEmployeePicture(_Session.ConnectionString, _Session.UserCode, Me.EmployeeCode, DbContext)

    End Sub

#End Region

    <Serializable()> _
    Public Class SimpleEmployeePicture

        Public Property EmployeeCode As String = String.Empty
        Public Property FirstName As String = String.Empty
        Public Property MiddleInitial As String = String.Empty
        Public Property LastName As String = String.Empty
        Public Property NickName As String = String.Empty
        Public Property BinaryImage As Byte() = Nothing
        Public Property DisplayNameAs As NameDisplay = NameDisplay.FullNameWithNickname
        Public Property Size As ControlSize = ControlSize.Small
        Public Property HasSessionData As Boolean = False
        Public Property Css As String = String.Empty
        Public Property HasImage As Boolean = False
        Public Property HasName As Boolean = False
        Public Property NameToDisplay As String = String.Empty
        Public Property DbContext As AdvantageFramework.Database.DbContext = Nothing

        Private Sub SetSizeCSS()

            Select Case Size

                Case ControlSize.Small

                    Me.Css = "wv-employee-img-thumbnail-lg"

                Case ControlSize.Medium

                Case ControlSize.Large

            End Select

        End Sub

        Sub New(ByVal ConnectionString As String, ByVal UserCode As String, ByVal EmployeeCode As String, Optional DbContext As AdvantageFramework.Database.DbContext = Nothing)

            Me.EmployeeCode = EmployeeCode

            If HttpContext.Current.Session("SimpleEmployeePicture_" & EmployeeCode) IsNot Nothing Then

                Dim SessionStore As New SimpleEmployeePicture
                SessionStore = CType(HttpContext.Current.Session("SimpleEmployeePicture_" & EmployeeCode), SimpleEmployeePicture)

                Me.EmployeeCode = SessionStore.EmployeeCode
                Me.FirstName = SessionStore.FirstName
                Me.MiddleInitial = SessionStore.MiddleInitial
                Me.LastName = SessionStore.LastName
                Me.NickName = SessionStore.NickName
                Me.BinaryImage = SessionStore.BinaryImage
                Me.DisplayNameAs = SessionStore.DisplayNameAs
                Me.Size = SessionStore.Size
                Me.Css = SessionStore.Css

                Me.HasSessionData = True

            Else

                If Me.EmployeeCode IsNot String.Empty AndAlso
                  (Me.FirstName Is String.Empty OrElse Me.LastName Is String.Empty) Then

                    Me.HasName = False

                End If
                If BinaryImage IsNot Nothing Then

                    Me.HasImage = True

                End If
                If Me.HasName = False OrElse Me.HasImage = False Then

                    If DbContext Is Nothing Then

                        Me.DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    Else

                        Me.DbContext = DbContext

                    End If

                    Using Me.DbContext

                        If Me.HasImage = False Then

                            Dim MyEmployeePicture As AdvantageFramework.Database.Entities.EmployeePicture = Nothing
                            MyEmployeePicture = AdvantageFramework.Database.Procedures.EmployeePicture.LoadByEmployeeCode(Me.DbContext, Me.EmployeeCode)

                            If MyEmployeePicture IsNot Nothing Then

                                If MyEmployeePicture.Image IsNot Nothing Then

                                    BinaryImage = MyEmployeePicture.Image
                                    Me._HasImage = True

                                End If

                                If Not MyEmployeePicture.Nickname Is Nothing Then Me.NickName = MyEmployeePicture.Nickname

                            End If

                        End If
                        If Me.HasName = False Then

                            Dim MyEmployee As AdvantageFramework.Database.Views.Employee = Nothing
                            MyEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(Me.DbContext, Me.EmployeeCode)

                            If Not MyEmployee Is Nothing Then

                                If Not MyEmployee.FirstName Is Nothing Then Me.FirstName = MyEmployee.FirstName
                                If Not MyEmployee.MiddleInitial Is Nothing Then Me.MiddleInitial = MyEmployee.MiddleInitial
                                If Not MyEmployee.LastName Is Nothing Then Me.LastName = MyEmployee.LastName
                                Me.HasName = True

                            End If

                        End If

                    End Using

                End If

                If Me.HasName = True Then

                    If Me.HasImage = True Then

                        Dim SbNameDisplay As New System.Text.StringBuilder

                        If Me.NickName IsNot String.Empty Then

                            Me.NickName = """" & Me.NickName & """ "

                        End If
                        If Me._FirstName IsNot String.Empty Then

                            Me.FirstName = Me.FirstName & " "

                        End If
                        If Me.MiddleInitial IsNot String.Empty Then

                            Me.MiddleInitial = Me.MiddleInitial & ". "

                        End If
                        Select Case Me.DisplayNameAs

                            Case NameDisplay.FullNameWithNickname

                                SbNameDisplay.Append(Me.NickName)
                                SbNameDisplay.Append(Me.MiddleInitial)
                                SbNameDisplay.Append(Me.LastName)

                            Case NameDisplay.FullNameWithoutNickname

                                SbNameDisplay.Append(Me.FirstName)
                                SbNameDisplay.Append(Me.MiddleInitial)
                                SbNameDisplay.Append(Me.LastName)

                            Case NameDisplay.FullNameWithFirstNameAndNickname

                                SbNameDisplay.Append(Me.NickName)
                                SbNameDisplay.Append(Me.FirstName)
                                SbNameDisplay.Append(Me.MiddleInitial)
                                SbNameDisplay.Append(Me.LastName)

                            Case NameDisplay.NicknameOnly

                                SbNameDisplay.Append(Me.NickName)

                            Case NameDisplay.FirstAndLastWithNickname

                                SbNameDisplay.Append(Me.NickName)
                                SbNameDisplay.Append(Me.FirstName)
                                SbNameDisplay.Append(Me.LastName)

                            Case NameDisplay.FirstAndLastWithoutNickname

                                SbNameDisplay.Append(Me.FirstName)
                                SbNameDisplay.Append(Me.LastName)

                        End Select

                        Me.NameToDisplay = SbNameDisplay.ToString()

                    Else

                        If Me.NickName IsNot String.Empty Then

                            Me.NameToDisplay = Me.NickName.Substring(0, 1).ToUpper()

                        ElseIf Me.FirstName IsNot String.Empty Then

                            Me.NameToDisplay = Me.NickName.Substring(0, 1).ToUpper()

                        Else

                            Me.NameToDisplay = "?"

                        End If

                    End If

                End If

                HttpContext.Current.Session("SimpleEmployeePicture_" & EmployeeCode) = Me

            End If

        End Sub
        Sub New()

        End Sub

    End Class

End Class
