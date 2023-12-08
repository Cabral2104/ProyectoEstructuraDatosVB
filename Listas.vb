Public Class Lista
    Implements IEstructuraDeDatos

    Private datos As New List(Of String)()

    Public Sub AgregarDato(dato As String) Implements IEstructuraDeDatos.AgregarDato
        datos.Add(dato)
    End Sub

    Public Sub EliminarDato(dato As String) Implements IEstructuraDeDatos.EliminarDato
        If datos.Contains(dato) Then
            datos.Remove(dato)
            Console.WriteLine($"{dato} eliminado de la lista.")
        Else
            Console.WriteLine($"{dato} no encontrado en la lista.")
        End If
    End Sub

    Public Sub MostrarDatos() Implements IEstructuraDeDatos.MostrarDatos
        Console.WriteLine("Lista: " & String.Join(", ", datos))
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
