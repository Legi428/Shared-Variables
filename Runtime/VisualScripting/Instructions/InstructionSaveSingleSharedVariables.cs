using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace GameCreator.Runtime.SharedVariables
{
    [Title("Save Single Shared Variables")]
    [Description("Saves the current state of a shared variables component in the scene. You can supply both or just a single reference.")]
    [Category("Storage/Save Single Shared Variables")]
    [Parameter("List Variables", "The reference of the shared list variables to be saved.")]
    [Parameter("Name Variables", "The reference of the shared name variables to be saved.")]
    [Keywords("Load", "Save", "Profile", "Slot", "Game", "Session", "Shared", "Variables")]
    [Image(typeof(IconDiskSolid), ColorTheme.Type.Green)]
    [Serializable]
    public class InstructionSaveSingleSharedVariables : Instruction
    {
        [SerializeField]
        PropertyGetGameObject _listVariables;

        [SerializeField]
        PropertyGetGameObject _nameVariables;

        public override string Title
        {
            get
            {
                var listVariables = _listVariables.Get<SharedListVariables>(Args.EMPTY);
                var nameVariables = _nameVariables.Get<SharedNameVariables>(Args.EMPTY);
                if (listVariables != null && nameVariables != null)
                {
                    return $"Save Shared List of {listVariables.name} and Name Variables {nameVariables.name}";
                }
                if (listVariables != null)
                {
                    return $"Save Shared List Variables of {listVariables.name}";
                }
                if (nameVariables != null)
                {
                    return $"Save Shared Name Variables of {nameVariables.name}";
                }
                return "Save Shared Variables of <none>";
            }
        }

        protected override async Task Run(Args args)
        {
            IGameSave reference = _listVariables.Get<SharedListVariables>(args);
            if (reference != null)
            {
                await SharedVariablesSaveManager.Instance.SaveItem(reference);
            }

            reference = _nameVariables.Get<SharedNameVariables>(args);
            if (reference != null)
            {
                await SharedVariablesSaveManager.Instance.SaveItem(reference);
            }
        }
    }
}
