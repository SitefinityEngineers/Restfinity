﻿using System;
using System.Collections.Generic;
using System.Linq;
using Restfinity.Models.Content;
using Telerik.Sitefinity.Events.Model;
using Telerik.Sitefinity.Modules.Events;
using Telerik.Sitefinity.SitefinityExceptions;

namespace Restfinity.Controllers
{
    public class EventsController : BaseApiController<Event, EventRestModel, EventsManager>
    {
        public override EventsManager GetManager()
        {
            return EventsManager.GetManager();
        }

        public override IEnumerable<Event> GetAll()
        {
            return this.GetManager().GetEvents();
        }

        public override Event GetOne(Guid id)
        {
            try
            {
                return this.GetManager().GetEvent(id);
            }
            catch (ItemNotFoundException)
            {
                return null;
            }
        }

        public override EventRestModel ConvertToRestModel(Event item)
        {
            EventRestModel restModel = new EventRestModel()
            {
                Id = item.Id,
                Title = item.Title.Value,
                Description = item.Description,
                Status = item.Status,
                Url = item.UrlName.Value,
                EventStartDate = item.EventStart,
                EventEndDate = item.EventEnd
            };
            return restModel;
        }
    }
}
