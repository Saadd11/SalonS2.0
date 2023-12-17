using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalonS.Models;
using SalonS.Services;
using System;

public class BookingConfirmationModel : PageModel
{
    private readonly BookingRepository _bookingRepository;

    public BookingConfirmationModel(BookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public Booking? Booking { get; private set; }

    public void OnGet(int id)
    {
        // Fetch the booking details based on the provided ID
        Booking = _bookingRepository.GetBookingById(id);

        if (Booking == null)
        {
            // Handle the case where the booking is not found
            RedirectToPage("Error"); // Redirect to an error page or handle differently
        }
    }
}