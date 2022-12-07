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

        private INpcService _npcService;

        [Inject]
        public void Construct(INpcService npcService)
        {
            _npcService = npcService;
        }

        private void Start()
        {
            _npcService.RegisterMovingObject(this);
        }

        private void OnDestroy()
        {
            _npcService.UnregisterObject(this);
        }

        public void StartMove()
        {
            ChooseTarget();
        }

        public void ChooseTarget()
        {
            float closestTargetDistance = float.MaxValue;
            NavMeshPath Path = null;
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