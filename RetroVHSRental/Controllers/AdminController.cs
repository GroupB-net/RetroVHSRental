using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetroVHSRental.Models;
using RetroVHSRental.Repository;

namespace RetroVHSRental.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBookingRepository bookingRepository;

        public AdminController(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }
        // GET: AdminController
        public async Task<IActionResult> BookingIndex()
        {
            var bookings = await bookingRepository.GetAllAsync();
            return View(bookings);
        }

        // GET: AdminController/Details/5
        public async Task<IActionResult> BookingDetails(int id)
        {
            var booking = await bookingRepository.GetBookingByIdAsync(id);
            return View(booking);
        }

        // GET: AdminController/Edit/5
        public async Task<IActionResult> BookingEdit(int id)
        {
            var booking = await bookingRepository.GetBookingByIdAsync(id);
            return View(booking);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookingEdit(Booking booking)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await bookingRepository.UpdateBookingAsync(booking);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public async Task<IActionResult> BookingDelete(int id)
        {
            var booking = await bookingRepository.GetBookingByIdAsync(id);
            return View(booking);
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookingDelete(Booking booking)
        {
            try
            {
                await bookingRepository.RemoveBookingAsync(booking);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
