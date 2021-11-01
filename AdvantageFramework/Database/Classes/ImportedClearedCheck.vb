Namespace Database.Classes

    <Serializable()>
    Public Class ImportedClearedCheck
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            BatchName
            FileName
            BankCode
            CheckNumber
            InvalidCheckNumber
            CheckVoid
            PreviouslyCleared
            CheckRegisterAmount
            ImportedCheckAmount
            Variance
            VendorName
            CheckClearedDate
            IsValid
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = 0
        Private _BatchName As String = ""
        Private _FileName As String = ""
        Private _BankCode As String = ""
        Private _CheckNumber As String = ""
        Private _InvalidCheckNumber As Boolean = False
        Private _CheckVoid As Boolean = False
        Private _PreviouslyCleared As Boolean = False
        Private _CheckRegisterAmount As Decimal = 0
        Private _ImportedCheckAmount As Decimal = 0
        Private _Variance As Decimal = 0
        Private _VendorName As String = ""
        Private _CheckClearedDate As Nullable(Of Date) = Nothing
        Private _IsValid As Boolean = False

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As Integer
            Get
                ID = _ID
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property BatchName() As String
            Get
                BatchName = _BatchName
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property FileName() As String
            Get
                FileName = _FileName
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Bank - Check Number")>
        Public ReadOnly Property BankCheckNumber() As String
            Get
                BankCheckNumber = _BankCode & " - " & _CheckNumber
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property InvalidCheckNumber() As Boolean
            Get
                InvalidCheckNumber = _InvalidCheckNumber
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property CheckVoid() As Boolean
            Get
                CheckVoid = _CheckVoid
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property PreviouslyCleared() As Boolean
            Get
                PreviouslyCleared = _PreviouslyCleared
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property CheckRegisterAmount() As Decimal
            Get
                CheckRegisterAmount = _CheckRegisterAmount
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ImportedCheckAmount() As Decimal
            Get
                ImportedCheckAmount = _ImportedCheckAmount
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Variance() As Decimal
            Get
                Variance = _Variance
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property CheckClearedDate() As Nullable(Of Date)
            Get
                CheckClearedDate = _CheckClearedDate
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property IsValid() As Boolean
            Get
                IsValid = _IsValid
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal ImportClearedChecksStaging As AdvantageFramework.Database.Entities.ImportClearedChecksStaging)

            Me.New(ImportClearedChecksStaging.DbContext, ImportClearedChecksStaging)

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportClearedChecksStaging As AdvantageFramework.Database.Entities.ImportClearedChecksStaging)

            If DbContext IsNot Nothing AndAlso ImportClearedChecksStaging IsNot Nothing Then

                _ID = ImportClearedChecksStaging.ID
                _BatchName = ImportClearedChecksStaging.BatchName
                _FileName = ImportClearedChecksStaging.FileName
                _BankCode = ImportClearedChecksStaging.BankCode
                _CheckNumber = ImportClearedChecksStaging.CheckNumber

                If String.IsNullOrEmpty(_CheckNumber) = False AndAlso IsNumeric(_CheckNumber) Then

                    If (From CheckRegister In AdvantageFramework.Database.Procedures.CheckRegister.Load(DbContext) _
                            Where CheckRegister.BankCode = ImportClearedChecksStaging.BankCode AndAlso _
                                  CheckRegister.CheckNumber = CInt(ImportClearedChecksStaging.CheckNumber) _
                            Select CheckRegister).Any = False Then

                        _InvalidCheckNumber = True

                    Else

                        _InvalidCheckNumber = False

                    End If

                Else

                    _InvalidCheckNumber = True

                End If

                If _InvalidCheckNumber = False Then

                    If (From CheckRegister In AdvantageFramework.Database.Procedures.CheckRegister.Load(DbContext) _
                        Where CheckRegister.BankCode = ImportClearedChecksStaging.BankCode AndAlso _
                              CheckRegister.CheckNumber = CInt(ImportClearedChecksStaging.CheckNumber) AndAlso _
                              CheckRegister.IsVoid = 1 _
                        Select CheckRegister).Any Then

                        _CheckVoid = True

                    Else

                        _CheckVoid = False

                    End If

                    If (From CheckRegister In AdvantageFramework.Database.Procedures.CheckRegister.Load(DbContext) _
                            Where CheckRegister.BankCode = ImportClearedChecksStaging.BankCode AndAlso _
                                  CheckRegister.CheckNumber = CInt(ImportClearedChecksStaging.CheckNumber) AndAlso _
                                  CheckRegister.IsCleared = 1 _
                            Select CheckRegister).Any Then

                        _PreviouslyCleared = True

                    Else

                        _PreviouslyCleared = False

                    End If

                Else

                    _PreviouslyCleared = False
                    _CheckVoid = False

                End If

                If _PreviouslyCleared = False AndAlso _CheckVoid = False AndAlso _InvalidCheckNumber = False Then

                    Try

                        _CheckRegisterAmount = (From CheckRegister In AdvantageFramework.Database.Procedures.CheckRegister.Load(DbContext) _
                                                Where CheckRegister.BankCode = ImportClearedChecksStaging.BankCode AndAlso _
                                                      CheckRegister.CheckNumber = CInt(ImportClearedChecksStaging.CheckNumber) _
                                                Select CheckRegister.CheckAmount).Sum

                    Catch ex As Exception
                        _CheckRegisterAmount = 0
                    End Try

                Else

                    _CheckRegisterAmount = 0

                End If

                _ImportedCheckAmount = ImportClearedChecksStaging.CheckAmount.GetValueOrDefault(0)
                _Variance = _CheckRegisterAmount - _ImportedCheckAmount
                _VendorName = ImportClearedChecksStaging.VendorName
                _CheckClearedDate = ImportClearedChecksStaging.CheckClearedDate

                If _PreviouslyCleared = False AndAlso _CheckVoid = False AndAlso _InvalidCheckNumber = False Then

                    If _Variance = 0 Then

                        _IsValid = True

                    Else

                        _IsValid = False

                    End If

                Else

                    _IsValid = False

                End If

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
