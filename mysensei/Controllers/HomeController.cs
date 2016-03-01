using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using mysensei.Models;
using mysensei.Models.ViewModels;


namespace mysensei.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository _repository = new Repository();
        private static int _thisPage = 1;
        private const int ThisTake = 9;
        private static string _thisSearchField = "";

        public ActionResult Index(string message = "")
        {
           GetUserFromCookie();
            ViewBag.message = message;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        #region [Course]

        [HttpGet]
        public ActionResult CreateCourse()
        {
            var user = GetUserFromCookie();
            if (user == null)
                return Redirect("/Home");

            return View(new ViewModelCreateCourse
            {
                PersonId = user.Id
            });
        }

        [HttpPost]
        public ActionResult CreateCourse(ViewModelCreateCourse model)
        {
            if (!ModelState.IsValid) return View(model);
            var course = _repository.CreateCourse(model.PersonId, model.Name, model.Description);
            return RedirectToAction("/Course", new { id = course.Id });
        }



        [HttpGet]
        public ActionResult Course(int id = 0, string cmd = "")
        {
            var user = GetUserFromCookie();
            var course = _repository.GetCourseById(id);
            if (id == 0 || course == null)
                return Redirect("/Home");

            switch (cmd)
            {
                case "assign":
                    _repository.AssignStudentCourse(user.Id, course.Id);
                    break;

                case "unassign":
                    _repository.UnassignStudentCourse(user.Id, course.Id);
                    break;
                case "delete":
                    _repository.DeactivateCourse(course.Id, user.Id);
                    return RedirectToAction("Index", "Home", new { message = "Kurset er slettet !" });
                case "sendmessage":
          
                    return RedirectToAction("Index", "Home", new { message = "Beskeden er sendt !" });
            }

            if (user != null)
            {
                ViewBag.PersonId = user.Id;
                ViewBag.IsSensei = course.Teacher.Id == user.Id;
            }

            ViewBag.LocationGroupName = _repository.GetLastLocationGroupByPerson(course.Teacher).Name;

            return View(course);
        }


        [HttpPost]
        public ActionResult Course(Course course, string message = "")
        {
            if (!ModelState.IsValid)

                return View(course);
            var user = GetUserFromCookie();
            _repository.SendMessage(course.Id, user.Id, message);


            return RedirectToAction("Course", new { cmd = "sendmessage" });

        }

        #endregion [Course]

        #region [Discover]

        public ActionResult Discover()
        {
            var modelDiscover = new ViewModelDiscover
            {
                ListCoursesHighRating = _repository.GetListCoursesHighRating(),
                ListCoursesNew = _repository.GetListCoursesNew(),
                ListCoursesPrivate = _repository.GetListCoursesPrivateByPersonId(GetUserFromCookie())
            };
            return View(modelDiscover);
        }

        #endregion [Discover]

        #region [Profile]

        [HttpGet]
        public ActionResult MyProfile(string cmd = "", int chatRoomId = 0)
        {
            var user = GetUserFromCookie();
            if (user == null) { 
                Logout();
                return Redirect("/Home");
            }
            var person = _repository.GetPersonById(user.Id);
            if (person == null)
                return Redirect("/Home");

            return View(new ViewModelProfileSite
            {
                Person = person,
                IsTeacher = _repository.IsPersonTeacherById(person.Id),
                IsStudent = _repository.IsPersonStudentById(person.Id),
                ListChatRooms = _repository.GetChatRoomsByPersonId(person.Id).
                    OrderByDescending(x => x.Chat.Where(chat => chat.PersonId != person.Id).
                    OrderByDescending(y => y.DateCreated).First().DateCreated),
                ListStudentCourses = _repository.GetStudentCoursesByPersonId(person.Id),
                ListTeacherCourses = _repository.GetTeacherCoursesByPersonId(person.Id),
                IsNewChatMail = _repository.IsNewChatMailByPersonId(person.Id),
                MsgChatRoomId = chatRoomId
            });
        }

        [HttpPost]
        public ActionResult MyProfileSendMessage(ViewModelProfileSite model)
        {
            if (model == null)
                return Redirect("/Home");
            var strMessage = string.IsNullOrEmpty(model.MsgMessage) ? "" : model.MsgMessage;
            if (strMessage != "")
                _repository.AddChatToChatroom(model.Person.Id, model.MsgChatRoomId, strMessage);

            return RedirectToAction("MyProfile", new { chatRoomId = model.MsgChatRoomId });
        }

        [HttpGet]
        public ActionResult CreateProfile()
        {
            return View(new ViewModelProfile());
        }

        [HttpPost]
        public ActionResult CreateProfile(ViewModelProfile modelProfile)
        {
            var contentIsValid = true;
            int zipcode;
            if (modelProfile.Zipcode != null && !(int.TryParse(modelProfile.Zipcode.ToString(), out zipcode) && _repository.CheckZipCode(zipcode)))
            {
                ModelState.AddModelError("Zipcode", "Postnummeret er ikke gyldigt");
                contentIsValid = false;
            }

            if (!ModelState.IsValid) return View(modelProfile);

            if (!_repository.CheckProfileUsername(modelProfile))
            {
                ModelState.AddModelError("Username", "Brugernavnet er desværre optaget");
                contentIsValid = false;
            }
            if (!modelProfile.NewPassword.Equals(modelProfile.ConfirmPassword))
            {
                ModelState.AddModelError("ConfirmPassword", "Password mathcher ikke, genindtast venligst password");
                contentIsValid = false;
            }

            if (!contentIsValid) return View(modelProfile);

            var user = _repository.CreateProfile(modelProfile);
            SetCookieAndLoginUser(user);
            return Redirect("MyProfile");
        }

        #endregion [Profile]

        #region [Search]

        public ActionResult Search(ViewModelSearch modelSearch, string cmd)
        {
            var root = false;
            switch (cmd)
            {
                case "Next":
                    _thisPage += 1;
                    break;
                case "Previous":
                    _thisPage += -1;
                    break;
                case "root":
                    root = true;
                    break;
            }
            _thisSearchField = modelSearch.SearchField;

            var searchCollection = _repository.SearchCourses(_thisSearchField, modelSearch.LocationGroupId);
            var count = searchCollection.ListCourses.Count();

            var pagesAll = ((count - 1) / ThisTake) + 1;
            if (_thisPage < 1)
                _thisPage = 1;
            else if (_thisPage > pagesAll)
                _thisPage = pagesAll;
            var skip = (_thisPage - 1) * ThisTake;

            return View(new ViewModelSearch
            {
                PageAll = pagesAll,
                PageThis = _thisPage,
                RecordCount = count,
                Take = ThisTake,
                ListCourses = searchCollection.ListCourses.OrderBy(x => x.Name).Skip(skip).Take(ThisTake),
                ListTags = searchCollection.ListTags,
                SearchField = _thisSearchField,
                ListTagGroups = searchCollection.ListTagGroups,
                ListLocationGroups = _repository.GetAllLocationGroups(),
                Root = root
            });
        }

        [HttpGet]
        public ActionResult SearchByTagId(int tagId)
        {
            if (tagId == 0)
                return Redirect("/Home");
            _thisPage = 1;
            _thisSearchField = "";

            var searchCollection = _repository.GetCoursesByTagId(tagId);
            var count = searchCollection.ListCourses.Count();
            var pagesAll = ((count - 1) / ThisTake) + 1;

            return View("Search", new ViewModelSearch
            {
                PageAll = pagesAll,
                PageThis = _thisPage,
                RecordCount = count,
                Take = ThisTake,
                ListCourses = searchCollection.ListCourses.OrderBy(x => x.Name).Skip(0).Take(ThisTake),
                ListTags = searchCollection.ListTags,
                SearchField = _thisSearchField,
                ListTagGroups = searchCollection.ListTagGroups,
                ListLocationGroups = _repository.GetAllLocationGroups(),
                Root = false
            });
        }

        #endregion [Search]

        #region [Login]

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ViewModelLogin modelLogin)
        {
            if (ModelState.IsValid)
            {
                var user = _repository.UserLoginCheck(modelLogin.UserName, modelLogin.UserPassword);
                if (user != null)
                {
                    user.RememberMe = modelLogin.RememberMe;
                    SetCookieAndLoginUser(user);
                    return Redirect("/Home");
                }
                else
                {
                    TempData["Status"] = "Forkert brugernavn eller password";
                }
            }

            return View(modelLogin);
        }

        private void SetCookieAndLoginUser(User user)
        {
            var serializer = new JavaScriptSerializer();
            var userData = serializer.Serialize(user);
            var authTicket = new FormsAuthenticationTicket(
                1,
                user.UserName,
                DateTime.Now,
                DateTime.Now.AddMonths(1),
                user.RememberMe, // persistant
                userData);
            var encTicket = FormsAuthentication.Encrypt(authTicket);
            var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            if (user.RememberMe) faCookie.Expires = DateTime.Now.AddYears(10);
            Response.Cookies.Add(faCookie);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return Redirect("/Home");
        }

        private User GetUserFromCookie()
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
                return null;
            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
            if (ticket == null) return null;
            var serializer = new JavaScriptSerializer();
            var user = serializer.Deserialize<User>(ticket.UserData);
            if (user.IsAdmin)
            {
                Session.Clear();
                FormsAuthentication.SignOut();
                return null;
            }
            return user;
        }

        #endregion [Login]

    }
}