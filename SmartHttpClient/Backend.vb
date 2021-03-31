Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports Newtonsoft.Json

Public Class SmartHttpClient
    Public Shared Async Function [Get](URL As String) As Threading.Tasks.Task(Of HttpResponseMessage)
        Using Client As New SSLHttpClient()
            Using ServiceRequest As New HttpRequestMessage(HttpMethod.Get, URL)
                Return Await Client.SendAsync(ServiceRequest)
            End Using
        End Using
    End Function

    Public Shared Async Function [Delete](URL As String) As Threading.Tasks.Task(Of HttpResponseMessage)
        Using Client As New SSLHttpClient()
            Using ServiceRequest As New HttpRequestMessage(HttpMethod.Get, URL)
                Return Await Client.SendAsync(ServiceRequest)
            End Using
        End Using
    End Function

    Public Shared Async Function [Post](URL As String, DictionaryForConverter As Dictionary(Of String, String)) As Threading.Tasks.Task(Of HttpResponseMessage)
        Using Client As New SSLHttpClient()
            Client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
            Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8")
            Using RequestContent As New StringContent(JsonConvert.SerializeObject(DictionaryForConverter), Encoding.UTF8, "application/json")
                Return Await Client.PostAsync(URL, RequestContent)
            End Using
        End Using
    End Function

    Public Shared Async Function GetStreamToBase64String(URL As String) As Threading.Tasks.Task(Of Tuple(Of String, String))
        Dim Response = Await [Get](URL)
        If Response.IsSuccessStatusCode Then
            Dim NewStream As New IO.MemoryStream
            Dim PhotoStream As IO.Stream = Await Response.Content.ReadAsStreamAsync
            PhotoStream.CopyTo(NewStream)
            PhotoStream.Close()
            Dim ByteBuff As Byte() = NewStream.ToArray
            Return New Tuple(Of String, String)(Convert.ToBase64String(ByteBuff), "OK")
        Else
            Return New Tuple(Of String, String)("", Response.ReasonPhrase)
        End If
    End Function
End Class

