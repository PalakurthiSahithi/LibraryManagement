using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    [MetadataType(typeof(CategoryMetaData))]
    public partial class Category
    {
        public class CategoryMetaData
        {
            [DisplayName("Category Name")]

            public string catname { get; set; }

            [DisplayName("Status")]

            public string status { get; set; }
        }
    }
}