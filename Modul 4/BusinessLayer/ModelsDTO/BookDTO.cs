using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ModelsDTO
{
    public class BookDTO
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AuthorDTO> Authors { get; set; }
        public ICollection<CategoryDTO> Categories { get; set; }
    }
}
