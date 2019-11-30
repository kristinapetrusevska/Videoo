using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videoo.Models;

namespace Videoo.ViewModels
{
    public class CustomerViewModel
    {
        public Customer customer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}