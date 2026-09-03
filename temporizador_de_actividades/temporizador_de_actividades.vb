Imports System
Module temporizador_de_actividades
    Sub Main(args As String())
        Dim ids(19) As Integer
        Dim nombres(19) As String
        Dim categorias(19) As String
        Dim descripciones(19) As String
        Dim tiemposObjetivo(19) As Integer
        Dim tiemposAcumulados(19) As Integer
        Dim estados(19) As String
        Dim cantidad As Integer = 0
        Dim opcion As Integer
        Dim temporizadorActivo As Boolean = False
        Dim idActividadActiva As Integer = 0
        Dim horaInicio As DateTime
        '------------------------------------------------'
        '--|menu_principal_temporizador_de_actividades|--'
        '------------------------------------------------'
        Do
            Console.WriteLine("menu principal temporizador de actividades")
            Console.WriteLine("1) Registrar actividad")
            Console.WriteLine("2) Editar actividad")
            Console.WriteLine("3) Listar actividades")
            Console.WriteLine("4) Buscar actividad")
            Console.WriteLine("5) Eliminar actividad")
            Console.WriteLine("6) Iniciar temporizador")
            Console.WriteLine("7) Detener temporizador")
            Console.WriteLine("8) Mostrar resumen")
            Console.WriteLine("9) Salir")
            Console.Write("Seleccione una opcion: ")
            opcion = Convert.ToInt32(Console.ReadLine())
            Select Case opcion
                '-------------------------'
                '--|registrar_actividad|--'
                '-------------------------'
                Case 1
                    If cantidad >= ids.Length Then
                        Console.WriteLine("No hay espacio para registrar mas actividades.")
                    Else
                        Console.Write("Ingrese el nombre de la actividad: ")
                        Dim nuevoNombre As String = Console.ReadLine()
                        If nuevoNombre = "" Then
                            Console.WriteLine("El nombre no puede estar vacio.")
                        Else
                            Dim actividadExiste As Boolean = False
                            For i As Integer = 0 To cantidad - 1
                                If nombres(i).ToLower() = nuevoNombre.ToLower() Then
                                    actividadExiste = True
                                End If
                            Next
                            If actividadExiste Then
                                Console.WriteLine("No se puede registrar. La actividad ya existe.")
                            Else
                                Console.Write("Ingrese la categoria: ")
                                Dim nuevaCategoria As String = Console.ReadLine()
                                Console.Write("Ingrese la descripcion: ")
                                Dim nuevaDescripcion As String = Console.ReadLine()
                                Console.Write("Ingrese el tiempo objetivo en minutos: ")
                                Dim nuevoTiempoObjetivo As Integer = Convert.ToInt32(Console.ReadLine())
                                If nuevoTiempoObjetivo <= 0 Then
                                    Console.WriteLine("El tiempo objetivo debe ser mayor que cero.")
                                Else
                                    ids(cantidad) = cantidad + 1
                                    nombres(cantidad) = nuevoNombre
                                    categorias(cantidad) = nuevaCategoria
                                    descripciones(cantidad) = nuevaDescripcion
                                    tiemposObjetivo(cantidad) = nuevoTiempoObjetivo
                                    tiemposAcumulados(cantidad) = 0
                                    estados(cantidad) = "Pendiente"
                                    cantidad += 1
                                    Console.WriteLine("Actividad registrada correctamente.")
                                    Console.WriteLine("ID: " & ids(cantidad - 1) & " | Nombre: " & nombres(cantidad - 1) & " | Categoria: " & categorias(cantidad - 1) & " | Descripcion: " & descripciones(cantidad - 1) & " | Tiempo objetivo: " & tiemposObjetivo(cantidad - 1) & " min | Tiempo acumulado: " & tiemposAcumulados(cantidad - 1) & " min | Estado: " & estados(cantidad - 1))
                                End If
                            End If
                        End If
                    End If
                '----------------------'
                '--|editar_actividad|--'
                '----------------------'
                Case 2
                    If cantidad = 0 Then
                        Console.WriteLine("No existen actividades registradas.")
                    Else
                        For i As Integer = 0 To cantidad - 1
                            Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Categoria: " & categorias(i) & " | Descripcion: " & descripciones(i) & " | Tiempo objetivo: " & tiemposObjetivo(i) & " min | Tiempo acumulado: " & tiemposAcumulados(i) & " min | Estado: " & estados(i))
                        Next
                        Console.Write("Ingrese el ID de la actividad a editar: ")
                        Dim idEditar As Integer = Convert.ToInt32(Console.ReadLine())
                        If idEditar >= 1 AndAlso idEditar <= cantidad Then
                            Dim posicion As Integer = idEditar - 1
                            Console.Write("Nuevo nombre: ")
                            Dim nuevoNombre As String = Console.ReadLine()
                            If nuevoNombre = "" Then
                                Console.WriteLine("El nombre no puede estar vacio.")
                            Else
                                Dim nombreExiste As Boolean = False
                                For i As Integer = 0 To cantidad - 1
                                    If i <> posicion AndAlso nombres(i).ToLower() = nuevoNombre.ToLower() Then
                                        nombreExiste = True
                                    End If
                                Next
                                If nombreExiste Then
                                    Console.WriteLine("No se puede actualizar. El nombre ya existe.")
                                Else
                                    nombres(posicion) = nuevoNombre
                                    Console.Write("Nueva categoria: ")
                                    categorias(posicion) = Console.ReadLine()
                                    Console.Write("Nueva descripcion: ")
                                    descripciones(posicion) = Console.ReadLine()
                                    Console.Write("Nuevo tiempo objetivo en minutos: ")
                                    Dim nuevoTiempoObjetivo As Integer = Convert.ToInt32(Console.ReadLine())
                                    If nuevoTiempoObjetivo <= 0 Then
                                        Console.WriteLine("El tiempo objetivo debe ser mayor que cero.")
                                    Else
                                        tiemposObjetivo(posicion) = nuevoTiempoObjetivo
                                        Console.WriteLine("Seleccione el nuevo estado:")
                                        Console.WriteLine("1) Pendiente")
                                        Console.WriteLine("2) En progreso")
                                        Console.WriteLine("3) Completada")
                                        Console.Write("Seleccione una opcion: ")
                                        Dim opcionEstado As Integer = Convert.ToInt32(Console.ReadLine())
                                        Select Case opcionEstado
                                            Case 1
                                                estados(posicion) = "Pendiente"
                                            Case 2
                                                estados(posicion) = "En progreso"
                                            Case 3
                                                estados(posicion) = "Completada"
                                            Case Else
                                                Console.WriteLine("Estado no valido.")
                                        End Select
                                        Console.WriteLine("Actividad actualizada correctamente.")
                                        Console.WriteLine("ID: " & ids(posicion) & " | Nombre: " & nombres(posicion) & " | Categoria: " & categorias(posicion) & " | Descripcion: " & descripciones(posicion) & " | Tiempo objetivo: " & tiemposObjetivo(posicion) & " min | Tiempo acumulado: " & tiemposAcumulados(posicion) & " min | Estado: " & estados(posicion))
                                    End If
                                End If
                            End If
                        Else
                            Console.WriteLine("ID no encontrada.")
                        End If
                    End If
                '------------------------'
                '--|listar_actividades|--'
                '------------------------'
                Case 3
                    If cantidad = 0 Then
                        Console.WriteLine("No existen actividades registradas.")
                    Else
                        For i As Integer = 0 To cantidad - 1
                            Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Categoria: " & categorias(i) & " | Descripcion: " & descripciones(i) & " | Tiempo objetivo: " & tiemposObjetivo(i) & " min | Tiempo acumulado: " & tiemposAcumulados(i) & " min | Estado: " & estados(i))
                        Next
                    End If
                '----------------------'
                '--|buscar_actividad|--'
                '----------------------'
                Case 4
                    If cantidad = 0 Then
                        Console.WriteLine("No existen actividades registradas.")
                    Else
                        Console.WriteLine("1) Buscar por ID")
                        Console.WriteLine("2) Buscar por nombre")
                        Console.WriteLine("3) Buscar por categoria")
                        Console.WriteLine("4) Buscar por estado")
                        Console.Write("Seleccione una opcion: ")
                        Dim tipoBusqueda As Integer = Convert.ToInt32(Console.ReadLine())
                        If tipoBusqueda = 1 Then
                            Console.Write("Ingrese el ID: ")
                            Dim idBuscar As Integer = Convert.ToInt32(Console.ReadLine())
                            If idBuscar >= 1 AndAlso idBuscar <= cantidad Then
                                Dim posicion As Integer = idBuscar - 1
                                Console.WriteLine("ID: " & ids(posicion) & " | Nombre: " & nombres(posicion) & " | Categoria: " & categorias(posicion) & " | Descripcion: " & descripciones(posicion) & " | Tiempo objetivo: " & tiemposObjetivo(posicion) & " min | Tiempo acumulado: " & tiemposAcumulados(posicion) & " min | Estado: " & estados(posicion))
                            Else
                                Console.WriteLine("ID no encontrada.")
                            End If
                        ElseIf tipoBusqueda = 2 Then
                            Console.Write("Ingrese el nombre: ")
                            Dim nombreBuscar As String = Console.ReadLine()
                            Dim encontrado As Boolean = False
                            For i As Integer = 0 To cantidad - 1
                                If nombres(i).ToLower().Contains(nombreBuscar.ToLower()) Then
                                    Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Categoria: " & categorias(i) & " | Descripcion: " & descripciones(i) & " | Tiempo objetivo: " & tiemposObjetivo(i) & " min | Tiempo acumulado: " & tiemposAcumulados(i) & " min | Estado: " & estados(i))
                                    encontrado = True
                                End If
                            Next
                            If Not encontrado Then
                                Console.WriteLine("No se encontraron actividades.")
                            End If
                        ElseIf tipoBusqueda = 3 Then
                            Console.Write("Ingrese la categoria: ")
                            Dim categoriaBuscar As String = Console.ReadLine()
                            Dim encontrado As Boolean = False
                            For i As Integer = 0 To cantidad - 1
                                If categorias(i).ToLower().Contains(categoriaBuscar.ToLower()) Then
                                    Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Categoria: " & categorias(i) & " | Descripcion: " & descripciones(i) & " | Tiempo objetivo: " & tiemposObjetivo(i) & " min | Tiempo acumulado: " & tiemposAcumulados(i) & " min | Estado: " & estados(i))
                                    encontrado = True
                                End If
                            Next
                            If Not encontrado Then
                                Console.WriteLine("No se encontraron actividades en esa categoria.")
                            End If
                        ElseIf tipoBusqueda = 4 Then
                            Console.Write("Ingrese el estado: ")
                            Dim estadoBuscar As String = Console.ReadLine()
                            Dim encontrado As Boolean = False
                            For i As Integer = 0 To cantidad - 1
                                If estados(i).ToLower() = estadoBuscar.ToLower() Then
                                    Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Categoria: " & categorias(i) & " | Descripcion: " & descripciones(i) & " | Tiempo objetivo: " & tiemposObjetivo(i) & " min | Tiempo acumulado: " & tiemposAcumulados(i) & " min | Estado: " & estados(i))
                                    encontrado = True
                                End If
                            Next
                            If Not encontrado Then
                                Console.WriteLine("No se encontraron actividades con ese estado.")
                            End If
                        Else
                            Console.WriteLine("Opcion no valida.")
                        End If
                    End If
                '------------------------'
                '--|eliminar_actividad|--'
                '------------------------'
                Case 5
                    If cantidad = 0 Then
                        Console.WriteLine("No existen actividades registradas.")
                    Else
                        If temporizadorActivo Then
                            Console.WriteLine("No se puede eliminar una actividad mientras el temporizador esta activo.")
                        Else
                            For i As Integer = 0 To cantidad - 1
                                Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Categoria: " & categorias(i) & " | Tiempo objetivo: " & tiemposObjetivo(i) & " min | Tiempo acumulado: " & tiemposAcumulados(i) & " min | Estado: " & estados(i))
                            Next
                            Console.Write("Ingrese el ID de la actividad a eliminar: ")
                            Dim idEliminar As Integer = Convert.ToInt32(Console.ReadLine())
                            If idEliminar >= 1 AndAlso idEliminar <= cantidad Then
                                Dim posicion As Integer = idEliminar - 1
                                For i As Integer = posicion To cantidad - 2
                                    ids(i) = ids(i + 1)
                                    nombres(i) = nombres(i + 1)
                                    categorias(i) = categorias(i + 1)
                                    descripciones(i) = descripciones(i + 1)
                                    tiemposObjetivo(i) = tiemposObjetivo(i + 1)
                                    tiemposAcumulados(i) = tiemposAcumulados(i + 1)
                                    estados(i) = estados(i + 1)
                                Next
                                cantidad -= 1
                                ids(cantidad) = 0
                                nombres(cantidad) = ""
                                categorias(cantidad) = ""
                                descripciones(cantidad) = ""
                                tiemposObjetivo(cantidad) = 0
                                tiemposAcumulados(cantidad) = 0
                                estados(cantidad) = ""
                                For i As Integer = 0 To cantidad - 1
                                    ids(i) = i + 1
                                Next
                                Console.WriteLine("Actividad eliminada correctamente.")
                            Else
                                Console.WriteLine("ID no encontrada.")
                            End If
                        End If
                    End If
                '--------------------------'
                '--|iniciar_temporizador|--'
                '--------------------------'
                Case 6
                    If cantidad = 0 Then
                        Console.WriteLine("No existen actividades registradas.")
                    ElseIf temporizadorActivo Then
                        Console.WriteLine("Ya existe un temporizador activo.")
                        Console.WriteLine("Actividad actual: " & nombres(idActividadActiva - 1))
                    Else
                        For i As Integer = 0 To cantidad - 1
                            Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Tiempo objetivo: " & tiemposObjetivo(i) & " min | Tiempo acumulado: " & tiemposAcumulados(i) & " min | Estado: " & estados(i))
                        Next
                        Console.Write("Ingrese el ID de la actividad: ")
                        Dim idIniciar As Integer = Convert.ToInt32(Console.ReadLine())
                        If idIniciar >= 1 AndAlso idIniciar <= cantidad Then
                            Dim posicion As Integer = idIniciar - 1
                            If estados(posicion) = "Completada" Then
                                Console.WriteLine("La actividad ya se encuentra completada.")
                            Else
                                temporizadorActivo = True
                                idActividadActiva = idIniciar
                                horaInicio = DateTime.Now
                                estados(posicion) = "En progreso"
                                Console.WriteLine("Temporizador iniciado correctamente.")
                                Console.WriteLine("Actividad: " & nombres(posicion))
                                Console.WriteLine("Hora de inicio: " & horaInicio.ToString("HH:mm:ss"))
                            End If
                        Else
                            Console.WriteLine("ID no encontrada.")
                        End If
                    End If
                '--------------------------'
                '--|detener_temporizador|--'
                '--------------------------'
                Case 7
                    If Not temporizadorActivo Then
                        Console.WriteLine("No existe un temporizador activo.")
                    Else
                        Dim horaFin As DateTime = DateTime.Now
                        Dim tiempoTranscurrido As TimeSpan = horaFin - horaInicio
                        Dim minutosSesion As Integer = CInt(Math.Floor(tiempoTranscurrido.TotalMinutes))
                        If minutosSesion < 1 Then
                            minutosSesion = 1
                        End If
                        Dim posicion As Integer = idActividadActiva - 1
                        tiemposAcumulados(posicion) += minutosSesion
                        If tiemposAcumulados(posicion) >= tiemposObjetivo(posicion) Then
                            estados(posicion) = "Completada"
                        Else
                            estados(posicion) = "Pendiente"
                        End If
                        Console.WriteLine("Temporizador detenido correctamente.")
                        Console.WriteLine("Actividad: " & nombres(posicion))
                        Console.WriteLine("Hora de inicio: " & horaInicio.ToString("HH:mm:ss"))
                        Console.WriteLine("Hora de finalizacion: " & horaFin.ToString("HH:mm:ss"))
                        Console.WriteLine("Tiempo de esta sesion: " & minutosSesion & " min")
                        Console.WriteLine("Tiempo acumulado: " & tiemposAcumulados(posicion) & " min")
                        Console.WriteLine("Estado: " & estados(posicion))
                        temporizadorActivo = False
                        idActividadActiva = 0
                    End If
                '---------------------'
                '--|mostrar_resumen|--'
                '---------------------'
                Case 8
                    If cantidad = 0 Then
                        Console.WriteLine("No existen actividades registradas.")
                    Else
                        Dim pendientes As Integer = 0
                        Dim enProgreso As Integer = 0
                        Dim completadas As Integer = 0
                        Dim tiempoTotal As Integer = 0
                        Dim mayorTiempo As Integer = tiemposAcumulados(0)
                        Dim menorTiempo As Integer = tiemposAcumulados(0)
                        Dim actividadMayor As String = nombres(0)
                        Dim actividadMenor As String = nombres(0)

                        For i As Integer = 0 To cantidad - 1
                            tiempoTotal += tiemposAcumulados(i)
                            If estados(i) = "Pendiente" Then
                                pendientes += 1
                            ElseIf estados(i) = "En progreso" Then
                                enProgreso += 1
                            ElseIf estados(i) = "Completada" Then
                                completadas += 1
                            End If
                            If tiemposAcumulados(i) > mayorTiempo Then
                                mayorTiempo = tiemposAcumulados(i)
                                actividadMayor = nombres(i)
                            End If
                            If tiemposAcumulados(i) < menorTiempo Then
                                menorTiempo = tiemposAcumulados(i)
                                actividadMenor = nombres(i)
                            End If
                        Next
                        Dim promedioTiempo As Double = tiempoTotal / cantidad
                        Console.WriteLine("Total de actividades: " & cantidad)
                        Console.WriteLine("Actividades pendientes: " & pendientes)
                        Console.WriteLine("Actividades en progreso: " & enProgreso)
                        Console.WriteLine("Actividades completadas: " & completadas)
                        Console.WriteLine("Tiempo total registrado: " & tiempoTotal & " min")
                        Console.WriteLine("Tiempo promedio por actividad: " & promedioTiempo.ToString("N2") & " min")
                        Console.WriteLine("Actividad con mayor tiempo acumulado: " & actividadMayor & " | Tiempo: " & mayorTiempo & " min")
                        Console.WriteLine("Actividad con menor tiempo acumulado: " & actividadMenor & " | Tiempo: " & menorTiempo & " min")
                    End If
                '------------------------------'
                '--|salir_del_menu_principal|--'
                '------------------------------'
                Case 9
                    If temporizadorActivo Then
                        Console.WriteLine("No se puede salir mientras existe un temporizador activo.")
                    Else
                        Console.WriteLine("Gracias por utilizar Temporizador de Actividades.")
                    End If
                Case Else
                    Console.WriteLine("Opcion no valida.")
            End Select
        Loop While opcion <> 9 OrElse temporizadorActivo
    End Sub
End Module