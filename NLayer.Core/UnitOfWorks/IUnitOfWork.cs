using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.UnitOfWorks 
{
    public interface IUnitOfWork // design pattern
    {

        Task CommitAsync(); // bunları implemante edince db context in savecahnge ve savechangeasyn methodları çagırılmış olacak.
        void Commit();
    }
}
