using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace GameCreator.Runtime.SharedVariables
{
    [Title("Load Single Shared Variables")]
    [Description("Loads a shared variables component in the scene. You can supply both or just a single reference.")]
    [Category("Storage/Load Single Shared Variables")]
    [Parameter("List Variables", "The reference of the shared list variables to be loaded.")]
    [Parameter("Name Variables", "The reference of the shared name variables to be loaded.")]
    [Keywords("Load", "Save", "Profile", "Slot", "Game", "Session", "Shared", "Variables")]
    [Image(typeof(IconDiskSolid), ColorTheme.Type.Blue)]
    [Serializable]
    public class InstructionLoadSingleSharedVariables : Instruction
    {
        [SerializeField]
        PropertyGetGameObject _listVariables = GetGameObjectSharedListVariables.Create;

        [SerializeField]
        PropertyGetGameObject _nameVariables = GetGameObjectSharedNameVariables.Create;

        public override string Title
        {
            get
            {
                var listVariables = _listVariables.Get<SharedListVariables>(Args.EMPTY);
                var nameVariables = _nameVariables.Get<SharedNameVariables>(Args.EMPTY);
                if (listVariables != null && nameVariables != null)
                {
                    return $"Load Shared List of {listVariables.name} and Name Variables of {nameVariables.name}";
                }
                if (listVariables != null)
                {
                    return $"Load Shared List Variables of {listVariables.name}";
                }
                if (nameVariables != null)
                {
                    return $"Load Shared Name Variables of {nameVariables.name}";
                }
                return "Load Shared Variables of <none>";
            }
        }

        protected override async Task Run(Args args)
        {
            IGameSave reference = _listVariables.Get<SharedListVariables>(args);
            if (reference == null) return;
            await SharedVariablesSaveManager.Instance.LoadItem(reference);

            reference = _nameVariables.Get<SharedNameVariables>(args);
            if (reference == null) return;
            await SharedVariablesSaveManager.Instance.LoadItem(reference);
        }
    }
}
