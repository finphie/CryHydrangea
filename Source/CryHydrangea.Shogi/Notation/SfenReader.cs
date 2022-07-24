using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CryHydrangea.Shogi.Notation;

public ref struct SfenReader
{
    readonly ReadOnlySpan<byte> _buffer;

    int _position;

    public SfenReader(ReadOnlySpan<byte> input)
    {
        _buffer = input;
        _position = 0;
    }

    public Piece ReadPiece()
    {
        ref var bufferStart = ref Unsafe.Add(ref MemoryMarshal.GetReference(_buffer), (nint)(uint)_position);

        File file;
        Rank rank;

        while (_position < _buffer.Length)
        {

        }
    }

    public bool IsPromotion();
}
