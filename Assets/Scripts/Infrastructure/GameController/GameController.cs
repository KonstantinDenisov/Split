using Cysharp.Threading.Tasks;
using Split.Infrastructure.ServicesFolder.Npc;

namespace Split.Infrastructure.GameController
{
    public class GameController : IGameController
    {
        private INpcService _npcService;
        private ITimerService _timerService;
        public bool IsGameInit { get; set; }

        public GameController(INpcService npcService, ITimerService timerService)
        {
            _npcService = npcService;
            _timerService = timerService;
        }

        public async void Init()
        {
            await _timerService.Timer();
            _npcService.BeginMove();
            IsGameInit = true;
        }
        
        
        public void Dispose()
        {
        }
    }
}