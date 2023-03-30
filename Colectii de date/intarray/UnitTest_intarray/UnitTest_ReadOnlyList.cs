using ColectiiDeDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColectiiDeDate
{
    public class UnitTest_ReadOnlyList
    {
        [Fact]
        public void Add_TestReadOnlyList_ShouldThrowNotSupportedExection()
        {
            var testList = new SortedList<int> { 4, 2, 1, 3 };
            var readOnlyList = new ReadOnlyList<int>(testList);

            var exception = Assert.Throws<NotSupportedException>(() => readOnlyList.Add(10));
            Assert.Equal("Collection is read-only.", exception.Message);
        }

        [Fact]
        public void IndexSetter_TestReadOnlyList_ShouldThrowNotSupportedExection()
        {
            var testList = new SortedList<int> { 4, 2, 1, 3 };
            var readOnlyList = new ReadOnlyList<int>(testList);

            var exception = Assert.Throws<NotSupportedException>(() => readOnlyList[2] = 3);
            Assert.Equal("Collection is read-only.", exception.Message);
        }

        [Fact]
        public void Insert_TestReadOnlyList_ShouldThrowNotSupportedExection()
        {
            var testList = new SortedList<int> { 4, 2, 1, 3 };
            var readOnlyList = new ReadOnlyList<int>(testList);

            var exception = Assert.Throws<NotSupportedException>(() => readOnlyList.Insert(1, 10));
            Assert.Equal("Collection is read-only.", exception.Message);
        }

        [Fact]
        public void Clear_TestReadOnlyList_ShouldThrowNotSupportedExection()
        {
            var testList = new SortedList<int> { 4, 2, 1, 3 };
            var readOnlyList = new ReadOnlyList<int>(testList);

            var exception = Assert.Throws<NotSupportedException>(() => readOnlyList.Clear());
            Assert.Equal("Collection is read-only.", exception.Message);
        }

        [Fact]
        public void Remove_TestReadOnlyList_ShouldThrowNotSupportedExection()
        {
            var testList = new SortedList<int> { 4, 2, 1, 3 };
            var readOnlyList = new ReadOnlyList<int>(testList);

            var exception = Assert.Throws<NotSupportedException>(() => readOnlyList.Remove(1));
            Assert.Equal("Collection is read-only.", exception.Message);
        }

        [Fact]
        public void RemoveAt_TestReadOnlyList_ShouldThrowNotSupportedExection()
        {
            var testList = new SortedList<int> { 4, 2, 1, 3 };
            var readOnlyList = new ReadOnlyList<int>(testList);

            var exception = Assert.Throws<NotSupportedException>(() => readOnlyList.RemoveAt(1));
            Assert.Equal("Collection is read-only.", exception.Message);
        }

        [Fact]
        public void NullExeption_TestReadOnlyList_ShouldThrowNullExection()
        {
            ReadOnlyList<int> readOnlyList;

            var exception = Assert.Throws<ArgumentNullException>(() => readOnlyList = new ReadOnlyList<int>(null));
            Assert.Equal("Array is null.", exception.Message);
        }
    }
}
