
Public Interface IEstructuraDeDatos
    Sub AgregarDato(dato As String)
    Sub EliminarDato(dato As String)
    Sub MostrarDatos()
    Sub BuscarDato(dato As String)
    Sub AgregarArista(datoOrigen As String, datoDestino As String)
    Sub EliminarArista(datoOrigen As String, datoDestino As String)
    Sub MostrarGrafo()
End Interface
Public Module Module1

    Sub Main()
        Dim estructuraActual As IEstructuraDeDatos = Nothing
        Dim salirPrograma As Boolean = False

        While Not salirPrograma
            Menu.MostrarMenu()
            Dim opcion1 As String = Console.ReadLine()

            Select Case opcion1
                Case "A", "B", "C", "D", "E"
                    estructuraActual = Menu.SeleccionarEstructura(opcion1)

                    If estructuraActual IsNot Nothing Then
                        Console.WriteLine($"Seleccionaste {opcion1}. Puedes realizar operaciones en {estructuraActual.GetType().Name}.")

                        While True
                            If opcion1 = "E" Then ' Si es un grafo
                                MostrarOperacionesGrafos()
                                Dim operacionGrafos As String = Console.ReadLine()

                                If RealizarOperacionGrafos(estructuraActual, operacionGrafos) Then
                                    Exit While
                                End If
                            Else
                                MostrarOperaciones()
                                Dim operacion As String = Console.ReadLine()

                                If RealizarOperacion(estructuraActual, operacion) Then
                                    Exit While
                                End If
                            End If
                        End While
                    Else
                        Console.WriteLine("Opción no válida. Por favor, seleccione una estructura válida.")
                    End If

                Case "F"
                    Console.WriteLine("Saliendo del programa. ¡Hasta luego!")
                    salirPrograma = True

                Case Else
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción del menú.")
            End Select
        End While
    End Sub
    Sub MostrarOperaciones()
        Console.WriteLine(vbLf & "Operaciones:")
        Console.WriteLine("1. Agregar dato")
        Console.WriteLine("2. Eliminar dato")
        Console.WriteLine("3. Mostrar datos")
        Console.WriteLine("4. Cambiar estructura")
        Console.WriteLine("5. Salir")
    End Sub

    Sub MostrarOperacionesGrafos()
        Console.WriteLine(vbLf & "Operaciones:")
        Console.WriteLine("1. Agregar Vertice")
        Console.WriteLine("2. Eliminar Vertice")
        Console.WriteLine("3. Agregar Arista")
        Console.WriteLine("4. Eliminar Arista")
        Console.WriteLine("5. Mostrar Grafo")
        Console.WriteLine("6. Cambiar De Estructura")
        Console.WriteLine("7. Salir")
    End Sub

    Function RealizarOperacion(estructura As IEstructuraDeDatos, operacion As String) As Boolean
        Select Case operacion
            Case "1"
                Console.Write("Ingrese un dato: ")
                Dim datoAgregar As String = Console.ReadLine()
                estructura.AgregarDato(datoAgregar)
                Return False
            Case "2"
                Console.Write("Ingrese el dato a eliminar: ")
                Dim datoEliminar As String = Console.ReadLine()
                estructura.EliminarDato(datoEliminar)
                Return False
            Case "3"
                estructura.MostrarDatos()
                Return False
            Case "4"
                Console.WriteLine("Cambiando estructura.")
                Return True
            Case "5"
                Console.WriteLine("Saliendo de la estructura actual.")
                Return True
            Case Else
                Console.WriteLine("Opción no válida. Por favor, seleccione una operación válida.")
                Return False
        End Select
    End Function

    Function RealizarOperacionGrafos(estructura As IEstructuraDeDatos, operacion As String) As Boolean
        Select Case operacion
            Case "1"
                Console.Write("Ingrese un Vertice: ")
                Dim datoAgregar As String = Console.ReadLine()
                estructura.AgregarDato(datoAgregar)
                Return False
            Case "2"
                Console.Write("Ingrese el dato a eliminar: ")
                Dim datoEliminar As String = Console.ReadLine()
                estructura.EliminarDato(datoEliminar)
                Return False
            Case "3"
                Console.Write("Ingrese el dato de origen: ")
                Dim datoOrigen As String = Console.ReadLine()
                Console.Write("Ingrese el dato de destino: ")
                Dim datoDestino As String = Console.ReadLine()
                DirectCast(estructura, Grafo).AgregarVertice(datoOrigen, datoDestino) ' Llamada al método AgregarVertice
                Return False
            Case "4"
                Console.Write("Ingrese el dato de origen: ")
                Dim datoOrigenEliminar As String = Console.ReadLine()
                Console.Write("Ingrese el dato de destino: ")
                Dim datoDestinoEliminar As String = Console.ReadLine()
                DirectCast(estructura, Grafo).EliminarVertice(datoOrigenEliminar, datoDestinoEliminar) ' Llamada al método EliminarVertice
                Return False
            Case "5"
                estructura.MostrarDatos()
                Return False
            Case "6"
                Console.WriteLine("Cambiando estructura.")
                Return True
            Case "7"
                Console.WriteLine("Saliendo de la estructura actual.")
                Return True
            Case Else
                Console.WriteLine("Opción no válida. Por favor, seleccione una operación válida.")
                Return False
        End Select
    End Function
End Module


