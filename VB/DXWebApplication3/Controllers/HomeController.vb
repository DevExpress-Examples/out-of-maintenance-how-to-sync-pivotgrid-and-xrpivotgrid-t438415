Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports DXWebApplication3.Models
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraPivotGrid.Data
Imports DevExpress.XtraReports.UI.PivotGrid
Imports System.IO

Namespace DXWebApplication3.Controllers
    Public Class HomeController
        Inherits Controller

        Private db As NwindContextDataContext = New DXWebApplication3.Models.NwindContextDataContext()

        Public Function Index() As ActionResult
            Return View()
        End Function

        <ValidateInput(False)> _
        Public Function PivotGridPartial() As ActionResult
            Dim model = db.ProductReports
            Return PartialView("_PivotGridPartial", model.ToList())
        End Function

        Public Function DocumentViewerPartial() As ActionResult
            Dim report As XtraReport = CreateReport()
            Return PartialView("_DocumentViewerPartial", report)
        End Function

        Public Function DocumentViewerPartialExport() As ActionResult
            Dim report As XtraReport = CreateReport()
            Return DocumentViewerExtension.ExportTo(report, Request)
        End Function

        Public Function CreateReport() As XtraReport
            Dim report As New XtraReport1()
            Dim pivotGrid As XRPivotGrid = report.xrPivotGrid1
            pivotGrid.DataSource = db.ProductReports

            Dim collapsedState() As Byte = CType(Session("CollapsedState"), Byte())
            Dim layout() As Byte = CType(Session("Layout"), Byte())

            If collapsedState IsNot Nothing AndAlso layout IsNot Nothing Then
                Using collapsedStateMS As New MemoryStream(collapsedState)
                    Using layoutMS As New MemoryStream(layout)
                        Dim data As PivotGridData = (CType(pivotGrid, DevExpress.Data.PivotGrid.IPivotGridDataContainer)).Data
                        CType(New DevExpress.Utils.Serializing.XmlXtraSerializer(), DevExpress.Utils.Serializing.XmlXtraSerializer).DeserializeObject(pivotGrid, layoutMS, "PivotGrid")
                        data.LoadCollapsedStateFromStream(collapsedStateMS)
                    End Using
                End Using
            End If
            Return report
        End Function
    End Class
End Namespace