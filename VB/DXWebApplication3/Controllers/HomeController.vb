Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Mvc
Imports DXWebApplication3.Models

Namespace DXWebApplication3.Controllers
    Public Class HomeController
        Inherits Controller

        Private db As New NWindEntities()

        Public Function Index() As ActionResult
            Return View()
        End Function

        <ValidateInput(False)>
        Public Function PivotGridPartial() As ActionResult
            Dim model = db.ProductReports
            Return PartialView("_PivotGridPartial", model.ToList())
        End Function
    End Class
End Namespace