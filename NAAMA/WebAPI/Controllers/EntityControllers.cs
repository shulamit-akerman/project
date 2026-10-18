// מייבא את AutoMapper לצורך העברת הממפה למחלקת הבסיס של הבקר.
using AutoMapper;
// מייבא את חוזה שירות המשתמש שמוגדר במרחב השמות הייעודי.
using BLL.Interfaces;
// מייבא את חוזי השירותים העסקיים שבהם משתמשים הבקרים.
using BLL.Services;
// מייבא את ישויות הנתונים שעליהן פועלות נקודות הקצה.
using DAL.Models;
// מייבא מאפייני HTTP וסוגי תוצאה של ASP.NET Core MVC.
using Microsoft.AspNetCore.Mvc;
// מייבא את אובייקטי הבקשה והתשובה של ה-API.
using NAAMA.DTOs;

// מצהיר שהבקרים בקובץ שייכים לשכבת WebAPI.
namespace WebAPI.Controllers;

/// <summary>
/// חושף נקודות קצה לניהול הזמנות באמצעות שירות ההזמנות.
/// </summary>
// מאפשר ל-ASP.NET Core להפעיל בדיקת מודל אוטומטית על בקשות הבקר.
[ApiController]
// קובע את תחילית הנתיב לכל נקודות הקצה של הזמנות.
[Route("api/bookings")]
// בקר הזמנות שמחבר שירות הזמנות למנגנון ה-CRUD המשותף.
public sealed class BookingsController(IBookingService service, IMapper mapper)
    // מגדיר את סוג הישות, DTOs ומפתח ההזמנה עבור פעולות ה-CRUD המשותפות.
    : CrudController<Booking, CreateBookingDto, UpdateBookingDto, BookingResponseDto, int>(mapper)
{
    // מחפש הזמנה לפי מזהה באמצעות שירות ההזמנות.
    protected override Task<Booking?> FindAsync(int id) => service.FindAsync(id);
    // מביא את כל ההזמנות באמצעות שירות ההזמנות.
    protected override Task<IReadOnlyList<Booking>> ListAsync() => service.ListAsync();
    // מוסיף הזמנה באמצעות שירות ההזמנות.
    protected override Task<Booking> InsertAsync(Booking entity) => service.InsertAsync(entity);
    // מעדכן הזמנה קיימת באמצעות שירות ההזמנות.
    protected override Task UpdateAsync(int id, Booking entity) => service.UpdateAsync(id, entity);
    // מוחק הזמנה לפי מזהה באמצעות שירות ההזמנות.
    protected override Task DeleteAsync(int id) => service.DeleteAsync(id);
    // קורא את מזהה ההזמנה מתוך הישות לצורך בניית כתובת התשובה.
    protected override int GetId(Booking entity) => entity.BookingId;
    // מציב בישות את מזהה ההזמנה שהתקבל בכתובת הבקשה.
    protected override void SetId(Booking entity, int id) => entity.BookingId = id;
}

/// <summary>
/// חושף נקודות קצה לניהול הודעות צ'אט באמצעות שירות ההודעות.
/// </summary>
// מאפשר בדיקת מודל אוטומטית עבור בקשות לבקר הודעות הצ'אט.
[ApiController]
// מגדיר את תחילית הנתיב של נקודות הקצה להודעות צ'אט.
[Route("api/chat-messages")]
// בקר הודעות צ'אט המשתמש בשירות ייעודי ובפעולות ה-CRUD המשותפות.
public sealed class ChatMessagesController(IChatMessageService service, IMapper mapper)
    // מגדיר את טיפוסי הישות, DTOs והמזהה המספרי בבקר הבסיסי.
    : CrudController<ChatMessage, CreateChatMessageDto, UpdateChatMessageDto, ChatMessageResponseDto, int>(mapper)
{
    // מאתר הודעת צ'אט לפי מזהה.
    protected override Task<ChatMessage?> FindAsync(int id) => service.FindAsync(id);
    // מחזיר את כל הודעות הצ'אט.
    protected override Task<IReadOnlyList<ChatMessage>> ListAsync() => service.ListAsync();
    // שומר הודעת צ'אט חדשה; השירות מאתחל את זמן השליחה.
    protected override Task<ChatMessage> InsertAsync(ChatMessage entity) => service.InsertAsync(entity);
    // שומר שינויים בהודעת צ'אט קיימת.
    protected override Task UpdateAsync(int id, ChatMessage entity) => service.UpdateAsync(id, entity);
    // מוחק הודעת צ'אט לפי מזהה.
    protected override Task DeleteAsync(int id) => service.DeleteAsync(id);
    // קורא את המזהה המספרי של ההודעה.
    protected override int GetId(ChatMessage entity) => entity.MessageId;
    // מעדכן את מזהה ההודעה לערך שהתקבל בנתיב.
    protected override void SetId(ChatMessage entity, int id) => entity.MessageId = id;
}

/// <summary>
/// חושף נקודות קצה לניהול הודעות המשויכות להזמנות.
/// </summary>
// מאפשר בדיקות מודל אוטומטיות לבקשות של בקר הודעות ההזמנה.
[ApiController]
// מגדיר את תחילית הנתיב של נקודות הקצה להודעות המשויכות להזמנה.
[Route("api/massage-to-bookings")]
// בקר לניהול הודעות שהוצמדו להזמנות.
public sealed class MassageToBookingsController(IMassageToBookingService service, IMapper mapper)
    // מגדיר את טיפוסי ההודעה, DTOs ומזהה מספרי עבור פעולות CRUD.
    : CrudController<MassageToBooking, CreateMassageToBookingDto, UpdateMassageToBookingDto,
        MassageToBookingResponseDto, int>(mapper)
{
    // מוסיף מקטע נתיב שמאפשר לשלוף הודעות של הזמנה מסוימת.
    [HttpGet("by-booking/{bookingId:int}")]
    // מחזיר DTOs של הודעות השייכות למזהה ההזמנה שנשלח בנתיב.
    public async Task<ActionResult<IReadOnlyList<MassageToBookingResponseDto>>> GetByBookingId(int bookingId)
    {
        // מבקש מהשירות את ההודעות המשויכות להזמנה.
        var messages = await service.GetMessagesByBookingIdAsync(bookingId);
        // ממיר את ההודעות ל-DTOs ומחזיר תשובת HTTP 200.
        return Ok(Map<IReadOnlyList<MassageToBookingResponseDto>>(messages));
    }

    // מחפש הודעת הזמנה לפי המזהה שלה.
    protected override Task<MassageToBooking?> FindAsync(int id) => service.FindAsync(id);
    // מחזיר את כל הודעות ההזמנה.
    protected override Task<IReadOnlyList<MassageToBooking>> ListAsync() => service.ListAsync();
    // יוצר הודעת הזמנה באמצעות השירות.
    protected override Task<MassageToBooking> InsertAsync(MassageToBooking entity) => service.InsertAsync(entity);
    // מעדכן הודעת הזמנה קיימת באמצעות השירות.
    protected override Task UpdateAsync(int id, MassageToBooking entity) => service.UpdateAsync(id, entity);
    // מוחק הודעת הזמנה באמצעות השירות.
    protected override Task DeleteAsync(int id) => service.DeleteAsync(id);
    // מחזיר את מזהה הודעת ההזמנה.
    protected override int GetId(MassageToBooking entity) => entity.MassageToBookingId;
    // מציב בישות את המזהה שהתקבל בנתיב.
    protected override void SetId(MassageToBooking entity, int id) => entity.MassageToBookingId = id;
}

/// <summary>
/// חושף נקודות קצה לניהול תשלומים ולשליפת התשלום האחרון להזמנה.
/// </summary>
// מפעיל בדיקת מודל אוטומטית לבקשות בקר התשלומים.
[ApiController]
// מגדיר את תחילית נתיב התשלומים.
[Route("api/payments")]
// בקר תשלומים המחבר את פעולות ה-CRUD ושאילתת התשלום האחרון לשירות.
public sealed class PaymentsController(IPaymentService service, IMapper mapper)
    // מגדיר את ישות התשלום, ה-DTOs והמזהה המספרי בבקר ה-CRUD.
    : CrudController<Payments, CreatePaymentDto, UpdatePaymentDto, PaymentResponseDto, int>(mapper)
{
    // מגדיר נקודת קצה לשליפת התשלום האחרון לפי מזהה הזמנה.
    [HttpGet("booking/{bookingId:int}/latest")]
    // מחזיר את התשלום האחרון להזמנה, או 404 אם אין לה תשלום.
    public async Task<ActionResult<PaymentResponseDto>> GetLatestByBookingId(int bookingId)
    {
        // מבקש מהשירות את התשלום האחרון של ההזמנה.
        var payment = await service.GetPaymentByBookingIdAsync(bookingId);
        // אם לא נמצא תשלום מחזירים 404; אחרת ממירים ל-DTO ומחזירים 200.
        return payment is null ? NotFound() : Ok(Map<PaymentResponseDto>(payment));
    }

    // מאתר תשלום לפי המזהה שלו.
    protected override Task<Payments?> FindAsync(int id) => service.FindAsync(id);
    // מחזיר את כל התשלומים.
    protected override Task<IReadOnlyList<Payments>> ListAsync() => service.ListAsync();
    // יוצר תשלום חדש; השירות מאתחל את הסטטוס ואת מועד היצירה.
    protected override Task<Payments> InsertAsync(Payments entity) => service.InsertAsync(entity);
    // שומר עדכון לתשלום קיים.
    protected override Task UpdateAsync(int id, Payments entity) => service.UpdateAsync(id, entity);
    // מוחק תשלום לפי מזהה.
    protected override Task DeleteAsync(int id) => service.DeleteAsync(id);
    // קורא את מזהה התשלום מתוך הישות.
    protected override int GetId(Payments entity) => entity.PaymentsId;
    // קובע את מזהה התשלום לפי הערך שהתקבל בנתיב.
    protected override void SetId(Payments entity, int id) => entity.PaymentsId = id;
}

/// <summary>
/// חושף נקודות קצה לניהול בקשות ולחיפוש התאמות לפי דרישות רכב.
/// </summary>
// מפעיל בדיקות מודל אוטומטיות על בקשות בקר הבקשות.
[ApiController]
// מגדיר את תחילית הנתיב של בקשות.
[Route("api/requests")]
// בקר לניהול בקשות ולחיפוש בקשות המתאימות לתכונות רכב.
public sealed class RequestsController(IRequestService service, IMapper mapper)
    // מגדיר ישות בקשה, DTOs ומזהה טקסטואלי בבקר ה-CRUD.
    : CrudController<Request, CreateRequestDto, UpdateRequestDto, RequestResponseDto, string>(mapper)
{
    // מגדיר נקודת קצה מיוחדת לחיפוש בקשות מתאימות.
    [HttpGet("matching")]
    // קורא פרמטרי חיפוש מה-query string ומחזיר את הבקשות המתאימות.
    public async Task<ActionResult<IReadOnlyList<RequestResponseDto>>> FindMatching(
        // מציין אם כלי הרכב צריך לכלול תא מטען.
        [FromQuery] bool hasTrunk,
        // מציין אם כלי הרכב צריך להתאים לעגלת ילדים.
        [FromQuery] bool fitsStroller,
        // מציין אם נדרשים מושבי ילדים.
        [FromQuery] bool childSeats)
    {
        // מבצע את חיפוש ההתאמות בשירות הבקשות.
        var matches = await service.FindMatchingRequestsAsync(hasTrunk, fitsStroller, childSeats);
        // ממפה את התוצאות ל-DTOs ומחזיר אותן בתשובת HTTP 200.
        return Ok(Map<IReadOnlyList<RequestResponseDto>>(matches));
    }

    // מאתר בקשה לפי המזהה הטקסטואלי שלה.
    protected override Task<Request?> FindAsync(string id) => service.FindAsync(id);
    // מחזיר את כל הבקשות.
    protected override Task<IReadOnlyList<Request>> ListAsync() => service.ListAsync();
    // יוצר בקשה חדשה; השירות מייצר את המזהה שלה.
    protected override Task<Request> InsertAsync(Request entity) => service.InsertAsync(entity);
    // מעדכן בקשה קיימת.
    protected override Task UpdateAsync(string id, Request entity) => service.UpdateAsync(id, entity);
    // מוחק בקשה לפי המזהה שלה.
    protected override Task DeleteAsync(string id) => service.DeleteAsync(id);
    // קורא את המזהה הטקסטואלי מתוך הבקשה.
    protected override string GetId(Request entity) => entity.RequestId;
    // משאיר את מזהה הבקשה זהה למזהה שהתקבל בנתיב.
    protected override void SetId(Request entity, string id) => entity.RequestId = id;
}

/// <summary>
/// חושף נקודות קצה לניהול הקשרים בין בקשות לנסיעות.
/// </summary>
// מפעיל בדיקת מודל אוטומטית לבקשות בקר הקשרים בין בקשות לנסיעות.
[ApiController]
// מגדיר את תחילית הנתיב לניהול הקשרים האלה.
[Route("api/request-to-rides")]
// בקר CRUD לקשרים בין בקשות לנסיעות.
public sealed class RequestToRidesController(IRequestToRideService service, IMapper mapper)
    // מגדיר את סוגי הישות וה-DTO ואת המזהה הטקסטואלי בבקר המשותף.
    : CrudController<RequestToRide, CreateRequestToRideDto, UpdateRequestToRideDto,
        RequestToRideResponseDto, string>(mapper)
{
    // מגדיר כתובת חיפוש של כל הקשרים המשויכים לנסיעה.
    [HttpGet("by-ride/{rideId}")]
    // מאחזר ומחזיר את הקשרים עבור מזהה הנסיעה שבנתיב.
    public async Task<ActionResult<IReadOnlyList<RequestToRideResponseDto>>> GetByRideId(string rideId)
    {
        // מבקש מהשירות את הקשרים השייכים לנסיעה.
        var relations = await service.GetByRideIdAsync(rideId);
        // ממפה את התוצאות ל-DTOs ומחזיר HTTP 200.
        return Ok(Map<IReadOnlyList<RequestToRideResponseDto>>(relations));
    }

    // מאתר קשר לפי המזהה שלו.
    protected override Task<RequestToRide?> FindAsync(string id) => service.FindAsync(id);
    // מחזיר את כל הקשרים בין בקשות לנסיעות.
    protected override Task<IReadOnlyList<RequestToRide>> ListAsync() => service.ListAsync();
    // יוצר קשר חדש; השירות מייצר עבורו מזהה.
    protected override Task<RequestToRide> InsertAsync(RequestToRide entity) => service.InsertAsync(entity);
    // מעדכן קשר קיים.
    protected override Task UpdateAsync(string id, RequestToRide entity) => service.UpdateAsync(id, entity);
    // מוחק קשר לפי מזהה.
    protected override Task DeleteAsync(string id) => service.DeleteAsync(id);
    // מחזיר את מזהה הקשר.
    protected override string GetId(RequestToRide entity) => entity.RequestToRideId;
    // קובע את מזהה הקשר לפי הערך שבנתיב.
    protected override void SetId(RequestToRide entity, string id) => entity.RequestToRideId = id;
}

/// <summary>
/// חושף נקודות קצה לניהול הקשרים בין בקשות לכלי רכב.
/// </summary>
// מפעיל בדיקת מודל אוטומטית לבקשות הבקר.
[ApiController]
// מגדיר את תחילית הנתיב של קשרי בקשות וכלי רכב.
[Route("api/request-to-vehicles")]
// בקר CRUD לקשרים בין בקשות לכלי רכב.
public sealed class RequestToVehiclesController(IRequestToVehiclesService service, IMapper mapper)
    // מגדיר את הישות, DTOs והמפתח הטקסטואלי שהבקר מטפל בהם.
    : CrudController<RequestToVehicles, CreateRequestToVehiclesDto, UpdateRequestToVehiclesDto,
        RequestToVehiclesResponseDto, string>(mapper)
{
    // מגדיר נתיב ייעודי לחיפוש קשרים לפי מזהה כלי רכב.
    [HttpGet("by-vehicle/{vehicleId}")]
    // מחזיר קשרים בין בקשות לבין כלי הרכב המבוקש.
    public async Task<ActionResult<IReadOnlyList<RequestToVehiclesResponseDto>>> GetByVehicleId(string vehicleId)
    {
        // מבקש מהשירות את הקשרים של כלי הרכב.
        var relations = await service.GetByVehicleIdAsync(vehicleId);
        // ממפה את הקשרים ל-DTOs ומחזיר HTTP 200.
        return Ok(Map<IReadOnlyList<RequestToVehiclesResponseDto>>(relations));
    }

    // מאתר קשר בין בקשה לרכב לפי מזהה הקשר.
    protected override Task<RequestToVehicles?> FindAsync(string id) => service.FindAsync(id);
    // מחזיר את כל הקשרים בין בקשות לכלי רכב.
    protected override Task<IReadOnlyList<RequestToVehicles>> ListAsync() => service.ListAsync();
    // מוסיף קשר חדש; השירות מקצה לו מזהה.
    protected override Task<RequestToVehicles> InsertAsync(RequestToVehicles entity) => service.InsertAsync(entity);
    // מעדכן קשר קיים בין בקשה לרכב.
    protected override Task UpdateAsync(string id, RequestToVehicles entity) => service.UpdateAsync(id, entity);
    // מוחק קשר לפי מזהה.
    protected override Task DeleteAsync(string id) => service.DeleteAsync(id);
    // מחזיר את מזהה הקשר.
    protected override string GetId(RequestToVehicles entity) => entity.RequestToVehiclesId;
    // מציב את מזהה הקשר שהתקבל בכתובת בבקשה.
    protected override void SetId(RequestToVehicles entity, string id) => entity.RequestToVehiclesId = id;
}

/// <summary>
/// חושף נקודות קצה לניהול בקשות נסיעה.
/// </summary>
// מפעיל בדיקת מודל אוטומטית לבקשות בקר בקשות הנסיעה.
[ApiController]
// קובע את תחילית הנתיב של בקשות ההצטרפות לנסיעות.
[Route("api/ride-requests")]
// בקר CRUD לבקשות הצטרפות לנסיעה.
public sealed class RideRequestsController(IRideRequestService service, IMapper mapper)
    // מגדיר את הישות, ה-DTOs והמזהה המספרי שבו משתמש בקר הבסיס.
    : CrudController<RideRequest, CreateRideRequestDto, UpdateRideRequestDto, RideRequestResponseDto, int>(mapper)
{
    // מחפש בקשת נסיעה לפי המזהה שלה.
    protected override Task<RideRequest?> FindAsync(int id) => service.FindAsync(id);
    // מחזיר את כל בקשות הנסיעה.
    protected override Task<IReadOnlyList<RideRequest>> ListAsync() => service.ListAsync();
    // יוצר בקשת נסיעה; השירות קובע לה זמן ומצב התחלתי.
    protected override Task<RideRequest> InsertAsync(RideRequest entity) => service.InsertAsync(entity);
    // מעדכן בקשת נסיעה קיימת.
    protected override Task UpdateAsync(int id, RideRequest entity) => service.UpdateAsync(id, entity);
    // מוחק בקשת נסיעה.
    protected override Task DeleteAsync(int id) => service.DeleteAsync(id);
    // קורא את המזהה המספרי מתוך בקשת הנסיעה.
    protected override int GetId(RideRequest entity) => entity.RequestId;
    // מעדכן את מזהה הישות לפי המזהה שבנתיב.
    protected override void SetId(RideRequest entity, int id) => entity.RequestId = id;
}

/// <summary>
/// חושף נקודות קצה לניהול נסיעות.
/// </summary>
// מפעיל בדיקת מודל אוטומטית לבקשות בקר הנסיעות.
[ApiController]
// מגדיר את תחילית הנתיב של נקודות הקצה לנסיעות.
[Route("api/rides")]
// בקר CRUD לנסיעות.
public sealed class RidesController(IRideService service, IMapper mapper)
    // מגדיר את טיפוסי הישות וה-DTO ואת המזהה המספרי לבקר הבסיס.
    : CrudController<Ride, CreateRideDto, UpdateRideDto, RideResponseDto, int>(mapper)
{
    // מאתר נסיעה לפי מזהה.
    protected override Task<Ride?> FindAsync(int id) => service.FindAsync(id);
    // מחזיר את כל הנסיעות.
    protected override Task<IReadOnlyList<Ride>> ListAsync() => service.ListAsync();
    // שומר נסיעה חדשה; השירות מאתחל את מצבה.
    protected override Task<Ride> InsertAsync(Ride entity) => service.InsertAsync(entity);
    // מעדכן נסיעה קיימת.
    protected override Task UpdateAsync(int id, Ride entity) => service.UpdateAsync(id, entity);
    // מוחק נסיעה לפי מזהה.
    protected override Task DeleteAsync(int id) => service.DeleteAsync(id);
    // קורא את מזהה הנסיעה מתוך הישות.
    protected override int GetId(Ride entity) => entity.RideId;
    // מגדיר את מזהה הנסיעה לערך שהתקבל בנתיב.
    protected override void SetId(Ride entity, int id) => entity.RideId = id;
}

/// <summary>
/// חושף נקודות קצה לניהול משתמשים ומשאיר את הכנת הסיסמה לשירות המשתמשים.
/// </summary>
// מפעיל בדיקת מודל אוטומטית לבקשות המשתמש.
[ApiController]
// קובע את תחילית הנתיב של נקודות הקצה למשתמשים.
[Route("api/users")]
// בקר משתמשים שמעביר את פעולות הנתונים ואת הכנת הסיסמה לשירותים.
public sealed class UsersController(
    // שירות המשתמשים מאתר, שומר, מעדכן ומוחק משתמשים.
    IUserService service,
    // הממפה ממיר בין DTO של המשתמש לבין ישות המשתמש.
    IMapper mapper)
    // מגדיר DTOs, ישות ומזהה מספרי לפעולות ה-CRUD המשותפות.
    : CrudController<Users, CreateUserDto, UpdateUserProfileEntityDto, UserResponseDto, int>(mapper)
{
    // מחפש משתמש לפי מזהה.
    protected override Task<Users?> FindAsync(int id) => service.FindAsync(id);
    // מחזיר את כל המשתמשים.
    protected override Task<IReadOnlyList<Users>> ListAsync() => service.ListAsync();
    // מוסיף משתמש לאחר שהפעולה CreateEntity מכינה את פרטי החשבון.
    protected override Task<Users> InsertAsync(Users entity) => service.InsertAsync(entity);
    // מעדכן משתמש קיים.
    protected override Task UpdateAsync(int id, Users entity) => service.UpdateAsync(id, entity);
    // מוחק משתמש לפי מזהה.
    protected override Task DeleteAsync(int id) => service.DeleteAsync(id);
    // קורא את מזהה המשתמש מתוך הישות.
    protected override int GetId(Users entity) => entity.UserId;
    // קובע את מזהה המשתמש לפי הערך שבכתובת הבקשה.
    protected override void SetId(Users entity, int id) => entity.UserId = id;

    /// <summary>יוצר ישות משתמש ומכין אותה לשמירה.</summary>
    /// <param name="dto">נתוני המשתמש שהתקבלו בבקשת היצירה.</param>
    /// <returns>ישות משתמש עם סיסמה מגובבת ופרטי חשבון מאותחלים.</returns>
    protected override Users CreateEntity(CreateUserDto dto)
    {
        // ממיר את נתוני המשתמש מה-DTO לישות.
        var user = base.CreateEntity(dto);
        // מעביר לשירות המשתמשים את גיבוב הסיסמה ואת אתחול פרטי החשבון.
        service.PrepareForCreate(user, dto.Password);
        // מחזיר את הישות שהוכנה לצורך שמירה.
        return user;
    }
}
