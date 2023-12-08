Public Class NodoArbol
    Public Property Valor As Integer
    Public Property Izquierda As NodoArbol
    Public Property Derecha As NodoArbol

    Public Sub New(valor As Integer)
        Me.Valor = valor
        Izquierda = Nothing
        Derecha = Nothing
    End Sub
End Class

