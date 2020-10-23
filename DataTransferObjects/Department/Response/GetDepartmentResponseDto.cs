using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.Department.Response
{
    public class GetDepartmentResponseDto
    {
        public int Id { get; set; }

        public string MedicalDepartment { get; set; }
    }
}
