using Gestao.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gestao.Models;

namespace Gestao.Controllers
{
    public class SalaController : Controller
    {
        private readonly GestaoContext _context;

        public SalaController(GestaoContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Salas.OrderBy(x => x.Nome).AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar(int? id)
        {
            if (id.HasValue)
            {
                var salas = await _context.Salas.FindAsync(id);
                if (salas == null)
                {
                    return NotFound();
                }
                return View(salas);
            }
            return View(new SalasModel());
        }

        private bool CategoriaExistente(int id)
        {
            return _context.Salas.Any(x => x.IdSala == id);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(int? id, [FromForm] SalasModel salas)
        {
            if (ModelState.IsValid)
            {
                if (id.HasValue)
                {
                    if (CategoriaExistente(id.Value))
                    {
                        _context.Update(salas);
                        if (await _context.SaveChangesAsync() > 0)
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Categoria alterada com sucesso!");
                        }
                        else
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Erro ao alterar a categoria", TipoMensagem.Erro);
                        }
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Categoria não encontrada!", TipoMensagem.Erro);
                    }
                }
                else
                {
                    _context.Add(salas);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Categoria cadastrada com sucesso!");
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Erro ao cadastrar a categoria!", TipoMensagem.Erro);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(salas);
            }
        }

    }
}
