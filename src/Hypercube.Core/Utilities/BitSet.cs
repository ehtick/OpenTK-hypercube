using System.Runtime.CompilerServices;
using System.Text;

namespace Hypercube.Core.Utilities;

/// <summary>
/// A bit set that supports an arbitrary number of bits beyond 64.
/// </summary>
public sealed class BitSet
{
    private const int BitsPerElement = 64;
    private const int MinSizeValue = 1;
    
    /// <summary>
    /// Gets the number of bits in the bitset.
    /// </summary>
    public readonly int Size;
    
    private ulong[] _bits;

    /// <summary>
    /// Initializes a new instance of the <see cref="BitSet"/> class with the specified number of bits.
    /// </summary>
    /// <param name="size">The total number of bits.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if size is less than 1.</exception>
    public BitSet(int size)
    {
        if (size < MinSizeValue)
            throw new ArgumentOutOfRangeException(nameof(size), $"Size must be at least {MinSizeValue}.");

        Size = size;
        _bits = new ulong[(size + 63) / BitsPerElement];
    }
    
    /// <summary>
    /// Sets the bit at the specified index to 1.
    /// </summary>
    /// <param name="index">The bit index to set.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(int index)
    {
        ValidateIndex(index);
        _bits[index / BitsPerElement] |= 1UL << (index % BitsPerElement);
    }

    /// <summary>
    /// Clears the bit at the specified index (sets it to 0).
    /// </summary>
    /// <param name="index">The bit index to clear.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Clear(int index)
    {
        ValidateIndex(index);
        _bits[index / BitsPerElement] &= ~(1UL << (index % BitsPerElement));
    }

    /// <summary>
    /// Checks if the bit at the specified index is set (1).
    /// </summary>
    /// <param name="index">The bit index to check.</param>
    /// <returns>True if the bit is set, otherwise false.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Has(int index)
    {
        ValidateIndex(index);
        return (_bits[index / BitsPerElement] & (1UL << (index % BitsPerElement))) != 0;
    }

    /// <summary>
    /// Throws an exception if the index is out of bounds.
    /// Uses unsigned comparison for performance optimization.
    /// </summary>
    /// <param name="index">The bit index to validate.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the index is out of range.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ValidateIndex(int index)
    {
        if ((uint) index < (uint) Size)
            return;
        
        throw new ArgumentOutOfRangeException(nameof(index), $"Index must be between 0 and {Size - 1}.");
    }
    
    /// <summary>
    /// Returns a string representation of the bitset, with the highest index on the left.
    /// </summary>
    /// <returns>A string of 1s and 0s representing the bitset.</returns>
    public override string ToString()
    {
        var builder = new StringBuilder(Size);
        for (var i = Size - 1; i >= 0; i--)
            builder.Append(Has(i) ? '1' : '0');
        return builder.ToString();
    }
    
    /// <summary>
    /// Applies a given bitwise operation between two bitsets.
    /// </summary>
    /// <param name="a">The first bitset.</param>
    /// <param name="b">The second bitset.</param>
    /// <param name="operation">The bitwise operation to apply.</param>
    /// <returns>A new bitset resulting from the operation.</returns>
    /// <exception cref="ArgumentException">Thrown if the sizes do not match.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static BitSet ApplyOperator(BitSet a, BitSet b, Func<ulong, ulong, ulong> operation)
    {
        if (a.Size != b.Size)
            throw new ArgumentException("BitSets must have the same size.");

        var result = new BitSet(a.Size);
        
        // Write the result without validation directly
        for (var i = 0; i < a._bits.Length; i++)
            result._bits[i] = operation(a._bits[i], b._bits[i]);

        return result;
    }

    /// <summary>
    /// Performs a bitwise OR operation between two bitsets.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static BitSet operator |(BitSet a, BitSet b)
    {
        if (a.Size != b.Size)
            throw new ArgumentException("BitSets must have the same size.");

        var result = new BitSet(a.Size);
        for (var i = 0; i < a._bits.Length; i++)
            result._bits[i] = a._bits[i] | b._bits[i];

        return result;
    }

    /// <summary>
    /// Performs a bitwise AND operation between two bitsets.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static BitSet operator &(BitSet a, BitSet b)
    {
        if (a.Size != b.Size)
            throw new ArgumentException("BitSets must have the same size.");

        var result = new BitSet(a.Size);
        for (var i = 0; i < a._bits.Length; i++)
            result._bits[i] = a._bits[i] & b._bits[i];

        return result;
    }

    /// <summary>
    /// Performs a bitwise XOR operation between two bitsets.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static BitSet operator ^(BitSet a, BitSet b)
    {
        if (a.Size != b.Size)
            throw new ArgumentException("BitSets must have the same size.");

        var result = new BitSet(a.Size);
        for (var i = 0; i < a._bits.Length; i++)
            result._bits[i] = a._bits[i] ^ b._bits[i];

        return result;
    }

    /// <summary>
    /// Performs a bitwise NOT operation (flipping all bits).
    /// </summary>
    public static BitSet operator ~(BitSet a)
    {
        var result = new BitSet(a.Size);

        // Invert all bits in each block
        for (var i = 0; i < a._bits.Length; i++)
            result._bits[i] = ~a._bits[i];

        // Trim excess bits in the last block
        var lastBitCount = a.Size % 64;
        if (lastBitCount > 0)
            result._bits[^1] &= (1UL << lastBitCount) - 1;

        return result;
    }
}