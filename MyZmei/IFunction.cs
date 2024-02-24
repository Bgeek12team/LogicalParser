using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyZmei
{
    public interface IFunction
    {
        public string StringValue { get; }
        public string CalculateResult(string exp);

        public string TrimSelf(Expression tokens);
    }
}
