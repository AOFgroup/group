namespace HostelPro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Security.Cryptography;
    using System.Text;

    [Table("Customer")]
    public partial class Customer
    {
    
        public Customer()
        {
            Bookings = new HashSet<Booking>();
        }
        public int ID { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        [StringLength(255)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password"), DataType(DataType.Password)]

        public string Hash { get; set; }
        [Required(ErrorMessage = "Comfirm Password"), Compare("Hash"), DataType(DataType.Password)]
        public string Salt { get; set; }

        public int? HostelRoleId { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual HostelRole HostelRole { get; set; }
   

        public string HashPassword(string password)
        {
            var saltedPass = string.Concat(password, Salt);
            var sha256 = new SHA256Managed();
            var bytes = UTF8Encoding.UTF8.GetBytes(saltedPass);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public string GenerateSalt()
        {
            var random = new RNGCryptoServiceProvider();
            var salt = new Byte[8];
            random.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        public bool ValidatePassword(string password)
        {
            var hash = HashPassword(password);
            return string.Equals(Hash, hash);
        }
    }
}
