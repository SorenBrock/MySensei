
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace mysensei.Models
{

using System;
    using System.Collections.Generic;
    
public partial class Person
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Person()
    {

        this.Active = true;

        this.TeacherCourse = new HashSet<Course>();

        this.StudentCourse = new HashSet<Course>();

        this.Rating = new HashSet<Rating>();

        this.Chat = new HashSet<Chat>();

        this.ChatRoom = new HashSet<ChatRoom>();

        this.ChatRoom1 = new HashSet<ChatRoom>();

        this.LogChatRead = new HashSet<LogChatRead>();

    }


    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Address { get; set; }

    public Nullable<short> Zipcode { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public string Description { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Image { get; set; }

    public bool Active { get; set; }

    public Nullable<System.DateTime> DateCreated { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Course> TeacherCourse { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Course> StudentCourse { get; set; }

    public virtual LocationCity LocationCity { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Rating> Rating { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Chat> Chat { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<ChatRoom> ChatRoom { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<ChatRoom> ChatRoom1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<LogChatRead> LogChatRead { get; set; }

}

}
