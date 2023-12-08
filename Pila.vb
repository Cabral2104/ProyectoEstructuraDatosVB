Public Class Pila
    Implements IEstructuraDeDatos

    Private datos As New Stack(Of String)()

    Public Sub AgregarDato(dato As String) Implements IEstructuraDeDatos.AgregarDato
        datos.Push(dato)
    End Sub

    Public Sub EliminarDato(dato As String) Implements IEstructuraDeDatos.EliminarDato
        If datos.Contains(dato) Then
            ' La eliminación en una pila implica desapilar hasta encontrar el elemento
            Dim nuevaPila As New Stack(Of String)()
            Dim elementoEliminado As Boolean = False

            While datos.Count > 0
                Dim elemento As String = datos.Pop()
                If Not elementoEliminado AndAlso elemento = dato Then
                    ' Eliminar solo la primera ocurrencia del elemento
                    elementoEliminado = True
                Else
                    nuevaPila.Push(elemento)
                End If
            End While

            ' Restaurar la pila original
            While nuevaPila.Count > 0
                datos.Push(nuevaPila.Pop())
            End While

            If elementoEliminado Then
                Console.WriteLine($"{dato} eliminado de la pila.")
            Else
                Console.WriteLine($"{dato} no encontrado en la pila.")
            End If
        Else
            Console.WriteLine($"{dato} no encontrado en la pila.")
        End If
    End Sub

    Public Sub MostrarDatos() Implements IEstructuraDeDatos.MostrarDatos
        Console.WriteLine("Pila: " & String.Join(", ", datos))
    End Sub

    Public Sub BuscarDato(dato As String) Implements IEstructuraDeDatos.BuscarDato
        Throw New NotImplementedException()
    End Sub

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
