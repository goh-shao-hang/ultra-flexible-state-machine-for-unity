using GameCells;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCells.StateMachine
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected State _currentState;

        //List of transitions in this state machine that applies to every state
        private List<Transition> _anyTransitions = new List<Transition>();

        public void Initialize(State initialState)
        {
            _currentState = initialState;
            _currentState.Enter();

            foreach (var transition in _anyTransitions) 
            {
                foreach (var condition in transition.Conditions)
                {
                    condition.Enter();
                }
            }
        }

        protected virtual void Update()
        {
            _currentState?.Update();

            foreach (var transition in _anyTransitions)
            {
                if (_currentState == transition.TargetState) //Don't transition to self
                    continue;

                bool allConditionsMet = true;

                foreach (var condition in transition.Conditions)
                {
                    condition.Update();

                    if (!condition.Evaluate())
                    {
                        allConditionsMet = false;
                        break;
                    }
                }

                if (allConditionsMet)
                {
                    SwitchState(transition.TargetState);
                    break;
                }
            }

            foreach (var transition in _currentState._transitions)
            {
                 bool allConditionsMet = true;

                foreach (var condition in transition.Conditions)
                {
                    condition.Update();

                    if (!condition.Evaluate())
                    {
                        allConditionsMet = false;
                        break;
                    }
                }

                if (allConditionsMet)
                {
                    SwitchState(transition.TargetState);
                    break;
                }
            }
        }

        private void SwitchState(State newState)
        {
            if (_currentState == newState)
                return;

            foreach (var transition in _anyTransitions)
            {
                foreach (var condition in transition.Conditions)
                {
                    condition.Exit();
                }
            }

            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();

            foreach (var transition in _anyTransitions)
            {
                foreach (var condition in transition.Conditions)
                {
                    condition.Enter();
                }
            }
        }

        /// <summary>
        /// Add a transition that any state in this state machine can transition to when the condition is met. These transitions always
        /// has higher priority than state-specific transitions.
        /// </summary>
        /// <param name="targetState"></param>
        protected void AddAnyTransition(State targetState, Condition condition)
        {
            _anyTransitions.Add(new Transition(targetState, condition));
        }

        protected void AddAnyTransition(State targetState, Condition[] conditions)
        {
            _anyTransitions.Add(new Transition(targetState, conditions));
        }
    }
}