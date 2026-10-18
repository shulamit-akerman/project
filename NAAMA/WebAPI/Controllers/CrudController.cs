// מאפשר להשתמש ב-AutoMapper כדי להמיר בין ישויות לבין DTOs.
using AutoMapper;
// מספק את מחלקות הבסיס והמאפיינים לבניית בקרי HTTP.
using Microsoft.AspNetCore.Mvc;

// מגדיר את מרחב השמות שבו נמצאים כל הבקרים של ה-API.
namespace WebAPI.Controllers;

/// <summary>
/// בקר בסיס גנרי שמרכז את נקודות הקצה המשותפות ליצירה, קריאה, עדכון ומחיקה.
/// </summary>
/// <typeparam name="TEntity">סוג הישות שנשמרת ונשלפת ממסד הנתונים.</typeparam>
/// <typeparam name="TCreateDto">סוג אובייקט הקלט שמתקבל בעת יצירת ישות.</typeparam>
/// <typeparam name="TUpdateDto">סוג אובייקט הקלט שמתקבל בעת עדכון ישות.</typeparam>
/// <typeparam name="TResponseDto">סוג אובייקט התשובה שנשלח ללקוח.</typeparam>
/// <typeparam name="TKey">סוג המזהה של הישות, למשל int או string.</typeparam>
/// <param name="mapper">שירות AutoMapper שמבצע המרות בין האובייקטים.</param>
public abstract class CrudController<TEntity, TCreateDto, TUpdateDto, TResponseDto, TKey>(IMapper mapper) : ControllerBase
    // הישות חייבת להיות מחלקה כדי שניתן יהיה לייצג היעדר ישות באמצעות null.
    where TEntity : class
    // המזהה חייב להיות מסוג שניתן להשתמש בו כמפתח, ולא null.
    where TKey : notnull
{
    /// <summary>מחפש ישות בודדת לפי המזהה שלה.</summary>
    /// <param name="id">המזהה של הישות המבוקשת.</param>
    /// <returns>הישות שנמצאה, או null אם אין ישות עם מזהה זה.</returns>
    protected abstract Task<TEntity?> FindAsync(TKey id);

    /// <summary>מחזיר את רשימת כל הישויות.</summary>
    /// <returns>רשימת הישויות שנמצאו.</returns>
    protected abstract Task<IReadOnlyList<TEntity>> ListAsync();

    /// <summary>מוסיף ישות חדשה באמצעות שכבת השירות.</summary>
    /// <param name="entity">הישות שאותה יש לשמור.</param>
    /// <returns>הישות לאחר שמירתה.</returns>
    protected abstract Task<TEntity> InsertAsync(TEntity entity);

    /// <summary>שומר עדכון לישות קיימת.</summary>
    /// <param name="id">המזהה של הישות לעדכון.</param>
    /// <param name="entity">הישות עם הערכים המעודכנים.</param>
    protected abstract Task UpdateAsync(TKey id, TEntity entity);

    /// <summary>מוחק ישות לפי המזהה שלה.</summary>
    /// <param name="id">המזהה של הישות למחיקה.</param>
    protected abstract Task DeleteAsync(TKey id);

    /// <summary>קורא את המזהה מתוך ישות.</summary>
    /// <param name="entity">הישות שממנה יש לקרוא את המזהה.</param>
    /// <returns>המזהה של הישות.</returns>
    protected abstract TKey GetId(TEntity entity);

    /// <summary>מעדכן את מזהה הישות לערך שהתקבל בבקשה.</summary>
    /// <param name="entity">הישות שמזהה שלה יעודכן.</param>
    /// <param name="id">המזהה שיש להציב בישות.</param>
    protected abstract void SetId(TEntity entity, TKey id);

    /// <summary>ממיר אובייקט ליעד מסוג המבוקש.</summary>
    /// <typeparam name="TDestination">סוג האובייקט שאליו ממירים.</typeparam>
    /// <param name="source">האובייקט שממנו מבצעים את ההמרה.</param>
    /// <returns>אובייקט חדש מהסוג המבוקש.</returns>
    protected TDestination Map<TDestination>(object source) => mapper.Map<TDestination>(source);

    /// <summary>מעתיק ערכים מאובייקט מקור אל אובייקט יעד קיים.</summary>
    /// <typeparam name="TDestination">סוג אובייקט היעד.</typeparam>
    /// <param name="source">האובייקט שממנו מעתיקים את הערכים.</param>
    /// <param name="destination">האובייקט הקיים שאליו מעתיקים.</param>
    /// <returns>אובייקט היעד לאחר עדכון הערכים.</returns>
    protected TDestination Map<TDestination>(object source, TDestination destination) =>
        mapper.Map(source, destination);

    /// <summary>יוצר ישות מתוך DTO; בקר יורש יכול לשנות את אופן היצירה.</summary>
    /// <param name="dto">נתוני הבקשה ליצירת ישות.</param>
    /// <returns>ישות חדשה שמכילה את הערכים שהועברו ב-DTO.</returns>
    protected virtual TEntity CreateEntity(TCreateDto dto) => mapper.Map<TEntity>(dto);

    /// <summary>מעתיק נתוני עדכון מה-DTO אל ישות קיימת.</summary>
    /// <param name="dto">נתוני העדכון שהתקבלו בבקשה.</param>
    /// <param name="entity">הישות הקיימת שאליה מועתקים הנתונים.</param>
    protected virtual void UpdateEntity(TUpdateDto dto, TEntity entity) => mapper.Map(dto, entity);

    /// <summary>נקודת הרחבה לאתחול ערכי ישות לפני יצירה; ברירת המחדל אינה משנה אותה.</summary>
    /// <param name="entity">הישות החדשה לפני שמירתה.</param>
    protected virtual void PrepareForCreate(TEntity entity) { }

    // קובע שפעולת HTTP GET ללא מזהה תפעיל את הפעולה הציבורית GetAll.
    [HttpGet]
    /// <summary>מחזיר את כל הישויות בתור DTOs של תשובה.</summary>
    /// <returns>תשובת HTTP 200 שמכילה את רשימת התוצאות.</returns>
    public async Task<ActionResult<IReadOnlyList<TResponseDto>>> GetAll()
    {
        // מבקש משכבת השירות את הישויות.
        var entities = await ListAsync();
        // ממיר את כל הישויות ל-DTOs ומחזיר תשובת HTTP 200.
        return Ok(mapper.Map<IReadOnlyList<TResponseDto>>(entities));
    }

    // קובע ש-GET עם מזהה בנתיב יפעיל את הפעולה GetById.
    [HttpGet("{id}")]
    /// <summary>מחזיר ישות יחידה לפי המזהה שבנתיב.</summary>
    /// <param name="id">המזהה שהתקבל בכתובת הבקשה.</param>
    /// <returns>HTTP 404 אם לא נמצאה ישות, או HTTP 200 עם DTO אם נמצאה.</returns>
    public async Task<ActionResult<TResponseDto>> GetById(TKey id)
    {
        // מחפש את הישות באמצעות שכבת השירות.
        var entity = await FindAsync(id);
        // אם לא נמצאה ישות מחזירים 404; אחרת ממירים ל-DTO ומחזירים 200.
        return entity is null ? NotFound() : Ok(mapper.Map<TResponseDto>(entity));
    }

    // קובע ש-HTTP POST לנתיב הבקר יפעיל את יצירת הישות.
    [HttpPost]
    /// <summary>יוצר ישות חדשה מתוך DTO ומחזיר את התוצאה.</summary>
    /// <param name="dto">נתוני הישות החדשה שהתקבלו בגוף הבקשה.</param>
    /// <returns>תשובת HTTP 201 הכוללת את הישות שנוצרה ואת כתובת השליפה שלה.</returns>
    public async Task<ActionResult<TResponseDto>> Create(TCreateDto dto)
    {
        // ממיר את נתוני הבקשה לישות של המערכת.
        var entity = CreateEntity(dto);
        // מאפשר לבקר יורש להגדיר ערכי ברירת מחדל לפני השמירה.
        PrepareForCreate(entity);
        // שומר את הישות באמצעות שכבת השירות ומקבל אותה לאחר השמירה.
        var created = await InsertAsync(entity);
        // ממיר את הישות השמורה ל-DTO שמיועד לתשובה ללקוח.
        var result = mapper.Map<TResponseDto>(created);
        // מחזיר HTTP 201, כולל כתובת GET של הישות החדשה ואת תוכן התשובה.
        return CreatedAtAction(nameof(GetById), new { id = GetId(created) }, result);
    }

    // קובע ש-HTTP PUT עם מזהה בנתיב יפעיל את עדכון הישות.
    [HttpPut("{id}")]
    /// <summary>מעדכן ישות קיימת לפי המזהה שבנתיב.</summary>
    /// <param name="id">המזהה של הישות לעדכון.</param>
    /// <param name="dto">הערכים החדשים שנשלחו בגוף הבקשה.</param>
    /// <returns>HTTP 404 אם הישות לא נמצאה, או HTTP 204 לאחר עדכון.</returns>
    public async Task<IActionResult> Update(TKey id, TUpdateDto dto)
    {
        // מאחזר את הישות הקיימת כדי לוודא שהיא קיימת ולעדכן אותה.
        var existing = await FindAsync(id);
        // אין מה לעדכן אם המזהה לא תואם לישות קיימת, ולכן מחזירים 404.
        if (existing is null)
        {
            return NotFound();
        }

        // ממפה את הערכים שהתקבלו ב-DTO אל הישות הקיימת.
        UpdateEntity(dto, existing);
        // שומר על המזהה שבכתובת, גם אם ה-DTO מכיל בטעות מזהה אחר.
        SetId(existing, id);
        // מעביר לשירות את המזהה ואת הישות לאחר עדכון הערכים.
        await UpdateAsync(id, existing);
        // מחזיר HTTP 204 שמציין שהעדכון הצליח ואין תוכן נוסף בתשובה.
        return NoContent();
    }

    // קובע ש-HTTP DELETE עם מזהה בנתיב יפעיל את מחיקת הישות.
    [HttpDelete("{id}")]
    /// <summary>מוחק ישות קיימת לפי המזהה שבנתיב.</summary>
    /// <param name="id">המזהה של הישות למחיקה.</param>
    /// <returns>HTTP 404 אם הישות לא נמצאה, או HTTP 204 לאחר מחיקה.</returns>
    public async Task<IActionResult> Delete(TKey id)
    {
        // מוודא שהישות קיימת לפני שמנסים למחוק אותה.
        if (await FindAsync(id) is null)
        {
            return NotFound();
        }

        // מבקש משכבת השירות למחוק את הישות.
        await DeleteAsync(id);
        // מחזיר HTTP 204 שמציין שהמחיקה הצליחה ואין תוכן נוסף בתשובה.
        return NoContent();
    }
}
