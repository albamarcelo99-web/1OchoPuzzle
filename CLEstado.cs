using System;
using System.Collections.Generic;

namespace OchoPuzzle
{

    public class CLEstado
    {
        #region Campos
        private int[,] _tablero;
        private int _nivel;
        private CLEstado _padre;
        #endregion

        #region Propiedades
        public int[,] tablero
        {
            get => _tablero;
            set => _tablero = value;
        }
        public int nivel
        {
            get => _nivel;
            set => _nivel = value;
        }
        public CLEstado padre
        {
            get => _padre;
            set => _padre = value;
        }
        #endregion

        #region Constructor
        public CLEstado()
        {
            this._tablero = new int[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    this._tablero[i, j] = 0;
            this._nivel = 0;
            this._padre = null;
        }
        public CLEstado(int p00, int p01, int p02,
                        int p10, int p11, int p12,
                        int p20, int p21, int p22
                        )
        {
            this._tablero = new int[3, 3];
            this._tablero[0, 0] = p00;
            this._tablero[1, 0] = p10;
            this._tablero[2, 0] = p20;
            this._tablero[0, 1] = p01;
            this._tablero[1, 1] = p11;
            this._tablero[2, 1] = p21;
            this._tablero[0, 2] = p02;
            this._tablero[1, 2] = p12;
            this._tablero[2, 2] = p22;
            this._nivel = 0;
            this._padre = null;
        }



        #endregion

        #region Métodos
        public List<CLEstado> GenerarHijos()
        {
            List<CLEstado> Respuesta = new List<CLEstado>();
            String pos0 = "";
            int[,] aux = new int[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (this._tablero[i, j] == 0)
                    {
                        pos0 = i.ToString() + j.ToString();
                    }
            CLEstado A = new CLEstado();
            switch (pos0)
            {
                case "00":
                    A = new CLEstado(this._tablero[0, 1],
                                             this._tablero[0, 0],
                                             this._tablero[0, 2],
                                             this._tablero[1, 0],
                                             this._tablero[1, 1],
                                             this._tablero[1, 2],
                                             this._tablero[2, 0],
                                             this._tablero[2, 1],
                                             this._tablero[2, 2]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);
                    A = new CLEstado(this._tablero[1, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[0, 0],
                                     this._tablero[1, 1],
                                     this._tablero[1, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);
                    break;
                case "01":
                    A = new CLEstado(this._tablero[0, 1],
                                         this._tablero[0, 0],
                                         this._tablero[0, 2],
                                         this._tablero[1, 0],
                                         this._tablero[1, 1],
                                         this._tablero[1, 2],
                                         this._tablero[2, 0],
                                         this._tablero[2, 1],
                                         this._tablero[2, 2]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);

                    A = new CLEstado(this._tablero[0, 0],
                                         this._tablero[1, 1],
                                         this._tablero[0, 2],
                                         this._tablero[1, 0],
                                         this._tablero[0, 1],
                                         this._tablero[1, 2],
                                         this._tablero[2, 0],
                                         this._tablero[2, 1],
                                         this._tablero[2, 2]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);

                    A = new CLEstado(this._tablero[0, 0],
                                         this._tablero[0, 2],
                                         this._tablero[0, 1],
                                         this._tablero[1, 0],
                                         this._tablero[1, 1],
                                         this._tablero[1, 2],
                                         this._tablero[2, 0],
                                         this._tablero[2, 1],
                                         this._tablero[2, 2]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);
                    break;
                case "02":
                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 2],
                                     this._tablero[0, 1],
                                     this._tablero[1, 0],
                                     this._tablero[1, 1],
                                     this._tablero[1, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);
                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[1, 1],
                                     this._tablero[1, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);
                    break;
                case "10":
                    A = new CLEstado(this._tablero[0, 1],
                                     this._tablero[0, 0],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[1, 1],
                                     this._tablero[1, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);

                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 1],
                                     this._tablero[1, 0],
                                     this._tablero[1, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);

                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[2, 0],
                                     this._tablero[1, 1],
                                     this._tablero[1, 2],
                                     this._tablero[1, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);
                    break;
                case "11":
                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 1],
                                     this._tablero[1, 0],
                                     this._tablero[1, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);

                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[1, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[0, 1],
                                     this._tablero[1, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);

                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[1, 2],
                                     this._tablero[1, 1],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);
                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[2, 1],
                                     this._tablero[1, 2],
                                     this._tablero[2, 0],
                                     this._tablero[1, 1],
                                     this._tablero[2, 2]);

                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);
                    break;
                case "12":
                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[1, 2],
                                     this._tablero[1, 0],
                                     this._tablero[1, 1],
                                     this._tablero[0, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);

                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[1, 2],
                                     this._tablero[1, 1],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);

                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[1, 1],
                                     this._tablero[2, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[1, 2]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);
                    break;
                case "20":
                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[2, 0],
                                     this._tablero[1, 1],
                                     this._tablero[1, 2],
                                     this._tablero[1, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);
                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[1, 1],
                                     this._tablero[1, 2],
                                     this._tablero[2, 1],
                                     this._tablero[2, 0],
                                     this._tablero[2, 2]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);
                    break;
                case "21":
                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[1, 1],
                                     this._tablero[1, 2],
                                     this._tablero[2, 1],
                                     this._tablero[2, 0],
                                     this._tablero[2, 2]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);

                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[2, 1],
                                     this._tablero[1, 2],
                                     this._tablero[2, 0],
                                     this._tablero[1, 1],
                                     this._tablero[2, 2]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);

                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[1, 1],
                                     this._tablero[1, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 2],
                                     this._tablero[2, 1]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);
                    break;
                case "22":
                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[1, 1],
                                     this._tablero[2, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[1, 2]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);
                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[1, 1],
                                     this._tablero[1, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 2],
                                     this._tablero[2, 1]);
                    A.nivel = this.nivel + 1;
                    A.padre = this;
                    Respuesta.Add(A);
                    break;
            }
            return Respuesta;
        }

        public bool EsFinal()
        {
            bool res = false;
            if (_tablero[0, 0] == 1 &&
                _tablero[0, 1] == 2 &&
                _tablero[0, 2] == 3 &&
                _tablero[1, 0] == 4 &&
                _tablero[1, 1] == 5 &&
                _tablero[1, 2] == 6 &&
                _tablero[2, 0] == 7 &&
                _tablero[2, 1] == 8 &&
                _tablero[2, 2] == 0)
            {
                res = true;
            }
            return res;
        }

        public bool EsIgual(CLEstado a)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (a.tablero[i, j] != this.tablero[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion

        public int H1()
        {
            int contador1 = 0;

            int[,] meta =
            {
                {1,2,3},
                {8,0,4},
                {7,6,5}
            };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (this._tablero[i, j] != 0 &&
                        this._tablero[i, j] != meta[i, j])
                    {
                        contador1++;
                    }
                }
            }

            return contador1;
        }

        public int H2()
        {
            int contador2 = 0;

            int[,] meta =
            {
                {1,2,3},
                {8,0,4},
                {7,6,5}
            };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int valor = _tablero[i, j];

                    if (valor == 0)
                        continue;

                    int filaMeta = 0;
                    int columnaMeta = 0;

                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            if (meta[x, y] == valor)
                            {
                                filaMeta = x;
                                columnaMeta = y;
                            }
                        }
                    }

                    contador2 += Math.Abs(i - filaMeta) +
                         Math.Abs(j - columnaMeta);
                }
            }

            return contador2;
        }

        public int H3()
        {
            int contador3 = 0;

            int[] recorrido =
            {
                _tablero[0,0],
                _tablero[0,1],
                _tablero[0,2],
                _tablero[1,2],
                _tablero[2,2],
                _tablero[2,1],
                _tablero[2,0],
                _tablero[1,0]
            };

            for (int i = 0; i < 8; i++)
            {
                int actual = recorrido[i];
                int siguiente = recorrido[(i + 1) % 8];

                if (actual != 0)
                {
                    int sucesor = (actual == 8) ? 1 : actual + 1;

                    if (siguiente != sucesor)
                        contador3 += 2;
                }
            }

            if (_tablero[1, 1] != 0)
                contador3 += 1;

            return H2() + (3 * contador3);
        }
    }
}