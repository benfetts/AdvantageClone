Namespace MediaManager.Classes

    <Serializable()>
    Public Class VCCDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            SequenceNumber
            MerchantName
            Action
            Amount
            Reference
            Processed
            ProcessDateTime
        End Enum

#End Region

#Region " Variables "

        Private _VCCCardDetail As AdvantageFramework.Database.Interfaces.IVCCCardDetail = Nothing
        Private _VCCProviderID As Short = Nothing
        Private _TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset = Nothing

#End Region

#Region " Properties "

        '<System.Runtime.Serialization.DataMemberAttribute(),
        'AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Seq #")>
        'Public ReadOnly Property SequenceNumber() As Short
        '    Get
        '        SequenceNumber = _VCCCardDetail.SequenceNumber
        '    End Get
        'End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property MerchantName() As String
            Get
                MerchantName = _VCCCardDetail.MerchantName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Action() As String
            Get

                Select Case _VCCCardDetail.Action

                    Case AdvantageFramework.Database.Entities.VCCAction.ClearedTransaction

                        Action = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VCCAction.ClearedTransaction).Description

                    Case AdvantageFramework.Database.Entities.VCCAction.CreditCardRequest

                        Action = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VCCAction.CreditCardRequest).Description

                    Case AdvantageFramework.Database.Entities.VCCAction.CreditCardUpdate

                        Action = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VCCAction.CreditCardUpdate).Description

                    Case AdvantageFramework.Database.Entities.VCCAction.PendingTransaction

                        Action = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VCCAction.PendingTransaction).Description

                    Case AdvantageFramework.Database.Entities.VCCAction.RejectedTransaction

                        Action = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VCCAction.RejectedTransaction).Description

                    Case Else

                        Action = "Undefined"

                End Select

            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Amount() As Decimal
            Get
                Amount = _VCCCardDetail.Amount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Reference() As String
            Get
                If _VCCCardDetail.Action = AdvantageFramework.Database.Entities.VCCAction.RejectedTransaction AndAlso _VCCProviderID = AdvantageFramework.VCC.VCCProviders.EFS Then

                    Reference = _VCCCardDetail.RejectMessage

                Else

                    Reference = _VCCCardDetail.ReferenceNumber

                End If
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Processed() As String
            Get
                Processed = AdvantageFramework.VCC.DisplayLocalDate(_TimezoneOffset, _VCCCardDetail.ProcessDateTime).Value.ToString("G")
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ProcessDateTime() As Date
            Get
                ProcessDateTime = _VCCCardDetail.ProcessDateTime
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(VCCCardDetail As AdvantageFramework.Database.Interfaces.IVCCCardDetail, VCCProviderID As Short, TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset)

            Me.New()

            _VCCCardDetail = VCCCardDetail
            _VCCProviderID = VCCProviderID
            _TimezoneOffset = TimezoneOffset

        End Sub

#End Region

    End Class

End Namespace