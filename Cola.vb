Public Class Cola
    Implements IEstructuraDeDatos

    Private datos As New Queue(Of String)()

    Public Sub AgregarDato(dato As String) Implements IEstructuraDeDatos.AgregarDato
        datos.Enqueue(dato)
    End Sub

    Public Sub EliminarDato(dato As String) Implements IEstructuraDeDatos.EliminarDato
        If datos.Contains(dato) Then
            ' La eliminación en una cola implica desencolar hasta encontrar el elemento
            Dim nuevaCola As New Queue(Of String)()
            Dim elementoEliminado As Boolean = False

            While datos.Count > 0
                Dim elemento As String = datos.Dequeue()
                If Not elementoEliminado AndAlso elemento = dato Then
                    ' Eliminar solo la primera ocurrencia del elemento
                    elementoEliminado = True
                Else
                    nuevaCola.Enqueue(elemento)
                End If
            End While

            ' Restaurar la cola original
            While nuevaCola.Count > 0
                datos.Enqueue(nuevaCola.Dequeue())
            End While

            If elementoEliminado Then
                Console.WriteLine($"{dato} eliminado de la cola.")
            Else
                Console.WriteLine($"{dato} no encontrado en la cola.")
            End If
        Else
            Console.WriteLine($"{dato} no encontrado en la cola.")
        End If
    End Sub

    Public Sub MostrarDatos() Implements IEstructuraDeDatos.MostrarDatos
        Console.WriteLine("Cola: " & String.Join(", ", datos))
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
