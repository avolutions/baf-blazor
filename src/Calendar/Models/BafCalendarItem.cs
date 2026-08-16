using Heron.MudCalendar;
using MudBlazor;

namespace Avolutions.Baf.Blazor.Calendar.Models;

public class BafCalendarItem : CalendarItem
{
    public string? Description { get; set; }
    public string? ColorHex { get; set; }
    public string? Icon { get; set; }
}