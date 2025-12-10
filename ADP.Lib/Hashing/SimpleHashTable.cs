using System.Diagnostics.CodeAnalysis;

namespace ADP.Lib.Hashing;

public class SimpleHashTable<Key, Value>
{
    // This shouldn't be public in a real implementation
    // But it's so much easier for testing. Tyvm.
    public int MaxSize = 16;
    private int CurrentCapacity = 0;
    private Value[] Data;

    public SimpleHashTable()
    {
        this.Data = new Value[MaxSize];
    }

    public int Size => this.CurrentCapacity;

    public void Add(Key key, Value value)
    {
        ArgumentNullException.ThrowIfNull(key, nameof(key));
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        var keyHash = HashingAlgorithm.Djb2(key.ToString(), (ulong)MaxSize);
        if (Data[keyHash] == null)
            Data[keyHash] = value;
        else
            throw new Exception("Collision detected.");

        CurrentCapacity++;
    }

    public void Clear()
    {
        this.Data = new Value[MaxSize];
        this.CurrentCapacity = 0;
    }

    public bool ContainsKey(Key key)
    {
        ArgumentNullException.ThrowIfNull(key, nameof(key));

        var keyHash = HashingAlgorithm.Djb2(key.GetHashCode(), (ulong)MaxSize);
        return Data[keyHash] != null;
    }

    public bool Remove(Key key)
    {
        ArgumentNullException.ThrowIfNull(key, nameof(key));

        var keyHash = HashingAlgorithm.Djb2(key.GetHashCode(), (ulong)MaxSize);
        if (Data[keyHash] == null)
            return false;

        Data[keyHash] = default;
        return true;
    }

    public bool TryGetValue(Key key, [MaybeNullWhen(false)] out Value value)
    {
        var keyHash = HashingAlgorithm.Djb2(key.GetHashCode(), (ulong)MaxSize);
        if (Data[keyHash] == null)
        {
            value = default;
            return false;
        }

        value = Data[keyHash];
        return true;
    }
}
