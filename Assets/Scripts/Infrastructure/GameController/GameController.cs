using Split.Game.Units.SelectedFolder;
using Split.Infrastructure.ServicesFolder.Npc;

namespace Split.Infrastructure.GameController
{
    public class GameController : IGameController
    {
        private INpcService _npcService;
        private ITimerService _timerService;
        private SelectedService _selectedService;
        public bool IsGameInit { get; set; }

        public GameController(INpcService npcService, ITimerService timerService, SelectedService selectedService)
        {
            _npcService = npcService;
            _timerService = timerService;
            _selectedService = selectedService;
        }

        public async void Init()
        {
            await _timerService.Timer();
            _npcService.BeginMove();
            IsGameInit = true;
            _selectedService.LossOfControl();
        }
        
        public void Dispose()
        {
        }
    }
}