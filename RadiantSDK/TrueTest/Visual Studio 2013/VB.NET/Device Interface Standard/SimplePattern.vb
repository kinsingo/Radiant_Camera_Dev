Imports TrueTestPatternGenerator
Imports System.Xml.Serialization

<Serializable()>
Public Class SimplePattern
    Inherits PatternBase

    <XmlIgnore()>
    Protected Overrides ReadOnly Property Name As String
        Get
            Return "Numeric Image #" & ImageNumber.ToString
        End Get
    End Property

#Region "pattern-specific properties"

    Public Property ImageNumber As Integer = 0

#End Region

End Class