using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Schema;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionController : ControllerBase
    {

        private readonly IRepository<Subscription> _subscriptionRepository;


        public SubscriptionController(IRepository<Subscription> subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }


        [HttpGet("get")]
        public IEnumerable<Subscription> Get()
        {
            return _subscriptionRepository.GetAll();
        }

        [HttpGet("GetAll")]
        public IEnumerable<SubscriptionDto> GetAll()
        {
            return _subscriptionRepository.GetAll().Select(subscription => new SubscriptionDto(subscription.Type, subscription.Price));
        }

        [HttpPost("add")]
        public void Add(SubscriptionDto subscriptionDto)
        {
            _subscriptionRepository.Add(new Subscription(subscriptionDto.Type,subscriptionDto.Price));
            _subscriptionRepository.SaveChanges();
        }

        [HttpPut("update")]
        public ObjectResult Update(Guid subscipritonId, SubscriptionDto subscription)
        {
            var subscriptionFromDb = _subscriptionRepository.GetById(subscipritonId);
            if(subscriptionFromDb == null) {
                return NotFound("Subscription not found");
            }
            subscriptionFromDb.Type = subscription.Type;
            subscriptionFromDb.Price = subscription.Price;
            _subscriptionRepository.SaveChanges();
            return Ok("Subscription updated");
        }



        [HttpDelete("delete")]
        public ObjectResult Delete(Guid subscriptionId)
        {
            var subscriptionFromDb = _subscriptionRepository.GetById(subscriptionId);
            if (subscriptionFromDb == null)
            {
                return NotFound("Subscription not found");
            }
            _subscriptionRepository.Remove(subscriptionFromDb);
            _subscriptionRepository.SaveChanges();
            return Ok("Subscription deleted");
        }
    }
}
