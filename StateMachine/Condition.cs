using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCells.StateMachine
{
    public abstract class Condition
    {
        public abstract bool Evaluate();

        public virtual void Enter() { }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }
        public virtual void Exit() { }
    }
}