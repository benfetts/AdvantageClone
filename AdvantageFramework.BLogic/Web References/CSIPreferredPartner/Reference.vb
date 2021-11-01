﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
'
Namespace CSIPreferredPartner
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="CSIPreferredPartnerSoap", [Namespace]:="http://localhost/AdvantageWebServices/")>  _
    Partial Public Class CSIPreferredPartner
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private SignAgreementOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.AdvantageFramework.My.MySettings.Default.AdvantageFramework_BLogic_CSIPreferredPartner_CSIPreferredPartner
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event SignAgreementCompleted As SignAgreementCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost/AdvantageWebServices/SignAgreement", RequestNamespace:="http://localhost/AdvantageWebServices/", ResponseNamespace:="http://localhost/AdvantageWebServices/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function SignAgreement(ByVal LicenseKey As String, ByVal UserCode As String, ByVal EmployeeCode As String, ByVal EmployeeName As String) As AgreementSignedResponse
            Dim results() As Object = Me.Invoke("SignAgreement", New Object() {LicenseKey, UserCode, EmployeeCode, EmployeeName})
            Return CType(results(0),AgreementSignedResponse)
        End Function
        
        '''<remarks/>
        Public Overloads Sub SignAgreementAsync(ByVal LicenseKey As String, ByVal UserCode As String, ByVal EmployeeCode As String, ByVal EmployeeName As String)
            Me.SignAgreementAsync(LicenseKey, UserCode, EmployeeCode, EmployeeName, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub SignAgreementAsync(ByVal LicenseKey As String, ByVal UserCode As String, ByVal EmployeeCode As String, ByVal EmployeeName As String, ByVal userState As Object)
            If (Me.SignAgreementOperationCompleted Is Nothing) Then
                Me.SignAgreementOperationCompleted = AddressOf Me.OnSignAgreementOperationCompleted
            End If
            Me.InvokeAsync("SignAgreement", New Object() {LicenseKey, UserCode, EmployeeCode, EmployeeName}, Me.SignAgreementOperationCompleted, userState)
        End Sub
        
        Private Sub OnSignAgreementOperationCompleted(ByVal arg As Object)
            If (Not (Me.SignAgreementCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent SignAgreementCompleted(Me, New SignAgreementCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3062.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://localhost/AdvantageWebServices/")>  _
    Partial Public Class AgreementSignedResponse
        
        Private clientCodeField As String
        
        Private errorMessageField As String
        
        Private signedField As Boolean
        
        '''<remarks/>
        Public Property ClientCode() As String
            Get
                Return Me.clientCodeField
            End Get
            Set
                Me.clientCodeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property ErrorMessage() As String
            Get
                Return Me.errorMessageField
            End Get
            Set
                Me.errorMessageField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Signed() As Boolean
            Get
                Return Me.signedField
            End Get
            Set
                Me.signedField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")>  _
    Public Delegate Sub SignAgreementCompletedEventHandler(ByVal sender As Object, ByVal e As SignAgreementCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class SignAgreementCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As AgreementSignedResponse
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),AgreementSignedResponse)
            End Get
        End Property
    End Class
End Namespace
