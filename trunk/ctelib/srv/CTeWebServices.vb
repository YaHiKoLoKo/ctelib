Option Strict Off
Option Explicit On
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

Namespace CTe.WebServices
  <XmlRoot("CTeWebServices")> _
  Public Class CTeWebServices
    Private Shared list As New CTeWebServices
    Private Shared loading As Boolean = False
    Private ufField() As WebServicesUF
    Private ufsiglaField() As eUF

    Public Enum eUF
      AC = 12
      AL = 27
      AM = 13
      AP = 16
      BA = 29
      CE = 23
      DF = 53
      ES = 32
      GO = 52
      MA = 21
      MG = 31
      MS = 50
      MT = 51
      PA = 15
      PB = 25
      PE = 26
      PI = 22
      PR = 41
      RJ = 33
      RN = 24
      RO = 11
      RR = 14
      RS = 43
      SC = 42
      SE = 28
      SP = 35
      [TO] = 17
    End Enum

    <XmlElement("AC"), _
  XmlElement("AL"), _
  XmlElement("AM"), _
  XmlElement("AP"), _
  XmlElement("BA"), _
  XmlElement("CE"), _
  XmlElement("DF"), _
  XmlElement("ES"), _
  XmlElement("GO"), _
  XmlElement("MA"), _
  XmlElement("MG"), _
  XmlElement("MS"), _
  XmlElement("MT"), _
  XmlElement("PA"), _
  XmlElement("PB"), _
  XmlElement("PE"), _
  XmlElement("PI"), _
  XmlElement("PR"), _
  XmlElement("RJ"), _
  XmlElement("RN"), _
  XmlElement("RO"), _
  XmlElement("RR"), _
  XmlElement("RS"), _
  XmlElement("SC"), _
  XmlElement("SE"), _
  XmlElement("SP"), _
  XmlElement("TO"), _
  XmlChoiceIdentifier("UFSigla")> _
    Public Property UF() As WebServicesUF()
      Get
        Return ufField
      End Get
      Set(ByVal value As WebServicesUF())
        ufField = value
      End Set
    End Property
    <XmlIgnore()> _
        Public Property UFSigla() As eUF()
      Get
        Return ufsiglaField
      End Get
      Set(ByVal value As eUF())
        ufsiglaField = value
      End Set
    End Property
    Partial Public Class WebServicesUF
      Private cUFField As String
      Private ProducaoField As WebServicesUFAmbiente
      Private HomologacaoField As WebServicesUFAmbiente
      Public Property cUF() As String
        Get
          Return cUFField
        End Get
        Set(ByVal value As String)
          cUFField = value
        End Set
      End Property
      Public Property Producao() As WebServicesUFAmbiente
        Get
          Return ProducaoField
        End Get
        Set(ByVal value As WebServicesUFAmbiente)
          ProducaoField = value
        End Set
      End Property
      Public Property Homologacao() As WebServicesUFAmbiente
        Get
          Return HomologacaoField
        End Get
        Set(ByVal value As WebServicesUFAmbiente)
          HomologacaoField = value
        End Set
      End Property
      Partial Public Class WebServicesUFAmbiente
        Private CTeRecepcaoField As String
        Private CTeRetRecepcaoField As String
        Private CTeCancelamentoField As String
        Private CTeInutilizacaoField As String
        Private CTeConsultaProtocoloField As String
        Private CTeStatusServicoField As String
        Public Property CTeRecepcao() As String
          Get
            Return CTeRecepcaoField
          End Get
          Set(ByVal value As String)
            CTeRecepcaoField = value
          End Set
        End Property
        Public Property CTeRetRecepcao() As String
          Get
            Return CTeRetRecepcaoField
          End Get
          Set(ByVal value As String)
            CTeRetRecepcaoField = value
          End Set
        End Property
        Public Property CTeCancelamento() As String
          Get
            Return CTeCancelamentoField
          End Get
          Set(ByVal value As String)
            CTeCancelamentoField = value
          End Set
        End Property
        Public Property CTeInutilizacao() As String
          Get
            Return CTeInutilizacaoField
          End Get
          Set(ByVal value As String)
            CTeInutilizacaoField = value
          End Set
        End Property
        Public Property CTeConsultaProtocolo() As String
          Get
            Return CTeConsultaProtocoloField
          End Get
          Set(ByVal value As String)
            CTeConsultaProtocoloField = value
          End Set
        End Property
        Public Property CTeStatusServico() As String
          Get
            Return CTeStatusServicoField
          End Get
          Set(ByVal value As String)
            CTeStatusServicoField = value
          End Set
        End Property

      End Class
    End Class
    Sub New()
      If list Is Nothing AndAlso Not loading Then _
      Me.Load("\ctews.xml")
    End Sub

    Private Sub Load(ByVal fromFile As String)
      'Dim ns As New XmlSerializerNamespaces
      'ns.Add("", "http://www.portalfisca.inf.br/CTe")
      CTe.Functions.InitCTEWSXML()
      Dim xs As New XmlSerializer(GetType(CTeWebServices))
      Dim fs As New IO.MemoryStream(IO.File.ReadAllBytes(fromFile))
      loading = True
      list = xs.Deserialize(fs)
      ufField = list.ufField
      ufsiglaField = list.ufsiglaField
      loading = False
      fs.Close()
      fs.Flush()
      CTe.Functions.DeinitCTEWSXML()
    End Sub
    Private Shared Function GetUFItem(ByVal cUF As Integer) As WebServicesUF
      For Each item As WebServicesUF In list.UF
        With item
          If Not IsNumeric(.cUF) Then Continue For
          If cUF = .cUF Then Return item
        End With
      Next
      Return Nothing
    End Function
    Public Shared Function GetCodUF(ByVal UF As String) As Integer
      Try
        Return [Enum].Parse(GetType(eUF), UF, True)
      Catch ex As Exception
        Return Nothing
      End Try
    End Function
    Public Shared Function GetCTeRecepcaoURL(ByVal cUF As Integer, ByVal Ambiente As Integer) As String
      If [Enum].IsDefined(GetType(eUF), cUF) Then
        Dim url As String = ""
        Dim item As WebServicesUF = GetUFItem(cUF)
        If Not item Is Nothing Then
          Select Case Ambiente
            Case 1
              Return item.Producao.CTeRecepcao
            Case 2
              Return item.Homologacao.CTeRecepcao
          End Select
        End If
        Return url
      End If
      Return Nothing
    End Function
    Public Shared Function GetCTeRecepcaoURL(ByVal UF As String, ByVal Ambiente As Integer) As String
      If IsNumeric(UF) Then Return GetCTeRecepcaoURL(CInt(UF), Ambiente)
      Return GetCTeRecepcaoURL([Enum].Parse(GetType(eUF), UF, True), Ambiente)
    End Function
    Public Shared Function GetCTeRetRecepcaoURL(ByVal cUF As Integer, ByVal Ambiente As Integer) As String
      If [Enum].IsDefined(GetType(eUF), cUF) Then
        Dim url As String = ""
        Dim item As WebServicesUF = GetUFItem(cUF)
        If Not item Is Nothing Then
          Select Case Ambiente
            Case 1
              Return item.Producao.CTeRetRecepcao
            Case 2
              Return item.Homologacao.CTeRetRecepcao
          End Select
        End If
        Return url
      End If
      Return Nothing
    End Function
    Public Shared Function GetCTeRetRecepcaoURL(ByVal UF As String, ByVal Ambiente As Integer) As String
      If IsNumeric(UF) Then Return GetCTeRetRecepcaoURL(CInt(UF), Ambiente)
      Return GetCTeRetRecepcaoURL([Enum].Parse(GetType(eUF), UF, True), Ambiente)
    End Function
    Public Shared Function GetCTeCancelamentoURL(ByVal cUF As Integer, ByVal Ambiente As Integer) As String
      If [Enum].IsDefined(GetType(eUF), cUF) Then
        Dim url As String = ""
        Dim item As WebServicesUF = GetUFItem(cUF)
        If Not item Is Nothing Then
          Select Case Ambiente
            Case 1
              Return item.Producao.CTeCancelamento
            Case 2
              Return item.Homologacao.CTeCancelamento
          End Select
        End If
        Return url
      End If
      Return Nothing
    End Function
    Public Shared Function GetCTeCancelamentoURL(ByVal UF As String, ByVal Ambiente As Integer) As String
      If IsNumeric(UF) Then Return GetCTeCancelamentoURL(CInt(UF), Ambiente)
      Return GetCTeCancelamentoURL([Enum].Parse(GetType(eUF), UF, True), Ambiente)
    End Function
    Public Shared Function GetCTeInutilizacaoURL(ByVal cUF As Integer, ByVal Ambiente As Integer) As String
      If [Enum].IsDefined(GetType(eUF), cUF) Then
        Dim url As String = ""
        Dim item As WebServicesUF = GetUFItem(cUF)
        If Not item Is Nothing Then
          Select Case Ambiente
            Case 1
              Return item.Producao.CTeInutilizacao
            Case 2
              Return item.Homologacao.CTeInutilizacao
          End Select
        End If
        Return url
      End If
      Return Nothing
    End Function
    Public Shared Function GetCTeInutilizacaoURL(ByVal UF As String, ByVal Ambiente As Integer) As String
      If IsNumeric(UF) Then Return GetCTeInutilizacaoURL(CInt(UF), Ambiente)
      Return GetCTeInutilizacaoURL([Enum].Parse(GetType(eUF), UF, True), Ambiente)
    End Function
    Public Shared Function GetCTeConsultaProtocoloURL(ByVal cUF As Integer, ByVal Ambiente As Integer) As String
      If [Enum].IsDefined(GetType(eUF), cUF) Then
        Dim url As String = ""
        Dim item As WebServicesUF = GetUFItem(cUF)
        If Not item Is Nothing Then
          Select Case Ambiente
            Case 1
              Return item.Producao.CTeConsultaProtocolo
            Case 2
              Return item.Homologacao.CTeConsultaProtocolo
          End Select
        End If
        Return url
      End If
      Return Nothing
    End Function
    Public Shared Function GetCTeConsultaProtocoloURL(ByVal UF As String, ByVal Ambiente As Integer) As String
      If IsNumeric(UF) Then Return GetCTeConsultaProtocoloURL(CInt(UF), Ambiente)
      Return GetCTeConsultaProtocoloURL([Enum].Parse(GetType(eUF), UF, True), Ambiente)
    End Function
    Public Shared Function GetCTeStatusServicoURL(ByVal cUF As Integer, ByVal Ambiente As Integer) As String
      If [Enum].IsDefined(GetType(eUF), cUF) Then
        Dim url As String = ""
        Dim item As WebServicesUF = GetUFItem(cUF)
        If Not item Is Nothing Then
          Select Case Ambiente
            Case 1
              Return item.Producao.CTeStatusServico
            Case 2
              Return item.Homologacao.CTeStatusServico
          End Select
        End If
        Return url
      End If
      Return Nothing
    End Function
    Public Shared Function GetCTeStatusServicoURL(ByVal UF As String, ByVal Ambiente As Integer) As String
      If IsNumeric(UF) Then Return GetCTeStatusServicoURL(CInt(UF), Ambiente)
      Return GetCTeStatusServicoURL([Enum].Parse(GetType(eUF), UF, True), Ambiente)
    End Function
  End Class

#Region "cteRecepcao"

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053"), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Web.Services.WebServiceBindingAttribute(Name:="CteRecepcaoSoap12", [Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteRecepcao")> _
  Partial Public Class CteRecepcao
    Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

    Private cteCabecMsgValueField As CteRecepcao.cteCabecMsg

    Private cteRecepcaoLoteOperationCompleted As System.Threading.SendOrPostCallback

    Private useDefaultCredentialsSetExplicitly As Boolean

    '''<remarks/>
    Public Sub New(ByVal cUF As Integer, ByVal Ambiente As Integer)
      MyBase.New()
      Me.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12
      Me.Url = CTe.WebServices.CTeWebServices.GetCTeRecepcaoURL(cuf, ambiente) 'Global.ctelib.My.MySettings.Default.ctelib_cteRecepcao_CteRecepcao
      If (Me.IsLocalFileSystemWebService(Me.Url) = True) Then
        Me.UseDefaultCredentials = True
        Me.useDefaultCredentialsSetExplicitly = False
      Else
        Me.useDefaultCredentialsSetExplicitly = True
      End If
      Me.cteCabecMsgValueField = New CteRecepcao.cteCabecMsg
      Me.cteCabecMsgValue.cUF = cUF
      Me.cteCabecMsgValue.versaoDados = "1.00"
    End Sub

    Public Property cteCabecMsgValue() As CteRecepcao.cteCabecMsg
      Get
        Return Me.cteCabecMsgValueField
      End Get
      Set(ByVal value As CteRecepcao.cteCabecMsg)
        Me.cteCabecMsgValueField = value
      End Set
    End Property

    Public Shadows Property Url() As String
      Get
        Return MyBase.Url
      End Get
      Set(ByVal value As String)
        If (((Me.IsLocalFileSystemWebService(MyBase.Url) = True) _
                    AndAlso (Me.useDefaultCredentialsSetExplicitly = False)) _
                    AndAlso (Me.IsLocalFileSystemWebService(value) = False)) Then
          MyBase.UseDefaultCredentials = False
        End If
        MyBase.Url = value
      End Set
    End Property

    Public Shadows Property UseDefaultCredentials() As Boolean
      Get
        Return MyBase.UseDefaultCredentials
      End Get
      Set(ByVal value As Boolean)
        MyBase.UseDefaultCredentials = value
        Me.useDefaultCredentialsSetExplicitly = True
      End Set
    End Property

    '''<remarks/>
    Public Event cteRecepcaoLoteCompleted As cteRecepcaoLoteCompletedEventHandler

    '''<remarks/>
    <System.Web.Services.Protocols.SoapHeaderAttribute("cteCabecMsgValue", Direction:=System.Web.Services.Protocols.SoapHeaderDirection.InOut), _
     System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/cte/wsdl/CteRecepcao/cteRecepcaoLote", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Bare)> _
    Public Function cteRecepcaoLote(<System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteRecepcao")> ByVal cteDadosMsg As System.Xml.XmlNode) As <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteRecepcao")> System.Xml.XmlNode
      Dim results() As Object = Me.Invoke("cteRecepcaoLote", New Object() {cteDadosMsg})
      Return CType(results(0), System.Xml.XmlNode)
    End Function

    '''<remarks/>
    Public Overloads Sub cteRecepcaoLoteAsync(ByVal cteDadosMsg As System.Xml.XmlNode)
      Me.cteRecepcaoLoteAsync(cteDadosMsg, Nothing)
    End Sub

    '''<remarks/>
    Public Overloads Sub cteRecepcaoLoteAsync(ByVal cteDadosMsg As System.Xml.XmlNode, ByVal userState As Object)
      If (Me.cteRecepcaoLoteOperationCompleted Is Nothing) Then
        Me.cteRecepcaoLoteOperationCompleted = AddressOf Me.OncteRecepcaoLoteOperationCompleted
      End If
      Me.InvokeAsync("cteRecepcaoLote", New Object() {cteDadosMsg}, Me.cteRecepcaoLoteOperationCompleted, userState)
    End Sub

    Private Sub OncteRecepcaoLoteOperationCompleted(ByVal arg As Object)
      If (Not (Me.cteRecepcaoLoteCompletedEvent) Is Nothing) Then
        Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
        RaiseEvent cteRecepcaoLoteCompleted(Me, New cteRecepcaoLoteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
      End If
    End Sub

    '''<remarks/>
    Public Shadows Sub CancelAsync(ByVal userState As Object)
      MyBase.CancelAsync(userState)
    End Sub

    Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
      If ((url Is Nothing) _
                  OrElse (url Is String.Empty)) Then
        Return False
      End If
      Dim wsUri As System.Uri = New System.Uri(url)
      If ((wsUri.Port >= 1024) _
                  AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
        Return True
      End If
      Return False
    End Function
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3082"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteRecepcao"), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteRecepcao", IsNullable:=False)> _
    Partial Public Class cteCabecMsg
      Inherits System.Web.Services.Protocols.SoapHeader

      Private cUFField As String

      Private versaoDadosField As String

      Private anyAttrField() As System.Xml.XmlAttribute

      '''<remarks/>
      Public Property cUF() As String
        Get
          Return Me.cUFField
        End Get
        Set(ByVal value As String)
          Me.cUFField = value
        End Set
      End Property

      '''<remarks/>
      Public Property versaoDados() As String
        Get
          Return Me.versaoDadosField
        End Get
        Set(ByVal value As String)
          Me.versaoDadosField = value
        End Set
      End Property

      '''<remarks/>
      <System.Xml.Serialization.XmlAnyAttributeAttribute()> _
      Public Property AnyAttr() As System.Xml.XmlAttribute()
        Get
          Return Me.anyAttrField
        End Get
        Set(ByVal value As System.Xml.XmlAttribute())
          Me.anyAttrField = value
        End Set
      End Property
    End Class
  End Class



  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")> _
  Public Delegate Sub cteRecepcaoLoteCompletedEventHandler(ByVal sender As Object, ByVal e As cteRecepcaoLoteCompletedEventArgs)

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053"), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code")> _
  Partial Public Class cteRecepcaoLoteCompletedEventArgs
    Inherits System.ComponentModel.AsyncCompletedEventArgs

    Private results() As Object

    Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
      MyBase.New(exception, cancelled, userState)
      Me.results = results
    End Sub

    '''<remarks/>
    Public ReadOnly Property Result() As System.Xml.XmlNode
      Get
        Me.RaiseExceptionIfNecessary()
        Return CType(Me.results(0), System.Xml.XmlNode)
      End Get
    End Property
  End Class

#End Region
#Region "cteRetRecepcao"
  <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053"), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Web.Services.WebServiceBindingAttribute(Name:="CteRetRecepcaoSoap12", [Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteRetRecepcao")> _
    Partial Public Class CteRetRecepcao
    Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

    Private cteCabecMsgValueField As CteRetRecepcao.cteCabecMsg

    Private cteRetRecepcaoOperationCompleted As System.Threading.SendOrPostCallback

    Private useDefaultCredentialsSetExplicitly As Boolean

    '''<remarks/>
    Public Sub New(ByVal cUF As Integer, ByVal Ambiente As Integer)
      MyBase.New()
      Me.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12
      Me.Url = ctelib.CTe.WebServices.CTeWebServices.GetCTeRetRecepcaoURL(cuf, ambiente) 'Global.ctelib.My.MySettings.Default.ctelib_cteRetRecepcao_CteRetRecepcao
      If (Me.IsLocalFileSystemWebService(Me.Url) = True) Then
        Me.UseDefaultCredentials = True
        Me.useDefaultCredentialsSetExplicitly = False
      Else
        Me.useDefaultCredentialsSetExplicitly = True
      End If
      Me.cteCabecMsgValueField = New CteRetRecepcao.cteCabecMsg
      Me.cteCabecMsgValue.cUF = cUF
      Me.cteCabecMsgValueField.versaoDados = "1.00"
    End Sub

    Public Property cteCabecMsgValue() As CteRetRecepcao.cteCabecMsg
      Get
        Return Me.cteCabecMsgValueField
      End Get
      Set(ByVal value As CteRetRecepcao.cteCabecMsg)
        Me.cteCabecMsgValueField = value
      End Set
    End Property

    Public Shadows Property Url() As String
      Get
        Return MyBase.Url
      End Get
      Set(ByVal value As String)
        If (((Me.IsLocalFileSystemWebService(MyBase.Url) = True) _
                    AndAlso (Me.useDefaultCredentialsSetExplicitly = False)) _
                    AndAlso (Me.IsLocalFileSystemWebService(value) = False)) Then
          MyBase.UseDefaultCredentials = False
        End If
        MyBase.Url = value
      End Set
    End Property

    Public Shadows Property UseDefaultCredentials() As Boolean
      Get
        Return MyBase.UseDefaultCredentials
      End Get
      Set(ByVal value As Boolean)
        MyBase.UseDefaultCredentials = value
        Me.useDefaultCredentialsSetExplicitly = True
      End Set
    End Property

    '''<remarks/>
    Public Event cteRetRecepcaoCompleted As cteRetRecepcaoCompletedEventHandler

    '''<remarks/>
    <System.Web.Services.Protocols.SoapHeaderAttribute("cteCabecMsgValue", Direction:=System.Web.Services.Protocols.SoapHeaderDirection.InOut), _
     System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/cte/wsdl/CteRetRecepcao/cteRetRecepcao", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Bare)> _
    Public Function cteRetRecepcao(<System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteRetRecepcao")> ByVal cteDadosMsg As System.Xml.XmlNode) As <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteRetRecepcao")> System.Xml.XmlNode
      Dim results() As Object = Me.Invoke("cteRetRecepcao", New Object() {cteDadosMsg})
      Return CType(results(0), System.Xml.XmlNode)
    End Function

    '''<remarks/>
    Public Overloads Sub cteRetRecepcaoAsync(ByVal cteDadosMsg As System.Xml.XmlNode)
      Me.cteRetRecepcaoAsync(cteDadosMsg, Nothing)
    End Sub

    '''<remarks/>
    Public Overloads Sub cteRetRecepcaoAsync(ByVal cteDadosMsg As System.Xml.XmlNode, ByVal userState As Object)
      If (Me.cteRetRecepcaoOperationCompleted Is Nothing) Then
        Me.cteRetRecepcaoOperationCompleted = AddressOf Me.OncteRetRecepcaoOperationCompleted
      End If
      Me.InvokeAsync("cteRetRecepcao", New Object() {cteDadosMsg}, Me.cteRetRecepcaoOperationCompleted, userState)
    End Sub

    Private Sub OncteRetRecepcaoOperationCompleted(ByVal arg As Object)
      If (Not (Me.cteRetRecepcaoCompletedEvent) Is Nothing) Then
        Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
        RaiseEvent cteRetRecepcaoCompleted(Me, New cteRetRecepcaoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
      End If
    End Sub

    '''<remarks/>
    Public Shadows Sub CancelAsync(ByVal userState As Object)
      MyBase.CancelAsync(userState)
    End Sub

    Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
      If ((url Is Nothing) _
                  OrElse (url Is String.Empty)) Then
        Return False
      End If
      Dim wsUri As System.Uri = New System.Uri(url)
      If ((wsUri.Port >= 1024) _
                  AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
        Return True
      End If
      Return False
    End Function
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3082"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteRetRecepcao"), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteRetRecepcao", IsNullable:=False)> _
    Partial Public Class cteCabecMsg
      Inherits System.Web.Services.Protocols.SoapHeader

      Private cUFField As String

      Private versaoDadosField As String

      Private anyAttrField() As System.Xml.XmlAttribute

      '''<remarks/>
      Public Property cUF() As String
        Get
          Return Me.cUFField
        End Get
        Set(ByVal value As String)
          Me.cUFField = value
        End Set
      End Property

      '''<remarks/>
      Public Property versaoDados() As String
        Get
          Return Me.versaoDadosField
        End Get
        Set(ByVal value As String)
          Me.versaoDadosField = value
        End Set
      End Property

      '''<remarks/>
      <System.Xml.Serialization.XmlAnyAttributeAttribute()> _
      Public Property AnyAttr() As System.Xml.XmlAttribute()
        Get
          Return Me.anyAttrField
        End Get
        Set(ByVal value As System.Xml.XmlAttribute())
          Me.anyAttrField = value
        End Set
      End Property
    End Class
  End Class

  

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")> _
  Public Delegate Sub cteRetRecepcaoCompletedEventHandler(ByVal sender As Object, ByVal e As cteRetRecepcaoCompletedEventArgs)

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053"), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code")> _
  Partial Public Class cteRetRecepcaoCompletedEventArgs
    Inherits System.ComponentModel.AsyncCompletedEventArgs

    Private results() As Object

    Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
      MyBase.New(exception, cancelled, userState)
      Me.results = results
    End Sub

    '''<remarks/>
    Public ReadOnly Property Result() As System.Xml.XmlNode
      Get
        Me.RaiseExceptionIfNecessary()
        Return CType(Me.results(0), System.Xml.XmlNode)
      End Get
    End Property
  End Class

#End Region
#Region "cteConsulta"

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053"), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Web.Services.WebServiceBindingAttribute(Name:="CteConsultaSoap12", [Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteConsulta")> _
  Partial Public Class CteConsulta
    Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

    Private cteCabecMsgValueField As CteConsulta.cteCabecMsg

    Private cteConsultaCTOperationCompleted As System.Threading.SendOrPostCallback

    Private useDefaultCredentialsSetExplicitly As Boolean

    '''<remarks/>
    Public Sub New(ByVal cUF As Integer, ByVal Ambiente As Integer)
      MyBase.New()
      Me.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12
      Me.Url = CTe.WebServices.CTeWebServices.GetCTeConsultaProtocoloURL(cUF, Ambiente) 'Global.ctelib.My.MySettings.Default.ctelib_cteConsulta_CteConsulta
      If (Me.IsLocalFileSystemWebService(Me.Url) = True) Then
        Me.UseDefaultCredentials = True
        Me.useDefaultCredentialsSetExplicitly = False
      Else
        Me.useDefaultCredentialsSetExplicitly = True
      End If
      Me.cteCabecMsgValueField = New CteConsulta.cteCabecMsg
      Me.cteCabecMsgValue.cUF = cUF
      Me.cteCabecMsgValue.versaoDados = "1.00"
    End Sub

    Public Property cteCabecMsgValue() As CteConsulta.cteCabecMsg
      Get
        Return Me.cteCabecMsgValueField
      End Get
      Set(ByVal value As CteConsulta.cteCabecMsg)
        Me.cteCabecMsgValueField = value
      End Set
    End Property

    Public Shadows Property Url() As String
      Get
        Return MyBase.Url
      End Get
      Set(ByVal value As String)
        If (((Me.IsLocalFileSystemWebService(MyBase.Url) = True) _
                    AndAlso (Me.useDefaultCredentialsSetExplicitly = False)) _
                    AndAlso (Me.IsLocalFileSystemWebService(value) = False)) Then
          MyBase.UseDefaultCredentials = False
        End If
        MyBase.Url = value
      End Set
    End Property

    Public Shadows Property UseDefaultCredentials() As Boolean
      Get
        Return MyBase.UseDefaultCredentials
      End Get
      Set(ByVal value As Boolean)
        MyBase.UseDefaultCredentials = value
        Me.useDefaultCredentialsSetExplicitly = True
      End Set
    End Property

    '''<remarks/>
    Public Event cteConsultaCTCompleted As cteConsultaCTCompletedEventHandler

    '''<remarks/>
    <System.Web.Services.Protocols.SoapHeaderAttribute("cteCabecMsgValue", Direction:=System.Web.Services.Protocols.SoapHeaderDirection.InOut), _
     System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/cte/wsdl/CteConsulta/cteConsultaCT", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Bare)> _
    Public Function cteConsultaCT(<System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteConsulta")> ByVal cteDadosMsg As System.Xml.XmlNode) As <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteConsulta")> System.Xml.XmlNode
      Dim results() As Object = Me.Invoke("cteConsultaCT", New Object() {cteDadosMsg})
      Return CType(results(0), System.Xml.XmlNode)
    End Function

    '''<remarks/>
    Public Overloads Sub cteConsultaCTAsync(ByVal cteDadosMsg As System.Xml.XmlNode)
      Me.cteConsultaCTAsync(cteDadosMsg, Nothing)
    End Sub

    '''<remarks/>
    Public Overloads Sub cteConsultaCTAsync(ByVal cteDadosMsg As System.Xml.XmlNode, ByVal userState As Object)
      If (Me.cteConsultaCTOperationCompleted Is Nothing) Then
        Me.cteConsultaCTOperationCompleted = AddressOf Me.OncteConsultaCTOperationCompleted
      End If
      Me.InvokeAsync("cteConsultaCT", New Object() {cteDadosMsg}, Me.cteConsultaCTOperationCompleted, userState)
    End Sub

    Private Sub OncteConsultaCTOperationCompleted(ByVal arg As Object)
      If (Not (Me.cteConsultaCTCompletedEvent) Is Nothing) Then
        Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
        RaiseEvent cteConsultaCTCompleted(Me, New cteConsultaCTCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
      End If
    End Sub

    '''<remarks/>
    Public Shadows Sub CancelAsync(ByVal userState As Object)
      MyBase.CancelAsync(userState)
    End Sub

    Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
      If ((url Is Nothing) _
                  OrElse (url Is String.Empty)) Then
        Return False
      End If
      Dim wsUri As System.Uri = New System.Uri(url)
      If ((wsUri.Port >= 1024) _
                  AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
        Return True
      End If
      Return False
    End Function
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3082"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteConsulta"), _
   System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteConsulta", IsNullable:=False)> _
  Partial Public Class cteCabecMsg
      Inherits System.Web.Services.Protocols.SoapHeader

      Private cUFField As String

      Private versaoDadosField As String

      Private anyAttrField() As System.Xml.XmlAttribute

      '''<remarks/>
      Public Property cUF() As String
        Get
          Return Me.cUFField
        End Get
        Set(ByVal value As String)
          Me.cUFField = value
        End Set
      End Property

      '''<remarks/>
      Public Property versaoDados() As String
        Get
          Return Me.versaoDadosField
        End Get
        Set(ByVal value As String)
          Me.versaoDadosField = value
        End Set
      End Property

      '''<remarks/>
      <System.Xml.Serialization.XmlAnyAttributeAttribute()> _
      Public Property AnyAttr() As System.Xml.XmlAttribute()
        Get
          Return Me.anyAttrField
        End Get
        Set(ByVal value As System.Xml.XmlAttribute())
          Me.anyAttrField = value
        End Set
      End Property
    End Class
  End Class


  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")> _
  Public Delegate Sub cteConsultaCTCompletedEventHandler(ByVal sender As Object, ByVal e As cteConsultaCTCompletedEventArgs)

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053"), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code")> _
  Partial Public Class cteConsultaCTCompletedEventArgs
    Inherits System.ComponentModel.AsyncCompletedEventArgs

    Private results() As Object

    Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
      MyBase.New(exception, cancelled, userState)
      Me.results = results
    End Sub

    '''<remarks/>
    Public ReadOnly Property Result() As System.Xml.XmlNode
      Get
        Me.RaiseExceptionIfNecessary()
        Return CType(Me.results(0), System.Xml.XmlNode)
      End Get
    End Property
  End Class

#End Region
#Region "cteStatusServico"

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053"), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Web.Services.WebServiceBindingAttribute(Name:="CteStatusServicoSoap12", [Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteStatusServico")> _
  Partial Public Class CteStatusServico
    Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

    Private cteCabecMsgValueField As CteStatusServico.cteCabecMsg

    Private cteStatusServicoCTOperationCompleted As System.Threading.SendOrPostCallback

    Private useDefaultCredentialsSetExplicitly As Boolean

    '''<remarks/>
    Public Sub New(ByVal cUF As Integer, ByVal Ambiente As Integer)
      MyBase.New()
      Me.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12
      Me.Url = CTe.WebServices.CTeWebServices.GetCTeStatusServicoURL(cuf, ambiente) 'Global.ctelib.My.MySettings.Default.ctelib_cteStatusServico_CteStatusServico
      If (Me.IsLocalFileSystemWebService(Me.Url) = True) Then
        Me.UseDefaultCredentials = True
        Me.useDefaultCredentialsSetExplicitly = False
      Else
        Me.useDefaultCredentialsSetExplicitly = True
      End If
      Me.cteCabecMsgValueField = New CteStatusServico.cteCabecMsg
      Me.cteCabecMsgValue.cUF = cUF
      Me.cteCabecMsgValue.versaoDados = "1.00"
    End Sub

    Public Property cteCabecMsgValue() As CteStatusServico.cteCabecMsg
      Get
        Return Me.cteCabecMsgValueField
      End Get
      Set(ByVal value As CteStatusServico.cteCabecMsg)
        Me.cteCabecMsgValueField = value
      End Set
    End Property

    Public Shadows Property Url() As String
      Get
        Return MyBase.Url
      End Get
      Set(ByVal value As String)
        If (((Me.IsLocalFileSystemWebService(MyBase.Url) = True) _
                    AndAlso (Me.useDefaultCredentialsSetExplicitly = False)) _
                    AndAlso (Me.IsLocalFileSystemWebService(value) = False)) Then
          MyBase.UseDefaultCredentials = False
        End If
        MyBase.Url = value
      End Set
    End Property

    Public Shadows Property UseDefaultCredentials() As Boolean
      Get
        Return MyBase.UseDefaultCredentials
      End Get
      Set(ByVal value As Boolean)
        MyBase.UseDefaultCredentials = value
        Me.useDefaultCredentialsSetExplicitly = True
      End Set
    End Property

    '''<remarks/>
    Public Event cteStatusServicoCTCompleted As cteStatusServicoCTCompletedEventHandler

    '''<remarks/>
    <System.Web.Services.Protocols.SoapHeaderAttribute("cteCabecMsgValue", Direction:=System.Web.Services.Protocols.SoapHeaderDirection.InOut), _
     System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/cte/wsdl/CteStatusServico/cteStatusServicoCT", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Bare)> _
    Public Function cteStatusServicoCT(<System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteStatusServico")> ByVal cteDadosMsg As System.Xml.XmlNode) As <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteStatusServico")> System.Xml.XmlNode
      Dim results() As Object = Me.Invoke("cteStatusServicoCT", New Object() {cteDadosMsg})
      Return CType(results(0), System.Xml.XmlNode)
    End Function

    '''<remarks/>
    Public Overloads Sub cteStatusServicoCTAsync(ByVal cteDadosMsg As System.Xml.XmlNode)
      Me.cteStatusServicoCTAsync(cteDadosMsg, Nothing)
    End Sub

    '''<remarks/>
    Public Overloads Sub cteStatusServicoCTAsync(ByVal cteDadosMsg As System.Xml.XmlNode, ByVal userState As Object)
      If (Me.cteStatusServicoCTOperationCompleted Is Nothing) Then
        Me.cteStatusServicoCTOperationCompleted = AddressOf Me.OncteStatusServicoCTOperationCompleted
      End If
      Me.InvokeAsync("cteStatusServicoCT", New Object() {cteDadosMsg}, Me.cteStatusServicoCTOperationCompleted, userState)
    End Sub

    Private Sub OncteStatusServicoCTOperationCompleted(ByVal arg As Object)
      If (Not (Me.cteStatusServicoCTCompletedEvent) Is Nothing) Then
        Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
        RaiseEvent cteStatusServicoCTCompleted(Me, New cteStatusServicoCTCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
      End If
    End Sub

    '''<remarks/>
    Public Shadows Sub CancelAsync(ByVal userState As Object)
      MyBase.CancelAsync(userState)
    End Sub

    Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
      If ((url Is Nothing) _
                  OrElse (url Is String.Empty)) Then
        Return False
      End If
      Dim wsUri As System.Uri = New System.Uri(url)
      If ((wsUri.Port >= 1024) _
                  AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
        Return True
      End If
      Return False
    End Function
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3082"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteStatusServico"), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteStatusServico", IsNullable:=False)> _
    Partial Public Class cteCabecMsg
      Inherits System.Web.Services.Protocols.SoapHeader

      Private cUFField As String

      Private versaoDadosField As String

      Private anyAttrField() As System.Xml.XmlAttribute

      '''<remarks/>
      Public Property cUF() As String
        Get
          Return Me.cUFField
        End Get
        Set(ByVal value As String)
          Me.cUFField = value
        End Set
      End Property

      '''<remarks/>
      Public Property versaoDados() As String
        Get
          Return Me.versaoDadosField
        End Get
        Set(ByVal value As String)
          Me.versaoDadosField = value
        End Set
      End Property

      '''<remarks/>
      <System.Xml.Serialization.XmlAnyAttributeAttribute()> _
      Public Property AnyAttr() As System.Xml.XmlAttribute()
        Get
          Return Me.anyAttrField
        End Get
        Set(ByVal value As System.Xml.XmlAttribute())
          Me.anyAttrField = value
        End Set
      End Property
    End Class
  End Class

  

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")> _
  Public Delegate Sub cteStatusServicoCTCompletedEventHandler(ByVal sender As Object, ByVal e As cteStatusServicoCTCompletedEventArgs)

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053"), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code")> _
  Partial Public Class cteStatusServicoCTCompletedEventArgs
    Inherits System.ComponentModel.AsyncCompletedEventArgs

    Private results() As Object

    Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
      MyBase.New(exception, cancelled, userState)
      Me.results = results
    End Sub

    '''<remarks/>
    Public ReadOnly Property Result() As System.Xml.XmlNode
      Get
        Me.RaiseExceptionIfNecessary()
        Return CType(Me.results(0), System.Xml.XmlNode)
      End Get
    End Property
  End Class

#End Region
#Region "cteCancelamento"
  '------------------------------------------------------------------------------
  ' <auto-generated>
  '     This code was generated by a tool.
  '     Runtime Version:2.0.50727.3625
  '
  '     Changes to this file may cause incorrect behavior and will be lost if
  '     the code is regenerated.
  ' </auto-generated>
  '------------------------------------------------------------------------------





  '
  'This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.3625.
  '


  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053"), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Web.Services.WebServiceBindingAttribute(Name:="CteCancelamentoSoap12", [Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteCancelamento")> _
  Partial Public Class CteCancelamento
    Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

    Private cteCabecMsgValueField As CteCancelamento.cteCabecMsg

    Private cteCancelamentoCTOperationCompleted As System.Threading.SendOrPostCallback

    Private useDefaultCredentialsSetExplicitly As Boolean

    '''<remarks/>
    Public Sub New(ByVal cUF As Integer, ByVal Ambiente As Integer)
      MyBase.New()
      Me.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12
      Me.Url = CTeWebServices.GetCTeCancelamentoURL(cUF, Ambiente) 'Global.ctelib.My.MySettings.Default.ctelib_cteCancelamento_CteCancelamento
      If (Me.IsLocalFileSystemWebService(Me.Url) = True) Then
        Me.UseDefaultCredentials = True
        Me.useDefaultCredentialsSetExplicitly = False
      Else
        Me.useDefaultCredentialsSetExplicitly = True
      End If
      Me.cteCabecMsgValueField = New CteCancelamento.cteCabecMsg
      Me.cteCabecMsgValue.cUF = cUF
      Me.cteCabecMsgValue.versaoDados = "1.00"
    End Sub

    Public Property cteCabecMsgValue() As CteCancelamento.cteCabecMsg
      Get
        Return Me.cteCabecMsgValueField
      End Get
      Set(ByVal value As CteCancelamento.cteCabecMsg)
        Me.cteCabecMsgValueField = value
      End Set
    End Property

    Public Shadows Property Url() As String
      Get
        Return MyBase.Url
      End Get
      Set(ByVal value As String)
        If (((Me.IsLocalFileSystemWebService(MyBase.Url) = True) _
                    AndAlso (Me.useDefaultCredentialsSetExplicitly = False)) _
                    AndAlso (Me.IsLocalFileSystemWebService(value) = False)) Then
          MyBase.UseDefaultCredentials = False
        End If
        MyBase.Url = value
      End Set
    End Property

    Public Shadows Property UseDefaultCredentials() As Boolean
      Get
        Return MyBase.UseDefaultCredentials
      End Get
      Set(ByVal value As Boolean)
        MyBase.UseDefaultCredentials = value
        Me.useDefaultCredentialsSetExplicitly = True
      End Set
    End Property

    '''<remarks/>
    Public Event cteCancelamentoCTCompleted As cteCancelamentoCTCompletedEventHandler

    '''<remarks/>
    <System.Web.Services.Protocols.SoapHeaderAttribute("cteCabecMsgValue", Direction:=System.Web.Services.Protocols.SoapHeaderDirection.InOut), _
     System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/cte/wsdl/CteCancelamento/cteCancelamentoCT", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Bare)> _
    Public Function cteCancelamentoCT(<System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteCancelamento")> ByVal cteDadosMsg As System.Xml.XmlNode) As <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteCancelamento")> System.Xml.XmlNode
      Dim results() As Object = Me.Invoke("cteCancelamentoCT", New Object() {cteDadosMsg})
      Return CType(results(0), System.Xml.XmlNode)
    End Function

    '''<remarks/>
    Public Overloads Sub cteCancelamentoCTAsync(ByVal cteDadosMsg As System.Xml.XmlNode)
      Me.cteCancelamentoCTAsync(cteDadosMsg, Nothing)
    End Sub

    '''<remarks/>
    Public Overloads Sub cteCancelamentoCTAsync(ByVal cteDadosMsg As System.Xml.XmlNode, ByVal userState As Object)
      If (Me.cteCancelamentoCTOperationCompleted Is Nothing) Then
        Me.cteCancelamentoCTOperationCompleted = AddressOf Me.OncteCancelamentoCTOperationCompleted
      End If
      Me.InvokeAsync("cteCancelamentoCT", New Object() {cteDadosMsg}, Me.cteCancelamentoCTOperationCompleted, userState)
    End Sub

    Private Sub OncteCancelamentoCTOperationCompleted(ByVal arg As Object)
      If (Not (Me.cteCancelamentoCTCompletedEvent) Is Nothing) Then
        Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
        RaiseEvent cteCancelamentoCTCompleted(Me, New cteCancelamentoCTCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
      End If
    End Sub

    '''<remarks/>
    Public Shadows Sub CancelAsync(ByVal userState As Object)
      MyBase.CancelAsync(userState)
    End Sub

    Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
      If ((url Is Nothing) _
                  OrElse (url Is String.Empty)) Then
        Return False
      End If
      Dim wsUri As System.Uri = New System.Uri(url)
      If ((wsUri.Port >= 1024) _
                  AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
        Return True
      End If
      Return False
    End Function
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3082"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteCancelamento"), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteCancelamento", IsNullable:=False)> _
    Partial Public Class cteCabecMsg
      Inherits System.Web.Services.Protocols.SoapHeader

      Private cUFField As String

      Private versaoDadosField As String

      Private anyAttrField() As System.Xml.XmlAttribute

      '''<remarks/>
      Public Property cUF() As String
        Get
          Return Me.cUFField
        End Get
        Set(ByVal value As String)
          Me.cUFField = value
        End Set
      End Property

      '''<remarks/>
      Public Property versaoDados() As String
        Get
          Return Me.versaoDadosField
        End Get
        Set(ByVal value As String)
          Me.versaoDadosField = value
        End Set
      End Property

      '''<remarks/>
      <System.Xml.Serialization.XmlAnyAttributeAttribute()> _
      Public Property AnyAttr() As System.Xml.XmlAttribute()
        Get
          Return Me.anyAttrField
        End Get
        Set(ByVal value As System.Xml.XmlAttribute())
          Me.anyAttrField = value
        End Set
      End Property
    End Class
  End Class

 

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")> _
  Public Delegate Sub cteCancelamentoCTCompletedEventHandler(ByVal sender As Object, ByVal e As cteCancelamentoCTCompletedEventArgs)

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053"), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code")> _
  Partial Public Class cteCancelamentoCTCompletedEventArgs
    Inherits System.ComponentModel.AsyncCompletedEventArgs

    Private results() As Object

    Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
      MyBase.New(exception, cancelled, userState)
      Me.results = results
    End Sub

    '''<remarks/>
    Public ReadOnly Property Result() As System.Xml.XmlNode
      Get
        Me.RaiseExceptionIfNecessary()
        Return CType(Me.results(0), System.Xml.XmlNode)
      End Get
    End Property
  End Class
#End Region
#Region "cteInutilizacao"

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053"), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Web.Services.WebServiceBindingAttribute(Name:="CteInutilizacaoSoap12", [Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteInutilizacao")> _
  Partial Public Class CteInutilizacao
    Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

    Private cteCabecMsgValueField As CteInutilizacao.cteCabecMsg

    Private cteInutilizacaoCTOperationCompleted As System.Threading.SendOrPostCallback

    Private useDefaultCredentialsSetExplicitly As Boolean

    '''<remarks/>
    Public Sub New(ByVal cUF As Integer, ByVal Ambiente As Integer)
      MyBase.New()
      Me.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12
      Me.Url = CTe.WebServices.CTeWebServices.GetCTeInutilizacaoURL(cuf, ambiente) 'Global.ctelib.My.MySettings.Default.ctelib_cteInutilizacao_CteInutilizacao
      If (Me.IsLocalFileSystemWebService(Me.Url) = True) Then
        Me.UseDefaultCredentials = True
        Me.useDefaultCredentialsSetExplicitly = False
      Else
        Me.useDefaultCredentialsSetExplicitly = True
      End If
      Me.cteCabecMsgValueField = New CteInutilizacao.cteCabecMsg
      Me.cteCabecMsgValue.cUF = cUF
      Me.cteCabecMsgValue.versaoDados = "1.00"
    End Sub

    Public Property cteCabecMsgValue() As CteInutilizacao.cteCabecMsg
      Get
        Return Me.cteCabecMsgValueField
      End Get
      Set(ByVal value As CteInutilizacao.cteCabecMsg)
        Me.cteCabecMsgValueField = value
      End Set
    End Property

    Public Shadows Property Url() As String
      Get
        Return MyBase.Url
      End Get
      Set(ByVal value As String)
        If (((Me.IsLocalFileSystemWebService(MyBase.Url) = True) _
                    AndAlso (Me.useDefaultCredentialsSetExplicitly = False)) _
                    AndAlso (Me.IsLocalFileSystemWebService(value) = False)) Then
          MyBase.UseDefaultCredentials = False
        End If
        MyBase.Url = value
      End Set
    End Property

    Public Shadows Property UseDefaultCredentials() As Boolean
      Get
        Return MyBase.UseDefaultCredentials
      End Get
      Set(ByVal value As Boolean)
        MyBase.UseDefaultCredentials = value
        Me.useDefaultCredentialsSetExplicitly = True
      End Set
    End Property

    '''<remarks/>
    Public Event cteInutilizacaoCTCompleted As cteInutilizacaoCTCompletedEventHandler

    '''<remarks/>
    <System.Web.Services.Protocols.SoapHeaderAttribute("cteCabecMsgValue", Direction:=System.Web.Services.Protocols.SoapHeaderDirection.InOut), _
     System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/cte/wsdl/CteInutilizacao/cteInutilizacaoCT", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Bare)> _
    Public Function cteInutilizacaoCT(<System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteInutilizacao")> ByVal cteDadosMsg As System.Xml.XmlNode) As <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteInutilizacao")> System.Xml.XmlNode
      Dim results() As Object = Me.Invoke("cteInutilizacaoCT", New Object() {cteDadosMsg})
      Return CType(results(0), System.Xml.XmlNode)
    End Function

    '''<remarks/>
    Public Overloads Sub cteInutilizacaoCTAsync(ByVal cteDadosMsg As System.Xml.XmlNode)
      Me.cteInutilizacaoCTAsync(cteDadosMsg, Nothing)
    End Sub

    '''<remarks/>
    Public Overloads Sub cteInutilizacaoCTAsync(ByVal cteDadosMsg As System.Xml.XmlNode, ByVal userState As Object)
      If (Me.cteInutilizacaoCTOperationCompleted Is Nothing) Then
        Me.cteInutilizacaoCTOperationCompleted = AddressOf Me.OncteInutilizacaoCTOperationCompleted
      End If
      Me.InvokeAsync("cteInutilizacaoCT", New Object() {cteDadosMsg}, Me.cteInutilizacaoCTOperationCompleted, userState)
    End Sub

    Private Sub OncteInutilizacaoCTOperationCompleted(ByVal arg As Object)
      If (Not (Me.cteInutilizacaoCTCompletedEvent) Is Nothing) Then
        Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
        RaiseEvent cteInutilizacaoCTCompleted(Me, New cteInutilizacaoCTCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
      End If
    End Sub

    '''<remarks/>
    Public Shadows Sub CancelAsync(ByVal userState As Object)
      MyBase.CancelAsync(userState)
    End Sub

    Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
      If ((url Is Nothing) _
                  OrElse (url Is String.Empty)) Then
        Return False
      End If
      Dim wsUri As System.Uri = New System.Uri(url)
      If ((wsUri.Port >= 1024) _
                  AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
        Return True
      End If
      Return False
    End Function

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3082"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteInutilizacao"), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte/wsdl/CteInutilizacao", IsNullable:=False)> _
    Partial Public Class cteCabecMsg
      Inherits System.Web.Services.Protocols.SoapHeader

      Private cUFField As String

      Private versaoDadosField As String

      Private anyAttrField() As System.Xml.XmlAttribute

      '''<remarks/>
      Public Property cUF() As String
        Get
          Return Me.cUFField
        End Get
        Set(ByVal value As String)
          Me.cUFField = value
        End Set
      End Property

      '''<remarks/>
      Public Property versaoDados() As String
        Get
          Return Me.versaoDadosField
        End Get
        Set(ByVal value As String)
          Me.versaoDadosField = value
        End Set
      End Property

      '''<remarks/>
      <System.Xml.Serialization.XmlAnyAttributeAttribute()> _
      Public Property AnyAttr() As System.Xml.XmlAttribute()
        Get
          Return Me.anyAttrField
        End Get
        Set(ByVal value As System.Xml.XmlAttribute())
          Me.anyAttrField = value
        End Set
      End Property
    End Class
  End Class


  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")> _
  Public Delegate Sub cteInutilizacaoCTCompletedEventHandler(ByVal sender As Object, ByVal e As cteInutilizacaoCTCompletedEventArgs)

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053"), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code")> _
  Partial Public Class cteInutilizacaoCTCompletedEventArgs
    Inherits System.ComponentModel.AsyncCompletedEventArgs

    Private results() As Object

    Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
      MyBase.New(exception, cancelled, userState)
      Me.results = results
    End Sub

    '''<remarks/>
    Public ReadOnly Property Result() As System.Xml.XmlNode
      Get
        Me.RaiseExceptionIfNecessary()
        Return CType(Me.results(0), System.Xml.XmlNode)
      End Get
    End Property
  End Class

#End Region
End Namespace
