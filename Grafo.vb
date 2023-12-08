Public Class Grafo
    Implements IEstructuraDeDatos

    Private vertices As Dictionary(Of String, List(Of String))
    Private aristas As List(Of (String, String))

    Public Sub New()
        vertices = New Dictionary(Of String, List(Of String))()
        aristas = New List(Of (String, String))()
    End Sub

    Public Sub AgregarDato(dato As String) Implements IEstructuraDeDatos.AgregarDato
        If Not vertices.ContainsKey(dato) Then
            vertices(dato) = New List(Of String)()
            Console.WriteLine($"Vértice '{dato}' agregado al grafo.")
        Else
            Console.WriteLine($"El vértice '{dato}' ya existe en el grafo.")
        End If
    End Sub

    Public Sub EliminarDato(dato As String) Implements IEstructuraDeDatos.EliminarDato
        If vertices.ContainsKey(dato) Then
            vertices.Remove(dato)
            ' Eliminar aristas relacionadas con el vértice
            aristas.RemoveAll(Function(a) a.Item1 = dato OrElse a.Item2 = dato)
            Console.WriteLine($"Vértice '{dato}' eliminado del grafo.")
        Else
            Console.WriteLine($"El vértice '{dato}' no encontrado en el grafo.")
        End If
    End Sub

    Public Sub AgregarVertice(datoOrigen As String, datoDestino As String) Implements IEstructuraDeDatos.AgregarArista
        If vertices.ContainsKey(datoOrigen) AndAlso vertices.ContainsKey(datoDestino) Then
            aristas.Add((datoOrigen, datoDestino))
            Console.WriteLine($"Arista entre '{datoOrigen}' y '{datoDestino}' agregada.")
        Else
            Console.WriteLine("Al menos uno de los vértices no encontrado en el grafo.")
        End If
    End Sub

    Public Sub EliminarVertice(datoOrigen As String, datoDestino As String) Implements IEstructuraDeDatos.EliminarArista
        If vertices.ContainsKey(datoOrigen) AndAlso vertices.ContainsKey(datoDestino) Then
            aristas.Remove((datoOrigen, datoDestino))
            Console.WriteLine($"Arista entre '{datoOrigen}' y '{datoDestino}' eliminada.")
        Else
            Console.WriteLine("Al menos uno de los vértices no encontrado en el grafo.")
        End If
    End Sub

    Public Sub MostrarGrafo() Implements IEstructuraDeDatos.MostrarGrafo
        If vertices.Count = 0 Then
            Console.WriteLine("Grafo vacío.")
        Else
            Console.WriteLine("Lista de Vértices:")
            For Each vertice In vertices.Keys
                Console.WriteLine(vertice)
            Next

            Console.WriteLine("Lista de Aristas:")
            For Each arista In aristas
                Console.WriteLine($"{arista.Item1} - {arista.Item2}")
            Next
        End If
    End Sub

    Public Sub MostrarDatos() Implements IEstructuraDeDatos.MostrarDatos
        MostrarGrafo()
    End Sub

    Public Sub BuscarDato(dato As String) Implements IEstructuraDeDatos.BuscarDato
        Throw New NotImplementedException()
    End Sub
End Class

