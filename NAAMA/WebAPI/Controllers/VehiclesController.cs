// מייבא כלי למיפוי בין ישות הרכב לבין אובייקטי ה-DTO.
using AutoMapper;
// מייבא את חוזה שירות כלי הרכב; הבקר אינו ניגש ישירות ל-repository.
using BLL.Services;
// מייבא את מודל הנתונים של כלי הרכב.
using DAL.Models;
// מייבא תכונות MVC ותוצאות HTTP עבור API.
using Microsoft.AspNetCore.Mvc;
// מייבא את DTOs המשמשים בבקשות ובתשובות של כלי הרכב.
using NAAMA.DTOs;

// מגדיר את מרחב השמות של בקרי ה-API.
namespace WebAPI.Controllers;

/// <summary>
/// חושף נקודות קצה לניהול כלי רכב באמצעות שירות כלי הרכב.
/// </summary>
// מאפשר ל-ASP.NET Core לבצע בדיקת מודל אוטומטית בבקשות.
[ApiController]
// קובע את תחילית הנתיב לכל פעולות כלי הרכב.
[Route("api/vehicles")]
// בקר המטפל בפעולות HTTP של כלי רכב ומעביר את הלוגיקה לשירות.
public sealed class VehiclesController(
    // שירות הגישה והלוגיקה העסקית של כלי הרכב.
    IVehicleService service,
    // ממיר ישויות רכב ל-DTOs ולהפך.
    IMapper mapper) : ControllerBase
{
    // קובע שהפעולה תענה לבקשת GET אל /api/vehicles.
    [HttpGet]
    /// <summary>מחזיר את כל כלי הרכב.</summary>
    /// <returns>HTTP 200 עם רשימת כלי רכב בפורמט DTO.</returns>
    public async Task<ActionResult<IReadOnlyList<VehicleDto>>> GetAll()
    {
        // מבקש מהשירות את כלי הרכב.
        var vehicles = await service.ListAsync();
        // ממיר את הרשימה ל-DTOs ומחזיר תשובת HTTP 200.
        return Ok(mapper.Map<IReadOnlyList<VehicleDto>>(vehicles));
    }

    // קובע שהפעולה תענה לבקשת GET עם מזהה מספרי בכתובת.
    [HttpGet("{id:int}")]
    /// <summary>מחזיר כלי רכב אחד לפי מזהה.</summary>
    /// <param name="id">מזהה כלי הרכב שבכתובת.</param>
    /// <returns>HTTP 404 אם לא נמצא כלי רכב, או HTTP 200 עם פרטיו.</returns>
    public async Task<ActionResult<VehicleDto>> GetById(int id)
    {
        // מחפש את כלי הרכב באמצעות השירות.
        var vehicle = await service.FindAsync(id);
        // מחזיר 404 אם לא נמצא; אחרת ממיר ל-DTO ומחזיר 200.
        return vehicle is null
            ? NotFound()
            : Ok(mapper.Map<VehicleDto>(vehicle));
    }

    // קובע נתיב GET ייעודי לחיפוש כלי רכב לפי מזהה נהג.
    [HttpGet("by-driver/{driverId:int}")]
    /// <summary>מחזיר את כלי הרכב המשויכים לנהג.</summary>
    /// <param name="driverId">המזהה המספרי של הנהג.</param>
    /// <returns>HTTP 200 עם כלי הרכב של הנהג בפורמט DTO.</returns>
    public async Task<ActionResult<IReadOnlyList<VehicleDto>>> GetByDriverId(int driverId)
    {
        // מבקש מהשירות את כלי הרכב של הנהג.
        var vehicles = await service.GetVehiclesByDriverAsync(driverId);
        // ממיר את התוצאות ל-DTOs ומחזיר HTTP 200.
        return Ok(mapper.Map<IReadOnlyList<VehicleDto>>(vehicles));
    }

    // קובע שהפעולה תענה לבקשת POST לכתובת הבסיס של כלי הרכב.
    [HttpPost]
    /// <summary>יוצר כלי רכב חדש.</summary>
    /// <param name="dto">פרטי כלי הרכב שנשלחו בגוף הבקשה.</param>
    /// <returns>HTTP 201 עם פרטי הרכב וכתובת לשליפתו.</returns>
    public async Task<ActionResult<VehicleDto>> Create(CreateVehicleDto dto)
    {
        // ממיר את פרטי הבקשה לישות רכב.
        var vehicle = mapper.Map<Vehicle>(dto);
        // מבקש מהשירות לשמור את כלי הרכב החדש.
        var created = await service.InsertAsync(vehicle);
        // ממיר את הישות שנשמרה ל-DTO תשובה.
        var response = mapper.Map<VehicleDto>(created);

        // מחזיר HTTP 201 ומציין שהכתובת לשליפת הרכב היא הפעולה GetById.
        return CreatedAtAction(
            nameof(GetById),
            new { id = created.VehicleId },
            response);
    }

    // קובע שהפעולה תענה לבקשת PUT עם מזהה רכב בכתובת.
    [HttpPut("{id:int}")]
    /// <summary>מעדכן את פרטי כלי הרכב.</summary>
    /// <param name="id">מזהה הרכב שבכתובת.</param>
    /// <param name="dto">הערכים החדשים שנשלחו בגוף הבקשה.</param>
    /// <returns>HTTP 404 אם הרכב לא נמצא, או HTTP 204 לאחר עדכון.</returns>
    public async Task<IActionResult> Update(int id, UpdateVehicleDto dto)
    {
        // מאתר את הרכב הקיים כדי לעדכן רק רשומה קיימת.
        var vehicle = await service.FindAsync(id);
        // מחזיר 404 כשהמזהה אינו תואם לרכב קיים.
        if (vehicle is null)
        {
            return NotFound();
        }

        // מעתיק את הערכים שמותר לעדכן מה-DTO אל הישות הקיימת.
        mapper.Map(dto, vehicle);
        // שומר את השינויים באמצעות שירות כלי הרכב.
        await service.UpdateAsync(id, vehicle);
        // מחזיר HTTP 204 לציון שהעדכון הסתיים ללא גוף תשובה.
        return NoContent();
    }

    // קובע שהפעולה תענה לבקשת DELETE עם מזהה רכב בכתובת.
    [HttpDelete("{id:int}")]
    /// <summary>מוחק כלי רכב לפי מזהה.</summary>
    /// <param name="id">מזהה הרכב שבכתובת.</param>
    /// <returns>HTTP 404 אם הרכב לא נמצא, או HTTP 204 לאחר מחיקה.</returns>
    public async Task<IActionResult> Delete(int id)
    {
        // מאתר את הרכב לפני המחיקה כדי להחזיר 404 אם אינו קיים.
        var vehicle = await service.FindAsync(id);
        // מחזיר 404 כשהרכב לא נמצא.
        if (vehicle is null)
        {
            return NotFound();
        }

        // מבקש מהשירות למחוק את הרכב לפי המזהה שלו.
        await service.DeleteAsync(id);
        // מחזיר HTTP 204 לציון שהמחיקה הסתיימה ללא גוף תשובה.
        return NoContent();
    }
}
