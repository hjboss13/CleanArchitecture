using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Domain.Models.Roma
{
    public class Category
    {
        private string _Descripcion;

        public short Id { get; set; }

        public string Description
        {
            get { return _Descripcion; }
            set { _Descripcion = value.Trim().ToLower(); }
        }

        public short CategoryId { get; set; }

        public string ImageLink1 { get; set; }
        public string ImageLink2 { get; set; }
        public string DescriptionEn { get; set; }
        public string ImageLink1En { get; set; }
        public string ImageLink2En { get; set; }
        public int Order { get; set; }
        public string Language { get; set; }
    }
}
