
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
    
public partial class ChatRoom
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public ChatRoom()
    {

        this.Active = true;

        this.Person = new HashSet<Person>();

        this.Chat = new HashSet<Chat>();

    }


    public int Id { get; set; }

    public string Name { get; set; }

    public int PersonId { get; set; }

    public bool Active { get; set; }

    public System.DateTime DateCreated { get; set; }



    public virtual Course Course { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Person> Person { get; set; }

    public virtual Person OwnerPerson { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Chat> Chat { get; set; }

}

}
