Imports System.Web.services
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
      Me.Load("CTews.xml")
    End Sub

    Private Sub Load(ByVal fromFile As String)
      'Dim ns As New XmlSerializerNamespaces
      'ns.Add("", "http://www.portalfisca.inf.br/CTe")
      CTe.Functions.InitCTeWSXML()
      Dim xs As New XmlSerializer(GetType(CTeWebServices))
      Dim fs As New IO.MemoryStream(IO.File.ReadAllBytes(fromFile))
      loading = True
      list = xs.Deserialize(fs)
      ufField = list.ufField
      ufsiglaField = list.ufsiglaField
      loading = False
      fs.Close()
      fs.Flush()
      CTe.Functions.DeinitCTeWSXML()
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
End Namespace
