using Domain.Dto;
using Infraestructure.Interfaces;
using Livros.Tests.Helpers;

namespace Livros.Tests
{
    public class LivroTestts
    {
        public readonly ILivroRepository _livro;
        

        [Fact]
        public async void CreateLivro()
        {
            var Autor = "Autor Teste";
            var Titulo = "Título Teste";
            var Descricao = "Descrição do livro-teste";
            var Isbn = "T132465";

            var livro = new LivroDto() 
            { 
                Autor= Autor,
                Descricao   = Descricao,
                Titulo= Titulo,
                Isbn= Isbn
            };

           // await using var context = new MockDatabase().CreateDbContext();

            var result = await _livro.AddDadosLivro(livro);

        }
    }
}