Namespace Web

    Public Class JsonResponseFactory

        Public Shared Function ErrorResponse(ByVal Message As String) As Object

            Return New With {.Success = False, .Message = Message}

        End Function
        Public Shared Function SuccessResponse() As Object

            Return New With {.Success = True}

        End Function
        Public Shared Function SuccessResponse(ByVal Data As Object) As Object

            Return New With {.Success = True, .Data = Data}

        End Function
        Public Shared Function Response(ByVal Success As Boolean, Optional ByVal Message As String = "", Optional ByVal Data As Object = Nothing) As Object

            Return New With {.Success = Success,
                             .Message = Message,
                             .Data = Data}

        End Function

    End Class

End Namespace


