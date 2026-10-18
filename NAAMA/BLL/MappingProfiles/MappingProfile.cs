using AutoMapper; // מייבא את מרחב השמות AutoMapper כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.
using NAAMA.DTOs; // מייבא את מרחב השמות NAAMA.DTOs כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.MappingProfiles; // משייך את הקוד למרחב השמות BLL.MappingProfiles.

/// <summary>
/// מגדיר המרות בין ישויות מסד הנתונים לבין אובייקטי ה־DTO של ה־API.
/// </summary>
public sealed class MappingProfile : Profile // מגדיר את הטיפוס MappingProfile ואת אחריותו בשכבת הלוגיקה.
{
    public MappingProfile() // מאתחל את פרופיל AutoMapper שבו נרשמים כללי ההמרה.
    {
        CreateMap<Booking, BookingResponseDto>(); // מגדיר מיפוי מהטיפוס Booking לטיפוס BookingResponseDto.
        CreateMap<ChatMessage, ChatMessageResponseDto>(); // מגדיר מיפוי מהטיפוס ChatMessage לטיפוס ChatMessageResponseDto.
        CreateMap<MassageToBooking, MassageToBookingResponseDto>(); // מגדיר מיפוי מהטיפוס MassageToBooking לטיפוס MassageToBookingResponseDto.
        CreateMap<Payments, PaymentResponseDto>(); // מגדיר מיפוי מהטיפוס Payments לטיפוס PaymentResponseDto.
        CreateMap<Request, RequestResponseDto>(); // מגדיר מיפוי מהטיפוס Request לטיפוס RequestResponseDto.
        CreateMap<RequestToRide, RequestToRideResponseDto>(); // מגדיר מיפוי מהטיפוס RequestToRide לטיפוס RequestToRideResponseDto.
        CreateMap<RequestToVehicles, RequestToVehiclesResponseDto>(); // מגדיר מיפוי מהטיפוס RequestToVehicles לטיפוס RequestToVehiclesResponseDto.
        CreateMap<RideRequest, RideRequestResponseDto>(); // מגדיר מיפוי מהטיפוס RideRequest לטיפוס RideRequestResponseDto.
        CreateMap<Ride, RideResponseDto>(); // מגדיר מיפוי מהטיפוס Ride לטיפוס RideResponseDto.
        CreateMap<Users, UserResponseDto>(); // מגדיר מיפוי מהטיפוס Users לטיפוס UserResponseDto.
        CreateMap<Vehicle, VehicleDto>(); // מגדיר מיפוי מהטיפוס Vehicle לטיפוס VehicleDto.
        CreateMap<CreateVehicleDto, Vehicle>(); // מגדיר מיפוי מהטיפוס CreateVehicleDto לטיפוס Vehicle.
        CreateMap<UpdateVehicleDto, Vehicle>(); // מגדיר מיפוי מהטיפוס UpdateVehicleDto לטיפוס Vehicle.
        CreateMap<CreateBookingDto, Booking>(); // מגדיר מיפוי מהטיפוס CreateBookingDto לטיפוס Booking.
        CreateMap<UpdateBookingDto, Booking>(); // מגדיר מיפוי מהטיפוס UpdateBookingDto לטיפוס Booking.
        CreateMap<CreateChatMessageDto, ChatMessage>(); // מגדיר מיפוי מהטיפוס CreateChatMessageDto לטיפוס ChatMessage.
        CreateMap<UpdateChatMessageDto, ChatMessage>(); // מגדיר מיפוי מהטיפוס UpdateChatMessageDto לטיפוס ChatMessage.
        CreateMap<CreateMassageToBookingDto, MassageToBooking>(); // מגדיר מיפוי מהטיפוס CreateMassageToBookingDto לטיפוס MassageToBooking.
        CreateMap<UpdateMassageToBookingDto, MassageToBooking>(); // מגדיר מיפוי מהטיפוס UpdateMassageToBookingDto לטיפוס MassageToBooking.
        CreateMap<CreatePaymentDto, Payments>(); // מגדיר מיפוי מהטיפוס CreatePaymentDto לטיפוס Payments.
        CreateMap<UpdatePaymentDto, Payments>(); // מגדיר מיפוי מהטיפוס UpdatePaymentDto לטיפוס Payments.
        CreateMap<CreateRequestDto, Request>(); // מגדיר מיפוי מהטיפוס CreateRequestDto לטיפוס Request.
        CreateMap<UpdateRequestDto, Request>(); // מגדיר מיפוי מהטיפוס UpdateRequestDto לטיפוס Request.
        CreateMap<CreateRequestToRideDto, RequestToRide>(); // מגדיר מיפוי מהטיפוס CreateRequestToRideDto לטיפוס RequestToRide.
        CreateMap<UpdateRequestToRideDto, RequestToRide>(); // מגדיר מיפוי מהטיפוס UpdateRequestToRideDto לטיפוס RequestToRide.
        CreateMap<CreateRequestToVehiclesDto, RequestToVehicles>(); // מגדיר מיפוי מהטיפוס CreateRequestToVehiclesDto לטיפוס RequestToVehicles.
        CreateMap<UpdateRequestToVehiclesDto, RequestToVehicles>(); // מגדיר מיפוי מהטיפוס UpdateRequestToVehiclesDto לטיפוס RequestToVehicles.
        CreateMap<CreateRideRequestDto, RideRequest>(); // מגדיר מיפוי מהטיפוס CreateRideRequestDto לטיפוס RideRequest.
        CreateMap<UpdateRideRequestDto, RideRequest>(); // מגדיר מיפוי מהטיפוס UpdateRideRequestDto לטיפוס RideRequest.
        CreateMap<CreateRideDto, Ride>(); // מגדיר מיפוי מהטיפוס CreateRideDto לטיפוס Ride.
        CreateMap<UpdateRideDto, Ride>(); // מגדיר מיפוי מהטיפוס UpdateRideDto לטיפוס Ride.
        CreateMap<CreateUserDto, Users>() // מגדיר מיפוי מהטיפוס CreateUserDto לטיפוס Users.
            .ForMember(user => user.PasswordHash, options => options.Ignore()); // מגדיר טיפול ייעודי במאפיין היעד במהלך המיפוי.
        CreateMap<UpdateUserProfileEntityDto, Users>(); // מגדיר מיפוי מהטיפוס UpdateUserProfileEntityDto לטיפוס Users.
    }
}
