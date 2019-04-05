namespace HotalApp.Models
{
    public class RoomsRegistrationLog
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public bool Buzy { get; set; }
    }
}
