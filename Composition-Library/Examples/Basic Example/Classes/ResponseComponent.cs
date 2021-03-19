using CompositionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Basic_Example
{
    public class ResponseComponent : IComponent
    {
        private string Response;

        public ResponseComponent(string _response)
        {
            Response = _response;
        }

        public string GetResponse()
        {
            return Response;
        }
    }
}
