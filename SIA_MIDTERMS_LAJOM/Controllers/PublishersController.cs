using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIA_MIDTERMS_LAJOM.Models;
using SIA_MIDTERMS_LAJOM.Models.DTO.PublisherDTO;
using SIA_MIDTERMS_LAJOM.Models.Repositories;

namespace SIA_MIDTERMS_LAJOM.Controllers
{
    public class PublishersController : Controller
    {
        private readonly IPublisherRepository _PublisherRepo;
        private readonly IMapper _mapper;

        public PublishersController(IPublisherRepository PublisherRepo, IMapper mapper)
        {
            _PublisherRepo = PublisherRepo;
            _mapper = mapper;
        }

        //GET: Publishers
        public async Task<IActionResult> Index()
        {
            var Publishers = await _PublisherRepo.GetAllAsync();
            var dto = _mapper.Map<IEnumerable<PublisherReadDTO>>(Publishers);
            return View(dto);
        }

        // GET: Publishers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var Publisher = await _PublisherRepo.GetByIdAsync(id);
            if (Publisher == null) return NotFound();

            var dto = _mapper.Map<PublisherReadDTO>(Publisher);
            return View(dto);
        }

        // GET: Publishers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publishers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PublisherCreateDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var Publisher = _mapper.Map<Publisher>(dto);
            await _PublisherRepo.CreateAsync(Publisher);

            return RedirectToAction(nameof(Index));
        }

        // GET: Publishers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var Publisher = await _PublisherRepo.GetByIdAsync(id);
            if (Publisher == null) return NotFound();

            var dto = _mapper.Map<PublisherUpdateDTO>(Publisher);
            return View(dto);
        }

        // POST: Publishers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PublisherUpdateDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var Publisher = _mapper.Map<Publisher>(dto);
            await _PublisherRepo.UpdateAsync(Publisher);

            return RedirectToAction(nameof(Index));
        }

        // GET: Publishers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var Publisher = await _PublisherRepo.GetByIdAsync(id);
            if (Publisher == null) return NotFound();

            var dto = _mapper.Map<PublisherReadDTO>(Publisher);
            return View(dto);
        }

        // POST: Publishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _PublisherRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
