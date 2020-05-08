using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MyvarEdit.TrueType.Internals
{
    [Flags]
    public enum OutlineFlags
    {
        OnCurve = 1,
        XIsByte = 2,
        YIsByte = 4,
        Repeat = 8,
        XDelta = 16,
        YDelta = 32,
    }
    
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CmapEncoding
    {
        public ushort platformID;
        public ushort platformSpecificID;
        public uint offset;
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct GlyphDescription
    {
        [FieldOffset(0)] public short numberOfContours;
        [FieldOffset(2)] public short xMin;
        [FieldOffset(3)] public short yMin;
        [FieldOffset(6)] public short xMax;
        [FieldOffset(8)]  public short yMax;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Cmap
    {
        public ushort format;
        public ushort length;
        public ushort language;
        public ushort segCountX2;
        public ushort searchRange;
        public ushort entrySelector;
        public ushort rangeShift;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CmapIndex
    {
        public ushort Version;
        public ushort NumberSubtables;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TrueTypeHeader
    {
        public uint Version;
        public uint FontRevision;
        public uint CheckSumAdjustment;
        public uint MagicNumber;
        public ushort Flags;
        public ushort UnitsPerEm;
        public ulong Created;
        public ulong Modified;
        public short Xmin;
        public short Ymin;
        public short Xmax;
        public short Ymax;
        public ushort MacStyle;
        public ushort LowestRecPPEM;
        public short FontDirectionHint;
        public short IndexToLocFormat;
        public short GlyphDataFormat;
    }


    [StructLayout(LayoutKind.Explicit)]
    public struct TableEntry
    {
        [FieldOffset(0)] public uint Id;
        [FieldOffset(4)] public uint CheckSum;
        [FieldOffset(8)] public uint Offset;
        [FieldOffset(12)] public uint Length;

        public override string ToString()
        {
            return Encoding.ASCII.GetString(BitConverter.GetBytes(Id).Reverse().ToArray());
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OffsetTable
    {
        public uint ScalerType;
        public ushort NumTables;
        public ushort SearchRange;
        public ushort EntrySelector;
        public ushort RangeShift;
    }
}