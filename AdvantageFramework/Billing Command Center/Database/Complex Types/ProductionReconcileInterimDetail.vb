Namespace BillingCommandCenter.Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="BCCObjectContext", Name:="ProductionReconcileInterimDetail")>
    <Serializable()>
    Public Class ProductionReconcileInterimDetail
        Inherits BaseClasses.ComplexType

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

        Private _FNC_CODE As String = Nothing
        Private _FNC_TYPE As String = Nothing
        Private _FNC_DESCRIPTION As String = Nothing
        Private _ITEM_ID As Integer = Nothing
        Private _LINE_NUMBER As Nullable(Of Short) = Nothing
        Private _AP_SEQ As Nullable(Of Short) = Nothing
        Private _EXT_AMOUNT As Nullable(Of Decimal) = Nothing
        Private _EXT_MARKUP_AMT As Nullable(Of Decimal) = Nothing
        Private _EXT_STATE_RESALE As Nullable(Of Decimal) = Nothing
        Private _EXT_COUNTY_RESALE As Nullable(Of Decimal) = Nothing
        Private _EXT_CITY_RESALE As Nullable(Of Decimal) = Nothing
        Private _EXT_NONRESALE_TAX As Nullable(Of Decimal) = Nothing
        Private _LINE_TOTAL As Nullable(Of Decimal) = Nothing
        Private _BA_ID As Nullable(Of Integer) = Nothing
        Private _WIP_AMOUNT As Nullable(Of Decimal) = Nothing
        Private _AMOUNT As Nullable(Of Decimal) = Nothing
        Private _AB_FLAG As Nullable(Of Integer) = Nothing
        Private _AR_INV_NBR As Nullable(Of Integer) = Nothing
        Private _TAX_CODE As String = Nothing
        Private _GLACODE_STATE As String = Nothing
        Private _GLACODE_CNTY As String = Nothing
        Private _GLACODE_CITY As String = Nothing
        Private _PREV_REC As Nullable(Of Decimal) = Nothing
        Private _REC_FLAG As Nullable(Of Short) = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FNC_CODE() As String
            Get
                FNC_CODE = _FNC_CODE
            End Get
            Set(value As String)
                _FNC_CODE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FNC_TYPE() As String
            Get
                FNC_TYPE = _FNC_TYPE
            End Get
            Set(value As String)
                _FNC_TYPE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FNC_DESCRIPTION() As String
            Get
                FNC_DESCRIPTION = _FNC_DESCRIPTION
            End Get
            Set(value As String)
                _FNC_DESCRIPTION = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ITEM_ID() As Integer
            Get
                ITEM_ID = _ITEM_ID
            End Get
            Set(value As Integer)
                _ITEM_ID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LINE_NUMBER() As Nullable(Of Short)
            Get
                LINE_NUMBER = _LINE_NUMBER
            End Get
            Set(value As Nullable(Of Short))
                _LINE_NUMBER = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AP_SEQ() As Nullable(Of Short)
            Get
                AP_SEQ = _AP_SEQ
            End Get
            Set(value As Nullable(Of Short))
                _AP_SEQ = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EXT_AMOUNT() As Nullable(Of Decimal)
            Get
                EXT_AMOUNT = _EXT_AMOUNT
            End Get
            Set(value As Nullable(Of Decimal))
                _EXT_AMOUNT = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EXT_MARKUP_AMT() As Nullable(Of Decimal)
            Get
                EXT_MARKUP_AMT = _EXT_MARKUP_AMT
            End Get
            Set(value As Nullable(Of Decimal))
                _EXT_MARKUP_AMT = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EXT_STATE_RESALE() As Nullable(Of Decimal)
            Get
                EXT_STATE_RESALE = _EXT_STATE_RESALE
            End Get
            Set(value As Nullable(Of Decimal))
                _EXT_STATE_RESALE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EXT_COUNTY_RESALE() As Nullable(Of Decimal)
            Get
                EXT_COUNTY_RESALE = _EXT_COUNTY_RESALE
            End Get
            Set(value As Nullable(Of Decimal))
                _EXT_COUNTY_RESALE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EXT_CITY_RESALE() As Nullable(Of Decimal)
            Get
                EXT_CITY_RESALE = _EXT_CITY_RESALE
            End Get
            Set(value As Nullable(Of Decimal))
                _EXT_CITY_RESALE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EXT_NONRESALE_TAX() As Nullable(Of Decimal)
            Get
                EXT_NONRESALE_TAX = _EXT_NONRESALE_TAX
            End Get
            Set(value As Nullable(Of Decimal))
                _EXT_NONRESALE_TAX = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LINE_TOTAL() As Nullable(Of Decimal)
            Get
                LINE_TOTAL = _LINE_TOTAL
            End Get
            Set(value As Nullable(Of Decimal))
                _LINE_TOTAL = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BA_ID() As Nullable(Of Integer)
            Get
                BA_ID = _BA_ID
            End Get
            Set(value As Nullable(Of Integer))
                _BA_ID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WIP_AMOUNT() As Nullable(Of Decimal)
            Get
                WIP_AMOUNT = _WIP_AMOUNT
            End Get
            Set(value As Nullable(Of Decimal))
                _WIP_AMOUNT = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AMOUNT() As Nullable(Of Decimal)
            Get
                AMOUNT = _AMOUNT
            End Get
            Set(value As Nullable(Of Decimal))
                _AMOUNT = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AB_FLAG() As Nullable(Of Integer)
            Get
                AB_FLAG = _AB_FLAG
            End Get
            Set(value As Nullable(Of Integer))
                _AB_FLAG = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AR_INV_NBR() As Nullable(Of Integer)
            Get
                AR_INV_NBR = _AR_INV_NBR
            End Get
            Set(value As Nullable(Of Integer))
                _AR_INV_NBR = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TAX_CODE() As String
            Get
                TAX_CODE = _TAX_CODE
            End Get
            Set(value As String)
                _TAX_CODE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GLACODE_STATE() As String
            Get
                GLACODE_STATE = _GLACODE_STATE
            End Get
            Set(value As String)
                _GLACODE_STATE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GLACODE_CNTY() As String
            Get
                GLACODE_CNTY = _GLACODE_CNTY
            End Get
            Set(value As String)
                _GLACODE_CNTY = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GLACODE_CITY() As String
            Get
                GLACODE_CITY = _GLACODE_CITY
            End Get
            Set(value As String)
                _GLACODE_CITY = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PREV_REC() As Nullable(Of Decimal)
            Get
                PREV_REC = _PREV_REC
            End Get
            Set(value As Nullable(Of Decimal))
                _PREV_REC = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property REC_FLAG() As Nullable(Of Short)
            Get
                REC_FLAG = _REC_FLAG
            End Get
            Set(value As Nullable(Of Short))
                _REC_FLAG = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.FNC_CODE.ToString

        End Function

#End Region

    End Class

End Namespace
