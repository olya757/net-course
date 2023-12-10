using AutoMapper;
using FitnessClub.BL.Trainers;
using FitnessClub.BL.Trainers.Entities;
using FitnessClub.Service.Controllers.Entities;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace FitnessClub.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class TrainersController : ControllerBase
{
    //REST Api
    //get all trainers GET: trainers/
    //get trainer details GET: trainers/{id}
    //create trainer POST: trainers + body 
    //edit trainer info PUT: trainers/{id} + body (all data)
    //fire trainer DELETE: trainers/{id}
    //not a REST Api:
    //GET: trainers/get-trainer-details
    //POST: trainers/save-trainer
    private readonly ITrainersProvider _trainersProvider;
    private readonly ITrainersManager _trainersManager;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public TrainersController(ITrainersProvider trainersProvider, ITrainersManager trainersManager, IMapper mapper,
        ILogger logger)
    {
        _trainersManager = trainersManager;
        _trainersProvider = trainersProvider;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet] //trainers/
    public IActionResult GetAllTrainers()
    {
        var trainers = _trainersProvider.GetTrainers();
        return Ok(new TrainersListResponse()
        {
            Trainers = trainers.ToList()
        });
    }

    [HttpGet]
    [Route("filter")] //trainers/filter?filter.sex=1&filter.age=20
    public IActionResult GetFilteredTrainers([FromQuery] TrainersFilter filter)
    {
        var trainers = _trainersProvider.GetTrainers(_mapper.Map<TrainersModelFilter>(filter));
        return Ok(new TrainersListResponse()
        {
            Trainers = trainers.ToList()
        });
    }

    [HttpGet]
    [Route("{id}")] //trainers/{id}
    public IActionResult GetTrainerInfo([FromRoute] Guid id)
    {
        try
        {
            var trainer = _trainersProvider.GetTrainerInfo(id);
            return Ok(trainer);
        }
        catch (ArgumentException ex)
        {
            _logger.Error(ex.ToString()); //stack trace + message
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateTrainer([FromBody] CreateTrainerRequest request) //automatic validation
    {
        try
        {
            var trainer = _trainersManager.CreateTrainer(_mapper.Map<CreateTrainerModel>(request));
            return Ok(trainer);
        }
        catch (ArgumentException ex)
        {
            _logger.Error(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateTrainerInfo([FromRoute] Guid id, UpdateTrainerRequest request)
    {
        //validator for request
        //UpdateTrainer(_mapper)
        //put into exception block
        //return TrainerModel
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteTrainer([FromRoute] Guid id)
    {
        //try catch
        //delete trainer
        return Ok();
    }
}