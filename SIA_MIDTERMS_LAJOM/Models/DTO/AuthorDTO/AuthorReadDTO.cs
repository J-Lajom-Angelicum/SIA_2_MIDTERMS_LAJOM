namespace SIA_MIDTERMS_LAJOM.Models.DTO.AuthorDTO
{
    public class AuthorReadDTO
    {
        public string AuId { get; set; }

        public string AuLname { get; set; }

        public string AuFname { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Zip { get; set; }

        public bool Contract { get; set; }
    }
}
