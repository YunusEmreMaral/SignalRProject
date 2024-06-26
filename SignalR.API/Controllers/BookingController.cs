﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookindDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }
    [HttpGet]
    public IActionResult BookingList()
    {
        var values = _bookingService.TGetListAll();
        return Ok(values);
    }
    [HttpPost]
    public IActionResult CreateBooking(CreateBookingDto createBookingDto)
    {
        Booking booking = new Booking()
        {
            Mail = createBookingDto.Mail,
            Name = createBookingDto.Name,
            Date = createBookingDto.Date,
            PersonelCount = createBookingDto.PersonelCount,
            Phone = createBookingDto.Phone
        };
        _bookingService.TAdd(booking);
        return Ok("Reservasyon alındı");
    }
	[HttpDelete("{id}")]
	public IActionResult DeleteBooking(int id)
    {
        var values = _bookingService.TGetByID(id);
        _bookingService.TDelete(values);
        return Ok("Reservasyon silindi.");
    }

    [HttpPut] 
    public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
    {
        Booking booking = new Booking()
        {
            BookingID = updateBookingDto.BookingID,
            Mail = updateBookingDto.Mail,
            Name = updateBookingDto.Name,
            Date = updateBookingDto.Date,
            PersonelCount = updateBookingDto.PersonelCount,
            Phone = updateBookingDto.Phone
        };
        _bookingService.TUpdate(booking);
        return Ok("Reservasyon güncellendi");
    }

	[HttpGet("{id}")]
	public IActionResult GetBooking(int id)
    {
        var values = _bookingService.TGetByID(id);
        return Ok(values);
    }
}
