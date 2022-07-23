using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interface
{
   public interface IStudentService
    {
        Student Create(int groupId, Student student);
    }
}
