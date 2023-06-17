using StudentSystem.Application.DTO;
using StudentSystem.Application.DTO.SubjectsOfStudents;
using StudentSystem.Domain.Entities;

namespace StudentSystem.Application.Service
{
    public class SSFactory : ISSFactory
    {
        public SubjectsOfStudents MapToSS(SSCreationDto sSCreationDto)
        {
            return new SubjectsOfStudents
            {
                StudentId = sSCreationDto.studentId,
                SubjectsOfTeachersId = sSCreationDto.sTId,
                Mark = sSCreationDto.mark ?? 0
            };
        }

        public void MaptoSS(SubjectsOfStudents subjectsOfStudents, SSForModificationDto sSForModificationDto)
        {
            subjectsOfStudents.StudentId = sSForModificationDto.studentId ?? subjectsOfStudents.StudentId;
            subjectsOfStudents.SubjectsOfTeachersId = sSForModificationDto.ssId ?? subjectsOfStudents.SubjectsOfTeachersId;
            subjectsOfStudents.Mark = sSForModificationDto.mark ?? subjectsOfStudents.Mark;
        }

        public SSDto MapToSSDto(SubjectsOfStudents subjectsOfStudents)
        {
            UserDto? userDto = default;
            STDto? stdto = default;

            if (subjectsOfStudents.Student is not null)
            {
                userDto = new UserDto(
                    subjectsOfStudents.Student.Id,
                    subjectsOfStudents.Student.FirstName,
                    subjectsOfStudents.Student.LastName,
                    subjectsOfStudents.Student.Email,
                    subjectsOfStudents.Student.PhoneNumber,
                    subjectsOfStudents.Student.BirthDate,
                    subjectsOfStudents.Student.Role
                    );
            }

            if(subjectsOfStudents.SubjectsOfTeachers is not null)
            {
                UserDto? userDto2 = default;
                SubjectDto? subjectDto = default;

                if (subjectsOfStudents.SubjectsOfTeachers.Teacher is not null)
                {
                    userDto2 = new UserDto(
                        subjectsOfStudents.SubjectsOfTeachers.Teacher.Id,
                        subjectsOfStudents.SubjectsOfTeachers.Teacher.FirstName,
                        subjectsOfStudents.SubjectsOfTeachers.Teacher.LastName,
                        subjectsOfStudents.SubjectsOfTeachers.Teacher.Email,
                        subjectsOfStudents.SubjectsOfTeachers.Teacher.PhoneNumber,
                        subjectsOfStudents.SubjectsOfTeachers.Teacher.BirthDate,
                        subjectsOfStudents.SubjectsOfTeachers.Teacher.Role
                        );
                }

                if (subjectsOfStudents.SubjectsOfTeachers.Subject is not null)
                {
                    subjectDto = new SubjectDto(
                        subjectsOfStudents.SubjectsOfTeachers.Subject.Id,
                        subjectsOfStudents.SubjectsOfTeachers.Subject.SubjectName);
                }

                stdto= new STDto(
                    subjectsOfStudents.SubjectsOfTeachers.Id,
                    subjectsOfStudents.SubjectsOfTeachers.TeacherId,
                    subjectsOfStudents.SubjectsOfTeachers.SubjectId,
                    userDto2,
                    subjectDto);
            }

            return new SSDto(
               subjectsOfStudents.Id,
               subjectsOfStudents.StudentId,
               subjectsOfStudents.SubjectsOfTeachersId,
               userDto,
               stdto,
               subjectsOfStudents.Mark);
        }
    }
}
