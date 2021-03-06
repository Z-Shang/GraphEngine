






using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xunit;
using Trinity;
using Trinity.Storage;

namespace tsl4
{

    public class IntListAccessorTests
    {
        #region Util

        private int[] GetArray(int size) => new int[size];

        #endregion

        #region CopyAll
        [Fact]
        public void CopyToTest_CopyAll_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(10);
            writer.IntList.CopyTo(array);
            Assert.True(array, Is.EqualTo(writer.IntList.Select(e => (int)e)));
        });

        [Fact]
        public void CopyToTest_CopyAll_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.IntList.CopyTo(array); }, Throws.ArgumentException);
        });
        #endregion

        #region CopyAllWithDstOffset
        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(15);
            writer.IntList.CopyTo(array, 5);
            Assert.True(array.Take(5), Has.Exactly(5).EqualTo(default(int)));
            Assert.True(array.Skip(5), Is.EqualTo(writer.IntList.Select(e => (int)e)));
        });

        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.IntList.CopyTo(array, 3); }, Throws.ArgumentException);
        });

        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_OffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.IntList.CopyTo(array, 102); }, Throws.ArgumentException);
            Assert.True(() => { writer.IntList.CopyTo(array, -20); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });
        #endregion

        #region CopyWithOffsetsAndCount
        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(15);
            writer.IntList.CopyTo(2, array, 3, 5);
            Assert.True(array.Take(3), Has.Exactly(3).EqualTo(default(int)));
            Assert.True(array.Skip(3).Take(5), Is.EqualTo(writer.IntList.Skip(2).Take(5).Select(e => (int)e)));
            Assert.True(array.Skip(8), Has.Exactly(15 - 8).EqualTo(default(int)));
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.IntList.CopyTo(2, array, 3, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.IntList.CopyTo(0, array, 1, 5); }, Throws.ArgumentException);
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_DstOffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.IntList.CopyTo(2, array, 102, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.IntList.CopyTo(2, array, -20, 5); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_SrcOffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.IntList.CopyTo(200, array, 0, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.IntList.CopyTo(-200, array, 0, 200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_CountOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.IntList.CopyTo(200, array, 0, -200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.True(() => { writer.IntList.CopyTo(0, array, 0, -200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });
        #endregion
    }


    public class ByteListAccessorTests
    {
        #region Util

        private byte[] GetArray(int size) => new byte[size];

        #endregion

        #region CopyAll
        [Fact]
        public void CopyToTest_CopyAll_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(10);
            writer.ByteList.CopyTo(array);
            Assert.True(array, Is.EqualTo(writer.ByteList.Select(e => (byte)e)));
        });

        [Fact]
        public void CopyToTest_CopyAll_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.ByteList.CopyTo(array); }, Throws.ArgumentException);
        });
        #endregion

        #region CopyAllWithDstOffset
        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(15);
            writer.ByteList.CopyTo(array, 5);
            Assert.True(array.Take(5), Has.Exactly(5).EqualTo(default(byte)));
            Assert.True(array.Skip(5), Is.EqualTo(writer.ByteList.Select(e => (byte)e)));
        });

        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.ByteList.CopyTo(array, 3); }, Throws.ArgumentException);
        });

        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_OffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.ByteList.CopyTo(array, 102); }, Throws.ArgumentException);
            Assert.True(() => { writer.ByteList.CopyTo(array, -20); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });
        #endregion

        #region CopyWithOffsetsAndCount
        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(15);
            writer.ByteList.CopyTo(2, array, 3, 5);
            Assert.True(array.Take(3), Has.Exactly(3).EqualTo(default(byte)));
            Assert.True(array.Skip(3).Take(5), Is.EqualTo(writer.ByteList.Skip(2).Take(5).Select(e => (byte)e)));
            Assert.True(array.Skip(8), Has.Exactly(15 - 8).EqualTo(default(byte)));
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.ByteList.CopyTo(2, array, 3, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.ByteList.CopyTo(0, array, 1, 5); }, Throws.ArgumentException);
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_DstOffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.ByteList.CopyTo(2, array, 102, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.ByteList.CopyTo(2, array, -20, 5); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_SrcOffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.ByteList.CopyTo(200, array, 0, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.ByteList.CopyTo(-200, array, 0, 200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_CountOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.ByteList.CopyTo(200, array, 0, -200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.True(() => { writer.ByteList.CopyTo(0, array, 0, -200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });
        #endregion
    }


    public class DoubleListAccessorTests
    {
        #region Util

        private double[] GetArray(int size) => new double[size];

        #endregion

        #region CopyAll
        [Fact]
        public void CopyToTest_CopyAll_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(10);
            writer.DoubleList.CopyTo(array);
            Assert.True(array, Is.EqualTo(writer.DoubleList.Select(e => (double)e)));
        });

        [Fact]
        public void CopyToTest_CopyAll_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.DoubleList.CopyTo(array); }, Throws.ArgumentException);
        });
        #endregion

        #region CopyAllWithDstOffset
        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(15);
            writer.DoubleList.CopyTo(array, 5);
            Assert.True(array.Take(5), Has.Exactly(5).EqualTo(default(double)));
            Assert.True(array.Skip(5), Is.EqualTo(writer.DoubleList.Select(e => (double)e)));
        });

        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.DoubleList.CopyTo(array, 3); }, Throws.ArgumentException);
        });

        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_OffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.DoubleList.CopyTo(array, 102); }, Throws.ArgumentException);
            Assert.True(() => { writer.DoubleList.CopyTo(array, -20); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });
        #endregion

        #region CopyWithOffsetsAndCount
        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(15);
            writer.DoubleList.CopyTo(2, array, 3, 5);
            Assert.True(array.Take(3), Has.Exactly(3).EqualTo(default(double)));
            Assert.True(array.Skip(3).Take(5), Is.EqualTo(writer.DoubleList.Skip(2).Take(5).Select(e => (double)e)));
            Assert.True(array.Skip(8), Has.Exactly(15 - 8).EqualTo(default(double)));
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.DoubleList.CopyTo(2, array, 3, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.DoubleList.CopyTo(0, array, 1, 5); }, Throws.ArgumentException);
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_DstOffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.DoubleList.CopyTo(2, array, 102, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.DoubleList.CopyTo(2, array, -20, 5); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_SrcOffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.DoubleList.CopyTo(200, array, 0, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.DoubleList.CopyTo(-200, array, 0, 200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_CountOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.DoubleList.CopyTo(200, array, 0, -200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.True(() => { writer.DoubleList.CopyTo(0, array, 0, -200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });
        #endregion
    }


    public class LongListAccessorTests
    {
        #region Util

        private long[] GetArray(int size) => new long[size];

        #endregion

        #region CopyAll
        [Fact]
        public void CopyToTest_CopyAll_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(10);
            writer.LongList.CopyTo(array);
            Assert.True(array, Is.EqualTo(writer.LongList.Select(e => (long)e)));
        });

        [Fact]
        public void CopyToTest_CopyAll_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.LongList.CopyTo(array); }, Throws.ArgumentException);
        });
        #endregion

        #region CopyAllWithDstOffset
        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(15);
            writer.LongList.CopyTo(array, 5);
            Assert.True(array.Take(5), Has.Exactly(5).EqualTo(default(long)));
            Assert.True(array.Skip(5), Is.EqualTo(writer.LongList.Select(e => (long)e)));
        });

        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.LongList.CopyTo(array, 3); }, Throws.ArgumentException);
        });

        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_OffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.LongList.CopyTo(array, 102); }, Throws.ArgumentException);
            Assert.True(() => { writer.LongList.CopyTo(array, -20); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });
        #endregion

        #region CopyWithOffsetsAndCount
        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(15);
            writer.LongList.CopyTo(2, array, 3, 5);
            Assert.True(array.Take(3), Has.Exactly(3).EqualTo(default(long)));
            Assert.True(array.Skip(3).Take(5), Is.EqualTo(writer.LongList.Skip(2).Take(5).Select(e => (long)e)));
            Assert.True(array.Skip(8), Has.Exactly(15 - 8).EqualTo(default(long)));
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.LongList.CopyTo(2, array, 3, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.LongList.CopyTo(0, array, 1, 5); }, Throws.ArgumentException);
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_DstOffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.LongList.CopyTo(2, array, 102, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.LongList.CopyTo(2, array, -20, 5); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_SrcOffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.LongList.CopyTo(200, array, 0, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.LongList.CopyTo(-200, array, 0, 200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_CountOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.LongList.CopyTo(200, array, 0, -200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.True(() => { writer.LongList.CopyTo(0, array, 0, -200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });
        #endregion
    }


    public class StringListAccessorTests
    {
        #region Util

        private string[] GetArray(int size) => new string[size];

        #endregion

        #region CopyAll
        [Fact]
        public void CopyToTest_CopyAll_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(10);
            writer.StringList.CopyTo(array);
            Assert.True(array, Is.EqualTo(writer.StringList.Select(e => (string)e)));
        });

        [Fact]
        public void CopyToTest_CopyAll_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.StringList.CopyTo(array); }, Throws.ArgumentException);
        });
        #endregion

        #region CopyAllWithDstOffset
        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(15);
            writer.StringList.CopyTo(array, 5);
            Assert.True(array.Take(5), Has.Exactly(5).EqualTo(default(string)));
            Assert.True(array.Skip(5), Is.EqualTo(writer.StringList.Select(e => (string)e)));
        });

        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.StringList.CopyTo(array, 3); }, Throws.ArgumentException);
        });

        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_OffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.StringList.CopyTo(array, 102); }, Throws.ArgumentException);
            Assert.True(() => { writer.StringList.CopyTo(array, -20); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });
        #endregion

        #region CopyWithOffsetsAndCount
        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(15);
            writer.StringList.CopyTo(2, array, 3, 5);
            Assert.True(array.Take(3), Has.Exactly(3).EqualTo(default(string)));
            Assert.True(array.Skip(3).Take(5), Is.EqualTo(writer.StringList.Skip(2).Take(5).Select(e => (string)e)));
            Assert.True(array.Skip(8), Has.Exactly(15 - 8).EqualTo(default(string)));
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.StringList.CopyTo(2, array, 3, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.StringList.CopyTo(0, array, 1, 5); }, Throws.ArgumentException);
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_DstOffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.StringList.CopyTo(2, array, 102, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.StringList.CopyTo(2, array, -20, 5); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_SrcOffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.StringList.CopyTo(200, array, 0, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.StringList.CopyTo(-200, array, 0, 200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_CountOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.StringList.CopyTo(200, array, 0, -200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.True(() => { writer.StringList.CopyTo(0, array, 0, -200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });
        #endregion
    }


    public class FixedLengthStructListAccessorTests
    {
        #region Util

        private FixedLengthStruct[] GetArray(int size) => new FixedLengthStruct[size];

        #endregion

        #region CopyAll
        [Fact]
        public void CopyToTest_CopyAll_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(10);
            writer.FixedLengthStructList.CopyTo(array);
            Assert.True(array, Is.EqualTo(writer.FixedLengthStructList.Select(e => (FixedLengthStruct)e)));
        });

        [Fact]
        public void CopyToTest_CopyAll_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.FixedLengthStructList.CopyTo(array); }, Throws.ArgumentException);
        });
        #endregion

        #region CopyAllWithDstOffset
        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(15);
            writer.FixedLengthStructList.CopyTo(array, 5);
            Assert.True(array.Take(5), Has.Exactly(5).EqualTo(default(FixedLengthStruct)));
            Assert.True(array.Skip(5), Is.EqualTo(writer.FixedLengthStructList.Select(e => (FixedLengthStruct)e)));
        });

        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.FixedLengthStructList.CopyTo(array, 3); }, Throws.ArgumentException);
        });

        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_OffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.FixedLengthStructList.CopyTo(array, 102); }, Throws.ArgumentException);
            Assert.True(() => { writer.FixedLengthStructList.CopyTo(array, -20); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });
        #endregion

        #region CopyWithOffsetsAndCount
        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(15);
            writer.FixedLengthStructList.CopyTo(2, array, 3, 5);
            Assert.True(array.Take(3), Has.Exactly(3).EqualTo(default(FixedLengthStruct)));
            Assert.True(array.Skip(3).Take(5), Is.EqualTo(writer.FixedLengthStructList.Skip(2).Take(5).Select(e => (FixedLengthStruct)e)));
            Assert.True(array.Skip(8), Has.Exactly(15 - 8).EqualTo(default(FixedLengthStruct)));
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.FixedLengthStructList.CopyTo(2, array, 3, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.FixedLengthStructList.CopyTo(0, array, 1, 5); }, Throws.ArgumentException);
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_DstOffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.FixedLengthStructList.CopyTo(2, array, 102, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.FixedLengthStructList.CopyTo(2, array, -20, 5); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_SrcOffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.FixedLengthStructList.CopyTo(200, array, 0, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.FixedLengthStructList.CopyTo(-200, array, 0, 200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_CountOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.FixedLengthStructList.CopyTo(200, array, 0, -200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.True(() => { writer.FixedLengthStructList.CopyTo(0, array, 0, -200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });
        #endregion
    }


    public class VariableLengthStructListAccessorTests
    {
        #region Util

        private VariableLengthStruct[] GetArray(int size) => new VariableLengthStruct[size];

        #endregion

        #region CopyAll
        [Fact]
        public void CopyToTest_CopyAll_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(10);
            writer.VariableLengthStructList.CopyTo(array);
            Assert.True(array, Is.EqualTo(writer.VariableLengthStructList.Select(e => (VariableLengthStruct)e)));
        });

        [Fact]
        public void CopyToTest_CopyAll_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.VariableLengthStructList.CopyTo(array); }, Throws.ArgumentException);
        });
        #endregion

        #region CopyAllWithDstOffset
        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(15);
            writer.VariableLengthStructList.CopyTo(array, 5);
            Assert.True(array.Take(5), Has.Exactly(5).EqualTo(default(VariableLengthStruct)));
            Assert.True(array.Skip(5), Is.EqualTo(writer.VariableLengthStructList.Select(e => (VariableLengthStruct)e)));
        });

        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.VariableLengthStructList.CopyTo(array, 3); }, Throws.ArgumentException);
        });

        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_OffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.VariableLengthStructList.CopyTo(array, 102); }, Throws.ArgumentException);
            Assert.True(() => { writer.VariableLengthStructList.CopyTo(array, -20); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });
        #endregion

        #region CopyWithOffsetsAndCount
        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(15);
            writer.VariableLengthStructList.CopyTo(2, array, 3, 5);
            Assert.True(array.Take(3), Has.Exactly(3).EqualTo(default(VariableLengthStruct)));
            Assert.True(array.Skip(3).Take(5), Is.EqualTo(writer.VariableLengthStructList.Skip(2).Take(5).Select(e => (VariableLengthStruct)e)));
            Assert.True(array.Skip(8), Has.Exactly(15 - 8).EqualTo(default(VariableLengthStruct)));
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.VariableLengthStructList.CopyTo(2, array, 3, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.VariableLengthStructList.CopyTo(0, array, 1, 5); }, Throws.ArgumentException);
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_DstOffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.VariableLengthStructList.CopyTo(2, array, 102, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.VariableLengthStructList.CopyTo(2, array, -20, 5); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_SrcOffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.VariableLengthStructList.CopyTo(200, array, 0, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.VariableLengthStructList.CopyTo(-200, array, 0, 200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_CountOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.VariableLengthStructList.CopyTo(200, array, 0, -200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.True(() => { writer.VariableLengthStructList.CopyTo(0, array, 0, -200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });
        #endregion
    }


    public class IntArrayListAccessorTests
    {
        #region Util

        private int[][,] GetArray(int size)
            => new int[size][,];

        #endregion

        #region CopyAll
        [Fact]
        public void CopyToTest_CopyAll_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(10);
            writer.IntArrayList.CopyTo(array);
            Assert.True(array, Is.EqualTo(writer.IntArrayList.Select(e => (int[,])e)));
        });

        [Fact]
        public void CopyToTest_CopyAll_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.IntArrayList.CopyTo(array); }, Throws.ArgumentException);
        });
        #endregion

        #region CopyAllWithDstOffset
        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(15);
            writer.IntArrayList.CopyTo(array, 5);
            Assert.True(array.Take(5), Has.Exactly(5).EqualTo(default(int[,])));
            Assert.True(array.Skip(5), Is.EqualTo(writer.IntArrayList.Select(e => (int[,])e)));
        });

        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.IntArrayList.CopyTo(array, 3); }, Throws.ArgumentException);
        });

        [Fact]
        public void CopyToTest_CopyAllWithDstOffset_OffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.IntArrayList.CopyTo(array, 102); }, Throws.ArgumentException);
            Assert.True(() => { writer.IntArrayList.CopyTo(array, -20); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });
        #endregion

        #region CopyWithOffsetsAndCount
        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_Success() => Utils.WithWriter(writer =>
        {
            var array = GetArray(15);
            writer.IntArrayList.CopyTo(2, array, 3, 5);
            Assert.True(array.Take(3), Has.Exactly(3).EqualTo(default(int[,])));
            Assert.True(array.Skip(3).Take(5), Is.EqualTo(writer.IntArrayList.Skip(2).Take(5).Select(e => (int[,])e)));
            Assert.True(array.Skip(8), Has.Exactly(15 - 8).EqualTo(default(int[,])));
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_DstNoSpace() => Utils.WithWriter(writer =>
        {
            var array = GetArray(5);
            Assert.True(() => { writer.IntArrayList.CopyTo(2, array, 3, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.IntArrayList.CopyTo(0, array, 1, 5); }, Throws.ArgumentException);
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_DstOffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.IntArrayList.CopyTo(2, array, 102, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.IntArrayList.CopyTo(2, array, -20, 5); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_SrcOffsetOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.IntArrayList.CopyTo(200, array, 0, 5); }, Throws.ArgumentException);
            Assert.True(() => { writer.IntArrayList.CopyTo(-200, array, 0, 200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });

        [Fact]
        public void CopyToTest_CopyWithOffsetsAndCount_CountOutOfRange() => Utils.WithWriter(writer =>
        {
            var array = GetArray(100);
            Assert.True(() => { writer.IntArrayList.CopyTo(200, array, 0, -200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.True(() => { writer.IntArrayList.CopyTo(0, array, 0, -200); }, Throws.TypeOf<ArgumentOutOfRangeException>());
        });
        #endregion
    }



}
