namespace NAAMA.DTOs;

public sealed class CreateBookingDto
{
    public int RequestId { get; set; }
    public int RideId { get; set; }
    public int LegSequence { get; set; }
    public string PickupPoint { get; set; } = "";
    public int Status { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal AdvanceAmount { get; set; }
    public decimal ReminingAmount { get; set; }
}

public sealed class UpdateBookingDto
{
    public int RequestId { get; set; }
    public int RideId { get; set; }
    public int LegSequence { get; set; }
    public string PickupPoint { get; set; } = "";
    public int Status { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal AdvanceAmount { get; set; }
    public decimal ReminingAmount { get; set; }
}

public sealed class BookingResponseDto
{
    public int BookingId { get; set; }
    public int RequestId { get; set; }
    public int RideId { get; set; }
    public int LegSequence { get; set; }
    public string? PickupPoint { get; set; }
    public int Status { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal AdvanceAmount { get; set; }
    public decimal ReminingAmount { get; set; }
}

public sealed class CreateChatMessageDto
{
    public int SenderId { get; set; }
    public string MessageText { get; set; } = "";
}

public sealed class UpdateChatMessageDto
{
    public string MessageText { get; set; } = "";
}

public sealed class ChatMessageResponseDto
{
    public int MessageId { get; set; }
    public int SenderId { get; set; }
    public string? MessageText { get; set; }
    public DateTime SentAt { get; set; }
}

public sealed class CreateMassageToBookingDto
{
    public int MassageId { get; set; }
    public int BookingId { get; set; }
}

public sealed class UpdateMassageToBookingDto
{
    public int MassageId { get; set; }
    public int BookingId { get; set; }
}

public sealed class MassageToBookingResponseDto
{
    public int MassageToBookingId { get; set; }
    public int MassageId { get; set; }
    public int BookingId { get; set; }
}

public sealed class CreatePaymentDto
{
    public int BookingId { get; set; }
    public decimal Amount { get; set; }
    public int PaymentType { get; set; }
    public int PaymentStage { get; set; }
}

public sealed class UpdatePaymentDto
{
    public decimal Amount { get; set; }
    public int PaymentType { get; set; }
    public int PaymentStage { get; set; }
}

public sealed class PaymentResponseDto
{
    public int PaymentsId { get; set; }
    public int BookingId { get; set; }
    public decimal Amount { get; set; }
    public int PaymentType { get; set; }
    public int PaymentStatus { get; set; }
    public int PaymentStage { get; set; }
    public DateTime CreateAt { get; set; }
}

public sealed class CreateRequestDto
{
    public bool HasTrunkSpace { get; set; }
    public bool FitsStroller { get; set; }
    public bool HasChildSeats { get; set; }
    public bool AllowMusic { get; set; }
    public string MusicGenre { get; set; } = "";
}

public sealed class UpdateRequestDto
{
    public bool HasTrunkSpace { get; set; }
    public bool FitsStroller { get; set; }
    public bool HasChildSeats { get; set; }
    public bool AllowMusic { get; set; }
    public string MusicGenre { get; set; } = "";
}

public sealed class RequestResponseDto
{
    public string? RequestId { get; set; }
    public bool HasTrunkSpace { get; set; }
    public bool FitsStroller { get; set; }
    public bool HasChildSeats { get; set; }
    public bool AllowMusic { get; set; }
    public string? MusicGenre { get; set; }
}

public sealed class CreateRequestToRideDto
{
    public string RequestId { get; set; } = "";
    public string RideId { get; set; } = "";
}

public sealed class UpdateRequestToRideDto
{
    public string RequestId { get; set; } = "";
    public string RideId { get; set; } = "";
}

public sealed class RequestToRideResponseDto
{
    public string? RequestToRideId { get; set; }
    public string? RequestId { get; set; }
    public string? RideId { get; set; }
}

public sealed class CreateRequestToVehiclesDto
{
    public string VehicleId { get; set; } = "";
    public string RequestId { get; set; } = "";
}

public sealed class UpdateRequestToVehiclesDto
{
    public string VehicleId { get; set; } = "";
    public string RequestId { get; set; } = "";
}

public sealed class RequestToVehiclesResponseDto
{
    public string? RequestToVehiclesId { get; set; }
    public string? VehicleId { get; set; }
    public string? RequestId { get; set; }
}

public sealed class CreateRideRequestDto
{
    public int PassengerId { get; set; }
    public string PickupName { get; set; } = "";
    public string DropoffName { get; set; } = "";
    public decimal PickupLat { get; set; }
    public decimal DropoffLat { get; set; }
}

public sealed class UpdateRideRequestDto
{
    public string PickupName { get; set; } = "";
    public string DropoffName { get; set; } = "";
    public decimal PickupLat { get; set; }
    public decimal DropoffLat { get; set; }
    public int Status { get; set; }
}

public sealed class RideRequestResponseDto
{
    public int RequestId { get; set; }
    public int PassengerId { get; set; }
    public string? PickupName { get; set; }
    public string? DropoffName { get; set; }
    public decimal PickupLat { get; set; }
    public decimal DropoffLat { get; set; }
    public DateTime RequestedTime { get; set; }
    public int Status { get; set; }
}

public sealed class CreateRideDto
{
    public int DriverId { get; set; }
    public string Origin { get; set; } = "";
    public string DestinationName { get; set; } = "";
    public decimal DestinationLat { get; set; }
    public DateTime DepartureTime { get; set; }
    public bool IsRecurring { get; set; }
    public int MaxSeats { get; set; }
}

public sealed class UpdateRideDto
{
    public string Origin { get; set; } = "";
    public string DestinationName { get; set; } = "";
    public decimal DestinationLat { get; set; }
    public DateTime DepartureTime { get; set; }
    public bool IsRecurring { get; set; }
    public int MaxSeats { get; set; }
    public int Status { get; set; }
}

public sealed class RideResponseDto
{
    public int RideId { get; set; }
    public int DriverId { get; set; }
    public string? Origin { get; set; }
    public string? DestinationName { get; set; }
    public decimal DestinationLat { get; set; }
    public DateTime DepartureTime { get; set; }
    public bool IsRecurring { get; set; }
    public int MaxSeats { get; set; }
    public int Status { get; set; }
}

public sealed class CreateUserDto
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
}

public sealed class UpdateUserProfileEntityDto
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Phone { get; set; } = "";
}

public sealed class UserResponseDto
{
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public int UserType { get; set; }
    public bool IsPhoneVerified { get; set; }
    public DateTime CreatedAt { get; set; }
}
