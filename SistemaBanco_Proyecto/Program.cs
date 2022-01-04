using System;
using System.IO;
using System.Threading;

namespace SistemaBanco_Proyecto
{
    class Program
    {
        static string path = "sistemaBancario.txt";
        static string path2 = "movimientosBancarios.txt";
        static string path3 = "clavesAcceso.txt";

        static int IDaux, IDaux2;

        static void Main(string[] args)
        {
            nombreBanco();
            pedirClave();
            menu();
        }

//FUNCION MENU
        public static void menu()
        {
            int opc = 0;
            string entrada;

            do
            {
                Console.Clear();
                nombreBanco();
                Console.WriteLine("Seleccione una opcion:\n\n\t1. Alta Cuentahabiente\n\t2. Baja Cuentahabiente\n\t3. Modificar limite\n\t4. Movimientos\n\t5. Salir");
                Console.WriteLine("\n\nOpcion: ");
                entrada = Console.ReadLine();
                opc = validar(entrada);

                switch (opc)
                {
                    case 1:
                        alta();
                        break;
                    case 2:
                        baja();
                        Console.ReadKey();
                        break;
                    case 3:
                        modificarLimites();
                        break;
                    case 4:
                        menuMovimientos(0);
                        break;
                }

            } while (opc != 5);
        }

//FUNCION ALTA
        public static void alta()
        {
            int ID = pedirID();
            crearMatriz(ID, 1);
        }

//FUNCION BAJA
        public static void baja()
        {
            int ID = pedirID();
            crearMatriz(ID, 2);
        }

//FUNCION MODIFICAR LIMITES
        public static void modificarLimites()
        {
            IDaux = pedirID();
            crearMatriz(IDaux, 3);
            crearMatriz(IDaux, 7);
        }

//FUNCION MOVIMIENTOS
        public static void menuMovimientos(int saldo)
        {
            int opc = 0;
            string entrada;
            bool repetir = true;

            do
            {
                Console.Clear();
                nombreBanco();
                Console.WriteLine("Seleccione el movimiento a registrar\n\n\t1. Deposito\n\t2. Retiro\n\t3. Compra\n\t4. Inversion \n\t5. Regresar");
                Console.WriteLine("\n\nOpcion: ");
                entrada = Console.ReadLine();
                opc = validar(entrada);

                switch (opc)
                {
                    case 1:
                        IDaux = pedirID();
                        saldo = crearMatriz(IDaux, 3);
                        crearMatriz(IDaux, 4);
                        break;
                    case 2:
                        IDaux = pedirID();
                        saldo = crearMatriz(IDaux, 3);
                        if (saldo == 0)
                        {
                            Console.Clear();
                            nombreBanco();
                            Console.WriteLine("\tERROR: Fondos insuficientes");
                            Thread.Sleep(2000);
                        }
                        else
                        {                        
                            crearMatriz(IDaux, 5);
                        }
                        break;
                    case 3:
                        IDaux = pedirID();
                        saldo = crearMatriz(IDaux, 3);
                        if (saldo == 0)
                        {
                            Console.Clear();
                            nombreBanco();
                            Console.WriteLine("\tERROR: Fondos insuficientes");
                            Thread.Sleep(2000);
                            break;
                        }
                        else
                        {           
                            Console.Clear();
                            nombreBanco();
                            crearMatriz(IDaux, 6);
                        }
                        break;
                    case 4:
                        IDaux = pedirID();
                        saldo = crearMatriz(IDaux, 3);
                        Console.WriteLine("SALDO: " + saldo);
                        Console.ReadKey();
                        
                        if (saldo == 0)
                        {
                            Console.Clear();
                            nombreBanco();
                            Console.WriteLine("\tERROR: Fondos insuficientes");
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            menuInversion(IDaux, saldo);
                        }
                        break;
                    case 5:
                        repetir = false;
                        break;
                }
            } while (repetir);
        }

//FUNCION MENU INVERSION
        public static void menuInversion(int ID, int saldo)
        {
            int opc = 0, rpt1=0;
            string rpt2 = "";
            bool repetir = true;

            do
            {
                Console.Clear();
                nombreBanco();
                Console.WriteLine("\tMENU DE INVERSIONES");
                Console.WriteLine("\nEliga una inversión para ver los detalles\n\n\t1. Cetes\n\t2. Pagares\n\t3. Fondos de inversion de deuda\n\t4. Regresar");
                Console.WriteLine("\n\nOpcion: ");
                opc = Convert.ToInt32(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        Console.Clear();
                        nombreBanco();
                        Console.WriteLine("CETES\n\nLos Certificados de la Tesoreria de la Federación (Cetes) son un instrumento de deuda bursatil emitido por el Gobierno Federal.\n\n-> Interes Anual Estimado: 4.50%\n\n-> Monto Minimo: Sin monto requerido");
                        Console.WriteLine("\n\n\nPor favor seleccione 'S' para invertir en CETES o 'N' para regresar");
                        rpt2 = Console.ReadLine();
                        if ((rpt2 == "S")||(rpt2=="s"))
                        {
                            crearMatriz(ID, 8);
                        }
                        else if (rpt2 == "N" || rpt2 == "n")
                        {
                            Console.Clear();
                            nombreBanco();
                            Console.WriteLine("AVISO: Los cambios no han sido realizados.");
                            Thread.Sleep(2000);
                        }

                        break;
                    case 2:
                        Console.Clear();
                        nombreBanco();
                        Console.WriteLine("Pagares\n\nPagare es un instrumento de inversión a un plazo que paga una tasa fija, donde el capital más los intereses se pagan al final del plazo de la inversion.\n\n-> Interes Anual Estimado: 3.10%\n\n-> Monto Minimo: Sin monto requerido");
                        Console.WriteLine("\n\n\nPor favor seleccione 'S' para invertir en PAGARES o 'N' para regresar");
                        rpt2 = Console.ReadLine();
                        if ((rpt2 == "S") || (rpt2 == "s"))
                        {
                            crearMatriz(ID, 8);
                        }
                        else if (rpt2 == "N" || rpt2 == "n")
                        {
                            Console.Clear();
                            nombreBanco();
                            Console.WriteLine("AVISO: Los cambios no han sido realizados.");
                            Thread.Sleep(2000);
                        }

                        break;
                    case 3:
                        Console.Clear();
                        nombreBanco();
                        Console.WriteLine("\tAVISO: Este producto esta en proceso de incorporacion al Plan de Inversiones Bancario, por lo tanto no puede ser ofrecido.");
                        Thread.Sleep(2000);
                        break;
                    case 4:
                        repetir = false;
                        break;
                }
            } while (repetir);
        }

//FUNCION PEDIR MONTO (MOVIMIENTOS)
        public static int pedirMonto()
        {
            string entrada;
            int monto;

            Console.Clear();
            nombreBanco();
            Console.WriteLine("Ingrese el monto: ");
            entrada = Console.ReadLine();
            monto = validar(entrada);

            return monto;
        }

//FUNCION CREAR MATRIZ
        public static int crearMatriz(int ID, int opc)
        {
            int saldo = 0, monto, operacion, validarNum,contador=0;
            bool buscarID = false;
            bool eliminado = false;
            bool band = false;
            string entrada;
            string rpt;
            string archivoMov;

            if (!File.Exists(path))
            {
                crearArchivo(path);
            }

            StreamReader lecturaContenido = File.OpenText(path);
            string contenido = lecturaContenido.ReadToEnd();
            lecturaContenido.Close();

            string[] nFilas = contenido.Split("\n");
            string[,] datos = new string[nFilas.Length, 7];
            for (int i = 0; i < datos.GetLength(0) - 1; i++)
            {
                string[] aux = nFilas[i].Split(" ");
                for (int j = 0; j < datos.GetLength(1); j++)
                {
                    datos[i, j] = aux[j];
                }
            }

            for (int i = 1; i < datos.GetLength(0) - 1; i++)
            {
                if (Convert.ToInt32(datos[i, 0]) == ID)
                {
                    buscarID = true;
                    IDaux2 = ID;
                    ID = i;
                    break;
                }

                else if (i == ID)
                {
                    if (datos[i, 0] == "-1")
                    {
                        eliminado = true;
                    }
                }
            }

            switch (opc)
            {

            //CASO 1: ALTA CUENTAHABIENTE
                case 1:
                    if (buscarID == true)
                    {
                        Console.Clear();
                        nombreBanco();
                        Console.WriteLine("ERROR: El cuentahabiente ya esta dado de alta.");
                        Thread.Sleep(2000);
                    }

                    else
                    {
                        if (eliminado == true)
                        {
                            datos[ID, 0] = Convert.ToString(ID);

                            Console.WriteLine("Nombre: ");
                            datos[ID, 1] = Console.ReadLine();

                            do
                            {
                                Console.WriteLine("Tipo de cuenta (Credito/Debito): ");
                                entrada = Console.ReadLine();

                                if (entrada.ToUpper() == "CREDITO" || entrada.ToUpper() == "DEBITO")
                                {
                                    band = true;
                                    datos[ID, 2] = entrada;
                                }
                                else
                                {
                                    Console.WriteLine("\tERROR: Tipo de cuenta no valida");
                                    Console.WriteLine("\nSeleccione una opcion correcta");
                                }
                            } while (band == false);

                            Console.WriteLine("\nSaldo actual: ");
                            entrada = Console.ReadLine();
                            validarNum = validar(entrada);
                            datos[ID, 3] = entrada;

                            Console.WriteLine("Limite de saldo: ");
                            entrada = Console.ReadLine();
                            validarNum = validar(entrada);
                            datos[ID, 4] = entrada;

                            datos[ID, 5] = Convert.ToString(contador);

                            datos[ID, 6] = "NULL";

                            archivoMov = "ALTA DE CUENTA_" + datos[ID, 2];
                            matrizMov(IDaux2, archivoMov);

                            Console.Clear();
                            nombreBanco();
                            Console.WriteLine("\tAVISO: Cuenta dada de alta con exito");
                            Thread.Sleep(2000);

                            StreamWriter cambios = File.AppendText(path);
                            for (int i = 0; i < datos.GetLength(1); i++)
                            {
                                if (i < datos.GetLength(1) - 1)
                                {
                                    cambios.Write($"{datos[nFilas.Length - 1, i]} ");
                                }
                                else cambios.Write($"{datos[nFilas.Length - 1, i]}\n");
                            }
                            cambios.Close();
                        }

                        else
                        {
                            datos[nFilas.Length - 1, 0] = Convert.ToString(ID);

                            Console.WriteLine("Nombre: ");
                            datos[nFilas.Length - 1, 1] = Console.ReadLine();

                            do
                            {
                                Console.WriteLine("Tipo de cuenta (Credito/Debito): ");
                                entrada = Console.ReadLine();

                                if (entrada.ToUpper() == "CREDITO" || entrada.ToUpper() == "DEBITO")
                                {
                                    band = true;
                                    datos[nFilas.Length - 1, 2] = entrada;
                                }
                                else
                                {
                                    Console.WriteLine("\tERROR: Tipo de cuenta no valida");
                                    Console.WriteLine("\nSeleccione una opcion correcta");
                                }
                            } while (band == false);

                            Console.WriteLine("\nSaldo actual: ");
                            entrada = Console.ReadLine();
                            validarNum = validar(entrada);
                            datos[nFilas.Length - 1, 3] = entrada;

                            Console.WriteLine("Limite de saldo: ");
                            entrada = Console.ReadLine();
                            validarNum = validar(entrada);
                            datos[nFilas.Length - 1, 4] = entrada;

                            datos[nFilas.Length - 1, 5] = Convert.ToString(contador);

                            datos[nFilas.Length - 1, 6] = "NULL";

                            archivoMov = "ALTA DE CUENTA_"+datos[nFilas.Length-1,2];
                            matrizMov(ID, archivoMov);

                            Console.Clear();
                            nombreBanco();
                            Console.WriteLine("\tAVISO: Cuenta dada de alta con exito");
                            Thread.Sleep(2000);

                            StreamWriter cambios = File.AppendText(path);
                            for (int i = 0; i < datos.GetLength(1); i++)
                            {
                                if (i < datos.GetLength(1) - 1)
                                {
                                    cambios.Write($"{datos[nFilas.Length - 1, i]} ");
                                }
                                else cambios.Write($"{datos[nFilas.Length - 1, i]}\n");
                            }
                            cambios.Close();
                        }
                    }
                    break;

            //CASO 2: BAJA CUENTAHABIENTE
                case 2:

                    if ((buscarID == true))
                    {
                        saldo = Convert.ToInt32(datos[ID, 3]);

                        if (saldo > 0)
                        {
                            Console.Clear();
                            nombreBanco();
                            Console.WriteLine("ERROR: Imposible dar de baja. Cuenta con saldo disponible.");
                            Thread.Sleep(2000);
                        }

                        else if (saldo == 0)
                        {
                            Console.Clear();
                            nombreBanco();
                            Console.WriteLine("-> Estas segur@ de dar de baja al cuentahabiente? (S/N)");
                            rpt = Console.ReadLine();

                            if (rpt == "S")
                            {
                                Console.Clear();
                                nombreBanco();
                                Console.WriteLine("\tAVISO: Por seguridad, ingresa nuevamente tu clave\n");
                                pedirClave();

                                Console.Clear();
                                nombreBanco();
                                Console.WriteLine("\nAVISO: Cuentahabiente dado de baja con exito");
                                Thread.Sleep(2000);

                                archivoMov = "BAJA DE CUENTA";

                                matrizMov(IDaux2, archivoMov);

                                for (int i = 0; i < datos.GetLength(1); i++)
                                {
                                    datos[ID, i] = "-1";
                                }

                                StreamWriter overWrite = File.CreateText(path);
                                for (int i = 0; i < datos.GetLength(0) - 1; i++)
                                {
                                    if (i == 0)
                                    {
                                        overWrite.WriteLine("ID Nombre Tipo_Cuenta Saldo_Actual Saldo_Maximo Movimientos Inversion");
                                    }
                                    else
                                    {
                                        for (int j = 0; j < datos.GetLength(1); j++)
                                        {
                                            if (j < datos.GetLength(1) - 1)
                                            {
                                                overWrite.Write($"{datos[i, j]} ");
                                            }
                                            else
                                            {
                                                overWrite.Write($"{datos[i, j]}\n");
                                            }
                                        }
                                    }
                                }
                                overWrite.Close();
                            }

                            else if (rpt == "N")
                            {
                                Console.Clear();
                                nombreBanco();
                                Console.WriteLine("AVISO: Los cambios no han sido realizados.");
                                Thread.Sleep(2000);
                            }
                        }
                    }

                    else
                    {
                        Console.Clear();
                        nombreBanco();
                        Console.WriteLine("ERROR: El ID ingresado no corresponde a ningun cuentahbaiente.");
                        Thread.Sleep(2000);
                    }

                    break;

            //CASO 3: COMPROBAR EL ID
                case 3:
                    do
                    {
                        if (buscarID == true)
                        {
                            saldo = Convert.ToInt32(datos[ID, 3]);
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            nombreBanco();
                            Console.WriteLine("\tERROR: El ID no corresponde a ningun cuentahbaiente.\n\nVuelva a intentarlo o presione 0 para regresar...");
                            entrada = Console.ReadLine();

                            if (entrada == "0")
                            {
                                menu();
                            }
                            else
                            {
                                menuMovimientos(0);
                            }
                        }
                    } while (band == false);

                    break;

            //CASO 4: DEPOSITO
                case 4:
                    monto = pedirMonto();

                    if(monto <= (Convert.ToInt32(datos[ID, 4])))
                    {
                        operacion = Convert.ToInt32(datos[ID, 3]) + monto;

                        if (operacion <= (Convert.ToInt32(datos[ID, 4])))
                        {
                            datos[ID, 3] = Convert.ToString(operacion);

                            Console.WriteLine("\n\tSaldo Actualizado: " + datos[ID, 3]);
                            Thread.Sleep(2000);

                            Convert.ToString(monto);
                            archivoMov = "Deposito_" + monto;

                            contador = Convert.ToInt32(datos[ID, 5]);
                            contador++;
                            datos[ID, 5] = Convert.ToString(contador);

                            matrizMov(IDaux2, archivoMov);

                            StreamWriter overWriteDeposito = File.CreateText(path);
                            for (int i = 0; i < datos.GetLength(0) - 1; i++)
                            {
                                if (i == 0)
                                {
                                    overWriteDeposito.WriteLine("ID Nombre Tipo_Cuenta Saldo_Actual Saldo_Maximo Movimientos Inversion");
                                }
                                else
                                {
                                    for (int j = 0; j < datos.GetLength(1); j++)
                                    {
                                        if (j < datos.GetLength(1) - 1)
                                        {
                                            overWriteDeposito.Write($"{datos[i, j]} ");
                                        }
                                        else
                                        {
                                            overWriteDeposito.Write($"{datos[i, j]}\n");
                                        }
                                    }
                                }
                            }
                            overWriteDeposito.Close();
                        }
                        else
                        {
                            Console.Clear();
                            nombreBanco();
                            Console.WriteLine("\tERROR: El limite de la cuenta es " + datos[ID, 4]);
                            Thread.Sleep(2000);
                        }

                    }
                    else
                    {
                        Console.Clear();
                        nombreBanco();
                        Console.WriteLine("\tERROR: El limite de la cuenta es " + datos[ID, 4]);
                        Thread.Sleep(2000);
                    }

                    break;

            //CASO 5: RETIRO
                case 5:
                    monto = pedirMonto();

                    if (monto > (Convert.ToInt32(datos[ID, 3])))
                    {
                        Console.WriteLine("\tERROR: Fondos insuficientes");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        operacion = Convert.ToInt32(datos[ID, 3]) - monto;

                        datos[ID, 3] = Convert.ToString(operacion);

                        Console.WriteLine("\n\tSaldo Actualizado: " + datos[ID, 3]);
                        Thread.Sleep(2000);

                        Convert.ToString(monto);
                        archivoMov = "Retiro_" + monto;

                        matrizMov(IDaux2, archivoMov);

                        contador = Convert.ToInt32(datos[ID, 5]);
                        contador++;
                        datos[ID, 5] = Convert.ToString(contador);

                        StreamWriter overWriteRetiro = File.CreateText(path);
                        for (int i = 0; i < datos.GetLength(0) - 1; i++)
                        {
                            if (i == 0)
                            {
                                overWriteRetiro.WriteLine("ID Nombre Tipo_Cuenta Saldo_Actual Saldo_Maximo Movimientos Inversion");
                            }
                            else
                            {
                                for (int j = 0; j < datos.GetLength(1); j++)
                                {
                                    if (j < datos.GetLength(1) - 1)
                                    {
                                        overWriteRetiro.Write($"{datos[i, j]} ");
                                    }
                                    else
                                    {
                                        overWriteRetiro.Write($"{datos[i, j]}\n");
                                    }
                                }
                            }
                        }
                        overWriteRetiro.Close();
                    }

                    break;

            //CASO 6: COMPRA
                case 6:
                    monto = pedirMonto();

                    if (monto > (Convert.ToInt32(datos[ID, 3])))
                    {
                        Console.WriteLine("\tERROR: Fondos insuficientes");
                        Thread.Sleep(2000);
                    }
                    else
                    {                
                        operacion = Convert.ToInt32(datos[ID, 3]) - monto;
                        datos[ID, 3] = Convert.ToString(operacion);

                        Console.WriteLine("Ingrese el concepto de compra: ");
                        string compra = Console.ReadLine();
                        Console.ReadKey();

                        Console.WriteLine("\n\tSaldo Actualizado: " + datos[ID, 3]);
                        Console.ReadKey();

                        Convert.ToString(monto);
                        archivoMov = "Compra_" + monto + "_" + compra;

                        matrizMov(IDaux2, archivoMov);

                        contador = Convert.ToInt32(datos[ID, 5]);
                        contador++;
                        datos[ID, 5] = Convert.ToString(contador);

                        StreamWriter overWriteCompra = File.CreateText(path);
                        for (int i = 0; i < datos.GetLength(0) - 1; i++)
                        {
                            if (i == 0)
                            {
                                overWriteCompra.WriteLine("ID Nombre Tipo_Cuenta Saldo_Actual Saldo_Maximo Movimientos Inversion");
                            }
                            else
                            {
                                for (int j = 0; j < datos.GetLength(1); j++)
                                {
                                    if (j < datos.GetLength(1) - 1)
                                    {
                                        overWriteCompra.Write($"{datos[i, j]} ");
                                    }
                                    else
                                    {
                                        overWriteCompra.Write($"{datos[i, j]}\n");
                                    }
                                }
                            }
                        }
                        overWriteCompra.Close();
                    }

                    break;

            //CASE 7: MODIFICAR LIMITES
                case 7:
                    Console.Clear();
                    nombreBanco();
                    Console.WriteLine("Limite Actual: "+ datos[ID,4]);

                    Console.WriteLine("\n\n-> Esta segur@ de modificarlo? (S/N)");
                    rpt = Console.ReadLine();

                    if (rpt == "S")
                    {
                        Console.Clear();
                        nombreBanco();
                        Console.WriteLine("\tAVISO: Por seguridad, ingresa nuevamente tu clave\n");
                        pedirClave();

                        Console.Clear();
                        nombreBanco();
                        Console.WriteLine("Escriba el nuevo limite de la cuenta: ");
                        datos[ID, 4] = Console.ReadLine();

                        Console.WriteLine("\n\tAVISO: Datos actualizados con exito\n\tNUEVO LIMITE: " + datos[ID, 4]);
                        Thread.Sleep(2000);

                        archivoMov = "actualizacionLimite_" + datos[ID, 4];

                        matrizMov(IDaux2, archivoMov);

                        StreamWriter overWriteLimite = File.CreateText(path);
                        for (int i = 0; i < datos.GetLength(0) - 1; i++)
                        {
                            if (i == 0)
                            {
                                overWriteLimite.WriteLine("ID Nombre Tipo_Cuenta Saldo_Actual Saldo_Maximo Movimientos Inversion");
                            }
                            else
                            {
                                for (int j = 0; j < datos.GetLength(1); j++)
                                {
                                    if (j < datos.GetLength(1) - 1)
                                    {
                                        overWriteLimite.Write($"{datos[i, j]} ");
                                    }
                                    else
                                    {
                                        overWriteLimite.Write($"{datos[i, j]}\n");
                                    }
                                }
                            }
                        }
                        overWriteLimite.Close();

                    }
                    else if (rpt == "N")
                    {
                        Console.Clear();
                        nombreBanco();
                        Console.WriteLine("AVISO: Los cambios no han sido realizados.");
                        Thread.Sleep(2000);
                    }

                    break;

            //CASE 8: INVERSION
                case 8:
                    int inversion, nuevoSaldo;

                    Console.Clear();
                    nombreBanco();
                    Console.WriteLine("\tSaldo Disponible: " + datos[ID, 3]);
                    Console.WriteLine("\nIngrese la cantidad a invertir: ");
                    entrada = Console.ReadLine();
                    inversion = validar(entrada);

                    if ((Convert.ToInt32(datos[ID, 3])) < inversion)
                    {
                        Console.Clear();
                        nombreBanco();
                        Console.WriteLine("\tERROR: Fondos insuficientes");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        nuevoSaldo = Convert.ToInt32(datos[ID, 3]) - inversion;

                        datos[ID, 3] = Convert.ToString(nuevoSaldo);

                        Console.WriteLine("\n\tAVISO: Inversion realizada con exito\n\tSaldo Actualizado: " + datos[ID, 3]);
                        Console.WriteLine("\tInversion: " + inversion);
                        Thread.Sleep(2000);

                        datos[ID, 6] = Convert.ToString(inversion);

                        Convert.ToString(inversion);
                        archivoMov = "Inversion_" + inversion;
                        matrizMov(IDaux2, archivoMov);

                        contador = Convert.ToInt32(datos[ID, 5]);
                        contador++;
                        datos[ID, 5] = Convert.ToString(contador);

                        StreamWriter overWriteInversion = File.CreateText(path);
                        for (int i = 0; i < datos.GetLength(0) - 1; i++)
                        {
                            if (i == 0)
                            {
                                overWriteInversion.WriteLine("ID Nombre Tipo_Cuenta Saldo_Actual Saldo_Maximo Movimientos Inversion");
                            }
                            else
                            {
                                for (int j = 0; j < datos.GetLength(1); j++)
                                {
                                    if (j < datos.GetLength(1) - 1)
                                    {
                                        overWriteInversion.Write($"{datos[i, j]} ");
                                    }
                                    else
                                    {
                                        overWriteInversion.Write($"{datos[i, j]}\n");
                                    }
                                }
                            }
                        }
                        overWriteInversion.Close();
                    }
                    break;
            }

            return saldo;
        }

//FUNCION MATRIZ MOVIMIENTOS
        public static void matrizMov(int IDaux2, string movimientos)
        {
            if (!File.Exists(path2))
            {
                crearArchivo(path2);
            }

            StreamReader lecturaContenido = File.OpenText(path2);
            string contenido = lecturaContenido.ReadToEnd();
            lecturaContenido.Close();

            string[] nFilas = contenido.Split("\n");
            string[,] datos = new string[nFilas.Length, 2];
            for (int i = 0; i < datos.GetLength(0) - 1; i++)
            {
                string[] aux = nFilas[i].Split(" ");
                for (int j = 0; j < datos.GetLength(1); j++)
                {
                    datos[i, j] = aux[j];
                }
            }

            datos[nFilas.Length-1, 0] = Convert.ToString(IDaux2);
            datos[nFilas.Length-1, 1] = movimientos;

            StreamWriter cambios = File.AppendText(path2);
            for (int i = 0; i < datos.GetLength(1); i++)
            {
                if (i < datos.GetLength(1) - 1)
                {
                    cambios.Write($"{datos[nFilas.Length - 1, i]} ");
                }
                else cambios.Write($"{datos[nFilas.Length - 1, i]}\n");
            }
            cambios.Close();

        }

//FUNCION PEDIR ID
        public static int pedirID()
        {
            Console.WriteLine("Ingresa el ID: ");

            string entrada = Console.ReadLine();
            int ID = validar(entrada);

            return ID;
        }

// FUNCION MOSTRAR NOMBRE DEL BANCO
        public static void nombreBanco()
        {
            Console.WriteLine("------------------------------------------------------------\n------------------- BANKCITY S.A. DE C.V. ------------------\n------------------------------------------------------------\n\n");
        }

//FUNCION PEDIR CLAVE
        public static void pedirClave()
        {
            int clave;
            string entrada;

            Console.WriteLine("Ingrese su CLAVE de usuario: ");
            entrada = Console.ReadLine();
            clave = validar(entrada);

            validarClave(clave);
        }

//FUNCION VALIDAR CLAVE
        public static void validarClave(int clave)
        {
            bool band = false;
            int intentos = 4;
            string entrada;
            bool buscarClave = false;

            /*if (!File.Exists(path3))
            {
                crearArchivo(path3);
            }

            StreamReader lecturaContenido = File.OpenText(path);
            string contenido = lecturaContenido.ReadToEnd();
            lecturaContenido.Close();

            string[] nFilas = contenido.Split("\n");
            string[,] datos = new string[nFilas.Length, 2];
            for (int i = 0; i < datos.GetLength(0) - 1; i++)
            {
                string[] aux = nFilas[i].Split(" ");
                for (int j = 0; j < datos.GetLength(1); j++)
                {
                    datos[i, j] = aux[j];
                }
            }

            for(int i = 1; i < datos.GetLength(0)-1; i++)
            {
                if(Convert.ToInt32(datos[i,1]) == clave)
                {
                    Console.WriteLine("HOLA");
                    Console.ReadKey();
                    buscarClave = true;
                }
            }*/

            while (band == false)
            {
                if (clave < 99)
                {
                    Console.Clear();
                    intentos--;
                    nombreBanco();
                    Console.WriteLine("La CLAVE ingresada es incorrecta !!");
                    Console.WriteLine("\n\n\tIntentos restantes: " + intentos);

                    if (intentos == 0)
                    {
                        Console.Clear();
                        nombreBanco();
                        Console.WriteLine("\tERROR: SISTEMA BLOQUEADO\n\n");
                        System.Environment.Exit(1);
                    }
                    else
                    {
                        Console.WriteLine("\n\n\nIngrese nuevamente la CLAVE: ");
                        entrada = Console.ReadLine();
                        clave = validar(entrada);
                    }
                }
                else
                {
                    band = true;
                }
            }
        }

//FUNCION CREAR ARCHIVO
        public static void crearArchivo(string path)
        {
            Console.WriteLine("\nCreando archivo...\n");

            StreamWriter creacion = File.CreateText(path);
            creacion.WriteLine("ID Nombre Tipo_Cuenta Saldo_Actual Saldo_Maximo Movimientos Inversion");
            creacion.Close();
        }

//FUNCION VALIDAR
        public static int validar(string valor)
        {
            int n = 0;
            bool band = true;

            while (band == true)
            {
                try
                {
                    n = Convert.ToInt32(valor);
                    if (n < 0)
                    {
                        Console.WriteLine("\nERROR: Ingrese un numero valido");
                        valor = Console.ReadLine();
                        band = false;
                    }
                }
                catch
                {
                    Console.WriteLine("\nERROR: Ingrese un numero valido");
                    valor = Console.ReadLine();
                    band = false;
                }
                band = !band;
            }
            return n;
        }
    }
}