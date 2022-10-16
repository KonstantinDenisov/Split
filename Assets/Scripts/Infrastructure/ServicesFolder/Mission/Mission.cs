using System;

namespace Split.Infrastructure.ServicesFolder.Mission
{
    public abstract class Mission
    {
        public event Action OnCompleted;
        public bool IsCompleted { get; private set; }

        public abstract void Init();
        public abstract void Dispose();
        public virtual void Update(float deltaTime) { }

        protected void Complete()
        {
            IsCompleted = true;
            OnCompleted?.Invoke();
        }
    }

    public abstract class Mission<TCondition> : Mission where TCondition : MissionCondition
    {
        protected TCondition Condition { get; private set; }

        public void SetCondition(TCondition condition) =>
            Condition = condition;
    }
}