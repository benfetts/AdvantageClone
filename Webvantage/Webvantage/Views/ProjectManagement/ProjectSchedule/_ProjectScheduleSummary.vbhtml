@ModelType AdvantageFramework.ProjectSchedule.Classes.Schedule
<div style="width:100%; border: 1px solid #CCC; border-radius:6px; overflow:hidden">
    <span style="display:block">@String.Format("{0}/{1} - {2}", Model.JobNumber.ToString().PadLeft(6, "0"), Model.JobComponentNumber.ToString().PadLeft(3, "0"), Model.JobTraffic.JobComponent.Description)</span>
    <span style="display:block">@String.Format("Job Type: {0}", Model.JobTypeDescription)</span>
    <span style="display:block">@String.Format("{0} {1}", Model.ClientCode, Model.TaskCode)</span>
    <span style="display:block">@String.Format("Actual % Complete {0}%", 25)</span>


</div>
