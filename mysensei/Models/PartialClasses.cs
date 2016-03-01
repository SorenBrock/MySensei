using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mysensei.Models
{
    [MetadataType(typeof(PersonMetadata))]
    public partial class Person
    {
    }

    [MetadataType(typeof(LocationGroupMetadata))]
    public partial class LocationGroup
    {
    }


}