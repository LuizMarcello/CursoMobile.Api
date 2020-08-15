using System;
using System.Collections.Generic;
using System.Text;
using CursoMobile.Api.Domain;
using CursoMobile.Api.Domain.Enums;

namespace CursoMobile.Api.Domain.DTO
{
    public class ContactDto
    {
        public ContactTypeEnum ContactType { get; set; }

        public string Description { get; set; }
    }
}

