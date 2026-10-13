using AutoMapper;
using DAL.Models;
using NAAMA.DTOs;

namespace BLL.MappingProfiles;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Booking, BookingResponseDto>();
        CreateMap<ChatMessage, ChatMessageResponseDto>();
        CreateMap<MassageToBooking, MassageToBookingResponseDto>();
        CreateMap<Payments, PaymentResponseDto>();
        CreateMap<Request, RequestResponseDto>();
        CreateMap<RequestToRide, RequestToRideResponseDto>();
        CreateMap<RequestToVehicles, RequestToVehiclesResponseDto>();
        CreateMap<RideRequest, RideRequestResponseDto>();
        CreateMap<Ride, RideResponseDto>();
        CreateMap<Users, UserResponseDto>();
        CreateMap<Vehicle, VehicleDto>();
        CreateMap<CreateVehicleDto, Vehicle>();
        CreateMap<UpdateVehicleDto, Vehicle>();
        CreateMap<CreateBookingDto, Booking>();
        CreateMap<UpdateBookingDto, Booking>();
        CreateMap<CreateChatMessageDto, ChatMessage>();
        CreateMap<UpdateChatMessageDto, ChatMessage>();
        CreateMap<CreateMassageToBookingDto, MassageToBooking>();
        CreateMap<UpdateMassageToBookingDto, MassageToBooking>();
        CreateMap<CreatePaymentDto, Payments>();
        CreateMap<UpdatePaymentDto, Payments>();
        CreateMap<CreateRequestDto, Request>();
        CreateMap<UpdateRequestDto, Request>();
        CreateMap<CreateRequestToRideDto, RequestToRide>();
        CreateMap<UpdateRequestToRideDto, RequestToRide>();
        CreateMap<CreateRequestToVehiclesDto, RequestToVehicles>();
        CreateMap<UpdateRequestToVehiclesDto, RequestToVehicles>();
        CreateMap<CreateRideRequestDto, RideRequest>();
        CreateMap<UpdateRideRequestDto, RideRequest>();
        CreateMap<CreateRideDto, Ride>();
        CreateMap<UpdateRideDto, Ride>();
        CreateMap<CreateUserDto, Users>()
            .ForMember(user => user.PasswordHash, options => options.Ignore());
        CreateMap<UpdateUserProfileEntityDto, Users>();
    }
}
