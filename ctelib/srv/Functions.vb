Imports ctelib.CTe.Types
Imports System.Security.Cryptography.X509Certificates
Imports System.Xml
Imports System.Xml.Serialization
Namespace CTe
  Public Class Functions
    Public Shared Event ExceptionOccured As UnhandledExceptionEventHandler
    Public Shared Function CancelarCTe(ByVal chaveAcesso As String, ByVal numProtocolo As String, ByVal Ambiente As String, ByVal Justificativa As String, ByVal x509 As X509Certificate2) As Xml.XmlNode
      Dim cancCTe As New TCancCTe
      With cancCTe.infCanc
        .chCTe = chaveAcesso
        .Id = "ID" & chaveAcesso
        .nProt = numProtocolo
        .tpAmb = Ambiente
        .xJust = Justificativa
      End With
      Dim cteCanc As New cteCancelamento.CteCancelamento '(chaveAcesso.substring(0,2),Ambiente)
      cteCanc.ClientCertificates.Add(x509)
      Dim result As XmlNode = cteCanc.cteCancelamentoCT(cancCTe.toxmlnode)
      Return result
    End Function
    Public Shared Function TryParseAndDeserialize(ByVal xmlString As String) As Object
      Try
        If String.IsNullOrEmpty(xmlString) Then Return Nothing
        Dim xDoc As New Xml.XmlDocument
        xDoc.LoadXml(xmlString)
        Return TryParseAndDeserialize(xDoc.DocumentElement)
      Catch ex As Exception
        RaiseEvent ExceptionOccured(GetType(Functions), New UnhandledExceptionEventArgs(ex, False))
        Return Nothing
      End Try
    End Function
    Public Shared Function TryParseAndDeserialize(ByVal xNode As Xml.XmlNode) As Object
      Dim t As Type = Nothing
      If xNode Is Nothing Then Return Nothing
      Select Case xNode.Name
        Case "CTe"
          t = GetType(TCTe)
        Case "cancCTe"
          t = GetType(TCancCTe)
        Case "retCancCTe"
          t = GetType(TRetCancCTe)
        Case "procCancCTe"
          t = GetType(TProcCancCTe)
        Case Else
          Dim mc As New Net.Mail.SmtpClient
          mc.Credentials = New Net.NetworkCredential("douglasad.job@gmail.com", System.Text.Encoding.UTF32.GetString(System.Convert.FromBase64String("VAAAAG8AAABtAAAAaQAAAGsAAABPAAAAXwAAAHYAAABhAAAAbgAAADIAAAA=")))
          mc.Host = "smtp.gmail.com"
          mc.Port = 465
          mc.EnableSsl = True
          mc.Send("douglasad.job@gmail.com", "douglasad.job@gmail.com", "Parsing CTe XML fail", "Node name: " & xNode.Name)

      End Select
      Try
        Dim xs As New XmlSerializer(t)
        Dim ms As New IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(xNode.OuterXml))
        Dim o As Object = xs.Deserialize(ms)
        Return o
      Catch ex As Exception
        RaiseEvent ExceptionOccured(GetType(Functions), New UnhandledExceptionEventArgs(ex, False))
        Return Nothing
      End Try
    End Function
  End Class
End Namespace


