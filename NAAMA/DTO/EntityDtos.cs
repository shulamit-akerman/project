// הגדרת מרחב השמות NAAMA.DTOs כדי לשייך את הטיפוסים למודול המתאים.
namespace NAAMA.DTOs;

/// <summary>
/// נתוני הקלט הנדרשים ליצירת הזמנה.
/// </summary>
public sealed class CreateBookingDto
{
    // מזהה בקשת הנסיעה.
    public int RequestId { get; set; }
    // מזהה הנסיעה שאליה מתייחסים.
    public int RideId { get; set; }
    // מספר הסדר של מקטע הנסיעה.
    public int LegSequence { get; set; }
    // נקודת האיסוף שנבחרה.
    public string PickupPoint { get; set; } = "";
    // המצב הנוכחי או המבוקש של הרשומה.
    public int Status { get; set; }
    // הסכום הכולל לתשלום עבור ההזמנה.
    public decimal TotalAmount { get; set; }
    // סכום המקדמה ששולמה או נדרשת.
    public decimal AdvanceAmount { get; set; }
    // יתרת הסכום שנותרה לתשלום.
    public decimal ReminingAmount { get; set; }
}

/// <summary>
/// נתוני הקלט לעדכון הזמנה קיימת.
/// </summary>
public sealed class UpdateBookingDto
{
    // מזהה בקשת הנסיעה.
    public int RequestId { get; set; }
    // מזהה הנסיעה שאליה מתייחסים.
    public int RideId { get; set; }
    // מספר הסדר של מקטע הנסיעה.
    public int LegSequence { get; set; }
    // נקודת האיסוף שנבחרה.
    public string PickupPoint { get; set; } = "";
    // המצב הנוכחי או המבוקש של הרשומה.
    public int Status { get; set; }
    // הסכום הכולל לתשלום עבור ההזמנה.
    public decimal TotalAmount { get; set; }
    // סכום המקדמה ששולמה או נדרשת.
    public decimal AdvanceAmount { get; set; }
    // יתרת הסכום שנותרה לתשלום.
    public decimal ReminingAmount { get; set; }
}

/// <summary>
/// פרטי הזמנה המוחזרים ללקוח ה־API.
/// </summary>
public sealed class BookingResponseDto
{
    // מזהה ההזמנה.
    public int BookingId { get; set; }
    // מזהה בקשת הנסיעה.
    public int RequestId { get; set; }
    // מזהה הנסיעה שאליה מתייחסים.
    public int RideId { get; set; }
    // מספר הסדר של מקטע הנסיעה.
    public int LegSequence { get; set; }
    // נקודת האיסוף שנבחרה.
    public string? PickupPoint { get; set; }
    // המצב הנוכחי או המבוקש של הרשומה.
    public int Status { get; set; }
    // הסכום הכולל לתשלום עבור ההזמנה.
    public decimal TotalAmount { get; set; }
    // סכום המקדמה ששולמה או נדרשת.
    public decimal AdvanceAmount { get; set; }
    // יתרת הסכום שנותרה לתשלום.
    public decimal ReminingAmount { get; set; }
}

/// <summary>
/// נתוני הקלט הנדרשים ליצירת הודעת צ'אט.
/// </summary>
public sealed class CreateChatMessageDto
{
    // מזהה המשתמש ששלח את ההודעה.
    public int SenderId { get; set; }
    // תוכן הודעת הצ׳אט.
    public string MessageText { get; set; } = "";
}

/// <summary>
/// נתוני הקלט לעדכון הודעת צ'אט קיימת.
/// </summary>
public sealed class UpdateChatMessageDto
{
    // תוכן הודעת הצ׳אט.
    public string MessageText { get; set; } = "";
}

/// <summary>
/// פרטי הודעת צ'אט המוחזרים ללקוח ה־API.
/// </summary>
public sealed class ChatMessageResponseDto
{
    // מזהה הודעת הצ׳אט.
    public int MessageId { get; set; }
    // מזהה המשתמש ששלח את ההודעה.
    public int SenderId { get; set; }
    // תוכן הודעת הצ׳אט.
    public string? MessageText { get; set; }
    // מועד שליחת ההודעה.
    public DateTime SentAt { get; set; }
}

/// <summary>
/// נתוני הקלט ליצירת הודעה המשויכת להזמנה.
/// </summary>
public sealed class CreateMassageToBookingDto
{
    // מזהה הודעת הצ׳אט המקושרת.
    public int MassageId { get; set; }
    // מזהה ההזמנה.
    public int BookingId { get; set; }
}

/// <summary>
/// נתוני הקלט לעדכון הודעה המשויכת להזמנה.
/// </summary>
public sealed class UpdateMassageToBookingDto
{
    // מזהה הודעת הצ׳אט המקושרת.
    public int MassageId { get; set; }
    // מזהה ההזמנה.
    public int BookingId { get; set; }
}

/// <summary>
/// פרטי הודעה המשויכת להזמנה ומוחזרים ללקוח ה־API.
/// </summary>
public sealed class MassageToBookingResponseDto
{
    // מזהה הקישור בין ההודעה להזמנה.
    public int MassageToBookingId { get; set; }
    // מזהה הודעת הצ׳אט המקושרת.
    public int MassageId { get; set; }
    // מזהה ההזמנה.
    public int BookingId { get; set; }
}

/// <summary>
/// נתוני הקלט הנדרשים ליצירת תשלום.
/// </summary>
public sealed class CreatePaymentDto
{
    // מזהה ההזמנה.
    public int BookingId { get; set; }
    // סכום התשלום.
    public decimal Amount { get; set; }
    // סוג אמצעי התשלום.
    public int PaymentType { get; set; }
    // שלב התשלום.
    public int PaymentStage { get; set; }
}

/// <summary>
/// נתוני הקלט לעדכון תשלום קיים.
/// </summary>
public sealed class UpdatePaymentDto
{
    // סכום התשלום.
    public decimal Amount { get; set; }
    // סוג אמצעי התשלום.
    public int PaymentType { get; set; }
    // שלב התשלום.
    public int PaymentStage { get; set; }
}

/// <summary>
/// פרטי תשלום המוחזרים ללקוח ה־API.
/// </summary>
public sealed class PaymentResponseDto
{
    // מזהה רשומת התשלום.
    public int PaymentsId { get; set; }
    // מזהה ההזמנה.
    public int BookingId { get; set; }
    // סכום התשלום.
    public decimal Amount { get; set; }
    // סוג אמצעי התשלום.
    public int PaymentType { get; set; }
    // מצב התשלום.
    public int PaymentStatus { get; set; }
    // שלב התשלום.
    public int PaymentStage { get; set; }
    // מועד יצירת פרטי התשלום.
    public DateTime CreateAt { get; set; }
}

/// <summary>
/// נתוני הקלט הנדרשים ליצירת בקשת נסיעה.
/// </summary>
public sealed class CreateRequestDto
{
    // האם נדרש או קיים מקום בתא המטען.
    public bool HasTrunkSpace { get; set; }
    // האם נדרש או קיים מקום לעגלת תינוק.
    public bool FitsStroller { get; set; }
    // האם נדרשים או קיימים מושבי בטיחות לילדים.
    public bool HasChildSeats { get; set; }
    // האם מותר להשמיע מוזיקה בנסיעה.
    public bool AllowMusic { get; set; }
    // ז׳אנר המוזיקה המועדף.
    public string MusicGenre { get; set; } = "";
}

/// <summary>
/// נתוני הקלט לעדכון בקשת נסיעה קיימת.
/// </summary>
public sealed class UpdateRequestDto
{
    // האם נדרש או קיים מקום בתא המטען.
    public bool HasTrunkSpace { get; set; }
    // האם נדרש או קיים מקום לעגלת תינוק.
    public bool FitsStroller { get; set; }
    // האם נדרשים או קיימים מושבי בטיחות לילדים.
    public bool HasChildSeats { get; set; }
    // האם מותר להשמיע מוזיקה בנסיעה.
    public bool AllowMusic { get; set; }
    // ז׳אנר המוזיקה המועדף.
    public string MusicGenre { get; set; } = "";
}

/// <summary>
/// פרטי בקשת נסיעה המוחזרים ללקוח ה־API.
/// </summary>
public sealed class RequestResponseDto
{
    // מזהה בקשת הנסיעה.
    public string? RequestId { get; set; }
    // האם נדרש או קיים מקום בתא המטען.
    public bool HasTrunkSpace { get; set; }
    // האם נדרש או קיים מקום לעגלת תינוק.
    public bool FitsStroller { get; set; }
    // האם נדרשים או קיימים מושבי בטיחות לילדים.
    public bool HasChildSeats { get; set; }
    // האם מותר להשמיע מוזיקה בנסיעה.
    public bool AllowMusic { get; set; }
    // ז׳אנר המוזיקה המועדף.
    public string? MusicGenre { get; set; }
}

/// <summary>
/// נתוני הקלט ליצירת קשר בין בקשה לנסיעה.
/// </summary>
public sealed class CreateRequestToRideDto
{
    // מזהה בקשת הנסיעה.
    public string RequestId { get; set; } = "";
    // מזהה הנסיעה שאליה מתייחסים.
    public string RideId { get; set; } = "";
}

/// <summary>
/// נתוני הקלט לעדכון קשר בין בקשה לנסיעה.
/// </summary>
public sealed class UpdateRequestToRideDto
{
    // מזהה בקשת הנסיעה.
    public string RequestId { get; set; } = "";
    // מזהה הנסיעה שאליה מתייחסים.
    public string RideId { get; set; } = "";
}

/// <summary>
/// פרטי הקשר בין בקשה לנסיעה המוחזרים ללקוח ה־API.
/// </summary>
public sealed class RequestToRideResponseDto
{
    // מזהה הקישור בין בקשת המשתמש לנסיעה.
    public string? RequestToRideId { get; set; }
    // מזהה בקשת הנסיעה.
    public string? RequestId { get; set; }
    // מזהה הנסיעה שאליה מתייחסים.
    public string? RideId { get; set; }
}

/// <summary>
/// נתוני הקלט ליצירת קשר בין בקשה לכלי רכב.
/// </summary>
public sealed class CreateRequestToVehiclesDto
{
    // מזהה כלי הרכב המשויך.
    public string VehicleId { get; set; } = "";
    // מזהה בקשת הנסיעה.
    public string RequestId { get; set; } = "";
}

/// <summary>
/// נתוני הקלט לעדכון קשר בין בקשה לכלי רכב.
/// </summary>
public sealed class UpdateRequestToVehiclesDto
{
    // מזהה כלי הרכב המשויך.
    public string VehicleId { get; set; } = "";
    // מזהה בקשת הנסיעה.
    public string RequestId { get; set; } = "";
}

/// <summary>
/// פרטי הקשר בין בקשה לכלי רכב המוחזרים ללקוח ה־API.
/// </summary>
public sealed class RequestToVehiclesResponseDto
{
    // מזהה הקישור בין בקשת המשתמש לכלי הרכב.
    public string? RequestToVehiclesId { get; set; }
    // מזהה כלי הרכב המשויך.
    public string? VehicleId { get; set; }
    // מזהה בקשת הנסיעה.
    public string? RequestId { get; set; }
}

/// <summary>
/// נתוני הקלט הנדרשים ליצירת בקשה לנסיעה.
/// </summary>
public sealed class CreateRideRequestDto
{
    // מזהה הנוסע.
    public int PassengerId { get; set; }
    // שם או תיאור נקודת האיסוף.
    public string PickupName { get; set; } = "";
    // שם או תיאור נקודת ההורדה.
    public string DropoffName { get; set; } = "";
    // קו הרוחב של נקודת האיסוף.
    public decimal PickupLat { get; set; }
    // קו הרוחב של נקודת ההורדה.
    public decimal DropoffLat { get; set; }
}

/// <summary>
/// נתוני הקלט לעדכון בקשה לנסיעה קיימת.
/// </summary>
public sealed class UpdateRideRequestDto
{
    // שם או תיאור נקודת האיסוף.
    public string PickupName { get; set; } = "";
    // שם או תיאור נקודת ההורדה.
    public string DropoffName { get; set; } = "";
    // קו הרוחב של נקודת האיסוף.
    public decimal PickupLat { get; set; }
    // קו הרוחב של נקודת ההורדה.
    public decimal DropoffLat { get; set; }
    // המצב הנוכחי או המבוקש של הרשומה.
    public int Status { get; set; }
}

/// <summary>
/// פרטי בקשה לנסיעה המוחזרים ללקוח ה־API.
/// </summary>
public sealed class RideRequestResponseDto
{
    // מזהה בקשת הנסיעה.
    public int RequestId { get; set; }
    // מזהה הנוסע.
    public int PassengerId { get; set; }
    // שם או תיאור נקודת האיסוף.
    public string? PickupName { get; set; }
    // שם או תיאור נקודת ההורדה.
    public string? DropoffName { get; set; }
    // קו הרוחב של נקודת האיסוף.
    public decimal PickupLat { get; set; }
    // קו הרוחב של נקודת ההורדה.
    public decimal DropoffLat { get; set; }
    // המועד המבוקש לנסיעה.
    public DateTime RequestedTime { get; set; }
    // המצב הנוכחי או המבוקש של הרשומה.
    public int Status { get; set; }
}

/// <summary>
/// נתוני הקלט הנדרשים לפרסום נסיעה חדשה.
/// </summary>
public sealed class CreateRideDto
{
    // מזהה הנהג.
    public int DriverId { get; set; }
    // נקודת המוצא של הנסיעה.
    public string Origin { get; set; } = "";
    // שם או תיאור נקודת היעד.
    public string DestinationName { get; set; } = "";
    // קו הרוחב של נקודת היעד.
    public decimal DestinationLat { get; set; }
    // מועד יציאת הנסיעה.
    public DateTime DepartureTime { get; set; }
    // האם הנסיעה מתקיימת באופן חוזר.
    public bool IsRecurring { get; set; }
    // מספר המושבים המרבי הזמין בנסיעה.
    public int MaxSeats { get; set; }
}

/// <summary>
/// נתוני הקלט לעדכון נסיעה קיימת.
/// </summary>
public sealed class UpdateRideDto
{
    // נקודת המוצא של הנסיעה.
    public string Origin { get; set; } = "";
    // שם או תיאור נקודת היעד.
    public string DestinationName { get; set; } = "";
    // קו הרוחב של נקודת היעד.
    public decimal DestinationLat { get; set; }
    // מועד יציאת הנסיעה.
    public DateTime DepartureTime { get; set; }
    // האם הנסיעה מתקיימת באופן חוזר.
    public bool IsRecurring { get; set; }
    // מספר המושבים המרבי הזמין בנסיעה.
    public int MaxSeats { get; set; }
    // המצב הנוכחי או המבוקש של הרשומה.
    public int Status { get; set; }
}

/// <summary>
/// פרטי נסיעה המוחזרים ללקוח ה־API.
/// </summary>
public sealed class RideResponseDto
{
    // מזהה הנסיעה שאליה מתייחסים.
    public int RideId { get; set; }
    // מזהה הנהג.
    public int DriverId { get; set; }
    // נקודת המוצא של הנסיעה.
    public string? Origin { get; set; }
    // שם או תיאור נקודת היעד.
    public string? DestinationName { get; set; }
    // קו הרוחב של נקודת היעד.
    public decimal DestinationLat { get; set; }
    // מועד יציאת הנסיעה.
    public DateTime DepartureTime { get; set; }
    // האם הנסיעה מתקיימת באופן חוזר.
    public bool IsRecurring { get; set; }
    // מספר המושבים המרבי הזמין בנסיעה.
    public int MaxSeats { get; set; }
    // המצב הנוכחי או המבוקש של הרשומה.
    public int Status { get; set; }
}

/// <summary>
/// נתוני הקלט ליצירת משתמש, כולל הסיסמה הגלויה שנגבית בשירות.
/// </summary>
public sealed class CreateUserDto
{
    // שם פרטי של המשתמש.
    public string FirstName { get; set; } = "";
    // שם משפחה של המשתמש.
    public string LastName { get; set; } = "";
    // מספר הטלפון של המשתמש.
    public string Phone { get; set; } = "";
    // כתובת הדואר האלקטרוני של המשתמש.
    public string Email { get; set; } = "";
    // הסיסמה שהוזנה בבקשה.
    public string Password { get; set; } = "";
}

/// <summary>
/// נתוני הקלט לעדכון פרטי פרופיל של משתמש.
/// </summary>
public sealed class UpdateUserProfileEntityDto
{
    // שם פרטי של המשתמש.
    public string FirstName { get; set; } = "";
    // שם משפחה של המשתמש.
    public string LastName { get; set; } = "";
    // מספר הטלפון של המשתמש.
    public string Phone { get; set; } = "";
}

/// <summary>
/// פרטי משתמש המוחזרים ללקוח ה־API ללא פרטי סיסמה.
/// </summary>
public sealed class UserResponseDto
{
    // מזהה המשתמש שאליו שייכת התגובה.
    public int UserId { get; set; }
    // שם פרטי של המשתמש.
    public string? FirstName { get; set; }
    // שם משפחה של המשתמש.
    public string? LastName { get; set; }
    // מספר הטלפון של המשתמש.
    public string? Phone { get; set; }
    // כתובת הדואר האלקטרוני של המשתמש.
    public string? Email { get; set; }
    // סוג המשתמש במערכת.
    public int UserType { get; set; }
    // האם מספר הטלפון של המשתמש אומת.
    public bool IsPhoneVerified { get; set; }
    // מועד יצירת הרשומה.
    public DateTime CreatedAt { get; set; }
}
