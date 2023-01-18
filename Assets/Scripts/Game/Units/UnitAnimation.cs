using UnityEngine;

namespace Split.Game.Units
{
    public class UnitAnimation : MonoBehaviour
    {
        private static readonly int IsAttack = Animator.StringToHash("IsAttack");
        private static readonly int IsDead = Animator.StringToHash("IsDead");

        [SerializeField] private Animator _animator;

        public void SetIsAttack(bool value)
        {
            _animator.SetBool(IsAttack, value);
        }

        public void SetIsDead()
        {
            _animator.SetTrigger(IsDead);
        }
    }
}