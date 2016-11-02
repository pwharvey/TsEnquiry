Imports RedStag.Data
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Web
Imports System.Web.Script.Services
Imports System.Web.Services

Namespace RedStag.Services
    
    Public Class DataControllerService
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Function GetPage(ByVal controller As String, ByVal view As String, ByVal request As PageRequest) As ViewPage
            Return ControllerFactory.CreateDataController().GetPage(controller, view, request)
        End Function
        
        Public Function GetPageList(ByVal requests() As PageRequest) As ViewPage()
            Return CType(ControllerFactory.CreateDataController(),DataControllerBase).GetPageList(requests)
        End Function
        
        Public Function GetListOfValues(ByVal controller As String, ByVal view As String, ByVal request As DistinctValueRequest) As Object()
            Return ControllerFactory.CreateDataController().GetListOfValues(controller, view, request)
        End Function
        
        Public Function Execute(ByVal controller As String, ByVal view As String, ByVal args As ActionArgs) As ActionResult
            Return ControllerFactory.CreateDataController().Execute(controller, view, args)
        End Function
        
        Public Function GetCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
            Return ControllerFactory.CreateAutoCompleteManager().GetCompletionList(prefixText, count, contextKey)
        End Function
        
        Public Function Login(ByVal username As String, ByVal password As String, ByVal createPersistentCookie As Boolean) As Boolean
            Return ApplicationServices.Login(username, password, createPersistentCookie)
        End Function
        
        Public Sub Logout()
            ApplicationServices.Logout()
        End Sub
        
        Public Function Roles() As String()
            Return ApplicationServices.Roles()
        End Function
    End Class
End Namespace
