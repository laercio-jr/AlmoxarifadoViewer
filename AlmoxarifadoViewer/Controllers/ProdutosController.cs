using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlmoxarifadoViewer.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace AlmoxarifadoViewer.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly AlmoxarifadoDbContext _context;

        public ProdutosController(AlmoxarifadoDbContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index(string searchString)
        {
            var produtosContext = from m in _context.Produtos select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                produtosContext = from p in produtosContext where p.Nome.Contains(searchString) || p.CodigoSap.ToString().Contains(searchString) select p;
                /*produtosContext = produtosContext.Where(s => s.Nome.Contains(searchString) || s.CodigoSap.ToString().Contains(searchString));*/
            }
            return View(await produtosContext.ToListAsync());
        }

        public IActionResult VerPNG(int id)
        {
            var produtosContexto = _context.Produtos.FirstOrDefault(a => a.ProdutoId == id);
            return File(produtosContexto.Imagem1, "image/png");
        }
        public IActionResult VerPNG2(int id)
        {
            var produtosContexto = _context.Produtos.FirstOrDefault(a => a.ProdutoId == id);
            return File(produtosContexto.Imagem2, "image/png");
        }
        public IActionResult VerPNG3(int id)
        {
            var produtosContexto = _context.Produtos.FirstOrDefault(a => a.ProdutoId == id);
            return File(produtosContexto.Imagem3, "image/png");
        }
        public IActionResult VerPNG4(int id)
        {
            var produtosContexto = _context.Produtos.FirstOrDefault(a => a.ProdutoId == id);
            return File(produtosContexto.Imagem4, "image/png");
        }
        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile imagem1, IFormFile imagem2, IFormFile imagem3, IFormFile imagem4, [Bind("ProdutoId,CodigoSap,Nome,Imagem1,Imagem2,Imagem3,Imagem4,Quantidade")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                if (imagem1 != null)
                {
                    MemoryStream ms = new MemoryStream();
                    imagem1.OpenReadStream().CopyTo(ms);
                    produto.Imagem1 = ms.ToArray();
                }
                if (imagem2 != null)
                {
                    MemoryStream ms = new MemoryStream();
                    imagem2.OpenReadStream().CopyTo(ms);
                    produto.Imagem2 = ms.ToArray();
                }
                if (imagem3 != null)
                {
                    MemoryStream ms = new MemoryStream();
                    imagem3.OpenReadStream().CopyTo(ms);
                    produto.Imagem3 = ms.ToArray();
                }
                if (imagem4 != null)
                {
                    MemoryStream ms = new MemoryStream();
                    imagem4.OpenReadStream().CopyTo(ms);
                    produto.Imagem4 = ms.ToArray();
                }

                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdutoId,CodigoSap,Nome,Imagem1,Imagem2,Imagem3,Imagem4,Quantidade")] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.ProdutoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.ProdutoId == id);
        }
    }
}
