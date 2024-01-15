namespace GlobalTicket.TicketManagement.Application.Features.Categories.Commands
{
    public class CreateCategoryDto
    {
        public Guid Category { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}