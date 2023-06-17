using StudentSystem.Domain.Enums;

namespace StudentSystem.Domain.Entities
{
    public class User
    {
        private const int DEFAULT_EXPIRE_DATE_IN_MINUTES = 1440;

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public UserRole Role { get; set; }

        public string? RefreshToken { get; private set; }
        public DateTime? RefreshTokenExpireDate { get; private set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }

        public IList<SubjectsOfTeachers> SubjectsOfTeachers { get; set; }

        public IList<SubjectsOfStudents> SubjectOfStudent { get; set; }



        public void UpdateRefreshToken(
        string refreshToken,
        int expireDateInMinutes = DEFAULT_EXPIRE_DATE_IN_MINUTES)
        {
            RefreshToken = refreshToken;

            RefreshTokenExpireDate = DateTime.UtcNow
                .AddMinutes(expireDateInMinutes);
        }

    }
}
