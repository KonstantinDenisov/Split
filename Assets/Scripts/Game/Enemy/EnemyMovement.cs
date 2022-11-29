using System;
using Split.Infrastructure;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;

namespace Split.Game.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Transform[] _targets;
        [SerializeField] private  NavMeshAgent _agent;
        [SerializeField] private float _timeDelay = 6f;
        
        private void ChooseTarget()
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

        public bool Move(bool isActive)
        {
            if (isActive)
                ChooseTarget();

            return isActive;
        }
        private void OnGUI()
        {
            if (GUI.Button(new Rect(20, 20, 300, 50), "Move To Target"))
            {
                ChooseTarget();
            }
        }
        
    }
}