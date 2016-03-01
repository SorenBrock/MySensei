using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using mysensei.Models;

namespace mysensei.Areas.Admin.Models
{
    public class Repository
    {
        private readonly mysenseiCTXContainer _db = new mysenseiCTXContainer();

        #region [Person]

        internal IQueryable<Person> SearchPersons(string search)
        {
            return _db.PersonSet.Where(x => x.FirstName.Contains(search) || x.LastName.Contains(search));
        }

        internal Person GetPersonById(int id)
        {
            return _db.PersonSet.FirstOrDefault(x => x.Id == id);
        }

        internal bool CheckZipCode(int zipCode)
        {
            return _db.LocationCitySet.Any(x => x.ZipcodeStart <= zipCode && zipCode <= x.ZipcodeEnd);
        }

        internal bool CheckPersonUsername(Person person)
        {
            return !_db.PersonSet.Any(x => x.Username.Equals(person.Username) && x.Id != person.Id);
        }

        internal void DeletePerson(Person person)
        {
            try
            {
                var dbPerson = _db.PersonSet.FirstOrDefault(x => x.Id == person.Id);

                _db.LogChatReadSet.RemoveRange(_db.LogChatReadSet.Where(x => x.PersonId == person.Id));
                // Sletter alle chatrooms, der ejes af person eller hvor der kun er to chattere
                foreach (var chatRoom in dbPerson.ChatRoom.Where(x => x.OwnerPerson.Id == dbPerson.Id || x.Chat.Count == 2).ToList())
                {
                    _db.ChatSet.RemoveRange(_db.ChatSet.Where(x => x.ChatRoomId == chatRoom.Id || x.PersonId == person.Id));
                    chatRoom.Person.ToList().ForEach(x => x.ChatRoom.Remove(chatRoom));
                    _db.ChatRoomSet.Remove(chatRoom);
                }
                // Afmelder person fra de restende chatrooms
                dbPerson?.ChatRoom.ToList().ForEach(x => x.Person.Remove(dbPerson));

                _db.RatingSet.RemoveRange(_db.RatingSet.Where(x => x.Person.Id == person.Id));
                foreach (var course in dbPerson.TeacherCourse.ToList())
                    DeleteCourse(course);

                // fjerner person fra tilmeldte kurser
                dbPerson?.StudentCourse.ToList().ForEach(x => x.Student.Remove(dbPerson));
                _db.PersonSet.Remove(dbPerson);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        internal void UpdatePerson(Person person)
        {
            var varPerson = GetPersonById(person.Id);
            try
            {
                varPerson.FirstName = person.FirstName;
                varPerson.LastName = person.LastName;
                varPerson.Address = person.Address;
                varPerson.Zipcode = person.Zipcode;
                varPerson.Username = person.Username;
                varPerson.LocationCity = _db.LocationCitySet.FirstOrDefault(x => x.ZipcodeStart <= person.Zipcode && x.ZipcodeEnd >= person.Zipcode);
                varPerson.Password = person.Password;
                varPerson.Email = person.Email;
                varPerson.Phone = person.Phone;
                varPerson.Active = person.Active;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        #endregion [Person]

        #region [Course]

        internal IQueryable<Course> SearchCourses(string search)
        {
            return _db.CourseSet.Where(x => x.Name.Contains(search));
        }

        internal Course GetCourseById(int id)
        {
            return _db.CourseSet.FirstOrDefault(x => x.Id == id);
        }

        internal void UpdateCourse(Course course)
        {
            var varCourse = GetCourseById(course.Id);
            try
            {
                varCourse.Name = course.Name;
                varCourse.Description = course.Description;
                varCourse.Active = course.Active;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        internal void RemoveStudentFromCourse(int courseId, int personId)
        {
            try
            {
                var firstOrDefault = _db.CourseSet.FirstOrDefault(x => x.Id == courseId);
                firstOrDefault?.Student.Remove(GetPersonById(personId));
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        internal void RemoveTagFromCourse(int courseId, int tagId)
        {
            try
            {
                var firstOrDefault = _db.CourseSet.FirstOrDefault(x => x.Id == courseId);
                firstOrDefault?.Tag.Remove(GetTagById(tagId));
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }
   
        internal void DeleteCourse(Course course)
        {
            try
            {
                var dbCourse = _db.CourseSet.FirstOrDefault(x => x.Id == course.Id);
                _db.RatingSet.RemoveRange(_db.RatingSet.Where(x => x.CourseId == dbCourse.Id));

                if (dbCourse != null)
                {
                    foreach (var chatRoom in dbCourse.ChatRoom.ToList())
                    {
                        _db.ChatSet.RemoveRange(_db.ChatSet.Where(x => x.ChatRoomId == chatRoom.Id));
                        chatRoom?.Person.ToList().ForEach(x => x.ChatRoom.Remove(chatRoom));
                        _db.ChatRoomSet.Remove(chatRoom);
                    }
                    dbCourse?.Student.ToList().ForEach(x => x.StudentCourse.Remove(dbCourse));
                    dbCourse?.Tag.ToList().ForEach(x => x.Course.Remove(dbCourse));
                    _db.CourseSet.Remove(dbCourse);
                }
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        #endregion [Course]

        #region [Tag]

        internal IQueryable<Tag> SearchTags(string search)
        {
            return _db.TagSet.Where(x => x.Name.Contains(search));
        }

        internal Tag GetTagById(int id)
        {
            return _db.TagSet.FirstOrDefault(x => x.Id == id);
        }

        internal Tag CreateTag()
        {
            Tag result = null;
            try
            {
                result = _db.TagSet.Add(new Tag { Name = "Nyt Tag" });
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return result;
        }

        internal void UpdateTag(Tag tag)
        {
            var varTag = GetTagById(tag.Id);
            try
            {
                varTag.Name = tag.Name;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        internal void DeleteTag(Tag tag)
        {
            try
            {
                tag = GetTagById(tag.Id);
                tag.TagGroup.ToList().ForEach(x=>x.Tag.Remove(tag));
                tag.Course.ToList().ForEach(x => x.Tag.Remove(tag));
                _db.TagSet.Remove(tag);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        internal void RemoveTagGroupFromTag(int tagId, int tagGroupId)
        {
            try
            {
                var firstOrDefault = _db.TagSet.FirstOrDefault(x => x.Id == tagId);
                firstOrDefault?.TagGroup.Remove(_db.TagGroupSet.FirstOrDefault(x => x.Id == tagGroupId));
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        internal void AddTagGroupToTag(int tagId, int tagGroupId)
        {
            try
            {
                var firstOrDefault = _db.TagSet.FirstOrDefault(x => x.Id == tagId);
                firstOrDefault?.TagGroup.Add(_db.TagGroupSet.FirstOrDefault(x => x.Id == tagGroupId));
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        internal IEnumerable<TagGroup> TagGroupToAdd(Tag tag)
        {
            return _db.TagGroupSet.ToList().Where(tagGroup => tagGroup.Tag.All(x => x.Id != tag.Id));
        }

        #endregion [Tag]

        #region [LocationGroup]

        internal IQueryable<LocationGroup> SearchLocationGroups(string search)
        {
            return _db.LocationGroupSet.Where(x => x.Name.Contains(search));
        }

        internal LocationGroup GetLocationGroupById(int id)
        {
            return _db.LocationGroupSet.FirstOrDefault(x => x.Id == id);
        }

        internal void UpdateLocationGroup(LocationGroup locationGroup)
        {
            var varLocationGroup = GetLocationGroupById(locationGroup.Id);
            try
            {
                varLocationGroup.Name = locationGroup.Name;
                varLocationGroup.ZipcodeStart = locationGroup.ZipcodeStart;
                varLocationGroup.ZipcodeEnd = locationGroup.ZipcodeEnd;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        internal void DeleteLocationGroup(LocationGroup locationGroup)
        {
            try
            {
                _db.LocationGroupSet.Remove(GetLocationGroupById(locationGroup.Id));
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        internal LocationGroup CreateLocationGroup()
        {
            LocationGroup result = null;
            try
            {
                result = new LocationGroup
                {
                    Name = "Nyt Post Skema",
                    ZipcodeStart = 1000,
                    ZipcodeEnd = 1000
                };

                _db.LocationGroupSet.Add(result);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }

            return result;
        }

        #endregion [LocationGroup]
        
        #region [Login]

        internal UserAdmin UserLoginCheck(string userName, string userPassword)
        {
            UserAdmin userAdmin = null;
            Administrator administrator = null;
            try
            {
                administrator = _db.AdministratorSet.FirstOrDefault(x => x.UserName == userName && x.Password == userPassword);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            if (administrator != null)
                userAdmin = new UserAdmin() { Id = administrator.Id, Name = administrator.Name, UserName = administrator.UserName,IsAdmin = true};
            return userAdmin;
        }

        #endregion [Login]
    }
}