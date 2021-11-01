Namespace BaseClasses

    <Serializable()> Public MustInherit Class BaseCore

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "


#End Region

#Region " Properties "

        

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Protected Sub SetValues(ByVal Entity As Object)

            'objects
            Dim PropDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            If Entity IsNot Nothing Then

                For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                    Try

                        PropDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(Entity).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(Prop) Prop.Name = PropertyDescriptor.Name).SingleOrDefault

                    Catch ex As Exception
                        PropDescriptor = Nothing
                    End Try

                    If PropDescriptor IsNot Nothing Then

                        Try

                            PropertyDescriptor.SetValue(Me, PropDescriptor.GetValue(Entity))

                        Catch ex As Exception

                        End Try

                    End If

                Next

            End If

        End Sub
        Public Sub SetPropertyValue(ByVal PropertyName As String, ByVal NewValue As Object)

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                PropertyDescriptor = (From [Property] In System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)() _
                                      Where [Property].Name = PropertyName _
                                      Select [Property]).SingleOrDefault

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            If PropertyDescriptor IsNot Nothing Then

                PropertyDescriptor.SetValue(Me, NewValue)

            End If

        End Sub

#End Region

    End Class

End Namespace