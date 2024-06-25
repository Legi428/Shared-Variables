using GameCreator.Runtime.Common;
using System;
using UnityEngine;

namespace GameCreator.Runtime.SharedVariables
{
    [Title("Shared List Variables")]
    [Category("Variables/Shared List Variables")]
    [Description("Reference to the game object with a Shared List Variables component")]
    [Image(typeof(IconListVariable), ColorTheme.Type.Pink)]
    [Serializable]
    public class GetGameObjectSharedListVariables : PropertyTypeGetGameObject
    {
        [SerializeField]
        SharedListVariables _sharedListVariables;

        public static PropertyGetGameObject Create => new(new GetGameObjectSharedListVariables());

        public override string String => _sharedListVariables != null
            ? _sharedListVariables.gameObject.name
            : "(none)";

        public override GameObject EditorValue => _sharedListVariables != null
            ? _sharedListVariables.gameObject
            : null;

        public override GameObject Get(Args args)
        {
            return _sharedListVariables != null
                ? _sharedListVariables.gameObject
                : null;
        }

        public override GameObject Get(GameObject gameObject)
        {
            return _sharedListVariables != null
                ? _sharedListVariables.gameObject
                : null;
        }

        public override T Get<T>(Args args)
        {
            if (typeof(T) == typeof(SharedListVariables)) return _sharedListVariables as T;
            return base.Get<T>(args);
        }
    }
}
