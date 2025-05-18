using AutoMapper;
using FastFood.Application.DTOs;
using FastFood.Application.Interfaces.Services;
using FastFood.Application.Validators;
using FastFood.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpPost]
        // [Route("/CreateClient")]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientRequest request)
        {
            var validationResult = new CreateClientRequestValidator().Validate(request);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var client = _mapper.Map<Client>(request);
            await _clientService.AddClient(client);

            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<Client>> Get()
        {
            return await _clientService.GetAllClients();
        }


    }
}
