Public Class ArbolBinario
    Implements IEstructuraDeDatos

    Private raiz As NodoArbol

    Public Sub AgregarDato(dato As String) Implements IEstructuraDeDatos.AgregarDato
        Dim valor As Integer
        If Integer.TryParse(dato, valor) Then
            raiz = AgregarNodo(raiz, valor)
            Console.WriteLine($"{valor} agregado al árbol.")
        Else
            Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.")
        End If
    End Sub

    Private Function AgregarNodo(nodo As NodoArbol, valor As Integer) As NodoArbol
        If nodo Is Nothing Then
            Return New NodoArbol(valor)
        End If

        If valor < nodo.Valor Then
            nodo.Izquierda = AgregarNodo(nodo.Izquierda, valor)
        ElseIf valor > nodo.Valor Then
            nodo.Derecha = AgregarNodo(nodo.Derecha, valor)
        End If

        Return nodo
    End Function

    Public Sub EliminarDato(dato As String) Implements IEstructuraDeDatos.EliminarDato
        Dim valor As Integer
        If Integer.TryParse(dato, valor) Then
            If BuscarNodo(raiz, valor) IsNot Nothing Then
                raiz = EliminarNodo(raiz, valor)
                Console.WriteLine($"{valor} eliminado del árbol.")
            Else
                Console.WriteLine($"{valor} no encontrado en el árbol.")
            End If
        Else
            Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.")
        End If
    End Sub

    Private Function EliminarNodo(nodo As NodoArbol, valor As Integer) As NodoArbol
        If nodo Is Nothing Then
            Return nodo
        End If

        If valor < nodo.Valor Then
            nodo.Izquierda = EliminarNodo(nodo.Izquierda, valor)
        ElseIf valor > nodo.Valor Then
            nodo.Derecha = EliminarNodo(nodo.Derecha, valor)
        Else
            ' Nodo encontrado, realizar la eliminación
            If nodo.Izquierda Is Nothing Then
                Return nodo.Derecha
            ElseIf nodo.Derecha Is Nothing Then
                Return nodo.Izquierda
            End If

            ' Reemplazar con el sucesor inmediato en orden (valor mínimo del subárbol derecho)
            nodo.Valor = EncontrarMinimoValor(nodo.Derecha)
            nodo.Derecha = EliminarNodo(nodo.Derecha, nodo.Valor)
        End If

        Return nodo
    End Function

    Private Function EncontrarMinimoValor(nodo As NodoArbol) As Integer
        Dim minimoValor As Integer = nodo.Valor
        While nodo.Izquierda IsNot Nothing
            minimoValor = nodo.Izquierda.Valor
            nodo = nodo.Izquierda
        End While
        Return minimoValor
    End Function

    Public Sub MostrarDatos() Implements IEstructuraDeDatos.MostrarDatos
        If raiz Is Nothing Then
            Console.WriteLine("Árbol vacío.")
        Else
            Console.WriteLine("Representación del Árbol Binario:")
            MostrarArbol(raiz, 0)
        End If
    End Sub

    Private Sub MostrarArbol(nodo As NodoArbol, nivel As Integer)
        If nodo IsNot Nothing Then
            MostrarArbol(nodo.Derecha, nivel + 1)
            Console.Write(New String(" "c, nivel * 4))
            Console.WriteLine($"{nodo.Valor}")
            MostrarArbol(nodo.Izquierda, nivel + 1)
        End If
    End Sub

    Public Sub BuscarDato(dato As String) Implements IEstructuraDeDatos.BuscarDato
        Dim valor As Integer
        If Integer.TryParse(dato, valor) Then
            If BuscarNodo(raiz, valor) IsNot Nothing Then
                Console.WriteLine($"{valor} encontrado en el árbol.")
            Else
                Console.WriteLine($"{valor} no encontrado en el árbol.")
            End If
        Else
            Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.")
        End If
    End Sub

    Private Function BuscarNodo(nodo As NodoArbol, valor As Integer) As NodoArbol
        If nodo Is Nothing OrElse nodo.Valor = valor Then
            Return nodo
        End If

        If valor < nodo.Valor Then
            Return BuscarNodo(nodo.Izquierda, valor)
        End If

        Return BuscarNodo(nodo.Derecha, valor)
    End Function

    Public Sub AgregarArista(datoOrigen As String, datoDestino As String) Implements IEstructuraDeDatos.AgregarArista
        Throw New NotImplementedException()
    End Sub

    Public Sub EliminarArista(datoOrigen As String, datoDestino As String) Implements IEstructuraDeDatos.EliminarArista
        Throw New NotImplementedException()
    End Sub

    Public Sub MostrarGrafo() Implements IEstructuraDeDatos.MostrarGrafo
        Throw New NotImplementedException()
    End Sub
End Class

