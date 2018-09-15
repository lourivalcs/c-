using Servicos.Tabelas;
using System.Net;
using System.Web.Mvc;
using WebProjectMVC.Modelo.Tabelas;

namespace WebProjectMVC.Areas.Tabelas.Controllers
{
    [Authorize(Roles = "Administradores")]
    public class CategoriasController : Controller
    {

        private CategoriaServico categoriaServico = new CategoriaServico();
        
        // GET: Categorias
        public ActionResult Index()
        {
            return View(categoriaServico.BuscaCategorias());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            categoriaServico.GravaCategoria(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long? id)
        {
            return VerificaCategoria(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoriaServico.GravaCategoria(categoria);
                return RedirectToAction("Index");
            }
            else
                return View(categoria);
        }

        public ActionResult Details(long? id)
        {
            return VerificaCategoria(id);
        }

        public ActionResult Delete(long? id)
        {
            return VerificaCategoria(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Categoria categoria = categoriaServico.ExluirCategoriaPorID((long)id);
            TempData["Mensagem"] = "A categoria " + categoria.Nome.ToUpper() + " foi removida";
            return RedirectToAction("Index");
        }

        public ActionResult VerificaCategoria(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Categoria categoria = categoriaServico.BuscaCategoriaPorID((long)id);

            if (categoria == null)
                return HttpNotFound();

            return View(categoria);
        }
    }
}