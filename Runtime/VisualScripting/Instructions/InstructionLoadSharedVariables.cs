using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using System;
using System.Threading.Tasks;

namespace GameCreator.Runtime.SharedVariables
{
    [Title("Load All Shared Variables")]
    [Description("Loads all shared variables in the scene.")]
    [Category("Storage/Load All Shared Variables")]
    [Keywords("Load", "Save", "Profile", "Slot", "Game", "Session", "Shared", "Variables")]
    [Image(typeof(IconDiskSolid), ColorTheme.Type.Blue)]
    [Serializable]
    public class InstructionLoadSharedVariables : Instruction
    {
        public override string Title => "Load All Shared Variables";

        protected override Task Run(Args args)
        {
            SharedVariablesSaveManager.Instance.LoadAll();
            return DefaultResult;
        }
    }
}
