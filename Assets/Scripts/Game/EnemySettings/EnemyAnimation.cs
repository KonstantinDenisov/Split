using Cinemachine;
using UnityEngine;

namespace Split.Game.EnemySettings
{
	public class EnemyAnimation : MonoBehaviour
	{
		[SerializeField] private Animator _animation;
		[SerializeField] private EnemyMovement _enemyMovement;
		
		private static readonly int Speed = Animator.StringToHash("Speed");
		
		public void SetSpeedHorizontal(float value)
		{
			_animation.SetFloat(Speed,value);
		}
	}
}
        
 