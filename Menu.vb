Public Class Menu

    Public Shared Sub MostrarMenu()
        Console.WriteLine("A. Listas")
        Console.WriteLine("B. Pilas")
        Console.WriteLine("C. Colas")
        Console.WriteLine("D. Árboles")
        Console.WriteLine("E. Grafos")
        Console.WriteLine("F. Salir")
    End Sub

    Public Shared Function SeleccionarEstructura(opcion1 As String) As IEstructuraDeDatos

        Select Case opcion1
            Case "A"
                Return New Lista()
            ' Agrega más casos para otras estructuras de datos según sea necesario
            Case "B"
                Return New Pila()

            Case "C"
                Return New Cola()
            Case "D"
                Return New ArbolBinario()
            Case "E"
                Return New Grafo()

            Case Else
                Return Nothing
        End Select
    End Function

End Class
