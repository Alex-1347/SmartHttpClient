'Require setting in web.config
'<configuration>
'  <appSettings>
'    <add key="AcceptAnySSLCertificate" value="true"/>
' </appSettings>
'...

Public Class SSLHttpClient
        Inherits System.Net.Http.HttpClient
        Public Sub New()
            MyBase.New
            If CBool(System.Configuration.ConfigurationManager.AppSettings("AcceptAnySSLCertificate")) Then
                System.Net.ServicePointManager.ServerCertificateValidationCallback = Function(s As Object,
                                                                                              cert As System.Security.Cryptography.X509Certificates.X509Certificate,
                                                                                              chain As System.Security.Cryptography.X509Certificates.X509Chain,
                                                                                              err As System.Net.Security.SslPolicyErrors)
                                                                                         Return True
                                                                                     End Function
            End If
        End Sub

        Public Sub New(handler As System.Net.Http.HttpMessageHandler)
            MyBase.New(handler)
            If CBool(System.Configuration.ConfigurationManager.AppSettings("AcceptAnySSLCertificate")) Then
                System.Net.ServicePointManager.ServerCertificateValidationCallback = Function(s As Object,
                                                                                              cert As System.Security.Cryptography.X509Certificates.X509Certificate,
                                                                                              chain As System.Security.Cryptography.X509Certificates.X509Chain,
                                                                                              err As System.Net.Security.SslPolicyErrors)
                                                                                         Return True
                                                                                     End Function
            End If

        End Sub

        Public Sub New(handler As System.Net.Http.HttpMessageHandler, disposeHandler As Boolean)
            MyBase.New(handler, disposeHandler)
            If CBool(System.Configuration.ConfigurationManager.AppSettings("AcceptAnySSLCertificate")) Then
                System.Net.ServicePointManager.ServerCertificateValidationCallback = Function(s As Object,
                                                                                              cert As System.Security.Cryptography.X509Certificates.X509Certificate,
                                                                                              chain As System.Security.Cryptography.X509Certificates.X509Chain,
                                                                                              err As System.Net.Security.SslPolicyErrors)
                                                                                         Return True
                                                                                     End Function
            End If
        End Sub
    End Class

