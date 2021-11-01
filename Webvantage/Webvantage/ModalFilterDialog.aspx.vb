Public Class ModalFilterDialog
    Inherits Webvantage.BaseChildPage

#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "

#End Region

#Region " Properties "

#End Region

#Region " Methods "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim LookupType As String = Nothing
        Dim ShowAddEdit As Boolean = False
        Dim Security As cSecurity = Nothing

        If Not Me.Page.IsPostBack Then

            Page.Title = "Search"

            If Not [String].IsNullOrWhiteSpace(Request("LookupType")) Then

                LookupType = Request("LookupType")

            End If

            If Not [String].IsNullOrWhiteSpace(LookupType) Then

                Page.Title &= " - " & AdvantageFramework.StringUtilities.GetNameAsWords(LookupType)

            End If

            If Not [String].IsNullOrWhiteSpace(Request("ShowAddEdit")) Then

                ShowAddEdit = CBool(Request("ShowAddEdit"))

            End If

            If ShowAddEdit = True Then

                Select Case LookupType

                    Case "VendorContact"

                        Security = New cSecurity(_Session.ConnectionString)

                        If Not Security.GetVendorContactSecurity(_Session.UserCode) = "N" Then

                            DivAddEditOptions.Visible = True
                            ImageButtonAdd.Visible = True
                            ImageButtonEdit.Visible = True
                            ImageButtonAdd.ToolTip = "Add Vendor Contact"
                            ImageButtonEdit.ToolTip = "Edit Vendor Contact"
                            ImageButtonAdd.Attributes.Add("onclick", "addVendorContact(); return false;")
                            ImageButtonEdit.Attributes.Add("onclick", "editVendorContact(); return false;")

                        End If

                End Select

                'Else

                '    Select Case LookupType

                '        Case "Employee"

                '            If Request("functiontype") = "V" Then
                '                Me.CheckboxClosedJobs.Visible = True
                '                Me.CheckboxClosedJobs.Text = "Limit to vendors with default function code '" & Request("functioncode") & "'"
                '                Me.CheckboxClosedJobs.Attributes.Add("onchange", "VendorLimitbyDefaultFunction(); return false;")
                '                Me.CheckBoxMediaVendors.Visible = True
                '                Me.CheckBoxMediaVendors.Attributes.Add("onchange", "VendorIncludeMediaVendors(); return false;")
                '            End If

                '    End Select

            End If

        End If

    End Sub


    'Private Function AddSpacesToSentence(text As String, preserveAcronyms As Boolean) As String
    '    If String.IsNullOrWhiteSpace(text) Then
    '        Return String.Empty
    '    End If
    '    Dim newText As New System.Text.StringBuilder(text.Length * 2)
    '    newText.Append(text(0))
    '    For i As Integer = 1 To text.Length - 1
    '        If Char.IsUpper(text(i)) Then
    '            If (text(i - 1) <> " "c AndAlso Not Char.IsUpper(text(i - 1))) OrElse (preserveAcronyms AndAlso Char.IsUpper(text(i - 1)) AndAlso i < text.Length - 1 AndAlso Not Char.IsUpper(text(i + 1))) Then
    '                newText.Append(" "c)
    '            End If
    '        End If
    '        newText.Append(text(i))
    '    Next
    '    Return newText.ToString()
    'End Function

#End Region

End Class