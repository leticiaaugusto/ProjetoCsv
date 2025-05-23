using System;

namespace Sistemafotovoltaico
{
    public class SistemaFotovoltaico
    {
        public double PotenciaGerador { get; set; }
        public int NumeroModulos { get; set; }
        public required string Inversores { get; set; }

        public double PotenciaInversores { get; set; }
        public required string StringBox { get; set; }
        public required string CabosVermelhoPreto{ get; set; }

        public int Conectores { get; set; }
        public int EstruturaFixacao { get; set; }


        // valores por unidade de módulo.
        public double Potencia { get; set; } = 330;
        public double Tensao { get; set; } = 37.7;
        public double Corrente { get; set; } = 8.76;
        public double TensaoAberto { get; set; } = 45.9;
        public double CorrenteCurto { get; set; } = 9.27;

        // valores máximos por quantidades de módulo (série).

        public double PotenciaMaxima => Potencia* NumeroModulos;
        public double TensaoMaxima => Tensao * NumeroModulos; 
        public double CorrenteMaxima => Corrente;
        public double TensaoAbertoMaxima => TensaoAberto * NumeroModulos;
        public double CorrenteCurtoMaxima => CorrenteCurto;
        // usar "=>" indica que são propriedades calculadas.
    }
}

