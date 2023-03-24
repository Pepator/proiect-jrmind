using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColectiiDeDate
{
    public class UnitTest_SortedList
    {
        [Fact]
        public void Add_TestSortedList_ShouldReturnRightNumberOfElementsInOrder()
        {
            var testList = new SortedList<int> { 4, 2, 1, 3 };

            Assert.Equal(4, testList.Count);
            Assert.Equal(4, testList[3]);
        }

        [Fact]
        public void Count_TestSortedList_ShouldReturnRightNumberOfElements()
        {
            var testList = new SortedList<int> { 2, 4, 1, 3, 5, 6 };

            Assert.Equal(6, testList.Count);
        }

        [Fact]
        public void Element_TestSortedList_ShouldReturnRightElement()
        {
            var testList = new SortedList<int> { 2, 4, 1, 3, 5, 6 };

            Assert.Equal(4, testList[3]);
        }

        [Fact]
        public void SetElement_TestSortedList_ShouldReturnRightNumberOfElementsAndNewElement()
        {
            var testList = new SortedList<int> { 2, 4, 1, 3, 5, 6 };
            testList[0] = 100;

            Assert.Equal(6, testList.Count);
            Assert.False(testList.Contains(100));
        }

        [Fact]
        public void Contains_TestSortedList_ShouldReturnTrueOfElementFound()
        {
            var testList = new SortedList<int> { 2, 4, 1, 3, 5, 6 };

            Assert.True(testList.Contains(6));
            Assert.False(testList.Contains(100));
        }

        [Fact]
        public void IndexOf_TestSortedList_ShouldReturnRightIndex()
        {
            var testList = new SortedList<int> { 2, 4, 1, 3, 5, 6 };

            Assert.Equal(0, testList.IndexOf(1));
            Assert.Equal(-1, testList.IndexOf(10));
        }

        [Fact]
        public void Insert_TestSortedList_ShouldReturnRightElementAndNumberOfElements()
        {
            var testList = new SortedList<int> { 2, 4, 1, 3, 5, 6 };
            testList.Insert(6, 100);

            Assert.Equal(7, testList.Count);
            Assert.Equal(100, testList[6]);
        }

        [Fact]
        public void Clear_TestSortedList_ShouldReturnNoElements()
        {
            var testList = new SortedList<int> { 2, 4, 1, 3, 5, 6 };
            testList.Clear();

            Assert.Equal(0, testList.Count);
        }

        [Fact]
        public void Remove_TestSortedList_ShouldReturnRightNumberOfElements()
        {
            var testList = new SortedList<int> { 2, 4, 1, 3, 5, 6 };
            testList.Remove(6);

            Assert.Equal(5, testList.Count);
            Assert.False(testList.Contains(6));
        }

        [Fact]
        public void RemoveAt_TestSortedList_ShouldReturnRightNumberOfElements()
        {
            var testList = new SortedList<int> { 2, 4, 1, 3, 5, 6 };
            testList.RemoveAt(4);

            Assert.Equal(5, testList.Count);
            Assert.False(testList.Contains(5));
        }

        [Fact]
        public void IndexGetExeption_TestSortedListClass_ShouldThrowExeption()
        {
            var testList = new SortedList<int> { 1, 2, 3, 4, 5, 6 };

            var exeption = Assert.Throws<ArgumentOutOfRangeException>(() => testList[-1]);
            Assert.Equal("Index should be non-negative and equal or less than the size of the list. (Parameter '-1')", exeption.Message);
        }

        [Fact]
        public void IndexSetExeption_TestSortedListClass_ShouldThrowExeption()
        {
            var testList = new SortedList<int> { 1, 2, 3, 4, 5, 6 };

            var exeption = Assert.Throws<ArgumentOutOfRangeException>(() => testList[10] = 1);
            Assert.Equal("Index should be non-negative and equal or less than the size of the list. (Parameter '10')", exeption.Message);
        }

        [Fact]
        public void InsertExeption_TestSortedListClass_ShouldThrowExeption()
        {
            var testList = new SortedList<int> { 1, 2, 3, 4, 5, 6 };

            var exeption = Assert.Throws<ArgumentOutOfRangeException>(() => testList.Insert(-1, 1));
            Assert.Equal("Index should be non-negative and equal or less than the size of the list. (Parameter '-1')", exeption.Message);
        }

        [Fact]
        public void RemoveAtExeption_TestSortedListClass_ShouldThrowExeption()
        {
            var testList = new SortedList<int> { 1, 2, 3, 4, 5, 6 };

            var exeption = Assert.Throws<ArgumentOutOfRangeException>(() => testList.RemoveAt(-1));
            Assert.Equal("Index should be non-negative and equal or less than the size of the list. (Parameter '-1')", exeption.Message);
        }

        [Fact]
        public void CopyToNullExeption_TestSortedListClass_ShouldThrowExeption()
        {
            var testList = new SortedList<int> { 1, 2, 3, 4, 5, 6 };
            int[] array = null;

            var exeption = Assert.Throws<ArgumentNullException>(() => testList.CopyTo(array, 0));
            Assert.Equal("Array is null (Parameter '0')", exeption.Message);
        }

        [Fact]
        public void CopyToOutOfRangeExeption_TestSortedListClass_ShouldThrowExeption()
        {
            var testList = new SortedList<int> { 1, 2, 3, 4, 5, 6 };
            int[] array = new int[10];

            var exeption = Assert.Throws<ArgumentOutOfRangeException>(() => testList.CopyTo(array, -1));
            Assert.Equal("Index out of range. Must be positive. (Parameter '-1')", exeption.Message);
        }

        [Fact]
        public void CopyToArgumentExeption_TestSortedListClass_ShouldThrowExeption()
        {
            var testList = new SortedList<int> { 1, 2, 3, 4, 5, 6 };
            int[] array = new int[10];

            var exeption = Assert.Throws<ArgumentException>(() => testList.CopyTo(array, 8));
            Assert.Equal("The number of elements to copy is greater than the available space in the array.", exeption.Message);
        }
    }
}
