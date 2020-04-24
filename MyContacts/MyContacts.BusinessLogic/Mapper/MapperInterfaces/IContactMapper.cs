﻿using System.Threading.Tasks;
using MyContacts.BusinessLogic.ViewModels;
using MyContacts.Entities.Models;

namespace MyContacts.BusinessLogic.Mapper.MapperInterfaces
{
    public interface IContactMapper
    {
        ContactViewModel MapContactToContactViewModel(Contact entity);

        //VcfData MapContactToVcf(Contact entity);
    }
}