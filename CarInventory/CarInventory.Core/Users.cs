using System;

namespace CarInventory.Core
{
    public class Users
    {
        /// <summary>
        /// Get and Set Property of Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Get and Set Property of Username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Get and Set Property of Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Get and Set Property of Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Get and Set Property of IsActive
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Get and Set Property of LastLogin
        /// </summary>
        public DateTime? LastLogin { get; set; }
        /// <summary>
        /// Get and Set Property of IsEmailVerified
        /// </summary>
        public bool IsEmailVerified { get; set; }
        /// <summary>
        /// Get and Set Property of ContactNumber
        /// </summary>
        public string ContactNumber { get; set; }
    }
}
