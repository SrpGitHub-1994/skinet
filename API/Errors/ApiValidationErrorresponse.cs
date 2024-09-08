using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiValidationErrorresponse : ApiResponse
    {
        public ApiValidationErrorresponse() : base(StatusCodes.Status400BadRequest)
        {

        }

        public IEnumerable<string> Errors { get; set; }
    }
}