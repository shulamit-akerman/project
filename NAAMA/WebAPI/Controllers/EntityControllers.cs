using AutoMapper;
using BLL.Repositories;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NAAMA.DTOs;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/bookings")]
public sealed class BookingsController(IBookingRepository repository, IMapper mapper)
    : CrudController<Booking, CreateBookingDto, UpdateBookingDto, BookingResponseDto, int>(mapper)
{
    protected override Task<Booking?> FindAsync(int id) => repository.GetByIdAsync(id);
    protected override Task<IReadOnlyList<Booking>> ListAsync() => repository.GetAllAsync();
    protected override Task<Booking> InsertAsync(Booking entity) => repository.AddAsync(entity);
    protected override Task UpdateAsync(int id, Booking entity) => repository.UpdateAsync(id, entity);
    protected override Task DeleteAsync(int id) => repository.DeleteAsync(id);
    protected override int GetId(Booking entity) => entity.BookingId;
    protected override void SetId(Booking entity, int id) => entity.BookingId = id;
}

[ApiController]
[Route("api/chat-messages")]
public sealed class ChatMessagesController(IChatMessageRepository repository, IMapper mapper)
    : CrudController<ChatMessage, CreateChatMessageDto, UpdateChatMessageDto, ChatMessageResponseDto, int>(mapper)
{
    protected override Task<ChatMessage?> FindAsync(int id) => repository.GetByIdAsync(id);
    protected override Task<IReadOnlyList<ChatMessage>> ListAsync() => repository.GetAllAsync();
    protected override Task<ChatMessage> InsertAsync(ChatMessage entity) => repository.AddAsync(entity);
    protected override Task UpdateAsync(int id, ChatMessage entity) => repository.UpdateAsync(id, entity);
    protected override Task DeleteAsync(int id) => repository.DeleteAsync(id);
    protected override int GetId(ChatMessage entity) => entity.MessageId;
    protected override void SetId(ChatMessage entity, int id) => entity.MessageId = id;
    protected override void PrepareForCreate(ChatMessage entity) => entity.SentAt = DateTime.UtcNow;
}

[ApiController]
[Route("api/massage-to-bookings")]
public sealed class MassageToBookingsController(IMassageToBookingRepository repository, IMapper mapper)
    : CrudController<MassageToBooking, CreateMassageToBookingDto, UpdateMassageToBookingDto,
        MassageToBookingResponseDto, int>(mapper)
{
    [HttpGet("by-booking/{bookingId:int}")]
    public async Task<ActionResult<IReadOnlyList<MassageToBookingResponseDto>>> GetByBookingId(int bookingId)
    {
        var messages = await repository.GetByBookingIdAsync(bookingId);
        return Ok(Map<IReadOnlyList<MassageToBookingResponseDto>>(messages));
    }

    protected override Task<MassageToBooking?> FindAsync(int id) => repository.GetByIdAsync(id);
    protected override Task<IReadOnlyList<MassageToBooking>> ListAsync() => repository.GetAllAsync();
    protected override Task<MassageToBooking> InsertAsync(MassageToBooking entity) => repository.AddAsync(entity);
    protected override Task UpdateAsync(int id, MassageToBooking entity) => repository.UpdateAsync(id, entity);
    protected override Task DeleteAsync(int id) => repository.DeleteAsync(id);
    protected override int GetId(MassageToBooking entity) => entity.MassageToBookingId;
    protected override void SetId(MassageToBooking entity, int id) => entity.MassageToBookingId = id;
}

[ApiController]
[Route("api/payments")]
public sealed class PaymentsController(IPaymentRepository repository, IMapper mapper)
    : CrudController<Payments, CreatePaymentDto, UpdatePaymentDto, PaymentResponseDto, int>(mapper)
{
    [HttpGet("booking/{bookingId:int}/latest")]
    public async Task<ActionResult<PaymentResponseDto>> GetLatestByBookingId(int bookingId)
    {
        var payment = await repository.GetLatestByBookingIdAsync(bookingId);
        return payment is null ? NotFound() : Ok(Map<PaymentResponseDto>(payment));
    }

    protected override Task<Payments?> FindAsync(int id) => repository.GetByIdAsync(id);
    protected override Task<IReadOnlyList<Payments>> ListAsync() => repository.GetAllAsync();
    protected override Task<Payments> InsertAsync(Payments entity) => repository.AddAsync(entity);
    protected override Task UpdateAsync(int id, Payments entity) => repository.UpdateAsync(id, entity);
    protected override Task DeleteAsync(int id) => repository.DeleteAsync(id);
    protected override int GetId(Payments entity) => entity.PaymentsId;
    protected override void SetId(Payments entity, int id) => entity.PaymentsId = id;
    protected override void PrepareForCreate(Payments entity)
    {
        entity.PaymentStatus = 0;
        entity.CreateAt = DateTime.UtcNow;
    }
}

[ApiController]
[Route("api/requests")]
public sealed class RequestsController(IRequestRepository repository, IMapper mapper)
    : CrudController<Request, CreateRequestDto, UpdateRequestDto, RequestResponseDto, string>(mapper)
{
    [HttpGet("matching")]
    public async Task<ActionResult<IReadOnlyList<RequestResponseDto>>> FindMatching(
        [FromQuery] bool hasTrunk,
        [FromQuery] bool fitsStroller,
        [FromQuery] bool childSeats)
    {
        var matches = await repository.FindMatchingAsync(hasTrunk, fitsStroller, childSeats);
        return Ok(Map<IReadOnlyList<RequestResponseDto>>(matches));
    }

    protected override Task<Request?> FindAsync(string id) => repository.GetByIdAsync(id);
    protected override Task<IReadOnlyList<Request>> ListAsync() => repository.GetAllAsync();
    protected override Task<Request> InsertAsync(Request entity) => repository.AddAsync(entity);
    protected override Task UpdateAsync(string id, Request entity) => repository.UpdateAsync(id, entity);
    protected override Task DeleteAsync(string id) => repository.DeleteAsync(id);
    protected override string GetId(Request entity) => entity.RequestId;
    protected override void SetId(Request entity, string id) => entity.RequestId = id;
    protected override void PrepareForCreate(Request entity) => entity.RequestId = Guid.NewGuid().ToString("N");
}

[ApiController]
[Route("api/request-to-rides")]
public sealed class RequestToRidesController(IRequestToRideRepository repository, IMapper mapper)
    : CrudController<RequestToRide, CreateRequestToRideDto, UpdateRequestToRideDto,
        RequestToRideResponseDto, string>(mapper)
{
    [HttpGet("by-ride/{rideId}")]
    public async Task<ActionResult<IReadOnlyList<RequestToRideResponseDto>>> GetByRideId(string rideId)
    {
        var relations = await repository.GetByRideIdAsync(rideId);
        return Ok(Map<IReadOnlyList<RequestToRideResponseDto>>(relations));
    }

    protected override Task<RequestToRide?> FindAsync(string id) => repository.GetByIdAsync(id);
    protected override Task<IReadOnlyList<RequestToRide>> ListAsync() => repository.GetAllAsync();
    protected override Task<RequestToRide> InsertAsync(RequestToRide entity) => repository.AddAsync(entity);
    protected override Task UpdateAsync(string id, RequestToRide entity) => repository.UpdateAsync(id, entity);
    protected override Task DeleteAsync(string id) => repository.DeleteAsync(id);
    protected override string GetId(RequestToRide entity) => entity.RequestToRideId;
    protected override void SetId(RequestToRide entity, string id) => entity.RequestToRideId = id;
    protected override void PrepareForCreate(RequestToRide entity) =>
        entity.RequestToRideId = Guid.NewGuid().ToString("N");
}

[ApiController]
[Route("api/request-to-vehicles")]
public sealed class RequestToVehiclesController(IRequestToVehiclesRepository repository, IMapper mapper)
    : CrudController<RequestToVehicles, CreateRequestToVehiclesDto, UpdateRequestToVehiclesDto,
        RequestToVehiclesResponseDto, string>(mapper)
{
    [HttpGet("by-vehicle/{vehicleId}")]
    public async Task<ActionResult<IReadOnlyList<RequestToVehiclesResponseDto>>> GetByVehicleId(string vehicleId)
    {
        var relations = await repository.GetByVehicleIdAsync(vehicleId);
        return Ok(Map<IReadOnlyList<RequestToVehiclesResponseDto>>(relations));
    }

    protected override Task<RequestToVehicles?> FindAsync(string id) => repository.GetByIdAsync(id);
    protected override Task<IReadOnlyList<RequestToVehicles>> ListAsync() => repository.GetAllAsync();
    protected override Task<RequestToVehicles> InsertAsync(RequestToVehicles entity) => repository.AddAsync(entity);
    protected override Task UpdateAsync(string id, RequestToVehicles entity) => repository.UpdateAsync(id, entity);
    protected override Task DeleteAsync(string id) => repository.DeleteAsync(id);
    protected override string GetId(RequestToVehicles entity) => entity.RequestToVehiclesId;
    protected override void SetId(RequestToVehicles entity, string id) => entity.RequestToVehiclesId = id;
    protected override void PrepareForCreate(RequestToVehicles entity) =>
        entity.RequestToVehiclesId = Guid.NewGuid().ToString("N");
}

[ApiController]
[Route("api/ride-requests")]
public sealed class RideRequestsController(IRideRequestRepository repository, IMapper mapper)
    : CrudController<RideRequest, CreateRideRequestDto, UpdateRideRequestDto, RideRequestResponseDto, int>(mapper)
{
    protected override Task<RideRequest?> FindAsync(int id) => repository.GetByIdAsync(id);
    protected override Task<IReadOnlyList<RideRequest>> ListAsync() => repository.GetAllAsync();
    protected override Task<RideRequest> InsertAsync(RideRequest entity) => repository.AddAsync(entity);
    protected override Task UpdateAsync(int id, RideRequest entity) => repository.UpdateAsync(id, entity);
    protected override Task DeleteAsync(int id) => repository.DeleteAsync(id);
    protected override int GetId(RideRequest entity) => entity.RequestId;
    protected override void SetId(RideRequest entity, int id) => entity.RequestId = id;
    protected override void PrepareForCreate(RideRequest entity)
    {
        entity.RequestedTime = DateTime.UtcNow;
        entity.Status = 0;
    }
}

[ApiController]
[Route("api/rides")]
public sealed class RidesController(IRideRepository repository, IMapper mapper)
    : CrudController<Ride, CreateRideDto, UpdateRideDto, RideResponseDto, int>(mapper)
{
    protected override Task<Ride?> FindAsync(int id) => repository.GetByIdAsync(id);
    protected override Task<IReadOnlyList<Ride>> ListAsync() => repository.GetAllAsync();
    protected override Task<Ride> InsertAsync(Ride entity) => repository.AddAsync(entity);
    protected override Task UpdateAsync(int id, Ride entity) => repository.UpdateAsync(id, entity);
    protected override Task DeleteAsync(int id) => repository.DeleteAsync(id);
    protected override int GetId(Ride entity) => entity.RideId;
    protected override void SetId(Ride entity, int id) => entity.RideId = id;
    protected override void PrepareForCreate(Ride entity) => entity.Status = 0;
}

[ApiController]
[Route("api/users")]
public sealed class UsersController(
    IUserRepository repository,
    IMapper mapper,
    IPasswordHasher<Users> passwordHasher)
    : CrudController<Users, CreateUserDto, UpdateUserProfileEntityDto, UserResponseDto, int>(mapper)
{
    protected override Task<Users?> FindAsync(int id) => repository.GetByIdAsync(id);
    protected override Task<IReadOnlyList<Users>> ListAsync() => repository.GetAllAsync();
    protected override Task<Users> InsertAsync(Users entity) => repository.AddAsync(entity);
    protected override Task UpdateAsync(int id, Users entity) => repository.UpdateAsync(id, entity);
    protected override Task DeleteAsync(int id) => repository.DeleteAsync(id);
    protected override int GetId(Users entity) => entity.UserId;
    protected override void SetId(Users entity, int id) => entity.UserId = id;

    protected override Users CreateEntity(CreateUserDto dto)
    {
        var user = base.CreateEntity(dto);
        user.PasswordHash = passwordHasher.HashPassword(user, dto.Password);
        return user;
    }

    protected override void PrepareForCreate(Users entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.IsPhoneVerified = false;
    }
}
