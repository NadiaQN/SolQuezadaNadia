using System;

namespace ConEjercicio2
{
    class Program
    {
        static void Main(string[] args)
        {

            // Declarar variables
            string nombreComuna, strCantidadPCRPositivos, strTotalHabitantes, analizarComuna;
            int cantidadPCRPositivos, TotalHabitantes, cantidadComunas, comunasFase4, totalPCRPositivos;
            double porcentajeContagiados;

            // Inicializar variables
            cantidadComunas = 0;
            comunasFase4 = 0;
            totalPCRPositivos = 0;

            Console.Write("¿Desea analizar una comuna?: (si/no) ");
            analizarComuna = Console.ReadLine();

            do
            {   
                // Obtener nombre comuna
                Console.Write("Ingrese el nombre de la comuna: ");
                nombreComuna = Console.ReadLine();

                // Obtener cantidad PCR positivos
                Console.Write("Ingrese cantidad de personas con PCR positivos: ");
                strCantidadPCRPositivos = Console.ReadLine();
                int.TryParse(strCantidadPCRPositivos, out cantidadPCRPositivos);

                // Obtener total de habitantes en la comuna
                Console.Write("Ingrese cantidad total de habitantes: ");
                strTotalHabitantes = Console.ReadLine();
                int.TryParse(strTotalHabitantes, out TotalHabitantes);

                // Calcular % de habitantes contagiados
                porcentajeContagiados = (cantidadPCRPositivos * 100) / TotalHabitantes;

                // Determinar fase
                if (porcentajeContagiados >= 80)
                {
                    Console.WriteLine("La comuna de {0} debe estar en Fase 1: Cuarentena", nombreComuna);
                }
                else if (porcentajeContagiados >= 60 && porcentajeContagiados <= 79)
                {
                    Console.WriteLine("La comuna de {0} debe estar en Fase 2: Transición", nombreComuna);
                }
                else if (porcentajeContagiados >= 50 && porcentajeContagiados <= 59)
                {
                    Console.WriteLine("La comuna de {0} debe estar en Fase 3: Preparación", nombreComuna);
                }
                else if (porcentajeContagiados >= 20 && porcentajeContagiados <= 49)
                {
                    Console.WriteLine("La comuna de {0} debe estar en Fase 4: Apertura Inicial", nombreComuna);
                    comunasFase4++;
                }
                else
                {
                    Console.WriteLine("La comuna de {0} debe estar en Fase 5: Apertura Avanzada", nombreComuna);
                }

                cantidadComunas++;
                totalPCRPositivos = totalPCRPositivos + cantidadPCRPositivos;

                Console.Write("¿Desea analizar otra comuna?: (si/no) ");
                analizarComuna = Console.ReadLine();
            }
            while (analizarComuna == "si");
            if (analizarComuna == "no")
            {
                Console.WriteLine("Cantidad de comunas analizadas: {0} \r\nCantidad de comunas en fase 4: {1} \r\nCantidad total de PCR positivo: {2}", cantidadComunas, comunasFase4, totalPCRPositivos);
            }
        }
    }
}
