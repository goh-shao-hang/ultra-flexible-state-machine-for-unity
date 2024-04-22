A flexible state machine system for Unity that can be used for creating AIs, managing game states and anything that has to do with states！

### Features:
![WIP](https://github.com/goh-shao-hang/ultra-flexible-state-machine-for-unity/assets/64406657/005fec4d-128f-4012-801c-51adbca77ae7)

### Explanation:
The system consists of 4 main scripts:
1. [StateMachine.cs](StateMachine/StateMachine.cs) - Inherited by your monobehaviour class. Automatically handles callbacks for states (enter, update, exit) as well as condition checking for transitions. Needs to be initialized in Awake (or Start if you're feeling brave), see example below.
2. [State.cs](StateMachine/State.cs)
3. [Condition.cs](StateMachine/Condition.cs)
4. [Transition.cs](StateMachine/Transition.cs)

### Step-by-step tutorial
![WIP](https://github.com/goh-shao-hang/ultra-flexible-state-machine-for-unity/assets/64406657/005fec4d-128f-4012-801c-51adbca77ae7)

### Example:
![WIP](https://github.com/goh-shao-hang/ultra-flexible-state-machine-for-unity/assets/64406657/005fec4d-128f-4012-801c-51adbca77ae7)
