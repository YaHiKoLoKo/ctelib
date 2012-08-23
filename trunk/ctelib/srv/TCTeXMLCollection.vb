Imports System.Runtime.Serialization.Formatters.Binary
Imports ctelib.CTe.Types
Imports System.Xml
Imports System.Xml.Serialization
<Serializable(), _
 XmlType("CTeXMLCollection", namespace:="http://ctelib.googlecode.com/"), _
 XmlRoot("CTeXMLCollection", namespace:="http://ctelib.googlecode.com/")> _
Public Class TCTeXMLCollection
  Private Shared stringConversionMode As StringConversionModes = StringConversionModes.BinaryString
  Private itemField() As Object
  Private itemElementNameField() As TCTeXMLCollectionElementName
  Public Enum StringConversionModes
    BinaryString
    XMLString
  End Enum
  Public Enum TCTeXMLCollectionElementName
    CTe
    cteProc
    cancCTe
    procCancCTe
    enviCTe
    retEnviCTe

  End Enum
  <XmlElement(""), _
  XmlChoiceIdentifier("ItemElementName")> _
  Public Property Item() As Object()
    Get
      Return itemField
    End Get
    Set(ByVal value As Object())
      itemField = value
    End Set
  End Property
  <XmlIgnore()> _
  Public Property ItemElementName() As TCTeXMLCollectionElementName()
    Get
      Return itemElementNameField
    End Get
    Set(ByVal value As TCTeXMLCollectionElementName())
      itemElementNameField = value
    End Set
  End Property
End Class
