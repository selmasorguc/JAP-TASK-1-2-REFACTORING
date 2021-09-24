namespace API.DTOs
{
    using System;
    using System.Collections.Generic;

    public class ScreeningDto
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public int MaxSeatsNumber { get; set; }

        public int MediaId { get; set; }

        public List<TicketDto> SoldTickets { get; set; }
    }
}
