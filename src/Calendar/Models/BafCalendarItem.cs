using Heron.MudCalendar;

namespace Avolutions.Baf.Blazor.Calendar.Models;

public class BafCalendarItem : CalendarItem
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public string? ColorHex { get; set; }
    public string? Icon { get; set; }
}