using System;
using System.Net.Mail;
using WebApi.Models.Base;

namespace WebApi.Models.User
{
    public class User : IEntityBase<Guid>
    {
        private const int PASSWORD_MIN_LENGTH = 6;

        public Guid Id { get; set; }

        /// <inheritdoc />
        public void SetNewId()
        {
            Id = Guid.NewGuid();
        }

        /// <inheritdoc />
        public void Patch(IEntityBase<Guid> other)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public string CheckPost()
        {
            if (string.IsNullOrEmpty(Email) || !IsValidEmail(Email)) return "Invalid email";
            if (string.IsNullOrEmpty(Password) || Password.Length < PASSWORD_MIN_LENGTH) return "Password is too short";
            return null;
        }

        public string Email { get; set; }

        public string Password { get; set; }

        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}