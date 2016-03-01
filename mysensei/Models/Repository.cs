using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using mysensei.Models.ViewModels;

namespace mysensei.Models
{
    public partial class Repository
    {
        private readonly mysenseiCTXContainer _db = new mysenseiCTXContainer();
        private const int ShowAmountOfCoursesNew = 9;
        private const int ShowAmountOfCoursesHighRating = 9;
        private const int ShowAmountOfCoursesSearch = 300;
        private const int ShowAmountOfTagsSearch = 30;

        #region [Profile]

        internal bool IsPersonTeacherById(int id)
        {
            return _db.CourseSet.Count(x => x.Active && x.PersonId == id) != 0;
        }

        internal bool IsPersonStudentById(int id)
        {
            return _db.PersonSet.Any(x => x.Active && x.Id == id && x.StudentCourse.Count != 0);
        }

        internal Person GetPersonById(int id)
        {
            return _db.PersonSet.FirstOrDefault(x => x.Active && x.Id == id);
        }

        internal IEnumerable<ChatRoom> GetChatRoomsByPersonId(int personId)
        {
            return _db.ChatRoomSet.Where(x => x.Active && x.Person.Any(person => person.Id == personId) || x.OwnerPerson.Id == personId);
        }

        internal IEnumerable<Course> GetStudentCoursesByPersonId(int personId)
        {
            return _db.CourseSet.Where(x => x.Active && x.Student.Any(y => y.Id == personId));
        }

        internal IEnumerable<Course> GetTeacherCoursesByPersonId(int personId)
        {
            return _db.CourseSet.Where(x => x.Active && x.PersonId == personId);
        }

        internal bool IsNewChatMailByPersonId(int personId)
        {
            var result = GetChatRoomsByPersonId(personId);
            var result2 = result.Any(x => x.Chat.Any(y => y.LogChatRead.Any(z => z.PersonId == personId)));
            return result2;
        }

        internal void AddChatToChatroom(int personId, int chatRoomId, string message)
        {
            try
            {
                var chat = new Chat
                {
                    PersonId = personId,
                    ChatRoomId = chatRoomId,
                    Message = message,
                    DateCreated = DateTime.Now,
                };

                chat.LogChatRead.Add(new LogChatRead
                {
                    PersonId = personId,
                    DateCreated = DateTime.Now
                });

                _db.ChatSet.Add(chat);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        #endregion [Profile]

        #region [Course]

        internal Course CreateCourse(int personId, string name, string description)
        {
            Course course = null;
            try
            {
                course = new Course
                {
                    PersonId = personId,
                    Name = name,
                    Description = description,
                    Active = true,
                    DateCreated = DateTime.Now
                };

                _db.CourseSet.Add(course);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }

            return course;
        }

        internal IEnumerable<Tag> GetAllTags()
        {
            return _db.TagSet.OrderBy(x => x.Name);
        }


        internal Course GetCourseById(int courseId)
        {
            return _db.CourseSet.FirstOrDefault(x => x.Active && x.Id == courseId);
        }

        internal LocationGroup GetLastLocationGroupByPerson(Person person)
        {
            return
                _db.LocationGroupSet.Where(x => x.ZipcodeStart >= person.Zipcode && x.ZipcodeEnd >= person.Zipcode)
                    .OrderBy(x => x.ZipcodeStart)
                    .ThenBy(x => x.ZipcodeEnd)
                    .FirstOrDefault();
        }

        internal void AssignStudentCourse(int personId, int courseId)
        {
            var firstOrDefault = _db.CourseSet.FirstOrDefault(x => x.Id == courseId);
            firstOrDefault?.Student.Add(GetPersonById(personId));
            _db.SaveChanges();
        }

        internal void UnassignStudentCourse(int personId, int courseId)
        {
            var firstOrDefault = _db.CourseSet.FirstOrDefault(x => x.Id == courseId);
            firstOrDefault?.Student.Remove(GetPersonById(personId));
            _db.SaveChanges();
        }

        internal void SendMessage(int courseId, int personId, string message)
        {
            var chatRoom = GetOrCreateChatRoom(courseId, personId);
            AddChatToChatroom(personId, chatRoom.Id, message);
        }

        private ChatRoom GetOrCreateChatRoom(int courseId, int personId)
        {
            var result = _db.ChatRoomSet.FirstOrDefault(x => x.Course.Id == courseId && x.Person.ToList().Any(y => y.Id == personId));
            if (result != null) return result;
            try
            {
                result = new ChatRoom
                {
                    PersonId = personId,
                    //OwnerPerson = GetPersonById(personId),
                    Course = GetCourseById(courseId),
                    Active = true,
                    DateCreated = DateTime.Now,
                    Person = new[] {GetCourseById(courseId).Teacher, GetPersonById(personId)}

                };

               _db.ChatRoomSet.Add(result);
                _db.SaveChanges();
                AddChatToChatroom(GetCourseById(courseId).Teacher.Id, result.Id, "Velkommen til kurset: " + GetCourseById(courseId).Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return result;
        }

        internal void DeactivateCourse(int courseId, int personId)
        {
            var course = _db.CourseSet.FirstOrDefault(x => x.Id == courseId && x.PersonId == personId);
            if (course != null)
                course.Active = false;
            _db.SaveChanges();
        }


        #endregion [Course]

        #region [Discover]

        internal IEnumerable<Course> GetListCoursesHighRating()
        {
            var result = new List<Course>();

            foreach (var rating in _db.RatingSet.GroupBy(x => x.CourseId).OrderByDescending(x => x.Sum(y => y.Stars) / x.Count()))
                result.Add(_db.CourseSet.FirstOrDefault(x => x.Id == rating.Key));

            return result.Where(x => x.Active).Take(ShowAmountOfCoursesHighRating);
        }

        internal IEnumerable<Course> GetListCoursesNew()
        {
            return _db.CourseSet.Where(x => x.Active).OrderByDescending(x => x.DateCreated).Take(ShowAmountOfCoursesNew);
        }

        internal IEnumerable<Course> GetListCoursesPrivateByPersonId(User user)
        {
            int id = 0;
            if (user != null)
                id = user.Id;

            return _db.CourseSet.Where(x => x.Active && x.Student.ToList().Any(y => y.Id == id) || x.Teacher.Id == id);
        }

        #endregion [Discover]

        #region [Search]

        internal ViewModelSearchResult SearchCourses(string search, int locationsGroupId)
        {
            var locationGroup = _db.LocationGroupSet.FirstOrDefault(x => x.Id == locationsGroupId);

            var zipCodeStart = 0;
            var zipCodeEnd = 9999;
            if (locationGroup != null)
            {
                zipCodeStart = (int)locationGroup.ZipcodeStart;
                zipCodeEnd = (int)locationGroup.ZipcodeEnd;
            }

            var tagList = new List<Tag>();
            var searchResultCourse = _db.CourseSet.Where(x => x.Active && (x.Teacher.Zipcode >= zipCodeStart && x.Teacher.Zipcode <= zipCodeEnd) && (x.Name.Contains(search) || x.Tag.Any(y => y.Name.Contains(search))));
            searchResultCourse.ToList().ForEach(x => tagList.AddRange(x.Tag));
            var result = new ViewModelSearchResult
            {
                ListCourses = searchResultCourse.Take(ShowAmountOfCoursesSearch),
                ListTags = tagList.Distinct().OrderBy(x => x.Name).Take(ShowAmountOfTagsSearch),
                ListTagGroups = _db.TagGroupSet.OrderBy(x => x.Name)
            };
            return result;
        }

        internal ViewModelSearchResult GetCoursesByTagId(int id)
        {
            var tagList = new List<Tag>();
            var searchResultCourse = _db.CourseSet.Where(x => x.Active && x.Tag.Any(y => y.Id == id));
            searchResultCourse.ToList().ForEach(x => tagList.AddRange(x.Tag));
            var result = new ViewModelSearchResult
            {
                ListCourses = searchResultCourse.Take(ShowAmountOfCoursesSearch),
                ListTags = tagList.Distinct().OrderBy(x => x.Name).Take(ShowAmountOfTagsSearch),
                ListTagGroups = _db.TagGroupSet.OrderBy(x => x.Name)
            };
            return result;
        }

        internal IEnumerable<LocationGroup> GetAllLocationGroups()
        {
            return _db.LocationGroupSet.OrderBy(x => x.ZipcodeStart).ThenByDescending(x => x.ZipcodeEnd);
        }

        #endregion [Search]

        #region [CreateProfile]

        internal bool CheckZipCode(int zipCode)
        {
            return _db.LocationCitySet.Any(x => x.ZipcodeStart <= zipCode && zipCode <= x.ZipcodeEnd);
        }

        internal bool CheckProfileUsername(ViewModelProfile profile)
        {
            return !_db.PersonSet.Any(x => x.Username.Equals(profile.Username));
        }

        internal User CreateProfile(ViewModelProfile profile)
        {
            User user = null;

            var zipcode = Convert.ToInt16(profile.Zipcode);
            try
            {
                var person = new Person
                {
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    Address = profile.Address,
                    Zipcode = zipcode,
                    LocationCity = _db.LocationCitySet.FirstOrDefault(x => x.ZipcodeStart <= zipcode && x.ZipcodeEnd >= zipcode),
                    Phone = profile.Phone,
                    Email = profile.Email,
                    Username = profile.Username,
                    Password = profile.NewPassword,
                    //Image = "",
                    Active = true,
                    DateCreated = DateTime.Now

                };

                _db.PersonSet.Add(person);
                _db.SaveChanges();

                user = new User
                {
                    Id = person.Id,
                    Name = person.FirstName,
                    IsAdmin = false,
                    RememberMe = false,
                    UserName = person.Username
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }

            return user;
        }

        #endregion [CreateProfile]

        #region [Login]

        internal User UserLoginCheck(string userName, string userPassword)
        {
            User user = null;
            Person person = null;
            try
            {
                person = _db.PersonSet.FirstOrDefault(x => x.Username == userName && x.Password == userPassword && x.Active);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            if (person != null)
                user = new User() { Id = person.Id, Name = person.FirstName, UserName = person.Username };
            return user;
        }

        #endregion [Login]

    }
}