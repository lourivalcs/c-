using System.Web.Mvc;
using System.Net;
using WebProjectMVC.Modelo.Cadastros;
using Servicos.Cadastros;
using Servicos.Tabelas;
using System.Web;
using System.IO;
using System;

namespace WebProjectMVC.Areas.Cadastros.Controllers
{
    [Authorize(Roles = "Administradores, Usuarios")]
    public class ProdutosController : Controller
    {
        private ProdutoServico produtoServico = new ProdutoServico();
        private CategoriaServico categoriaServico = new CategoriaServico();
        private FabricanteServico fabricanteServico = new FabricanteServico();

        // GET: Produtos
        public ActionResult Index()
        {
            return View(produtoServico.BuscaProdutos());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(long? id)
        {
            return VisaoProduto(id);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            InsereViewBag();
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            return GravarProduto(produto, null, null);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(long? id)
        {
            InsereViewBag(produtoServico.BuscaProdutoPorId((long)id));
            return VisaoProduto(id);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        public ActionResult Edit(Produto produto, HttpPostedFileBase logo, string chkRemoverImagem = null)
        {
            return GravarProduto(produto, logo, chkRemoverImagem);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(long? id)
        {
            return VisaoProduto(id);
        }

        // POST: Produtos/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Produto produto = produtoServico.ExcluirProdutoPorId((long)id);
                TempData["Mensagem"] = "O Produto " + produto.Nome.ToUpper() + " foi removido";

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private ActionResult VisaoProduto(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Produto produto = produtoServico.BuscaProdutoPorId((long)id);

            if (produto == null)
                return HttpNotFound();

            return View(produto);
        }

        private void InsereViewBag(Produto produto = null)
        {
            if (produto == null)
            {
                ViewBag.IdCategoria = new SelectList(categoriaServico.BuscaCategorias(), "IdCategoria", "Nome");
                ViewBag.IdFabricante = new SelectList(fabricanteServico.BuscaFabricantes(), "IdFabricante", "Nome");
            }
            else
            {
                ViewBag.IdCategoria = new SelectList(categoriaServico.BuscaCategorias(), "IdCategoria", "Nome", produto.IdCategoria);
                ViewBag.IdFabricante = new SelectList(fabricanteServico.BuscaFabricantes(), "IdFabricante", "Nome", produto.IdFabricante);
            }
        }

        private ActionResult GravarProduto(Produto produto, HttpPostedFileBase logotipo, string chkRemoverImagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (chkRemoverImagem != null)
                    {
                        produto.Logotipo = null;
                    }
                    if (logotipo != null)
                    {
                        produto.LogotipoMimeType = logotipo.ContentType;
                        produto.Logotipo = SetLogotipo(logotipo);
                        produto.NomeArquivo = logotipo.FileName;
                        produto.TamanhoArquivo = logotipo.ContentLength;
                    }
                    produtoServico.GravarProduto(produto);
                    return RedirectToAction("Index");
                }
                InsereViewBag(produto);
                return View(produto);
            }
            catch
            {
                InsereViewBag();
                return View(produto);
            }
        }

        private byte[] SetLogotipo(HttpPostedFileBase logotipo)
        {
            var bytesLogotipo = new byte[logotipo.ContentLength];
            logotipo.InputStream.Read(bytesLogotipo, 0, logotipo.ContentLength);
            return bytesLogotipo;
        }

        public FileContentResult GetLogotipo(long id)
        {
            Produto produto = produtoServico.BuscaProdutoPorId(id);
            if (produto != null)
            {
                return File(produto.Logotipo, produto.LogotipoMimeType);
            }
            return null;
        }

        public ActionResult DownloadArquivo(long id)        {
            Produto produto = produtoServico.BuscaProdutoPorId(id);
            FileStream fileStream = new FileStream(Server.MapPath("~/TempData/" + produto.NomeArquivo), FileMode.Create, FileAccess.Write);
            fileStream.Write(produto.Logotipo, 0, Convert.ToInt32(produto.TamanhoArquivo));
            fileStream.Close();
            return File(fileStream.Name, produto.LogotipoMimeType, produto.NomeArquivo);
        }
    }
}
