using System;
using System.Collections.Generic;

namespace OchoPuzzle
{
 
    public class CLEstado
    {
        #region Campos
        private int[,] _tablero;
        private int _nivel;
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
        #endregion

        #region Constructor
        public CLEstado()
        {
            this._tablero = new int[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    this._tablero[i, j] = 0;
            this._nivel = 0;
        }
        public CLEstado(int p00, int p01, int p02,
                        int p10, int p11, int p12,
                        int p20, int p21, int p22
                        )
        {
            this._tablero = new int[3, 3];
            
            this._tablero[0, 0] = p00;
            this._tablero[0, 1] = p01;
            this._tablero[0, 2] = p02;
            this._tablero[1, 0] = p10;
            this._tablero[1, 1] = p11;
            this._tablero[1, 2] = p12;
            this._tablero[2, 0] = p20;
            this._tablero[2, 1] = p21;
            this._tablero[2, 2] = p22;
            this._nivel = 0;
        }

    
        public CLEstado(int[,] tablero)
        {
            this._tablero = new int[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    this._tablero[i, j] = tablero[i, j];
            this._nivel = 0;
        }



        #endregion

        #region Métodos
        public List<CLEstado> GenerarHijos()
        {
            var Respuesta = new List<CLEstado>();

            int zi = -1, zj = -1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (this._tablero[i, j] == 0)
                    {
                        zi = i; zj = j; break;
                    }
                }
                if (zi != -1) break;
            }

            if (zi == -1) return Respuesta;

            int[,] moves = new int[,] { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

            for (int m = 0; m < 4; m++)
            {
                int ni = zi + moves[m, 0];
                int nj = zj + moves[m, 1];
                if (ni >= 0 && ni < 3 && nj >= 0 && nj < 3)
                {
                    int[,] copy = new int[3, 3];
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 3; j++)
                            copy[i, j] = this._tablero[i, j];

                    
                    copy[zi, zj] = copy[ni, nj];
                    copy[ni, nj] = 0;

                    var hijo = new CLEstado(copy);
                    hijo.nivel = this._nivel + 1;
                    Respuesta.Add(hijo);
                }
            }

            return Respuesta;
        }
        #endregion
    }
}
