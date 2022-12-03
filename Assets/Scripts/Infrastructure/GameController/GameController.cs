using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Split.Infrastructure.ServicesFolder.Npc;

namespace Split.Infrastructure.GameController
{
    public class GameController : IGameController
    {
        private INpcService _npcService;
        private ITimerService _timerService;

        public GameController(INpcService npcService, ITimerService timerService)
        {
            _npcService = npcService;
            _timerService = timerService;
        }

        public async void Init()
        {
            await _timerService.Timer();
           _npcService.BeginMove();
        }

        private void StartGame(UniTask startTimer)
        {
        }

        public void Dispose()
        {
        }
        

    }
}