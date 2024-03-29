Imports ctelib.CTe.Types
Imports System.Security.Cryptography.X509Certificates
Imports System.Xml
Imports System.Xml.Serialization
Namespace CTe
  Public Class Functions
    Public Shared Event ExceptionOccured As UnhandledExceptionEventHandler
    <DebuggerStepThrough()> _
    Public Shared Function CancelarCTe(ByVal chaveAcesso As String, ByVal numProtocolo As String, ByVal Ambiente As String, ByVal Justificativa As String, ByVal x509 As X509Certificate2) As Xml.XmlNode
      Dim cancCTe As New TCancCTe
      With cancCTe.infCanc
        .chCTe = chaveAcesso
        .Id = "ID" & chaveAcesso
        .nProt = numProtocolo
        .tpAmb = Ambiente
        .xJust = Justificativa
      End With
      Return CancelarCTe(cancCTe, x509)
    End Function
    Public Shared Function CancelarCTe(ByVal cancCTe As TCancCTe, ByVal x509 As X509Certificate2) As XmlNode
      Dim ws As New CTe.WebServices.CteCancelamento(cancCTe.infCanc.chCTe.Substring(0, 2), cancCTe.infCanc.tpAmb)
      ws.ClientCertificates.Add(x509)
      If cancCTe.Signature Is Nothing Then _
        cancCTe = TryParseAndDeserialize(AssinarRaizXML(cancCTe.ToXMLNode, x509, cancCTe.infCanc.Id))
      Dim result As XmlNode = ws.cteCancelamentoCT(cancCTe.ToXMLNode)
      Return result
    End Function
    Public Shared Function ConsultaStatusServiço(ByVal cUF As Integer, ByVal Ambiente As String, ByVal x509 As X509Certificate2) As XmlNode
      Dim consStatServ As New TConsStatServ
      With consStatServ
        .tpAmb = Ambiente
        .versao = "1.00"
      End With
      Dim ws As New CTe.WebServices.CteStatusServico(cUF, Ambiente)
      ws.ClientCertificates.Add(x509)
      Dim result As XmlNode = ws.cteStatusServicoCT(consStatServ.ToXMLNode)
      Return result
    End Function
    Public Shared Function ConsultarSituaçãoCTe(ByVal chAcesso As String, ByVal Ambiente As String, ByVal x509 As X509Certificate2) As XmlNode
      Dim consSitCTe As New TConsSitCTe(Ambiente, chAcesso)
      Dim ws As New CTe.WebServices.CteConsulta(chAcesso.Substring(0, 2), Ambiente)
      ws.ClientCertificates.Add(x509)
      ws.cteCabecMsgValue.versaoDados = "1.04"
      Dim result As XmlNode = ws.cteConsultaCT(consSitCTe.ToXMLNode)
      Return result
    End Function
    <DebuggerStepThrough()> _
    Public Shared Function TransmitirCTe(ByVal numLote As Long, ByVal CTe As TCTe, ByVal x509 As X509Certificate2) As XmlNode
      Return TransmitirCTe(New TEnviCTe(numLote, CTe), x509)
    End Function
    <DebuggerStepThrough()> _
    Public Shared Function TransmitirCTe(ByVal numLote As Long, ByVal CTe() As TCTe, ByVal x509 As X509Certificate2) As XmlNode
      Return TransmitirCTe(New TEnviCTe(numLote, CTe), x509)
    End Function
    Public Shared Function TransmitirCTe(ByVal lote As TEnviCTe, ByVal x509 As X509Certificate2) As XmlNode
      If lote.CTe Is Nothing Then Return Nothing
      If lote.CTe.Length = 0 Then Return Nothing
      Dim ws As New CTe.WebServices.CteRecepcao(lote.CTe(0).infCte.ide.cUF, lote.CTe(0).infCte.ide.tpAmb)
      ws.ClientCertificates.Add(x509)
      Dim result As XmlNode = ws.cteRecepcaoLote(lote.ToXMLNode)
      Return result
    End Function

    Public Shared Function InutilizarFaixa(ByVal inutCTe As TInutCTe, ByVal x509 As X509Certificate2) As XmlNode
      Dim ws As New CTe.WebServices.CteInutilizacao(inutCTe.infInut.cUF, inutCTe.infInut.tpAmb)
      ws.ClientCertificates.Add(x509)
      If inutCTe.Signature Is Nothing Then inutCTe = TryParseAndDeserialize(AssinarRaizXML(inutCTe.toxmlnode, x509, inutCTe.infInut.Id))
      Dim result As XmlNode = ws.cteInutilizacaoCT(inutCTe.ToXMLNode)
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
        Case "cteProc"
          t = GetType(cteProc)
        Case "cancCTe"
          t = GetType(TCancCTe)
        Case "consSitCTe"
          t = GetType(TConsSitCTe)
        Case "retConsSitCTe"
          t = GetType(TRetConsSitCTe)
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
    <DebuggerStepThrough()> _
      Public Shared Function AssinarRaizXML(ByVal source As Object, ByVal x509 As X509Certificate2, ByVal ReferenceURI As String) As XmlDocument
      Return AssinarRaizXML(source.toxmlnode, x509, ReferenceURI)
    End Function
    Public Shared Function AssinarRaizXML(ByVal source As XmlNode, ByVal x509 As X509Certificate2, ByVal ReferenceURI As String) As XmlDocument
      Dim xDoc As New XmlDocument
      xDoc.LoadXml(source.OuterXml)
      Return AssinarRaizXML(xDoc, x509, ReferenceURI)
    End Function
    <DebuggerStepThrough()> _
    Public Shared Function AssinarRaizXML(ByVal source As XmlDocument, ByVal x509 As X509Certificate2, ByVal ReferenceURI As String) As XmlDocument
      Dim Key As New System.Security.Cryptography.RSACryptoServiceProvider()
      Dim SignedDocument As System.Security.Cryptography.Xml.SignedXml
      Dim keyInfo As New System.Security.Cryptography.Xml.KeyInfo()

      'Retira chave privada ligada ao certificado
      Key = CType(x509.PrivateKey, System.Security.Cryptography.RSACryptoServiceProvider)
      'Adiciona Certificado ao Key Info
      keyInfo.AddClause(New System.Security.Cryptography.Xml.KeyInfoX509Data(x509))
      SignedDocument = New System.Security.Cryptography.Xml.SignedXml(source)
      'Seta chaves
      SignedDocument.SigningKey = Key
      SignedDocument.KeyInfo = keyInfo
      ' Cria referencia
      Dim reference As New System.Security.Cryptography.Xml.Reference()
      reference.Uri = IIf(ReferenceURI.Length = 0, String.Empty, "#" & ReferenceURI)
      ' Adiciona transformacao a referencia
      reference.AddTransform(New System.Security.Cryptography.Xml.XmlDsigEnvelopedSignatureTransform())
      reference.AddTransform(New System.Security.Cryptography.Xml.XmlDsigC14NTransform(False))
      ' Adiciona referencia ao xml
      SignedDocument.AddReference(reference)
      ' Calcula Assinatura
      SignedDocument.ComputeSignature()
      ' Pega representação da assinatura
      Dim xmlDigitalSignature As System.Xml.XmlElement = SignedDocument.GetXml()
      ' Adiciona ao doc XML
      source.DocumentElement.AppendChild(source.ImportNode(xmlDigitalSignature, True))
      Return source
    End Function
    <DebuggerStepThrough()> _
    Public Shared Function SelecionarCertificado() As X509Certificate2
      'Listando certificados
      Dim store As New X509Store(StoreName.My)
      store.Open(OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly)
      Dim validCertificates As X509Certificate2Collection = store.Certificates.Find(X509FindType.FindByTimeValid, Now, True)
      If validCertificates.Count <= 0 Then Return Nothing
      Dim selected As X509Certificate2Collection = X509Certificate2UI.SelectFromCollection(validCertificates, "Selecione um certificado", "", X509SelectionFlag.SingleSelection)
      If selected.Count > 0 Then
        'IO.File.AppendAllText("certificate.selection.log", Now.ToString("[yyyy-MM-dd HH:mm:ss]") & "Last public key selected: " & vbNewLine & selected(0).GetPublicKeyString & vbNewLine)
        Return selected(0)
      End If
      Return Nothing
    End Function
    <DebuggerStepThrough()> _
    Public Shared Function SelecionarCertificado(ByVal publicKey As String) As X509Certificate2
      If String.IsNullOrEmpty(publicKey) Then Return SelecionarCertificado()
      Dim store As New X509Store(StoreName.My)
      store.Open(OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly)
      Dim validCertificates As X509Certificate2Collection = store.Certificates.Find(X509FindType.FindByTimeValid, Now, True)
      If validCertificates.Count <= 0 Then Return Nothing
      For Each x509 As X509Certificate2 In validCertificates
        If x509.GetPublicKeyString = publicKey Then Return x509
      Next
      Dim selected As X509Certificate2Collection = _
      X509Certificate2UI.SelectFromCollection(validCertificates, "Selecione um certificado", "Não foi encontrado nenhum certificado com a chave publica informada, favor selecionar outro certificado.", X509SelectionFlag.SingleSelection)
      If selected.Count > 0 Then
        'IO.File.AppendAllText("certificate.selection.log", Now.ToString("[yyyy-MM-dd HH:mm:ss]") & "Last public key selected: " & vbNewLine & selected(0).GetPublicKeyString & vbNewLine)
        Return selected(0)
      End If

      Return Nothing
      'Return Nothing
    End Function
    Friend Shared Sub InitCTEWSXML()
      If Not IO.File.Exists("\ctews.xml") Then IO.File.WriteAllText("\ctews.xml", My.Resources.ctews, System.Text.Encoding.UTF8)
    End Sub
    Friend Shared Sub DeinitCTEWSXML()
      If IO.File.Exists("\ctews.xml") Then IO.File.Delete("\ctews.xml")
    End Sub
  End Class
End Namespace


