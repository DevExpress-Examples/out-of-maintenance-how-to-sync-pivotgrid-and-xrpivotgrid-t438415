<script type="text/javascript">
    function onInit(s, e) {
        DocumentViewer.Refresh();
    }
    function onEndCallback(s, e) {
        DocumentViewer.Refresh();
    }
</script>

@Html.Action("PivotGridPartial")
@Html.Action("DocumentViewerPartial", "Home")
