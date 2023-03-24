using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColectiiDeDate
{
    public class UnitTest_List
    {
        [Fact]
        public void Add_TestListClass_ShouldReturnRightNumberOfElementsInOrderForInt()
        {
            var testList = new List<int> { 5, 7, 3, 20, 100 };

            Assert.Equal(5, testList.Count);
            Assert.Equal(100, testList[4]);
        }

        [Fact]
        public void Add_TestListClass_ShouldReturnRightNumberOfElementsInOrderForChar()
        {
            var testList = new List<char> { 'a', 'b', 'c', 'd' };

            Assert.Equal(4, testList.Count);
            Assert.Equal('b', testList[1]);
        }

        [Fact]
        public void Count_TestListClass_ShouldReturnRightNumberOfElements()
        {
            var testList = new List<int> { 1, 2, 3, 4, 5, 6 };

            Assert.Equal(6, testList.Count);
        }

        [Fact]
        public void Element_TestListClass_ShouldReturnCorrectElement()
        {
            var testList = new List<int> { 1, 2, 3, 4, 5, 6 };

            Assert.Equal(3, testList[2]);
        }

        [Fact]
        public void SetElement_TestListClass_ShouldReturnCorrectElement()
        {
            var testList = new List<int> { 1, 2, 3, 4, 5, 6 };
            testList[2] = 100;

            Assert.Equal(100, testList[2]);
        }

        [Fact]
        public void Contains_TestListClass_ShouldReturnTrueIfElementIsFound()
        {
            var testList = new List<char> { 'a', 'b', 'c', 'd' };

            Assert.True(testList.Contains('b'));
            Assert.False(testList.Contains('x'));
        }

        [Fact]
        public void IndexOf_TestListClass_ShouldReturnCorrectIndex()
        {
            var testList = new List<int> { 1, 2, 3, 4, 5, 6 };

            Assert.Equal(3, testList.IndexOf(4));
        }

        [Fact]
        public void Insert_TestListClass_ShouldReturnCorrectNumberOfElementsAndCorrectElement()
        {
            var testList = new List<int> { 1, 2, 3, 4, 5, 6 };
            testList.Insert(1, 100);

            Assert.Equal(7, testList.Count);
            Assert.Equal(100, testList[1]);
        }

        [Fact]
        public void Clear_TestListClass_ShouldRemoveAllElements()
        {
            var testList = new List<int> { 1, 2, 3, 4, 5, 6 };
            testList.Clear();

            Assert.Equal(0, testList.Count);
        }

        [Fact]
        public void Remove_TestListClass_ShouldRemoveCorrectElement()
        {
            var testList = new List<int> { 1, 2, 3, 4, 5, 6 };

            Assert.True(testList.Remove(3));
            Assert.Equal(5, testList.Count);
            Assert.DoesNotContain(3, testList);

        }

        [Fact]
        public void RemoveAt_TestListClass_ShouldRemoveCorrectElement()
        {
            var testList = new List<int> { 1, 2, 3, 4, 5, 6 };
            testList.RemoveAt(3);

            Assert.Equal(5, testList.Count);
            Assert.False(testList.Contains(4));
        }

        [Fact]
        public void CopyTo_TestListClass_ShouldRemoveCorrectElement()
        {
            var testList = new List<int> { 1, 2, 3, 4, 5, 6 };
            var array = new int[7];
            testList.CopyTo(array, 1);

            Assert.Equal(1, array[1]);
            Assert.Equal(6, array[6]);
        }

        [Fact]
        public void IndexGetExeption_TestListClass_ShouldThrowExeption()
        {
            var testList = new List<int> { 1, 2, 3, 4, 5, 6 };

            var exeption = Assert.Throws<ArgumentOutOfRangeException>(() => testList[-1]);
            Assert.Equal("Index should be non-negative and equal or less than the size of the list. (Parameter '-1')", exeption.Message);
        }

        [Fact]
        public void IndexSetExeption_TestListClass_ShouldThrowExeption()
        {
            var testList = new List<int> { 1, 2, 3, 4, 5, 6 };

            var exeption = Assert.Throws<ArgumentOutOfRangeException>(() => testList[10] = 1);
            Assert.Equal("Index should be non-negative and equal or less than the size of the list. (Parameter '10')", exeption.Message);
        }

        [Fact]
        public void InsertExeption_TestListClass_ShouldThrowExeption()
        {
            var testList = new List<int> { 1, 2, 3, 4, 5, 6 };

            var exeption = Assert.Throws<ArgumentOutOfRangeException>(() => testList.Insert(-1, 1));
            Assert.Equal("Index should be non-negative and equal or less than the size of the list. (Parameter '-1')", exeption.Message);
        }

        [Fact]
        public void RemoveAtExeption_TestListClass_ShouldThrowExeption()
        {
            var testList = new List<int> { 1, 2, 3, 4, 5, 6 };

            var exeption = Assert.Throws<ArgumentOutOfRangeException>(() => testList.RemoveAt(-1));
            Assert.Equal("Index should be non-negative and equal or less than the size of the list. (Parameter '-1')", exeption.Message);
        }

        [Fact]
        public void CopyToNullExeption_TestListClass_ShouldThrowExeption()
        {
            var testList = new List<int> { 1, 2, 3, 4, 5, 6 };
            int[] array = null;

            var exeption = Assert.Throws<ArgumentNullException>(() => testList.CopyTo(array, 0));
            Assert.Equal("Array is null (Parameter '0')", exeption.Message);
        }

        [Fact]
        public void CopyToOutOfRangeExeption_TestListClass_ShouldThrowExeption()
        {
            var testList = new List<int> { 1, 2, 3, 4, 5, 6 };
            int[] array = new int[10];

            var exeption = Assert.Throws<ArgumentOutOfRangeException>(() => testList.CopyTo(array, -1));
            Assert.Equal("Index out of range. Must be positive. (Parameter '-1')", exeption.Message);
        }

        [Fact]
        public void CopyToArgumentExeption_TestListClass_ShouldThrowExeption()
        {
            var testList = new List<int> { 1, 2, 3, 4, 5, 6 };
            int[] array = new int[10];

            var exeption = Assert.Throws<ArgumentException>(() => testList.CopyTo(array, 8));
            Assert.Equal("The number of elements to copy is greater than the available space in the array.", exeption.Message);
        }
    }
}
