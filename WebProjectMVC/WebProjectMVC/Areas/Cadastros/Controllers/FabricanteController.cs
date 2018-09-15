using Servicos.Cadastros;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebProjectMVC.Modelo.Cadastros;

namespace WebProjectMVC.Areas.Cadastros.Controllers
{
    [Authorize(Roles = "Administradores")]
    public class FabricanteController : Controller
    {

        private FabricanteServico fabricanteServico = new FabricanteServico();

        // GET: Fabricante
        public ActionResult Index()
        {
            return View(fabricanteServico.BuscaFabricantes());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            fabricanteServico.GravaFabricante(fabricante);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long? id)
        {
            return VisaoFabricante(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                fabricanteServico.GravaFabricante(fabricante);
                return RedirectToAction("Index");
            }
            else
                return View(fabricante);
        }

        public ActionResult Details(long? id)
        {
            return VisaoFabricante(id);
        }

        public ActionResult Delete(long? id)
        {
            return VisaoFabricante(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Fabricante fab = fabricanteServico.ExcluiFabricantePorID((long)id);
            TempData["Mensagem"] = "O Fabricante " + fab.Nome.ToUpper() + " foi removido";
            return RedirectToAction("Index");
        }

        public ActionResult VisaoFabricante(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Fabricante fabricante = fabricanteServico.BuscaFabricantePorID((long)id);

            if (fabricante == null)
                return HttpNotFound();

            return View(fabricante);
        }
    }
}