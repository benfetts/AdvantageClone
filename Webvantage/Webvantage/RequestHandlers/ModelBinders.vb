Imports System.Web.Mvc

Namespace ModelBinders

    Public Class DateTimeModelBinder
        Implements System.Web.Mvc.IModelBinder

        Public Function BindModel(controllerContext As ControllerContext, bindingContext As ModelBindingContext) As Object Implements IModelBinder.BindModel

            Dim ValueProviderResult As ValueProviderResult = Nothing
            Dim DateTimeValue As DateTime = Nothing
            Dim IsDate As Boolean = False

            ValueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName)

            IsDate = DateTime.TryParse(ValueProviderResult.AttemptedValue, Threading.Thread.CurrentThread.CurrentUICulture, Globalization.DateTimeStyles.None, DateTimeValue)

            If Not IsDate Then

                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Invalid Date")
                Return DateTime.UtcNow

            End If

            Return DateTimeValue

        End Function

    End Class

    Public Class NullableDateTimeModelBinder
        Implements System.Web.Mvc.IModelBinder

        Public Function BindModel(controllerContext As ControllerContext, bindingContext As ModelBindingContext) As Object Implements IModelBinder.BindModel

            Dim ValueProviderResult As ValueProviderResult = Nothing
            Dim DateTimeValue As DateTime = Nothing
            Dim IsDate As Boolean = False

            ValueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName)

            If String.IsNullOrWhiteSpace(ValueProviderResult.AttemptedValue) Then

                Return Nothing

            End If

            IsDate = DateTime.TryParse(ValueProviderResult.AttemptedValue, Threading.Thread.CurrentThread.CurrentUICulture, Globalization.DateTimeStyles.None, DateTimeValue)

            If Not IsDate Then

                If (ValueProviderResult.AttemptedValue IsNot Nothing AndAlso ValueProviderResult.AttemptedValue.LastIndexOf("(") > 0) Then
                    IsDate = DateTime.TryParseExact(ValueProviderResult.AttemptedValue.Substring(0, ValueProviderResult.AttemptedValue.LastIndexOf("(") - 1), "ddd MMM dd yyyy hh:mm:ss 'GMT'K", System.Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, DateTimeValue)

                    'DateTime.ParseExact("Tue May 28 2019 00:00:00 GMT-0400", "ddd MMM dd yyyy hh:mm:ss 'GMT'K", CultureInfo.InvariantCulture)

                End If

                If Not IsDate Then
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Invalid Date")
                    If bindingContext.ModelName = "CutoffDate" Then
                        Return Nothing
                    Else
                        Return DateTime.UtcNow
                    End If

                End If

            End If

            Return DateTimeValue

        End Function

    End Class

End Namespace


