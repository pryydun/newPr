﻿using EM.CoreBusiness;
using EM_UseCases.Events.interfaces;
using EM_UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_UseCases.Events
{
    public class ViewEventsByNameUseCase : IViewEventsByNameUseCase
    {
        private readonly IEventRepository _eventRepository;

        public ViewEventsByNameUseCase(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<Event>> ExecuteAsync()
        {

                return await _eventRepository.GetAllEventsAsync();
            

             
        }
    }
}
