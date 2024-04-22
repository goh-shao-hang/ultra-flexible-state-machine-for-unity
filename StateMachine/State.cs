using System.Collections.Generic;

namespace GameCells.StateMachine
{
    public abstract class State
    {
        public List<Transition> _transitions = new();

        public virtual void Enter()
        {
            foreach (var transition in _transitions)
            {
                foreach (var condition in transition.Conditions)
                {
                    condition.Enter();
                }
            }
        }

        public virtual void Update()
        {
            foreach (var transition in _transitions)
            {
                foreach (var condition in transition.Conditions)
                {
                    condition.Update();
                }
            }
        }

        public virtual void FixedUpdate()
        {
            foreach (var transition in _transitions)
            {
                foreach (var condition in transition.Conditions)
                {
                    condition.FixedUpdate();
                }
            }
        }

        public virtual void Exit()
        {
            foreach (var transition in _transitions)
            {
                foreach (var condition in transition.Conditions)
                {
                    condition.Exit();
                }
            }
        }

        /// <summary>
        /// Add a transition this state can transition to upon meeting certain condition
        /// </summary>
        /// <param name="targetState"></param>
        /// <param name="condition"></param>
        public void AddTransition(State targetState, Condition condition) => _transitions.Add(new Transition(targetState, condition));

        public void AddTransition(State targetState, Condition[] conditions) => _transitions.Add(new Transition(targetState, conditions));

        public void AddTransition(Transition transition) => _transitions.Add(transition);
    }
}