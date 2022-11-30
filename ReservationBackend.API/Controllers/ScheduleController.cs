using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReservationBackend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReservationBackend.API.Models;
namespace ReservationBackend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : ControllerBase
    {
      

       
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
          
            _scheduleService = scheduleService;
        }


        [HttpPost("AddSchedule")]
        public ActionResult AddSchedule([FromBody] Schedule schedule)
        {

            return Ok(_scheduleService.AddSchedule(schedule.ProviderId, schedule.StartTime, schedule.EndTime));
        }


        [HttpGet("ListFreeTimeSlots")]
        public ActionResult ListFreeTimeSlots()
        {

            return Ok(_scheduleService.ListFreeTimeSlots());
        }

        [HttpPut("ReserveTimeSlot/{scheduleid}")]
        public ActionResult ReserveTimeSlot(int scheduleid)
        {
            _scheduleService.ReserveTimeSlot(scheduleid);
            return Ok();
        }

        [HttpPut("ConfirmTimeSlot/{scheduleid}")]
        public ActionResult ConfirmTimeSlot(int scheduleid)
        {
            _scheduleService.ConfirmTimeSlot(scheduleid);
            return Ok();
        }
    }
}
