using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    [MetadataType(typeof(MemberMetaData))]
    public partial class Member
    {
        public class MemberMetaData
        {
            [DisplayName("Member Name")]
            public string name { get; set; }

            [DisplayName("Address")]
            public string address { get; set; }

            [DisplayName("Phone")]
            public string phone { get; set; }
        }
        
    }
}