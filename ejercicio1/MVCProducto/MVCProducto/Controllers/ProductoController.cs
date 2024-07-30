using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCProducto.Models;

namespace MVCProducto.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductosDBContext _context;

        public ProductoController(ProductosDBContext context)
        {
            _context = context;
        }

        // GET: Peliculas
        public async Task<IActionResult> Index(string textoABuscar)
        {
            if (_context.Producto == null)
            {
                return Problem("No se ha inicializado elcontexto");
            }

            var peliculas = from p in _context.Producto
                            select p;

            if (!String.IsNullOrEmpty(textoABuscar))
            {
                peliculas = peliculas.Where(p => p.NombreProducto.Contains(textoABuscar));
            }

            return View(await peliculas.ToListAsync());

            //var peliculasDBContext = _context.Peliculas.Include(p => p.Genero);
            //return View(await peliculasDBContext.ToListAsync());
        }

        // GET: Peliculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Producto
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        // GET: Peliculas/Create
        public IActionResult Create()
        {
            ViewData["GeneroId"] = new SelectList(_context.Categoria, "Id", "Id");
            return View();
        }

        // POST: Peliculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public string Index(string textoABuscar, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + textoABuscar;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Titulo,FechaLanzamiento,GeneroId,Precio,Director")] Producto pelicula)
        {
            //Removemos la validacion de la propiedad de navegacion de genero
            ModelState.Remove("Genero");

            if (ModelState.IsValid)
            {
                _context.Add(pelicula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GeneroId"] = new SelectList(_context.Categoria, "Id", "Id", pelicula.CodigoCategoria);
            return View(pelicula);
        }

        // GET: Peliculas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Producto.FindAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            ViewData["GeneroId"] = new SelectList(_context.Categoria, "Id", "Id", pelicula.CodigoCategoria);
            return View(pelicula);
        }

        // POST: Peliculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Titulo,FechaLanzamiento,GeneroId,Precio,Director")] Producto pelicula)
        {
            //Removemos la validacion de la propiedad de navegacion Genero
            ModelState.Remove("Genero");


            if (id != pelicula.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pelicula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeliculaExists(pelicula.ID))
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
            ViewData["GeneroId"] = new SelectList(_context.Categoria, "Id", "Id", pelicula.CodigoCategoria);
            return View(pelicula);
        }

        // GET: Peliculas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Producto
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pelicula = await _context.Producto.FindAsync(id);
            if (pelicula != null)
            {
                _context.Producto.Remove(pelicula);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeliculaExists(int id)
        {
            return _context.Producto.Any(e => e.ID == id);
        }
    }
}
