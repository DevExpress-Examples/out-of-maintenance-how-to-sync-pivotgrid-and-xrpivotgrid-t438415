Imports DevExpress.XtraPivotGrid.Data
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.UI.PivotGrid
Imports DevExpress.XtraReports.Web.WebDocumentViewer
Imports DXWebApplication3.Models
Imports DXWebApplication3.Reports
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Web

Namespace DXWebApplication3
    Public Class CustomWebDocumentViewerReportResolver
        Implements IWebDocumentViewerReportResolver

        Private db As New NWindEntities()

        Public Function CreatePivotGridReport() As XtraReport
            Dim report As New XtraReport1()
            Dim pivotGrid As XRPivotGrid = report.xrPivotGrid1
            pivotGrid.DataSource = db.ProductReports.ToList()
            Dim session = HttpContext.Current.Session

            Dim collapsedState() As Byte = DirectCast(session("CollapsedState"), Byte())
            Dim layout() As Byte = DirectCast(session("Layout"), Byte())

            If collapsedState IsNot Nothing AndAlso layout IsNot Nothing Then
                Using collapsedStateMS As New MemoryStream(collapsedState)
                    Using layoutMS As New MemoryStream(layout)

                        Dim data As PivotGridData = DirectCast(pivotGrid, IPivotGridDataContainer).Data
                        Call (New DevExpress.Utils.Serializing.XmlXtraSerializer()).DeserializeObject(pivotGrid, layoutMS, "PivotGrid")
                        data.LoadCollapsedStateFromStream(collapsedStateMS)
                    End Using
                End Using
            End If
            Return report
        End Function

        Public Function Resolve(ByVal reportEntry As String) As XtraReport Implements IWebDocumentViewerReportResolver.Resolve
            Select Case reportEntry
                Case "PivotGrid"
                    Return CreatePivotGridReport()
            End Select
            Return New XtraReport()
        End Function
    End Class
End Namespace