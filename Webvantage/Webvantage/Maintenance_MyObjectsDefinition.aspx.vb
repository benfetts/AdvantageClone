Public Class Maintenance_MyObjectsDefinition
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

#End Region

#Region " Properties "



#End Region

#Region " Page Events "

    Private Sub Maintenance_MyObjectsDefinition_Init(sender As Object, e As EventArgs) Handles Me.Init

    End Sub
    Private Sub Maintenance_MyObjectsDefinition_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.BindRadioButtonListObjectType()
            Me.BindRadListBoxObjects()

        End If

    End Sub

#End Region

#Region " Controls Events "

    Public Sub CheckBoxIsChecked_CheckedChanged(sender As Object, e As EventArgs)

        Dim ThisCheckbox As CheckBox = CType(sender, CheckBox)
        Dim ThisRow As Telerik.Web.UI.GridDataItem = DirectCast(ThisCheckbox.Parent.Parent, Telerik.Web.UI.GridDataItem)

        If Not ThisRow Is Nothing Then

            Dim m As New AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Methods(Session("ConnString"), Session("UserCode"), HttpContext.Current)
            Dim s As String = ""
            If m.UpdateObjectDefinitionSetting(ThisRow.GetDataKeyValue("Id"), ThisRow.GetDataKeyValue("Object.Id"), _
                                               ThisRow.GetDataKeyValue("Definition.Id"), _
                                               ThisRow.GetDataKeyValue("Definition.IsStatic"), ThisCheckbox.Checked, s) = True Then

                Me.RadGridMyObjectSettings.Rebind()

            Else

                Me.ShowMessage(s)

            End If

        End If

    End Sub
    Private Sub RadGridMyObjectSettings_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridMyObjectSettings.NeedDataSource

        Dim ObjectId As Integer = 0

        If Me.RadListBoxObjects.SelectedIndex > -1 Then

            ObjectId = CType(Me.RadListBoxObjects.SelectedValue, Integer)

        End If

        Dim m As New AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Methods(Session("ConnString"), Session("UserCode"), HttpContext.Current)

        With Me.RadGridMyObjectSettings

            .DataSource = m.LoadObjectDefinitions(ObjectId, False)

        End With

        'test
        Me.RadGridTest.Rebind()

    End Sub
    Private Sub RadioButtonListObjectType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonListObjectType.SelectedIndexChanged

        Me.BindRadListBoxObjects()
        Me.RadGridMyObjectSettings.Rebind()

    End Sub
    Private Sub RadListBoxObjects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadListBoxObjects.SelectedIndexChanged

        Me.RadGridMyObjectSettings.Rebind()

    End Sub

#End Region

#Region " Methods "

    Private Sub BindRadioButtonListObjectType()

        With Me.RadioButtonListObjectType

            .Items.Clear()
            .DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.ObjectType))
            .DataTextField = "Value"
            .DataValueField = "Key"
            .DataBind()

        End With

        If Me.RadioButtonListObjectType.Items.Count > 0 Then

            Me.RadioButtonListObjectType.Items(0).Selected = True

        End If

    End Sub
    Private Sub BindRadListBoxObjects()

        If Me.RadioButtonListObjectType.Items.Count > 0 AndAlso Not Me.RadioButtonListObjectType.SelectedItem Is Nothing AndAlso IsNumeric(Me.RadioButtonListObjectType.SelectedItem.Value) = True Then

            Dim m As New AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Methods(Session("ConnString"), Session("UserCode"), HttpContext.Current)

            With RadListBoxObjects

                .Items.Clear()
                .DataSource = m.LoadObjects(CType(Me.RadioButtonListObjectType.SelectedItem.Value, Integer))
                .DataTextField = "Description"
                .DataValueField = "Id"
                .DataBind()

            End With

        End If

    End Sub

#End Region

    Private Sub RadGridTest_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridTest.NeedDataSource
        Dim ObjectId As Integer = 0

        If Me.RadListBoxObjects.SelectedIndex > -1 Then

            ObjectId = CType(Me.RadListBoxObjects.SelectedValue, Integer)

        End If
        Dim m As New AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Methods(Session("ConnString"), Session("UserCode"), HttpContext.Current)

        With Me.RadGridTest

            .DataSource = m.LoadEmployeeDynamicRestrictionDatatable(ObjectId, Session("EmpCode"))

        End With

    End Sub
End Class