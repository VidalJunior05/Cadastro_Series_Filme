using System;

namespace Cadastro_Series{
    class Program{
        static SerieRepositorio repositorio = new SerieRepositorio();
		static FilmeRepositorio repositorio_Filme = new FilmeRepositorio();
      
        static void Main(string[] args){
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X"){
				switch (opcaoUsuario){
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
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
					case "6":
						ListarFilmes();
						break;
					case "7":
						InserirFilme();
						break;
					case "8":
						AtualizarFilme();
						break;
					case "9":
						ExcluirFilme();
						break;
					case "10":
						VisualizarFilme();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Volte sempre,foi um prazer tê-los aqui.");
			Console.ReadLine();
        }

        private static void ExcluirSerie(){
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			
			Console.WriteLine("Deseja excluir ? Digite S para sim e N para não");
			string confirmarExcluir = Console.ReadLine();
			
			 if(confirmarExcluir.ToUpper() == "S"){
				repositorio.Exclui(indiceSerie);
				Console.Write("Série excluída");
				Console.WriteLine();
			 }else{
				 Console.Write("A Série não foi excluída!");
				 Console.WriteLine();
			 }
			
		}

		private static void ExcluirFilme(){
			Console.Write("Digite o id do Filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			
			Console.WriteLine("Deseja excluir ? Digite S para sim e N para não");
			string confirmarExcluir2 = Console.ReadLine();
			
			 if(confirmarExcluir2.ToUpper() == "S"){
				repositorio_Filme.Exclui(indiceFilme);
				Console.Write("Filme excluído");
				Console.WriteLine();
			 }else{
				 Console.Write("O Filme não foi excluído!");
				 Console.WriteLine();
			 }
			
		
		}
        private static void VisualizarSerie(){
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}
		private static void VisualizarFilme(){
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			var filme = repositorio_Filme.RetornaPorId(indiceFilme);
			Console.WriteLine(filme);
		}

        private static void AtualizarSerie(){
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero))){
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}

		private static void AtualizarFilme(){
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			foreach(int i in Enum.GetValues(typeof(Genero))){
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Escolha o gênero do filme, de acordo com as opções listadas acima: ");
			int entradaGenero_Filme = int.Parse(Console.ReadLine());

			Console.Write("Digite o título do filme: ");
			string entradaTitulo_Filme = Console.ReadLine();

			Console.Write("Digite o Ano de lançamento do filme: ");
			int entradaAno_Filme = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do filme: ");
			string entradaDescricao_Filme = Console.ReadLine();

			Filme atualizaFilme = new Filme (id:indiceFilme,
											 genero: (Genero)entradaGenero_Filme,
											 Titulo_Filme: entradaTitulo_Filme,
											 Ano_Filme: entradaAno_Filme,
											 Descricao_Filme : entradaDescricao_Filme);

			repositorio_Filme.Atualiza(indiceFilme, atualizaFilme);
			
		}
        private static void ListarSeries(){
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0){
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}
			foreach (var serie in lista){
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID_Série {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Série Excluída*" : ""));
			}
		}

		private static void ListarFilmes(){
			Console.WriteLine("Listar filmes");

			var lista_filme = repositorio_Filme.Lista();
			if(lista_filme.Count == 0){
				Console.WriteLine("Nenhum filme cadastrado");
				return;	
			}
			foreach(var filme in lista_filme){
				var excluido = filme.retornaExcluido();
				
				Console.WriteLine("#ID_Filme {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Filme Excluído*" : ""));
			}
		}

        private static void InserirSerie(){
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero))){
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}
		private static void InserirFilme(){
			Console.WriteLine("Insira um novo filme: ");

			foreach(int i in Enum.GetValues(typeof(Genero))){
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero_Filme = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do filme: ");
			string entradaTitulo_Filme = Console.ReadLine();

			Console.Write("Digite o Ano de lançamento do filme: ");
			int entradaAno_Filme = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do filme: ");
			string entradaDescricao_Filme = Console.ReadLine();

			Filme novoFilme = new Filme (id: repositorio_Filme.ProximoId(),
											 genero: (Genero)entradaGenero_Filme,
											 Titulo_Filme: entradaTitulo_Filme,
											 Ano_Filme: entradaAno_Filme,
											 Descricao_Filme : entradaDescricao_Filme);

			repositorio_Filme.Insere(novoFilme);
			
		}

        private static string ObterOpcaoUsuario(){
			Console.WriteLine();
			Console.WriteLine("Bem vido a CodiFlix");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("6- Listar filmes");
			Console.WriteLine("7- Inserir novo filme");
			Console.WriteLine("8- Atualizar filme");
			Console.WriteLine("9- Excluir filme");
			Console.WriteLine("10- Visualizar filme");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}