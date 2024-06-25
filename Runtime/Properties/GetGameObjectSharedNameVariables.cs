using GameCreator.Runtime.Common;
using System;
using UnityEngine;

namespace GameCreator.Runtime.SharedVariables
{
    [Title("Shared Name Variables")]
    [Category("Variables/Shared Name Variables")]
    [Description("Reference to the game object with a Shared Name Variables component")]
    [Image(typeof(IconNameVariable), ColorTheme.Type.Pink)]
    [Serializable]
    public class GetGameObjectSharedNameVariables : PropertyTypeGetGameObject
    {
        [SerializeField]
        SharedNameVariables _sharedNameVariables;

        public static PropertyGetGameObject Create => new(new GetGameObjectSharedNameVariables());

        public override string String => _sharedNameVariables != null
            ? _sharedNameVariables.gameObject.name
            : "(none)";

        public override GameObject EditorValue => _sharedNameVariables != null
            ? _sharedNameVariables.gameObject
            : null;

        public override GameObject Get(Args args)
        {
            return _sharedNameVariables != null
                ? _sharedNameVariables.gameObject
                : null;
        }

        public override GameObject Get(GameObject gameObject)
        {
            return _sharedNameVariables != null
                ? _sharedNameVariables.gameObject
                : null;
        }

        public override T Get<T>(Args args)
        {
            if (typeof(T) == typeof(SharedNameVariables)) return _sharedNameVariables as T;
            return base.Get<T>(args);
        }
    }
}
