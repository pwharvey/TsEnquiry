Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.DataVisualization.Charting
Imports System.Web.UI.WebControls


Partial Public Class Controls_Chart_StockCurrent_StockByLocation
    Inherits Global.System.Web.UI.UserControl
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
    End Sub
    
    Public Overrides Sub DataBind()
        MyBase.DataBind()
        Chart1.DataManipulator.GroupByAxisLabel("Sum", "Packets")
    End Sub
End Class
