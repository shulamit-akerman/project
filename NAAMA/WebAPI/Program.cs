// נקודת הכניסה של ה-API: רישום שירותים, הגדרת מסד הנתונים והרכבת צינור הבקשות.
// מייבא את AutoMapper עבור המרת אובייקטים.
using AutoMapper;
// מייבא את חוזי ה-BLL שנמצאים במרחב השמות Interfaces.
using BLL.Interfaces;
// מייבא את פרופילי ההמרה של AutoMapper.
using BLL.MappingProfiles;
// מייבא את חוזי מימושי הגישה לנתונים.
using BLL.Repositories;
// מייבא את שירותי הלוגיקה העסקית.
using BLL.Services;
// מייבא את הקשר מסד הנתונים.
using DAL;
// מייבא את מודל המשתמש עבור רישום מגבב הסיסמאות.
using DAL.Models;
// מייבא את מנגנון גיבוב הסיסמאות של ASP.NET Identity.
using Microsoft.AspNetCore.Identity;
// מייבא את הרחבות ההגדרה של Entity Framework Core.
using Microsoft.EntityFrameworkCore;
// מייבא את מתאם גיבוב הסיסמאות שממומש בשכבת ה-API.
using WebAPI.Services;

// יוצר בונה אפליקציה ומטעין הגדרות סביבה ותצורה.
var builder = WebApplication.CreateBuilder(args);

// רושם תמיכה בבקרים כדי ש-ASP.NET Core יוכל לזהותם ולהפעילם.
builder.Services.AddControllers();
// מוסיף יצירת מסמך OpenAPI לתיאור נקודות הקצה של ה-API.
builder.Services.AddOpenApi();

// רושם את AppDbContext ומגדיר אותו להתחבר ל-SQL Server.
builder.Services.AddDbContext<AppDbContext>(options =>
    // קורא את מחרוזת החיבור בשם DefaultConnection מקובצי התצורה.
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// קורא מפתח רישיון אופציונלי של AutoMapper מהגדרות האפליקציה.
var autoMapperLicenseKey = builder.Configuration["AutoMapper:LicenseKey"];
// רושם את AutoMapper ומאתר פרופילי מיפוי בהרכבה שבה נמצא MappingProfile.
builder.Services.AddAutoMapper(
    // מגדיר את AutoMapper באמצעות פעולת תצורה.
    configuration =>
    {
        // קובע מפתח רישיון רק אם הוגדר ערך שאינו ריק.
        if (!string.IsNullOrWhiteSpace(autoMapperLicenseKey))
        {
            // מעביר את מפתח הרישיון לתצורת AutoMapper.
            configuration.LicenseKey = autoMapperLicenseKey;
        }
    },
    // ההרכבה שמכילה את פרופילי המיפוי של הפרויקט.
    typeof(MappingProfile).Assembly);
// רושם מימוש repository להזמנות לכל בקשת HTTP בנפרד.
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
// רושם מימוש repository להודעות צ'אט לכל בקשת HTTP בנפרד.
builder.Services.AddScoped<IChatMessageRepository, ChatMessageRepository>();
// רושם מימוש repository להודעות המשויכות להזמנות.
builder.Services.AddScoped<IMassageToBookingRepository, MassageToBookingRepository>();
// רושם מימוש repository לתשלומים.
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
// רושם מימוש repository לבקשות.
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
// רושם מימוש repository לקשרים בין בקשות לנסיעות.
builder.Services.AddScoped<IRequestToRideRepository, RequestToRideRepository>();
// רושם מימוש repository לקשרים בין בקשות לכלי רכב.
builder.Services.AddScoped<IRequestToVehiclesRepository, RequestToVehiclesRepository>();
// רושם מימוש repository לבקשות הצטרפות לנסיעה.
builder.Services.AddScoped<IRideRequestRepository, RideRequestRepository>();
// רושם מימוש repository לנסיעות.
builder.Services.AddScoped<IRideRepository, RideRepository>();
// רושם מימוש repository למשתמשים.
builder.Services.AddScoped<IUserRepository, UserRepository>();
// רושם מימוש repository לכלי רכב.
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
// רושם את מגבב הסיסמאות המובנה של ASP.NET Identity.
builder.Services.AddScoped<IPasswordHasher<Users>, PasswordHasher<Users>>();
// מאפשר לשירותי BLL להשתמש בגיבוב בלי להיות תלויים ישירות ב-ASP.NET Identity.
builder.Services.AddScoped<IUserPasswordHasher, IdentityUserPasswordHasher>();

// רושם את שירות הלוגיקה העסקית להזמנות.
builder.Services.AddScoped<IBookingService, BookingService>();
// רושם את שירות הלוגיקה העסקית להודעות צ'אט.
builder.Services.AddScoped<IChatMessageService, ChatMessageService>();
// רושם את שירות הלוגיקה העסקית לתשלומים.
builder.Services.AddScoped<IPaymentService, PaymentService>();
// רושם את שירות ההודעות המשויכות להזמנות.
builder.Services.AddScoped<IMassageToBookingService, MassageToBookingService>();
// רושם את שירות כלי הרכב.
builder.Services.AddScoped<IVehicleService, VehicleService>();
// רושם את שירות המשתמשים.
builder.Services.AddScoped<IUserService, UserService>();
// רושם את שירות הנסיעות.
builder.Services.AddScoped<IRideService, RideService>();
// רושם את שירות בקשות ההצטרפות לנסיעות.
builder.Services.AddScoped<IRideRequestService, RideRequestService>();
// רושם את שירות הקשרים בין בקשות לכלי רכב.
builder.Services.AddScoped<IRequestToVehiclesService, RequestToVehiclesService>();
// רושם את שירות הקשרים בין בקשות לנסיעות.
builder.Services.AddScoped<IRequestToRideService, RequestToRideService>();
// רושם את שירות הבקשות, כולל איתור התאמות.
builder.Services.AddScoped<IRequestService, RequestService>();

// בונה את אפליקציית ה-Web לאחר רישום כל התלויות.
var app = builder.Build();

// מוסיף נקודת קצה למסמך OpenAPI רק בסביבת פיתוח.
if (app.Environment.IsDevelopment())
{
    // מפרסם את מסמך ה-OpenAPI בנתיב ברירת המחדל.
    app.MapOpenApi();
}

// מפנה בקשות HTTP ל-HTTPS.
app.UseHttpsRedirection();

// מפעיל middleware לאימות הרשאות של בקשות.
app.UseAuthorization();

// מחבר את נקודות הקצה של כל הבקרים ל-pipeline של האפליקציה.
app.MapControllers();

// מפעיל את שרת ה-Web ומתחיל לקבל בקשות.
app.Run();
