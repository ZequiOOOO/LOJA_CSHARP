using Microsoft.AspNetCore.Mvc;
using ProJeto_Cliente_Produto.Models;
using servico;
using System.Diagnostics;

namespace ProjetoCarros.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult Produto()
        {
            var db = new DB();
            var viewModel = new ProdutoViewModel() { listaProduto = [] };
            try
            {

                var listaProdutoTO = db.GetProdutos();

                var listaProduto = new List<Produto>();

                foreach (var produtoTO in listaProdutoTO)
                {
                    listaProduto.Add(new Produto()
                    {
                        Id = produtoTO.Id,
                        Nome = produtoTO.Nome,
                        Descricao = produtoTO.Descricao,
                        Preco = produtoTO.Preco,
                        Estoque = produtoTO.Estoque,
                        DataAdicionado = produtoTO.DataAdicionado
                    });
                }

                viewModel.listaProduto = listaProduto;
            }
            catch (Exception ex)
            {
                viewModel.erros.Add(ex.ToString());
                viewModel.erros.Add(ex.Message.ToString());
            }


            return View(viewModel);
        }


       // public IActionResult PersistirProduto()
       // {
            //var db = new DB();
            //ainda em construção
        ///}

        public IActionResult Deletar(int Id)
        {
            var db = new DB();

            db.DeletarProduto(Id);

            return RedirectToAction("Produtos");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}