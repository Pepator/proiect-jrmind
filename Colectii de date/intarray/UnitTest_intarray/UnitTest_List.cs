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
            testList.Remove(3);

            Assert.Equal(5, testList.Count);
            Assert.False(testList.Contains(3));
        }

        [Fact]
        public void RemoveAt_TestListClass_ShouldRemoveCorrectElement()
        {
            var testList = new List<int> { 1, 2, 3, 4, 5, 6 };
            testList.RemoveAt(3);

            Assert.Equal(5, testList.Count);
            Assert.False(testList.Contains(4));
        }
    }
}
