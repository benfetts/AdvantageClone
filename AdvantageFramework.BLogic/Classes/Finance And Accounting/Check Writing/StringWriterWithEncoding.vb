Namespace Classes.FinanceAndAccounting.CheckWriting

    Public Class StringWriterWithEncodingAPI
        Inherits IO.StringWriter

        Private _encoding As System.Text.Encoding

        Public Sub New(encoding As System.Text.Encoding)
            MyBase.New()
            _encoding = encoding
        End Sub

        Public Sub New(encoding As System.Text.Encoding, formatProvider As IFormatProvider)
            MyBase.New(formatProvider)
            _encoding = encoding
        End Sub

        Public Sub New(encoding As System.Text.Encoding, sb As System.Text.StringBuilder)
            MyBase.New(sb)
            _encoding = encoding
        End Sub

        Public Sub New(encoding As System.Text.Encoding, sb As System.Text.StringBuilder, formatProvider As IFormatProvider)
            MyBase.New(sb, formatProvider)
            _encoding = encoding
        End Sub

        Public Overrides ReadOnly Property Encoding As System.Text.Encoding
            Get
                Return _encoding
            End Get
        End Property

    End Class

End Namespace
