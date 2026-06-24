using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OchoPuzzle
{
    public static class CLAlgoritmosDeBusqueda
    {
        public static List<CLEstado> AnchuraPrioritaria(CLEstado Inicial)
        {
            //Definición de variables
            List<CLEstado> Solucion = new List<CLEstado>();
            List<CLEstado> Abiertos = new List<CLEstado>();
            List<CLEstado> Cerrados = new List<CLEstado>();
            List<CLEstado> Hijos = new List<CLEstado>();
            CLEstado Actual = new CLEstado();
            //Algoritmo
            Abiertos.Add(Inicial);
            Actual = Abiertos[0];
            while (!Actual.EsFinal() && Abiertos.Count > 0)
            {
                Cerrados.Add(Actual);
                Abiertos.RemoveAt(0);
                Hijos = Actual.GenerarHijos();
                Hijos = TratarRepetidos(Hijos, Abiertos, Cerrados);
                foreach (CLEstado a in Hijos)
                    Abiertos.Add(a);
                Actual = Abiertos[0];
            }
            if (Actual.EsFinal())
            {
                Solucion.Add(Actual);
                while (Actual.padre != null)
                {
                    Solucion.Add(Actual.padre);
                    Actual = Actual.padre;
                }
            }
            return Solucion;
        }
        public static List<CLEstado> AlgoritmoHeuristico(CLEstado Inicial)
        {

            List<CLEstado> Solucion = new List<CLEstado>();
            List<CLEstado> Abiertos = new List<CLEstado>();
            List<CLEstado> Cerrados = new List<CLEstado>();
            List<CLEstado> Hijos = new List<CLEstado>();

            Abiertos.Add(Inicial);

            while (Abiertos.Count > 0)
            {
                
                CLEstado Actual = Abiertos[0];
                int idx = 0;
                for (int i = 1; i < Abiertos.Count; i++)
                {
                    int f_i = Abiertos[i].nivel + Abiertos[i].h3;
                    int f_best = Actual.nivel + Actual.h3;
                    if (f_i < f_best)
                    {
                        Actual = Abiertos[i];
                        idx = i;
                    }
                }


                if (Actual.EsFinal())
                {
                    Solucion.Add(Actual);
                    while (Actual.padre != null)
                    {
                        Solucion.Add(Actual.padre);
                        Actual = Actual.padre;
                    }
                    return Solucion;
                }

           
                Abiertos.RemoveAt(idx);
                Cerrados.Add(Actual);

                
                Hijos = Actual.GenerarHijos();

               
                foreach (var hijo in Hijos)
                {
                    bool enCerrados = false;
                    for (int c = 0; c < Cerrados.Count; c++)
                    {
                        if (hijo.EsIgual(Cerrados[c]))
                        {
                            enCerrados = true; break;
                        }
                    }
                    if (enCerrados) continue;

                    int indexEnAbiertos = -1;
                    for (int a = 0; a < Abiertos.Count; a++)
                    {
                        if (hijo.EsIgual(Abiertos[a]))
                        {
                            indexEnAbiertos = a; break;
                        }
                    }

                    if (indexEnAbiertos == -1)
                    {
                        Abiertos.Add(hijo);
                    }
                    else
                    {
                        
                        if (hijo.nivel < Abiertos[indexEnAbiertos].nivel)
                        {
                            Abiertos[indexEnAbiertos].padre = hijo.padre;
                            Abiertos[indexEnAbiertos].nivel = hijo.nivel;
                            Abiertos[indexEnAbiertos].h3 = hijo.h3;
                        }
                    }
                }
            }

            return Solucion;
        }

        public static List<CLEstado> ProfundidadLimitada(CLEstado Inicial, int Limite)
        {
            //Definición de variables
            List<CLEstado> Solucion = new List<CLEstado>();
            List<CLEstado> Abiertos = new List<CLEstado>();
            List<CLEstado> Cerrados = new List<CLEstado>();
            List<CLEstado> Hijos = new List<CLEstado>();
            CLEstado Actual = new CLEstado();
            //Algoritmo
            Abiertos.Add(Inicial);
            Actual = Abiertos[Abiertos.Count - 1];
            while (!Actual.EsFinal() && Abiertos.Count > 0)
            {
                Cerrados.Add(Actual);
                Abiertos.RemoveAt(Abiertos.Count - 1);
                if (Actual.nivel <= Limite)
                {
                    Hijos = Actual.GenerarHijos();
                    Hijos = TratarRepetidosProfundidad(Hijos, Abiertos, Cerrados);
                    foreach (CLEstado a in Hijos)
                        Abiertos.Add(a);
                }
                Actual = Abiertos[Abiertos.Count - 1];
            }
            if (Actual.EsFinal())
            {
                Solucion.Add(Actual);
                while (Actual.padre != null)
                {
                    Solucion.Add(Actual.padre);
                    Actual = Actual.padre;
                }
            }
            return Solucion;
        }
        private static List<CLEstado> TratarRepetidos(List<CLEstado> hijos, List<CLEstado> abiertos, List<CLEstado> cerrados)
        {
            List<CLEstado> HijosDepurado = new List<CLEstado>();
            bool encontrado = false;
            foreach (CLEstado hijo in hijos)
            {
                encontrado = false;
                // comparar con abiertos
                foreach (var a in abiertos)
                {
                    if (hijo.EsIgual(a))
                    {
                        encontrado = true; break;
                    }
                }

                if (encontrado) continue;

                // comparar con cerrados
                foreach (var c in cerrados)
                {
                    if (hijo.EsIgual(c))
                    {
                        encontrado = true; break;
                    }
                }

                if (!encontrado)
                {
                    HijosDepurado.Add(hijo);
                }
            }

            return HijosDepurado;
        }
        private static List<CLEstado> TratarRepetidosProfundidad(List<CLEstado> hijos, List<CLEstado> abiertos, List<CLEstado> cerrados)
        {
            List<CLEstado> HijosDepurado = new List<CLEstado>();
            bool encontrado = false;
            foreach (CLEstado hijo in hijos)
            {
                encontrado = false;
                // comparar con abiertos
                foreach (var a in abiertos)
                {
                    if (hijo.EsIgual(a))
                    {
                        encontrado = true; break;
                    }
                }

                if (encontrado) continue;

                // comparar con cerrados
                foreach (var c in cerrados)
                {
                    if (hijo.EsIgual(c))
                    {
                        if (hijo.nivel >= c.nivel)
                            encontrado = true; break;
                    }
                }

                if (!encontrado)
                {
                    HijosDepurado.Add(hijo);
                }
            }

            return HijosDepurado;
        }

        public static List<CLEstado> AlgortimoHeuristicoH3(CLEstado Inicial)
        {
            //Definición de variables
            List<CLEstado> Solucion = new List<CLEstado>();
            List<CLEstado> Abiertos = new List<CLEstado>();
            List<CLEstado> Cerrados = new List<CLEstado>();
            List<CLEstado> Hijos = new List<CLEstado>();
            CLEstado Actual = new CLEstado();
            //Algoritmo
            Abiertos.Add(Inicial);
            Actual = Abiertos[0];
            while (!Actual.EsFinal() && Abiertos.Count > 0)
            {
                Cerrados.Add(Actual);
                Abiertos.RemoveAt(0);
                Hijos = Actual.GenerarHijos();
                Hijos = TratarRepetidos(Hijos, Abiertos, Cerrados);
                foreach (CLEstado a in Hijos)
                    Abiertos.Add(a);
                //ORDENAR ABIERTOS POR H3
                Abiertos = Abiertos.OrderBy(e => e.h3).ToList();
                Actual = Abiertos[0];
            }
            if (Actual.EsFinal())
            {
                Solucion.Add(Actual);
                while (Actual.padre != null)
                {
                    Solucion.Add(Actual.padre);
                    Actual = Actual.padre;
                }
            }
            return Solucion;
        }
    }
}