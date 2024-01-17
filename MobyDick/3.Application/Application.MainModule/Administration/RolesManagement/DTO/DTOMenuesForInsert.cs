using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement.DTO
{
    public class DTOMenuesForInsert
    {
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [StringLength(50,ErrorMessage="El nombre no puede exceder los 50 caracteres")]
        public string Name { get; set; }
        public DTOMenuesForInsert ParentMenu { get; set; }
        public int? IDParentMenu { get; set; }
      //  [Required(ErrorMessage = "Debe ingresar una descripción")]
        public string Description { get; set; }

        //Datos de la vista
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}