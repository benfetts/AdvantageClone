Namespace Conventions

    Public Class DecimalPrecisionAttributeConvention
        Inherits System.Data.Entity.ModelConfiguration.Conventions.PrimitivePropertyAttributeConfigurationConvention(Of Attributes.DecimalPrecisionAttribute)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Overrides Sub Apply(configuration As System.Data.Entity.ModelConfiguration.Configuration.ConventionPrimitivePropertyConfiguration, attribute As Attributes.DecimalPrecisionAttribute)

            configuration.HasPrecision(attribute.Precision, attribute.Scale)

        End Sub

#End Region

    End Class

End Namespace
