Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Common
Imports System.Data.OleDb
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Net.Mail
Imports System.Runtime.Serialization
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Web
Imports System.Web.Caching
Imports System.Web.Configuration

Namespace RedStag.Data
    
    Public Class ImportMapDictionary
        Inherits SortedDictionary(Of Integer, DataField)
    End Class
    
    Public Class ImportLookupDictionary
        Inherits SortedDictionary(Of String, DataField)
    End Class
    
    Partial Public Class ImportProcessor
        Inherits ImportProcessorBase
    End Class
    
    Partial Public Class ImportProcessorFactory
        Inherits ImportProcessorFactoryBase
    End Class
    
    Public Class ImportProcessorFactoryBase
        
        Public Overridable Function CreateProcessor(ByVal fileName As String) As ImportProcessorBase
            Throw New Exception(String.Format("The format of file <b>{0}</b> is not supported.", Path.GetFileName(fileName)))
        End Function
        
        Public Shared Function Create(ByVal fileName As String) As ImportProcessorBase
            Dim factory As ImportProcessorFactoryBase = New ImportProcessorFactory()
            Return factory.CreateProcessor(fileName)
        End Function
    End Class
    
    Public Class ImportProcessorBase
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Shared ReadOnly Property SharedTempPath() As String
            Get
                Dim p As String = WebConfigurationManager.AppSettings("SharedTempPath")
                If String.IsNullOrEmpty(p) Then
                    p = Path.GetTempPath()
                End If
                If Not (Path.IsPathRooted(p)) Then
                    p = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, p)
                End If
                Return p
            End Get
        End Property
        
        Public Shared Sub Execute(ByVal args As ActionArgs)
        End Sub
    End Class
End Namespace
