Namespace BaseClasses

    <Serializable>
    Public MustInherit Class EntityView

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
        Public Function CreateXML() As String

            CreateXML = AdvantageFramework.BaseClasses.CreateXML(Me)

        End Function
        Public Function ImportFromXML(ByVal XML As String) As AdvantageFramework.BaseClasses.Entity

            ImportFromXML = AdvantageFramework.BaseClasses.ImportFromXML(XML, Me.GetType)

        End Function

#End Region

    End Class

End Namespace
