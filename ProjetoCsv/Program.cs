using Sistemafotovoltaico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.IO;
using System.Linq;

namespace ProjetoCsv
{ 
    class Program
    {
    static void Main(string[] args)
    {

           Console.WriteLine("Informe a potência do gerador utilizando ponto como separador decimal:\n");



            // Converte para double usando CultureInfo.InvariantCulture para aceitar ponto como separador decimal.
           double Valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            var sistemas = LerCSV("TabelaValores.csv");

          
            // Caso o usuário digite um valor aproximado (não exato) ele ainda consegue visualizar as info. (margem de erro).
            var sistemaSelecionado = sistemas.FirstOrDefault(s => Math.Abs(s.PotenciaGerador - Valor) < 0.02); 


            // Verifica se o valor digitado existe no arquivo csv, se não existir retorna o Console.

            if (sistemaSelecionado == null)
            {
                Console.WriteLine("Gerador não encontrado com essa potência.");
                return;
            }

            Console.WriteLine("---Soluções inteligentes On Grid---\n");
            Console.WriteLine($" Potência Máxima do Gerador: {sistemaSelecionado.PotenciaMaxima} kWp.");
            Console.WriteLine($" Número de Módulos: {sistemaSelecionado.NumeroModulos}");
            Console.WriteLine($" Tipo de Inversor(s):{sistemaSelecionado.Inversores}");
            Console.WriteLine($" Potência dos Inversores: {sistemaSelecionado.PotenciaInversores} kW.");
            Console.WriteLine($" String Box: {sistemaSelecionado.StringBox}");
            Console.WriteLine($" Cabos: {sistemaSelecionado.CabosVermelhoPreto}");
            Console.WriteLine($" Par de Conectores: {sistemaSelecionado.Conectores}");
            Console.WriteLine($" Tensão Máxima de Operação: {sistemaSelecionado.TensaoMaxima:F2} V.");
            Console.WriteLine($" Corrente Máxima de Operação: {sistemaSelecionado.CorrenteMaxima} A.");
            Console.WriteLine($" Tensão de Circuito Aberto: {sistemaSelecionado.TensaoAbertoMaxima:F2} V.");
            Console.WriteLine($" Corrente de Curto Circuito: {sistemaSelecionado.CorrenteCurtoMaxima} A.");

            Console.WriteLine("\n Aperte qualquer tecla para sair da tabela com os valores!");
            Console.ReadKey();
        }

        // Método de leitura do csv utilizando lista
            static List<SistemaFotovoltaico> LerCSV(string caminho)
        {
            var linhas = File.ReadAllLines("C:\\ProjetoCsv\\ProjetoCsv\\ProjetoCsv\\TabelaValores.csv");
            var lista = new List<SistemaFotovoltaico>();


            foreach (var linha in linhas.Skip(1)) // pula o cabeçalho do csv
            {
                var colunas = linha.Split(',');

                var sistema = new SistemaFotovoltaico
                {
                    PotenciaGerador = double.Parse(colunas[0], CultureInfo.InvariantCulture),
                    NumeroModulos = int.Parse(colunas[1]),
                    Inversores = colunas[2],
                    PotenciaInversores = double.Parse(colunas[3], CultureInfo.InvariantCulture),
                    StringBox = colunas[4],
                    CabosVermelhoPreto = colunas[5],
                    Conectores = int.Parse(colunas[6]),
                    EstruturaFixacao = int.Parse(colunas[7])
                };

                lista.Add(sistema);
            }

            return lista;
        }
    }
    }

