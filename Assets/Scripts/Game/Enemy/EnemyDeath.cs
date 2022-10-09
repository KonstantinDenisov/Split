using System;
using UnityEngine;

namespace Split.Game.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        public event Action<EnemyDeath> OnHappened;
       
    }
}