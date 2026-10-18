// ייבוא אובייקטי העברת הנתונים של NAAMA.
using NAAMA.DTOs;

// הגדרת מרחב השמות RideSharing.DTOs כדי לשייך את הטיפוסים למודול המתאים.
namespace RideSharing.DTOs
{
    /// <summary>
    /// מרחיב את סיכום הנסיעה בפרטים הנוספים הנדרשים להצגתה.
    /// </summary>
    public class RideDetailsDto : RideSummaryDto
    {
        // הערות נוספות לגבי הנסיעה.
        public string Notes { get; set; }
        // פרטי כלי הרכב המשויך לנסיעה.
        public VehicleDto Vehicle { get; set; }
    }
}