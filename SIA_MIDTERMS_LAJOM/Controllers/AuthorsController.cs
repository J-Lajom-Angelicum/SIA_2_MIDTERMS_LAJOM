using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIA_MIDTERMS_LAJOM.Models.Repositories;
using SIA_MIDTERMS_LAJOM.Models.DTO.AuthorDTO;
using SIA_MIDTERMS_LAJOM.Models;

namespace SIA_MIDTERMS_LAJOM.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorRepository _AuthorRepo;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorRepository AuthorRepo, IMapper mapper)
        {
            _AuthorRepo = AuthorRepo;
            _mapper = mapper;
        }

        //GET: Authors
        public async Task<IActionResult> Index()
        {
            var Authors = await _AuthorRepo.GetAllAsync();
            var dto = _mapper.Map<IEnumerable<AuthorReadDTO>>(Authors);
            return View(dto);
        }

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var Author = await _AuthorRepo.GetByIdAsync(id);
            if (Author == null) return NotFound();

            var dto = _mapper.Map<AuthorReadDTO>(Author);
            return View(dto);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuthorCreateDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var author = _mapper.Map<Author>(dto);
            await _AuthorRepo.CreateAsync(author);

            return RedirectToAction(nameof(Index));
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var Author = await _AuthorRepo.GetByIdAsync(id);
            if (Author == null) return NotFound();

            var dto = _mapper.Map<AuthorUpdateDTO>(Author);
            return View(dto);
        }

        // POST: Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AuthorUpdateDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var author = _mapper.Map<Author>(dto);
            await _AuthorRepo.UpdateAsync(author);

            return RedirectToAction(nameof(Index));
        }

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var Author = await _AuthorRepo.GetByIdAsync(id);
            if (Author == null) return NotFound();

            var dto = _mapper.Map<AuthorReadDTO>(Author);
            return View(dto);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _AuthorRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }




    }
}
