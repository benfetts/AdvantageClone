<Assembly: System.Data.Objects.DataClasses.EdmSchemaAttribute("fabcebba-6829-41ce-8bd7-c343eed42add")> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("BCCObjectContext", "BillingApprovalBatchBillingCommandCenters", "BillingApprovalBatch", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(BillingCommandCenter.Database.Entities.BillingApprovalBatch), "BillingCommandCenters", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(BillingCommandCenter.Database.Entities.BillingCommandCenter), True)> 

Namespace BillingCommandCenter.Database

    Public Class BCCObjectContext
        Inherits BaseClasses.DbContext

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            BillingApprovalBatches
            BillingCommandCenters
        End Enum

#End Region

#Region " Variables "

        Private _BillingApprovalBatches As System.Data.Objects.ObjectSet(Of Database.Entities.BillingApprovalBatch) = Nothing
        Private _BillingCommandCenters As System.Data.Objects.ObjectSet(Of Database.Entities.BillingCommandCenter) = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property BillingApprovalBatches() As System.Data.Objects.ObjectSet(Of Database.Entities.BillingApprovalBatch)
            Get

                If _BillingApprovalBatches Is Nothing Then

                    _BillingApprovalBatches = MyBase.CreateObjectSet(Of Database.Entities.BillingApprovalBatch)(Database.BCCObjectContext.Properties.BillingApprovalBatches.ToString)

                End If

                BillingApprovalBatches = _BillingApprovalBatches

            End Get
        End Property
        Public ReadOnly Property BillingCommandCenters() As System.Data.Objects.ObjectSet(Of Database.Entities.BillingCommandCenter)
            Get

                If _BillingCommandCenters Is Nothing Then

                    _BillingCommandCenters = MyBase.CreateObjectSet(Of Database.Entities.BillingCommandCenter)(Database.BCCObjectContext.Properties.BillingCommandCenters.ToString)

                End If

                BillingCommandCenters = _BillingCommandCenters

            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal ConnectionString As String, ByVal UserCode As String)

            MyBase.New(ConnectionString, UserCode, ObjectContextType.BillingCommandCenter)

        End Sub

#End Region

    End Class

End Namespace