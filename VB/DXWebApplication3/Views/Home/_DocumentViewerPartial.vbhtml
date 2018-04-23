@Html.DevExpress().DocumentViewer(
    Sub(settings)
            settings.Name = "DocumentViewer"
            settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "DocumentViewerPartial"}
            settings.ExportRouteValues = New With {Key .Controller = "Home", Key .Action = "DocumentViewerPartialExport"}
            settings.Report = CType(Model, DXWebApplication3.Models.XtraReport1)
            settings.ToolbarMode = DocumentViewerToolbarMode.StandardToolbar
    End Sub).GetHtml()