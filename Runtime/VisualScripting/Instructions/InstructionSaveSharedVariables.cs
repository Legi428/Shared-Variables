using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using System;
using System.Threading.Tasks;

namespace GameCreator.Runtime.SharedVariables
{
    [Title("Save All Shared Variables")]
    [Description("Saves the current state of all shared variables in the scene.")]
    [Category("Storage/Save All Shared Variables")]
    [Keywords("Load", "Save", "Profile", "Slot", "Game", "Session", "Shared", "Variables")]
    [Image(typeof(IconDiskSolid), ColorTheme.Type.Green)]
    [Serializable]
    public class InstructionSaveSharedVariables : Instruction
    {
        public override string Title => "Save All Shared Variables";

        protected override Task Run(Args args)
        {
            SharedVariablesSaveManager.Instance.SaveAll();
            return DefaultResult;
        }
    }
}
