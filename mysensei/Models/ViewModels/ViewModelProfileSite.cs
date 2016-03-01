using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mysensei.Models.ViewModels
{
    public class ViewModelProfileSite
    {

        public Person Person { get; set; }

        public bool IsTeacher  { get; set; }
        public bool IsStudent { get; set; }
        public bool IsNewChatMail { get; set; }
        public string MyProfileMenuChoosen { get; set; }

        public int MsgChatRoomId { get; set; }
        public string MsgMessage { get; set; }

        public IEnumerable<Course> ListStudentCourses { get; set; }    
        public IEnumerable<Course> ListTeacherCourses { get; set; }
        public IEnumerable<ChatRoom> ListChatRooms { get; set; }


    }
}