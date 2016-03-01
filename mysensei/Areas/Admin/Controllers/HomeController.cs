using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.WebControls.Expressions;
using mysensei.Areas.Admin.Models;
using mysensei.Areas.Admin.Models.ViewModels;
using mysensei.Models;
using Repository = mysensei.Areas.Admin.Models.Repository;

namespace mysensei.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository _repository = new Repository();
        private static int _thisPage = 1;
        private static int _thisTake = 20;
        private static string _thisSearchField = "";
        private static Stack<VisitedPage> _visitedPages = new Stack<VisitedPage>();

        public ActionResult Index()
        {
            GetUserFromCookie();
            return View();
        }

        #region [Person]       

        public ActionResult PersonList(ShowList<Person> showList, string cmd)
        {
            PushPage(this, 0, true);
            showList = GetShowList<Person>(showList, cmd);
            ModelState.Clear();
            return View(showList);
        }

        [HttpGet]
        public ActionResult PersonSite(int id)
        {
            if (id == 0)
                return Redirect("/Admin");
            PushPage(this, id);
            return View(_repository.GetPersonById(id));
        }

        [HttpPost]
        public ActionResult PersonSite(Person person, string command)
        {
            VisitedPage page;
            switch (command)
            {
                case "edit":
                    ViewBag.Edit = true;
                    ModelState.Clear();
                    break;
                case "cancel":
                    ViewBag.Edit = false;
                    break;
                case "delete":
                    _repository.DeletePerson(person);
                    page = PopPage();
                    return RedirectToAction(page.PageAction, "Home", new { id = page.PageId });
                case "save":
                    ViewBag.Edit = true;
                    if (ModelState.IsValid)
                    {
                        if (!_repository.CheckPersonUsername(person))
                        {
                            ModelState.AddModelError("Username", "Brugernavn er optaget");
                            break;
                        }
                        int zipcode;
                        if (!(int.TryParse(person.Zipcode.ToString(), out zipcode) && _repository.CheckZipCode(zipcode)))
                        {
                            ModelState.AddModelError("Zipcode", "Fejl i postnr");
                            break;
                        }
                        _repository.UpdatePerson(person);
                        ViewBag.Edit = false;
                    }

                    break;
                case "back":
                    page = PopPage();
                    return RedirectToAction(page.PageAction, "Home", new { id = page.PageId });
            }
            return View(_repository.GetPersonById(person.Id));
        }

        #endregion [Person]

        #region [Course]

        public ActionResult CourseList(ShowList<Course> showList, string cmd)
        {
            PushPage(this, 0, true);
            showList = GetShowList<Course>(showList, cmd);
            ModelState.Clear();
            return View(showList);
        }

        [HttpGet]
        public ActionResult CourseSite(int id)
        {
            if (id == 0)
                return Redirect("/Admin");
            PushPage(this, id);
            return View(_repository.GetCourseById(id));
        }

        [HttpPost]
        public ActionResult CourseSite(Course course, string command)
        {
            VisitedPage page;
            switch (command)
            {
                case "edit":
                    ViewBag.Edit = true;
                    ModelState.Clear();
                    break;
                case "cancel":
                    ViewBag.Edit = false;
                    break;
                case "delete":
                    _repository.DeleteCourse(course);
                    page = PopPage();
                    return RedirectToAction(page.PageAction, "Home", new { id = page.PageId });
                case "save":
                    ViewBag.Edit = true;
                    if (ModelState.IsValid)
                    {
                        _repository.UpdateCourse(course);
                        ViewBag.Edit = false;
                    }
                    break;
                case "back":
                    page = PopPage();
                    return RedirectToAction(page.PageAction, "Home", new { id = page.PageId });
            }
            return View(_repository.GetCourseById(course.Id));
        }

        [HttpGet]
        public ActionResult RemoveStudentFromCourse(int courseId, int personId)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("UserLogin", "Home");
            PushPage(this, courseId);
            _repository.RemoveStudentFromCourse(courseId, personId);
            var page = PopPage();
            return RedirectToAction(page.PageAction, "Home", new { id = page.PageId });
        }

        [HttpGet]
        public ActionResult RemoveTagFromCourse(int courseId, int tagId)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("UserLogin", "Home");
            PushPage(this, courseId);
            _repository.RemoveTagFromCourse(courseId, tagId);
            var page = PopPage();
            return RedirectToAction(page.PageAction, "Home", new { id = page.PageId });
        }

        #endregion [Course]

        #region [Tag]

        public ActionResult TagList(ShowList<Tag> showList, string cmd)
        {
            PushPage(this, 0, true);
            if (cmd == "Create")
                return RedirectToAction("TagSite", new { id = _repository.CreateTag().Id });
            showList = GetShowList<Tag>(showList, cmd);
            ModelState.Clear();
            return View(showList);
        }

        [HttpGet]
        public ActionResult TagSite(int id)
        {
            if (id == 0)
                return Redirect("/Admin");
            PushPage(this, id);
            var tag = _repository.GetTagById(id);
            var model = new TagViewModel
            {
                TagModel = tag,
                TagGroupToAdd = _repository.TagGroupToAdd(tag)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult TagSite(TagViewModel viewModel, string command)
        {
            VisitedPage page;
            switch (command)
            {
                case "edit":
                    ViewBag.Edit = true;
                    ModelState.Clear();
                    break;
                case "cancel":
                    ViewBag.Edit = false;
                    break;
                case "delete":
                    _repository.DeleteTag(viewModel.TagModel);
                    page = PopPage();
                    return RedirectToAction(page.PageAction, "Home", new { id = page.PageId });
                case "save":
                    ViewBag.Edit = true;
                    if (ModelState.IsValid)
                    {
                        _repository.UpdateTag(viewModel.TagModel);
                        ViewBag.Edit = false;
                    }
                    break;
                case "back":
                    page = PopPage();
                    return RedirectToAction(page.PageAction, "Home", new { id = page.PageId });
            }

            var tag = _repository.GetTagById(viewModel.TagModel.Id);
            var model = new TagViewModel
            {
                TagModel = tag,
                TagGroupToAdd = _repository.TagGroupToAdd(tag)
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult RemoveTagGroupFromtag(int tagId, int tagGroupId)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("UserLogin", "Home");
            PushPage(this, tagId);
            _repository.RemoveTagGroupFromTag(tagId, tagGroupId);
            var page = PopPage();
            return RedirectToAction(page.PageAction, "Home", new { id = page.PageId });
        }

        [HttpGet]
        public ActionResult AddTagGroupToTag(int tagId, int tagGroupId)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("UserLogin", "Home");
            PushPage(this, tagId);
            _repository.AddTagGroupToTag(tagId, tagGroupId);
            var page = PopPage();
            return RedirectToAction(page.PageAction, "Home", new { id = page.PageId });
        }

        #endregion [Tag]

        #region [LocationsGroup]

        public ActionResult LocationGroupList(ShowList<LocationGroup> showList, string cmd)
        {
            PushPage(this, 0, true);
            if (cmd == "Create")
                return RedirectToAction("LocationGroupSite", new { id = _repository.CreateLocationGroup().Id });
            showList = GetShowList<LocationGroup>(showList, cmd);
            ModelState.Clear();
            return View(showList);
        }

        [HttpGet]
        public ActionResult LocationGroupSite(int id)
        {
            PushPage(this, id);
            return View(_repository.GetLocationGroupById(id));
        }

        [HttpPost]
        public ActionResult LocationGroupSite(LocationGroup locationGroup, string command)
        {
            VisitedPage page;
            switch (command)
            {
                case "edit":
                    ViewBag.Edit = true;
                    ModelState.Clear();
                    break;
                case "cancel":
                    ViewBag.Edit = false;
                    break;
                case "delete":
                    _repository.DeleteLocationGroup(locationGroup);
                    page = PopPage();
                    return RedirectToAction(page.PageAction, "Home", new { id = page.PageId });
                case "save":
                    ViewBag.Edit = true;
                    if (ModelState.IsValid)
                    {
                        _repository.UpdateLocationGroup(locationGroup);
                        ViewBag.Edit = false;
                    }
                    break;
                case "back":
                    page = PopPage();
                    return RedirectToAction(page.PageAction, "Home", new { id = page.PageId });
            }
            return View(_repository.GetLocationGroupById(locationGroup.Id));
        }

        #endregion [LocationsGroup]

        #region [UserLogin]

        [HttpGet]
        public ActionResult UserLogin()
        {
            return View(new UserLoginModel());
        }

        [HttpPost]
        public ActionResult UserLogin(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _repository.UserLoginCheck(model.UserName, model.UserPassword);
                if (user != null)
                {
                    var serializer = new JavaScriptSerializer();
                    var userData = serializer.Serialize(user);
                    var authTicket = new FormsAuthenticationTicket(
                        1,
                        model.UserName,
                        DateTime.Now,
                        DateTime.Now.AddMonths(1),
                        model.RememberMe, // persistant
                        userData);
                    var encTicket = FormsAuthentication.Encrypt(authTicket);
                    var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    if (model.RememberMe) faCookie.Expires = DateTime.Now.AddYears(10);
                    Response.Cookies.Add(faCookie);

                    return Redirect("/Admin");
                }
            }
            TempData["Status"] = "Forkert brugernavn eller password";
            return View(model);
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
            if (!user.IsAdmin)
            {
                Session.Clear();
                FormsAuthentication.SignOut();
                return null;
            }
            return user;
        }


        [HttpGet]
        public ActionResult UserLogout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return Redirect("/Admin");
        }
        #endregion [Login]

        #region [Methods:Navigation]

        private static void PushPage(HomeController controller, int id, bool init = false)
        {
            if (init)
            {
                _visitedPages.Clear();
                _visitedPages.Push(new VisitedPage("root", 0));
            }
            var actionName = controller.ControllerContext.RouteData.Values["action"].ToString();
            if (!_visitedPages.Peek().PageAction.Equals(actionName))
                _visitedPages.Push((new VisitedPage(actionName, id)));
        }

        private static VisitedPage PopPage()
        {
            _visitedPages.Pop();
            return _visitedPages.Pop();
        }

        private ShowList<T> GetShowList<T>(ShowList<T> showList, string cmd)
        {
            switch (cmd)
            {
                case "root":
                    _thisPage = 1;
                    _thisTake = 20;
                    _thisSearchField = "";
                    break;
                case "Next":
                    _thisPage += 1;
                    break;
                case "Previous":
                    _thisPage += -1;
                    break;
                case "Search":

                    _thisSearchField = showList.SearchField==null ? "" : showList.SearchField;
                    break;
            }

            _thisTake = showList.Take == 0 ? _thisTake : showList.Take;

            IQueryable<Person> searchCollectionPerson = null;
            IQueryable<Course> searchCollectionCourse = null;
            IQueryable<Tag> searchCollectionTag = null;
            IQueryable<LocationGroup> searchLocationGroup = null;
            int count = 0;
            if (typeof(T) == typeof(Person))
            {
                searchCollectionPerson = _repository.SearchPersons(_thisSearchField);
                count = searchCollectionPerson.Count();

            }
            else if (typeof(T) == typeof(Course))
            {
                searchCollectionCourse = _repository.SearchCourses(_thisSearchField);
                count = searchCollectionCourse.Count();
            }
            else if (typeof(T) == typeof(Tag))
            {
                searchCollectionTag = _repository.SearchTags(_thisSearchField);
                count = searchCollectionTag.Count();
            }
            else if (typeof(T) == typeof(LocationGroup))
            {
                searchLocationGroup = _repository.SearchLocationGroups(_thisSearchField);
                count = searchLocationGroup.Count();
            }

            var pagesAll = ((count - 1) / _thisTake) + 1;
            if (_thisPage < 1)
                _thisPage = 1;
            else if (_thisPage > pagesAll)
                _thisPage = pagesAll;
            var skip = (_thisPage - 1) * _thisTake;

            IEnumerable<T> listGeneric = null;
            if (typeof(T) == typeof(Person))
            {
                listGeneric = (IEnumerable<T>)
                    searchCollectionPerson.OrderBy(x => x.FirstName).Skip(skip).Take(_thisTake);
            }
            else if (typeof(T) == typeof(Course))
            {
                listGeneric = (IEnumerable<T>)
                    searchCollectionCourse.OrderBy(x => x.Name).Skip(skip).Take(_thisTake);
            }
            else if (typeof(T) == typeof(Tag))
            {
                listGeneric = (IEnumerable<T>)
                    searchCollectionTag.OrderBy(x => x.Name).Skip(skip).Take(_thisTake);
            }
            else if (typeof(T) == typeof(LocationGroup))
            {
                listGeneric = (IEnumerable<T>)
                    searchLocationGroup.OrderBy(x => x.ZipcodeStart).ThenByDescending(x=>x.ZipcodeEnd).Skip(skip).Take(_thisTake);
            }
            ModelState.Clear();
            return new ShowList<T>
            {
                PageAll = pagesAll,
                PageThis = _thisPage,
                RecordCount = count,
                Take = _thisTake,
                ListGeneric = listGeneric,
                SearchField = _thisSearchField,
            };

        }

        #endregion [Methods:Navigation]

    }
}