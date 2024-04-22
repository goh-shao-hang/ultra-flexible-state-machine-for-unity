using GameCells;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCells.StateMachine
{
    public class Transition
    {
        public State TargetState { get; }
        public Condition[] Conditions { get; }

        public Transition(State targetState, Condition condition)
        {
            TargetState = targetState;
            Conditions = new Condition[] { condition };
        }

        public Transition(State targetState, Condition[] conditions)
        {
            TargetState = targetState;
            Conditions = conditions;
        }
    }
}