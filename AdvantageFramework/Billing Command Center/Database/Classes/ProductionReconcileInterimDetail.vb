Namespace BillingCommandCenter.Database.Classes

    <Serializable()>
    Public Class ProductionReconcileInterimDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            FNCCODE
            FNCTYPE
            FNCDESCRIPTION
            ITEMID
            LINENUMBER
            APSEQ
            EXTAMOUNT
            EXTMARKUPAMT
            EXTSTATERESALE
            EXTCOUNTYRESALE
            EXTCITYRESALE
            EXTNONRESALETAX
            LINETOTAL
            BAID
            WIPAMOUNT
            AMOUNT
            ABFLAG
            ARINVNBR
            TAXCODE
            GLACODESTATE
            GLACODECNTY
            GLACODECITY
            PREVREC
            RECFLAG
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property FNC_CODE() As String

        Public Property FNC_TYPE() As String

        Public Property FNC_DESCRIPTION() As String

        Public Property ITEM_ID() As Integer

        Public Property LINE_NUMBER() As Nullable(Of Short)

        Public Property AP_SEQ() As Nullable(Of Short)

        Public Property EXT_AMOUNT() As Nullable(Of Decimal)

        Public Property EXT_MARKUP_AMT() As Nullable(Of Decimal)

        Public Property EXT_STATE_RESALE() As Nullable(Of Decimal)

        Public Property EXT_COUNTY_RESALE() As Nullable(Of Decimal)

        Public Property EXT_CITY_RESALE() As Nullable(Of Decimal)

        Public Property EXT_NONRESALE_TAX() As Nullable(Of Decimal)

        Public Property LINE_TOTAL() As Nullable(Of Decimal)

        Public Property BA_ID() As Nullable(Of Integer)

        Public Property WIP_AMOUNT() As Nullable(Of Decimal)

        Public Property AMOUNT() As Nullable(Of Decimal)

        Public Property AB_FLAG() As Nullable(Of Integer)

        Public Property AR_INV_NBR() As Nullable(Of Integer)

        Public Property TAX_CODE() As String

        Public Property GLACODE_STATE() As String

        Public Property GLACODE_CNTY() As String

        Public Property GLACODE_CITY() As String

        Public Property PREV_REC() As Nullable(Of Decimal)

        Public Property REC_FLAG() As Nullable(Of Short)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.FNC_CODE.ToString

        End Function

#End Region

    End Class

End Namespace
