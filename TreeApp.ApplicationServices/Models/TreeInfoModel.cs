using System;

namespace TreeApp.ApplicationServices.Models
{
    public sealed class TreeInfoModel
    {
        public Guid Id { get; set; }

        public TreeHeight Height { get; set; }

        public TreeAge Age { get; set; }
    }
}
