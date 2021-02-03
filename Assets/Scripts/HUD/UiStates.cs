using FSM_Pluggable;
using TanksSimpleAi.TankPFSM;
using UnityEngine;
using UnityEngine.UI;

namespace HUD
{
    public class UiStates : MonoBehaviour
    {
        public TankMachine targetMachine;
        public Image stateColor;
        public Text stateNameTxt;

        private void Start()
        {
            targetMachine.OnStateChanged += OnStateMachineChanged;
        }

        private void OnStateMachineChanged(SmState state)
        {
            stateColor.color = state.stateColor;
            stateNameTxt.text = $"Enemy State : {state.name}";
        }
    }
}