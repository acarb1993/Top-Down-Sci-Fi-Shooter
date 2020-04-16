using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject, ISerializationCallbackReceiver
{
    // This value should not be edited at runtime
    public float InitialValue;

    [System.NonSerialized]
    public float RuntimeValue;

    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize() { }
}
