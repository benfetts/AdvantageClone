﻿Namespace Classes.FinanceAndAccounting.CheckWriting.HSBCExportExp

    <XmlRoot(ElementName:="OrgId", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
    Public Class OrgId

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <XmlElement(ElementName:="Othr", [Namespace]:="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")>
        Public Property Othr As Othr

#End Region

#Region " Methods "

        Public Sub New()

            Me.Othr = New Othr

        End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
