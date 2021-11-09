using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Control
{
    public interface IListCv
    {
        Task<List<Cv>> SearcheCv(string value);
    }
}
