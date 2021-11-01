' Simply apply this attribute to a Test_OData_Service-derived class to get
' JSONP support in that service
<AttributeUsage(AttributeTargets.Class)> _
Public Class JSONPSupportBehaviorAttribute
    Inherits Attribute
    Implements System.ServiceModel.Description.IServiceBehavior

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region "IServiceBehavior Members"

    Private Sub AddBindingParameters(ByVal serviceDescription As System.ServiceModel.Description.ServiceDescription, ByVal serviceHostBase As ServiceHostBase, ByVal endpoints As System.Collections.ObjectModel.Collection(Of System.ServiceModel.Description.ServiceEndpoint), ByVal bindingParameters As System.ServiceModel.Channels.BindingParameterCollection) Implements System.ServiceModel.Description.IServiceBehavior.AddBindingParameters



    End Sub
    Private Sub ApplyDispatchBehavior(ByVal serviceDescription As System.ServiceModel.Description.ServiceDescription, ByVal serviceHostBase As ServiceHostBase) Implements System.ServiceModel.Description.IServiceBehavior.ApplyDispatchBehavior

        For Each cd As System.ServiceModel.Dispatcher.ChannelDispatcher In serviceHostBase.ChannelDispatchers

            For Each ed As System.ServiceModel.Dispatcher.EndpointDispatcher In cd.Endpoints

                ed.DispatchRuntime.MessageInspectors.Add(New JSONPSupportInspector())

            Next ed

        Next cd

    End Sub
    Private Sub Validate(ByVal serviceDescription As System.ServiceModel.Description.ServiceDescription, ByVal serviceHostBase As ServiceHostBase) Implements System.ServiceModel.Description.IServiceBehavior.Validate



    End Sub

#End Region

#End Region

End Class