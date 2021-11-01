Namespace Database.Classes

    <Serializable()>
    Public Class BillingRate
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            BILLING_RATE
            RATE_LEVEL
            TAX_CODE
            TAX_LEVEL
            NOBILL_FLAG
            NOBILL_LEVEL
            COMM
            COMM_LEVEL
            TAX_COMM
            TAX_COMM_ONLY
            TAX_COMM_FLAGS_LEVEL
            FEE_TIME_FLAG
            FEE_TIME_LEVEL
        End Enum

#End Region

#Region " Variables "

        Private _BILLING_RATE As System.Nullable(Of Decimal) = Nothing
        Private _RATE_LEVEL As System.Nullable(Of Short) = Nothing
        Private _TAX_CODE As String = Nothing
        Private _TAX_LEVEL As System.Nullable(Of Short) = Nothing
        Private _NOBILL_FLAG As System.Nullable(Of Short) = Nothing
        Private _NOBILL_LEVEL As System.Nullable(Of Short) = Nothing
        Private _COMM As System.Nullable(Of Decimal) = Nothing
        Private _COMM_LEVEL As System.Nullable(Of Short) = Nothing
        Private _TAX_COMM As System.Nullable(Of Short) = Nothing
        Private _TAX_COMM_ONLY As System.Nullable(Of Short) = Nothing
        Private _TAX_COMM_FLAGS_LEVEL As System.Nullable(Of Short) = Nothing
        Private _FEE_TIME_FLAG As System.Nullable(Of Short) = Nothing
        Private _FEE_TIME_LEVEL As System.Nullable(Of Short) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BILLING_RATE() As System.Nullable(Of Decimal)
            Get
                BILLING_RATE = _BILLING_RATE
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _BILLING_RATE = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property RATE_LEVEL() As System.Nullable(Of Short)
            Get
                RATE_LEVEL = _RATE_LEVEL
            End Get
            Set(ByVal value As System.Nullable(Of Short))
                _RATE_LEVEL = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property TAX_CODE As String
            Get
                TAX_CODE = _TAX_CODE
            End Get
            Set(ByVal value As String)
                _TAX_CODE = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property TAX_LEVEL As System.Nullable(Of Short)
            Get
                TAX_LEVEL = _TAX_LEVEL
            End Get
            Set(ByVal value As System.Nullable(Of Short))
                _TAX_LEVEL = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property NOBILL_FLAG As System.Nullable(Of Short)
            Get
                NOBILL_FLAG = _NOBILL_FLAG
            End Get
            Set(ByVal value As System.Nullable(Of Short))
                _NOBILL_FLAG = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property NOBILL_LEVEL As System.Nullable(Of Short)
            Get
                NOBILL_LEVEL = _NOBILL_LEVEL
            End Get
            Set(ByVal value As System.Nullable(Of Short))
                _NOBILL_LEVEL = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property COMM As System.Nullable(Of Decimal)
            Get
                COMM = _COMM
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _COMM = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property COMM_LEVEL As System.Nullable(Of Short)
            Get
                COMM_LEVEL = _COMM_LEVEL
            End Get
            Set(ByVal value As System.Nullable(Of Short))
                _COMM_LEVEL = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property TAX_COMM As System.Nullable(Of Short)
            Get
                TAX_COMM = _TAX_COMM
            End Get
            Set(ByVal value As System.Nullable(Of Short))
                _TAX_COMM = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property TAX_COMM_ONLY As System.Nullable(Of Short)
            Get
                TAX_COMM_ONLY = _TAX_COMM_ONLY
            End Get
            Set(ByVal value As System.Nullable(Of Short))
                _TAX_COMM_ONLY = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property TAX_COMM_FLAGS_LEVEL As System.Nullable(Of Short)
            Get
                TAX_COMM_FLAGS_LEVEL = _TAX_COMM_FLAGS_LEVEL
            End Get
            Set(ByVal value As System.Nullable(Of Short))
                _TAX_COMM_FLAGS_LEVEL = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property FEE_TIME_FLAG As System.Nullable(Of Short)
            Get
                FEE_TIME_FLAG = _FEE_TIME_FLAG
            End Get
            Set(ByVal value As System.Nullable(Of Short))
                _FEE_TIME_FLAG = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property FEE_TIME_LEVEL As System.Nullable(Of Short)
            Get
                FEE_TIME_LEVEL = _FEE_TIME_LEVEL
            End Get
            Set(ByVal value As System.Nullable(Of Short))
                _FEE_TIME_LEVEL = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Function GetLevelDescription(ByVal DbContext As AdvantageFramework.Database.DbContext, Optional ByVal LevelNumber As Integer = Nothing) As String

            'objects
            Dim BillingRateLevelDescription As String = ""

            If LevelNumber <> Nothing Then

                Try

                    BillingRateLevelDescription = (From Entity In DbContext.GetQuery(Of Database.Entities.BillingRateLevel)
                                                   Where Entity.Number = LevelNumber
                                                   Select [Description] = Entity.Number & " - " & Entity.Description).SingleOrDefault

                Catch ex As Exception
                    BillingRateLevelDescription = ""
                End Try

            End If

            GetLevelDescription = BillingRateLevelDescription

        End Function

#End Region

    End Class

End Namespace