using UnityEngine;

namespace Split.Game.Enemy
{
    public abstract class EnemyBehaviour : MonoBehaviour
    {
        public bool IsActive { get; private set; }

        private void Update()
        {
            OnUpdate();

            if (IsActive)
                OnActiveUpdate();
        }

        public virtual void Activate()
        {
            IsActive = true;
        }

        public virtual void Deactivate()
        {
            IsActive = false;
        }

        protected virtual void OnUpdate() { }
        protected virtual void OnActiveUpdate() { }
    }
}