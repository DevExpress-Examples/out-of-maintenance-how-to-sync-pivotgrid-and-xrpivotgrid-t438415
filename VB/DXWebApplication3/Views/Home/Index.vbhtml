@Code
    ViewBag.Title = "Index"
End Code

<h2>Index</h2>

<script type="text/javascript">
    function onInit(s, e) {
        WebDocumentViewer.OpenReport("PivotGrid");
    }
    function onEndCallback(s, e) {
        WebDocumentViewer.Close();
        WebDocumentViewer.OpenReport("PivotGrid");
    }
</script>

@Html.Action("PivotGridPartial")
@Html.DevExpress().WebDocumentViewer(Sub(settings)
                                              settings.Name = "WebDocumentViewer"
                                          End Sub).GetHtml()