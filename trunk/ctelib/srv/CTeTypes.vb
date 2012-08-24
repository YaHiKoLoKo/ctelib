Option Strict Off
Option Explicit On
Imports System.Xml
Imports System.Xml.Serialization
Namespace CTe.Types
  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte"), _
   System.Xml.Serialization.XmlRootAttribute("CTe", [Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
  Partial Public Class TCTe

    Private infCteField As TCTeInfCte

    Private signatureField As SignatureType

    '''<remarks/>
    Public Property infCte() As TCTeInfCte
      Get
        Return Me.infCteField
      End Get
      Set(ByVal value As TCTeInfCte)
        Me.infCteField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Public Property Signature() As SignatureType
      Get
        Return Me.signatureField
      End Get
      Set(ByVal value As SignatureType)
        Me.signatureField = value
      End Set
    End Property

    Public Function ToFile(ByVal onFolder As String) As Boolean
      Try
        Dim fname As String = GetFileName()
        Dim fi As New IO.FileInfo(fname)
        If fi.Exists Then fi.Delete()
        IO.File.WriteAllBytes(fname, ToBytes)
        IO.File.Move(fname, (onFolder & IO.Path.DirectorySeparatorChar & fname).Replace(New String(IO.Path.DirectorySeparatorChar, 2), IO.Path.DirectorySeparatorChar))
        Return True
      Catch ex As Exception
        Return False
      End Try
    End Function
    Public Function GetFileName() As String
      Return Me.infCte.Id.Substring(3) & ".xml"
    End Function
    Public Function ToBytes() As Byte()
      Return System.Text.Encoding.UTF8.GetBytes(ToString)
    End Function

    Public Function ToXMLNode() As Xml.XmlNode
      Dim xDoc As New Xml.XmlDocument
      xDoc.LoadXml(ToString)
      Return xDoc.DocumentElement
    End Function
    Public Overrides Function ToString() As String
      Dim xs As New XmlSerializer(Me.GetType)
      Dim xmlns As New XmlSerializerNamespaces
      xmlns.Add("", "http://www.portalfiscal.inf.br/cte")
      Dim sw As New IO.StringWriter()
      'Dim ms As New IO.MemoryStream
      Dim tmp As String = IO.Path.GetTempFileName
      Dim sw2 As New IO.StreamWriter(tmp, False, System.Text.Encoding.UTF8)
      xs.Serialize(sw2, Me, xmlns)
      Dim xmlDocument As New XmlDocument
      sw2.Close()
      xmlDocument.Load(tmp)
      Dim r As String = xmlDocument.DocumentElement.OuterXml
      IO.File.Delete(tmp)
      Return r
      'xs.Deserialize
      Return MyBase.ToString()
    End Function

  End Class


  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCte

    Private ideField As TCTeInfCteIde

    Private complField As TCTeInfCteCompl

    Private emitField As TCTeInfCteEmit

    Private remField As TCTeInfCteRem

    Private expedField As TCTeInfCteExped

    Private recebField As TCTeInfCteReceb

    Private destField As TCTeInfCteDest

    Private vPrestField As TCTeInfCteVPrest

    Private impField As TCTeInfCteImp

    Private itemsField() As Object

    Private versaoField As String

    Private idField As String

    '''<remarks/>
    Public Property ide() As TCTeInfCteIde
      Get
        Return Me.ideField
      End Get
      Set(ByVal value As TCTeInfCteIde)
        Me.ideField = value
      End Set
    End Property

    '''<remarks/>
    Public Property compl() As TCTeInfCteCompl
      Get
        Return Me.complField
      End Get
      Set(ByVal value As TCTeInfCteCompl)
        Me.complField = value
      End Set
    End Property

    '''<remarks/>
    Public Property emit() As TCTeInfCteEmit
      Get
        Return Me.emitField
      End Get
      Set(ByVal value As TCTeInfCteEmit)
        Me.emitField = value
      End Set
    End Property

    '''<remarks/>
    Public Property [rem]() As TCTeInfCteRem
      Get
        Return Me.remField
      End Get
      Set(ByVal value As TCTeInfCteRem)
        Me.remField = value
      End Set
    End Property

    '''<remarks/>
    Public Property exped() As TCTeInfCteExped
      Get
        Return Me.expedField
      End Get
      Set(ByVal value As TCTeInfCteExped)
        Me.expedField = value
      End Set
    End Property

    '''<remarks/>
    Public Property receb() As TCTeInfCteReceb
      Get
        Return Me.recebField
      End Get
      Set(ByVal value As TCTeInfCteReceb)
        Me.recebField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dest() As TCTeInfCteDest
      Get
        Return Me.destField
      End Get
      Set(ByVal value As TCTeInfCteDest)
        Me.destField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vPrest() As TCTeInfCteVPrest
      Get
        Return Me.vPrestField
      End Get
      Set(ByVal value As TCTeInfCteVPrest)
        Me.vPrestField = value
      End Set
    End Property

    '''<remarks/>
    Public Property imp() As TCTeInfCteImp
      Get
        Return Me.impField
      End Get
      Set(ByVal value As TCTeInfCteImp)
        Me.impField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("infCTeNorm", GetType(TCTeInfCteInfCTeNorm)), _
     System.Xml.Serialization.XmlElementAttribute("infCteAnu", GetType(TCTeInfCteInfCteAnu)), _
     System.Xml.Serialization.XmlElementAttribute("infCteComp", GetType(TCTeInfCteInfCteComp))> _
    Public Property Items() As Object()
      Get
        Return Me.itemsField
      End Get
      Set(ByVal value As Object())
        Me.itemsField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versao() As String
      Get
        Return Me.versaoField
      End Get
      Set(ByVal value As String)
        Me.versaoField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")> _
    Public Property Id() As String
      Get
        Return Me.idField
      End Get
      Set(ByVal value As String)
        Me.idField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteIde

    Private cUFField As String

    Private cCTField As String

    Private cFOPField As String

    Private natOpField As String

    Private forPagField As String

    Private modField As String

    Private serieField As String

    Private nCTField As String

    Private dhEmiField As String

    Private tpImpField As String

    Private tpEmisField As String

    Private cDVField As String

    Private tpAmbField As String

    Private tpCTeField As String

    Private procEmiField As String

    Private verProcField As String

    Private refCTEField As String

    Private cMunEnvField As String

    Private xMunEnvField As String

    Private uFEnvField As String

    Private modalField As String

    Private tpServField As String

    Private cMunIniField As String

    Private xMunIniField As String

    Private uFIniField As String

    Private cMunFimField As String

    Private xMunFimField As String

    Private uFFimField As String

    Private retiraField As String

    Private xDetRetiraField As String

    Private itemField As Object

    Private dhContField As String

    Private xJustField As String

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
    Public Property cCT() As String
      Get
        Return Me.cCTField
      End Get
      Set(ByVal value As String)
        Me.cCTField = value
      End Set
    End Property

    '''<remarks/>
    Public Property CFOP() As String
      Get
        Return Me.cFOPField
      End Get
      Set(ByVal value As String)
        Me.cFOPField = value
      End Set
    End Property

    '''<remarks/>
    Public Property natOp() As String
      Get
        Return Me.natOpField
      End Get
      Set(ByVal value As String)
        Me.natOpField = value
      End Set
    End Property

    '''<remarks/>
    Public Property forPag() As String
      Get
        Return Me.forPagField
      End Get
      Set(ByVal value As String)
        Me.forPagField = value
      End Set
    End Property

    '''<remarks/>
    Public Property [mod]() As String
      Get
        Return Me.modField
      End Get
      Set(ByVal value As String)
        Me.modField = value
      End Set
    End Property

    '''<remarks/>
    Public Property serie() As String
      Get
        Return Me.serieField
      End Get
      Set(ByVal value As String)
        Me.serieField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nCT() As String
      Get
        Return Me.nCTField
      End Get
      Set(ByVal value As String)
        Me.nCTField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dhEmi() As String
      Get
        Return Me.dhEmiField
      End Get
      Set(ByVal value As String)
        Me.dhEmiField = value
      End Set
    End Property

    '''<remarks/>
    Public Property tpImp() As String
      Get
        Return Me.tpImpField
      End Get
      Set(ByVal value As String)
        Me.tpImpField = value
      End Set
    End Property

    '''<remarks/>
    Public Property tpEmis() As String
      Get
        Return Me.tpEmisField
      End Get
      Set(ByVal value As String)
        Me.tpEmisField = value
      End Set
    End Property

    '''<remarks/>
    Public Property cDV() As String
      Get
        Return Me.cDVField
      End Get
      Set(ByVal value As String)
        Me.cDVField = value
      End Set
    End Property

    '''<remarks/>
    Public Property tpAmb() As String
      Get
        Return Me.tpAmbField
      End Get
      Set(ByVal value As String)
        Me.tpAmbField = value
      End Set
    End Property

    '''<remarks/>
    Public Property tpCTe() As String
      Get
        Return Me.tpCTeField
      End Get
      Set(ByVal value As String)
        Me.tpCTeField = value
      End Set
    End Property

    '''<remarks/>
    Public Property procEmi() As String
      Get
        Return Me.procEmiField
      End Get
      Set(ByVal value As String)
        Me.procEmiField = value
      End Set
    End Property

    '''<remarks/>
    Public Property verProc() As String
      Get
        Return Me.verProcField
      End Get
      Set(ByVal value As String)
        Me.verProcField = value
      End Set
    End Property

    '''<remarks/>
    Public Property refCTE() As String
      Get
        Return Me.refCTEField
      End Get
      Set(ByVal value As String)
        Me.refCTEField = value
      End Set
    End Property

    '''<remarks/>
    Public Property cMunEnv() As String
      Get
        Return Me.cMunEnvField
      End Get
      Set(ByVal value As String)
        Me.cMunEnvField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xMunEnv() As String
      Get
        Return Me.xMunEnvField
      End Get
      Set(ByVal value As String)
        Me.xMunEnvField = value
      End Set
    End Property

    '''<remarks/>
    Public Property UFEnv() As String
      Get
        Return Me.uFEnvField
      End Get
      Set(ByVal value As String)
        Me.uFEnvField = value
      End Set
    End Property

    '''<remarks/>
    Public Property modal() As String
      Get
        Return Me.modalField
      End Get
      Set(ByVal value As String)
        Me.modalField = value
      End Set
    End Property

    '''<remarks/>
    Public Property tpServ() As String
      Get
        Return Me.tpServField
      End Get
      Set(ByVal value As String)
        Me.tpServField = value
      End Set
    End Property

    '''<remarks/>
    Public Property cMunIni() As String
      Get
        Return Me.cMunIniField
      End Get
      Set(ByVal value As String)
        Me.cMunIniField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xMunIni() As String
      Get
        Return Me.xMunIniField
      End Get
      Set(ByVal value As String)
        Me.xMunIniField = value
      End Set
    End Property

    '''<remarks/>
    Public Property UFIni() As String
      Get
        Return Me.uFIniField
      End Get
      Set(ByVal value As String)
        Me.uFIniField = value
      End Set
    End Property

    '''<remarks/>
    Public Property cMunFim() As String
      Get
        Return Me.cMunFimField
      End Get
      Set(ByVal value As String)
        Me.cMunFimField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xMunFim() As String
      Get
        Return Me.xMunFimField
      End Get
      Set(ByVal value As String)
        Me.xMunFimField = value
      End Set
    End Property

    '''<remarks/>
    Public Property UFFim() As String
      Get
        Return Me.uFFimField
      End Get
      Set(ByVal value As String)
        Me.uFFimField = value
      End Set
    End Property

    '''<remarks/>
    Public Property retira() As String
      Get
        Return Me.retiraField
      End Get
      Set(ByVal value As String)
        Me.retiraField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xDetRetira() As String
      Get
        Return Me.xDetRetiraField
      End Get
      Set(ByVal value As String)
        Me.xDetRetiraField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("toma03", GetType(TCTeInfCteIdeToma03)), _
     System.Xml.Serialization.XmlElementAttribute("toma4", GetType(TCTeInfCteIdeToma4))> _
    Public Property Item() As Object
      Get
        Return Me.itemField
      End Get
      Set(ByVal value As Object)
        Me.itemField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dhCont() As String
      Get
        Return Me.dhContField
      End Get
      Set(ByVal value As String)
        Me.dhContField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xJust() As String
      Get
        Return Me.xJustField
      End Get
      Set(ByVal value As String)
        Me.xJustField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TCodUfIBGE

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("11")> _
    Item11

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("12")> _
    Item12

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("13")> _
    Item13

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("14")> _
    Item14

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("15")> _
    Item15

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("16")> _
    Item16

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("17")> _
    Item17

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("21")> _
    Item21

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("22")> _
    Item22

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("23")> _
    Item23

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("24")> _
    Item24

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("25")> _
    Item25

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("26")> _
    Item26

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("27")> _
    Item27

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("28")> _
    Item28

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("29")> _
    Item29

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("31")> _
    Item31

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("32")> _
    Item32

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("33")> _
    Item33

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("35")> _
    Item35

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("41")> _
    Item41

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("42")> _
    Item42

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("43")> _
    Item43

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("50")> _
    Item50

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("51")> _
    Item51

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("52")> _
    Item52

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("53")> _
    Item53
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TforPag

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("0")> _
    Item0

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")> _
    Item1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("2")> _
    Item2
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TModCT

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("57")> _
    Item57
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TCTeInfCteIdeTpImp

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")> _
    Item1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("2")> _
    Item2
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TCTeInfCteIdeTpEmis

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")> _
    Item1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("5")> _
    Item5

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("7")> _
    Item7

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("8")> _
    Item8
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TFinCTe

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("0")> _
    Item0

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")> _
    Item1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("2")> _
    Item2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("3")> _
    Item3
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TProcEmi

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("0")> _
    Item0

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")> _
    Item1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("2")> _
    Item2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("3")> _
    Item3
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TModTransp

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("01")> _
    Item01

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("02")> _
    Item02

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("03")> _
    Item03

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("04")> _
    Item04

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("05")> _
    Item05
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TCTeInfCteIdeTpServ

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("0")> _
    Item0

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")> _
    Item1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("2")> _
    Item2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("3")> _
    Item3
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TCTeInfCteIdeRetira

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("0")> _
    Item0

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")> _
    Item1
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteIdeToma03

    Private tomaField As String

    '''<remarks/>
    Public Property toma() As String
      Get
        Return Me.tomaField
      End Get
      Set(ByVal value As String)
        Me.tomaField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TCTeInfCteIdeToma03Toma

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("0")> _
    Item0

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")> _
    Item1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("2")> _
    Item2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("3")> _
    Item3
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteIdeToma4

    Private tomaField As String

    Private itemField As String

    Private itemElementNameField As ItemChoiceType1

    Private ieField As String

    Private xNomeField As String

    Private xFantField As String

    Private foneField As String

    Private enderTomaField As TEndereco

    Private emailField As String

    '''<remarks/>
    Public Property toma() As String
      Get
        Return Me.tomaField
      End Get
      Set(ByVal value As String)
        Me.tomaField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("CNPJ", GetType(String)), _
     System.Xml.Serialization.XmlElementAttribute("CPF", GetType(String)), _
     System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")> _
    Public Property Item() As String
      Get
        Return Me.itemField
      End Get
      Set(ByVal value As String)
        Me.itemField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property ItemElementName() As ItemChoiceType1
      Get
        Return Me.itemElementNameField
      End Get
      Set(ByVal value As ItemChoiceType1)
        Me.itemElementNameField = value
      End Set
    End Property

    '''<remarks/>
    Public Property IE() As String
      Get
        Return Me.ieField
      End Get
      Set(ByVal value As String)
        Me.ieField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xNome() As String
      Get
        Return Me.xNomeField
      End Get
      Set(ByVal value As String)
        Me.xNomeField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xFant() As String
      Get
        Return Me.xFantField
      End Get
      Set(ByVal value As String)
        Me.xFantField = value
      End Set
    End Property

    '''<remarks/>
    Public Property fone() As String
      Get
        Return Me.foneField
      End Get
      Set(ByVal value As String)
        Me.foneField = value
      End Set
    End Property

    '''<remarks/>
    Public Property enderToma() As TEndereco
      Get
        Return Me.enderTomaField
      End Get
      Set(ByVal value As TEndereco)
        Me.enderTomaField = value
      End Set
    End Property

    '''<remarks/>
    Public Property email() As String
      Get
        Return Me.emailField
      End Get
      Set(ByVal value As String)
        Me.emailField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TCTeInfCteIdeToma4Toma

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("4")> _
    Item4
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte", IncludeInSchema:=False)> _
  Public Enum ItemChoiceType1

    '''<remarks/>
    CNPJ

    '''<remarks/>
    CPF
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TEndereco

    Private xLgrField As String

    Private nroField As String

    Private xCplField As String

    Private xBairroField As String

    Private cMunField As String

    Private xMunField As String

    Private cEPField As String

    Private ufField As String

    Private cPaisField As String

    Private xPaisField As String

    '''<remarks/>
    Public Property xLgr() As String
      Get
        Return Me.xLgrField
      End Get
      Set(ByVal value As String)
        Me.xLgrField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nro() As String
      Get
        Return Me.nroField
      End Get
      Set(ByVal value As String)
        Me.nroField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xCpl() As String
      Get
        Return Me.xCplField
      End Get
      Set(ByVal value As String)
        Me.xCplField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xBairro() As String
      Get
        Return Me.xBairroField
      End Get
      Set(ByVal value As String)
        Me.xBairroField = value
      End Set
    End Property

    '''<remarks/>
    Public Property cMun() As String
      Get
        Return Me.cMunField
      End Get
      Set(ByVal value As String)
        Me.cMunField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xMun() As String
      Get
        Return Me.xMunField
      End Get
      Set(ByVal value As String)
        Me.xMunField = value
      End Set
    End Property

    '''<remarks/>
    Public Property CEP() As String
      Get
        Return Me.cEPField
      End Get
      Set(ByVal value As String)
        Me.cEPField = value
      End Set
    End Property

    '''<remarks/>
    Public Property UF() As String
      Get
        Return Me.ufField
      End Get
      Set(ByVal value As String)
        Me.ufField = value
      End Set
    End Property

    '''<remarks/>
    Public Property cPais() As String
      Get
        Return Me.cPaisField
      End Get
      Set(ByVal value As String)
        Me.cPaisField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xPais() As String
      Get
        Return Me.xPaisField
      End Get
      Set(ByVal value As String)
        Me.xPaisField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteCompl

    Private xCaracAdField As String

    Private xCaracSerField As String

    Private xEmiField As String

    Private fluxoField As TCTeInfCteComplFluxo

    Private entregaField As TCTeInfCteComplEntrega

    Private origCalcField As String

    Private destCalcField As String

    Private xObsField As String

    Private obsContField() As TCTeInfCteComplObsCont

    Private obsFiscoField() As TCTeInfCteComplObsFisco

    '''<remarks/>
    Public Property xCaracAd() As String
      Get
        Return Me.xCaracAdField
      End Get
      Set(ByVal value As String)
        Me.xCaracAdField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xCaracSer() As String
      Get
        Return Me.xCaracSerField
      End Get
      Set(ByVal value As String)
        Me.xCaracSerField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xEmi() As String
      Get
        Return Me.xEmiField
      End Get
      Set(ByVal value As String)
        Me.xEmiField = value
      End Set
    End Property

    '''<remarks/>
    Public Property fluxo() As TCTeInfCteComplFluxo
      Get
        Return Me.fluxoField
      End Get
      Set(ByVal value As TCTeInfCteComplFluxo)
        Me.fluxoField = value
      End Set
    End Property

    '''<remarks/>
    Public Property Entrega() As TCTeInfCteComplEntrega
      Get
        Return Me.entregaField
      End Get
      Set(ByVal value As TCTeInfCteComplEntrega)
        Me.entregaField = value
      End Set
    End Property

    '''<remarks/>
    Public Property origCalc() As String
      Get
        Return Me.origCalcField
      End Get
      Set(ByVal value As String)
        Me.origCalcField = value
      End Set
    End Property

    '''<remarks/>
    Public Property destCalc() As String
      Get
        Return Me.destCalcField
      End Get
      Set(ByVal value As String)
        Me.destCalcField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xObs() As String
      Get
        Return Me.xObsField
      End Get
      Set(ByVal value As String)
        Me.xObsField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("ObsCont")> _
    Public Property ObsCont() As TCTeInfCteComplObsCont()
      Get
        Return Me.obsContField
      End Get
      Set(ByVal value As TCTeInfCteComplObsCont())
        Me.obsContField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("ObsFisco")> _
    Public Property ObsFisco() As TCTeInfCteComplObsFisco()
      Get
        Return Me.obsFiscoField
      End Get
      Set(ByVal value As TCTeInfCteComplObsFisco())
        Me.obsFiscoField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteComplFluxo

    Private xOrigField As String

    Private passField() As TCTeInfCteComplFluxoPass

    Private xDestField As String

    Private xRotaField As String

    '''<remarks/>
    Public Property xOrig() As String
      Get
        Return Me.xOrigField
      End Get
      Set(ByVal value As String)
        Me.xOrigField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("pass")> _
    Public Property pass() As TCTeInfCteComplFluxoPass()
      Get
        Return Me.passField
      End Get
      Set(ByVal value As TCTeInfCteComplFluxoPass())
        Me.passField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xDest() As String
      Get
        Return Me.xDestField
      End Get
      Set(ByVal value As String)
        Me.xDestField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xRota() As String
      Get
        Return Me.xRotaField
      End Get
      Set(ByVal value As String)
        Me.xRotaField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteComplFluxoPass

    Private xPassField As String

    '''<remarks/>
    Public Property xPass() As String
      Get
        Return Me.xPassField
      End Get
      Set(ByVal value As String)
        Me.xPassField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteComplEntrega

    Private itemField As Object

    Private item1Field As Object

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("comData", GetType(TCTeInfCteComplEntregaComData)), _
     System.Xml.Serialization.XmlElementAttribute("noPeriodo", GetType(TCTeInfCteComplEntregaNoPeriodo)), _
     System.Xml.Serialization.XmlElementAttribute("semData", GetType(TCTeInfCteComplEntregaSemData))> _
    Public Property Item() As Object
      Get
        Return Me.itemField
      End Get
      Set(ByVal value As Object)
        Me.itemField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("comHora", GetType(TCTeInfCteComplEntregaComHora)), _
     System.Xml.Serialization.XmlElementAttribute("noInter", GetType(TCTeInfCteComplEntregaNoInter)), _
     System.Xml.Serialization.XmlElementAttribute("semHora", GetType(TCTeInfCteComplEntregaSemHora))> _
    Public Property Item1() As Object
      Get
        Return Me.item1Field
      End Get
      Set(ByVal value As Object)
        Me.item1Field = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteComplEntregaComData

    Private tpPerField As TCTeInfCteComplEntregaComDataTpPer

    Private dProgField As String

    '''<remarks/>
    Public Property tpPer() As TCTeInfCteComplEntregaComDataTpPer
      Get
        Return Me.tpPerField
      End Get
      Set(ByVal value As TCTeInfCteComplEntregaComDataTpPer)
        Me.tpPerField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dProg() As String
      Get
        Return Me.dProgField
      End Get
      Set(ByVal value As String)
        Me.dProgField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TCTeInfCteComplEntregaComDataTpPer

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")> _
    Item1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("2")> _
    Item2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("3")> _
    Item3
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteComplEntregaNoPeriodo

    Private tpPerField As TCTeInfCteComplEntregaNoPeriodoTpPer

    Private dIniField As String

    Private dFimField As String

    '''<remarks/>
    Public Property tpPer() As TCTeInfCteComplEntregaNoPeriodoTpPer
      Get
        Return Me.tpPerField
      End Get
      Set(ByVal value As TCTeInfCteComplEntregaNoPeriodoTpPer)
        Me.tpPerField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dIni() As String
      Get
        Return Me.dIniField
      End Get
      Set(ByVal value As String)
        Me.dIniField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dFim() As String
      Get
        Return Me.dFimField
      End Get
      Set(ByVal value As String)
        Me.dFimField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TCTeInfCteComplEntregaNoPeriodoTpPer

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("4")> _
    Item4
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteComplEntregaSemData

    Private tpPerField As TCTeInfCteComplEntregaSemDataTpPer

    '''<remarks/>
    Public Property tpPer() As TCTeInfCteComplEntregaSemDataTpPer
      Get
        Return Me.tpPerField
      End Get
      Set(ByVal value As TCTeInfCteComplEntregaSemDataTpPer)
        Me.tpPerField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TCTeInfCteComplEntregaSemDataTpPer

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("0")> _
    Item0
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteComplEntregaComHora

    Private tpHorField As TCTeInfCteComplEntregaComHoraTpHor

    Private hProgField As String

    '''<remarks/>
    Public Property tpHor() As TCTeInfCteComplEntregaComHoraTpHor
      Get
        Return Me.tpHorField
      End Get
      Set(ByVal value As TCTeInfCteComplEntregaComHoraTpHor)
        Me.tpHorField = value
      End Set
    End Property

    '''<remarks/>
    Public Property hProg() As String
      Get
        Return Me.hProgField
      End Get
      Set(ByVal value As String)
        Me.hProgField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TCTeInfCteComplEntregaComHoraTpHor

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")> _
    Item1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("2")> _
    Item2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("3")> _
    Item3
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteComplEntregaNoInter

    Private tpHorField As TCTeInfCteComplEntregaNoInterTpHor

    Private hIniField As String

    Private hFimField As String

    '''<remarks/>
    Public Property tpHor() As TCTeInfCteComplEntregaNoInterTpHor
      Get
        Return Me.tpHorField
      End Get
      Set(ByVal value As TCTeInfCteComplEntregaNoInterTpHor)
        Me.tpHorField = value
      End Set
    End Property

    '''<remarks/>
    Public Property hIni() As String
      Get
        Return Me.hIniField
      End Get
      Set(ByVal value As String)
        Me.hIniField = value
      End Set
    End Property

    '''<remarks/>
    Public Property hFim() As String
      Get
        Return Me.hFimField
      End Get
      Set(ByVal value As String)
        Me.hFimField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TCTeInfCteComplEntregaNoInterTpHor

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("4")> _
    Item4
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteComplEntregaSemHora

    Private tpHorField As TCTeInfCteComplEntregaSemHoraTpHor

    '''<remarks/>
    Public Property tpHor() As TCTeInfCteComplEntregaSemHoraTpHor
      Get
        Return Me.tpHorField
      End Get
      Set(ByVal value As TCTeInfCteComplEntregaSemHoraTpHor)
        Me.tpHorField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TCTeInfCteComplEntregaSemHoraTpHor

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("0")> _
    Item0
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteComplObsCont

    Private xTextoField As String

    Private xCampoField As String

    '''<remarks/>
    Public Property xTexto() As String
      Get
        Return Me.xTextoField
      End Get
      Set(ByVal value As String)
        Me.xTextoField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property xCampo() As String
      Get
        Return Me.xCampoField
      End Get
      Set(ByVal value As String)
        Me.xCampoField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteComplObsFisco

    Private xTextoField As String

    Private xCampoField As String

    '''<remarks/>
    Public Property xTexto() As String
      Get
        Return Me.xTextoField
      End Get
      Set(ByVal value As String)
        Me.xTextoField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property xCampo() As String
      Get
        Return Me.xCampoField
      End Get
      Set(ByVal value As String)
        Me.xCampoField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteEmit

    Private cNPJField As String

    Private ieField As String

    Private xNomeField As String

    Private xFantField As String

    Private enderEmitField As TEndeEmi

    '''<remarks/>
    Public Property CNPJ() As String
      Get
        Return Me.cNPJField
      End Get
      Set(ByVal value As String)
        Me.cNPJField = value
      End Set
    End Property

    '''<remarks/>
    Public Property IE() As String
      Get
        Return Me.ieField
      End Get
      Set(ByVal value As String)
        Me.ieField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xNome() As String
      Get
        Return Me.xNomeField
      End Get
      Set(ByVal value As String)
        Me.xNomeField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xFant() As String
      Get
        Return Me.xFantField
      End Get
      Set(ByVal value As String)
        Me.xFantField = value
      End Set
    End Property

    '''<remarks/>
    Public Property enderEmit() As TEndeEmi
      Get
        Return Me.enderEmitField
      End Get
      Set(ByVal value As TEndeEmi)
        Me.enderEmitField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TEndeEmi

    Private xLgrField As String

    Private nroField As String

    Private xCplField As String

    Private xBairroField As String

    Private cMunField As String

    Private xMunField As String

    Private cEPField As String

    Private ufField As String

    Private foneField As String

    '''<remarks/>
    Public Property xLgr() As String
      Get
        Return Me.xLgrField
      End Get
      Set(ByVal value As String)
        Me.xLgrField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nro() As String
      Get
        Return Me.nroField
      End Get
      Set(ByVal value As String)
        Me.nroField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xCpl() As String
      Get
        Return Me.xCplField
      End Get
      Set(ByVal value As String)
        Me.xCplField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xBairro() As String
      Get
        Return Me.xBairroField
      End Get
      Set(ByVal value As String)
        Me.xBairroField = value
      End Set
    End Property

    '''<remarks/>
    Public Property cMun() As String
      Get
        Return Me.cMunField
      End Get
      Set(ByVal value As String)
        Me.cMunField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xMun() As String
      Get
        Return Me.xMunField
      End Get
      Set(ByVal value As String)
        Me.xMunField = value
      End Set
    End Property

    '''<remarks/>
    Public Property CEP() As String
      Get
        Return Me.cEPField
      End Get
      Set(ByVal value As String)
        Me.cEPField = value
      End Set
    End Property

    '''<remarks/>
    Public Property UF() As String
      Get
        Return Me.ufField
      End Get
      Set(ByVal value As String)
        Me.ufField = value
      End Set
    End Property

    '''<remarks/>
    Public Property fone() As String
      Get
        Return Me.foneField
      End Get
      Set(ByVal value As String)
        Me.foneField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TUF_sem_EX

    '''<remarks/>
    AC

    '''<remarks/>
    AL

    '''<remarks/>
    AM

    '''<remarks/>
    AP

    '''<remarks/>
    BA

    '''<remarks/>
    CE

    '''<remarks/>
    DF

    '''<remarks/>
    ES

    '''<remarks/>
    GO

    '''<remarks/>
    MA

    '''<remarks/>
    MG

    '''<remarks/>
    MS

    '''<remarks/>
    MT

    '''<remarks/>
    PA

    '''<remarks/>
    PB

    '''<remarks/>
    PE

    '''<remarks/>
    PI

    '''<remarks/>
    PR

    '''<remarks/>
    RJ

    '''<remarks/>
    RN

    '''<remarks/>
    RO

    '''<remarks/>
    RR

    '''<remarks/>
    RS

    '''<remarks/>
    SC

    '''<remarks/>
    SE

    '''<remarks/>
    SP

    '''<remarks/>
    [TO]
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteRem

    Private itemField As String

    Private itemElementNameField As ItemChoiceType2

    Private ieField As String

    Private xNomeField As String

    Private xFantField As String

    Private foneField As String

    Private enderRemeField As TEndereco

    Private emailField As String

    Private itemsField() As Object

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("CNPJ", GetType(String)), _
     System.Xml.Serialization.XmlElementAttribute("CPF", GetType(String)), _
     System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")> _
    Public Property Item() As String
      Get
        Return Me.itemField
      End Get
      Set(ByVal value As String)
        Me.itemField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property ItemElementName() As ItemChoiceType2
      Get
        Return Me.itemElementNameField
      End Get
      Set(ByVal value As ItemChoiceType2)
        Me.itemElementNameField = value
      End Set
    End Property

    '''<remarks/>
    Public Property IE() As String
      Get
        Return Me.ieField
      End Get
      Set(ByVal value As String)
        Me.ieField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xNome() As String
      Get
        Return Me.xNomeField
      End Get
      Set(ByVal value As String)
        Me.xNomeField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xFant() As String
      Get
        Return Me.xFantField
      End Get
      Set(ByVal value As String)
        Me.xFantField = value
      End Set
    End Property

    '''<remarks/>
    Public Property fone() As String
      Get
        Return Me.foneField
      End Get
      Set(ByVal value As String)
        Me.foneField = value
      End Set
    End Property

    '''<remarks/>
    Public Property enderReme() As TEndereco
      Get
        Return Me.enderRemeField
      End Get
      Set(ByVal value As TEndereco)
        Me.enderRemeField = value
      End Set
    End Property

    '''<remarks/>
    Public Property email() As String
      Get
        Return Me.emailField
      End Get
      Set(ByVal value As String)
        Me.emailField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("infNF", GetType(TCTeInfCteRemInfNF)), _
     System.Xml.Serialization.XmlElementAttribute("infNFe", GetType(TCTeInfCteRemInfNFe)), _
     System.Xml.Serialization.XmlElementAttribute("infOutros", GetType(TCTeInfCteRemInfOutros))> _
    Public Property Items() As Object()
      Get
        Return Me.itemsField
      End Get
      Set(ByVal value As Object())
        Me.itemsField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte", IncludeInSchema:=False)> _
  Public Enum ItemChoiceType2

    '''<remarks/>
    CNPJ

    '''<remarks/>
    CPF
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteRemInfNF

    Private nRomaField As String

    Private nPedField As String

    Private modField As String

    Private serieField As String

    Private nDocField As String

    Private dEmiField As String

    Private vBCField As String

    Private vICMSField As String

    Private vBCSTField As String

    Private vSTField As String

    Private vProdField As String

    Private vNFField As String

    Private nCFOPField As String

    Private nPesoField As String

    Private pINField As String

    Private locRetField As TEndReEnt

    '''<remarks/>
    Public Property nRoma() As String
      Get
        Return Me.nRomaField
      End Get
      Set(ByVal value As String)
        Me.nRomaField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nPed() As String
      Get
        Return Me.nPedField
      End Get
      Set(ByVal value As String)
        Me.nPedField = value
      End Set
    End Property

    '''<remarks/>
    Public Property [mod]() As String
      Get
        Return Me.modField
      End Get
      Set(ByVal value As String)
        Me.modField = value
      End Set
    End Property

    '''<remarks/>
    Public Property serie() As String
      Get
        Return Me.serieField
      End Get
      Set(ByVal value As String)
        Me.serieField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nDoc() As String
      Get
        Return Me.nDocField
      End Get
      Set(ByVal value As String)
        Me.nDocField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dEmi() As String
      Get
        Return Me.dEmiField
      End Get
      Set(ByVal value As String)
        Me.dEmiField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vBC() As String
      Get
        Return Me.vBCField
      End Get
      Set(ByVal value As String)
        Me.vBCField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vICMS() As String
      Get
        Return Me.vICMSField
      End Get
      Set(ByVal value As String)
        Me.vICMSField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vBCST() As String
      Get
        Return Me.vBCSTField
      End Get
      Set(ByVal value As String)
        Me.vBCSTField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vST() As String
      Get
        Return Me.vSTField
      End Get
      Set(ByVal value As String)
        Me.vSTField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vProd() As String
      Get
        Return Me.vProdField
      End Get
      Set(ByVal value As String)
        Me.vProdField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vNF() As String
      Get
        Return Me.vNFField
      End Get
      Set(ByVal value As String)
        Me.vNFField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nCFOP() As String
      Get
        Return Me.nCFOPField
      End Get
      Set(ByVal value As String)
        Me.nCFOPField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nPeso() As String
      Get
        Return Me.nPesoField
      End Get
      Set(ByVal value As String)
        Me.nPesoField = value
      End Set
    End Property

    '''<remarks/>
    Public Property PIN() As String
      Get
        Return Me.pINField
      End Get
      Set(ByVal value As String)
        Me.pINField = value
      End Set
    End Property

    '''<remarks/>
    Public Property locRet() As TEndReEnt
      Get
        Return Me.locRetField
      End Get
      Set(ByVal value As TEndReEnt)
        Me.locRetField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TModNF

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("01")> _
    Item01

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("04")> _
    Item04
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TEndReEnt

    Private itemField As String

    Private itemElementNameField As ItemChoiceType3

    Private xNomeField As String

    Private xLgrField As String

    Private nroField As String

    Private xCplField As String

    Private xBairroField As String

    Private cMunField As String

    Private xMunField As String

    Private ufField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("CNPJ", GetType(String)), _
     System.Xml.Serialization.XmlElementAttribute("CPF", GetType(String)), _
     System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")> _
    Public Property Item() As String
      Get
        Return Me.itemField
      End Get
      Set(ByVal value As String)
        Me.itemField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property ItemElementName() As ItemChoiceType3
      Get
        Return Me.itemElementNameField
      End Get
      Set(ByVal value As ItemChoiceType3)
        Me.itemElementNameField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xNome() As String
      Get
        Return Me.xNomeField
      End Get
      Set(ByVal value As String)
        Me.xNomeField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xLgr() As String
      Get
        Return Me.xLgrField
      End Get
      Set(ByVal value As String)
        Me.xLgrField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nro() As String
      Get
        Return Me.nroField
      End Get
      Set(ByVal value As String)
        Me.nroField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xCpl() As String
      Get
        Return Me.xCplField
      End Get
      Set(ByVal value As String)
        Me.xCplField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xBairro() As String
      Get
        Return Me.xBairroField
      End Get
      Set(ByVal value As String)
        Me.xBairroField = value
      End Set
    End Property

    '''<remarks/>
    Public Property cMun() As String
      Get
        Return Me.cMunField
      End Get
      Set(ByVal value As String)
        Me.cMunField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xMun() As String
      Get
        Return Me.xMunField
      End Get
      Set(ByVal value As String)
        Me.xMunField = value
      End Set
    End Property

    '''<remarks/>
    Public Property UF() As String
      Get
        Return Me.ufField
      End Get
      Set(ByVal value As String)
        Me.ufField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte", IncludeInSchema:=False)> _
  Public Enum ItemChoiceType3

    '''<remarks/>
    CNPJ

    '''<remarks/>
    CPF
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteRemInfNFe

    Private chaveField As String

    Private pINField As String

    '''<remarks/>
    Public Property chave() As String
      Get
        Return Me.chaveField
      End Get
      Set(ByVal value As String)
        Me.chaveField = value
      End Set
    End Property

    '''<remarks/>
    Public Property PIN() As String
      Get
        Return Me.pINField
      End Get
      Set(ByVal value As String)
        Me.pINField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteRemInfOutros

    Private tpDocField As TCTeInfCteRemInfOutrosTpDoc

    Private descOutrosField As String

    Private nDocField As String

    Private dEmiField As String

    Private vDocFiscField As String

    '''<remarks/>
    Public Property tpDoc() As TCTeInfCteRemInfOutrosTpDoc
      Get
        Return Me.tpDocField
      End Get
      Set(ByVal value As TCTeInfCteRemInfOutrosTpDoc)
        Me.tpDocField = value
      End Set
    End Property

    '''<remarks/>
    Public Property descOutros() As String
      Get
        Return Me.descOutrosField
      End Get
      Set(ByVal value As String)
        Me.descOutrosField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nDoc() As String
      Get
        Return Me.nDocField
      End Get
      Set(ByVal value As String)
        Me.nDocField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dEmi() As String
      Get
        Return Me.dEmiField
      End Get
      Set(ByVal value As String)
        Me.dEmiField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vDocFisc() As String
      Get
        Return Me.vDocFiscField
      End Get
      Set(ByVal value As String)
        Me.vDocFiscField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TCTeInfCteRemInfOutrosTpDoc

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("00")> _
    Item00

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("10")> _
    Item10

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("99")> _
    Item99
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteExped

    Private itemField As String

    Private itemElementNameField As ItemChoiceType4

    Private ieField As String

    Private xNomeField As String

    Private foneField As String

    Private enderExpedField As TEndereco

    Private emailField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("CNPJ", GetType(String)), _
     System.Xml.Serialization.XmlElementAttribute("CPF", GetType(String)), _
     System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")> _
    Public Property Item() As String
      Get
        Return Me.itemField
      End Get
      Set(ByVal value As String)
        Me.itemField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property ItemElementName() As ItemChoiceType4
      Get
        Return Me.itemElementNameField
      End Get
      Set(ByVal value As ItemChoiceType4)
        Me.itemElementNameField = value
      End Set
    End Property

    '''<remarks/>
    Public Property IE() As String
      Get
        Return Me.ieField
      End Get
      Set(ByVal value As String)
        Me.ieField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xNome() As String
      Get
        Return Me.xNomeField
      End Get
      Set(ByVal value As String)
        Me.xNomeField = value
      End Set
    End Property

    '''<remarks/>
    Public Property fone() As String
      Get
        Return Me.foneField
      End Get
      Set(ByVal value As String)
        Me.foneField = value
      End Set
    End Property

    '''<remarks/>
    Public Property enderExped() As TEndereco
      Get
        Return Me.enderExpedField
      End Get
      Set(ByVal value As TEndereco)
        Me.enderExpedField = value
      End Set
    End Property

    '''<remarks/>
    Public Property email() As String
      Get
        Return Me.emailField
      End Get
      Set(ByVal value As String)
        Me.emailField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte", IncludeInSchema:=False)> _
  Public Enum ItemChoiceType4

    '''<remarks/>
    CNPJ

    '''<remarks/>
    CPF
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteReceb

    Private itemField As String

    Private itemElementNameField As ItemChoiceType5

    Private ieField As String

    Private xNomeField As String

    Private foneField As String

    Private enderRecebField As TEndereco

    Private emailField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("CNPJ", GetType(String)), _
     System.Xml.Serialization.XmlElementAttribute("CPF", GetType(String)), _
     System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")> _
    Public Property Item() As String
      Get
        Return Me.itemField
      End Get
      Set(ByVal value As String)
        Me.itemField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property ItemElementName() As ItemChoiceType5
      Get
        Return Me.itemElementNameField
      End Get
      Set(ByVal value As ItemChoiceType5)
        Me.itemElementNameField = value
      End Set
    End Property

    '''<remarks/>
    Public Property IE() As String
      Get
        Return Me.ieField
      End Get
      Set(ByVal value As String)
        Me.ieField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xNome() As String
      Get
        Return Me.xNomeField
      End Get
      Set(ByVal value As String)
        Me.xNomeField = value
      End Set
    End Property

    '''<remarks/>
    Public Property fone() As String
      Get
        Return Me.foneField
      End Get
      Set(ByVal value As String)
        Me.foneField = value
      End Set
    End Property

    '''<remarks/>
    Public Property enderReceb() As TEndereco
      Get
        Return Me.enderRecebField
      End Get
      Set(ByVal value As TEndereco)
        Me.enderRecebField = value
      End Set
    End Property

    '''<remarks/>
    Public Property email() As String
      Get
        Return Me.emailField
      End Get
      Set(ByVal value As String)
        Me.emailField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte", IncludeInSchema:=False)> _
  Public Enum ItemChoiceType5

    '''<remarks/>
    CNPJ

    '''<remarks/>
    CPF
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteDest

    Private itemField As String

    Private itemElementNameField As ItemChoiceType6

    Private ieField As String

    Private xNomeField As String

    Private foneField As String

    Private iSUFField As String

    Private enderDestField As TEndereco

    Private emailField As String

    Private locEntField As TEndReEnt

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("CNPJ", GetType(String)), _
     System.Xml.Serialization.XmlElementAttribute("CPF", GetType(String)), _
     System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")> _
    Public Property Item() As String
      Get
        Return Me.itemField
      End Get
      Set(ByVal value As String)
        Me.itemField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property ItemElementName() As ItemChoiceType6
      Get
        Return Me.itemElementNameField
      End Get
      Set(ByVal value As ItemChoiceType6)
        Me.itemElementNameField = value
      End Set
    End Property

    '''<remarks/>
    Public Property IE() As String
      Get
        Return Me.ieField
      End Get
      Set(ByVal value As String)
        Me.ieField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xNome() As String
      Get
        Return Me.xNomeField
      End Get
      Set(ByVal value As String)
        Me.xNomeField = value
      End Set
    End Property

    '''<remarks/>
    Public Property fone() As String
      Get
        Return Me.foneField
      End Get
      Set(ByVal value As String)
        Me.foneField = value
      End Set
    End Property

    '''<remarks/>
    Public Property ISUF() As String
      Get
        Return Me.iSUFField
      End Get
      Set(ByVal value As String)
        Me.iSUFField = value
      End Set
    End Property

    '''<remarks/>
    Public Property enderDest() As TEndereco
      Get
        Return Me.enderDestField
      End Get
      Set(ByVal value As TEndereco)
        Me.enderDestField = value
      End Set
    End Property

    '''<remarks/>
    Public Property email() As String
      Get
        Return Me.emailField
      End Get
      Set(ByVal value As String)
        Me.emailField = value
      End Set
    End Property

    '''<remarks/>
    Public Property locEnt() As TEndReEnt
      Get
        Return Me.locEntField
      End Get
      Set(ByVal value As TEndReEnt)
        Me.locEntField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte", IncludeInSchema:=False)> _
  Public Enum ItemChoiceType6

    '''<remarks/>
    CNPJ

    '''<remarks/>
    CPF
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteVPrest

    Private vTPrestField As String

    Private vRecField As String

    Private compField() As TCTeInfCteVPrestComp

    '''<remarks/>
    Public Property vTPrest() As String
      Get
        Return Me.vTPrestField
      End Get
      Set(ByVal value As String)
        Me.vTPrestField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vRec() As String
      Get
        Return Me.vRecField
      End Get
      Set(ByVal value As String)
        Me.vRecField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("Comp")> _
    Public Property Comp() As TCTeInfCteVPrestComp()
      Get
        Return Me.compField
      End Get
      Set(ByVal value As TCTeInfCteVPrestComp())
        Me.compField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteVPrestComp

    Private xNomeField As String

    Private vCompField As String

    '''<remarks/>
    Public Property xNome() As String
      Get
        Return Me.xNomeField
      End Get
      Set(ByVal value As String)
        Me.xNomeField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vComp() As String
      Get
        Return Me.vCompField
      End Get
      Set(ByVal value As String)
        Me.vCompField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteImp

    Private iCMSField As TImp

    Private infAdFiscoField As String

    '''<remarks/>
    Public Property ICMS() As TImp
      Get
        Return Me.iCMSField
      End Get
      Set(ByVal value As TImp)
        Me.iCMSField = value
      End Set
    End Property

    '''<remarks/>
    Public Property infAdFisco() As String
      Get
        Return Me.infAdFiscoField
      End Get
      Set(ByVal value As String)
        Me.infAdFiscoField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TImp

    Private itemField As Object

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("ICMS00", GetType(TImpICMS00)), _
     System.Xml.Serialization.XmlElementAttribute("ICMS20", GetType(TImpICMS20)), _
     System.Xml.Serialization.XmlElementAttribute("ICMS45", GetType(TImpICMS45)), _
     System.Xml.Serialization.XmlElementAttribute("ICMS60", GetType(TImpICMS60)), _
     System.Xml.Serialization.XmlElementAttribute("ICMS90", GetType(TImpICMS90)), _
     System.Xml.Serialization.XmlElementAttribute("ICMSOutraUF", GetType(TImpICMSOutraUF)), _
     System.Xml.Serialization.XmlElementAttribute("ICMSSN", GetType(TImpICMSSN))> _
    Public Property Item() As Object
      Get
        Return Me.itemField
      End Get
      Set(ByVal value As Object)
        Me.itemField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TImpICMS00

    Private cSTField As String

    Private vBCField As String

    Private pICMSField As String

    Private vICMSField As String

    '''<remarks/>
    Public Property CST() As String
      Get
        Return Me.cSTField
      End Get
      Set(ByVal value As String)
        Me.cSTField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vBC() As String
      Get
        Return Me.vBCField
      End Get
      Set(ByVal value As String)
        Me.vBCField = value
      End Set
    End Property

    '''<remarks/>
    Public Property pICMS() As String
      Get
        Return Me.pICMSField
      End Get
      Set(ByVal value As String)
        Me.pICMSField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vICMS() As String
      Get
        Return Me.vICMSField
      End Get
      Set(ByVal value As String)
        Me.vICMSField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TImpICMS00CST

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("00")> _
    Item00
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TImpICMS20

    Private cSTField As String

    Private pRedBCField As String

    Private vBCField As String

    Private pICMSField As String

    Private vICMSField As String

    '''<remarks/>
    Public Property CST() As String
      Get
        Return Me.cSTField
      End Get
      Set(ByVal value As String)
        Me.cSTField = value
      End Set
    End Property

    '''<remarks/>
    Public Property pRedBC() As String
      Get
        Return Me.pRedBCField
      End Get
      Set(ByVal value As String)
        Me.pRedBCField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vBC() As String
      Get
        Return Me.vBCField
      End Get
      Set(ByVal value As String)
        Me.vBCField = value
      End Set
    End Property

    '''<remarks/>
    Public Property pICMS() As String
      Get
        Return Me.pICMSField
      End Get
      Set(ByVal value As String)
        Me.pICMSField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vICMS() As String
      Get
        Return Me.vICMSField
      End Get
      Set(ByVal value As String)
        Me.vICMSField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TImpICMS20CST

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("20")> _
    Item20
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TImpICMS45

    Private cSTField As String

    '''<remarks/>
    Public Property CST() As String
      Get
        Return Me.cSTField
      End Get
      Set(ByVal value As String)
        Me.cSTField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TImpICMS45CST

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("40")> _
    Item40

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("41")> _
    Item41

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("51")> _
    Item51
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TImpICMS60

    Private cSTField As String

    Private vBCSTRetField As String

    Private vICMSSTRetField As String

    Private pICMSSTRetField As String

    Private vCredField As String

    '''<remarks/>
    Public Property CST() As String
      Get
        Return Me.cSTField
      End Get
      Set(ByVal value As String)
        Me.cSTField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vBCSTRet() As String
      Get
        Return Me.vBCSTRetField
      End Get
      Set(ByVal value As String)
        Me.vBCSTRetField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vICMSSTRet() As String
      Get
        Return Me.vICMSSTRetField
      End Get
      Set(ByVal value As String)
        Me.vICMSSTRetField = value
      End Set
    End Property

    '''<remarks/>
    Public Property pICMSSTRet() As String
      Get
        Return Me.pICMSSTRetField
      End Get
      Set(ByVal value As String)
        Me.pICMSSTRetField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vCred() As String
      Get
        Return Me.vCredField
      End Get
      Set(ByVal value As String)
        Me.vCredField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TImpICMS60CST

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("60")> _
    Item60
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TImpICMS90

    Private cSTField As String

    Private pRedBCField As String

    Private vBCField As String

    Private pICMSField As String

    Private vICMSField As String

    Private vCredField As String

    '''<remarks/>
    Public Property CST() As String
      Get
        Return Me.cSTField
      End Get
      Set(ByVal value As String)
        Me.cSTField = value
      End Set
    End Property

    '''<remarks/>
    Public Property pRedBC() As String
      Get
        Return Me.pRedBCField
      End Get
      Set(ByVal value As String)
        Me.pRedBCField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vBC() As String
      Get
        Return Me.vBCField
      End Get
      Set(ByVal value As String)
        Me.vBCField = value
      End Set
    End Property

    '''<remarks/>
    Public Property pICMS() As String
      Get
        Return Me.pICMSField
      End Get
      Set(ByVal value As String)
        Me.pICMSField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vICMS() As String
      Get
        Return Me.vICMSField
      End Get
      Set(ByVal value As String)
        Me.vICMSField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vCred() As String
      Get
        Return Me.vCredField
      End Get
      Set(ByVal value As String)
        Me.vCredField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TImpICMS90CST

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("90")> _
    Item90
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TImpICMSOutraUF

    Private cSTField As String

    Private pRedBCOutraUFField As String

    Private vBCOutraUFField As String

    Private pICMSOutraUFField As String

    Private vICMSOutraUFField As String

    '''<remarks/>
    Public Property CST() As String
      Get
        Return Me.cSTField
      End Get
      Set(ByVal value As String)
        Me.cSTField = value
      End Set
    End Property

    '''<remarks/>
    Public Property pRedBCOutraUF() As String
      Get
        Return Me.pRedBCOutraUFField
      End Get
      Set(ByVal value As String)
        Me.pRedBCOutraUFField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vBCOutraUF() As String
      Get
        Return Me.vBCOutraUFField
      End Get
      Set(ByVal value As String)
        Me.vBCOutraUFField = value
      End Set
    End Property

    '''<remarks/>
    Public Property pICMSOutraUF() As String
      Get
        Return Me.pICMSOutraUFField
      End Get
      Set(ByVal value As String)
        Me.pICMSOutraUFField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vICMSOutraUF() As String
      Get
        Return Me.vICMSOutraUFField
      End Get
      Set(ByVal value As String)
        Me.vICMSOutraUFField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TImpICMSOutraUFCST

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("90")> _
    Item90
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TImpICMSSN

    Private indSNField As String

    '''<remarks/>
    Public Property indSN() As String
      Get
        Return Me.indSNField
      End Get
      Set(ByVal value As String)
        Me.indSNField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TImpICMSSNIndSN

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")> _
    Item1
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCTeNorm

    Private infCargaField As TCTeInfCteInfCTeNormInfCarga

    Private contQtField() As TCTeInfCteInfCTeNormContQt

    Private docAntField() As TCTeInfCteInfCTeNormEmiDocAnt

    Private segField() As TCTeInfCteInfCTeNormSeg

    Private infModalField As TCTeInfCteInfCTeNormInfModal

    Private periField() As TCTeInfCteInfCTeNormPeri

    Private veicNovosField() As TCTeInfCteInfCTeNormVeicNovos

    Private cobrField As TCTeInfCteInfCTeNormCobr

    Private infCteSubField As TCTeInfCteInfCTeNormInfCteSub

    '''<remarks/>
    Public Property infCarga() As TCTeInfCteInfCTeNormInfCarga
      Get
        Return Me.infCargaField
      End Get
      Set(ByVal value As TCTeInfCteInfCTeNormInfCarga)
        Me.infCargaField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("contQt")> _
    Public Property contQt() As TCTeInfCteInfCTeNormContQt()
      Get
        Return Me.contQtField
      End Get
      Set(ByVal value As TCTeInfCteInfCTeNormContQt())
        Me.contQtField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlArrayItemAttribute("emiDocAnt", IsNullable:=False)> _
    Public Property docAnt() As TCTeInfCteInfCTeNormEmiDocAnt()
      Get
        Return Me.docAntField
      End Get
      Set(ByVal value As TCTeInfCteInfCTeNormEmiDocAnt())
        Me.docAntField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("seg")> _
    Public Property seg() As TCTeInfCteInfCTeNormSeg()
      Get
        Return Me.segField
      End Get
      Set(ByVal value As TCTeInfCteInfCTeNormSeg())
        Me.segField = value
      End Set
    End Property

    '''<remarks/>
    Public Property infModal() As TCTeInfCteInfCTeNormInfModal
      Get
        Return Me.infModalField
      End Get
      Set(ByVal value As TCTeInfCteInfCTeNormInfModal)
        Me.infModalField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("peri")> _
    Public Property peri() As TCTeInfCteInfCTeNormPeri()
      Get
        Return Me.periField
      End Get
      Set(ByVal value As TCTeInfCteInfCTeNormPeri())
        Me.periField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("veicNovos")> _
    Public Property veicNovos() As TCTeInfCteInfCTeNormVeicNovos()
      Get
        Return Me.veicNovosField
      End Get
      Set(ByVal value As TCTeInfCteInfCTeNormVeicNovos())
        Me.veicNovosField = value
      End Set
    End Property

    '''<remarks/>
    Public Property cobr() As TCTeInfCteInfCTeNormCobr
      Get
        Return Me.cobrField
      End Get
      Set(ByVal value As TCTeInfCteInfCTeNormCobr)
        Me.cobrField = value
      End Set
    End Property

    '''<remarks/>
    Public Property infCteSub() As TCTeInfCteInfCTeNormInfCteSub
      Get
        Return Me.infCteSubField
      End Get
      Set(ByVal value As TCTeInfCteInfCTeNormInfCteSub)
        Me.infCteSubField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCTeNormInfCarga

    Private vCargaField As String

    Private proPredField As String

    Private xOutCatField As String

    Private infQField() As TCTeInfCteInfCTeNormInfCargaInfQ

    '''<remarks/>
    Public Property vCarga() As String
      Get
        Return Me.vCargaField
      End Get
      Set(ByVal value As String)
        Me.vCargaField = value
      End Set
    End Property

    '''<remarks/>
    Public Property proPred() As String
      Get
        Return Me.proPredField
      End Get
      Set(ByVal value As String)
        Me.proPredField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xOutCat() As String
      Get
        Return Me.xOutCatField
      End Get
      Set(ByVal value As String)
        Me.xOutCatField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("infQ")> _
    Public Property infQ() As TCTeInfCteInfCTeNormInfCargaInfQ()
      Get
        Return Me.infQField
      End Get
      Set(ByVal value As TCTeInfCteInfCTeNormInfCargaInfQ())
        Me.infQField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCTeNormInfCargaInfQ

    Private cUnidField As TCTeInfCteInfCTeNormInfCargaInfQCUnid

    Private tpMedField As String

    Private qCargaField As String

    '''<remarks/>
    Public Property cUnid() As TCTeInfCteInfCTeNormInfCargaInfQCUnid
      Get
        Return Me.cUnidField
      End Get
      Set(ByVal value As TCTeInfCteInfCTeNormInfCargaInfQCUnid)
        Me.cUnidField = value
      End Set
    End Property

    '''<remarks/>
    Public Property tpMed() As String
      Get
        Return Me.tpMedField
      End Get
      Set(ByVal value As String)
        Me.tpMedField = value
      End Set
    End Property

    '''<remarks/>
    Public Property qCarga() As String
      Get
        Return Me.qCargaField
      End Get
      Set(ByVal value As String)
        Me.qCargaField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TCTeInfCteInfCTeNormInfCargaInfQCUnid

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("00")> _
    Item00

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("01")> _
    Item01

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("02")> _
    Item02

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("03")> _
    Item03

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("04")> _
    Item04

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("05")> _
    Item05
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCTeNormContQt

    Private nContField As String

    Private lacContQtField() As TCTeInfCteInfCTeNormContQtLacContQt

    Private dPrevField As String

    '''<remarks/>
    Public Property nCont() As String
      Get
        Return Me.nContField
      End Get
      Set(ByVal value As String)
        Me.nContField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("lacContQt")> _
    Public Property lacContQt() As TCTeInfCteInfCTeNormContQtLacContQt()
      Get
        Return Me.lacContQtField
      End Get
      Set(ByVal value As TCTeInfCteInfCTeNormContQtLacContQt())
        Me.lacContQtField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dPrev() As String
      Get
        Return Me.dPrevField
      End Get
      Set(ByVal value As String)
        Me.dPrevField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCTeNormContQtLacContQt

    Private nLacreField As String

    '''<remarks/>
    Public Property nLacre() As String
      Get
        Return Me.nLacreField
      End Get
      Set(ByVal value As String)
        Me.nLacreField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCTeNormEmiDocAnt

    Private itemField As String

    Private itemElementNameField As ItemChoiceType7

    Private ieField As String

    Private ufField As String

    Private xNomeField As String

    Private idDocAntField() As TCTeInfCteInfCTeNormEmiDocAntIdDocAnt

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("CNPJ", GetType(String)), _
     System.Xml.Serialization.XmlElementAttribute("CPF", GetType(String)), _
     System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")> _
    Public Property Item() As String
      Get
        Return Me.itemField
      End Get
      Set(ByVal value As String)
        Me.itemField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property ItemElementName() As ItemChoiceType7
      Get
        Return Me.itemElementNameField
      End Get
      Set(ByVal value As ItemChoiceType7)
        Me.itemElementNameField = value
      End Set
    End Property

    '''<remarks/>
    Public Property IE() As String
      Get
        Return Me.ieField
      End Get
      Set(ByVal value As String)
        Me.ieField = value
      End Set
    End Property

    '''<remarks/>
    Public Property UF() As String
      Get
        Return Me.ufField
      End Get
      Set(ByVal value As String)
        Me.ufField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xNome() As String
      Get
        Return Me.xNomeField
      End Get
      Set(ByVal value As String)
        Me.xNomeField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("idDocAnt")> _
    Public Property idDocAnt() As TCTeInfCteInfCTeNormEmiDocAntIdDocAnt()
      Get
        Return Me.idDocAntField
      End Get
      Set(ByVal value As TCTeInfCteInfCTeNormEmiDocAntIdDocAnt())
        Me.idDocAntField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte", IncludeInSchema:=False)> _
  Public Enum ItemChoiceType7

    '''<remarks/>
    CNPJ

    '''<remarks/>
    CPF
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCTeNormEmiDocAntIdDocAnt

    Private itemsField() As Object

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("idDocAntEle", GetType(TCTeInfCteInfCTeNormEmiDocAntIdDocAntIdDocAntEle)), _
     System.Xml.Serialization.XmlElementAttribute("idDocAntPap", GetType(TCTeInfCteInfCTeNormEmiDocAntIdDocAntIdDocAntPap))> _
    Public Property Items() As Object()
      Get
        Return Me.itemsField
      End Get
      Set(ByVal value As Object())
        Me.itemsField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCTeNormEmiDocAntIdDocAntIdDocAntEle

    Private chaveField As String

    '''<remarks/>
    Public Property chave() As String
      Get
        Return Me.chaveField
      End Get
      Set(ByVal value As String)
        Me.chaveField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCTeNormEmiDocAntIdDocAntIdDocAntPap

    Private tpDocField As String

    Private serieField As String

    Private subserField As String

    Private nDocField As String

    Private dEmiField As String

    '''<remarks/>
    Public Property tpDoc() As String
      Get
        Return Me.tpDocField
      End Get
      Set(ByVal value As String)
        Me.tpDocField = value
      End Set
    End Property

    '''<remarks/>
    Public Property serie() As String
      Get
        Return Me.serieField
      End Get
      Set(ByVal value As String)
        Me.serieField = value
      End Set
    End Property

    '''<remarks/>
    Public Property subser() As String
      Get
        Return Me.subserField
      End Get
      Set(ByVal value As String)
        Me.subserField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nDoc() As String
      Get
        Return Me.nDocField
      End Get
      Set(ByVal value As String)
        Me.nDocField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dEmi() As String
      Get
        Return Me.dEmiField
      End Get
      Set(ByVal value As String)
        Me.dEmiField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TDocAssoc

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("00")> _
    Item00

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("01")> _
    Item01

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("02")> _
    Item02

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("03")> _
    Item03

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("04")> _
    Item04

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("05")> _
    Item05

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("06")> _
    Item06

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("07")> _
    Item07

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("08")> _
    Item08

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("09")> _
    Item09

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("10")> _
    Item10

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("11")> _
    Item11

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("12")> _
    Item12

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("99")> _
    Item99
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCTeNormSeg

    Private respSegField As TCTeInfCteInfCTeNormSegRespSeg

    Private xSegField As String

    Private nApolField As String

    Private nAverField As String

    Private vCargaField As String

    '''<remarks/>
    Public Property respSeg() As TCTeInfCteInfCTeNormSegRespSeg
      Get
        Return Me.respSegField
      End Get
      Set(ByVal value As TCTeInfCteInfCTeNormSegRespSeg)
        Me.respSegField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xSeg() As String
      Get
        Return Me.xSegField
      End Get
      Set(ByVal value As String)
        Me.xSegField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nApol() As String
      Get
        Return Me.nApolField
      End Get
      Set(ByVal value As String)
        Me.nApolField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nAver() As String
      Get
        Return Me.nAverField
      End Get
      Set(ByVal value As String)
        Me.nAverField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vCarga() As String
      Get
        Return Me.vCargaField
      End Get
      Set(ByVal value As String)
        Me.vCargaField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TCTeInfCteInfCTeNormSegRespSeg

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("0")> _
    Item0

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")> _
    Item1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("2")> _
    Item2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("3")> _
    Item3

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("4")> _
    Item4

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("5")> _
    Item5
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCTeNormInfModal

    Private anyField As System.Xml.XmlElement

    Private versaoModalField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlAnyElementAttribute()> _
    Public Property Any() As System.Xml.XmlElement
      Get
        Return Me.anyField
      End Get
      Set(ByVal value As System.Xml.XmlElement)
        Me.anyField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versaoModal() As String
      Get
        Return Me.versaoModalField
      End Get
      Set(ByVal value As String)
        Me.versaoModalField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCTeNormPeri

    Private nONUField As String

    Private xNomeAEField As String

    Private xClaRiscoField As String

    Private grEmbField As String

    Private qTotProdField As String

    Private qVolTipoField As String

    Private pontoFulgorField As String

    '''<remarks/>
    Public Property nONU() As String
      Get
        Return Me.nONUField
      End Get
      Set(ByVal value As String)
        Me.nONUField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xNomeAE() As String
      Get
        Return Me.xNomeAEField
      End Get
      Set(ByVal value As String)
        Me.xNomeAEField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xClaRisco() As String
      Get
        Return Me.xClaRiscoField
      End Get
      Set(ByVal value As String)
        Me.xClaRiscoField = value
      End Set
    End Property

    '''<remarks/>
    Public Property grEmb() As String
      Get
        Return Me.grEmbField
      End Get
      Set(ByVal value As String)
        Me.grEmbField = value
      End Set
    End Property

    '''<remarks/>
    Public Property qTotProd() As String
      Get
        Return Me.qTotProdField
      End Get
      Set(ByVal value As String)
        Me.qTotProdField = value
      End Set
    End Property

    '''<remarks/>
    Public Property qVolTipo() As String
      Get
        Return Me.qVolTipoField
      End Get
      Set(ByVal value As String)
        Me.qVolTipoField = value
      End Set
    End Property

    '''<remarks/>
    Public Property pontoFulgor() As String
      Get
        Return Me.pontoFulgorField
      End Get
      Set(ByVal value As String)
        Me.pontoFulgorField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCTeNormVeicNovos

    Private chassiField As String

    Private cCorField As String

    Private xCorField As String

    Private cModField As String

    Private vUnitField As String

    Private vFreteField As String

    '''<remarks/>
    Public Property chassi() As String
      Get
        Return Me.chassiField
      End Get
      Set(ByVal value As String)
        Me.chassiField = value
      End Set
    End Property

    '''<remarks/>
    Public Property cCor() As String
      Get
        Return Me.cCorField
      End Get
      Set(ByVal value As String)
        Me.cCorField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xCor() As String
      Get
        Return Me.xCorField
      End Get
      Set(ByVal value As String)
        Me.xCorField = value
      End Set
    End Property

    '''<remarks/>
    Public Property cMod() As String
      Get
        Return Me.cModField
      End Get
      Set(ByVal value As String)
        Me.cModField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vUnit() As String
      Get
        Return Me.vUnitField
      End Get
      Set(ByVal value As String)
        Me.vUnitField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vFrete() As String
      Get
        Return Me.vFreteField
      End Get
      Set(ByVal value As String)
        Me.vFreteField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCTeNormCobr

    Private fatField As TCTeInfCteInfCTeNormCobrFat

    Private dupField() As TCTeInfCteInfCTeNormCobrDup

    '''<remarks/>
    Public Property fat() As TCTeInfCteInfCTeNormCobrFat
      Get
        Return Me.fatField
      End Get
      Set(ByVal value As TCTeInfCteInfCTeNormCobrFat)
        Me.fatField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("dup")> _
    Public Property dup() As TCTeInfCteInfCTeNormCobrDup()
      Get
        Return Me.dupField
      End Get
      Set(ByVal value As TCTeInfCteInfCTeNormCobrDup())
        Me.dupField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCTeNormCobrFat

    Private nFatField As String

    Private vOrigField As String

    Private vDescField As String

    Private vLiqField As String

    '''<remarks/>
    Public Property nFat() As String
      Get
        Return Me.nFatField
      End Get
      Set(ByVal value As String)
        Me.nFatField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vOrig() As String
      Get
        Return Me.vOrigField
      End Get
      Set(ByVal value As String)
        Me.vOrigField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vDesc() As String
      Get
        Return Me.vDescField
      End Get
      Set(ByVal value As String)
        Me.vDescField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vLiq() As String
      Get
        Return Me.vLiqField
      End Get
      Set(ByVal value As String)
        Me.vLiqField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCTeNormCobrDup

    Private nDupField As String

    Private dVencField As String

    Private vDupField As String

    '''<remarks/>
    Public Property nDup() As String
      Get
        Return Me.nDupField
      End Get
      Set(ByVal value As String)
        Me.nDupField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dVenc() As String
      Get
        Return Me.dVencField
      End Get
      Set(ByVal value As String)
        Me.dVencField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vDup() As String
      Get
        Return Me.vDupField
      End Get
      Set(ByVal value As String)
        Me.vDupField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCTeNormInfCteSub

    Private chCteField As String

    Private itemField As Object

    '''<remarks/>
    Public Property chCte() As String
      Get
        Return Me.chCteField
      End Get
      Set(ByVal value As String)
        Me.chCteField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("tomaICMS", GetType(TCTeInfCteInfCTeNormInfCteSubTomaICMS)), _
     System.Xml.Serialization.XmlElementAttribute("tomaNaoICMS", GetType(TCTeInfCteInfCTeNormInfCteSubTomaNaoICMS))> _
    Public Property Item() As Object
      Get
        Return Me.itemField
      End Get
      Set(ByVal value As Object)
        Me.itemField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCTeNormInfCteSubTomaICMS

    Private itemField As Object

    Private itemElementNameField As ItemChoiceType8

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("refCte", GetType(String)), _
     System.Xml.Serialization.XmlElementAttribute("refNF", GetType(TCTeInfCteInfCTeNormInfCteSubTomaICMSRefNF)), _
     System.Xml.Serialization.XmlElementAttribute("refNFe", GetType(String)), _
     System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")> _
    Public Property Item() As Object
      Get
        Return Me.itemField
      End Get
      Set(ByVal value As Object)
        Me.itemField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property ItemElementName() As ItemChoiceType8
      Get
        Return Me.itemElementNameField
      End Get
      Set(ByVal value As ItemChoiceType8)
        Me.itemElementNameField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCTeNormInfCteSubTomaICMSRefNF

    Private cNPJField As String

    Private modField As TModDoc

    Private serieField As String

    Private subserieField As String

    Private nroField As String

    Private valorField As String

    Private dEmiField As String

    '''<remarks/>
    Public Property CNPJ() As String
      Get
        Return Me.cNPJField
      End Get
      Set(ByVal value As String)
        Me.cNPJField = value
      End Set
    End Property

    '''<remarks/>
    Public Property [mod]() As TModDoc
      Get
        Return Me.modField
      End Get
      Set(ByVal value As TModDoc)
        Me.modField = value
      End Set
    End Property

    '''<remarks/>
    Public Property serie() As String
      Get
        Return Me.serieField
      End Get
      Set(ByVal value As String)
        Me.serieField = value
      End Set
    End Property

    '''<remarks/>
    Public Property subserie() As String
      Get
        Return Me.subserieField
      End Get
      Set(ByVal value As String)
        Me.subserieField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nro() As String
      Get
        Return Me.nroField
      End Get
      Set(ByVal value As String)
        Me.nroField = value
      End Set
    End Property

    '''<remarks/>
    Public Property valor() As String
      Get
        Return Me.valorField
      End Get
      Set(ByVal value As String)
        Me.valorField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dEmi() As String
      Get
        Return Me.dEmiField
      End Get
      Set(ByVal value As String)
        Me.dEmiField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TModDoc

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("01")> _
    Item01

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1B")> _
    Item1B

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("02")> _
    Item02

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("2D")> _
    Item2D

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("2E")> _
    Item2E

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("04")> _
    Item04

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("06")> _
    Item06

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("07")> _
    Item07

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("08")> _
    Item08

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("8B")> _
    Item8B

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("09")> _
    Item09

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("10")> _
    Item10

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("11")> _
    Item11

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("13")> _
    Item13

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("14")> _
    Item14

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("15")> _
    Item15

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("16")> _
    Item16

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("17")> _
    Item17

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("18")> _
    Item18

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("20")> _
    Item20

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("21")> _
    Item21

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("22")> _
    Item22

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("23")> _
    Item23

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("24")> _
    Item24

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("25")> _
    Item25

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("26")> _
    Item26

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("27")> _
    Item27

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("28")> _
    Item28

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("55")> _
    Item55
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte", IncludeInSchema:=False)> _
  Public Enum ItemChoiceType8

    '''<remarks/>
    refCte

    '''<remarks/>
    refNF

    '''<remarks/>
    refNFe
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCTeNormInfCteSubTomaNaoICMS

    Private refCteAnuField As String

    '''<remarks/>
    Public Property refCteAnu() As String
      Get
        Return Me.refCteAnuField
      End Get
      Set(ByVal value As String)
        Me.refCteAnuField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCteAnu

    Private chCteField As String

    Private dEmiField As String

    '''<remarks/>
    Public Property chCte() As String
      Get
        Return Me.chCteField
      End Get
      Set(ByVal value As String)
        Me.chCteField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dEmi() As String
      Get
        Return Me.dEmiField
      End Get
      Set(ByVal value As String)
        Me.dEmiField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCteComp

    Private chaveField As String

    Private vPresCompField As TCTeInfCteInfCteCompVPresComp

    Private impCompField As TCTeInfCteInfCteCompImpComp

    '''<remarks/>
    Public Property chave() As String
      Get
        Return Me.chaveField
      End Get
      Set(ByVal value As String)
        Me.chaveField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vPresComp() As TCTeInfCteInfCteCompVPresComp
      Get
        Return Me.vPresCompField
      End Get
      Set(ByVal value As TCTeInfCteInfCteCompVPresComp)
        Me.vPresCompField = value
      End Set
    End Property

    '''<remarks/>
    Public Property impComp() As TCTeInfCteInfCteCompImpComp
      Get
        Return Me.impCompField
      End Get
      Set(ByVal value As TCTeInfCteInfCteCompImpComp)
        Me.impCompField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCteCompVPresComp

    Private vTPrestField As String

    Private compCompField() As TCTeInfCteInfCteCompVPresCompCompComp

    '''<remarks/>
    Public Property vTPrest() As String
      Get
        Return Me.vTPrestField
      End Get
      Set(ByVal value As String)
        Me.vTPrestField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("compComp")> _
    Public Property compComp() As TCTeInfCteInfCteCompVPresCompCompComp()
      Get
        Return Me.compCompField
      End Get
      Set(ByVal value As TCTeInfCteInfCteCompVPresCompCompComp())
        Me.compCompField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCteCompVPresCompCompComp

    Private xNomeField As String

    Private vCompField As String

    '''<remarks/>
    Public Property xNome() As String
      Get
        Return Me.xNomeField
      End Get
      Set(ByVal value As String)
        Me.xNomeField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vComp() As String
      Get
        Return Me.vCompField
      End Get
      Set(ByVal value As String)
        Me.vCompField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCTeInfCteInfCteCompImpComp

    Private iCMSCompField As TImp

    Private infAdFiscoField As String

    '''<remarks/>
    Public Property ICMSComp() As TImp
      Get
        Return Me.iCMSCompField
      End Get
      Set(ByVal value As TImp)
        Me.iCMSCompField = value
      End Set
    End Property

    '''<remarks/>
    Public Property infAdFisco() As String
      Get
        Return Me.infAdFiscoField
      End Get
      Set(ByVal value As String)
        Me.infAdFiscoField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte"), _
   System.Xml.Serialization.XmlRootAttribute("enviCTe", [Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
  Partial Public Class TEnviCTe

    Private idLoteField As String

    Private cTeField() As TCTe

    Private versaoField As String
    Sub New()
      MyBase.New()
    End Sub
    Sub New(ByVal numLote As Long, ByVal ParamArray CTes() As TCTe)
      MyBase.New()
      idLoteField = numLote
      cTeField = CTes
      If cTeField IsNot Nothing Then _
      If cTeField.Length > 0 Then _
      versaoField = cTeField(0).infCte.versao
    End Sub
    '''<remarks/>
    Public Property idLote() As String
      Get
        Return Me.idLoteField
      End Get
      Set(ByVal value As String)
        Me.idLoteField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("CTe")> _
    Public Property CTe() As TCTe()
      Get
        Return Me.cTeField
      End Get
      Set(ByVal value As TCTe())
        Me.cTeField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versao() As String
      Get
        Return Me.versaoField
      End Get
      Set(ByVal value As String)
        Me.versaoField = value
      End Set
    End Property
    Public Function ToXMLNode() As Xml.XmlNode
      Dim xDoc As New Xml.XmlDocument
      xDoc.LoadXml(ToString)
      Return xDoc.DocumentElement
    End Function
    Public Overrides Function ToString() As String
      Dim xs As New XmlSerializer(Me.GetType)
      Dim xmlns As New XmlSerializerNamespaces
      xmlns.Add("", "http://www.portalfiscal.inf.br/cte")
      Dim sw As New IO.StringWriter()
      'Dim ms As New IO.MemoryStream
      Dim tmp As String = IO.Path.GetTempFileName
      Dim sw2 As New IO.StreamWriter(tmp, False, System.Text.Encoding.UTF8)
      xs.Serialize(sw2, Me, xmlns)
      Dim xmlDocument As New XmlDocument
      sw2.Close()
      xmlDocument.Load(tmp)
      Dim r As String = xmlDocument.DocumentElement.OuterXml
      IO.File.Delete(tmp)
      Return r
      'xs.Deserialize
      Return MyBase.ToString()
    End Function
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte"), _
   System.Xml.Serialization.XmlRootAttribute("inutCTe", [Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
  Partial Public Class TInutCTe

    Private infInutField As TInutCTeInfInut

    Private signatureField As SignatureType

    Private versaoField As String

    '''<remarks/>
    Public Property infInut() As TInutCTeInfInut
      Get
        Return Me.infInutField
      End Get
      Set(ByVal value As TInutCTeInfInut)
        Me.infInutField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Public Property Signature() As SignatureType
      Get
        Return Me.signatureField
      End Get
      Set(ByVal value As SignatureType)
        Me.signatureField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versao() As String
      Get
        Return Me.versaoField
      End Get
      Set(ByVal value As String)
        Me.versaoField = value
      End Set
    End Property
    Public Function ToXMLNode() As Xml.XmlNode
      Dim xDoc As New Xml.XmlDocument
      xDoc.LoadXml(ToString)
      Return xDoc.DocumentElement
    End Function
    Public Overrides Function ToString() As String
      Dim xs As New XmlSerializer(Me.GetType)
      Dim xmlns As New XmlSerializerNamespaces
      xmlns.Add("", "http://www.portalfiscal.inf.br/cte")
      Dim sw As New IO.StringWriter()
      'Dim ms As New IO.MemoryStream
      Dim tmp As String = IO.Path.GetTempFileName
      Dim sw2 As New IO.StreamWriter(tmp, False, System.Text.Encoding.UTF8)
      xs.Serialize(sw2, Me, xmlns)
      Dim xmlDocument As New XmlDocument
      sw2.Close()
      xmlDocument.Load(tmp)
      Dim r As String = xmlDocument.DocumentElement.OuterXml
      IO.File.Delete(tmp)
      Return r
      'xs.Deserialize
      Return MyBase.ToString()
    End Function
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TInutCTeInfInut

    Private tpAmbField As String

    Private xServField As String

    Private cUFField As String

    Private anoField As Short

    Private cNPJField As String

    Private modField As String

    Private serieField As String

    Private nCTIniField As String

    Private nCTFinField As String

    Private xJustField As String

    Private idField As String

    Public Sub New()
      MyBase.New()
      Me.xServField = "INUTILIZAR"
    End Sub

    '''<remarks/>
    Public Property tpAmb() As String
      Get
        Return Me.tpAmbField
      End Get
      Set(ByVal value As String)
        Me.tpAmbField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xServ() As String
      Get
        Return Me.xServField
      End Get
      Set(ByVal value As String)
        Me.xServField = value
      End Set
    End Property

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
    Public Property ano() As Short
      Get
        Return Me.anoField
      End Get
      Set(ByVal value As Short)
        Me.anoField = value
      End Set
    End Property

    '''<remarks/>
    Public Property CNPJ() As String
      Get
        Return Me.cNPJField
      End Get
      Set(ByVal value As String)
        Me.cNPJField = value
      End Set
    End Property

    '''<remarks/>
    Public Property [mod]() As String
      Get
        Return Me.modField
      End Get
      Set(ByVal value As String)
        Me.modField = value
      End Set
    End Property

    '''<remarks/>
    Public Property serie() As String
      Get
        Return Me.serieField
      End Get
      Set(ByVal value As String)
        Me.serieField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nCTIni() As String
      Get
        Return Me.nCTIniField
      End Get
      Set(ByVal value As String)
        Me.nCTIniField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nCTFin() As String
      Get
        Return Me.nCTFinField
      End Get
      Set(ByVal value As String)
        Me.nCTFinField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xJust() As String
      Get
        Return Me.xJustField
      End Get
      Set(ByVal value As String)
        Me.xJustField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")> _
    Public Property Id() As String
      Get
        Return Me.idField
      End Get
      Set(ByVal value As String)
        Me.idField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte"), _
   System.Xml.Serialization.XmlRootAttribute("procCancCTe", [Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
  Partial Public Class TProcCancCTe

    Private cancCTeField As TCancCTe

    Private retCancCTeField As TRetCancCTe

    Private versaoField As String

    Sub New(ByVal baseCancCTe As TCancCTe, ByVal baseRetCancCTe As TRetCancCTe)
      cancCTeField = baseCancCTe
      retCancCTeField = baseRetCancCTe
      versaoField = baseCancCTe.versao
    End Sub
    '''<remarks/>
    Public Property cancCTe() As TCancCTe
      Get
        Return Me.cancCTeField
      End Get
      Set(ByVal value As TCancCTe)
        Me.cancCTeField = value
      End Set
    End Property

    '''<remarks/>
    Public Property retCancCTe() As TRetCancCTe
      Get
        Return Me.retCancCTeField
      End Get
      Set(ByVal value As TRetCancCTe)
        Me.retCancCTeField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versao() As String
      Get
        Return Me.versaoField
      End Get
      Set(ByVal value As String)
        Me.versaoField = value
      End Set
    End Property

    Public Function ToFile(ByVal onFolder As String) As Boolean
      Try
        Dim fname As String = GetFileName()
        Dim fi As New IO.FileInfo(fname)
        If fi.Exists Then fi.Delete()
        IO.File.WriteAllBytes(fname, ToBytes)
        If Not IO.Directory.Exists(onFolder) Then IO.Directory.CreateDirectory(onFolder)
        IO.File.Move(fname, (onFolder & IO.Path.DirectorySeparatorChar & fname).Replace(New String(IO.Path.DirectorySeparatorChar, 2), IO.Path.DirectorySeparatorChar))
        Return True
      Catch ex As Exception
        Return False
      End Try
    End Function
    Public Function ToBytes() As Byte()
      Return System.Text.Encoding.UTF8.GetBytes(ToString)
    End Function
    Public Function GetFileName() As String
      Return Me.cancCTe.infCanc.Id.Substring(3) & "-procCancCTe.xml"
    End Function

    Public Function ToXMLNode() As Xml.XmlNode
      Dim xDoc As New Xml.XmlDocument
      xDoc.LoadXml(ToString)
      Return xDoc.DocumentElement
    End Function
    Public Overrides Function ToString() As String
      Dim xs As New XmlSerializer(Me.GetType)
      Dim xmlns As New XmlSerializerNamespaces
      xmlns.Add("", "http://www.portalfiscal.inf.br/cte")
      Dim sw As New IO.StringWriter()
      'Dim ms As New IO.MemoryStream
      Dim tmp As String = IO.Path.GetTempFileName
      Dim sw2 As New IO.StreamWriter(tmp, False, System.Text.Encoding.UTF8)
      xs.Serialize(sw2, Me, xmlns)
      Dim xmlDocument As New XmlDocument
      sw2.Close()
      xmlDocument.Load(tmp)
      Dim r As String = xmlDocument.DocumentElement.OuterXml
      IO.File.Delete(tmp)
      Return r
      'xs.Deserialize
      Return MyBase.ToString()
    End Function
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte"), _
   System.Xml.Serialization.XmlRootAttribute("retCancCTe", [Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
  Partial Public Class TRetCancCTe

    Private infCancField As TRetCancCTeInfCanc

    Private signatureField As SignatureType

    Private versaoField As String

    '''<remarks/>
    Public Property infCanc() As TRetCancCTeInfCanc
      Get
        Return Me.infCancField
      End Get
      Set(ByVal value As TRetCancCTeInfCanc)
        Me.infCancField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Public Property Signature() As SignatureType
      Get
        Return Me.signatureField
      End Get
      Set(ByVal value As SignatureType)
        Me.signatureField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versao() As String
      Get
        Return Me.versaoField
      End Get
      Set(ByVal value As String)
        Me.versaoField = value
      End Set
    End Property

    Public Function ToFile(ByVal onFolder As String) As Boolean
      Try
        Dim fname As String = GetFileName()
        Dim fi As New IO.FileInfo(fname)
        If fi.Exists Then fi.Delete()
        IO.File.WriteAllBytes(fname, ToBytes)
        IO.File.Move(fname, (onFolder & IO.Path.DirectorySeparatorChar & fname).Replace(New String(IO.Path.DirectorySeparatorChar, 2), IO.Path.DirectorySeparatorChar))
        Return True
      Catch ex As Exception
        Return False
      End Try
    End Function
    Public Function GetFileName() As String
      Return Me.infCanc.chCTe & "-retCancCTe.xml"
    End Function
    Public Function ToBytes() As Byte()
      Return System.Text.Encoding.UTF8.GetBytes(ToString)
    End Function

    Public Function ToXMLNode() As Xml.XmlNode
      Dim xDoc As New Xml.XmlDocument
      xDoc.LoadXml(ToString)
      Return xDoc.DocumentElement
    End Function
    Public Overrides Function ToString() As String
      Dim xs As New XmlSerializer(Me.GetType)
      Dim xmlns As New XmlSerializerNamespaces
      xmlns.Add("", "http://www.portalfiscal.inf.br/cte")
      Dim sw As New IO.StringWriter()
      'Dim ms As New IO.MemoryStream
      Dim tmp As String = IO.Path.GetTempFileName
      Dim sw2 As New IO.StreamWriter(tmp, False, System.Text.Encoding.UTF8)
      xs.Serialize(sw2, Me, xmlns)
      Dim xmlDocument As New XmlDocument
      sw2.Close()
      xmlDocument.Load(tmp)
      Dim r As String = xmlDocument.DocumentElement.OuterXml
      IO.File.Delete(tmp)
      Return r
      'xs.Deserialize
      Return MyBase.ToString()
    End Function
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TRetCancCTeInfCanc

    Private tpAmbField As String

    Private cUFField As String

    Private verAplicField As String

    Private cStatField As String

    Private xMotivoField As String

    Private chCTeField As String

    Private dhRecbtoField As Date

    Private dhRecbtoFieldSpecified As Boolean

    Private nProtField As String

    Private idField As String

    '''<remarks/>
    Public Property tpAmb() As String
      Get
        Return Me.tpAmbField
      End Get
      Set(ByVal value As String)
        Me.tpAmbField = value
      End Set
    End Property

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
    Public Property verAplic() As String
      Get
        Return Me.verAplicField
      End Get
      Set(ByVal value As String)
        Me.verAplicField = value
      End Set
    End Property

    '''<remarks/>
    Public Property cStat() As String
      Get
        Return Me.cStatField
      End Get
      Set(ByVal value As String)
        Me.cStatField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xMotivo() As String
      Get
        Return Me.xMotivoField
      End Get
      Set(ByVal value As String)
        Me.xMotivoField = value
      End Set
    End Property

    '''<remarks/>
    Public Property chCTe() As String
      Get
        Return Me.chCTeField
      End Get
      Set(ByVal value As String)
        Me.chCTeField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dhRecbto() As Date
      Get
        Return Me.dhRecbtoField
      End Get
      Set(ByVal value As Date)
        Me.dhRecbtoField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property dhRecbtoSpecified() As Boolean
      Get
        Return Me.dhRecbtoFieldSpecified
      End Get
      Set(ByVal value As Boolean)
        Me.dhRecbtoFieldSpecified = value
      End Set
    End Property

    '''<remarks/>
    Public Property nProt() As String
      Get
        Return Me.nProtField
      End Get
      Set(ByVal value As String)
        Me.nProtField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")> _
    Public Property Id() As String
      Get
        Return Me.idField
      End Get
      Set(ByVal value As String)
        Me.idField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte"), _
   System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
  Partial Public Class cteProc

    Private cTeField As TCTe

    Private protCTeField As TProtCTe

    Private versaoField As String

    '''<remarks/>
    Public Property CTe() As TCTe
      Get
        Return Me.cTeField
      End Get
      Set(ByVal value As TCTe)
        Me.cTeField = value
      End Set
    End Property

    '''<remarks/>
    Public Property protCTe() As TProtCTe
      Get
        Return Me.protCTeField
      End Get
      Set(ByVal value As TProtCTe)
        Me.protCTeField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versao() As String
      Get
        Return Me.versaoField
      End Get
      Set(ByVal value As String)
        Me.versaoField = value
      End Set
    End Property

    Public Function ToFile(ByVal onFolder As String) As Boolean
      Try
        Dim fname As String = GetFileName()
        Dim fi As New IO.FileInfo(fname)
        If fi.Exists Then fi.Delete()
        IO.File.WriteAllBytes(fname, ToBytes)
        If Not IO.Directory.Exists(onFolder) Then IO.Directory.CreateDirectory(onFolder)
        IO.File.Move(fname, (onFolder & IO.Path.DirectorySeparatorChar & fname).Replace(New String(IO.Path.DirectorySeparatorChar, 2), IO.Path.DirectorySeparatorChar))
        Return True
      Catch ex As Exception
        Return False
      End Try
    End Function
    Public Function ToBytes() As Byte()
      Return System.Text.Encoding.UTF8.GetBytes(ToString)
    End Function
    Public Function GetFileName() As String
      Return Me.CTe.infCte.Id.Substring(3) & "-procCTe.xml"
    End Function

    Public Function ToXMLNode() As Xml.XmlNode
      Dim xDoc As New Xml.XmlDocument
      xDoc.LoadXml(ToString)
      Return xDoc.DocumentElement
    End Function
    Public Overrides Function ToString() As String
      Dim xs As New XmlSerializer(Me.GetType)
      Dim xmlns As New XmlSerializerNamespaces
      xmlns.Add("", "http://www.portalfiscal.inf.br/cte")
      Dim sw As New IO.StringWriter()
      'Dim ms As New IO.MemoryStream
      Dim tmp As String = IO.Path.GetTempFileName
      Dim sw2 As New IO.StreamWriter(tmp, False, System.Text.Encoding.UTF8)
      xs.Serialize(sw2, Me, xmlns)
      Dim xmlDocument As New XmlDocument
      sw2.Close()
      xmlDocument.Load(tmp)
      Dim r As String = xmlDocument.DocumentElement.OuterXml
      IO.File.Delete(tmp)
      Return r
      'xs.Deserialize
      Return MyBase.ToString()
    End Function
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TProtCTe

    Private infProtField As TProtCTeInfProt

    Private signatureField As SignatureType

    Private versaoField As String

    '''<remarks/>
    Public Property infProt() As TProtCTeInfProt
      Get
        Return Me.infProtField
      End Get
      Set(ByVal value As TProtCTeInfProt)
        Me.infProtField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Public Property Signature() As SignatureType
      Get
        Return Me.signatureField
      End Get
      Set(ByVal value As SignatureType)
        Me.signatureField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versao() As String
      Get
        Return Me.versaoField
      End Get
      Set(ByVal value As String)
        Me.versaoField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TProtCTeInfProt

    Private tpAmbField As String

    Private verAplicField As String

    Private chCTeField As String

    Private dhRecbtoField As Date

    Private nProtField As String

    Private digValField() As Byte

    Private cStatField As String

    Private xMotivoField As String

    Private idField As String

    '''<remarks/>
    Public Property tpAmb() As String
      Get
        Return Me.tpAmbField
      End Get
      Set(ByVal value As String)
        Me.tpAmbField = value
      End Set
    End Property

    '''<remarks/>
    Public Property verAplic() As String
      Get
        Return Me.verAplicField
      End Get
      Set(ByVal value As String)
        Me.verAplicField = value
      End Set
    End Property

    '''<remarks/>
    Public Property chCTe() As String
      Get
        Return Me.chCTeField
      End Get
      Set(ByVal value As String)
        Me.chCTeField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dhRecbto() As Date
      Get
        Return Me.dhRecbtoField
      End Get
      Set(ByVal value As Date)
        Me.dhRecbtoField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nProt() As String
      Get
        Return Me.nProtField
      End Get
      Set(ByVal value As String)
        Me.nProtField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="base64Binary")> _
    Public Property digVal() As Byte()
      Get
        Return Me.digValField
      End Get
      Set(ByVal value As Byte())
        Me.digValField = value
      End Set
    End Property

    '''<remarks/>
    Public Property cStat() As String
      Get
        Return Me.cStatField
      End Get
      Set(ByVal value As String)
        Me.cStatField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xMotivo() As String
      Get
        Return Me.xMotivoField
      End Get
      Set(ByVal value As String)
        Me.xMotivoField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")> _
    Public Property Id() As String
      Get
        Return Me.idField
      End Get
      Set(ByVal value As String)
        Me.idField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte"), _
   System.Xml.Serialization.XmlRootAttribute("procInutCTe", [Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
  Partial Public Class TProcInutCTe

    Private inutCTeField As TInutCTe

    Private retInutCTeField As TRetInutCTe

    Private versaoField As String

    '''<remarks/>
    Public Property inutCTe() As TInutCTe
      Get
        Return Me.inutCTeField
      End Get
      Set(ByVal value As TInutCTe)
        Me.inutCTeField = value
      End Set
    End Property

    '''<remarks/>
    Public Property retInutCTe() As TRetInutCTe
      Get
        Return Me.retInutCTeField
      End Get
      Set(ByVal value As TRetInutCTe)
        Me.retInutCTeField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versao() As String
      Get
        Return Me.versaoField
      End Get
      Set(ByVal value As String)
        Me.versaoField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte"), _
   System.Xml.Serialization.XmlRootAttribute("retInutCTe", [Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
  Partial Public Class TRetInutCTe

    Private infInutField As TRetInutCTeInfInut

    Private signatureField As SignatureType

    Private versaoField As String

    '''<remarks/>
    Public Property infInut() As TRetInutCTeInfInut
      Get
        Return Me.infInutField
      End Get
      Set(ByVal value As TRetInutCTeInfInut)
        Me.infInutField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Public Property Signature() As SignatureType
      Get
        Return Me.signatureField
      End Get
      Set(ByVal value As SignatureType)
        Me.signatureField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versao() As String
      Get
        Return Me.versaoField
      End Get
      Set(ByVal value As String)
        Me.versaoField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TRetInutCTeInfInut

    Private tpAmbField As String

    Private verAplicField As String

    Private cStatField As String

    Private xMotivoField As String

    Private cUFField As String

    Private anoField As Short

    Private anoFieldSpecified As Boolean

    Private cNPJField As String

    Private modField As String

    Private modFieldSpecified As Boolean

    Private serieField As String

    Private nCTIniField As String

    Private nCTFinField As String

    Private dhRecbtoField As Date

    Private dhRecbtoFieldSpecified As Boolean

    Private nProtField As String

    Private idField As String

    '''<remarks/>
    Public Property tpAmb() As String
      Get
        Return Me.tpAmbField
      End Get
      Set(ByVal value As String)
        Me.tpAmbField = value
      End Set
    End Property

    '''<remarks/>
    Public Property verAplic() As String
      Get
        Return Me.verAplicField
      End Get
      Set(ByVal value As String)
        Me.verAplicField = value
      End Set
    End Property

    '''<remarks/>
    Public Property cStat() As String
      Get
        Return Me.cStatField
      End Get
      Set(ByVal value As String)
        Me.cStatField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xMotivo() As String
      Get
        Return Me.xMotivoField
      End Get
      Set(ByVal value As String)
        Me.xMotivoField = value
      End Set
    End Property

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
    Public Property ano() As Short
      Get
        Return Me.anoField
      End Get
      Set(ByVal value As Short)
        Me.anoField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property anoSpecified() As Boolean
      Get
        Return Me.anoFieldSpecified
      End Get
      Set(ByVal value As Boolean)
        Me.anoFieldSpecified = value
      End Set
    End Property

    '''<remarks/>
    Public Property CNPJ() As String
      Get
        Return Me.cNPJField
      End Get
      Set(ByVal value As String)
        Me.cNPJField = value
      End Set
    End Property

    '''<remarks/>
    Public Property [mod]() As String
      Get
        Return Me.modField
      End Get
      Set(ByVal value As String)
        Me.modField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property modSpecified() As Boolean
      Get
        Return Me.modFieldSpecified
      End Get
      Set(ByVal value As Boolean)
        Me.modFieldSpecified = value
      End Set
    End Property

    '''<remarks/>
    Public Property serie() As String
      Get
        Return Me.serieField
      End Get
      Set(ByVal value As String)
        Me.serieField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nCTIni() As String
      Get
        Return Me.nCTIniField
      End Get
      Set(ByVal value As String)
        Me.nCTIniField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nCTFin() As String
      Get
        Return Me.nCTFinField
      End Get
      Set(ByVal value As String)
        Me.nCTFinField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dhRecbto() As Date
      Get
        Return Me.dhRecbtoField
      End Get
      Set(ByVal value As Date)
        Me.dhRecbtoField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property dhRecbtoSpecified() As Boolean
      Get
        Return Me.dhRecbtoFieldSpecified
      End Get
      Set(ByVal value As Boolean)
        Me.dhRecbtoFieldSpecified = value
      End Set
    End Property

    '''<remarks/>
    Public Property nProt() As String
      Get
        Return Me.nProtField
      End Get
      Set(ByVal value As String)
        Me.nProtField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")> _
    Public Property Id() As String
      Get
        Return Me.idField
      End Get
      Set(ByVal value As String)
        Me.idField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte"), _
   System.Xml.Serialization.XmlRootAttribute("retConsReciCTe", [Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
  Partial Public Class TRetConsReciCTe

    Private tpAmbField As String

    Private verAplicField As String

    Private nRecField As String

    Private cStatField As String

    Private xMotivoField As String

    Private cUFField As String

    Private protCTeField() As TProtCTe

    Private versaoField As String

    '''<remarks/>
    Public Property tpAmb() As String
      Get
        Return Me.tpAmbField
      End Get
      Set(ByVal value As String)
        Me.tpAmbField = value
      End Set
    End Property

    '''<remarks/>
    Public Property verAplic() As String
      Get
        Return Me.verAplicField
      End Get
      Set(ByVal value As String)
        Me.verAplicField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nRec() As String
      Get
        Return Me.nRecField
      End Get
      Set(ByVal value As String)
        Me.nRecField = value
      End Set
    End Property

    '''<remarks/>
    Public Property cStat() As String
      Get
        Return Me.cStatField
      End Get
      Set(ByVal value As String)
        Me.cStatField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xMotivo() As String
      Get
        Return Me.xMotivoField
      End Get
      Set(ByVal value As String)
        Me.xMotivoField = value
      End Set
    End Property

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
    <System.Xml.Serialization.XmlElementAttribute("protCTe")> _
    Public Property protCTe() As TProtCTe()
      Get
        Return Me.protCTeField
      End Get
      Set(ByVal value As TProtCTe())
        Me.protCTeField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versao() As String
      Get
        Return Me.versaoField
      End Get
      Set(ByVal value As String)
        Me.versaoField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte"), _
   System.Xml.Serialization.XmlRootAttribute("retConsSitCTe", [Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
  Partial Public Class TRetConsSitCTe

    Private tpAmbField As String

    Private verAplicField As String

    Private cStatField As String

    Private xMotivoField As String

    Private cUFField As String

    Private itemField As Object

    Private versaoField As String

    '''<remarks/>
    Public Property tpAmb() As String
      Get
        Return Me.tpAmbField
      End Get
      Set(ByVal value As String)
        Me.tpAmbField = value
      End Set
    End Property

    '''<remarks/>
    Public Property verAplic() As String
      Get
        Return Me.verAplicField
      End Get
      Set(ByVal value As String)
        Me.verAplicField = value
      End Set
    End Property

    '''<remarks/>
    Public Property cStat() As String
      Get
        Return Me.cStatField
      End Get
      Set(ByVal value As String)
        Me.cStatField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xMotivo() As String
      Get
        Return Me.xMotivoField
      End Get
      Set(ByVal value As String)
        Me.xMotivoField = value
      End Set
    End Property

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
    <System.Xml.Serialization.XmlElementAttribute("protCTe", GetType(TProtCTe)), _
     System.Xml.Serialization.XmlElementAttribute("retCancCTe", GetType(TRetCancCTe))> _
    Public Property Item() As Object
      Get
        Return Me.itemField
      End Get
      Set(ByVal value As Object)
        Me.itemField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versao() As String
      Get
        Return Me.versaoField
      End Get
      Set(ByVal value As String)
        Me.versaoField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte"), _
   System.Xml.Serialization.XmlRootAttribute("retConsStatServCte", [Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
  Partial Public Class TRetConsStatServ

    Private tpAmbField As String

    Private verAplicField As String

    Private cStatField As String

    Private xMotivoField As String

    Private cUFField As String

    Private dhRecbtoField As Date

    Private tMedField As String

    Private dhRetornoField As Date

    Private dhRetornoFieldSpecified As Boolean

    Private xObsField As String

    Private versaoField As String

    '''<remarks/>
    Public Property tpAmb() As String
      Get
        Return Me.tpAmbField
      End Get
      Set(ByVal value As String)
        Me.tpAmbField = value
      End Set
    End Property

    '''<remarks/>
    Public Property verAplic() As String
      Get
        Return Me.verAplicField
      End Get
      Set(ByVal value As String)
        Me.verAplicField = Value
      End Set
    End Property

    '''<remarks/>
    Public Property cStat() As String
      Get
        Return Me.cStatField
      End Get
      Set(ByVal value As String)
        Me.cStatField = Value
      End Set
    End Property

    '''<remarks/>
    Public Property xMotivo() As String
      Get
        Return Me.xMotivoField
      End Get
      Set(ByVal value As String)
        Me.xMotivoField = Value
      End Set
    End Property

    '''<remarks/>
    Public Property cUF() As String
      Get
        Return Me.cUFField
      End Get
      Set(ByVal value As String)
        Me.cUFField = Value
      End Set
    End Property

    '''<remarks/>
    Public Property dhRecbto() As Date
      Get
        Return Me.dhRecbtoField
      End Get
      Set(ByVal value As Date)
        Me.dhRecbtoField = Value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="integer")> _
    Public Property tMed() As String
      Get
        Return Me.tMedField
      End Get
      Set(ByVal value As String)
        Me.tMedField = Value
      End Set
    End Property

    '''<remarks/>
    Public Property dhRetorno() As Date
      Get
        Return Me.dhRetornoField
      End Get
      Set(ByVal value As Date)
        Me.dhRetornoField = Value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property dhRetornoSpecified() As Boolean
      Get
        Return Me.dhRetornoFieldSpecified
      End Get
      Set(ByVal value As Boolean)
        Me.dhRetornoFieldSpecified = Value
      End Set
    End Property

    '''<remarks/>
    Public Property xObs() As String
      Get
        Return Me.xObsField
      End Get
      Set(ByVal value As String)
        Me.xObsField = Value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versao() As String
      Get
        Return Me.versaoField
      End Get
      Set(ByVal value As String)
        Me.versaoField = Value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte"), _
   System.Xml.Serialization.XmlRootAttribute("retEnviCte", [Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
  Partial Public Class TRetEnviCTe

    Private tpAmbField As String

    Private cUFField As String

    Private verAplicField As String

    Private cStatField As String

    Private xMotivoField As String

    Private infRecField As TRetEnviCTeInfRec

    Private versaoField As String

    '''<remarks/>
    Public Property tpAmb() As String
      Get
        Return Me.tpAmbField
      End Get
      Set(ByVal value As String)
        Me.tpAmbField = value
      End Set
    End Property

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
    Public Property verAplic() As String
      Get
        Return Me.verAplicField
      End Get
      Set(ByVal value As String)
        Me.verAplicField = Value
      End Set
    End Property

    '''<remarks/>
    Public Property cStat() As String
      Get
        Return Me.cStatField
      End Get
      Set(ByVal value As String)
        Me.cStatField = Value
      End Set
    End Property

    '''<remarks/>
    Public Property xMotivo() As String
      Get
        Return Me.xMotivoField
      End Get
      Set(ByVal value As String)
        Me.xMotivoField = Value
      End Set
    End Property

    '''<remarks/>
    Public Property infRec() As TRetEnviCTeInfRec
      Get
        Return Me.infRecField
      End Get
      Set(ByVal value As TRetEnviCTeInfRec)
        Me.infRecField = Value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versao() As String
      Get
        Return Me.versaoField
      End Get
      Set(ByVal value As String)
        Me.versaoField = Value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TRetEnviCTeInfRec

    Private nRecField As String

    Private dhRecbtoField As Date

    Private tMedField As String

    '''<remarks/>
    Public Property nRec() As String
      Get
        Return Me.nRecField
      End Get
      Set(ByVal value As String)
        Me.nRecField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dhRecbto() As Date
      Get
        Return Me.dhRecbtoField
      End Get
      Set(ByVal value As Date)
        Me.dhRecbtoField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="integer")> _
    Public Property tMed() As String
      Get
        Return Me.tMedField
      End Get
      Set(ByVal value As String)
        Me.tMedField = value
      End Set
    End Property
  End Class

  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte"), _
   System.Xml.Serialization.XmlRootAttribute("cancCTe", [Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
  Partial Public Class TCancCTe

    Private infCancField As TCancCTeInfCanc

    Private signatureField As SignatureType

    Private versaoField As String
    Sub New()
      infCancField = New TCancCTeInfCanc
    End Sub
    '''<remarks/>
    Public Property infCanc() As TCancCTeInfCanc
      Get
        Return Me.infCancField
      End Get
      Set(ByVal value As TCancCTeInfCanc)
        Me.infCancField = Value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Public Property Signature() As SignatureType
      Get
        Return Me.signatureField
      End Get
      Set(ByVal value As SignatureType)
        Me.signatureField = Value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versao() As String
      Get
        Return Me.versaoField
      End Get
      Set(ByVal value As String)
        Me.versaoField = Value
      End Set
    End Property
    Public Function ToXMLNode() As Xml.XmlNode
      Dim xDoc As New Xml.XmlDocument
      xDoc.LoadXml(ToString)
      Return xDoc.DocumentElement
    End Function
    Public Overrides Function ToString() As String
      Dim xs As New XmlSerializer(Me.GetType)
      Dim xmlns As New XmlSerializerNamespaces
      xmlns.Add("", "http://www.portalfiscal.inf.br/cte")
      Dim sw As New IO.StringWriter()
      'Dim ms As New IO.MemoryStream
      Dim tmp As String = IO.Path.GetTempFileName
      Dim sw2 As New IO.StreamWriter(tmp, False, System.Text.Encoding.UTF8)
      xs.Serialize(sw2, Me, xmlns)
      Dim xmlDocument As New XmlDocument
      sw2.Close()
      xmlDocument.Load(tmp)
      Dim r As String = xmlDocument.DocumentElement.OuterXml
      IO.File.Delete(tmp)
      Return r
      'xs.Deserialize
      Return MyBase.ToString()
    End Function
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TCancCTeInfCanc

    Private tpAmbField As String

    Private xServField As String

    Private chCTeField As String

    Private nProtField As String

    Private xJustField As String

    Private idField As String

    Public Sub New()
      MyBase.New()
      Me.xServField = "CANCELAR"
    End Sub

    '''<remarks/>
    Public Property tpAmb() As String
      Get
        Return Me.tpAmbField
      End Get
      Set(ByVal value As String)
        Me.tpAmbField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xServ() As String
      Get
        Return Me.xServField
      End Get
      Set(ByVal value As String)
        Me.xServField = Value
      End Set
    End Property

    '''<remarks/>
    Public Property chCTe() As String
      Get
        Return Me.chCTeField
      End Get
      Set(ByVal value As String)
        Me.chCTeField = Value
      End Set
    End Property

    '''<remarks/>
    Public Property nProt() As String
      Get
        Return Me.nProtField
      End Get
      Set(ByVal value As String)
        Me.nProtField = Value
      End Set
    End Property

    '''<remarks/>
    Public Property xJust() As String
      Get
        Return Me.xJustField
      End Get
      Set(ByVal value As String)
        Me.xJustField = Value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")> _
    Public Property Id() As String
      Get
        Return Me.idField
      End Get
      Set(ByVal value As String)
        Me.idField = Value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TAmb

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")> _
    Item1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("2")> _
    Item2
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
  Partial Public Class X509DataType

    Private x509CertificateField() As Byte

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="base64Binary")> _
    Public Property X509Certificate() As Byte()
      Get
        Return Me.x509CertificateField
      End Get
      Set(ByVal value As Byte())
        Me.x509CertificateField = Value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
  Partial Public Class KeyInfoType

    Private x509DataField As X509DataType

    Private idField As String

    '''<remarks/>
    Public Property X509Data() As X509DataType
      Get
        Return Me.x509DataField
      End Get
      Set(ByVal value As X509DataType)
        Me.x509DataField = Value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")> _
    Public Property Id() As String
      Get
        Return Me.idField
      End Get
      Set(ByVal value As String)
        Me.idField = Value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
  Partial Public Class SignatureValueType

    Private idField As String

    Private valueField() As Byte

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")> _
    Public Property Id() As String
      Get
        Return Me.idField
      End Get
      Set(ByVal value As String)
        Me.idField = Value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlTextAttribute(DataType:="base64Binary")> _
    Public Property Value() As Byte()
      Get
        Return Me.valueField
      End Get
      Set(ByVal value As Byte())
        Me.valueField = Value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
  Partial Public Class TransformType

    Private xPathField() As String

    Private algorithmField As TTransformURI

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("XPath")> _
    Public Property XPath() As String()
      Get
        Return Me.xPathField
      End Get
      Set(ByVal value As String())
        Me.xPathField = Value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property Algorithm() As TTransformURI
      Get
        Return Me.algorithmField
      End Get
      Set(ByVal value As TTransformURI)
        Me.algorithmField = Value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
  Public Enum TTransformURI

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("http://www.w3.org/2000/09/xmldsig#enveloped-signature")> _
    httpwwww3org200009xmldsigenvelopedsignature

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("http://www.w3.org/TR/2001/REC-xml-c14n-20010315")> _
    httpwwww3orgTR2001RECxmlc14n20010315
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
  Partial Public Class ReferenceType

    Private transformsField() As TransformType

    Private digestMethodField As ReferenceTypeDigestMethod

    Private digestValueField() As Byte

    Private idField As String

    Private uRIField As String

    Private typeField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlArrayItemAttribute("Transform", IsNullable:=False)> _
    Public Property Transforms() As TransformType()
      Get
        Return Me.transformsField
      End Get
      Set(ByVal value As TransformType())
        Me.transformsField = Value
      End Set
    End Property

    '''<remarks/>
    Public Property DigestMethod() As ReferenceTypeDigestMethod
      Get
        Return Me.digestMethodField
      End Get
      Set(ByVal value As ReferenceTypeDigestMethod)
        Me.digestMethodField = Value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="base64Binary")> _
    Public Property DigestValue() As Byte()
      Get
        Return Me.digestValueField
      End Get
      Set(ByVal value As Byte())
        Me.digestValueField = Value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")> _
    Public Property Id() As String
      Get
        Return Me.idField
      End Get
      Set(ByVal value As String)
        Me.idField = Value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute(DataType:="anyURI")> _
    Public Property URI() As String
      Get
        Return Me.uRIField
      End Get
      Set(ByVal value As String)
        Me.uRIField = Value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute(DataType:="anyURI")> _
    Public Property Type() As String
      Get
        Return Me.typeField
      End Get
      Set(ByVal value As String)
        Me.typeField = Value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
  Partial Public Class ReferenceTypeDigestMethod

    Private algorithmField As String

    Public Sub New()
      MyBase.New()
      Me.algorithmField = "http://www.w3.org/2000/09/xmldsig#sha1"
    End Sub

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute(DataType:="anyURI")> _
    Public Property Algorithm() As String
      Get
        Return Me.algorithmField
      End Get
      Set(ByVal value As String)
        Me.algorithmField = Value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
  Partial Public Class SignedInfoType

    Private canonicalizationMethodField As SignedInfoTypeCanonicalizationMethod

    Private signatureMethodField As SignedInfoTypeSignatureMethod

    Private referenceField As ReferenceType

    Private idField As String

    '''<remarks/>
    Public Property CanonicalizationMethod() As SignedInfoTypeCanonicalizationMethod
      Get
        Return Me.canonicalizationMethodField
      End Get
      Set(ByVal value As SignedInfoTypeCanonicalizationMethod)
        Me.canonicalizationMethodField = Value
      End Set
    End Property

    '''<remarks/>
    Public Property SignatureMethod() As SignedInfoTypeSignatureMethod
      Get
        Return Me.signatureMethodField
      End Get
      Set(ByVal value As SignedInfoTypeSignatureMethod)
        Me.signatureMethodField = Value
      End Set
    End Property

    '''<remarks/>
    Public Property Reference() As ReferenceType
      Get
        Return Me.referenceField
      End Get
      Set(ByVal value As ReferenceType)
        Me.referenceField = Value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")> _
    Public Property Id() As String
      Get
        Return Me.idField
      End Get
      Set(ByVal value As String)
        Me.idField = Value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
  Partial Public Class SignedInfoTypeCanonicalizationMethod

    Private algorithmField As String

    Public Sub New()
      MyBase.New()
      Me.algorithmField = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315"
    End Sub

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute(DataType:="anyURI")> _
    Public Property Algorithm() As String
      Get
        Return Me.algorithmField
      End Get
      Set(ByVal value As String)
        Me.algorithmField = Value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
  Partial Public Class SignedInfoTypeSignatureMethod

    Private algorithmField As String

    Public Sub New()
      MyBase.New()
      Me.algorithmField = "http://www.w3.org/2000/09/xmldsig#rsa-sha1"
    End Sub

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute(DataType:="anyURI")> _
    Public Property Algorithm() As String
      Get
        Return Me.algorithmField
      End Get
      Set(ByVal value As String)
        Me.algorithmField = Value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#"), _
   System.Xml.Serialization.XmlRootAttribute("Signature", [Namespace]:="http://www.w3.org/2000/09/xmldsig#", IsNullable:=False)> _
  Partial Public Class SignatureType

    Private signedInfoField As SignedInfoType

    Private signatureValueField As SignatureValueType

    Private keyInfoField As KeyInfoType

    Private idField As String

    '''<remarks/>
    Public Property SignedInfo() As SignedInfoType
      Get
        Return Me.signedInfoField
      End Get
      Set(ByVal value As SignedInfoType)
        Me.signedInfoField = Value
      End Set
    End Property

    '''<remarks/>
    Public Property SignatureValue() As SignatureValueType
      Get
        Return Me.signatureValueField
      End Get
      Set(ByVal value As SignatureValueType)
        Me.signatureValueField = Value
      End Set
    End Property

    '''<remarks/>
    Public Property KeyInfo() As KeyInfoType
      Get
        Return Me.keyInfoField
      End Get
      Set(ByVal value As KeyInfoType)
        Me.keyInfoField = Value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute(DataType:="ID")> _
    Public Property Id() As String
      Get
        Return Me.idField
      End Get
      Set(ByVal value As String)
        Me.idField = Value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte"), _
   System.Xml.Serialization.XmlRootAttribute("consReciCTe", [Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
  Partial Public Class TConsReciCTe

    Private tpAmbField As String

    Private nRecField As String

    Private versaoField As String

    '''<remarks/>
    Public Property tpAmb() As String
      Get
        Return Me.tpAmbField
      End Get
      Set(ByVal value As String)
        Me.tpAmbField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nRec() As String
      Get
        Return Me.nRecField
      End Get
      Set(ByVal value As String)
        Me.nRecField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versao() As String
      Get
        Return Me.versaoField
      End Get
      Set(ByVal value As String)
        Me.versaoField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte"), _
   System.Xml.Serialization.XmlRootAttribute("consSitCTe", [Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
  Partial Public Class TConsSitCTe

    Private tpAmbField As String

    Private xServField As String

    Private chCTeField As String

    Private versaoField As String

    Public Sub New()
      MyBase.New()
      Me.xServField = "CONSULTAR"
    End Sub
    Sub New(ByVal Ambiente As String, ByVal chaveAcesso As String)
      MyBase.New()
      tpAmb = Ambiente
      chCTeField = chaveAcesso
      versaoField = "1.04"
      xServField = "CONSULTAR"
    End Sub
    '''<remarks/>
    Public Property tpAmb() As String
      Get
        Return Me.tpAmbField
      End Get
      Set(ByVal value As String)
        Me.tpAmbField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xServ() As String
      Get
        Return Me.xServField
      End Get
      Set(ByVal value As String)
        Me.xServField = value
      End Set
    End Property

    '''<remarks/>
    Public Property chCTe() As String
      Get
        Return Me.chCTeField
      End Get
      Set(ByVal value As String)
        Me.chCTeField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versao() As String
      Get
        Return Me.versaoField
      End Get
      Set(ByVal value As String)
        Me.versaoField = value
      End Set
    End Property

   
    Public Function ToXMLNode() As Xml.XmlNode
      Dim xDoc As New Xml.XmlDocument
      xDoc.LoadXml(ToString)
      Return xDoc.DocumentElement
    End Function
    Public Overrides Function ToString() As String
      Dim xs As New XmlSerializer(Me.GetType)
      Dim xmlns As New XmlSerializerNamespaces
      xmlns.Add("", "http://www.portalfiscal.inf.br/cte")
      Dim sw As New IO.StringWriter()
      'Dim ms As New IO.MemoryStream
      Dim tmp As String = IO.Path.GetTempFileName
      Dim sw2 As New IO.StreamWriter(tmp, False, System.Text.Encoding.UTF8)
      xs.Serialize(sw2, Me, xmlns)
      Dim xmlDocument As New XmlDocument
      sw2.Close()
      xmlDocument.Load(tmp)
      Dim r As String = xmlDocument.DocumentElement.OuterXml
      IO.File.Delete(tmp)
      Return r
      'xs.Deserialize
      Return MyBase.ToString()
    End Function
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte"), _
   System.Xml.Serialization.XmlRootAttribute("consStatServCte", [Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
  Partial Public Class TConsStatServ

    Private tpAmbField As String

    Private xServField As String

    Private versaoField As String

    Public Sub New()
      MyBase.New()
      Me.xServField = "STATUS"
    End Sub

    '''<remarks/>
    Public Property tpAmb() As String
      Get
        Return Me.tpAmbField
      End Get
      Set(ByVal value As String)
        Me.tpAmbField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xServ() As String
      Get
        Return Me.xServField
      End Get
      Set(ByVal value As String)
        Me.xServField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versao() As String
      Get
        Return Me.versaoField
      End Get
      Set(ByVal value As String)
        Me.versaoField = value
      End Set
    End Property
    Public Function ToXMLNode() As Xml.XmlNode
      Dim xDoc As New Xml.XmlDocument
      xDoc.LoadXml(ToString)
      Return xDoc.DocumentElement
    End Function
    Public Overrides Function ToString() As String
      Dim xs As New XmlSerializer(Me.GetType)
      Dim xmlns As New XmlSerializerNamespaces
      xmlns.Add("", "http://www.portalfiscal.inf.br/cte")
      Dim sw As New IO.StringWriter()
      'Dim ms As New IO.MemoryStream
      Dim tmp As String = IO.Path.GetTempFileName
      Dim sw2 As New IO.StreamWriter(tmp, False, System.Text.Encoding.UTF8)
      xs.Serialize(sw2, Me, xmlns)
      Dim xmlDocument As New XmlDocument
      sw2.Close()
      xmlDocument.Load(tmp)
      Dim r As String = xmlDocument.DocumentElement.OuterXml
      IO.File.Delete(tmp)
      Return r
      'xs.Deserialize
      Return MyBase.ToString()
    End Function
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte"), _
   System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
  Partial Public Class aereo

    Private nMinuField As String

    Private nOCAField As String

    Private dPrevField As String

    Private xLAgEmiField As String

    Private idTField As String

    Private tarifaField As aereoTarifa

    Private natCargaField As aereoNatCarga

    '''<remarks/>
    Public Property nMinu() As String
      Get
        Return Me.nMinuField
      End Get
      Set(ByVal value As String)
        Me.nMinuField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nOCA() As String
      Get
        Return Me.nOCAField
      End Get
      Set(ByVal value As String)
        Me.nOCAField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dPrev() As String
      Get
        Return Me.dPrevField
      End Get
      Set(ByVal value As String)
        Me.dPrevField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xLAgEmi() As String
      Get
        Return Me.xLAgEmiField
      End Get
      Set(ByVal value As String)
        Me.xLAgEmiField = value
      End Set
    End Property

    '''<remarks/>
    Public Property IdT() As String
      Get
        Return Me.idTField
      End Get
      Set(ByVal value As String)
        Me.idTField = value
      End Set
    End Property

    '''<remarks/>
    Public Property tarifa() As aereoTarifa
      Get
        Return Me.tarifaField
      End Get
      Set(ByVal value As aereoTarifa)
        Me.tarifaField = value
      End Set
    End Property

    '''<remarks/>
    Public Property natCarga() As aereoNatCarga
      Get
        Return Me.natCargaField
      End Get
      Set(ByVal value As aereoNatCarga)
        Me.natCargaField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class aereoTarifa

    Private clField As String

    Private cTarField As String

    Private vTarField As String

    '''<remarks/>
    Public Property CL() As String
      Get
        Return Me.clField
      End Get
      Set(ByVal value As String)
        Me.clField = value
      End Set
    End Property

    '''<remarks/>
    Public Property cTar() As String
      Get
        Return Me.cTarField
      End Get
      Set(ByVal value As String)
        Me.cTarField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vTar() As String
      Get
        Return Me.vTarField
      End Get
      Set(ByVal value As String)
        Me.vTarField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class aereoNatCarga

    Private xDimeField As String

    Private cInfManuField() As aereoNatCargaCInfManu

    Private cIMPField() As String

    '''<remarks/>
    Public Property xDime() As String
      Get
        Return Me.xDimeField
      End Get
      Set(ByVal value As String)
        Me.xDimeField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("cInfManu")> _
    Public Property cInfManu() As aereoNatCargaCInfManu()
      Get
        Return Me.cInfManuField
      End Get
      Set(ByVal value As aereoNatCargaCInfManu())
        Me.cInfManuField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("cIMP")> _
    Public Property cIMP() As String()
      Get
        Return Me.cIMPField
      End Get
      Set(ByVal value As String())
        Me.cIMPField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum aereoNatCargaCInfManu

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")> _
    Item1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("2")> _
    Item2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("3")> _
    Item3

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("4")> _
    Item4

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("5")> _
    Item5

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("6")> _
    Item6

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("7")> _
    Item7

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("8")> _
    Item8

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("9")> _
    Item9

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("99")> _
    Item99
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte"), _
   System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
  Partial Public Class aquav

    Private vPrestField As String

    Private vAFRMMField As String

    Private nBookingField As String

    Private nCtrlField As String

    Private xNavioField As String

    Private balsaField() As aquavBalsa

    Private nViagField As String

    Private direcField As aquavDirec

    Private prtEmbField As String

    Private prtTransField As String

    Private prtDestField As String

    Private tpNavField As aquavTpNav

    Private tpNavFieldSpecified As Boolean

    Private irinField As String

    Private detContField() As aquavDetCont

    '''<remarks/>
    Public Property vPrest() As String
      Get
        Return Me.vPrestField
      End Get
      Set(ByVal value As String)
        Me.vPrestField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vAFRMM() As String
      Get
        Return Me.vAFRMMField
      End Get
      Set(ByVal value As String)
        Me.vAFRMMField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nBooking() As String
      Get
        Return Me.nBookingField
      End Get
      Set(ByVal value As String)
        Me.nBookingField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nCtrl() As String
      Get
        Return Me.nCtrlField
      End Get
      Set(ByVal value As String)
        Me.nCtrlField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xNavio() As String
      Get
        Return Me.xNavioField
      End Get
      Set(ByVal value As String)
        Me.xNavioField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("balsa")> _
    Public Property balsa() As aquavBalsa()
      Get
        Return Me.balsaField
      End Get
      Set(ByVal value As aquavBalsa())
        Me.balsaField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nViag() As String
      Get
        Return Me.nViagField
      End Get
      Set(ByVal value As String)
        Me.nViagField = value
      End Set
    End Property

    '''<remarks/>
    Public Property direc() As aquavDirec
      Get
        Return Me.direcField
      End Get
      Set(ByVal value As aquavDirec)
        Me.direcField = value
      End Set
    End Property

    '''<remarks/>
    Public Property prtEmb() As String
      Get
        Return Me.prtEmbField
      End Get
      Set(ByVal value As String)
        Me.prtEmbField = value
      End Set
    End Property

    '''<remarks/>
    Public Property prtTrans() As String
      Get
        Return Me.prtTransField
      End Get
      Set(ByVal value As String)
        Me.prtTransField = value
      End Set
    End Property

    '''<remarks/>
    Public Property prtDest() As String
      Get
        Return Me.prtDestField
      End Get
      Set(ByVal value As String)
        Me.prtDestField = value
      End Set
    End Property

    '''<remarks/>
    Public Property tpNav() As aquavTpNav
      Get
        Return Me.tpNavField
      End Get
      Set(ByVal value As aquavTpNav)
        Me.tpNavField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property tpNavSpecified() As Boolean
      Get
        Return Me.tpNavFieldSpecified
      End Get
      Set(ByVal value As Boolean)
        Me.tpNavFieldSpecified = value
      End Set
    End Property

    '''<remarks/>
    Public Property irin() As String
      Get
        Return Me.irinField
      End Get
      Set(ByVal value As String)
        Me.irinField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("detCont")> _
    Public Property detCont() As aquavDetCont()
      Get
        Return Me.detContField
      End Get
      Set(ByVal value As aquavDetCont())
        Me.detContField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class aquavBalsa

    Private xBalsaField As String

    '''<remarks/>
    Public Property xBalsa() As String
      Get
        Return Me.xBalsaField
      End Get
      Set(ByVal value As String)
        Me.xBalsaField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum aquavDirec

    '''<remarks/>
    N

    '''<remarks/>
    S

    '''<remarks/>
    L

    '''<remarks/>
    O
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum aquavTpNav

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("0")> _
    Item0

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")> _
    Item1
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class aquavDetCont

    Private nContField As String

    Private lacreField() As aquavDetContLacre

    Private infDocField As aquavDetContInfDoc

    '''<remarks/>
    Public Property nCont() As String
      Get
        Return Me.nContField
      End Get
      Set(ByVal value As String)
        Me.nContField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("lacre")> _
    Public Property lacre() As aquavDetContLacre()
      Get
        Return Me.lacreField
      End Get
      Set(ByVal value As aquavDetContLacre())
        Me.lacreField = value
      End Set
    End Property

    '''<remarks/>
    Public Property infDoc() As aquavDetContInfDoc
      Get
        Return Me.infDocField
      End Get
      Set(ByVal value As aquavDetContInfDoc)
        Me.infDocField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class aquavDetContLacre

    Private nLacreField As String

    '''<remarks/>
    Public Property nLacre() As String
      Get
        Return Me.nLacreField
      End Get
      Set(ByVal value As String)
        Me.nLacreField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class aquavDetContInfDoc

    Private itemsField() As Object

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("infNF", GetType(aquavDetContInfDocInfNF)), _
     System.Xml.Serialization.XmlElementAttribute("infNFe", GetType(aquavDetContInfDocInfNFe))> _
    Public Property Items() As Object()
      Get
        Return Me.itemsField
      End Get
      Set(ByVal value As Object())
        Me.itemsField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class aquavDetContInfDocInfNF

    Private serieField As String

    Private nDocField As String

    Private unidRatField As String

    '''<remarks/>
    Public Property serie() As String
      Get
        Return Me.serieField
      End Get
      Set(ByVal value As String)
        Me.serieField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nDoc() As String
      Get
        Return Me.nDocField
      End Get
      Set(ByVal value As String)
        Me.nDocField = value
      End Set
    End Property

    '''<remarks/>
    Public Property unidRat() As String
      Get
        Return Me.unidRatField
      End Get
      Set(ByVal value As String)
        Me.unidRatField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class aquavDetContInfDocInfNFe

    Private chaveField As String

    Private unidRatField As String

    '''<remarks/>
    Public Property chave() As String
      Get
        Return Me.chaveField
      End Get
      Set(ByVal value As String)
        Me.chaveField = value
      End Set
    End Property

    '''<remarks/>
    Public Property unidRat() As String
      Get
        Return Me.unidRatField
      End Get
      Set(ByVal value As String)
        Me.unidRatField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte"), _
   System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
  Partial Public Class duto

    Private vTarField As String

    Private dIniField As String

    Private dFimField As String

    '''<remarks/>
    Public Property vTar() As String
      Get
        Return Me.vTarField
      End Get
      Set(ByVal value As String)
        Me.vTarField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dIni() As String
      Get
        Return Me.dIniField
      End Get
      Set(ByVal value As String)
        Me.dIniField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dFim() As String
      Get
        Return Me.dFimField
      End Get
      Set(ByVal value As String)
        Me.dFimField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte"), _
   System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
  Partial Public Class ferrov

    Private tpTrafField As ferrovTpTraf

    Private trafMutField As ferrovTrafMut

    Private fluxoField As String

    Private idTremField As String

    Private vFreteField As String

    Private ferroEnvField() As ferrovFerroEnv

    Private detVagField() As ferrovDetVag

    '''<remarks/>
    Public Property tpTraf() As ferrovTpTraf
      Get
        Return Me.tpTrafField
      End Get
      Set(ByVal value As ferrovTpTraf)
        Me.tpTrafField = value
      End Set
    End Property

    '''<remarks/>
    Public Property trafMut() As ferrovTrafMut
      Get
        Return Me.trafMutField
      End Get
      Set(ByVal value As ferrovTrafMut)
        Me.trafMutField = value
      End Set
    End Property

    '''<remarks/>
    Public Property fluxo() As String
      Get
        Return Me.fluxoField
      End Get
      Set(ByVal value As String)
        Me.fluxoField = value
      End Set
    End Property

    '''<remarks/>
    Public Property idTrem() As String
      Get
        Return Me.idTremField
      End Get
      Set(ByVal value As String)
        Me.idTremField = value
      End Set
    End Property

    '''<remarks/>
    Public Property vFrete() As String
      Get
        Return Me.vFreteField
      End Get
      Set(ByVal value As String)
        Me.vFreteField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("ferroEnv")> _
    Public Property ferroEnv() As ferrovFerroEnv()
      Get
        Return Me.ferroEnvField
      End Get
      Set(ByVal value As ferrovFerroEnv())
        Me.ferroEnvField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("detVag")> _
    Public Property detVag() As ferrovDetVag()
      Get
        Return Me.detVagField
      End Get
      Set(ByVal value As ferrovDetVag())
        Me.detVagField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum ferrovTpTraf

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("0")> _
    Item0

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")> _
    Item1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("2")> _
    Item2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("3")> _
    Item3
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class ferrovTrafMut

    Private respFatField As ferrovTrafMutRespFat

    Private ferrEmiField As ferrovTrafMutFerrEmi

    '''<remarks/>
    Public Property respFat() As ferrovTrafMutRespFat
      Get
        Return Me.respFatField
      End Get
      Set(ByVal value As ferrovTrafMutRespFat)
        Me.respFatField = value
      End Set
    End Property

    '''<remarks/>
    Public Property ferrEmi() As ferrovTrafMutFerrEmi
      Get
        Return Me.ferrEmiField
      End Get
      Set(ByVal value As ferrovTrafMutFerrEmi)
        Me.ferrEmiField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum ferrovTrafMutRespFat

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")> _
    Item1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("2")> _
    Item2
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum ferrovTrafMutFerrEmi

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")> _
    Item1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("2")> _
    Item2
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class ferrovFerroEnv

    Private cNPJField As String

    Private cIntField As String

    Private ieField As String

    Private xNomeField As String

    Private enderFerroField As TEnderFer

    '''<remarks/>
    Public Property CNPJ() As String
      Get
        Return Me.cNPJField
      End Get
      Set(ByVal value As String)
        Me.cNPJField = value
      End Set
    End Property

    '''<remarks/>
    Public Property [cInt]() As String
      Get
        Return Me.cIntField
      End Get
      Set(ByVal value As String)
        Me.cIntField = value
      End Set
    End Property

    '''<remarks/>
    Public Property IE() As String
      Get
        Return Me.ieField
      End Get
      Set(ByVal value As String)
        Me.ieField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xNome() As String
      Get
        Return Me.xNomeField
      End Get
      Set(ByVal value As String)
        Me.xNomeField = value
      End Set
    End Property

    '''<remarks/>
    Public Property enderFerro() As TEnderFer
      Get
        Return Me.enderFerroField
      End Get
      Set(ByVal value As TEnderFer)
        Me.enderFerroField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class TEnderFer

    Private xLgrField As String

    Private nroField As String

    Private xCplField As String

    Private xBairroField As String

    Private cMunField As String

    Private xMunField As String

    Private cEPField As String

    Private ufField As String

    '''<remarks/>
    Public Property xLgr() As String
      Get
        Return Me.xLgrField
      End Get
      Set(ByVal value As String)
        Me.xLgrField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nro() As String
      Get
        Return Me.nroField
      End Get
      Set(ByVal value As String)
        Me.nroField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xCpl() As String
      Get
        Return Me.xCplField
      End Get
      Set(ByVal value As String)
        Me.xCplField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xBairro() As String
      Get
        Return Me.xBairroField
      End Get
      Set(ByVal value As String)
        Me.xBairroField = value
      End Set
    End Property

    '''<remarks/>
    Public Property cMun() As String
      Get
        Return Me.cMunField
      End Get
      Set(ByVal value As String)
        Me.cMunField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xMun() As String
      Get
        Return Me.xMunField
      End Get
      Set(ByVal value As String)
        Me.xMunField = value
      End Set
    End Property

    '''<remarks/>
    Public Property CEP() As String
      Get
        Return Me.cEPField
      End Get
      Set(ByVal value As String)
        Me.cEPField = value
      End Set
    End Property

    '''<remarks/>
    Public Property UF() As String
      Get
        Return Me.ufField
      End Get
      Set(ByVal value As String)
        Me.ufField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum TUf

    '''<remarks/>
    AC

    '''<remarks/>
    AL

    '''<remarks/>
    AM

    '''<remarks/>
    AP

    '''<remarks/>
    BA

    '''<remarks/>
    CE

    '''<remarks/>
    DF

    '''<remarks/>
    ES

    '''<remarks/>
    GO

    '''<remarks/>
    MA

    '''<remarks/>
    MG

    '''<remarks/>
    MS

    '''<remarks/>
    MT

    '''<remarks/>
    PA

    '''<remarks/>
    PB

    '''<remarks/>
    PE

    '''<remarks/>
    PI

    '''<remarks/>
    PR

    '''<remarks/>
    RJ

    '''<remarks/>
    RN

    '''<remarks/>
    RO

    '''<remarks/>
    RR

    '''<remarks/>
    RS

    '''<remarks/>
    SC

    '''<remarks/>
    SE

    '''<remarks/>
    SP

    '''<remarks/>
    [TO]

    '''<remarks/>
    EX
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class ferrovDetVag

    Private nVagField As String

    Private capField As String

    Private tpVagField As String

    Private pesoRField As String

    Private pesoBCField As String

    Private lacDetVagField() As ferrovDetVagLacDetVag

    Private contVagField() As ferrovDetVagContVag

    Private ratVagField As ferrovDetVagRatVag

    '''<remarks/>
    Public Property nVag() As String
      Get
        Return Me.nVagField
      End Get
      Set(ByVal value As String)
        Me.nVagField = value
      End Set
    End Property

    '''<remarks/>
    Public Property cap() As String
      Get
        Return Me.capField
      End Get
      Set(ByVal value As String)
        Me.capField = value
      End Set
    End Property

    '''<remarks/>
    Public Property tpVag() As String
      Get
        Return Me.tpVagField
      End Get
      Set(ByVal value As String)
        Me.tpVagField = value
      End Set
    End Property

    '''<remarks/>
    Public Property pesoR() As String
      Get
        Return Me.pesoRField
      End Get
      Set(ByVal value As String)
        Me.pesoRField = value
      End Set
    End Property

    '''<remarks/>
    Public Property pesoBC() As String
      Get
        Return Me.pesoBCField
      End Get
      Set(ByVal value As String)
        Me.pesoBCField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("lacDetVag")> _
    Public Property lacDetVag() As ferrovDetVagLacDetVag()
      Get
        Return Me.lacDetVagField
      End Get
      Set(ByVal value As ferrovDetVagLacDetVag())
        Me.lacDetVagField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("contVag")> _
    Public Property contVag() As ferrovDetVagContVag()
      Get
        Return Me.contVagField
      End Get
      Set(ByVal value As ferrovDetVagContVag())
        Me.contVagField = value
      End Set
    End Property

    '''<remarks/>
    Public Property ratVag() As ferrovDetVagRatVag
      Get
        Return Me.ratVagField
      End Get
      Set(ByVal value As ferrovDetVagRatVag)
        Me.ratVagField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class ferrovDetVagLacDetVag

    Private nLacreField As String

    '''<remarks/>
    Public Property nLacre() As String
      Get
        Return Me.nLacreField
      End Get
      Set(ByVal value As String)
        Me.nLacreField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class ferrovDetVagContVag

    Private nContField As String

    Private dPrevField As String

    '''<remarks/>
    Public Property nCont() As String
      Get
        Return Me.nContField
      End Get
      Set(ByVal value As String)
        Me.nContField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dPrev() As String
      Get
        Return Me.dPrevField
      End Get
      Set(ByVal value As String)
        Me.dPrevField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class ferrovDetVagRatVag

    Private itemsField() As Object

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("ratNF", GetType(ferrovDetVagRatVagRatNF)), _
     System.Xml.Serialization.XmlElementAttribute("ratNFe", GetType(ferrovDetVagRatVagRatNFe))> _
    Public Property Items() As Object()
      Get
        Return Me.itemsField
      End Get
      Set(ByVal value As Object())
        Me.itemsField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class ferrovDetVagRatVagRatNF

    Private serieField As String

    Private nDocField As String

    Private pesoRatField As String

    '''<remarks/>
    Public Property serie() As String
      Get
        Return Me.serieField
      End Get
      Set(ByVal value As String)
        Me.serieField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nDoc() As String
      Get
        Return Me.nDocField
      End Get
      Set(ByVal value As String)
        Me.nDocField = value
      End Set
    End Property

    '''<remarks/>
    Public Property pesoRat() As String
      Get
        Return Me.pesoRatField
      End Get
      Set(ByVal value As String)
        Me.pesoRatField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class ferrovDetVagRatVagRatNFe

    Private chaveField As String

    Private pesoRatField As String

    '''<remarks/>
    Public Property chave() As String
      Get
        Return Me.chaveField
      End Get
      Set(ByVal value As String)
        Me.chaveField = value
      End Set
    End Property

    '''<remarks/>
    Public Property pesoRat() As String
      Get
        Return Me.pesoRatField
      End Get
      Set(ByVal value As String)
        Me.pesoRatField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte"), _
   System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte", IsNullable:=False)> _
  Partial Public Class rodo

    Private rNTRCField As String

    Private dPrevField As String

    Private lotaField As rodoLota

    Private cIOTField As String

    Private occField() As rodoOcc

    Private valePedField() As rodoValePed

    Private veicField() As rodoVeic

    Private lacRodoField() As rodoLacRodo

    Private motoField() As rodoMoto

    '''<remarks/>
    Public Property RNTRC() As String
      Get
        Return Me.rNTRCField
      End Get
      Set(ByVal value As String)
        Me.rNTRCField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dPrev() As String
      Get
        Return Me.dPrevField
      End Get
      Set(ByVal value As String)
        Me.dPrevField = value
      End Set
    End Property

    '''<remarks/>
    Public Property lota() As rodoLota
      Get
        Return Me.lotaField
      End Get
      Set(ByVal value As rodoLota)
        Me.lotaField = value
      End Set
    End Property

    '''<remarks/>
    Public Property CIOT() As String
      Get
        Return Me.cIOTField
      End Get
      Set(ByVal value As String)
        Me.cIOTField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("occ")> _
    Public Property occ() As rodoOcc()
      Get
        Return Me.occField
      End Get
      Set(ByVal value As rodoOcc())
        Me.occField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("valePed")> _
    Public Property valePed() As rodoValePed()
      Get
        Return Me.valePedField
      End Get
      Set(ByVal value As rodoValePed())
        Me.valePedField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("veic")> _
    Public Property veic() As rodoVeic()
      Get
        Return Me.veicField
      End Get
      Set(ByVal value As rodoVeic())
        Me.veicField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("lacRodo")> _
    Public Property lacRodo() As rodoLacRodo()
      Get
        Return Me.lacRodoField
      End Get
      Set(ByVal value As rodoLacRodo())
        Me.lacRodoField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("moto")> _
    Public Property moto() As rodoMoto()
      Get
        Return Me.motoField
      End Get
      Set(ByVal value As rodoMoto())
        Me.motoField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum rodoLota

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("0")> _
    Item0

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")> _
    Item1
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class rodoOcc

    Private serieField As String

    Private nOccField As String

    Private dEmiField As String

    Private emiOccField As rodoOccEmiOcc

    '''<remarks/>
    Public Property serie() As String
      Get
        Return Me.serieField
      End Get
      Set(ByVal value As String)
        Me.serieField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nOcc() As String
      Get
        Return Me.nOccField
      End Get
      Set(ByVal value As String)
        Me.nOccField = value
      End Set
    End Property

    '''<remarks/>
    Public Property dEmi() As String
      Get
        Return Me.dEmiField
      End Get
      Set(ByVal value As String)
        Me.dEmiField = value
      End Set
    End Property

    '''<remarks/>
    Public Property emiOcc() As rodoOccEmiOcc
      Get
        Return Me.emiOccField
      End Get
      Set(ByVal value As rodoOccEmiOcc)
        Me.emiOccField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class rodoOccEmiOcc

    Private cNPJField As String

    Private cIntField As String

    Private ieField As String

    Private ufField As String

    Private foneField As String

    '''<remarks/>
    Public Property CNPJ() As String
      Get
        Return Me.cNPJField
      End Get
      Set(ByVal value As String)
        Me.cNPJField = value
      End Set
    End Property

    '''<remarks/>
    Public Property [cInt]() As String
      Get
        Return Me.cIntField
      End Get
      Set(ByVal value As String)
        Me.cIntField = value
      End Set
    End Property

    '''<remarks/>
    Public Property IE() As String
      Get
        Return Me.ieField
      End Get
      Set(ByVal value As String)
        Me.ieField = value
      End Set
    End Property

    '''<remarks/>
    Public Property UF() As String
      Get
        Return Me.ufField
      End Get
      Set(ByVal value As String)
        Me.ufField = value
      End Set
    End Property

    '''<remarks/>
    Public Property fone() As String
      Get
        Return Me.foneField
      End Get
      Set(ByVal value As String)
        Me.foneField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class rodoValePed

    Private cNPJFornField As String

    Private nCompraField As String

    Private cNPJPgField As String

    '''<remarks/>
    Public Property CNPJForn() As String
      Get
        Return Me.cNPJFornField
      End Get
      Set(ByVal value As String)
        Me.cNPJFornField = value
      End Set
    End Property

    '''<remarks/>
    Public Property nCompra() As String
      Get
        Return Me.nCompraField
      End Get
      Set(ByVal value As String)
        Me.nCompraField = value
      End Set
    End Property

    '''<remarks/>
    Public Property CNPJPg() As String
      Get
        Return Me.cNPJPgField
      End Get
      Set(ByVal value As String)
        Me.cNPJPgField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class rodoVeic

    Private cIntField As String

    Private rENAVAMField As String

    Private placaField As String

    Private taraField As String

    Private capKGField As String

    Private capM3Field As String

    Private tpPropField As rodoVeicTpProp

    Private tpVeicField As rodoVeicTpVeic

    Private tpRodField As rodoVeicTpRod

    Private tpCarField As rodoVeicTpCar

    Private ufField As String

    Private propField As rodoVeicProp

    '''<remarks/>
    Public Property [cInt]() As String
      Get
        Return Me.cIntField
      End Get
      Set(ByVal value As String)
        Me.cIntField = value
      End Set
    End Property

    '''<remarks/>
    Public Property RENAVAM() As String
      Get
        Return Me.rENAVAMField
      End Get
      Set(ByVal value As String)
        Me.rENAVAMField = value
      End Set
    End Property

    '''<remarks/>
    Public Property placa() As String
      Get
        Return Me.placaField
      End Get
      Set(ByVal value As String)
        Me.placaField = value
      End Set
    End Property

    '''<remarks/>
    Public Property tara() As String
      Get
        Return Me.taraField
      End Get
      Set(ByVal value As String)
        Me.taraField = value
      End Set
    End Property

    '''<remarks/>
    Public Property capKG() As String
      Get
        Return Me.capKGField
      End Get
      Set(ByVal value As String)
        Me.capKGField = value
      End Set
    End Property

    '''<remarks/>
    Public Property capM3() As String
      Get
        Return Me.capM3Field
      End Get
      Set(ByVal value As String)
        Me.capM3Field = value
      End Set
    End Property

    '''<remarks/>
    Public Property tpProp() As rodoVeicTpProp
      Get
        Return Me.tpPropField
      End Get
      Set(ByVal value As rodoVeicTpProp)
        Me.tpPropField = value
      End Set
    End Property

    '''<remarks/>
    Public Property tpVeic() As rodoVeicTpVeic
      Get
        Return Me.tpVeicField
      End Get
      Set(ByVal value As rodoVeicTpVeic)
        Me.tpVeicField = value
      End Set
    End Property

    '''<remarks/>
    Public Property tpRod() As rodoVeicTpRod
      Get
        Return Me.tpRodField
      End Get
      Set(ByVal value As rodoVeicTpRod)
        Me.tpRodField = value
      End Set
    End Property

    '''<remarks/>
    Public Property tpCar() As rodoVeicTpCar
      Get
        Return Me.tpCarField
      End Get
      Set(ByVal value As rodoVeicTpCar)
        Me.tpCarField = value
      End Set
    End Property

    '''<remarks/>
    Public Property UF() As String
      Get
        Return Me.ufField
      End Get
      Set(ByVal value As String)
        Me.ufField = value
      End Set
    End Property

    '''<remarks/>
    Public Property prop() As rodoVeicProp
      Get
        Return Me.propField
      End Get
      Set(ByVal value As rodoVeicProp)
        Me.propField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum rodoVeicTpProp

    '''<remarks/>
    P

    '''<remarks/>
    T
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum rodoVeicTpVeic

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("0")> _
    Item0

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")> _
    Item1
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum rodoVeicTpRod

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("00")> _
    Item00

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("01")> _
    Item01

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("02")> _
    Item02

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("03")> _
    Item03

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("04")> _
    Item04

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("05")> _
    Item05

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("06")> _
    Item06
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum rodoVeicTpCar

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("00")> _
    Item00

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("01")> _
    Item01

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("02")> _
    Item02

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("03")> _
    Item03

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("04")> _
    Item04

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("05")> _
    Item05
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class rodoVeicProp

    Private itemField As String

    Private itemElementNameField As ItemChoiceType

    Private rNTRCField As String

    Private xNomeField As String

    Private ieField As String

    Private ufField As String

    Private tpPropField As rodoVeicPropTpProp

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("CNPJ", GetType(String)), _
     System.Xml.Serialization.XmlElementAttribute("CPF", GetType(String)), _
     System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")> _
    Public Property Item() As String
      Get
        Return Me.itemField
      End Get
      Set(ByVal value As String)
        Me.itemField = value
      End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property ItemElementName() As ItemChoiceType
      Get
        Return Me.itemElementNameField
      End Get
      Set(ByVal value As ItemChoiceType)
        Me.itemElementNameField = value
      End Set
    End Property

    '''<remarks/>
    Public Property RNTRC() As String
      Get
        Return Me.rNTRCField
      End Get
      Set(ByVal value As String)
        Me.rNTRCField = value
      End Set
    End Property

    '''<remarks/>
    Public Property xNome() As String
      Get
        Return Me.xNomeField
      End Get
      Set(ByVal value As String)
        Me.xNomeField = value
      End Set
    End Property

    '''<remarks/>
    Public Property IE() As String
      Get
        Return Me.ieField
      End Get
      Set(ByVal value As String)
        Me.ieField = value
      End Set
    End Property

    '''<remarks/>
    Public Property UF() As String
      Get
        Return Me.ufField
      End Get
      Set(ByVal value As String)
        Me.ufField = value
      End Set
    End Property

    '''<remarks/>
    Public Property tpProp() As rodoVeicPropTpProp
      Get
        Return Me.tpPropField
      End Get
      Set(ByVal value As rodoVeicPropTpProp)
        Me.tpPropField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/cte", IncludeInSchema:=False)> _
  Public Enum ItemChoiceType

    '''<remarks/>
    CNPJ

    '''<remarks/>
    CPF
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Public Enum rodoVeicPropTpProp

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("0")> _
    Item0

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")> _
    Item1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("2")> _
    Item2
  End Enum

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class rodoLacRodo

    Private nLacreField As String

    '''<remarks/>
    Public Property nLacre() As String
      Get
        Return Me.nLacreField
      End Get
      Set(ByVal value As String)
        Me.nLacreField = value
      End Set
    End Property
  End Class

  '''<remarks/>
  <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
   System.SerializableAttribute(), _
   System.Diagnostics.DebuggerStepThroughAttribute(), _
   System.ComponentModel.DesignerCategoryAttribute("code"), _
   System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/cte")> _
  Partial Public Class rodoMoto

    Private xNomeField As String

    Private cPFField As String

    '''<remarks/>
    Public Property xNome() As String
      Get
        Return Me.xNomeField
      End Get
      Set(ByVal value As String)
        Me.xNomeField = value
      End Set
    End Property

    '''<remarks/>
    Public Property CPF() As String
      Get
        Return Me.cPFField
      End Get
      Set(ByVal value As String)
        Me.cPFField = value
      End Set
    End Property
  End Class



End Namespace