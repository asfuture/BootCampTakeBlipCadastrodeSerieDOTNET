using System;
using projeto_takeblip;

namespace Projeto_takeblip
{
    class Program
    {
        static SerieRepositorio repositorio =  new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "x")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                    ListarSeries();
                    break;
                    case "2":
                    InserirSeries();
                    break;
                    case "3":
                    AtualizarSerie();
                    break;
                    case "4":
                    ExcluirSerie();
                    break;
                    case "5":
                    VisualizarSerie();
                    break;
                    case "C":
                    Console.Clear();
                    break;
                   default:
                    throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }
        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série:");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }
         private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série:");
            int indiceSerie = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }   
        private static void AtualizarSerie()
        {
             Console.Write("Digite o id da série:");
             int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o género entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(
                id:indiceSerie,
                genero:(Genero)entradaGenero,
                titulo:entradaTitulo,
                ano: entradaAno,
                descricao:entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        private static void ListarSeries()
        {
            Console.WriteLine("*************************************");
            Console.WriteLine("*****LISTA DE SÉRIE CADASTRADAS******");
            Console.WriteLine("*************************************");
            var lista = repositorio.Lista();

            if(lista.Count == 0){
                Console.WriteLine("VOCÊ NÃO TEM SÉRIE CADASTRADA");
                return;
            }
            foreach (var serie in lista){
                var excluido = serie.retornaExcluido();
                Console.WriteLine("ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Série Excluido com sucesso*":""));
            }
        }
        private static void InserirSeries()
        {
            Console.WriteLine("CADASTRE A SUA SÉRIE FAVORITA AQUI.");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine(" {0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o género entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titutlo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(
                id:repositorio.ProxmoId(),
                genero:(Genero)entradaGenero,
                titulo:entradaTitulo,
                ano: entradaAno,
                descricao:entradaDescricao
                );
                repositorio.Insere(novaSerie);
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("*************************************");
            Console.WriteLine("*****PROJETO TAKEBLIP- DIO!!****");
            Console.WriteLine("******CADASTRO DE SÉRIE*********");
            Console.WriteLine("*************************************");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualiar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine()
            .ToUpper();
            Console.WriteLine();
            return opcaoUsuario;            

        }
    }
}
