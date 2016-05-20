using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MarsRover.Contracts;
using MarsRover.Web.Models.MarsRover;

namespace MarsRover.Web.Controllers
{
    public class MarsRoverSquadController : Controller
    {
        private readonly ICommandParser _commandParser;
        private readonly ILocationParser _locationParser;
        private readonly IRoverFactory _roverFactory;
        private readonly ISurfaceParser _surfaceParser;

        public MarsRoverSquadController(IRoverFactory roverFactory, ISurfaceParser surfaceParser, ILocationParser locationParser, ICommandParser commandParser)
        {
            if (roverFactory == null) throw new ArgumentNullException(nameof(roverFactory));
            if (surfaceParser == null) throw new ArgumentNullException(nameof(surfaceParser));
            if (locationParser == null) throw new ArgumentNullException(nameof(locationParser));
            if (commandParser == null) throw new ArgumentNullException(nameof(commandParser));

            _roverFactory = roverFactory;
            _surfaceParser = surfaceParser;
            _locationParser = locationParser;
            _commandParser = commandParser;
        }

        [HttpGet]
        public ActionResult Explore()
        {
            var model = new MarsRoverSquadModel();
            model.Rovers = new List<MarsRoverModel>();
            model.Rovers.Add(new MarsRoverModel());
            model.Rovers.Add(new MarsRoverModel());

            return View(model);
        }

        [HttpPost]
        public ActionResult Explore(MarsRoverSquadModel model)
        {
            if (model.Rovers == null)
            {
                model.Rovers = new List<MarsRoverModel>();
            }

             if (!ModelState.IsValid)
            {
                return View(model);
            }

            var surface = _surfaceParser.Parse(model.Plateau.ToString());

            var roverModelList = new List<MarsRoverModel>();
            foreach (var roverModel in model.Rovers)
            {
                var location = _locationParser.Parse(roverModel.InputLocation.ToString());
                var commands = _commandParser.ParseCommands(roverModel.Commands);

                var rover = _roverFactory.CreateRover(surface, location);
                foreach (var command in commands)
                {
                    rover.Execute(command);
                }

                roverModel.OutputLocation.X = rover.Location.X;
                roverModel.OutputLocation.Y = rover.Location.Y;
                roverModel.OutputLocation.Orientation = rover.Location.Orientation;
                roverModelList.Add(roverModel);
            }
            model.Rovers = roverModelList;

            return View(model);
        }
    }
}