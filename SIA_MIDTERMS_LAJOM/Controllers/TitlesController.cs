using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIA_MIDTERMS_LAJOM.Models;
using SIA_MIDTERMS_LAJOM.Models.DTO.TitleDTO;
using SIA_MIDTERMS_LAJOM.Models.Repositories;

namespace SIA_MIDTERMS_LAJOM.Controllers
{
    public class TitlesController : Controller
    {
        private readonly ITitleRepository _TitleRepo;
        private readonly IMapper _mapper;

        public TitlesController(ITitleRepository TitleRepo, IMapper mapper)
        {
            _TitleRepo = TitleRepo;
            _mapper = mapper;
        }

        //GET: Titles
        public async Task<IActionResult> Index()
        {
            var Titles = await _TitleRepo.GetAllAsync();
            var dto = _mapper.Map<IEnumerable<TitleReadDTO>>(Titles);
            return View(dto);
        }

        // GET: Titles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var Title = await _TitleRepo.GetByIdAsync(id);
            if (Title == null) return NotFound();

            var dto = _mapper.Map<TitleReadDTO>(Title);
            return View(dto);
        }

        // GET: Titles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Titles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TitleCreateDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var Title = _mapper.Map<Title>(dto);
            await _TitleRepo.CreateAsync(Title);

            return RedirectToAction(nameof(Index));
        }

        // GET: Titles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var Title = await _TitleRepo.GetByIdAsync(id);
            if (Title == null) return NotFound();

            var dto = _mapper.Map<TitleUpdateDTO>(Title);
            return View(dto);
        }

        // POST: Titles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TitleUpdateDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var Title = _mapper.Map<Title>(dto);
            await _TitleRepo.UpdateAsync(Title);

            return RedirectToAction(nameof(Index));
        }

        // GET: Titles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var Title = await _TitleRepo.GetByIdAsync(id);
            if (Title == null) return NotFound();

            var dto = _mapper.Map<TitleReadDTO>(Title);
            return View(dto);
        }

        // POST: Titles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _TitleRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
