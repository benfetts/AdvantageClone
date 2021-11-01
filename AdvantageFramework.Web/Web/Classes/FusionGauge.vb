Namespace Web.FusionLinearGauge

    Public Class Gauge

        Public ReadOnly Property type As String
            Get
                Return "hlineargauge"
            End Get
        End Property
        Public Property renderAt As String
        Public ReadOnly Property id As String
            Get
                Return "cs-linear-gauge"
            End Get
        End Property
        Public Property width As String
        Public Property height As String
        Public ReadOnly Property dataFormat As String
            Get
                Return "json"
            End Get
        End Property
        Public Property dataSource As DataSource

        Public Function SerializeAsJson() As String

            Try

                Return New System.Web.Script.Serialization.JavaScriptSerializer().Serialize(Me)

            Catch ex As Exception
                Return ""
            End Try

        End Function
        Public Sub New()

            Me.dataSource = New DataSource

        End Sub

    End Class

    Public Class DataSource

        Public Property chart As Chart
        Public Property colorRange As ColorRange
        Public Property pointers As Pointers
        Public Property trendpoints As TreadPoints

        Public Sub New()

            Me.chart = New Chart
            Me.colorRange = New ColorRange
            Me.pointers = New Pointers
            Me.trendpoints = New TreadPoints

        End Sub

    End Class

    Public Class Chart

        Public Property manageresize As String
        Public Property showborder As String
        Public Property upperlimit As String
        Public Property lowerlimit As String
        Public Property gaugeroundradius As String
        Public Property chartbottommargin As String
        Public Property ticksbelowgauge As String
        Public Property showgaugelabels As String
        Public Property valueabovepointer As String
        Public Property pointerontop As String
        Public Property pointerradius As String
        Public Property numberprefix As String
        Public Property majorTMNumber As String
        Public Property bgColor As String
        Public Property bgAlpha As String
        Public Property canvasBgColor As String
        Public Property canvasBgAlpha As String
        Public Property forceTickValueDecimals As String
        Public Property adjustTM As String
        Public Property decimalSeparator As String
        Public Property thousandSeparator As String

    End Class

    Public Class ColorRange

        Public Property color As Color()

    End Class

    Public Class Color

        Public Property minValue As String
        Public Property maxValue As String
        Public Property label As String
        Public Property code As String

    End Class

    Public Class Pointers

        Public Property pointer As Pointer()

    End Class

    Public Class Pointer

        Public Property value As String

    End Class

    Public Class TreadPoints

        Public Property point As Point()

    End Class

    Public Class Point

        Public Property startvalue As String
        Public Property displayvalue As String
        Public Property dashed As String
        Public Property color As String
        Public Property thickness As String
        Public Property useMarker As String
        Public Property markerBorderColor As String
        Public Property markerColor As String
        Public Property markerTooltext As String

    End Class

End Namespace