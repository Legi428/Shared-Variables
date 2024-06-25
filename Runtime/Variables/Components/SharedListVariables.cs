using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using System;
using System.Reflection;

namespace GameCreator.Runtime.SharedVariables
{
    public class SharedListVariables : LocalListVariables
    {
        protected override void Awake()
        {
            // Get the field info for m_Runtime
            var fieldInfo = typeof(LocalListVariables).GetField("m_Runtime", BindingFlags.Instance | BindingFlags.NonPublic);

            // Retrieve the value of m_Runtime
            var value = (NameVariableRuntime)fieldInfo?.GetValue(this);
            if (value == null) return;

            // Call the OnStartup method
            value.OnStartup();

            // Use reflection to add the event handler for EventChange
            var eventInfo = typeof(NameVariableRuntime).GetEvent("EventChange", BindingFlags.Instance | BindingFlags.Public);
            if (eventInfo == null)
            {
                throw new InvalidOperationException("EventChange event not found in NameVariableRuntime.");
            }

            // Create a delegate for the OnRuntimeChange method
            var methodInfo =
                typeof(LocalListVariables).GetMethod("OnRuntimeChange", BindingFlags.Instance | BindingFlags.NonPublic);
            if (methodInfo == null)
            {
                throw new InvalidOperationException("OnRuntimeChange method not found in SharedVariables.");
            }

            // Add the handler to the event
            var handlerDelegate = Delegate.CreateDelegate(eventInfo.EventHandlerType, this, methodInfo);
            eventInfo.AddEventHandler(value, handlerDelegate);

            SharedVariablesSaveManager.Instance.Add(this);
        }

        protected override void OnDestroy()
        {
            if (ApplicationManager.IsExiting) return;
            SharedVariablesSaveManager.Instance.Remove(this);
        }
    }
}
