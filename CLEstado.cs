using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OchoPuzzle
{

    public class CLEstado
    {
        #region Campos
        private int[,] _tablero;
        private int _nivel;
        private CLEstado _padre;
        private int _h3;
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
        public int h3
        {
            get => _h3;
            set => _h3 = value;
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
            this._h3 = H3();
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
            this._h3 = H3();
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
            // Estado objetivo: 
            // 1 2 3
            // 8 0 4
            // 7 6 5
            if (_tablero[0, 0] == 1 &&
                _tablero[0, 1] == 2 &&
                _tablero[0, 2] == 3 &&
                _tablero[1, 0] == 8 &&
                _tablero[1, 1] == 0 &&
                _tablero[1, 2] == 4 &&
                _tablero[2, 0] == 7 &&
                _tablero[2, 1] == 6 &&
                _tablero[2, 2] == 5)
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

        public int H1()
        {
            int piezasFueraDeLugar = 0;

            int[,] estadoMeta =
            {
            {1, 2, 3},
            {8, 0, 4},
            {7, 6, 5}
            };

            for (int fila = 0; fila < 3; fila++)
            {
                for (int columna = 0; columna < 3; columna++)
                {
                    if (_tablero[fila, columna] != 0 &&
                        _tablero[fila, columna] != estadoMeta[fila, columna])
                    {
                        piezasFueraDeLugar++;
                    }
                }
            }
            return piezasFueraDeLugar;
        }

        public int H2()
        {
            int distanciaTotal = 0;
            int[,] estadoMeta =
            {

        {1, 2, 3},
        {8, 0, 4},
        {7, 6, 5}
    };
            for (int fila = 0; fila < 3; fila++)
            {
                for (int columna = 0; columna < 3; columna++)
                {
                    int valor = _tablero[fila, columna];
                    if (valor == 0)
                        continue;
                    int filaMeta = 0;
                    int columnaMeta = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (estadoMeta[i, j] == valor)
                            {
                                filaMeta = i;
                                columnaMeta = j;
                            }
                        }
                    }
                    distanciaTotal +=
                        Math.Abs(fila - filaMeta) +
                        Math.Abs(columna - columnaMeta);
                }
            }
            return distanciaTotal;
        }

        private int H3()
        {

            int sumaS = 0;
            int[] borde =
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
                int actual = borde[i];
                if (actual == 0)
                    continue;
                int siguiente = borde[(i + 1) % 8];
                int sucesorCorrecto = (actual == 8) ? 1 : actual + 1;

                if (siguiente == sucesorCorrecto)
                    sumaS += 0;
                else
                    sumaS += 2;
            }
            if (_tablero[1, 1] != 0)
                sumaS += 1;
            return H2() + sumaS;
        }

        #endregion
    }
}