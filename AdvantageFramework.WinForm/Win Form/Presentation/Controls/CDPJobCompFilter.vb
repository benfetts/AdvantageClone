Namespace WinForm.Presentation.Controls

    Public Class CDPJobCompFilter

        Public Event ClientChangedEvent()
        Public Event DivisionChangedEvent()
        Public Event ProductChangedEvent()
        Public Event JobChangedEvent()
        Public Event ComponentChangedEvent()
        Public Event ClientChangingEvent(ByRef Cancel As Boolean)
        Public Event DivisionChangingEvent(ByRef Cancel As Boolean)
        Public Event ProductChangingEvent(ByRef Cancel As Boolean)
        Public Event JobChangingEvent(ByRef Cancel As Boolean)
        Public Event ComponentChangingEvent(ByRef Cancel As Boolean)

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

        Private _ClientDisplayControl As System.Windows.Forms.Control = Nothing
        Private _DivisionDisplayControl As System.Windows.Forms.Control = Nothing
        Private _ProductDisplayControl As System.Windows.Forms.Control = Nothing
        Private _JobDisplayControl As System.Windows.Forms.Control = Nothing
        Private _JobComponentDisplayControl As System.Windows.Forms.Control = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _JobNumber As Integer? = Nothing
        Private _JobComponentNumber As Short? = Nothing
        Private _JobComponentID As Integer? = Nothing
        Private _ClientSource As IEnumerable = Nothing
        Private _DivisionSource As IEnumerable = Nothing
        Private _ProductSource As IEnumerable = Nothing
        Private _JobSource As IEnumerable = Nothing
        Private _JobComponentSource As IEnumerable = Nothing
        Private _IsProcessing As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

        <System.ComponentModel.Browsable(True)>
        Public Property ClientDisplayControl As System.Windows.Forms.Control
            Get
                ClientDisplayControl = _ClientDisplayControl
            End Get
            Set(value As System.Windows.Forms.Control)
                _ClientDisplayControl = value
                SetupControl(_ClientDisplayControl)
            End Set
        End Property
        <System.ComponentModel.Browsable(True)>
        Public Property DivisionDisplayControl As System.Windows.Forms.Control
            Get
                DivisionDisplayControl = _DivisionDisplayControl
            End Get
            Set(value As System.Windows.Forms.Control)
                _DivisionDisplayControl = value
                SetupControl(_DivisionDisplayControl)
            End Set
        End Property
        <System.ComponentModel.Browsable(True)>
        Public Property ProductDisplayControl As System.Windows.Forms.Control
            Get
                ProductDisplayControl = _ProductDisplayControl
            End Get
            Set(value As System.Windows.Forms.Control)
                _ProductDisplayControl = value
                SetupControl(_ProductDisplayControl)
            End Set
        End Property
        <System.ComponentModel.Browsable(True)>
        Public Property JobDisplayControl As System.Windows.Forms.Control
            Get
                JobDisplayControl = _JobDisplayControl
            End Get
            Set(value As System.Windows.Forms.Control)
                _JobDisplayControl = value
                SetupControl(_JobDisplayControl)
            End Set
        End Property
        <System.ComponentModel.Browsable(True)>
        Public Property JobComponentDisplayControl As System.Windows.Forms.Control
            Get
                JobComponentDisplayControl = _JobComponentDisplayControl
            End Get
            Set(value As System.Windows.Forms.Control)
                _JobComponentDisplayControl = value
                SetupControl(_JobComponentDisplayControl)
            End Set
        End Property
        <System.ComponentModel.Browsable(False)>
        Public Property ClientSource As IEnumerable
            Get
                ClientSource = GetClients()
            End Get
            Set(value As IEnumerable)
                _ClientSource = LoadDataView(value)
            End Set
        End Property
        <System.ComponentModel.Browsable(False)>
        Public Property DivisionSource(Optional ByVal IncludeCode As String = "") As IEnumerable
            Get
                DivisionSource = GetDivisions(IncludeCode)
            End Get
            Set(value As IEnumerable)
                _DivisionSource = LoadDataView(value)
            End Set
        End Property
        <System.ComponentModel.Browsable(False)>
        Public Property ProductSource(Optional ByVal IncludeCode As String = "") As IEnumerable
            Get
                ProductSource = GetProducts(IncludeCode)
            End Get
            Set(value As IEnumerable)
                _ProductSource = LoadDataView(value)
            End Set
        End Property
        <System.ComponentModel.Browsable(False)>
        Public Property JobSource As IEnumerable
            Get
                JobSource = GetJobs()
            End Get
            Set(value As IEnumerable)
                _JobSource = LoadDataView(value)
            End Set
        End Property
        <System.ComponentModel.Browsable(False)>
        Public Property JobComponentSource As IEnumerable
            Get
                JobComponentSource = GetJobComponents()
            End Get
            Set(value As IEnumerable)
                _JobComponentSource = LoadDataView(value)
            End Set
        End Property
        Public Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                SetClient(value)
            End Set
        End Property
        Public Property DivisionCode As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                SetDivision(value)
            End Set
        End Property
        Public Property ProductCode As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                SetProduct(value)
            End Set
        End Property
        Public Property JobNumber As Integer?
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Integer?)
                SetJob(value.GetValueOrDefault(0))
            End Set
        End Property
        Public Property JobComponentNumber As Short?
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Short?)
                SetJobComponent(value.GetValueOrDefault(0))
            End Set
        End Property
        Public ReadOnly Property JobComponentID As Integer?
            Get
                JobComponentID = _JobComponentID
            End Get
        End Property

#End Region

#Region " Methods "

#Region "  Client Methods "

        Private Sub SetClient(ByVal ClientCode As String)

            'objects
            Dim Cancel As Boolean = False

            If _ClientCode <> ClientCode Then

                RaiseEvent ClientChangingEvent(Cancel)

                If Cancel = False Then

                    _ClientCode = ClientCode

                End If

                If String.IsNullOrWhiteSpace(_ClientCode) Then

                    _ClientCode = Nothing

                End If

                SetDisplayControlValue(_ClientDisplayControl)

                If _IsProcessing = False Then

                    ProcessClientChanged()

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Function GetClients() As IEnumerable

            GetClients = _ClientSource

        End Function
        Private Sub ProcessClientChanged()

            _IsProcessing = True

            Try

                Me.DivisionCode = Nothing
                Me.ProductCode = Nothing
                Me.JobNumber = Nothing
                Me.JobComponentNumber = Nothing

                ReloadDisplayControlDataSource(_DivisionDisplayControl)
                ReloadDisplayControlDataSource(_ProductDisplayControl)
                ReloadDisplayControlDataSource(_JobDisplayControl, Not String.IsNullOrWhiteSpace(Me.ProductCode))
                ReloadDisplayControlDataSource(_JobComponentDisplayControl)
                
                SelectSingleDivision()
                SelectSingleProduct()
                SelectSingleJob()
                SelectSingleJobComponent()

                RaiseEvent ClientChangedEvent()

            Catch ex As Exception

            End Try

            _IsProcessing = False

        End Sub
        Private Sub SelectSingleClient()

            'objects
            Dim Clients As IEnumerable = Nothing
            Dim Client As Object = Nothing

            Clients = GetClients()

            If Clients IsNot Nothing Then

                If (From Entity In Clients _
                    Select Entity).Count = 1 Then

                    Client = (From Entity In Clients _
                                Select Entity).SingleOrDefault

                    If TypeOf Client Is AdvantageFramework.Database.Entities.Client Then

                        Me.ClientCode = DirectCast(Client, AdvantageFramework.Database.Entities.Client).Code

                    ElseIf TypeOf Client Is AdvantageFramework.Database.Core.Client Then

                        Me.ClientCode = DirectCast(Client, AdvantageFramework.Database.Core.Client).Code

                    End If

                    RaiseEvent ClientChangedEvent()

                    _DivisionDisplayControl.Focus()

                    ReloadDisplayControlDataSource(_DivisionDisplayControl)
                    ReloadDisplayControlDataSource(_ProductDisplayControl)
                    ReloadDisplayControlDataSource(_JobDisplayControl, Not String.IsNullOrWhiteSpace(Me.ProductCode))
                    ReloadDisplayControlDataSource(_JobComponentDisplayControl)

                End If

            End If

        End Sub

#End Region

#Region "  Division Methods "

        Private Sub SetDivision(ByVal DivisionCode As String)

            'objects
            Dim Cancel As Boolean = False

            If _DivisionCode <> DivisionCode Then

                RaiseEvent DivisionChangingEvent(Cancel)

                If Cancel = False Then

                    _DivisionCode = DivisionCode

                End If

                If String.IsNullOrWhiteSpace(_DivisionCode) Then

                    _DivisionCode = Nothing

                End If

                SetDisplayControlValue(_DivisionDisplayControl)

                If _IsProcessing = False Then

                    ProcessDivisionChanged()

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Function GetDivisions(Optional ByVal IncludeDivisionCode As String = "") As IEnumerable

            'objects
            Dim Divisions As IEnumerable = Nothing
            Dim DivisionToInclude As Object = Nothing
            Dim KeyValueList As Generic.Dictionary(Of String, Object) = Nothing

            Try

                If _DivisionSource IsNot Nothing Then

                    If String.IsNullOrWhiteSpace(_ClientCode) = False Then

                        If TypeOf _DivisionSource Is IEnumerable(Of AdvantageFramework.Database.Entities.Division) Then

                            Divisions = (From Entity In DirectCast(_DivisionSource, IEnumerable(Of AdvantageFramework.Database.Entities.Division))
                                         Where Entity.ClientCode = _ClientCode
                                         Select Entity).ToList

                            If Not String.IsNullOrWhiteSpace(IncludeDivisionCode) Then

                                If (From Division In DirectCast(Divisions, IEnumerable(Of AdvantageFramework.Database.Entities.Division))
                                    Where Division.Code = IncludeDivisionCode
                                    Select Division).Any = False Then

                                    If _Session IsNot Nothing Then

                                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                            DivisionToInclude = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, _ClientCode, IncludeDivisionCode)

                                            If DivisionToInclude IsNot Nothing Then

                                                Divisions = (From Item In AddItemToSource(DirectCast(Divisions, IEnumerable(Of AdvantageFramework.Database.Entities.Division)), DivisionToInclude)
                                                             Select DirectCast(Item, AdvantageFramework.Database.Entities.Division)).ToList

                                            End If

                                        End Using

                                    End If

                                End If

                            End If

                        ElseIf TypeOf _DivisionSource Is IEnumerable(Of AdvantageFramework.Database.Core.Division) Then

                            Divisions = (From Entity In DirectCast(_DivisionSource, IEnumerable(Of AdvantageFramework.Database.Core.Division))
                                         Where Entity.ClientCode = _ClientCode
                                         Select Entity).ToList

                            If (From Division In DirectCast(Divisions, IEnumerable(Of AdvantageFramework.Database.Core.Division))
                                Where Division.Code = IncludeDivisionCode
                                Select Division).Any = False Then

                                If _Session IsNot Nothing Then

                                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                        DivisionToInclude = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, _ClientCode, IncludeDivisionCode)

                                        If DivisionToInclude IsNot Nothing Then

                                            Divisions = (From Item In AddItemToSource(DirectCast(Divisions, IEnumerable(Of AdvantageFramework.Database.Core.Division)), (New AdvantageFramework.Database.Core.Division(DivisionToInclude)))
                                                         Select DirectCast(Item, AdvantageFramework.Database.Core.Division)).ToList

                                        End If

                                    End Using

                                End If

                            End If

                        ElseIf TypeOf _DivisionSource Is IEnumerable(Of AdvantageFramework.Database.Views.DivisionView) Then

                            Divisions = (From Entity In DirectCast(_DivisionSource, IEnumerable(Of AdvantageFramework.Database.Views.DivisionView))
                                         Where Entity.ClientCode = _ClientCode
                                         Select Entity).ToList

                            If (From Division In DirectCast(Divisions, IEnumerable(Of AdvantageFramework.Database.Views.DivisionView))
                                Where Division.DivisionCode = IncludeDivisionCode
                                Select Division).Any = False Then

                                If _Session IsNot Nothing Then

                                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                        DivisionToInclude = (From Item In AdvantageFramework.Database.Procedures.DivisionView.Load(DbContext)
                                                             Where Item.ClientCode = _ClientCode AndAlso
                                                                     Item.DivisionCode = IncludeDivisionCode
                                                             Select Item).SingleOrDefault

                                        If DivisionToInclude IsNot Nothing Then

                                            Divisions = (From Item In AddItemToSource(DirectCast(Divisions, IEnumerable(Of AdvantageFramework.Database.Views.DivisionView)), DivisionToInclude)
                                                         Select DirectCast(Item, AdvantageFramework.Database.Views.DivisionView)).ToList

                                        End If

                                    End Using

                                End If

                            End If

                        Else

                            KeyValueList = New Generic.Dictionary(Of String, Object)

                            KeyValueList.Add("ClientCode", _ClientCode)

                            Divisions = GetList(_DivisionSource, Nothing)

                        End If

                    Else

                        Divisions = Nothing

                    End If

                End If

            Catch ex As Exception
                Divisions = Nothing
            Finally
                GetDivisions = Divisions
            End Try

        End Function
        Private Sub ProcessDivisionChanged()

            _IsProcessing = True

            Try

                Me.ProductCode = Nothing
                Me.JobNumber = Nothing
                Me.JobComponentNumber = Nothing

                ReloadDisplayControlDataSource(_ProductDisplayControl)
                ReloadDisplayControlDataSource(_JobDisplayControl, Not String.IsNullOrWhiteSpace(Me.ProductCode))
                ReloadDisplayControlDataSource(_JobComponentDisplayControl)

                SelectSingleProduct()
                SelectSingleJob()
                SelectSingleJobComponent()

                RaiseEvent DivisionChangedEvent()

            Catch ex As Exception

            End Try

            _IsProcessing = False

        End Sub
        Private Sub SelectSingleDivision()

            'objects
            Dim Divisions As IEnumerable = Nothing
            Dim Division As Object = Nothing

            If String.IsNullOrWhiteSpace(Me.ClientCode) = False Then

                Divisions = GetDivisions()

                If Divisions IsNot Nothing Then

                    If (From Entity In Divisions _
                        Select Entity).Count = 1 Then

                        Division = (From Entity In Divisions _
                                    Select Entity).SingleOrDefault

                        If TypeOf Division Is AdvantageFramework.Database.Entities.Division Then

                            Me.DivisionCode = DirectCast(Division, AdvantageFramework.Database.Entities.Division).Code

                        ElseIf TypeOf Division Is AdvantageFramework.Database.Core.Division Then

                            Me.DivisionCode = DirectCast(Division, AdvantageFramework.Database.Core.Division).Code

                        ElseIf TypeOf Division Is AdvantageFramework.Database.Views.DivisionView Then

                            Me.DivisionCode = DirectCast(Division, AdvantageFramework.Database.Views.DivisionView).DivisionCode

                        End If

                        RaiseEvent DivisionChangedEvent()

                        _DivisionDisplayControl.Focus()

                        ReloadDisplayControlDataSource(_ProductDisplayControl)
                        ReloadDisplayControlDataSource(_JobDisplayControl, Not String.IsNullOrWhiteSpace(Me.ProductCode))
                        ReloadDisplayControlDataSource(_JobComponentDisplayControl)

                    End If

                End If

            End If

        End Sub

#End Region

#Region "  Product Methods "

        Private Sub SetProduct(ByVal ProductCode As String)

            'objects
            Dim Cancel As Boolean = False

            If ProductCode <> _ProductCode Then

                RaiseEvent ProductChangingEvent(Cancel)

                If Cancel = False Then

                    _ProductCode = ProductCode

                End If

                If String.IsNullOrWhiteSpace(_ProductCode) Then

                    _ProductCode = Nothing

                End If

                SetDisplayControlValue(_ProductDisplayControl)

                If _IsProcessing = False Then

                    ProcessProductChanged()

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Function GetProducts(Optional ByVal IncludeProductCode As String = "") As IEnumerable

            'objects
            Dim Products As IEnumerable = Nothing
            Dim ProductToInclude As Object = Nothing
            Dim KeyValueList As Generic.Dictionary(Of String, Object) = Nothing

            Try

                If _ProductSource IsNot Nothing Then

                    If String.IsNullOrWhiteSpace(_ClientCode) = False AndAlso String.IsNullOrWhiteSpace(_DivisionCode) = False Then

                        If TypeOf _ProductSource Is IEnumerable(Of AdvantageFramework.Database.Entities.Product) Then

                            Products = (From Entity In DirectCast(_ProductSource, IEnumerable(Of AdvantageFramework.Database.Entities.Product))
                                        Where Entity.ClientCode = _ClientCode AndAlso
                                               Entity.DivisionCode = _DivisionCode
                                        Select Entity).ToList

                            If Not String.IsNullOrWhiteSpace(IncludeProductCode) Then

                                If (From Product In DirectCast(Products, IEnumerable(Of AdvantageFramework.Database.Entities.Product))
                                    Where Product.Code = IncludeProductCode
                                    Select Product).Any = False Then

                                    If _Session IsNot Nothing Then

                                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                            ProductToInclude = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, IncludeProductCode)

                                            If ProductToInclude IsNot Nothing Then

                                                Products = (From Item In AddItemToSource(DirectCast(Products, IEnumerable(Of AdvantageFramework.Database.Entities.Product)), ProductToInclude)
                                                            Select DirectCast(Item, AdvantageFramework.Database.Entities.Product)).ToList

                                            End If

                                        End Using

                                    End If

                                End If

                            End If

                        ElseIf TypeOf _ProductSource Is IEnumerable(Of AdvantageFramework.Database.Core.Product) Then

                            Products = (From Entity In DirectCast(_ProductSource, IEnumerable(Of AdvantageFramework.Database.Core.Product))
                                        Where Entity.ClientCode = _ClientCode AndAlso
                                               Entity.DivisionCode = _DivisionCode
                                        Select Entity).ToList

                            If Not String.IsNullOrWhiteSpace(IncludeProductCode) Then

                                If (From Product In DirectCast(Products, IEnumerable(Of AdvantageFramework.Database.Core.Product))
                                    Where Product.Code = IncludeProductCode
                                    Select Product).Any = False Then

                                    If _Session IsNot Nothing Then

                                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                            ProductToInclude = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, IncludeProductCode)

                                            If ProductToInclude IsNot Nothing Then

                                                Products = (From Item In AddItemToSource(DirectCast(Products, IEnumerable(Of AdvantageFramework.Database.Core.Product)), (New AdvantageFramework.Database.Core.Product(ProductToInclude)))
                                                            Select DirectCast(Item, AdvantageFramework.Database.Core.Product)).ToList

                                            End If

                                        End Using

                                    End If

                                End If

                            End If

                        ElseIf TypeOf _ProductSource Is IEnumerable(Of AdvantageFramework.Database.Views.ProductView) Then

                            Products = (From Entity In DirectCast(_ProductSource, IEnumerable(Of AdvantageFramework.Database.Views.ProductView))
                                        Where Entity.ClientCode = _ClientCode AndAlso
                                               Entity.DivisionCode = _DivisionCode
                                        Select Entity).ToList

                            If (From Product In DirectCast(Products, IEnumerable(Of AdvantageFramework.Database.Views.ProductView))
                                Where Product.ProductCode = IncludeProductCode
                                Select Product).Any = False Then

                                If _Session IsNot Nothing Then

                                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                        ProductToInclude = (From Item In AdvantageFramework.Database.Procedures.ProductView.Load(DbContext)
                                                            Where Item.ClientCode = _ClientCode AndAlso
                                                                    Item.DivisionCode = _DivisionCode AndAlso
                                                                    Item.ProductCode = IncludeProductCode
                                                            Select Item).SingleOrDefault

                                        If ProductToInclude IsNot Nothing Then

                                            Products = (From Item In AddItemToSource(DirectCast(Products, IEnumerable(Of AdvantageFramework.Database.Views.ProductView)), ProductToInclude)
                                                        Select DirectCast(Item, AdvantageFramework.Database.Views.ProductView)).ToList

                                        End If

                                    End Using

                                End If

                            End If

                        Else

                            KeyValueList = New Generic.Dictionary(Of String, Object)

                            KeyValueList.Add("ClientCode", _ClientCode)
                            KeyValueList.Add("DivisionCode", _DivisionCode)

                            Products = GetList(_ProductSource, KeyValueList)

                        End If

                    Else

                        Products = Nothing

                    End If

                End If

            Catch ex As Exception
                Products = Nothing
            Finally
                GetProducts = Products
            End Try

        End Function
        Private Sub ProcessProductChanged()

            _IsProcessing = True

            Try

                Me.JobNumber = Nothing
                Me.JobComponentNumber = Nothing

                ReloadDisplayControlDataSource(_JobDisplayControl, Not String.IsNullOrWhiteSpace(Me.ProductCode))
                ReloadDisplayControlDataSource(_JobComponentDisplayControl)

                SelectSingleJob()
                SelectSingleJobComponent()

                RaiseEvent ProductChangedEvent()

            Catch ex As Exception

            End Try

            _IsProcessing = False

        End Sub
        Private Sub SelectSingleProduct()

            'objects
            Dim Products As IEnumerable = Nothing
            Dim Product As Object = Nothing

            If String.IsNullOrWhiteSpace(Me.ClientCode) = False AndAlso String.IsNullOrWhiteSpace(Me.DivisionCode) = False Then

                Products = GetProducts()

                If Products IsNot Nothing Then

                    If (From Entity In Products
                        Select Entity).Count = 1 Then

                        Product = (From Entity In Products
                                   Select Entity).SingleOrDefault

                        If TypeOf Product Is AdvantageFramework.Database.Entities.Product Then

                            Me.ProductCode = DirectCast(Product, AdvantageFramework.Database.Entities.Product).Code

                        ElseIf TypeOf Product Is AdvantageFramework.Database.Core.Product Then

                            Me.ProductCode = DirectCast(Product, AdvantageFramework.Database.Core.Product).Code

                        ElseIf TypeOf Product Is AdvantageFramework.Database.Views.ProductView Then

                            Me.ProductCode = DirectCast(Product, AdvantageFramework.Database.Views.ProductView).ProductCode

                        End If

                        RaiseEvent ProductChangedEvent()

                        _ProductDisplayControl.Focus()

                        ReloadDisplayControlDataSource(_JobDisplayControl, Not String.IsNullOrWhiteSpace(Me.ProductCode))
                        ReloadDisplayControlDataSource(_JobComponentDisplayControl)

                    End If

                End If

            End If

        End Sub
        Private Function AddItemToSource(Of T)(ByVal Source As IEnumerable(Of T), ByVal Item As T) As List(Of T)

            Dim SourceList As List(Of T)

            SourceList = Source.ToList
            SourceList.Add(Item)

            Return SourceList

        End Function

#End Region

#Region "  Job Methods "

        Private Sub SetJob(ByVal JobNumber As Integer)

            'objects
            Dim Cancel As Boolean = False

            If JobNumber <> _JobNumber.GetValueOrDefault(0) Then

                RaiseEvent JobChangingEvent(Cancel)

                If Cancel = False Then

                    If JobNumber > 0 Then

                        _JobNumber = JobNumber

                    Else

                        _JobNumber = Nothing

                    End If

                End If

                SetDisplayControlValue(_JobDisplayControl)

                If _IsProcessing = False Then

                    ProcessJobChanged()

                    SelectSingleItemDataSource(_JobDisplayControl)

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Function GetJobs() As IEnumerable

            'objects
            Dim Jobs As IEnumerable = Nothing
            Dim KeyValueList As Generic.Dictionary(Of String, Object) = Nothing

            Try

                If _JobSource IsNot Nothing Then

                    If TypeOf _JobSource Is IEnumerable(Of AdvantageFramework.Database.Entities.Job) Then

                        Jobs = (From Entity In DirectCast(_JobSource, IEnumerable(Of AdvantageFramework.Database.Entities.Job)) _
                                Where Entity.ClientCode = If(String.IsNullOrWhiteSpace(_ClientCode), Entity.ClientCode, _ClientCode) AndAlso _
                                      Entity.DivisionCode = If(String.IsNullOrWhiteSpace(_DivisionCode), Entity.DivisionCode, _DivisionCode) AndAlso _
                                      Entity.ProductCode = If(String.IsNullOrWhiteSpace(_ProductCode), Entity.ProductCode, _ProductCode) _
                                Select Entity).ToList
                        
                    ElseIf TypeOf _JobSource Is IEnumerable(Of AdvantageFramework.Database.Core.Job) Then

                        Jobs = (From Entity In DirectCast(_JobSource, IEnumerable(Of AdvantageFramework.Database.Core.Job)) _
                                Where Entity.ClientCode = If(String.IsNullOrWhiteSpace(_ClientCode), Entity.ClientCode, _ClientCode) AndAlso _
                                      Entity.DivisionCode = If(String.IsNullOrWhiteSpace(_DivisionCode), Entity.DivisionCode, _DivisionCode) AndAlso _
                                      Entity.ProductCode = If(String.IsNullOrWhiteSpace(_ProductCode), Entity.ProductCode, _ProductCode) _
                                Select Entity).ToList

                    ElseIf TypeOf _JobSource Is IEnumerable(Of AdvantageFramework.Database.Views.JobView) Then

                        Jobs = (From Entity In DirectCast(_JobSource, IEnumerable(Of AdvantageFramework.Database.Views.JobView)) _
                                Where Entity.ClientCode = If(String.IsNullOrWhiteSpace(_ClientCode), Entity.ClientCode, _ClientCode) AndAlso _
                                      Entity.DivisionCode = If(String.IsNullOrWhiteSpace(_DivisionCode), Entity.DivisionCode, _DivisionCode) AndAlso _
                                      Entity.ProductCode = If(String.IsNullOrWhiteSpace(_ProductCode), Entity.ProductCode, _ProductCode) _
                                Select Entity).ToList

                    Else

                        KeyValueList = New Generic.Dictionary(Of String, Object)

                        If String.IsNullOrWhiteSpace(_ClientCode) = False Then

                            KeyValueList.Add("ClientCode", _ClientCode)

                            If String.IsNullOrWhiteSpace(_DivisionCode) = False Then

                                KeyValueList.Add("DivisionCode", _DivisionCode)

                                If String.IsNullOrWhiteSpace(_ProductCode) = False Then

                                    KeyValueList.Add("ProductCode", _ProductCode)

                                End If

                            End If

                        End If

                        Jobs = GetList(_JobSource, KeyValueList)

                    End If

                End If

            Catch ex As Exception
                Jobs = Nothing
            Finally
                GetJobs = Jobs
            End Try

        End Function
        Private Sub ProcessJobChanged()

            'objects
            Dim TryToSelectJob As Boolean = False

            _IsProcessing = True

            Try

                Me.JobComponentNumber = Nothing

                If String.IsNullOrWhiteSpace(Me.ClientCode) OrElse String.IsNullOrWhiteSpace(Me.DivisionCode) OrElse String.IsNullOrWhiteSpace(Me.ProductCode) Then

                    BackFillJobData()

                End If

                If Me.JobNumber.GetValueOrDefault(0) > 0 Then

                    TryToSelectJob = True

                End If

                ReloadDisplayControlDataSource(_JobDisplayControl, TryToSelectJob)
                ReloadDisplayControlDataSource(_JobComponentDisplayControl)

                SelectSingleJobComponent()

                RaiseEvent JobChangedEvent()

            Catch ex As Exception

            End Try

            _IsProcessing = False

        End Sub
        Private Sub BackFillJobData()

            'objects
            Dim Job As Object = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing

            If _JobSource IsNot Nothing Then
                
                If TypeOf _JobSource Is IEnumerable(Of AdvantageFramework.Database.Entities.Job) Then

                    Job = (From Entity In DirectCast(_JobSource, IEnumerable(Of AdvantageFramework.Database.Entities.Job)) _
                           Where Entity.Number = Me.JobNumber.GetValueOrDefault(0) _
                           Select Entity).SingleOrDefault

                    If Job IsNot Nothing Then
                        
                        ClientCode = CType(Job, AdvantageFramework.Database.Entities.Job).ClientCode
                        DivisionCode = CType(Job, AdvantageFramework.Database.Entities.Job).DivisionCode
                        ProductCode = CType(Job, AdvantageFramework.Database.Entities.Job).ProductCode

                    End If

                ElseIf TypeOf _JobSource Is IEnumerable(Of AdvantageFramework.Database.Core.Job) Then

                    Job = (From Entity In DirectCast(_JobSource, IEnumerable(Of AdvantageFramework.Database.Core.Job)) _
                           Where Entity.Number = Me.JobNumber.GetValueOrDefault(0) _
                           Select Entity).SingleOrDefault

                    If Job IsNot Nothing Then

                        ClientCode = CType(Job, AdvantageFramework.Database.Core.Job).ClientCode
                        DivisionCode = CType(Job, AdvantageFramework.Database.Core.Job).DivisionCode
                        ProductCode = CType(Job, AdvantageFramework.Database.Core.Job).ProductCode

                    End If

                ElseIf TypeOf _JobSource Is IEnumerable(Of AdvantageFramework.Database.Views.JobView) Then

                    Job = (From Entity In DirectCast(_JobSource, IEnumerable(Of AdvantageFramework.Database.Views.JobView)) _
                           Where Entity.JobNumber = Me.JobNumber.GetValueOrDefault(0) _
                           Select Entity).SingleOrDefault

                    If Job IsNot Nothing Then

                        ClientCode = CType(Job, AdvantageFramework.Database.Views.JobView).ClientCode
                        DivisionCode = CType(Job, AdvantageFramework.Database.Views.JobView).DivisionCode
                        ProductCode = CType(Job, AdvantageFramework.Database.Views.JobView).ProductCode

                    End If

                End If

                If Job IsNot Nothing Then

                    Me.ClientCode = ClientCode

                    ReloadDisplayControlDataSource(_DivisionDisplayControl, IncludeCode:=DivisionCode)

                    Me.DivisionCode = DivisionCode

                    ReloadDisplayControlDataSource(_ProductDisplayControl, IncludeCode:=ProductCode)

                    Me.ProductCode = ProductCode

                End If

            End If

        End Sub
        Private Sub SelectSingleJob()

            'objects
            Dim Jobs As IEnumerable = Nothing
            Dim Job As Object = Nothing

            If String.IsNullOrWhiteSpace(Me.ClientCode) = False AndAlso String.IsNullOrWhiteSpace(Me.DivisionCode) = False AndAlso String.IsNullOrWhiteSpace(Me.ProductCode) = False Then

                Jobs = GetJobs()

                If Jobs IsNot Nothing Then

                    If (From Entity In Jobs _
                        Select Entity).Count = 1 Then

                        Job = (From Entity In Jobs _
                               Select Entity).SingleOrDefault

                        If TypeOf Job Is AdvantageFramework.Database.Entities.Job Then

                            Me.JobNumber = DirectCast(Job, AdvantageFramework.Database.Entities.Job).Number

                        ElseIf TypeOf Job Is AdvantageFramework.Database.Core.Job Then

                            Me.JobNumber = DirectCast(Job, AdvantageFramework.Database.Core.Job).Number

                        ElseIf TypeOf Job Is AdvantageFramework.Database.Views.JobView Then

                            Me.JobNumber = DirectCast(Job, AdvantageFramework.Database.Views.JobView).JobNumber

                        End If

                        RaiseEvent JobChangedEvent()

                        _JobDisplayControl.Focus()

                        ReloadDisplayControlDataSource(_JobComponentDisplayControl)

                    End If

                End If

            End If

        End Sub

#End Region

#Region "  Job Component Methods "

        Private Sub BackFillJobComponentData()

            'objects
            Dim JobComponent As Object = Nothing

            If _JobComponentSource IsNot Nothing Then

                If TypeOf _JobComponentSource Is IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent) Then

                    JobComponent = (From Entity In DirectCast(_JobComponentSource, IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent)) _
                                    Where Entity.Number = Me.JobComponentNumber.GetValueOrDefault(0) AndAlso _
                                          Entity.JobNumber = Me.JobNumber.GetValueOrDefault(0) _
                                    Select Entity).SingleOrDefault

                    If JobComponent IsNot Nothing Then

                        _JobComponentID = DirectCast(JobComponent, AdvantageFramework.Database.Entities.JobComponent).ID

                    End If

                ElseIf TypeOf _JobComponentSource Is IEnumerable(Of AdvantageFramework.Database.Core.JobComponent) Then

                    JobComponent = (From Entity In DirectCast(_JobComponentSource, IEnumerable(Of AdvantageFramework.Database.Core.JobComponent)) _
                                    Where Entity.Number = Me.JobComponentNumber.GetValueOrDefault(0) AndAlso _
                                          Entity.JobNumber = Me.JobNumber.GetValueOrDefault(0) _
                                    Select Entity).SingleOrDefault

                    If JobComponent IsNot Nothing Then

                        _JobComponentID = DirectCast(JobComponent, AdvantageFramework.Database.Core.JobComponent).ID

                    End If

                ElseIf TypeOf _JobComponentSource Is IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView) Then

                    JobComponent = (From Entity In DirectCast(_JobComponentSource, IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView)) _
                                    Where Entity.JobComponentNumber = Me.JobComponentNumber.GetValueOrDefault(0) AndAlso _
                                          Entity.JobNumber = Me.JobNumber.GetValueOrDefault(0) _
                                    Select Entity).SingleOrDefault

                    If JobComponent IsNot Nothing Then

                        _JobComponentID = DirectCast(JobComponent, AdvantageFramework.Database.Views.JobComponentView).ID

                    End If

                End If

            End If

        End Sub
        Private Sub SetJobComponent(ByVal JobComponentNumber As Integer)

            'objects
            Dim Cancel As Boolean = False

            If JobComponentNumber <> _JobComponentNumber.GetValueOrDefault(0) Then

                RaiseEvent ComponentChangingEvent(Cancel)

                If Cancel = False Then

                    If JobComponentNumber > 0 Then

                        _JobComponentNumber = JobComponentNumber

                    Else

                        _JobComponentNumber = Nothing

                    End If

                End If

                SetDisplayControlValue(_JobComponentDisplayControl)

                If _IsProcessing = False Then

                    ProcessJobComponentChanged()

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Function GetJobComponents() As IEnumerable

            'objects
            Dim JobComponents As IEnumerable = Nothing
            Dim KeyValueList As Generic.Dictionary(Of String, Object) = Nothing

            Try

                If _JobComponentSource IsNot Nothing Then

                    If TypeOf _JobComponentSource Is IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent) Then

                        JobComponents = (From Entity In DirectCast(_JobComponentSource, IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent)) _
                                         Where Entity.JobNumber = If(_JobNumber.HasValue = False, Entity.JobNumber, _JobNumber) _
                                         Select Entity).ToList

                    ElseIf TypeOf _JobComponentSource Is IEnumerable(Of AdvantageFramework.Database.Core.JobComponent) Then

                        JobComponents = (From Entity In DirectCast(_JobComponentSource, IEnumerable(Of AdvantageFramework.Database.Core.JobComponent)) _
                                         Where Entity.JobNumber = If(_JobNumber.HasValue = False, Entity.JobNumber, _JobNumber) _
                                         Select Entity).ToList

                    ElseIf TypeOf _JobComponentSource Is IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView) Then

                        JobComponents = (From Entity In DirectCast(_JobComponentSource, IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView)) _
                                         Where Entity.ClientCode = If(String.IsNullOrWhiteSpace(_ClientCode), Entity.ClientCode, _ClientCode) AndAlso _
                                               Entity.DivisionCode = If(String.IsNullOrWhiteSpace(_DivisionCode), Entity.DivisionCode, _DivisionCode) AndAlso _
                                               Entity.ProductCode = If(String.IsNullOrWhiteSpace(_ProductCode), Entity.ProductCode, _ProductCode) AndAlso _
                                               Entity.JobNumber = If(_JobNumber.HasValue = False, Entity.JobNumber, _JobNumber) _
                                         Select Entity).ToList

                    Else

                        KeyValueList = New Generic.Dictionary(Of String, Object)

                        If String.IsNullOrWhiteSpace(_ClientCode) = False Then

                            KeyValueList.Add("ClientCode", _ClientCode)

                            If String.IsNullOrWhiteSpace(_DivisionCode) = False Then

                                KeyValueList.Add("DivisionCode", _DivisionCode)

                                If String.IsNullOrWhiteSpace(_ProductCode) = False Then

                                    KeyValueList.Add("ProductCode", _ProductCode)

                                End If

                            End If

                        End If

                        If _JobNumber.HasValue Then

                            KeyValueList.Add("JobNumber", _JobNumber.Value)

                        End If

                        JobComponents = GetList(_JobSource, KeyValueList)

                    End If

                End If

            Catch ex As Exception
                JobComponents = Nothing
            Finally
                GetJobComponents = JobComponents
            End Try

        End Function
        Private Sub ProcessJobComponentChanged()

            _IsProcessing = True

            Try

                _JobComponentID = Nothing

                BackFillJobComponentData()

                RaiseEvent ComponentChangedEvent()

            Catch ex As Exception

            End Try

            _IsProcessing = False

        End Sub
        Private Sub SelectSingleJobComponent()

            'objects
            Dim JobComponents As IEnumerable = Nothing
            Dim JobComponent As Object = Nothing

            If Me.JobNumber.GetValueOrDefault(0) > 0 Then

                JobComponents = GetJobComponents()

                If JobComponents IsNot Nothing Then

                    If (From Entity In JobComponents _
                        Select Entity).Count = 1 Then

                        JobComponent = (From Entity In JobComponents _
                                        Select Entity).SingleOrDefault

                        If TypeOf JobComponent Is AdvantageFramework.Database.Entities.JobComponent Then
                            
                            Me.JobComponentNumber = DirectCast(JobComponent, AdvantageFramework.Database.Entities.JobComponent).Number
                            _JobComponentID = DirectCast(JobComponent, AdvantageFramework.Database.Entities.JobComponent).ID

                        ElseIf TypeOf JobComponent Is AdvantageFramework.Database.Core.JobComponent Then

                            Me.JobComponentNumber = DirectCast(JobComponent, AdvantageFramework.Database.Core.JobComponent).Number
                            _JobComponentID = DirectCast(JobComponent, AdvantageFramework.Database.Core.JobComponent).ID

                        ElseIf TypeOf JobComponent Is AdvantageFramework.Database.Views.JobComponentView Then

                            Me.JobComponentNumber = DirectCast(JobComponent, AdvantageFramework.Database.Views.JobComponentView).JobComponentNumber
                            _JobComponentID = DirectCast(JobComponent, AdvantageFramework.Database.Views.JobComponentView).ID

                        ElseIf TypeOf JobComponent Is AdvantageFramework.IncomeOnly.Classes.JobComponent Then

                            Me.JobComponentNumber = DirectCast(JobComponent, AdvantageFramework.IncomeOnly.Classes.JobComponent).JobComponentNumber
                            _JobComponentID = DirectCast(JobComponent, AdvantageFramework.IncomeOnly.Classes.JobComponent).ID

                        End If

                        RaiseEvent ComponentChangedEvent()

                        _JobComponentDisplayControl.Focus()

                    End If

                End If

            End If

        End Sub

#End Region

        Public Sub InitializeDataControls()

            FillDisplayControlDataSource(_ClientDisplayControl, Me.ClientSource)
            FillDisplayControlDataSource(_DivisionDisplayControl, Me.DivisionSource)
            FillDisplayControlDataSource(_ProductDisplayControl, Me.ProductSource)
            FillDisplayControlDataSource(_JobDisplayControl, Me.JobSource)
            FillDisplayControlDataSource(_JobComponentDisplayControl, Me.JobComponentSource)

            EnableOrDisableActions()

        End Sub
        Private Sub FillDisplayControlDataSource(ByVal Control As System.Windows.Forms.Control, ByVal DataSourceList As IEnumerable)

            If Control IsNot Nothing Then

                If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox Then

                    DirectCast(Control, AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox).DataSource = DataSourceList

                End If

            End If

        End Sub
        Private Function LoadDataView(ByVal Value As IEnumerable) As IEnumerable

            'objects
            Dim View As IEnumerable = Nothing

            If Value IsNot Nothing AndAlso TypeOf Value Is IEnumerable Then

                If TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Client) Then

                    View = LoadDataView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Client)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Client) Then

                    View = LoadDataView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Client)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Division) Then

                    View = LoadDataView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Division)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Division) Then

                    View = LoadDataView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Division)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.DivisionView) Then

                    View = LoadDataView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.DivisionView)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Product) Then

                    View = LoadDataView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Product)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Product) Then

                    View = LoadDataView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Product)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.ProductView) Then

                    View = LoadDataView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.ProductView)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Job) Then

                    View = LoadDataView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Job)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Job) Then

                    View = LoadDataView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Job)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.JobView) Then

                    View = LoadDataView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.JobView)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent) Then

                    View = LoadDataView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.JobComponent) Then

                    View = LoadDataView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.JobComponent)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView) Then

                    View = LoadDataView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.IncomeOnly.Classes.JobComponent) Then

                    View = LoadDataView(DirectCast(Value, IEnumerable(Of AdvantageFramework.IncomeOnly.Classes.JobComponent)))

                Else

                    View = Value

                End If

            End If

            LoadDataView = View

        End Function
        Private Function LoadDataView(ByVal Clients As IEnumerable(Of AdvantageFramework.Database.Entities.Client)) As IEnumerable

            LoadDataView = (From Entity In Clients _
                            Select Entity.Code, _
                                   Entity.Name, _
                                   Entity.IsActive).ToList.Select(Function(Entity) New AdvantageFramework.Database.Entities.Client With {.Code = Entity.Code, _
                                                                                                                                         .Name = Entity.Name, _
                                                                                                                                         .IsActive = Entity.IsActive}).ToList

        End Function
        Private Function LoadDataView(ByVal Clients As IEnumerable(Of AdvantageFramework.Database.Core.Client)) As IEnumerable

            LoadDataView = (From Entity In Clients _
                            Select Entity.Code, _
                                   Entity.Name, _
                                   Entity.IsActive).ToList.Select(Function(Entity) New AdvantageFramework.Database.Core.Client With {.Code = Entity.Code, _
                                                                                                                                     .Name = Entity.Name, _
                                                                                                                                     .IsActive = Entity.IsActive}).ToList

        End Function
        Private Function LoadDataView(ByVal Divisions As IEnumerable(Of AdvantageFramework.Database.Entities.Division)) As IEnumerable

            LoadDataView = (From Entity In Divisions _
                            Select Entity.ClientCode, _
                                   Entity.Code, _
                                   Entity.Name, _
                                   Entity.IsActive).ToList.Select(Function(Entity) New AdvantageFramework.Database.Entities.Division With {.ClientCode = Entity.ClientCode, _
                                                                                                                                           .Code = Entity.Code, _
                                                                                                                                           .Name = Entity.Name, _
                                                                                                                                           .IsActive = Entity.IsActive}).ToList

        End Function
        Private Function LoadDataView(ByVal Divisions As IEnumerable(Of AdvantageFramework.Database.Core.Division)) As IEnumerable

            LoadDataView = (From Entity In Divisions _
                            Select Entity.ClientCode, _
                                   Entity.Code, _
                                   Entity.Name, _
                                   Entity.IsActive).ToList.Select(Function(Entity) New AdvantageFramework.Database.Core.Division With {.ClientCode = Entity.ClientCode, _
                                                                                                                                       .Code = Entity.Code, _
                                                                                                                                       .Name = Entity.Name, _
                                                                                                                                       .IsActive = Entity.IsActive}).ToList

        End Function
        Private Function LoadDataView(ByVal Divisions As IEnumerable(Of AdvantageFramework.Database.Views.DivisionView)) As IEnumerable

            LoadDataView = (From Entity In Divisions _
                            Select Entity.ClientCode, _
                                   Entity.DivisionCode, _
                                   Entity.DivisionName, _
                                   Entity.IsActive).ToList.Select(Function(Entity) New AdvantageFramework.Database.Views.DivisionView With {.ClientCode = Entity.ClientCode, _
                                                                                                                                            .DivisionCode = Entity.DivisionCode, _
                                                                                                                                            .DivisionName = Entity.DivisionName, _
                                                                                                                                            .IsActive = Entity.IsActive}).ToList

        End Function
        Private Function LoadDataView(ByVal Products As IEnumerable(Of AdvantageFramework.Database.Entities.Product)) As IEnumerable

            LoadDataView = (From Entity In Products _
                            Select Entity.ClientCode, _
                                   Entity.DivisionCode, _
                                   Entity.Code, _
                                   Entity.Name, _
                                   Entity.IsActive).ToList.Select(Function(Entity) New AdvantageFramework.Database.Entities.Product With {.ClientCode = Entity.ClientCode, _
                                                                                                                                          .DivisionCode = Entity.DivisionCode, _
                                                                                                                                          .Code = Entity.Code, _
                                                                                                                                          .Name = Entity.Name, _
                                                                                                                                          .IsActive = Entity.IsActive}).ToList

        End Function
        Private Function LoadDataView(ByVal Products As IEnumerable(Of AdvantageFramework.Database.Core.Product)) As IEnumerable

            LoadDataView = (From Entity In Products _
                            Select Entity.ClientCode, _
                                   Entity.DivisionCode, _
                                   Entity.Code, _
                                   Entity.Name, _
                                   Entity.IsActive).ToList.Select(Function(Entity) New AdvantageFramework.Database.Core.Product With {.ClientCode = Entity.ClientCode, _
                                                                                                                                      .DivisionCode = Entity.DivisionCode, _
                                                                                                                                      .Code = Entity.Code, _
                                                                                                                                      .Name = Entity.Name, _
                                                                                                                                      .IsActive = Entity.IsActive}).ToList

        End Function
        Private Function LoadDataView(ByVal Products As IEnumerable(Of AdvantageFramework.Database.Views.ProductView)) As IEnumerable

            LoadDataView = (From Entity In Products _
                            Select Entity.ClientCode, _
                                   Entity.DivisionCode, _
                                   Entity.ProductCode, _
                                   Entity.ProductDescription, _
                                   Entity.IsActive).ToList.Select(Function(Entity) New AdvantageFramework.Database.Views.ProductView With {.ClientCode = Entity.ClientCode, _
                                                                                                                                           .DivisionCode = Entity.DivisionCode, _
                                                                                                                                           .ProductCode = Entity.ProductCode, _
                                                                                                                                           .ProductDescription = Entity.ProductDescription, _
                                                                                                                                           .IsActive = Entity.IsActive}).ToList

        End Function
        Private Function LoadDataView(ByVal Jobs As IEnumerable(Of AdvantageFramework.Database.Entities.Job)) As IEnumerable

            LoadDataView = (From Entity In Jobs _
                            Select Entity.ClientCode, _
                                   Entity.DivisionCode, _
                                   Entity.ProductCode, _
                                   Entity.Number, _
                                   Entity.Description, _
                                   Entity.IsOpen).ToList.Select(Function(Entity) New AdvantageFramework.Database.Entities.Job With {.ClientCode = Entity.ClientCode, _
                                                                                                                                    .DivisionCode = Entity.DivisionCode, _
                                                                                                                                    .ProductCode = Entity.ProductCode, _
                                                                                                                                    .Number = Entity.Number, _
                                                                                                                                    .Description = Entity.Description, _
                                                                                                                                    .IsOpen = Entity.IsOpen}).ToList

        End Function
        Private Function LoadDataView(ByVal Jobs As IEnumerable(Of AdvantageFramework.Database.Core.Job)) As IEnumerable

            LoadDataView = (From Entity In Jobs _
                            Select Entity.ClientCode, _
                                   Entity.DivisionCode, _
                                   Entity.ProductCode, _
                                   Entity.Number, _
                                   Entity.Description, _
                                   Entity.IsOpen).ToList.Select(Function(Entity) New AdvantageFramework.Database.Core.Job With {.ClientCode = Entity.ClientCode, _
                                                                                                                                .DivisionCode = Entity.DivisionCode, _
                                                                                                                                .ProductCode = Entity.ProductCode, _
                                                                                                                                .Number = Entity.Number, _
                                                                                                                                .Description = Entity.Description, _
                                                                                                                                .IsOpen = Entity.IsOpen}).ToList

        End Function
        Private Function LoadDataView(ByVal Jobs As IEnumerable(Of AdvantageFramework.Database.Views.JobView)) As IEnumerable

            LoadDataView = (From Entity In Jobs _
                            Select Entity.ClientCode, _
                                   Entity.DivisionCode, _
                                   Entity.ProductCode, _
                                   Entity.JobNumber, _
                                   Entity.JobDescription, _
                                   Entity.IsOpen).ToList.Select(Function(Entity) New AdvantageFramework.Database.Views.JobView With {.ClientCode = Entity.ClientCode, _
                                                                                                                                     .DivisionCode = Entity.DivisionCode, _
                                                                                                                                     .ProductCode = Entity.ProductCode, _
                                                                                                                                     .JobNumber = Entity.JobNumber, _
                                                                                                                                     .JobDescription = Entity.JobDescription, _
                                                                                                                                     .IsOpen = Entity.IsOpen}).ToList

        End Function
        Private Function LoadDataView(ByVal JobComponents As IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent)) As IEnumerable

            LoadDataView = (From Entity In JobComponents _
                            Select Entity.JobNumber, _
                                   Entity.Description, _
                                   Entity.Number, _
                                   Entity.ID).ToList.Select(Function(Entity) New AdvantageFramework.Database.Entities.JobComponent With {.JobNumber = Entity.JobNumber, _
                                                                                                                                         .Description = Entity.Description,
                                                                                                                                         .Number = Entity.Number, _
                                                                                                                                         .ID = Entity.ID}).ToList

        End Function
        Private Function LoadDataView(ByVal JobComponents As IEnumerable(Of AdvantageFramework.Database.Core.JobComponent)) As IEnumerable

            LoadDataView = (From Entity In JobComponents _
                            Select Entity.JobNumber, _
                                   Entity.Description, _
                                   Entity.Number, _
                                   Entity.ID).ToList.Select(Function(Entity) New AdvantageFramework.Database.Core.JobComponent With {.JobNumber = Entity.JobNumber, _
                                                                                                                                     .Description = Entity.Description,
                                                                                                                                     .Number = Entity.Number, _
                                                                                                                                     .ID = Entity.ID}).ToList

        End Function
        Private Function LoadDataView(ByVal JobComponentViews As IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView)) As IEnumerable

            LoadDataView = (From Entity In JobComponentViews _
                            Select Entity.ClientCode, _
                                   Entity.DivisionCode, _
                                   Entity.ProductCode, _
                                   Entity.JobNumber, _
                                   Entity.JobDescription, _
                                   Entity.JobComponentNumber, _
                                   Entity.JobComponentDescription, _
                                   Entity.ID).ToList.Select(Function(Entity) New AdvantageFramework.Database.Views.JobComponentView With {.ClientCode = Entity.ClientCode, _
                                                                                                                                          .DivisionCode = Entity.DivisionCode, _
                                                                                                                                          .ProductCode = Entity.ProductCode, _
                                                                                                                                          .JobNumber = Entity.JobNumber, _
                                                                                                                                          .JobDescription = Entity.JobDescription,
                                                                                                                                          .JobComponentNumber = Entity.JobComponentNumber, _
                                                                                                                                          .JobComponentDescription = Entity.JobComponentDescription, _
                                                                                                                                          .ID = Entity.ID}).ToList

        End Function
        Private Function LoadDataView(ByVal JobComponents As IEnumerable(Of AdvantageFramework.IncomeOnly.Classes.JobComponent)) As IEnumerable

            LoadDataView = JobComponents.ToList

        End Function
        Private Function GetList(ByVal SourceList As IEnumerable, ByVal KeyValueList As Generic.Dictionary(Of String, Object)) As IEnumerable

            'objects
            Dim List As Generic.List(Of Object) = Nothing
            Dim PropertiesExist As Boolean = True
            Dim PropertyDescriptorCollection As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim AddObject As Boolean = False

            If SourceList IsNot Nothing AndAlso KeyValueList IsNot Nothing Then

                PropertyDescriptorCollection = New Generic.List(Of System.ComponentModel.PropertyDescriptor)

                For Each Key In KeyValueList.Keys.ToList

                    PropertyDescriptor = (From PropDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(SourceList.GetEnumerator.Current).OfType(Of System.ComponentModel.PropertyDescriptor)() _
                                          Where PropDescriptor.Name = Key _
                                          Select PropDescriptor).SingleOrDefault

                    If PropertyDescriptor IsNot Nothing Then

                        PropertyDescriptorCollection.Add(PropertyDescriptor)

                    Else

                        PropertiesExist = False
                        Exit For

                    End If

                Next

                If PropertiesExist = True Then

                    List = New Generic.List(Of Object)

                    For Each SourceObject In SourceList

                        AddObject = True

                        For Each PropDescriptor In PropertyDescriptorCollection

                            If PropDescriptor.GetValue(SourceObject) <> KeyValueList(PropDescriptor.Name) Then

                                AddObject = False

                            End If

                        Next

                        If AddObject Then

                            List.Add(SourceObject)

                        End If

                    Next

                End If

            End If

            GetList = List

        End Function
        Private Sub SetupControl(ByVal Control As System.Windows.Forms.Control)

            If Control IsNot Nothing Then

                If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox Then

                    SetupSearchableComboBox(DirectCast(Control, AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox))
                    
                End If

            End If

        End Sub
        Private Sub SetupSearchableComboBox(ByVal SearchableComboBox As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox)

            If SearchableComboBox IsNot Nothing Then

                AddHandler SearchableComboBox.EditValueChanged, AddressOf SearchableComboBox_EditValueChanged
                AddHandler SearchableComboBox.QueryPopUp, AddressOf SearchableComboBox_QueryPopUp
                AddHandler SearchableComboBox.EditValueChanging, AddressOf SearchableComboBox_EditValueChanging

            End If

        End Sub
        Private Sub ReloadDisplayControlDataSource(ByVal Control As System.Windows.Forms.Control, Optional ByVal SelectSingleItemDataSource As Boolean = True, Optional ByVal IncludeCode As String = "")

            If Control IsNot Nothing Then

                SetDisplayControlDataSource(Control, SelectSingleItemDataSource, IncludeCode)
                SetDisplayControlValue(Control)

            End If

        End Sub
        Private Sub SetDisplayControlValue(ByVal Control As System.Windows.Forms.Control)

            'objects
            Dim Value As Object = Nothing

            If Control IsNot Nothing Then

                If Control Is _ClientDisplayControl Then

                    Value = Me.ClientCode

                ElseIf Control Is _DivisionDisplayControl Then

                    Value = Me.DivisionCode

                ElseIf Control Is _ProductDisplayControl Then

                    Value = Me.ProductCode

                ElseIf Control Is _JobDisplayControl Then

                    Value = Me.JobNumber

                ElseIf Control Is _JobComponentDisplayControl Then

                    Value = Me.JobComponentNumber

                End If

                SetDisplayControlValue(Control, Value)

            End If

        End Sub
        Private Sub SetDisplayControlValue(ByVal Control As System.Windows.Forms.Control, ByVal Value As Object)

            If Control IsNot Nothing Then

                If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox Then

                    If DirectCast(Control, AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox).EditValue <> Value Then

                        DirectCast(Control, AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox).EditValue = Value

                    End If

                End If

            End If

        End Sub
        Private Sub SetDisplayControlDataSource(ByVal Control As System.Windows.Forms.Control, Optional ByVal SelectSingleItemDataSource As Boolean = True, Optional ByVal IncludeCode As String = "")

            'objects
            Dim DataSource As IEnumerable = Nothing

            If Control IsNot Nothing Then

                If Control Is _ClientDisplayControl Then

                    DataSource = Me.ClientSource

                ElseIf Control Is _DivisionDisplayControl Then

                    DataSource = Me.DivisionSource(IncludeCode)

                ElseIf Control Is _ProductDisplayControl Then

                    DataSource = Me.ProductSource(IncludeCode)

                ElseIf Control Is _JobDisplayControl Then

                    DataSource = Me.JobSource

                ElseIf Control Is _JobComponentDisplayControl Then

                    DataSource = Me.JobComponentSource

                End If

                SetDisplayControlDataSource(Control, DataSource, SelectSingleItemDataSource)

            End If

        End Sub
        Private Sub SetDisplayControlDataSource(ByVal Control As System.Windows.Forms.Control, ByVal DataSource As IEnumerable, Optional ByVal SelectSingleItemDataSource As Boolean = True)

            If Control IsNot Nothing Then

                If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox Then

                    DirectCast(Control, AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox).DataSource = DataSource

                    If SelectSingleItemDataSource Then

                        DirectCast(Control, AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox).SelectSingleItemDataSource()

                    End If

                End If

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            'objects
            Dim ClientEnabled As Boolean = False
            Dim DivisionEnabled As Boolean = False
            Dim ProductEnabled As Boolean = False
            Dim JobEnabled As Boolean = False
            Dim JobComponentEnabled As Boolean = False

            If _ClientDisplayControl IsNot Nothing Then

                ClientEnabled = If(Me.ClientSource IsNot Nothing, True, False)
                
                If _DivisionDisplayControl IsNot Nothing Then

                    DivisionEnabled = Not String.IsNullOrWhiteSpace(Me.ClientCode)
                    
                    If _ProductDisplayControl IsNot Nothing Then

                        ProductEnabled = Not String.IsNullOrWhiteSpace(Me.DivisionCode)

                    End If

                End If

            End If

            If _JobDisplayControl IsNot Nothing Then

                JobEnabled = If(Me.JobSource IsNot Nothing, True, False)

                'If _JobComponentDisplayControl IsNot Nothing Then

                '    JobComponentEnabled = _JobNumber.HasValue AndAlso _JobNumber.Value > 0

                'End If

            End If

            If _JobComponentDisplayControl IsNot Nothing Then

                JobComponentEnabled = If(Me.JobComponentSource IsNot Nothing, True, False)

            End If

            EnableOrDisableControl(_ClientDisplayControl, ClientEnabled)
            EnableOrDisableControl(_DivisionDisplayControl, DivisionEnabled)
            EnableOrDisableControl(_ProductDisplayControl, ProductEnabled)
            EnableOrDisableControl(_JobDisplayControl, JobEnabled)
            EnableOrDisableControl(_JobComponentDisplayControl, JobComponentEnabled)

        End Sub
        Private Sub EnableOrDisableControl(ByVal Control As System.Windows.Forms.Control, ByVal Enabled As Boolean)

            If Control IsNot Nothing Then

                If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox Then

                    DirectCast(Control, AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox).Enabled = Enabled

                Else

                    Control.Enabled = Enabled

                End If

            End If

        End Sub
        Private Sub SelectSingleItemDataSource(ByVal Control As System.Windows.Forms.Control)

            'objects
            Dim ControlsToPrefill As Generic.List(Of System.Windows.Forms.Control) = Nothing
            Dim ControlHasValue As Boolean = False

            If Control IsNot Nothing Then

                ControlsToPrefill = New Generic.List(Of System.Windows.Forms.Control)

                If Control Is _ClientDisplayControl Then

                    ControlHasValue = Not String.IsNullOrWhiteSpace(Me.ClientCode)

                    ControlsToPrefill.Add(_DivisionDisplayControl)
                    ControlsToPrefill.Add(_ProductDisplayControl)
                    ControlsToPrefill.Add(_JobDisplayControl)
                    ControlsToPrefill.Add(_JobComponentDisplayControl)

                ElseIf Control Is _DivisionDisplayControl Then

                    ControlHasValue = Not String.IsNullOrWhiteSpace(Me.DivisionCode)

                    ControlsToPrefill.Add(_ProductDisplayControl)
                    ControlsToPrefill.Add(_JobDisplayControl)
                    ControlsToPrefill.Add(_JobComponentDisplayControl)

                ElseIf Control Is _ProductDisplayControl Then

                    ControlHasValue = Not String.IsNullOrWhiteSpace(Me.ProductCode)

                    ControlsToPrefill.Add(_JobDisplayControl)
                    ControlsToPrefill.Add(_JobComponentDisplayControl)

                ElseIf Control Is _JobDisplayControl Then

                    ControlHasValue = If(Me.JobNumber.GetValueOrDefault(0) = 0, False, True)

                    ControlsToPrefill.Add(_JobComponentDisplayControl)

                End If

                If ControlHasValue Then

                    For Each ControlToPrefill In ControlsToPrefill

                        PrefillControl(ControlToPrefill)

                    Next

                End If

            End If

        End Sub
        Public Sub SelectSingleItemDataSource()

            If String.IsNullOrWhiteSpace(Me.ClientCode) Then

                SelectSingleClient()

            ElseIf String.IsNullOrWhiteSpace(Me.DivisionCode) Then

                SelectSingleDivision()

            ElseIf String.IsNullOrWhiteSpace(Me.ProductCode) Then

                SelectSingleProduct()

            ElseIf Me.JobNumber.GetValueOrDefault(0) = 0 Then

                SelectSingleJob()

            ElseIf Me.JobComponentNumber.GetValueOrDefault(0) = 0 Then

                SelectSingleJobComponent()

            End If

        End Sub
        Private Sub PrefillControl(ByVal Control As System.Windows.Forms.Control)

            If Control IsNot Nothing Then

                If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox Then

                    DirectCast(Control, AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox).SelectSingleItemDataSource()

                End If

            End If

        End Sub
        Public Sub SetInitialValues(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal JobNumber As Integer?, ByVal JobComponentNumber As Short?)

            Me.ClientCode = Nothing
            Me.ClientCode = ClientCode

            Me.DivisionCode = Nothing
            Me.DivisionCode = DivisionCode

            Me.ProductCode = Nothing
            Me.ProductCode = ProductCode

            Me.JobNumber = Nothing
            Me.JobNumber = JobNumber

            Me.JobComponentNumber = Nothing
            Me.JobComponentNumber = JobComponentNumber

        End Sub
        Public Sub SetSession(ByVal Session As AdvantageFramework.Security.Session)

            _Session = Session

        End Sub

#Region "  Editor Methods "

#Region "   SearchableComboBox "

        Private Sub SearchableComboBox_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

            ''objects
            'Dim SearchableComboBox As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox = Nothing

            'Try

            '    SearchableComboBox = DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox)

            'Catch ex As Exception
            '    SearchableComboBox = Nothing
            'End Try

            'If SearchableComboBox IsNot Nothing Then

            '    If SearchableComboBox Is _ClientDisplayControl Then

            '        RaiseEvent ClientChangingEvent(e.Cancel)

            '    ElseIf SearchableComboBox Is _DivisionDisplayControl Then

            '        RaiseEvent DivisionChangingEvent(e.Cancel)

            '    ElseIf SearchableComboBox Is _ProductDisplayControl Then

            '        RaiseEvent ProductChangingEvent(e.Cancel)

            '    ElseIf SearchableComboBox Is _JobDisplayControl Then

            '        RaiseEvent JobChangingEvent(e.Cancel)

            '    ElseIf SearchableComboBox Is _JobComponentDisplayControl Then

            '        RaiseEvent ComponentChangingEvent(e.Cancel)

            '    End If

            'End If

        End Sub
        Private Sub SearchableComboBox_EditValueChanged(sender As Object, e As EventArgs)

            'objects
            Dim SearchableComboBox As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Integer = Nothing
            Dim JobComponentID As Integer = Nothing

            Try

                SearchableComboBox = DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox)

            Catch ex As Exception
                SearchableComboBox = Nothing
            End Try

            If SearchableComboBox IsNot Nothing Then

                If SearchableComboBox Is _ClientDisplayControl Then

                    Me.ClientCode = SearchableComboBox.GetSelectedValue

                ElseIf SearchableComboBox Is _DivisionDisplayControl Then

                    Me.DivisionCode = SearchableComboBox.GetSelectedValue

                ElseIf SearchableComboBox Is _ProductDisplayControl Then

                    Me.ProductCode = SearchableComboBox.GetSelectedValue

                ElseIf SearchableComboBox Is _JobDisplayControl Then

                    Me.JobNumber = SearchableComboBox.GetSelectedValue

                ElseIf SearchableComboBox Is _JobComponentDisplayControl Then

                    If SearchableComboBox.Properties.View.Columns Is Nothing OrElse SearchableComboBox.Properties.View.Columns.Count = 0 Then

                        SearchableComboBox.Properties.View.PopulateColumns()

                    End If

                    JobNumber = SearchableComboBox.Properties.View.GetFocusedRowCellValue("JobNumber")
                    JobComponentNumber = SearchableComboBox.GetSelectedValue
                    JobComponentID = SearchableComboBox.Properties.View.GetFocusedRowCellValue("ID")

                    If JobComponentNumber > 0 Then

                        If Me.JobNumber.HasValue = False Then

                            Me.JobNumber = JobNumber

                        End If

                    End If

                    Me.JobComponentNumber = JobComponentNumber

                    If Me.JobComponentNumber > 0 Then

                        _JobComponentID = JobComponentID

                    Else

                        _JobComponentID = Nothing

                    End If

                End If

            End If

        End Sub
        Private Sub SearchableComboBox_QueryPopUp(sender As Object, e As ComponentModel.CancelEventArgs)

            'objects
            Dim SearchableComboBox As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox = Nothing

            Try

                SearchableComboBox = DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox)

            Catch ex As Exception
                SearchableComboBox = Nothing
            End Try

            If SearchableComboBox IsNot Nothing Then

                If SearchableComboBox.ControlType = Controls.SearchableComboBox.Type.JobComponent Then
                    
                    If SearchableComboBox.Properties.View.Columns("JobNumber") IsNot Nothing Then

                        SearchableComboBox.Properties.View.Columns("JobNumber").Visible = Not Me.JobNumber.HasValue

                    End If

                End If

            End If

        End Sub

#End Region

#End Region

#End Region

    End Class

End Namespace