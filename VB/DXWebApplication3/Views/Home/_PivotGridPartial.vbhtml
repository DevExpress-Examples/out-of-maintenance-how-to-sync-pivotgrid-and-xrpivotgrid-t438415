@Functions
    Sub ConfigurePivot(ByVal s As System.Object, ByVal e As System.EventArgs)
        Dim pivot As MVCxPivotGrid = DirectCast(s, MVCxPivotGrid)
        Using collapsedStateMS As New MemoryStream()
            Using layoutMS As New MemoryStream()
                CType(New DevExpress.Utils.Serializing.XmlXtraSerializer(), DevExpress.Utils.Serializing.XmlXtraSerializer).SerializeObject(pivot, layoutMS, "PivotGrid")

                pivot.SaveCollapsedStateToStream(collapsedStateMS)

                Session("CollapsedState") = collapsedStateMS.ToArray()
                Session("Layout") = layoutMS.ToArray()
            End Using
        End Using
    End Sub
End Functions

@Html.DevExpress().PivotGrid(
 Sub(settings)
     settings.Name = "PivotGrid"
     settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "PivotGridPartial"}
     settings.OptionsData.DataProcessingEngine = PivotDataProcessingEngine.Optimized
     settings.Fields.Add(Sub(field)
                             field.Area = PivotArea.RowArea
                             field.DataBinding = New DevExpress.Web.ASPxPivotGrid.DataSourceColumnBinding("CategoryName")
                             field.Caption = "CategoryName"
                         End Sub)
     settings.Fields.Add(Sub(field)
                             field.Area = PivotArea.FilterArea
                             field.DataBinding = New DevExpress.Web.ASPxPivotGrid.DataSourceColumnBinding("ProductName")
                             field.Caption = "ProductName"
                         End Sub)
     settings.Fields.Add(Sub(field)
                             field.Area = PivotArea.DataArea
                             field.DataBinding = New DevExpress.Web.ASPxPivotGrid.DataSourceColumnBinding("ProductSales")
                             field.Caption = "ProductSales"
                         End Sub)
     settings.Fields.Add(Sub(field)
                             field.Area = PivotArea.FilterArea
                             field.DataBinding = New DevExpress.Web.ASPxPivotGrid.DataSourceColumnBinding("ShippedDate")
                             field.Caption = "ShippedDate"
                         End Sub)

     settings.PreRender = AddressOf ConfigurePivot
     settings.AfterPerformCallback = AddressOf ConfigurePivot

     settings.ClientSideEvents.Init = "onInit"
     settings.ClientSideEvents.EndCallback = "onEndCallback"
 End Sub).Bind(Model).GetHtml()