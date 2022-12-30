using Split.Infrastructure.GameController;
using Split.Infrastructure.GameOver;
using Split.Infrastructure.ServicesFolder.Npc;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Split.Game.EnemySettings
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Transform[] _targets;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private EnemyAnimation _animation;

        private INpcService _npcService;
        private EnemyDeath _enemyDeath;
        private IGameOverService _gameOverService;
        private IGameController _gameController;

        [Inject]
        public void Construct(INpcService npcService, IGameOverService gameOverService,IGameController gameController)
        {
            _npcService = npcService;
            _gameOverService = gameOverService;
            _gameController = gameController;
        }

        private void Start()
        {
            _enemyDeath = GetComponent<EnemyDeath>();
            _enemyDeath.OnDead += Die;
        }

        private void Update()
        {
            if (_gameController.IsGameInit)
                Move();
        }

        private void OnEnable()
        {
            _npcService.RegisterMovingObject(this);
        }

        private void Die()
        {
            _npcService.UnregisterObject(this);
            _gameOverService.IsGameOver = true;
            _enemyDeath.OnDead -= Die;
        }

        public void InitMove()
        {
            Move();
            StartMovementAnimation();
        }

        public void Move()
        {
            if (_gameOverService.IsGameOver)
                return;
            ChooseTarget();
        }

        public void StartMovementAnimation()
        {
            _animation.SetSpeedHorizontal(_agent.speed);
        }
        public void ChooseTarget()
        {
            float closestTargetDistance = float.MaxValue;
            NavMeshPath Path;
            NavMeshPath ShortestPath = null;

            for (int i = 0; i < _targets.Length; i++)
            {
                if (_targets[i] == null)
                {
                    continue;
                }

                Path = new NavMeshPath();

                if (NavMesh.CalculatePath(transform.position, _targets[i].position, _agent.areaMask, Path))
                {
                    float distance = Vector3.Distance(transform.position, Path.corners[0]);

                    for (int j = 1; j < Path.corners.Length; j++)
                    {
                        distance += Vector3.Distance(Path.corners[j - 1], Path.corners[j]);
                    }

                    if (distance < closestTargetDistance)
                    {
                        closestTargetDistance = distance;
                        ShortestPath = Path;
                    }
                }
            }

            if (ShortestPath != null)
            {
                _agent.SetPath(ShortestPath);
            }
        }
    }
}