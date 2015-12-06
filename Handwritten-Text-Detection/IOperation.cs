using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Handwritten_Text_Detection_Library
{
    public interface IOperation
    {
        Image Apply(Image input);
    }
}
