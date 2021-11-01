@ModelType Webvantage.ViewModels.EmployeesViewModel
<div class="row-spacer">

    @Html.EJ().ListBox("Boards").Datasource(DirectCast(Model.List, Generic.List(Of AdvantageFramework.Database.Entities.EmployeeSimple))).ListBoxFields(Function(F) F.Value("Code").Text("FullName").Selected("Selected")).AllowMultiSelection(True).Height("100%").Width("50%").ShowCheckbox(True).ClientSideEvents(Sub(e)
                                                                                                                                                                                                                                                                                                                          e.Selected("Selected")
                                                                                                                                                                                                                                                                                                                      End Sub)

<script>
    function SelectIndexChanged(args){
        showKendoAlert("SelectIndexChanged")
       //console.log(args);
    }
    function Select(args){
        showKendoAlert("Select")
        //console.log(args);
   }
    function Selected(args){
        showKendoAlert("Selected")
       //console.log(args);
    }
</script>

</div>
